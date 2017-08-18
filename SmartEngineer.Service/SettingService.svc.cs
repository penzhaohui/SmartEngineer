using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using SmartEngineer.Service.Model;

namespace SmartEngineer.Service
{
    public class SettingService : ISettingService
    {
        public void GetAllConfigs()
        {
            throw new NotImplementedException();
        }

        public List<ConfigOption> GetConfigOptions(string configName)
        {
            throw new NotImplementedException();
        }

        public void UpdateConfigOptions(List<ConfigOption> options)
        {
            throw new NotImplementedException();
        }
    }
}
