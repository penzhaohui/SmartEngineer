using log4net;
using SmartEngineer.Core.DAOs;
using SmartEngineer.Core.Models;
using SmartEngineer.Framework.Logger;
using System;
using System.Collections.Generic;
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

        public List<Issue> GetIssueList(List<string> caseNos, string jiraAccount, string jiraPassword)
        {
            IJiraClient jira = new JiraClient(AccelaJiraUrl, jiraAccount, jiraPassword);

            string sql = String.Empty;

            foreach (string caseNo in caseNos)
            {
                if (String.IsNullOrEmpty(sql))
                {
                    sql = " \"SalesForce ID\" ~  " + caseNo;
                }
                else
                {
                    sql += " OR \"SalesForce ID\" ~  " + caseNo;
                }
            }

            sql = "(" + sql + ")";

            List<Issue> issueList = new List<Issue>();
            var issues = jira.GetIssuesByQuery("ENGSUPP", "", sql);
            foreach (Issue issue in issues)
            {
                issueList.Add(issue);
            }

            return issueList;
        }

        public async Task<Issue> CreateIssue(string project, string issueType, IssueFields fields, string jiraAccount, string jiraPassword)
        {
            IJiraClient jira = new JiraClient(AccelaJiraUrl, jiraAccount, jiraPassword);
            var issue = jira.CreateIssue(project, issueType, fields);

            return issue;
        }

        public async Task<Issue> UpdateIssue(Issue issue, string jiraAccount, string jiraPassword)
        {
            IJiraClient jira = new JiraClient(AccelaJiraUrl, jiraAccount, jiraPassword);

            var result = jira.UpdateIssue(issue);

            return result;
        }

        public async Task<Comment> CreateComment(IssueRef issue, string caseComment, string jiraAccount, string jiraPassword)
        {
            IJiraClient jira = new JiraClient(AccelaJiraUrl, jiraAccount, jiraPassword);

            var jiraComments = jira.GetComments(issue);
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
                jiraComment = jira.CreateComment(issue, caseComment);
            }

            return jiraComment;
        }

        public async Task<List<Comment>> GetComments(IssueRef issue, string jiraAccount, string jiraPassword)
        {
            IJiraClient jira = new JiraClient(AccelaJiraUrl, jiraAccount, jiraPassword);

            var jiraComments = jira.GetComments(issue);

            return (jiraComments as List<Comment>);
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