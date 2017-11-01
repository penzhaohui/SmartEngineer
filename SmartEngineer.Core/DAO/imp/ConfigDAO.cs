using SmartEngineer.Core.Models;

namespace SmartEngineer.Core.DAOs
{
    public class ConfigDAO<T> : BaseDAO<T>, IConfigDAO<T>
        where T : Config
    {
    }
}
