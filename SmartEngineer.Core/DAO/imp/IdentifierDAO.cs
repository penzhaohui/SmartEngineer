using System;
using SmartSql.Abstractions;
using SmartSql;

namespace SmartEngineer.Core.DAOs
{
    public class IdentifierDAO<T> : BaseDAO<T>
    {
        public override ISmartSqlMapper SQLMapper
        {
            get
            {
                return SQLMapperManager.Instance.GetSQLMapper(@"F:\MyWorkspace\SmartEngineer\SmartEngineer.Core\Config\SmartSqlMapConfig.xml");
            }
        }
    }
}
