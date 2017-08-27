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
        public virtual string TableName { get; }

        public int Delete<TPrimary>(TPrimary entity)
        {
            throw new NotImplementedException();
        }

        public TEntity GetEntityByID<TPrimary>(TPrimary ID, DataSourceChoice sourceChoice = DataSourceChoice.Read)
        {
            return SQLMapper.QuerySingle<TEntity>(new RequestContext
            {
                Scope = this.Scope,
                SqlId = DefaultSqlId.GetEntity,
                Request = new { ID = ID }
            }, sourceChoice);
        }

        public TEntity GetEntity(object paramObj, DataSourceChoice sourceChoice = DataSourceChoice.Read)
        {
            return SQLMapper.QuerySingle<TEntity>(new RequestContext
            {
                Scope = this.Scope,
                SqlId = DefaultSqlId.GetEntity,
                Request = paramObj
            }, sourceChoice);
        }

        public IEnumerable<TResponse> GetList<TResponse>(object paramObj, DataSourceChoice sourceChoice = DataSourceChoice.Read)
        {
            return SQLMapper.Query<TResponse>(new RequestContext
            {
                Scope = this.Scope,
                SqlId = DefaultSqlId.GetList,
                Request = paramObj
            }, sourceChoice);
        }

        public IEnumerable<TResponse> GetListByPage<TResponse>(object paramObj, DataSourceChoice sourceChoice = DataSourceChoice.Read)
        {
            return SQLMapper.Query<TResponse>(new RequestContext
            {
                Scope = this.Scope,
                SqlId = DefaultSqlId.GetListByPage,
                Request = paramObj
            }, sourceChoice);
        }

        public virtual TEntity Insert(TEntity entity)
        {
            SQLMapper.Execute(new RequestContext
            {
                Scope = this.Scope,
                SqlId = DefaultSqlId.Insert,
                Request = entity
            });

            return default(TEntity);
        }

        public bool IsExist(object paramObj, DataSourceChoice sourceChoice = DataSourceChoice.Read)
        {
            return SQLMapper.QuerySingle<int>(new RequestContext
            {
                Scope = this.Scope,
                SqlId = DefaultSqlId.IsExist,
                Request = paramObj
            }, sourceChoice) > 0;
        }

        public int Update(TEntity entity)
        {
            return SQLMapper.Execute(new RequestContext
            {
                Scope = this.Scope,
                SqlId = DefaultSqlId.Update,
                Request = entity
            });
        }

        public int NewID()
        {
            int maxID = SQLMapper.ExecuteScalar<int>(new RequestContext
            {
                Scope = "IDStore",
                SqlId = DefaultSqlId.GetRecord,
                Request = new { TableName = this.TableName }
            });

            SQLMapper.ExecuteAsync(new RequestContext
            {
                Scope = "IDStore",
                SqlId = DefaultSqlId.Update,
                Request = new { MaxID = maxID + 1, Increment = 1, TableName = this.TableName }
            });

            return maxID + 1;
        }
    }
}
