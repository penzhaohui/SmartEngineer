﻿using SmartEngineer.ServiceClient.Models;
using SmartEngineer.ServiceClient.SettingService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartEngineer.Common
{
    public static class ConfigOptionExtention
    {
        public static ConfigOption Get(this List<ConfigOption> options, string name)
        {
            var configOption = options.Where(option => option.ConfigOptionValue == name).FirstOrDefault<ConfigOption>();

            return configOption;
        }

        public static string GetOptionValue(this List<ConfigOption> options, string name)
        {
            string configOptionValue = string.Empty;

            ConfigOption configOption = options.Get(name);
            if (configOption != null
                && configOption.IsActive)
            {
                configOptionValue = configOption.ConfigOptionDesc;
            }

            return configOptionValue;
        }

        public static bool Update(this List<ConfigOption> options, string name, string vaulue)
        {
            ConfigOption configOption = new ConfigOption();
            configOption.ConfigOptionValue = name;
            configOption.ConfigOptionDesc = vaulue;
            configOption.IsActive = true;
            configOption.ConfigExtra = "";

            var configOptionList = options.Where(option => option.ConfigOptionValue == configOption.ConfigOptionValue);
            foreach (ConfigOption item in configOptionList)
            {
                configOption.ConfigID = item.ID;
                options.Remove(item);                
            }

            options.Add(configOption);

            return true;
        }
    }
}
