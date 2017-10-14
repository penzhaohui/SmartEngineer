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

        Task<Issue> CreateIssue(string project, string issueType, IssueFields fields, string jiraAccount, string jiraPassword);

        Task<Issue> UpdateIssue(Issue issue, string jiraAccount, string jiraPassword);
    }
}