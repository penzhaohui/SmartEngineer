using SmartEngineer.Core.Models;
using SmartSql;
using SmartSql.Abstractions;

namespace SmartEngineer.Core.DAOs
{
    public class JiraWorkLogDAO<T> : BaseDAO<T>, IJiraWorkLogDAO<T>
       where T : JiraWorkLog
    {
        public override string TableName
        {
            get
            {
                return "JiraWorkLog";
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
