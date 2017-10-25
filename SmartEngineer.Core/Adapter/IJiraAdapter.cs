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

        List<Issue> GetIssueList(List<string> CaseNoOrJiraKeyList, string jiraAccount, string jiraPassword);

        Task<Issue> CreateIssue(string project, string issueType, IssueFields fields, string jiraAccount, string jiraPassword);

        Task<Issue> UpdateIssue(Issue issue, string jiraAccount, string jiraPassword);

        Task<Comment> CreateComment(IssueRef issue, string caseComment, string jiraAccount, string jiraPassword);

        Task<List<Comment>> GetComments(IssueRef issue, string jiraAccount, string jiraPassword);

        Task<bool> UpdateJiraStatus(IssueRef issueRef, string jiraStatus, string jiraNextStatus, string jiraAccount, string jiraPassword);

        bool IsExistsLocalIssue(string jiraKey);

        bool IsExistsLocalCase(string caseNo);

        bool BatchStoreIssueInfoToLocal(List<string> keys);

       Task<bool> BatchStoreIssueInfoToLocalSync(List<string> keys);

        int StoreIssueInfoToLocal(IssueInfo issueInfo);

        List<string> GetUnimportedCases(List<string> caseNos);
    }
}