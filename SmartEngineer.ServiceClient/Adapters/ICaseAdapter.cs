using SmartEngineer.ServiceClient.SalesforceService;
using System;
using System.Collections.Generic;
using System.Data;

namespace SmartEngineer.ServiceClient.Adapters
{
    public interface ICaseAdapter
    {
        List<string> GetNewCasesForToday();

        List<string> GetEngineerCasesList();

        List<string> GetCommentedCasesForToday();

        List<string> GetCommentedCases(DateTime start, DateTime end);

        DataTable PullDetailedCaseInfo(List<string> caseNos);

        List<string> GetProductionBugList(DateTime start, DateTime end);
    }
}
