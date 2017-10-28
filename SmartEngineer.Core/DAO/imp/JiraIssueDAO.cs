using System;
using System.Collections.Generic;
using SmartEngineer.Core.Models;
using SmartSql;
using SmartSql.Abstractions;

namespace SmartEngineer.Core.DAOs
{
    public class JiraIssueDAO<T> : BaseDAO<T>, IJiraIssueDAO<T>
       where T : JiraIssue
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
                return "JiraIssue";
            }
        }

        public List<JiraIssue> GetEntitiesByCaseNo(List<string> caseNos)
        {
            List<JiraIssue> jiraIssues = new List<JiraIssue>();

            if (caseNos == null || caseNos.Count == 0) return jiraIssues;

            var entities = SQLMapper.Query<JiraIssue>(new RequestContext
            {
                Scope = this.Scope,
                SqlId = "GetEntities",
                Request = new { CaseNumber = caseNos }
            });

            foreach (JiraIssue entity in entities)
            {
                jiraIssues.Add(entity);
            }

            return jiraIssues;
        }

        public List<JiraIssue> GetEntitiesByJiraKey(List<string> jiraKeys)
        {
            List<JiraIssue> jiraIssues = new List<JiraIssue>();

            if (jiraKeys == null || jiraKeys.Count == 0) return jiraIssues;

            var entities = SQLMapper.Query<JiraIssue>(new RequestContext
            {
                Scope = this.Scope,
                SqlId = "GetEntities",
                Request = new { JiraKey = jiraKeys }
            });

            foreach (JiraIssue entity in entities)
            {
                jiraIssues.Add(entity);
            }

            return jiraIssues;
        }

        public override T Insert(T entity)
        {
            entity.ID = this.NewID();
            base.Insert(entity);

            return entity;
        }
    }
}
