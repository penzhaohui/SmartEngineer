using SmartEngineer.Core.Models;
using System.Collections.Generic;

namespace SmartEngineer.Core.DAOs
{
    public interface ISFCaseDAO<T> : IBaseDAO<T>
        where T : CaseInfo
    {
        List<CaseInfo> GetEntitys(List<string> caseNos);
    }
}
