using SmartEngineer.Core.Models;
using SmartSql;
using SmartSql.Abstractions;

namespace SmartEngineer.Core.DAOs
{
    public class JiraIssueCommentDAO<T> : BaseDAO<T>, IJiraIssueCommentDAO<T>
       where T : JiraIssueComment
    {
        public override string TableName
        {
            get
            {
                return "JiraIssueComment";
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