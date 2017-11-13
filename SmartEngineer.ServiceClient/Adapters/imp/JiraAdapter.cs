using SmartEngineer.Common;
using SmartEngineer.ServiceClient.JiraServiceForENGSupp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartEngineer.ServiceClient.Adapters
{
    public class JiraAdapter : IJiraAdapter
    {
        public List<string> GetPendingCasesForToday()
        {
            List<string> caseNOs = new List<string>();
            JiraServiceForENGSuppClient jiraServiceForENGSuppClient = WSFactory.Instance.GetWCFClient<JiraServiceForENGSuppClient, IJiraServiceForENGSupp>();
            caseNOs.AddRange(jiraServiceForENGSuppClient.GetPendingCaseList());

            return caseNOs;
        }

        public bool SyncSalesforceToJira(List<string> caseNos)
        {
            JiraServiceForENGSuppClient jiraServiceForENGSuppClient = WSFactory.Instance.GetWCFClient<JiraServiceForENGSuppClient, IJiraServiceForENGSupp>();

            return jiraServiceForENGSuppClient.SyncSalesforceCaseToJiraIssue(caseNos.ToArray());
        }

        public List<string> GetNewIssues(DateTime from, DateTime to)
        {
            List<string> caseNOs = new List<string>();
            JiraServiceForENGSuppClient jiraServiceForENGSuppClient = WSFactory.Instance.GetWCFClient<JiraServiceForENGSuppClient, IJiraServiceForENGSupp>();
            caseNOs.AddRange(jiraServiceForENGSuppClient.GetNewIssues(from, to));

            return caseNOs;
        }

        public List<string> GetResolvedIssues(DateTime from, DateTime to)
        {
            List<string> caseNOs = new List<string>();
            JiraServiceForENGSuppClient jiraServiceForENGSuppClient = WSFactory.Instance.GetWCFClient<JiraServiceForENGSuppClient, IJiraServiceForENGSupp>();
            caseNOs.AddRange(jiraServiceForENGSuppClient.GetResolvedIssues(from, to));

            return caseNOs;
        }

        public List<string> GetProductionBugs()
        {
            List<string> caseNOs = new List<string>();
            JiraServiceForENGSuppClient jiraServiceForENGSuppClient = WSFactory.Instance.GetWCFClient<JiraServiceForENGSuppClient, IJiraServiceForENGSupp>();
            caseNOs.AddRange(jiraServiceForENGSuppClient.GetProductionBugs());

            return caseNOs;
        }
    }
}
