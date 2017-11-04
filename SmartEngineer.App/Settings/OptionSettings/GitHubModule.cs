using System.Collections.Generic;
using SmartEngineer.ServiceClient.SettingService;

namespace SmartEngineer.UserControls
{
    public partial class GitHubModule : UserControl
    {
        public GitHubModule()
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
