using SmartEngineer.Framework.Utils;
using SmartEngineer.ServiceClient.SettingService;
using System;
using System.Collections.Generic;

namespace SmartEngineer.UserControls
{
    public partial class SubTaskTemplate : UserControl
    {
        private static readonly string Extra_Data_Key_Project = "Project";
        private static readonly string Extra_Data_Key_IssueType = "IssueType";
        private static readonly string Extra_Data_Key_IsDefaultSubTask = "IsDefaultSubTask";
        private dynamic OriginalSetting;

        public SubTaskTemplate()
        {
            InitializeComponent();
        }

        public string IssueType { get; set; }
        public Func<UserControl, bool> SaveFunc { get; set; }
        public Func<bool> AddFunc { get; set; }
        public override string OptionName => "Jira Sub Task Template";

        public override List<ConfigOption> CollectOption()
        {
            string issueType = this.IssueType;
            string subTaskName = this.txtSubTaskName.Text.Trim();
            string subTaskTemplateContent = this.txtSubTaskTemplateContent.Text.Trim();
            string project = this.cmbProjects.SelectedItem as string;
            bool enable = this.chkEnableSubTask.Checked;
            bool isDefaultSubTask = this.chkDefaultSubTask.Checked;

            ConfigOption configOption = CreateConfigOption(subTaskName, subTaskTemplateContent);
            configOption.IsActive = enable;
            //Project=ENGSUPP;IssueType=Bug;IsDefaultSubTask=Yes
            configOption.ConfigExtra = $"Project={project};IssueType={issueType};IsDefaultSubTask={isDefaultSubTask}";

            List<ConfigOption> configOptions = new List<ConfigOption>();
            configOptions.Add(configOption);

            return configOptions;
        }

        public override void Initialize(List<ConfigOption> options)
        {
            if (options == null || options.Count == 0) return;

            foreach (ConfigOption option in options)
            {
                if (option == null) continue;

                string subTaskName = option.ConfigOptionValue;
                string subTaskTemplateContent = option.ConfigOptionDesc;
                bool enable = option.IsActive;

                // Project=ENGSUPP;IssueType=Bug;IsDefaultSubTask=Yes
                string extraData = option.ConfigExtra;
                string[] extraSettings = extraData.Split(';');

                string project = String.Empty;
                string issueType = String.Empty;
                string isDefaultSubTask = String.Empty;
                foreach (string extraSetting in extraSettings)
                {
                    string[] setting = extraSetting.Split('=');
                    if (Extra_Data_Key_Project.Equals(setting[0], StringComparison.OrdinalIgnoreCase))
                    {
                        project = setting[1];
                    }
                    else if (Extra_Data_Key_IssueType.Equals(setting[0], StringComparison.OrdinalIgnoreCase))
                    {
                        issueType = setting[1];
                    }
                    else if (Extra_Data_Key_IsDefaultSubTask.Equals(setting[0], StringComparison.OrdinalIgnoreCase))
                    {
                        isDefaultSubTask = setting[1];
                    }
                }

                this.cmbProjects.Items.Clear();
                this.cmbProjects.Items.Add("ENGSUPP");
                this.cmbProjects.Items.Add("DATABASE");

                this.txtSubTaskName.Text = subTaskName;
                this.txtSubTaskTemplateContent.Text = subTaskTemplateContent;
                this.chkEnableSubTask.Checked = enable;

                this.chkDefaultSubTask.Checked = CommonUtil.IsTrue(isDefaultSubTask);
                this.cmbProjects.SelectedIndex = this.cmbProjects.Items.IndexOf(project);
                if (IssueType != issueType)
                {
                    return;
                }

                break;
            }

            OriginalSetting = new
            {
                IssueType = this.IssueType,
                SubTaskName = this.txtSubTaskName.Text.Trim(),
                SubTaskTemplateContent = this.txtSubTaskTemplateContent.Text.Trim(),
                Project = this.cmbProjects.SelectedValue,
                Enable = this.chkEnableSubTask.Checked,
                IsDefaultSubTask = this.chkDefaultSubTask.Checked
            };
        }

        public override bool IsModified()
        {
            if (OriginalSetting == null) return true;

            string issueType = this.IssueType;
            string subTaskName = this.txtSubTaskName.Text.Trim();
            string subTaskTemplateContent = this.txtSubTaskTemplateContent.Text.Trim();
            string project = this.cmbProjects.SelectedValue as string;
            bool enable = this.chkEnableSubTask.Checked;
            bool isDefaultSubTask = this.chkDefaultSubTask.Checked;

            if (issueType != OriginalSetting.IssueType
                || subTaskName != OriginalSetting.SubTaskName
                || subTaskTemplateContent != OriginalSetting.SubTaskTemplateContent
                || project != OriginalSetting.Project
                || enable != OriginalSetting.Enable
                || isDefaultSubTask != OriginalSetting.IsDefaultSubTask)
            {
                return true;
            }

            return false;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {            
            if (AddFunc != null)
            {
                AddFunc();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (SaveFunc != null)
            {
                SaveFunc(this);
            }
        }
    }
}
