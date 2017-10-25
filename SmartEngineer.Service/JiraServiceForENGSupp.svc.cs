using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using SmartEngineer.Core.Models;
using SmartEngineer.Core.Adapter;
using System.Configuration;
using TechTalk.JiraRestClient;

namespace SmartEngineer.Service
{
    /// <summary>
    /// TO DO: 
    /// </summary>
    public class JiraServiceForENGSupp : IJiraServiceForENGSupp
    {
        private static readonly IJiraAdapter JiraAdapter = new JiraAdapter();
        private static readonly ISalesforceAdapterV2 SalesforceAdapterV2 = new SalesforceAdapterV2();
        private static readonly string JiraAccount = ConfigurationManager.AppSettings["JiraAccount"];
        private static readonly string JiraPassword = ConfigurationManager.AppSettings["JiraPassword"];

        public List<IssueInfo> GetIssuesByCaseNos(List<string> caseNOs)
        {
            List<IssueInfo> jiraIssues = new List<IssueInfo>();

            List<string> unStoredJiraKeyList = new List<string>();
            List<string> unStoredCaseNoList = new List<string>();

            List<Issue> issues = JiraAdapter.GetIssueList(caseNOs, JiraAccount, JiraPassword);
            if (issues.Count == 0)
            {
                unStoredCaseNoList.AddRange(caseNOs);
            }
            else
            {
                foreach (Issue issue in issues)
                {
                    string caseNo = issue.fields.CaseNumber;
                    if (!JiraAdapter.IsExistsLocalIssue(issue.key))
                    {
                        unStoredJiraKeyList.Add(issue.key);
                    }

                    if (!SalesforceAdapterV2.IsExistsLocalCase(caseNo))
                    {
                        unStoredCaseNoList.Add(caseNo);
                    }
                }
            }

            // If jira issue/task is not stored into local database, store it
            // Save jira basic information into JiraIssue
            // Save jira comments into JiraIssueComments
            // Save jira attachment into JiraIssueAttachments
            // Save jira sub task into JiraIssueSubTask
            // Save jira work logs into JiraIssueWorkLogs
            JiraAdapter.BatchStoreIssueInfoToLocalSync(unStoredJiraKeyList);

            // If salesforce case is not stored into local database, store it
            // Save case basic information into SFCase
            // Save case comment into SFCaseComments
            // Save case attachment into SFCaseAttachments
            SalesforceAdapterV2.BatchStoreCaseInfoToLocalSync(unStoredCaseNoList);

            return jiraIssues;
        }

        public List<IssueInfo> GetIssuesByLabels(List<string> labels)
        {
            throw new NotImplementedException();
        }

        public List<IssueInfo> GetIssuesByStatuses(List<string> statuses)
        {
            throw new NotImplementedException();
        }

        public int GetNewIssueCount(DateTime from, DateTime to)
        {
            throw new NotImplementedException();
        }

        public int GetProductionBugCount(DateTime from, DateTime to)
        {
            throw new NotImplementedException();
        }

        public int GetProductionBugCount()
        {
            throw new NotImplementedException();
        }

        public int GetResolvedIssueCount(DateTime from, DateTime to)
        {
            throw new NotImplementedException();
        }

        public int GetTotalTimeSpent(string subTaskKey, DateTime from, DateTime to)
        {
            throw new NotImplementedException();
        }

        public int GetTotalTimeSpent(int category, DateTime from, DateTime to)
        {
            throw new NotImplementedException();
        }

        public bool ImportCaseComments(List<string> caseNOs)
        {
            throw new NotImplementedException();
        }

        public bool ImportCaseNOs(List<string> caseNOs)
        {
            throw new NotImplementedException();

            // 1. Load Case Info from local database
            // 2. Create and Update Jira Issue
            // 
        }

        public bool SyncIssueStatus(List<string> caseNOs)
        {
            throw new NotImplementedException();
        }

        public bool SyncSalesforceCaseToJiraIssue(List<string> caseNOs)
        {
            throw new NotImplementedException();
        }
    }
}
