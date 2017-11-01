using SmartEngineer.Core.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartEngineer.Core.Adapter
{
    public interface ISalesforceAdapterV2
    {
        IList<AccelaCase> QueryCasesByEngineerQueue(string queueName, int n = 100);
        IList<AccelaCase> QueryCasesByLastModifer(string lastModifier, int n = 100);
        IList<AccelaCase> PullCasesByCaseNos(List<string> caseNos);
        List<CaseInfo> GetCaseInfoByCaseNos(List<string> caseNos);

        IList<AccelaCaseComment> PullCaseCommentsByParentID(string parentId, string creatorId, DateTime? from = null, DateTime? end = null);

        string CreateCaseComment(AccelaCaseComment comment);

        List<string> GetProcessedCaseNOs(DateTime from, DateTime end, string editor);

        List<string> GetUnstoredLocalCases(List<string> caseNos);

        bool IsExistsLocalCase(string caseNo);
        CaseInfo GetCaseInfoByCaseNo(string caseNo);
        int StoreCaseInfoToLocal(CaseInfo caseInfo);
        CaseInfo UpdateCaseInfoToLocal(string caseNo);
        bool UpdateCaseCommentInfoToLocal(string caseNo);
        bool BatchStoreCaseInfoToLocal(List<string> keys);
        Task<bool> BatchStoreCaseInfoToLocalSync(List<string> keys);
    }
}