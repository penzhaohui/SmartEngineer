using SmartSql.Abstractions;
using SmartSql.Abstractions.DataSource;
using SmartSql.Common;
using System.Linq;

namespace SmartSql
{
    /// <summary>
    /// 数据源管理器
    /// </summary>
    public class DataSourceManager : IDataSourceManager
    {
        public ISmartSqlMapper SmartSqlMapper { get; }
        /// <summary>
        /// 权重筛选器
        /// </summary>
        private WeightFilter<IReadDataSource> weightFilter = new WeightFilter<IReadDataSource>();

        public DataSourceManager(ISmartSqlMapper sqlMaper)
        {            
            SmartSqlMapper = sqlMaper;
        }

        public IDataSource GetDataSource(DataSourceChoice sourceChoice)
        {
            IDataSource choiceDataSource = SmartSqlMapper.SqlMapConfig.Database.WriteDataSource;

            var readDataSources = SmartSqlMapper.SqlMapConfig.Database.ReadDataSources;
            if (sourceChoice == DataSourceChoice.Read
                && readDataSources.Count > 0)
            {
                var seekList = readDataSources.Select(readDataSource => new WeightFilter<IReadDataSource>.WeightSource
                {
                    Source = readDataSource,
                    Weight = readDataSource.Weight
                });

                choiceDataSource = weightFilter.Elect(seekList).Source;
            }

            return choiceDataSource;
        }
    }
}
