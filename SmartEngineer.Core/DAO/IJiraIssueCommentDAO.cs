using SmartEngineer.Core.Models;

namespace SmartEngineer.Core.DAOs
{
    public interface IJiraIssueCommentDAO<T> : IBaseDAO<T>
        where T : JiraIssueComment
    {
    }
}
