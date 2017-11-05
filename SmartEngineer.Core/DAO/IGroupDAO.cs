using SmartEngineer.Core.Models;

namespace SmartEngineer.Core.DAOs
{
    public interface IGroupDAO<T> : IBaseDAO<T>
        where T : Group
    {
    }
}
