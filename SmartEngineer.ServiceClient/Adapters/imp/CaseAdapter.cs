using log4net;
using SmartEngineer.Common;
using SmartEngineer.Framework.Logger;
using SmartEngineer.ServiceClient.JiraServiceForENGSupp;
using SmartEngineer.ServiceClient.SalesforceService;
using System;
using System.Collections.Generic;
using System.Data;

namespace SmartEngineer.ServiceClient.Adapters
{
    public class CaseAdapter : ICaseAdapter
    {
        /// <summary>
        /// Logger object.
        /// </summary>
        private static readonly ILog Logger = LogFactory.Instance.GetLogger(typeof(CaseAdapter));

        public List<string> GetCommentedCasesForToday()
        {
            List<string> caseNOs = new List<string>();

            SalesforceServiceClient client = WSFactory.Instance.GetWCFClient<SalesforceServiceClient, ISalesforceService>();
            CaseInfo[] caseInfos = client.GetCommentedCasesList();

            if (caseInfos != null)
            {
                foreach (CaseInfo caseInfo in caseInfos)
                {
                }
            }

            return caseNOs;
        }

        public List<string> GetNewCasesForToday()
        {
            List<string> caseNOs = new List<string>();

            SalesforceServiceClient client = WSFactory.Instance.GetWCFClient<SalesforceServiceClient, ISalesforceService>();
            caseNOs.AddRange(client.GetNewCasesList());
            return caseNOs;
        }

        public List<string> GetPendingCasesForToday()
        {
            throw new NotImplementedException();
        }

        public DataTable PullDetailedCaseInfo(List<string> caseNos)
        {
            //SalesforceServiceClient salesforceServiceClient = WSFactory.Instance.GetWCFClient<SalesforceServiceClient, ISalesforceService>();
            //var caseInfos = salesforceServiceClient.GetCasesByCaseNOs(caseNos.ToArray());

            JiraServiceForENGSuppClient jiraServiceForENGSuppClient = WSFactory.Instance.GetWCFClient<JiraServiceForENGSuppClient, IJiraServiceForENGSupp>();
            jiraServiceForENGSuppClient.GetIssuesByCaseNos(caseNos.ToArray());

            return null;
        }
    }
}
