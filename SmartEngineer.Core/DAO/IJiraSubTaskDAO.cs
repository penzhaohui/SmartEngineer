using SmartEngineer.Core.Models;
using System.Collections.Generic;

namespace SmartEngineer.Core.DAOs
{
    public interface IJiraSubTaskDAO<T> : IBaseDAO<T>
        where T : JiraSubTask
    {
        List<JiraSubTask> GetEntitiesByParentJiraKey(string parentJiraKey);
    }
}
