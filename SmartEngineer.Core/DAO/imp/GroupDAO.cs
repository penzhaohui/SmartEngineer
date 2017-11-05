using SmartEngineer.Core.Models;
using SmartSql;
using SmartSql.Abstractions;

namespace SmartEngineer.Core.DAOs
{
    public class GroupDAO<T> : BaseDAO<T>, IGroupDAO<T>
        where T : Group
    {
        public override string TableName
        {
            get
            {
                return "admin_Group";
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
