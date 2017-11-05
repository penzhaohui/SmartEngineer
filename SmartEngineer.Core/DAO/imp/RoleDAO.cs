using SmartEngineer.Core.Models;
using SmartSql;
using SmartSql.Abstractions;

namespace SmartEngineer.Core.DAOs
{
    public class RoleDAO<T> : BaseDAO<T>, IRoleDAO<T>
        where T : Role
    {
        public override string TableName
        {
            get
            {
                return "admin_Role";
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
