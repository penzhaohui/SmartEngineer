using SmartEngineer.Core.Models;

namespace SmartEngineer.Core.DAOs
{
    public class ConfigOptionDAO<T> : BaseDAO<T>, IConfigOptionDAO<T>
       where T : ConfigOption
    {
    }
}
