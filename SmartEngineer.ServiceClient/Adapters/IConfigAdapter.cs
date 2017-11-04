using SmartEngineer.ServiceClient.SettingService;
using System.Collections.Generic;

namespace SmartEngineer.ServiceClient.Adapters
{
    public interface IConfigAdapter
    {
        List<ConfigOption> GetConfigOptions(string configName);

        bool UpdateConfigOptions(string configName, List<ConfigOption> options);
    }
}
