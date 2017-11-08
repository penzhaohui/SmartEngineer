using SmartEngineer.Core.Models;
using System.Collections.Generic;

namespace SmartEngineer.Core.DAOs
{
    public interface ISFCaseCommentDAO<T> : IBaseDAO<T>
        where T : CaseCommentInfo
    {
        List<CaseCommentInfo> GetEntitiesByCaseNos(List<string> CaseNos);

        List<CaseCommentInfo> GetEntitiesByCaseId(List<string> CaseIDs);

        List<CaseCommentInfo> GetEntitiesByAuthors(string caseNo, List<string> Authors);
    }
}
