﻿using SmartSql.Abstractions;
using SmartSql.Abstractions.Config;
using SmartSql.Common;
using SmartSql.SqlMap;
using System;
using System.IO;

namespace SmartSql
{
    /// <summary>
    /// 本地文件配置加载器
    /// </summary>
    public class LocalFileConfigLoader : ConfigLoader
    {
        public LocalFileConfigLoader()
        {            
        }

        public override SmartSqlMapConfig Load(String path, ISmartSqlMapper smartSqlMapper)
        {           
            var configStream = LoadConfigStream(path);
            var config = LoadConfig(configStream, smartSqlMapper);

            foreach (var sqlmapSource in config.SmartSqlMapSources)
            {
                switch (sqlmapSource.Type)
                {
                    case SmartSqlMapSource.ResourceType.File:
                        {
                            LoadSmartSqlMap(config, sqlmapSource.Path);
                            break;
                        }
                    case SmartSqlMapSource.ResourceType.Directory:
                        {
                            var childSqlmapSources = Directory.EnumerateFiles(sqlmapSource.Path, "*.xml");
                            foreach (var childSqlmapSource in childSqlmapSources)
                            {
                                LoadSmartSqlMap(config, childSqlmapSource);
                            }
                            break;
                        }
                    default:
                        {
                            break;
                        }
                }
            }
            //_logger.LogDebug($"SmartSql.LocalFileConfigLoader Load: {path} End");

            smartSqlMapper.LoadConfig(config);

            if (config.Settings.IsWatchConfigFile)
            {
                //_logger.LogDebug($"SmartSql.LocalFileConfigLoader Load Add WatchConfig: {path} Starting.");
                WatchConfig(smartSqlMapper);
                //_logger.LogDebug($"SmartSql.LocalFileConfigLoader Load Add WatchConfig: {path} End.");
            }
            return config;
        }

        private void LoadSmartSqlMap(SmartSqlMapConfig config, String sqlmapSourcePath)
        {
            //_logger.LogDebug($"SmartSql.LoadSmartSqlMap Load: {sqlmapSourcePath}");
            var sqlmapStream = LoadConfigStream(sqlmapSourcePath);
            var sqlmap = LoadSmartSqlMap(sqlmapStream, config);
            config.SmartSqlMaps.Add(sqlmap);
        }

        public ConfigStream LoadConfigStream(string path)
        {
            var configStream = new ConfigStream
            {
                Path = path,
                Stream = FileLoader.Load(path)
            };
            return configStream;
        }

        /// <summary>
        /// 监控配置文件-热更新
        /// </summary>
        /// <param name="smartSqlMapper"></param>
        /// <param name="config"></param>
        private void WatchConfig(ISmartSqlMapper smartSqlMapper)
        {
            var config = smartSqlMapper.SqlMapConfig;

            #region SmartSqlMapConfig File Watch

            //_logger.LogDebug($"SmartSql.LocalFileConfigLoader Watch SmartSqlMapConfig: {config.Path} .");
            var cofigFileInfo = FileLoader.GetInfo(config.Path);
            FileWatcherLoader.Instance.Watch(cofigFileInfo, () =>
            {
                //_logger.LogDebug($"SmartSql.LocalFileConfigLoader Changed ReloadConfig: {config.Path} Starting");
                var newConfig = Load(config.Path, smartSqlMapper);
                //_logger.LogDebug($"SmartSql.LocalFileConfigLoader Changed ReloadConfig: {config.Path} End");
            });

            #endregion

            #region SmartSqlMaps File Watch

            foreach (var sqlmap in config.SmartSqlMaps)
            {
                #region SqlMap File Watch

                //_logger.LogDebug($"SmartSql.LocalFileConfigLoader Watch SmartSqlMap: {sqlmap.Path} .");
                var sqlMapFileInfo = FileLoader.GetInfo(sqlmap.Path);
                FileWatcherLoader.Instance.Watch(sqlMapFileInfo, () =>
                {
                    //_logger.LogDebug($"SmartSql.LocalFileConfigLoader Changed Reload SmartSqlMap: {sqlmap.Path} Starting");
                    var sqlmapStream = LoadConfigStream(sqlmap.Path);
                    var newSqlmap = LoadSmartSqlMap(sqlmapStream, config);
                    sqlmap.Scope = newSqlmap.Scope;
                    sqlmap.Statements = newSqlmap.Statements;
                    sqlmap.Caches = newSqlmap.Caches;
                    config.ResetMappedStatements();
                    smartSqlMapper.CacheManager.ResetMappedCaches();
                    //_logger.LogDebug($"SmartSql.LocalFileConfigLoader Changed Reload SmartSqlMap: {sqlmap.Path} End");
                });

                #endregion
            }

            #endregion
        }

        public override void Dispose()
        {
            FileWatcherLoader.Instance.Clear();
        }
    }
}
