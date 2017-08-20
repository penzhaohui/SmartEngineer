using SmartSql.Abstractions;
using System;
using System.Collections.Generic;

namespace SmartSql
{
    public sealed class SQLMapperManager : IDisposable
    {
        private static readonly SQLMapperManager SingleInstancen = new SQLMapperManager();
        private IDictionary<String, ISmartSqlMapper> _sqlmappers = new Dictionary<String, ISmartSqlMapper>();
        private string _defaultSqlMapConfigPath = "SmartSqlMapConfig.xml";

        private SQLMapperManager(){ }

        public static SQLMapperManager Instance
        {
            get
            {
                return SingleInstancen;
            }
        }

        public ISmartSqlMapper DefaultSQLMapper
        {
            get
            {
                if (String.IsNullOrEmpty(_defaultSqlMapConfigPath))
                {
                    throw new Exception("No SQL Mapper is initialized yet.");
                }

                return _sqlmappers[_defaultSqlMapConfigPath];
            }
        }

        public ISmartSqlMapper GetSQLMapper(string sqlMapConfigPath = "SmartSqlMapConfig.xml", bool isDefaultMapper = false)
        {
            ISmartSqlMapper instance = null;

            lock (this)
            {
                if (_sqlmappers.ContainsKey(sqlMapConfigPath))
                {
                    instance = _sqlmappers[sqlMapConfigPath];
                }
                else
                {
                    ISmartSqlMapper _mapper = new SmartSqlMapper(sqlMapConfigPath);
                    _sqlmappers.Add(sqlMapConfigPath, _mapper);

                    if (isDefaultMapper)
                    {
                        _defaultSqlMapConfigPath = sqlMapConfigPath;
                    }
                }

                instance = _sqlmappers[sqlMapConfigPath];
            }
            
            return instance;
        }

        public void Dispose()
        {
            foreach (var mapper in _sqlmappers)
            {
                mapper.Value.Dispose();
            }

            _sqlmappers.Clear();
        }
    }
}  
