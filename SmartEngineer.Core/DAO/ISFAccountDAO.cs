using SmartEngineer.Core.Models;
using System.Collections.Generic;

namespace SmartEngineer.Core.DAOs
{
    public interface ISFAccountDAO<T> : IBaseDAO<T>
        where T : CaseAccountInfo
    {
        List<CaseAccountInfo> GetEntitiesByName(List<string> Names);

        List<CaseAccountInfo> GetEntitiesByUserID(List<string> UserIDs);
    }
}

