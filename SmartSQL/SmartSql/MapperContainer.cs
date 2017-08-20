using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using SmartSql.Abstractions;
using SmartSql.Abstractions.Config;
//using Microsoft.Extensions.Logging;
//using SmartSql.Abstractions.Logging;

namespace SmartSql
{
    public class MapperContainer : IDisposable
    {
        /// <summary>
        /// Mapper容器
        /// </summary>
        private IDictionary<String, ISmartSqlMapper> _mapperContainer = new Dictionary<String, ISmartSqlMapper>();
        public static MapperContainer Instance = new MapperContainer();

        private MapperContainer() { }        
        

        public ISmartSqlMapper GetSqlMapper(String smartSqlMapConfigPath = "SmartSqlMapConfig.xml")
        {
            return GetSqlMapper(smartSqlMapConfigPath, new LocalFileConfigLoader());
        }

        public ISmartSqlMapper GetSqlMapper(String smartSqlMapConfigPath, IConfigLoader configLoader)
        {
            if (!_mapperContainer.ContainsKey(smartSqlMapConfigPath))
            {
                lock (this)
                {
                    if (!_mapperContainer.ContainsKey(smartSqlMapConfigPath))
                    {
                        ISmartSqlMapper _mapper = new SmartSqlMapper(smartSqlMapConfigPath, configLoader);
                        _mapperContainer.Add(smartSqlMapConfigPath, _mapper);
                    }
                }
            }
            return _mapperContainer[smartSqlMapConfigPath];
        }

        public void Dispose()
        {
            foreach (var mapper in _mapperContainer)
            {
                mapper.Value.Dispose();
            }
            _mapperContainer.Clear();
        }
    }
}
