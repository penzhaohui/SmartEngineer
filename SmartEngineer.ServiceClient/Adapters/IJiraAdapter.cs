using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartEngineer.ServiceClient.Adapters
{
    public interface IJiraAdapter
    {
        List<string> GetPendingCasesForToday();

        bool SyncSalesforceToJira(List<string> caseNos);

        List<string> GetNewIssues(DateTime from, DateTime to);

        List<string> GetResolvedIssues(DateTime from, DateTime to);

        List<string> GetProductionBugs();
    }
}
