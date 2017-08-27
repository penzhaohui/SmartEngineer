using SmartSql.Abstractions;
using SmartSQL;
using System;
using System.Collections.Generic;

namespace SmartEngineer.Core.DAOs
{
    public abstract class BaseDAO<TEntity> : IBaseDAO<TEntity>
    {
        public abstract ISmartSqlMapper SQLMapper { get; }

        public string Scope => typeof(TEntity).Name;

        public int Delete<TPrimary>(TPrimary entity)
        {
            throw new NotImplementedException();
        }

        public TEntity GetEntity<TPrimary>(TPrimary ID, DataSourceChoice sourceChoice = DataSourceChoice.Read)
        {
            return SQLMapper.QuerySingle<TEntity>(new RequestContext
            {
                Scope = this.Scope,
                SqlId = DefaultSqlId.GetEntity,
                Request = new { ID = ID }
            }, sourceChoice);
        }

        public IEnumerable<TResponse> GetList<TResponse>(object paramObj, DataSourceChoice sourceChoice = DataSourceChoice.Read)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TResponse> GetListByPage<TResponse>(object paramObj, DataSourceChoice sourceChoice = DataSourceChoice.Read)
        {
            throw new NotImplementedException();
        }

        public TEntity Insert(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public bool IsExist(object paramObj, DataSourceChoice sourceChoice = DataSourceChoice.Read)
        {
            throw new NotImplementedException();
        }

        public int Update(TEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
