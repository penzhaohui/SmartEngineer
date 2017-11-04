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

        public List<JiraIssue> GetIssuesByLabels(List<string> labels)
        {
            throw new NotImplementedException();
        }

        public List<JiraIssue> GetIssuesByStatuses(List<string> statuses)
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
            ISalesforceService SalesforceService = new SalesforceService();
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
    }
}
