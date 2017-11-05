using SmartEngineer.Core.Models;
using SmartSql;
using SmartSql.Abstractions;

namespace SmartEngineer.Core.DAOs
{
    public class TenantDAO<T> : BaseDAO<T>, ITenantDAO<T>
        where T : Tenant
    {
        public override string TableName
        {
            get
            {
                return "sys_Tenant";
            }
        }

        public override T Insert(T entity)
        {
            entity.ID = this.NewID();
            base.Insert(entity);

            return entity;
        }
    }
}
