using SmartEngineer.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using TechTalk.JiraRestClient;

namespace SmartEngineer.Core.Adapter
{
    public interface IJiraAdapter
    {
        /// <summary>
        /// Validate jira user
        /// </summary>
        /// <param name="userOrEmailAddress">user name or email address</param>
        /// <param name="password">password</param>
        /// <returns>account</returns>
        Account ValidateAccount(string userOrEmailAddress, string password);

        List<Issue> PullIssueList(List<string> CaseNoOrJiraKeyList, string jiraAccount, string jiraPassword);
        Issue PullIssue(string jiraKeyOrCaseNo, string jiraAccount, string jiraPassword);
        List<Issue> PullIssueListByStatus(List<string> statusList, string jiraAccount, string jiraPassword);
        Issue CreateIssue(string project, string issueType, IssueFields fields, string jiraAccount, string jiraPassword);
        Task<Issue> UpdateIssue(Issue issue, string jiraAccount, string jiraPassword);
        List<Comment> PullComments(IssueRef issueRef, string jiraAccount, string jiraPassword);
        Task<Comment> CreateComment(IssueRef issueRef, string caseComment, string jiraAccount, string jiraPassword);
        List<SubTask> PullSubTasks(IssueRef issueRef, string jiraAccount, string jiraPassword);
        List<Worklog> PullWorkLogs(IssueRef issueRef, string jiraAccount, string jiraPassword);
        
        Task<bool> UpdateJiraStatus(IssueRef issueRef, string jiraStatus, string jiraNextStatus, string jiraAccount, string jiraPassword);

        List<Issue> GetIssueListByCreatedDate(DateTime start, DateTime end, string jiraAccount, string jiraPassword);
        List<Issue> GetIssueListByResolutiondate(DateTime start, DateTime end, string jiraAccount, string jiraPassword);
        List<Issue> GetBugListByBugStatus(List<string> statusList, string jiraAccount, string jiraPassword);

        List<JiraIssue> GetIssueInfoByCaseNos(List<string> caseNos);
        List<JiraIssue> GetIssueInfoByJiraKeys(List<string> jiraKeys);
        List<string> GetUnimportedCases(List<string> caseNos);
        bool IsExistsLocalIssue(string jiraKey);
        bool IsExistsLocalCase(string caseNo);

        List<string> BatchStoreIssueInfoToLocal(List<string> caseNOs);
        Task<bool> BatchStoreIssueInfoToLocalSync(List<string> keys);
        int StoreIssueInfoToLocal(JiraIssue issueInfo);

        List<string> ImportSalesforceCaseIntoJira(List<string> caseNOs);
        bool SyncInformationFromSalesforce(List<string> caseNOs);
    }
}