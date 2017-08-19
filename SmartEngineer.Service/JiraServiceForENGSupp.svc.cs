using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SmartEngineer.Service
{
    /// <summary>
    /// TO DO: 
    /// </summary>
    public class JiraServiceForENGSupp : IJiraServiceForENGSupp
    {
        public void GetIssuesByLabelList(List<string> labelList)
        {
            return;
        }

        public void GetIssuesBySalesforceIDList(List<string> caseIDList)
        {
            throw new NotImplementedException();
        }

        public void GetIssuesByStatusList(List<string> statusList)
        {
            throw new NotImplementedException();
        }

        public void ImportSalesforceCaseComments(List<string> caseIDList)
        {
            throw new NotImplementedException();
        }

        public void ImportSalesforceCases(List<string> caseIDList)
        {
            throw new NotImplementedException();
        }

        public void UpdateJiraIssueStatusForSalesforceIDList(List<string> caseIDList)
        {
            throw new NotImplementedException();
        }

        public void UpdateSalesforceCases(List<string> caseIDList)
        {
            throw new NotImplementedException();
        }
    }
}
