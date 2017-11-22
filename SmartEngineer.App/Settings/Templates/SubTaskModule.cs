using SmartEngineer.Notification;
using SmartEngineer.ServiceClient.Adapters;
using SmartEngineer.ServiceClient.SettingService;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SmartEngineer.UserControls
{
    public partial class SubTaskModule : UserControl
    {
        public SubTaskModule()
        {
            InitializeComponent();
        }

        public override string OptionName => "";
        public string IssueType { get; set; }
        public override List<ConfigOption> CollectOption()
        {
            return null;
        }

        public override void Initialize(List<ConfigOption> options)
        {            
            this.tabControl1.TabPages.Clear();
            if (options == null || options.Count == 0)
            {
                TabPage tablePage = new TabPage();
                tablePage.Name = "TablePage0";
                tablePage.Text = "New Sub Task Template";
                this.tabControl1.TabPages.Add(tablePage);
                this.tabControl1.TabPages["TablePage0"].Controls.Add(CreateSubTaskTemplate(IssueType, null));
            }
            else
            {
                int index = 1;
                foreach (ConfigOption option in options)
                {
                    TabPage tablePage = new TabPage();
                    tablePage.Name = "TablePage" + index++;
                    tablePage.Text = option.ConfigOptionValue;
                    this.tabControl1.TabPages.Add(tablePage);
                    this.tabControl1.TabPages[tablePage.Name].Controls.Add(CreateSubTaskTemplate(IssueType, option));
                }
            }
        }

        private SubTaskTemplate CreateSubTaskTemplate(string issueType, ConfigOption option)
        {
            SubTaskTemplate subTaskTemplate = new SubTaskTemplate();
            subTaskTemplate.Location = new System.Drawing.Point(15, 15);
            subTaskTemplate.IssueType = issueType;
            subTaskTemplate.AddFunc = AddFunc;
            subTaskTemplate.SaveFunc = SaveFunc;

            List<ConfigOption> options = new List<ConfigOption>();
            options.Add(option);

            subTaskTemplate.Initialize(options);

            return subTaskTemplate;

        }

        public bool AddFunc()
        {
            if (this.tabControl1.TabPages["TablePage0"] == null)
            {
                TabPage tablePage = new TabPage();
                tablePage.Name = "TablePage0";
                tablePage.Text = "New Sub Task Template";
                this.tabControl1.TabPages.Add(tablePage);
                this.tabControl1.TabPages["TablePage0"].Controls.Add(CreateSubTaskTemplate(IssueType, null));
                return true;
            }

            return false;
        }

        public bool SaveFunc(UserControl userControl)
        {
            List<ConfigOption> options = userControl.CollectOption();
            IConfigAdapter ConfigAdapter = new ConfigAdapter();
            bool isUpdateSuccess = ConfigAdapter.UpdateConfigOptions(userControl.OptionName, options);
            if (isUpdateSuccess)
            {
                SystemMessageBox.ShowInformation("Save successfully.");
            }
            else
            {
                SystemMessageBox.ShowInformation("Failed to save, please contact administrator.");
            }
            return true;
        }

        public override bool IsModified()
        {
            return true;
        }
    }
}
