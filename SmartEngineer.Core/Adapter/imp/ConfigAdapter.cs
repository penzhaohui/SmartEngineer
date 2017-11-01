using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartEngineer.Core.Models;
using SmartEngineer.Core.DAOs;

namespace SmartEngineer.Core.Adapter
{
    public class ConfigAdapter : IConfigAdapter
    {
        private static readonly IConfigDAO<Config> ConfigDAO = new ConfigDAO<Config>();
        private static readonly IConfigOptionDAO<ConfigOption> ConfigOptionDAO = new ConfigOptionDAO<ConfigOption>();

        Dictionary<string, Dictionary<string, dynamic>> SubTaskTemplate = new Dictionary<string, Dictionary<string, dynamic>>();

        public Dictionary<string, dynamic> GeSubTaskTemplates(string project)
        {
            Dictionary<string, dynamic> options = new Dictionary<string, dynamic>();

            if (SubTaskTemplate.Keys.Count == 0)
            {
                var config = ConfigDAO.GetEntity(new { Name = "Jira Sub Task Template" });
                var configOptions = ConfigOptionDAO.GetList<ConfigOption>(new { ConfigID = config.ID });
                if (configOptions != null)
                {
                    string optionProject = String.Empty;
                    foreach (ConfigOption configOption in configOptions)
                    {
                        if (String.IsNullOrEmpty(configOption.ConfigExtra)) continue;

                        dynamic dynamicConfigOption = configOption;

                        /*
                        System.Reflection.PropertyInfo[] properties = configOption.GetType().GetProperties(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public);
                        if (properties.Length > 0)
                        {
                            foreach (System.Reflection.PropertyInfo item in properties)
                            {
                                string name = item.Name;
                                object value = item.GetValue(configOption, null);

                                if (item.PropertyType.IsValueType || item.PropertyType.Name.StartsWith("String", StringComparison.InvariantCultureIgnoreCase))
                                {
                                    ((IDictionary<string, object>)dynamicConfigOption).Add(name, value);
                                }
                            }
                        }
                        */

                        string[] extraConfigs = configOption.ConfigExtra.Split(';');
                        foreach (string extraConfig in extraConfigs)
                        {
                            string[] settings = extraConfig.Split('=');
                            string key = settings[0].Trim();
                            string value = settings[1].Trim();

                            bool outBoolValue = true;
                            int outIntValue = 0;
                            if (bool.TryParse(value, out outBoolValue))
                            {
                                ((IDictionary<string, object>)dynamicConfigOption).Add(key, outBoolValue);
                            }
                            else if (int.TryParse(value, out outIntValue))
                            {
                                ((IDictionary<string, object>)dynamicConfigOption).Add(key, outIntValue);
                            }
                            else
                            {
                                ((IDictionary<string, object>)dynamicConfigOption).Add(key, value);
                            }

                            if ("Project".Equals(key, StringComparison.InvariantCultureIgnoreCase))
                            {
                                optionProject = value;
                            }
                        }

                        if (SubTaskTemplate.ContainsKey(optionProject))
                        {
                            SubTaskTemplate.Add(optionProject, new Dictionary<string, dynamic>());
                        }

                        Dictionary<string, dynamic> tempOptions = SubTaskTemplate[optionProject];
                        if (!tempOptions.ContainsKey(configOption.ConfigOptionValue))
                        {
                            tempOptions.Add(configOption.ConfigOptionValue, dynamicConfigOption);
                        }
                    }
                }
            }

            return options;
        }
    }
}
