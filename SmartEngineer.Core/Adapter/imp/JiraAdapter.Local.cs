using SmartEngineer.Core.DAOs;
using SmartEngineer.Core.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Threading.Tasks;
using TechTalk.JiraRestClient;

namespace SmartEngineer.Core.Adapter
{
    public partial class JiraAdapter : IJiraAdapter
    {
        private static readonly IJiraIssueDAO<IssueInfo> JiraIssueDAO = new JiraIssueDAO<IssueInfo>();
        private static readonly string JiraAccount = ConfigurationManager.AppSettings["JiraAccount"];
        private static readonly string JiraPassword = ConfigurationManager.AppSettings["JiraPassword"];

        public bool IsExistsLocalIssue(string jiraKey)
        {
            return JiraIssueDAO.IsExist(new { JiraKey = jiraKey });
        }

        public bool IsExistsLocalCase(string caseNo)
        {
            return JiraIssueDAO.IsExist(new { CaseNumber = caseNo });
        }

        public bool BatchStoreIssueInfoToLocal(List<string> keys)
        {
            // If jira issue/task is not stored into local database, store it
            // Save jira basic information into JiraIssue
            // Save jira comments into JiraIssueComments
            // Save jira attachment into JiraIssueAttachments
            // Save jira sub task into JiraIssueSubTask
            // Save jira work logs into JiraIssueWorkLogs
            if (keys.Count == 0) return true;

            List<Issue> issues = GetIssueList(keys, JiraAccount, JiraPassword);

            IssueInfo issueInfo = null;

            foreach (Issue issue in issues)
            {
                try
                {
                    issueInfo = new IssueInfo();
                    issueInfo.Initialize(issue);
                    StoreIssueInfoToLocal(issueInfo);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Logger.Error($"Encouter one exception while executing the function BatchStoreIssueInfoToLocal, the detailed message {ex.Message}");
                }
            }

            return true;
        }

        public async Task<bool> BatchStoreIssueInfoToLocalSync(List<string> keys)
        {
            return BatchStoreIssueInfoToLocal(keys);
        }

        public int StoreIssueInfoToLocal(IssueInfo issueInfo)
        {
            IssueInfo entity = null;

            if (!IsExistsLocalIssue(issueInfo.JiraKey))
            {
                entity = JiraIssueDAO.Insert(issueInfo);
            }

            return entity != null ? entity.ID : 0;
        }

        public List<string> GetUnimportedCases(List<string> caseNos)
        {
            List<string> unimportedCases = new List<string>();

            List<IssueInfo> issues = JiraIssueDAO.GetEntitys(caseNos);

            foreach (IssueInfo issue in issues)
            {
                caseNos.Remove(issue.CaseNumber);
            }

            unimportedCases.AddRange(caseNos);

            return unimportedCases;
        }
    }
}