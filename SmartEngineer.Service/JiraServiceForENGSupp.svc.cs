using SmartEngineer.Core.Adapter;
using SmartEngineer.Core.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using TechTalk.JiraRestClient;

namespace SmartEngineer.Service
{
    public class JiraServiceForENGSupp : IJiraServiceForENGSupp
    {
        private static readonly string JiraAccount = ConfigurationManager.AppSettings["JiraAccount"];
        private static readonly string JiraPassword = ConfigurationManager.AppSettings["JiraPassword"];

        public ISalesforceAdapterV2 SalesforceAdapter { get; set; }
        public IJiraAdapter JiraAdapter { get; set; }

        /// <summary>
        /// 缺省构造函数，确保在启动该项目时可以查看WCF Service的定义
        /// https://stackoverflow.com/questions/43802845/how-to-resolve-system-servicemodel-servicehostingenvironment-serviceactivations
        /// </summary>
        public JiraServiceForENGSupp() { }

        public JiraServiceForENGSupp(ISalesforceAdapterV2 salesforceAdapter, IJiraAdapter jiraAdapter)
        {
            SalesforceAdapter = salesforceAdapter;
            JiraAdapter = jiraAdapter;
        }

        public List<JiraIssue> GetIssuesByLabels(List<string> labels)
        {
            throw new NotImplementedException();
        }

        public List<string> GetPendingCaseList()
        {
            List<string> pendingCaseNoList = new List<string>();
            List<string> unStoredJiraKeyList = new List<string>();
            List<string> pengingJiraStatus = new List<string>();

            pengingJiraStatus.Add("In Development");
            pengingJiraStatus.Add("In Progress");
            pengingJiraStatus.Add("Open");
            pengingJiraStatus.Add("Pending");
            pengingJiraStatus.Add("Reopened");

            var issues = JiraAdapter.PullIssueListByStatus(pengingJiraStatus, JiraAccount, JiraPassword);
            foreach (Issue issue in issues)
            {
                string jiraKey = issue.key;
                if (!JiraAdapter.IsExistsLocalIssue(jiraKey))
                {
                    unStoredJiraKeyList.Add(jiraKey);
                }

                string caseNO = issue.fields.CaseNumber;
                if (!String.IsNullOrEmpty(caseNO))
                {
                    if (!pendingCaseNoList.Contains(caseNO))
                    {
                        pendingCaseNoList.Add(caseNO);
                    }
                }
            }

            return pendingCaseNoList;
        }

        public List<JiraIssue> GetIssuesByStatuses(List<string> statuses)
        {
            List<JiraIssue> jiraIssues = new List<JiraIssue>();

            var issues = JiraAdapter.PullIssueListByStatus(statuses, JiraAccount, JiraPassword);
            foreach (Issue issue in issues)
            {
                JiraIssue issueInfo = new JiraIssue();
                issueInfo.Initialize(issue);
                jiraIssues.Add(issueInfo);
            }

            return jiraIssues;
        }

        public List<JiraIssue> GetIssuesByCaseNos(List<string> caseNOs)
        {
            List<JiraIssue> jiraIssues = new List<JiraIssue>();

            List<string> unStoredCaseNoList = new List<string>();

            foreach (string caseNo in caseNOs)
            {
                if (!JiraAdapter.IsExistsLocalIssue(caseNo))
                {
                    unStoredCaseNoList.Add(caseNo);
                }
            }

            JiraAdapter.BatchStoreIssueInfoToLocalSync(unStoredCaseNoList);

            List<Issue> issues = JiraAdapter.PullIssueList(unStoredCaseNoList, JiraAccount, JiraPassword);
            foreach (Issue issue in issues)
            {
                caseNOs.Remove(issue.fields.CaseNumber);

                JiraIssue issueInfo = new JiraIssue();
                issueInfo.Initialize(issue);
                jiraIssues.Add(issueInfo);
            }

            List<JiraIssue> localIssueIList = JiraAdapter.GetIssueInfoByCaseNos(caseNOs);
            foreach (JiraIssue localIssue in localIssueIList)
            {
                if (!unStoredCaseNoList.Contains(localIssue.CaseNumber))
                {
                    jiraIssues.Add(localIssue);
                }
            }

            return jiraIssues;
        }
        public bool ImportCaseNOs(List<string> caseNOs)
        {
            throw new NotImplementedException();

            // 1. Load Case Info from local database
            // 2. Create and Update Jira Issue
            // 
        }

        public bool ImportCaseComments(List<string> caseNOs)
        {
            throw new NotImplementedException();
        }

        public bool SyncIssueStatus(List<string> caseNOs)
        {
            throw new NotImplementedException();
        }

        public bool SyncSalesforceCaseToJiraIssue(List<string> caseNOs)
        {
            ISalesforceService SalesforceService = new SalesforceService(SalesforceAdapter, JiraAdapter);
            List<string> newCaseNoList = SalesforceService.GetNewCasesList();

            // C# .Net List<T>中Remove()、RemoveAt()、RemoveRange()、RemoveAll()的区别，List<T>删除汇总
            // http://www.cnblogs.com/fancyblogs/p/7150545.html
            newCaseNoList.RemoveAll(caseNo => !caseNOs.Contains(caseNo));

            foreach (string newCaseNo in newCaseNoList)
            {
                // Assumption: The local jira record indicates it is already imported.
                if (!JiraAdapter.IsExistsLocalCase(newCaseNo) && caseNOs.Contains(newCaseNo))
                {
                    caseNOs.Remove(newCaseNo);
                }
            }

            // If it is one new case
            //      1. Create new jira issue
            //      2. Check DB Information and reproduced steps
            //      3. Create Sub Task
            JiraAdapter.ImportSalesforceCaseIntoJira(newCaseNoList); // Sync


            // If it is commented case
            //      1. Sync Jira Status
            //      2. Sync salesforce comment
            JiraAdapter.SyncInformationFromSalesforce(caseNOs); // Async

            return true;
        }

        public List<string> GetNewIssues(DateTime from, DateTime to)
        {
            List<string> jiraKeyList = new List<string>();
            var issues = JiraAdapter.GetIssueListByCreatedDate(from, to, JiraAccount, JiraPassword);
            foreach (Issue issue in issues)
            {
                jiraKeyList.Add(issue.key);
            }

            return jiraKeyList;
        }

        public List<string> GetResolvedIssues(DateTime from, DateTime to)
        {
            List<string> jiraKeyList = new List<string>();
            var issues = JiraAdapter.GetIssueListByResolutiondate(from, to, JiraAccount, JiraPassword);
            foreach (Issue issue in issues)
            {
                jiraKeyList.Add(issue.key);
            }

            return jiraKeyList;
        }

        public List<string> GetProductionBugs()
        {
            List<string> jiraKeyList = new List<string>();
            List<string> statusList = new List<string>();
            statusList.Add("Open");
            statusList.Add("In Progress");
            statusList.Add("Reopened");
            statusList.Add("Pending");
            statusList.Add("Development in Progress");

            var issues = JiraAdapter.GetBugListByBugStatus(statusList, JiraAccount, JiraPassword);
            foreach (Issue issue in issues)
            {
                jiraKeyList.Add(issue.key);
            }

            return jiraKeyList;
        } 

        public int GetTotalTimeSpent(string subTaskKey, DateTime from, DateTime to)
        {
            throw new NotImplementedException();
        }

        public int GetTotalTimeSpent(int category, DateTime from, DateTime to)
        {
            throw new NotImplementedException();
        }        
    }
}
