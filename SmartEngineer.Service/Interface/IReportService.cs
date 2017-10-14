using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SmartEngineer.Service
{
    [ServiceContract]
    public interface IReportService
    {
        [OperationContract]
        bool SendOutDailyWorkLogReport(DateTime workday);

        [OperationContract]
        bool SendOutDailyReviewedCaseReport(List<string> caseNos);

        [OperationContract]
        bool SendOutClosedCaseReport(List<string> caseNos);                   

        [OperationContract]
        void SendOutWeeklyCaseReport();

        [OperationContract]
        void SendOutReleaseStatusReport(List<string> caseNos);

        [OperationContract]
        void SendOutReleaseSummaryReport(string version);
    }
}
