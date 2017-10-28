using SmartEngineer.Core.Models;
using System.Collections.Generic;

namespace SmartEngineer.Core.DAOs
{
    public interface IJiraIssueDAO<T> : IBaseDAO<T>
        where T : JiraIssue
    {
        List<JiraIssue> GetEntitiesByCaseNo(List<string> caseNos);

        List<JiraIssue> GetEntitiesByJiraKey(List<string> caseNos);
    }
}
