using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SmartEngineer.Service
{
    public class ReportService : IReportService
    {
        public bool SendOutClosedCaseReport(List<string> caseNos)
        {
            throw new NotImplementedException();
        }

        public bool SendOutDailyReviewedCaseReport(List<string> caseNos)
        {
            throw new NotImplementedException();
        }

        public bool SendOutDailyWorkLogReport(DateTime workday)
        {
            throw new NotImplementedException();
        }

        public void SendOutReleaseStatusReport(List<string> caseNos)
        {
            throw new NotImplementedException();
        }

        public void SendOutReleaseSummaryReport(string version)
        {
            throw new NotImplementedException();
        }

        public void SendOutWeeklyCaseReport()
        {
            throw new NotImplementedException();
        }
    }
}
