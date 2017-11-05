using SmartEngineer.Core.Models;

namespace SmartEngineer.Core.DAOs
{
    public interface IMemberDAO<T> : IBaseDAO<T>
        where T : Member
    {
    }
}
