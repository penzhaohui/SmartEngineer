using SmartEngineer.Core.Models;

namespace SmartEngineer.Core.DAOs
{
    public interface IMemberGroupDAO<T> : IBaseDAO<T>
        where T : MemberGroup
    {
    }
}