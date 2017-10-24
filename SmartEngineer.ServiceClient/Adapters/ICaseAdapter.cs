using SmartEngineer.ServiceClient.SalesforceService;
using System.Collections.Generic;
using System.Data;

namespace SmartEngineer.ServiceClient.Adapters
{
    public interface ICaseAdapter
    {
        List<string> GetNewCasesForToday();

        List<string> GetCommentedCasesForToday();

        List<string> GetPendingCasesForToday();

        DataTable PullDetailedCaseInfo(List<string> caseNos);
    }
}
