using SmartEngineer.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartEngineer.Core.Adapter
{
    public interface ISalesforceAdapter
    {
        Task<List<AccelaCase>> QueryCasesByEngineerQueue(string queueName, int n = 100);

        Task<List<AccelaCase>> QueryCasesByLastModifer(string lastModifier, int n = 100);

        Task<List<AccelaCase>> QueryCasesByCaseNos(List<string> caseNos);

        Task<string> CreateCaseComment(AccelaCaseComment comment);

        Task<List<AccelaCaseComment>> GetCaseCommentsByCaseID(string id);

        bool IsExistsLocalCase(string caseNo);

        bool StoreCaseInfoToLocal(AccelaCase caseInfo);

        bool UpdateLocalCaseInfo(AccelaCase caseInfo);

        bool AppendCaseCommentToLocaCase();

        bool AppendCaseAttachmentToLocalCase();
    }
}