using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SmartEngineer.Service
{
    [ServiceContract]
    public interface IJiraServiceForENGSupp
    {
        [OperationContract]
        void GetIssuesByLabelList(List<string> labelList);

        [OperationContract]
        void GetIssuesByStatusList(List<string> statusList);

        [OperationContract]
        void GetIssuesBySalesforceIDList(List<string> caseIDList);

        [OperationContract]
        void ImportSalesforceCases(List<string> caseIDList);

        [OperationContract]
        void UpdateSalesforceCases(List<string> caseIDList);

        [OperationContract]
        void ImportSalesforceCaseComments(List<string> caseIDList);

        [OperationContract]
        void UpdateJiraIssueStatusForSalesforceIDList(List<string> caseIDList);
    }
}
