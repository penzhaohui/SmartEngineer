using log4net;
using SmartEngineer.Common;
using SmartEngineer.Framework.Logger;
using SmartEngineer.ServiceClient.SettingService;
using System;
using System.Collections.Generic;

namespace SmartEngineer.ServiceClient.Adapters
{
    public class ConfigAdapter : IConfigAdapter
    {
        /// <summary>
        /// Logger object.
        /// </summary>
        private static readonly ILog Logger = LogFactory.Instance.GetLogger(typeof(CaseAdapter));
        private static readonly SettingServiceClient SettingServiceClient = WSFactory.Instance.GetWCFClient<SettingServiceClient, ISettingService>();

        public List<ConfigOption> GetConfigOptions(string configName)
        {
            List<ConfigOption> options = new List<ConfigOption>();

            var result = SettingServiceClient.GetConfigOptions(configName);
            options.AddRange(result);

            return options;
        }

        public bool UpdateConfigOptions(string configName, List<ConfigOption> options)
        {
            if (options == null) return false;

            return SettingServiceClient.UpdateConfigOptions(configName, options.ToArray());
        }
    }
}
