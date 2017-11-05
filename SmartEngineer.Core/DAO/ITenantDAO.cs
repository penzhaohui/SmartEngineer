using SmartEngineer.Core.Models;

namespace SmartEngineer.Core.DAOs
{
    public interface ITenantDAO<T> : IBaseDAO<T>
        where T : Tenant
    {
    }
}
