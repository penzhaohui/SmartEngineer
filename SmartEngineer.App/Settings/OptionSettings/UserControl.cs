using SmartEngineer.ServiceClient.SettingService;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SmartEngineer.UserControls
{
    public class UserControl : System.Windows.Forms.UserControl
    {
        public virtual string OptionName { get; }

        public virtual void Initialize(List<ConfigOption> options)
        {
        }

        public virtual List<ConfigOption> CollectOption()
        {
            return null;
        }

        public virtual bool IsModified()
        {
            return false;
        }

        protected ConfigOption CreateConfigOption(string name, string value)
        {
            ConfigOption option = new ConfigOption();
            option.ConfigOptionValue = name;
            option.ConfigOptionDesc = value;
            option.IsActive = true;
            option.ConfigExtra = string.Empty;

            return option;
        }
    }
}
