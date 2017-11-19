using SmartEngineer.Core.Models;

namespace SmartEngineer.Core.DAOs
{
    public interface IMemberRoleDAO<T> : IBaseDAO<T>
        where T : MemberRole
    {
    }
}
