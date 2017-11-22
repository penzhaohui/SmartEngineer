using SmartEngineer.Notification;
using SmartEngineer.OutlookBar;
using SmartEngineer.ServiceClient.Adapters;
using SmartEngineer.ServiceClient.SettingService;
using SmartEngineer.UserControls;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace SmartEngineer.Forms
{
    public partial class frmTemplateSettings : Form
    {
        private static readonly IConfigAdapter ConfigAdapter = new ConfigAdapter();

        public frmTemplateSettings()
        {
            InitializeComponent();

            #region 初始化 OutLookBar
            outlookBar.BorderStyle = BorderStyle.FixedSingle;
            outlookBar.Initialize();
            IconPanel iconPanel1 = new IconPanel();
            IconPanel iconPanel2 = new IconPanel();
            IconPanel iconPanel3 = new IconPanel();

            outlookBar.AddBand("Sub Task Template", iconPanel1);
            outlookBar.AddBand("Report Email Template", iconPanel2);

            // 总结C#获取当前路径的7种方法
            // http://www.cnblogs.com/Impulse/p/4494077.html
            //0
            iconPanel1.AddIcon("Case", Image.FromFile(System.AppDomain.CurrentDomain.BaseDirectory  + @"\Image\1.ico"), new EventHandler(PanelEventA));
            //1
            iconPanel1.AddIcon("Bug", Image.FromFile(System.AppDomain.CurrentDomain.BaseDirectory + @"\Image\2.ico"), new EventHandler(PanelEventA));
            //2
            iconPanel2.AddIcon("Daily Case", Image.FromFile(System.AppDomain.CurrentDomain.BaseDirectory + @"\Image\3.ico"), new EventHandler(PanelEventB));
            //3
            iconPanel2.AddIcon("Daily Worklog", Image.FromFile(System.AppDomain.CurrentDomain.BaseDirectory + @"\Image\4.ico"), new EventHandler(PanelEventB));
            //4
            iconPanel2.AddIcon("Weekly Case", Image.FromFile(System.AppDomain.CurrentDomain.BaseDirectory + @"\Image\4.ico"), new EventHandler(PanelEventB));
            outlookBar.SelectBand(0);
            #endregion
        }

        public void PanelEventA(object sender, EventArgs e)
        {
            Control ctrl = (Control)sender;
            PanelIcon panelIcon = ctrl.Tag as PanelIcon;
            string clickInfo = string.Empty;
            switch (panelIcon.Index)
            {
                case 0:
                    clickInfo = "Case";
                    break;
                case 1:
                    clickInfo = "Bug";
                    break;
            }
            this.label1.Text = string.Format("您选择了 {0}", clickInfo);
            // Project = ENGSUPP; IssueType = Case; IsDefaultSubTask = Yes
            List<ConfigOption> options = ConfigAdapter.GetConfigOptions("Jira Sub Task Template");
            // Linq中where查询 - http://www.studyofnet.com/news/269.html
            var queryResult = from ConfigOption option in options
                      where option.ConfigExtra.Contains(clickInfo)
                      select option;

            this.templatePanel.Controls.Clear();
            SubTaskModule subTaskModule = new SubTaskModule();
            subTaskModule.IssueType = clickInfo;
            subTaskModule.Initialize(queryResult.ToList<ConfigOption>());
            this.templatePanel.Controls.Add(subTaskModule);
        }

        public void PanelEventB(object sender, EventArgs e)
        {
            Control ctrl = (Control)sender;
            PanelIcon panelIcon = ctrl.Tag as PanelIcon;
            string clickInfo = string.Empty;
            
            switch (panelIcon.Index)
            {
                case 0:
                    clickInfo = "Daily Case";
                    
                    break;
                case 1:
                    clickInfo = "Daily Worklog";
                    break;
                case 2:
                    clickInfo = "Weekly Case";
                    break;
            }
            this.label1.Text = string.Format("您选择了 {0}", clickInfo);

            string optionName = $"{clickInfo} Report Email Setting";
            List<ConfigOption> options = ConfigAdapter.GetConfigOptions(optionName);

            this.templatePanel.Controls.Clear();
            ReportEmailModule reportEmailModule = new ReportEmailModule();
            reportEmailModule.ReportName = clickInfo;
            reportEmailModule.SaveFunc = SaveFunc;
            reportEmailModule.Initialize(options);
            this.templatePanel.Controls.Add(reportEmailModule);
        }

        public bool SaveFunc(string optionName, UserControls.UserControl userControl)
        {
            List<ConfigOption> options = userControl.CollectOption();
            bool isUpdateSuccess = ConfigAdapter.UpdateConfigOptions(optionName, options);
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
    }
}
