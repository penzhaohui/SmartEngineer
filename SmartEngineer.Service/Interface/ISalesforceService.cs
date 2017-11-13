using SmartEngineer.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SmartEngineer.Service
{
    [ServiceContract]
    public interface ISalesforceService
    {
        [OperationContract]
        List<string> GetNewCasesList();

        [OperationContract]
        List<string> GetEngineerCasesList();

        [OperationContract]
        List<string> GetCommentedCaseList(DateTime start, DateTime end);

        [OperationContract]
        List<string> GetProductionBugList(DateTime start, DateTime end);

        [OperationContract]
        List<CaseInfo> GetCasesByCaseNOs(List<string> caseNOs);
    }
}
