using SmartSql.Abstractions;
using System.Collections.Generic;

namespace SmartEngineer.Core.DAOs
{
    public interface IBaseDAO<TEntity>
    {
        ISmartSqlMapper SQLMapper { get; }

        string Scope { get; }

        bool IsExist(object paramObj, DataSourceChoice sourceChoice = DataSourceChoice.Read);

        TEntity GetEntity<TPrimary>(TPrimary ID, DataSourceChoice sourceChoice = DataSourceChoice.Read);

        IEnumerable<TResponse> GetList<TResponse>(object paramObj, DataSourceChoice sourceChoice = DataSourceChoice.Read);

        IEnumerable<TResponse> GetListByPage<TResponse>(object paramObj, DataSourceChoice sourceChoice = DataSourceChoice.Read);

        TEntity Insert(TEntity entity);

        int Delete<TPrimary>(TPrimary entity);

        int Update(TEntity entity);
    }
}
