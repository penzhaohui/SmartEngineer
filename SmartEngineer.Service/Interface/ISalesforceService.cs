using SmartEngineer.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SmartEngineer.Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ISalesforceService" in both code and config file together.
    [ServiceContract]
    public interface ISalesforceService
    {
        [OperationContract]
        List<CaseInfo> GetNewCasesList();

        [OperationContract]
        List<CaseInfo> GetCommentedCasesList();

        [OperationContract]
        List<CaseInfo> GetCasesByCaseNOs(List<string> caseNOs);

        [OperationContract]
        List<CaseInfo> GetProcessedCase(DateTime from, DateTime to, List<string> sfAccounts);

        [OperationContract]
        int GetTotalNewCaseCount();

        [OperationContract]
        int GetCaseCommentCount(DateTime from, DateTime to);

        [OperationContract]
        int GetReviewedCaseCount(DateTime from, DateTime to);

        // [OperationContract]
        // int GetReviewedCaseCount(DateTime workday);
    }
}
