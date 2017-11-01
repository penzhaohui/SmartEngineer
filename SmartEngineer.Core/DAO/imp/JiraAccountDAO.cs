using SmartEngineer.Core.Models;
using SmartSql;
using SmartSql.Abstractions;

namespace SmartEngineer.Core.DAOs
{
    public class JiraAccountDAO<T> : BaseDAO<T>, IJiraAccountDAO<T>
       where T : JiraAccount
    {
        public override string TableName
        {
            get
            {
                return "JiraAccount";
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
