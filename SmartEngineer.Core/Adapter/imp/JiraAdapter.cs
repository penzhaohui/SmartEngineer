using log4net;
using SmartEngineer.Core.DAOs;
using SmartEngineer.Core.Model;
using SmartEngineer.Core.Models;
using SmartEngineer.Framework.Logger;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TechTalk.JiraRestClient;

namespace SmartEngineer.Core.Adapter
{
    public partial class JiraAdapter : IJiraAdapter
    {
        /// <summary>
        /// Logger object.
        /// </summary>
        private static readonly ILog Logger = LogFactory.Instance.GetLogger(typeof(JiraAdapter));
        private static readonly string AccelaJiraUrl = "https://accelaeng.atlassian.net/";
        private static readonly ISalesforceAdapterV2 SalesforceAdapterV2 = new SalesforceAdapterV2();
        private static readonly IConfigAdapter ConfigAdapter = new ConfigAdapter();

        public Account ValidateAccount(string userOrEmailAddress, string password)
        {
            Account account = null;

            IJiraClient client = new JiraClient("https://accelaeng.atlassian.net/", userOrEmailAddress, password); // TODO: Need cache every login user's client
            JiraUser user = client.GetMySelf();
            if (user != null)
            {
                account = new Account();
                account.UserName = user.name;
                account.Password = password; // TODO: Need encryption here.
                account.DisplayName = user.displayName;
                account.EmailAddress = user.displayName;

                AccountDAO<Account> AccountDAO = new AccountDAO<Account>();

                // Check if Account is registered in smart engineer
                // if not, then register it automatically now
                if (!AccountDAO.IsExist(account))
                {
                    AccountDAO.Insert(account);
                }

                account = AccountDAO.GetEntity(account);
            }

            return account;
        }

        public Issue PullIssue(string jiraKeyOrCaseNo, string jiraAccount, string jiraPassword)
        {
            Issue jiraIssue = null;

            List<string> CaseNoOrJiraKeyList = new List<string>();
            CaseNoOrJiraKeyList.Add(jiraKeyOrCaseNo);

            List<Issue> jiraIssueList = PullIssueList(CaseNoOrJiraKeyList, jiraAccount, jiraPassword);
            if (jiraIssueList != null && jiraIssueList.Count > 0)
            {
                jiraIssue = jiraIssueList[0];
            }

            return jiraIssue;
        }

        public List<Issue> PullIssueList(List<string> CaseNoOrJiraKeyList, string jiraAccount, string jiraPassword)
        {
            List<Issue> issueList = new List<Issue>();

            if (CaseNoOrJiraKeyList == null || CaseNoOrJiraKeyList.Count == 0) return issueList;

            IJiraClient jira = new JiraClient(AccelaJiraUrl, jiraAccount, jiraPassword);
            
            string sql = String.Empty;

            int index = 0;
            foreach (string caseNoOrJiraKey in CaseNoOrJiraKeyList)
            {
                index++;
                if (String.IsNullOrEmpty(sql))
                {
                    if (caseNoOrJiraKey.StartsWith("ENGSUPP"))
                    {
                        sql = " key = " + caseNoOrJiraKey;
                    }
                    else
                    {
                        sql = " \"SalesForce ID\" ~  " + caseNoOrJiraKey;
                    }
                }
                else
                {
                    if (caseNoOrJiraKey.StartsWith("ENGSUPP"))
                    {
                        sql += " OR key =  " + caseNoOrJiraKey;
                    }
                    else
                    {
                        sql += " OR \"SalesForce ID\" ~  " + caseNoOrJiraKey;
                    }
                }

                if (index % 50 == 0 || index == CaseNoOrJiraKeyList.Count)
                {
                    sql = "(" + sql + ")";
                    var issues = jira.GetIssuesByQuery("ENGSUPP", "", sql);
                    foreach (Issue issue in issues)
                    {
                        issueList.Add(issue);
                    }

                    sql = String.Empty;
                }
            }
            
            return issueList;
        }

        public Issue CreateIssue(string project, string issueType, IssueFields fields, string jiraAccount, string jiraPassword)
        {
            IJiraClient jira = new JiraClient(AccelaJiraUrl, jiraAccount, jiraPassword);
            var issue = jira.CreateIssue(project, issueType, fields);

            return issue;
        }

        public List<string> ImportSalesforceCaseIntoJira(List<string> caseNOs)
        {
            List<string> jiraKeyList = new List<string>();

            if (caseNOs == null || caseNOs.Count == 0) return jiraKeyList;

            SalesforceAdapterV2.BatchStoreCaseInfoToLocalSync(caseNOs);

            IReadOnlyList<string> newCaseNoList = caseNOs.AsReadOnly(); 
            int loopNumber = 1;
            do
            {
                string jiraKey = string.Empty;
                int failedTimes = 0;
                foreach (string caseNo in newCaseNoList)
                {
                    // Assumption: The existing local jira record indicates it is already imported.
                    if (!IsExistsLocalCase(caseNo))
                    {
                        // Ensure the case is not imported by other tool at this moment.
                        Issue jiraIssue = PullIssue(caseNo, JiraAccount, JiraPassword);
                        if (jiraIssue == null)
                        {
                            if (SalesforceAdapterV2.IsExistsLocalCase(caseNo))
                            {
                                CaseInfo caseInfo = SalesforceAdapterV2.GetCaseInfoByCaseNo(caseNo);
                                jiraIssue = caseInfo.ConvertToIssue();
                                jiraIssue = CreateIssue("ENGSUPP", "Case", jiraIssue.fields, JiraAccount, JiraPassword);                                
                            }

                            if (jiraIssue == null || String.IsNullOrEmpty(jiraIssue.key))
                            {
                                failedTimes++; // Record failed times
                                continue;
                            }
                        }

                        JiraIssue localJiraIssue = new JiraIssue();
                        localJiraIssue.Initialize(jiraIssue);
                        StoreIssueInfoToLocal(localJiraIssue);

                        jiraKey = localJiraIssue.JiraKey;
                        jiraKeyList.Add(localJiraIssue.JiraKey);
                    }

                    // Create Default Sub Tasks
                    CreateDefaultSubTasks(jiraKey);

                    caseNOs.Remove(caseNo);                    
                }

                // Pause 1 second due to that no case is ready
                if (failedTimes == newCaseNoList.Count)
                {
                    Thread.Sleep(1000); 
                }

                newCaseNoList = caseNOs.AsReadOnly(); // Reset the new case list for next loop
                loopNumber++;

            } while (loopNumber < 5 && caseNOs.Count > 0);

            return jiraKeyList;
        }

        public bool SyncInformationFromSalesforce(List<string> caseNOs)
        {
            foreach (string caseNo in caseNOs)
            {
                CaseInfo caseInfo = SalesforceAdapterV2.UpdateCaseInfoToLocal(caseNo);
                SyncCaseInfotToJira(caseInfo);
                SyncCaseStatusToJira(caseInfo);

                bool isUpdateSuccess = SalesforceAdapterV2.UpdateCaseCommentInfoToLocal(caseNo);
                if (isUpdateSuccess)
                {
                    SyncCaseCommentToJira(caseNo);
                }
            }

            // Always return true
            return true;
        }

        private bool SyncCaseInfotToJira(CaseInfo caseInfo)
        {
            var jiraIssueInfo = GetIssueInfoByCaseNo(caseInfo.CaseNumber); 

            bool isNeedUpdateJira = !jiraIssueInfo.IsEqualCase(caseInfo);
            if (isNeedUpdateJira)
            {
                Issue issue = PullIssue(jiraIssueInfo.JiraKey, JiraAccount, JiraPassword);
                issue = caseInfo.MergeToIssue(issue);
                UpdateIssue(issue, JiraAccount, JiraPassword);
            }

            return true;
        }

        private bool SyncCaseStatusToJira(CaseInfo caseInfo)
        {
            string caseOwner = caseInfo.CaseOwner;
            string caseStaus = caseInfo.Status;
            string jiraIssueType = "";
            string jiraStatus = "";

            string jiraTargetStatus = GetJiraTargetStatus(jiraIssueType, jiraStatus, caseOwner, caseStaus);

            IssueRef issueRef = new IssueRef();
            issueRef.key = "";

            UpdateJiraStatus(issueRef, jiraStatus, jiraTargetStatus, JiraAccount, JiraPassword);

            return true;
        }

        private string GetJiraTargetStatus(string jiraIssueType, string jiraStatus, string caseOwner, string caseStaus)
        {
            string nextJiraStatus = "";

            if ("Bug".Equals(jiraIssueType, StringComparison.InvariantCultureIgnoreCase))
            {
                if ("Pending".Equals(jiraStatus, StringComparison.InvariantCultureIgnoreCase)
                    || "Open".Equals(jiraStatus, StringComparison.InvariantCultureIgnoreCase)
                    || "In Progress".Equals(jiraStatus, StringComparison.InvariantCultureIgnoreCase))
                {
                    nextJiraStatus = "Dev In Progress";
                }
            }

            if ("Case".Equals(jiraIssueType, StringComparison.InvariantCultureIgnoreCase))
            {

                // sql += " and (status ='eng qa' or status ='qa in progress' or status ='engqa') ";
                if ("Engineering".Equals(caseOwner, System.StringComparison.InvariantCultureIgnoreCase)
                    && ("Eng New".Equals(caseStaus, System.StringComparison.InvariantCultureIgnoreCase)
                        || "Eng QA".Equals(caseStaus, System.StringComparison.InvariantCultureIgnoreCase)
                        || "Qa In Progress".Equals(caseStaus, System.StringComparison.InvariantCultureIgnoreCase)
                        || "EngQA".Equals(caseStaus, System.StringComparison.InvariantCultureIgnoreCase)))
                {
                    if (!"In Progress".Equals(jiraStatus, StringComparison.InvariantCultureIgnoreCase))
                    {
                        nextJiraStatus = "In Progress";
                    }
                }
                else
                {
                    if ("CLOSED".Equals(caseStaus, StringComparison.InvariantCultureIgnoreCase)
                        || "PM Assigned".Equals(caseStaus, StringComparison.InvariantCultureIgnoreCase)
                        || "Ideas (Closed)".Equals(caseStaus, StringComparison.InvariantCultureIgnoreCase)
                        || "Closed - Knowledge".Equals(caseStaus, StringComparison.InvariantCultureIgnoreCase)
                        || "SPAM Closed".Equals(caseStaus, StringComparison.InvariantCultureIgnoreCase))
                    {
                        if (!"Closed".Equals(jiraStatus, StringComparison.InvariantCultureIgnoreCase))
                        {
                            nextJiraStatus = "Closed";
                        }
                    }
                }

            }

            return nextJiraStatus;
        }

        private bool SyncCaseCommentToJira(string caseNo)
        {
            return true;
        }

        private void CreateDefaultSubTasks(string jiraKey)
        {            
            var jiraIssue = GetIssueInfoByJiraKey(jiraKey);
            var jiraIssueType = jiraIssue.IssueType;
            var jiraIssueStatus = jiraIssue.Status;
            var jiraIssueProject = "ENGSUPP"; // jiraIssue.Project;

            Dictionary<string, dynamic> configOptions = ConfigAdapter.GeSubTaskTemplates(jiraIssueProject);
            if (configOptions != null)
            {
                foreach (KeyValuePair<string, dynamic> configOption in configOptions)
                {
                    // Project=ENGSUPP;IssueType=Case;IsDefaultSubTask=Yes
                    if (jiraIssueProject == configOption.Value.Project
                        && jiraIssueType == configOption.Value.IssueType
                        && true == configOption.Value.IsDefaultSubTask
                        && true == configOption.Value.IsActive)
                    {
                        CreateSubTask(jiraIssueProject,
                                      jiraKey,
                                      configOption.Value.ConfigOptionValue,
                                      configOption.Value.ConfigOptionDesc,
                                      JiraAccount,
                                      JiraPassword);
                    }
                }
            }
        }

        public Issue CreateSubTask(string project, string jiraKey, string subTaskSummary, string subTaskSummaryDescription, string jiraAccount, string jiraPassword)
        {
            IJiraClient jira = new JiraClient("https://accelaeng.atlassian.net/", jiraAccount, jiraPassword);

            var issue = jira.CreateSubTask(project, jiraKey, subTaskSummary, subTaskSummaryDescription);

            return issue;
        }

        public async Task<Issue> UpdateIssue(Issue issue, string jiraAccount, string jiraPassword)
        {
            IJiraClient jira = new JiraClient(AccelaJiraUrl, jiraAccount, jiraPassword);

            var result = jira.UpdateIssue(issue);

            return result;
        }

        public async Task<Comment> CreateComment(IssueRef issueRef, string caseComment, string jiraAccount, string jiraPassword)
        {
            IJiraClient jira = new JiraClient(AccelaJiraUrl, jiraAccount, jiraPassword);

            var jiraComments = jira.GetComments(issueRef);
            bool isFound = false;
            Comment jiraComment = null;
            foreach (Comment temp in jiraComments)
            {
                if (temp.body.Equals(caseComment, System.StringComparison.InvariantCultureIgnoreCase))
                {
                    jiraComment = temp;
                    isFound = true;
                    break;
                }
            }

            if (!isFound)
            {
                jiraComment = jira.CreateComment(issueRef, caseComment);
            }

            return jiraComment;
        }

        public List<Comment> PullComments(IssueRef issueRef, string jiraAccount, string jiraPassword)
        {
            IJiraClient jira = new JiraClient(AccelaJiraUrl, jiraAccount, jiraPassword);

            var jiraComments = jira.GetComments(issueRef);

            return (jiraComments as List<Comment>);
        }

        public List<SubTask> PullSubTasks(IssueRef issueRef, string jiraAccount, string jiraPassword)
        {
            List<SubTask> subTaskList = new List<SubTask>();
            // https://accelaeng.atlassian.net/rest/api/2/search?jql=project=ENGSUPP AND issuetype in subTaskIssueTypes() AND parent=ENGSUPP-14674
            // project = ENGSUPP AND issuetype in subTaskIssueTypes() AND parent = ENGSUPP - 14674
            IJiraClient jira = new JiraClient(AccelaJiraUrl, jiraAccount, jiraPassword);

            var subTasks = jira.GetSubTasksByQuery("", $"parent={issueRef.key}");
            foreach (SubTask subTask in subTasks)
            {
                subTaskList.Add(subTask);
            }

            return subTaskList;
        }

        public List<Worklog> PullWorkLogs(IssueRef issueRef, string jiraAccount, string jiraPassword)
        {
            IJiraClient jira = new JiraClient(AccelaJiraUrl, jiraAccount, jiraPassword);

            var workLogs = jira.GetWorklogs(issueRef);

            return (workLogs as List<Worklog>);
        }

        public async Task<bool> UpdateJiraStatus(IssueRef issueRef, string jiraStatus, string jiraNextStatus, string jiraAccount, string jiraPassword)
        {
            IJiraClient jira = new JiraClient(AccelaJiraUrl, jiraAccount, jiraPassword);

            var transitions = jira.GetTransitions(issueRef);
            if ("Closed".Equals(jiraStatus, System.StringComparison.InvariantCultureIgnoreCase)
                && jiraNextStatus == "In Progress")
            {
                foreach (var transition in transitions)
                {
                    if ("Re-Open".Equals(transition.name, System.StringComparison.InvariantCultureIgnoreCase))
                    {
                        jira.TransitionIssue(issueRef, transition);
                        break;
                    }
                }
            }

            if ("Pending".Equals(jiraStatus, System.StringComparison.InvariantCultureIgnoreCase)
                && jiraNextStatus == "In Progress")
            {
                foreach (var transition in transitions)
                {
                    if ("Analysis In Progress".Equals(transition.name, System.StringComparison.InvariantCultureIgnoreCase))
                    {
                        jira.TransitionIssue(issueRef, transition);
                        break;
                    }
                }
            }

            if ("In Progress".Equals(jiraStatus, System.StringComparison.InvariantCultureIgnoreCase)
                && jiraNextStatus == "Pending")
            {
                foreach (var transition in transitions)
                {
                    if ("Commented".Equals(transition.name, System.StringComparison.InvariantCultureIgnoreCase))
                    {
                        jira.TransitionIssue(issueRef, transition);
                        break;
                    }
                }
            }

            if (("Pending".Equals(jiraStatus, System.StringComparison.InvariantCultureIgnoreCase)
                || "Resolved".Equals(jiraStatus, System.StringComparison.InvariantCultureIgnoreCase))
                && jiraNextStatus == "Closed")
            {
                foreach (var transition in transitions)
                {
                    if ("Closed".Equals(transition.name, System.StringComparison.InvariantCultureIgnoreCase))
                    {
                        jira.TransitionIssue(issueRef, transition);
                        break;
                    }
                }
            }

            return true;
        }    
    }
}