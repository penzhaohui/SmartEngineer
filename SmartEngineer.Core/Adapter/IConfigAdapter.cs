using SmartEngineer.Core.Models;
using System.Collections.Generic;

namespace SmartEngineer.Core.Adapter
{
    public interface IConfigAdapter
    {
        Dictionary<string, dynamic> GeSubTaskTemplates(string project);

        List<ConfigOption> GetAllConfigs();

        List<ConfigOption> GetConfigOptions(string configName);

        bool UpdateConfigOptions(string configName, List<ConfigOption> options);
    }
}
