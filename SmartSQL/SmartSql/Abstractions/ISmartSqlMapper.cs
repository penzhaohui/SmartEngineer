using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;
using SmartSql.SqlMap;
using System.Data.Common;
using System.Threading.Tasks;
using SmartSql.Abstractions.DbSession;
using SmartSql.Abstractions.DataSource;
using SmartSql.Abstractions.Cache;
using SmartSql.Abstractions.Config;

namespace SmartSql.Abstractions
{
    /// <summary>
    /// SmartSQL 映射器
    /// 注：整个程序的入口
    /// </summary>
    public interface ISmartSqlMapper : ISmartSqlMapperAsync, IDisposable
    {
        #region Properties

        SmartSqlMapConfig SqlMapConfig { get; }
        IDataSourceManager DataSourceManager { get; }
        ICacheManager CacheManager { get; }
        ISqlBuilder SqlBuilder { get; }
        DbProviderFactory DbProviderFactory { get; }
        IDbConnectionSessionStore DbSessionStore { get; }
        IConfigLoader ConfigLoader { get; }

        #endregion

        void LoadConfig(SmartSqlMapConfig smartSqlMapConfig);

        IDbConnectionSession CreateDbSession(DataSourceChoice commandMethod);        

        int Execute(RequestContext context);
        T ExecuteScalar<T>(RequestContext context);
        IEnumerable<T> Query<T>(RequestContext context);
        IEnumerable<T> Query<T>(RequestContext context, DataSourceChoice sourceChoice);
        T QuerySingle<T>(RequestContext context);
        T QuerySingle<T>(RequestContext context, DataSourceChoice sourceChoice);

        #region Transaction
        IDbConnectionSession BeginTransaction();
        IDbConnectionSession BeginTransaction(IsolationLevel isolationLevel);
        void CommitTransaction();
        void RollbackTransaction();
        #endregion

        #region Scoped Session
        IDbConnectionSession BeginSession(DataSourceChoice sourceChoice = DataSourceChoice.Write);
        void EndSession();
        #endregion
    }

    public enum DataSourceChoice
    {
        Write,
        Read
    }
}
