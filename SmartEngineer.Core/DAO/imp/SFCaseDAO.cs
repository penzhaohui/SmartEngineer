using SmartEngineer.Core.Models;
using SmartSql;
using SmartSql.Abstractions;
using System.Collections.Generic;

namespace SmartEngineer.Core.DAOs
{
    public class SFCaseDAO<T> : BaseDAO<T>, ISFCaseDAO<T>
        where T : CaseInfo
    {
        public override ISmartSqlMapper SQLMapper
        {
            get {
                return SQLMapperManager.Instance.GetSQLMapper(@"F:\MyWorkspace\SmartEngineer\SmartEngineer.Core\Config\SmartSqlMapConfig.xml");
            }
        }

        public override string TableName
        {
            get {
                return "SFCase";
            }
        }

        public List<CaseInfo> GetEntitys(List<string> caseNos)
        {
            List<CaseInfo> cases = new List<CaseInfo>();

            if (caseNos == null || caseNos.Count == 0) return cases;

            var entities = SQLMapper.Query<CaseInfo>(new RequestContext
            {
                Scope = this.Scope,
                SqlId = "GetEntities",
                Request = new { CaseNumber = caseNos }
            });

            foreach(CaseInfo entity in entities)
            {
                cases.Add(entity);
            }

            return cases;
        }

        public override T Insert(T entity)
        {
            entity.ID = this.NewID();
            base.Insert(entity);

            return entity;
        }
    }
}
