using SmartEngineer.OutlookBar;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace SmartEngineer.Forms
{
    public partial class frmTemplateSettings : Form
    {
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
            iconPanel2.AddIcon("Daily Case Review Report", Image.FromFile(System.AppDomain.CurrentDomain.BaseDirectory + @"\Image\3.ico"), new EventHandler(PanelEventB));
            //3
            iconPanel2.AddIcon("Daily Work Log Report", Image.FromFile(System.AppDomain.CurrentDomain.BaseDirectory + @"\Image\4.ico"), new EventHandler(PanelEventB));
            //4
            iconPanel2.AddIcon("Weekly Case Review Report", Image.FromFile(System.AppDomain.CurrentDomain.BaseDirectory + @"\Image\4.ico"), new EventHandler(PanelEventB));
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
        }

        public void PanelEventB(object sender, EventArgs e)
        {
            Control ctrl = (Control)sender;
            PanelIcon panelIcon = ctrl.Tag as PanelIcon;
            string clickInfo = string.Empty;

            switch (panelIcon.Index)
            {
                case 0:
                    clickInfo = "Daily Case Review Report";
                    break;
                case 1:
                    clickInfo = "Daily Work Log Report";
                    break;
                case 2:
                    clickInfo = "Weekly Case Review Report";
                    break;
            }
            this.label1.Text = string.Format("您选择了 {0}", clickInfo);
        }
    }
}
