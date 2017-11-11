using SmartEngineer.Core.Adapter;
using SmartEngineer.Core.Models;
using System.Collections.Generic;

namespace SmartEngineer.Service
{
    public class SettingService : ISettingService
    {
        public IConfigAdapter ConfigAdapter { get; set; }

        public SettingService(IConfigAdapter configAdapter)
        {
            ConfigAdapter = configAdapter;
        }

        public List<ConfigOption> GetAllConfigs()
        {
            return ConfigAdapter.GetAllConfigs();
        }

        public List<ConfigOption> GetConfigOptions(string configName)
        {
            return ConfigAdapter.GetConfigOptions(configName);
        }

        public bool UpdateConfigOptions(string configName, List<ConfigOption> options)
        {
            return ConfigAdapter.UpdateConfigOptions(configName, options);
        }
    }
}
