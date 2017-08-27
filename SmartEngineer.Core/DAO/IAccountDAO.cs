using SmartEngineer.Core.Models;

namespace SmartEngineer.Core.DAOs
{
    public interface IAccountDAO<T> : IBaseDAO<T>
        where T : Account
    {
    }
}
