using SmartEngineer.Core.Models;

namespace SmartEngineer.Core.DAOs
{
    public interface IConfigOptionDAO<T> : IBaseDAO<T>
            where T : ConfigOption
    {
    }
}
