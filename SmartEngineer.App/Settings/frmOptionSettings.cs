using SmartEngineer.Notification;
using SmartEngineer.ServiceClient.Adapters;
using SmartEngineer.ServiceClient.SettingService;
using SmartEngineer.UserControls;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SmartEngineer.Forms
{
    public partial class frmOptionSettings : Form
    {
        private static readonly IConfigAdapter ConfigAdapter = new ConfigAdapter();
        UserControls.UserControl UserControl = null;

        public frmOptionSettings()
        {
            InitializeComponent();
        }

        private void optionTree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            this.splitContainer.Panel2.Controls.Clear();
            UserControl = new AuditLogModule();

            string nodeTag = optionTree.SelectedNode.Tag as string;
            switch (nodeTag)
            {
                case "System":
                case "Performance":
                    UserControl = new PerformanceModule();                    
                    break;
                case "Memcache":
                    UserControl = new MemcacheModule();
                    break;
                case "AuditLog":
                    UserControl = new AuditLogModule();
                    break;
                case "Synchronous":
                case "Salesforce":
                    UserControl = new SaleforceAccountModule();
                    break;
                case "Jira":
                    UserControl = new JiraModule();
                    break;
                case "GitHub":
                    UserControl = new GitHubModule();
                    break;
                case "TestRail":
                    UserControl = new TestRailModule();
                    break;
            }

            Button btnSave = new Button();
            btnSave.Text = "Save";
            btnSave.Name = "btnSave";
            btnSave.Location = new System.Drawing.Point(5, UserControl.Height);
            btnSave.Click += Save;

            Button btnCancel = new Button();
            btnCancel.Text = "Cancel";
            btnCancel.Name = "btnCancel";
            btnCancel.Location = new System.Drawing.Point(10 + btnSave.Width, UserControl.Height);
            btnCancel.Click += Cancel;

            this.splitContainer.Panel2.Controls.Add(UserControl);
            this.splitContainer.Panel2.Controls.Add(btnSave);
            this.splitContainer.Panel2.Controls.Add(btnCancel);

            List<ConfigOption> options = null;
            if (!string.IsNullOrEmpty(UserControl.OptionName))
            {
                options = ConfigAdapter.GetConfigOptions(UserControl.OptionName);
            }
            UserControl.Initialize(options);
        }

        private void Save(object sender, EventArgs e)
        {
            if (UserControl.IsModified())
            {
                List<ConfigOption> options = UserControl.CollectOption();
                if (ConfigAdapter.UpdateConfigOptions(UserControl.OptionName, options))
                {
                    SystemMessageBox.ShowInformation("Save successfully.");
                }
                else
                {
                    SystemMessageBox.ShowInformation("Failed to save, please contact administrator.");
                }

            }
        }

        private void Cancel(object sender, EventArgs e)
        {
            System.Console.WriteLine();
        }
    }
}
