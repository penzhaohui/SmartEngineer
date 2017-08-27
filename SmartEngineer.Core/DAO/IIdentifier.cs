using SmartEngineer.Core.DAOs;
using SmartEngineer.Core.Models;

namespace SmartEngineer.Core.DAO
{
    interface IIDStore<T> : IBaseDAO<T>
        where T : Identifier
    {
    }
}
