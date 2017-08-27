using SmartEngineer.Core.DAOs;
using SmartEngineer.Core.Models;

namespace SmartEngineer.Core.DAO
{
    public interface IAccountSessionDAO<T> : IBaseDAO<T>
        where T: AccountSession
    {
    }
}
