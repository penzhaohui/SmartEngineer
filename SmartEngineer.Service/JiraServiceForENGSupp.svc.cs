using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using SmartEngineer.Core.Models;

namespace SmartEngineer.Service
{
    /// <summary>
    /// TO DO: 
    /// </summary>
    public class JiraServiceForENGSupp : IJiraServiceForENGSupp
    {
        public List<IssueInfo> GetIssuesByCaseNos(List<string> caseNOs)
        {
            throw new NotImplementedException();
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
