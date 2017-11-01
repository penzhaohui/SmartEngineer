using SmartEngineer.Core.Models;
using SmartSql;
using SmartSql.Abstractions;
using System.Collections.Generic;

namespace SmartEngineer.Core.DAOs
{
    public class JiraSubTaskDAO<T> : BaseDAO<T>, IJiraSubTaskDAO<T>
       where T : JiraSubTask
    {
        public override string TableName
        {
            get
            {
                return "JiraSubTask";
            }
        }

        public List<JiraSubTask> GetEntitiesByParentJiraKey(string parentJiraKey)
        {
            List<JiraSubTask> subTasks = new List<JiraSubTask>();

            if (parentJiraKey == null || parentJiraKey.Trim().Length == 0) return subTasks;

            var entities = SQLMapper.Query<JiraSubTask>(new RequestContext
            {
                Scope = this.Scope,
                SqlId = "GetEntities",
                Request = new { ParentJiraKey = parentJiraKey }
            });

            foreach (JiraSubTask entity in entities)
            {
                subTasks.Add(entity);
            }

            return subTasks;
        }

        public override T Insert(T entity)
        {
            entity.ID = this.NewID();
            base.Insert(entity);

            return entity;
        }
    }
}
