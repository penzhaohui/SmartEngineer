using System;
using System.Collections.Generic;

namespace SmartEngineer.Service
{
    public class ReportService : IReportService
    {
        public ReportService() { }

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
