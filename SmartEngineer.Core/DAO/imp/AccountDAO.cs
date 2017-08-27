using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartSql.Abstractions;
using SmartSql;

namespace SmartEngineer.Core.DAOs
{
    public class AccountDAO<T> : BaseDAO<T>
    {
        public override ISmartSqlMapper SQLMapper
        {
            get {
                return SQLMapperManager.Instance.GetSQLMapper(@"D:\SmartEngineer\SmartEngineer.Core\Config\SmartSqlMapConfig.xml");
            }
        }
    }
}
