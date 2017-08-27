﻿using SmartEngineer.Core.Models;
using System.Collections.Generic;
using System.ServiceModel;

namespace SmartEngineer.Service
{
    [ServiceContract]
    public interface ISettingService
    {
        /// <summary>
        /// Get all configs
        /// </summary>
        [OperationContract]
        void GetAllConfigs();

        /// <summary>
        /// Get config option for spcified setting
        /// </summary>
        /// <param name="configName"></param>
        /// <returns>options</returns>
        [OperationContract]
        List<ConfigOption> GetConfigOptions(string configName);

        /// <summary>
        /// Update config options
        /// </summary>
        /// <param name="options">Options</param>
        [OperationContract(IsOneWay = true)]
        void UpdateConfigOptions(List<ConfigOption> options);
    }
}
