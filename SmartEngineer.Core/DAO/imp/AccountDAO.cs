using SmartEngineer.Core.Models;
using SmartSql;
using SmartSql.Abstractions;

namespace SmartEngineer.Core.DAOs
{
    public class AccountDAO<T> : BaseDAO<T>, IAccountDAO<T>
        where T : Account
    {
        public override string TableName
        {
            get {
                return "sys_Account";
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
