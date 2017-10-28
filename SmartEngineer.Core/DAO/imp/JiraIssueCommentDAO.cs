using SmartEngineer.Core.Models;
using SmartSql;
using SmartSql.Abstractions;

namespace SmartEngineer.Core.DAOs
{
    public class JiraIssueCommentDAO<T> : BaseDAO<T>, IJiraIssueCommentDAO<T>
       where T : JiraIssueComment
    {
        public override ISmartSqlMapper SQLMapper
        {
            get
            {
                return SQLMapperManager.Instance.GetSQLMapper(@"F:\MyWorkspace\SmartEngineer\SmartEngineer.Core\Config\SmartSqlMapConfig.xml");
            }
        }

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