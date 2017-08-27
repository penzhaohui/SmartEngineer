using SmartEngineer.Core.DAO;
using SmartEngineer.Core.Models;
using SmartSql;
using SmartSql.Abstractions;

namespace SmartEngineer.Core.DAOs
{
    public class AccountSessionDAO<T> : BaseDAO<T>, IAccountSessionDAO<T>
        where T : AccountSession
    {
        public override ISmartSqlMapper SQLMapper
        {
            get
            {
                return SQLMapperManager.Instance.GetSQLMapper(@"D:\SmartEngineer\SmartEngineer.Core\Config\SmartSqlMapConfig.xml");
            }
        }
    }
}
