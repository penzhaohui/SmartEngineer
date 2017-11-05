using SmartEngineer.Core.Models;

namespace SmartEngineer.Core.DAOs
{
    public interface IRoleDAO<T> : IBaseDAO<T>
        where T : Role
    {
    }
}
