using SmartEngineer.Core.Models;
using System.Collections.Generic;

namespace SmartEngineer.Core.DAOs
{
    public interface IJiraAccountDAO<T> : IBaseDAO<T>
        where T : JiraAccount
    {
    }
}
