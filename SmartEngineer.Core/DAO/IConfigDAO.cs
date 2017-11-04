using SmartEngineer.Core.DAOs;
using SmartEngineer.Core.Models;

namespace SmartEngineer.Core.DAOs
{
    public interface IConfigDAO<T> : IBaseDAO<T>
        where T : Config
    {
    }
}
