using SmartEngineer.Core.Models;
using System.Collections.Generic;

namespace SmartEngineer.Core.DAOs
{
    public interface IJiraWorkLogDAO<T> : IBaseDAO<T>
        where T : JiraWorkLog
    {
    }
}
