using SmartEngineer.ServiceClient.SettingService;
using System.Collections.Generic;

namespace SmartEngineer.UserControls
{
    public partial class TestRailModule : UserControl
    {
        public TestRailModule()
        {
            InitializeComponent();
        }

        public override List<ConfigOption> CollectOption()
        {
            return null;
        }

        public override void Initialize(List<ConfigOption> options)
        {
            return;
        }

        public override bool IsModified()
        {
            return true;
        }
    }
}
