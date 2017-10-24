using Microsoft.VisualBasic;
using SmartEngineer.Notification;
using System;
using System.Windows.Forms;

namespace SmartEngineer.Forms
{
    public partial class frmMain : Form, IBasicForm
    {
        private static frmMain _CurrentMainForm = null;
        private static frmMain _OldMainForm = null;

        /// <summary>
        /// 主窗体实例全局变量
        /// </summary>
        public static frmMain CurrentMainForm { get { return _CurrentMainForm; } }

        /// <summary>
        ///创建主窗体实例
        /// </summary>
        /// <returns></returns>
        public static IBasicForm CreateMainFormInsatance()
        {
            if (_CurrentMainForm != null) _OldMainForm = _CurrentMainForm;

            _CurrentMainForm = new frmMain();
            _CurrentMainForm.StartPosition = FormStartPosition.CenterScreen;

            //
            //其它操作
            //
            return _CurrentMainForm;
        }

        public frmMain()
        {
            InitializeComponent();
        }

        #region Implementation of IBasicForm Interface
        public string FormName { get { return "frmMain"; } }

        public void InitUserInterface(IShowMessage messager)
        {
            //
            //在这里初始化主窗体，如：加载模块，生成菜单，下载公共缓存数据等操作...
            //
            try
            {
                this.SuspendLayout();

                messager.ShowMessage("正在初始化用户界面...");

                messager.ShowMessage("正在加载模块...");

                messager.ShowMessage("正在生成菜单...");

                messager.ShowMessage("正在下载公共缓存数据...");

                messager.ShowMessage("加载主窗体完成.");

                this.ResumeLayout();
            }
            catch (Exception ex)
            {
                SystemMessageBox.ShowException(ex);
            }
        }

        /// <summary>
        /// 标记旧窗体准备进入销毁状态。此标记用于配合FormClosed事件使用。
        /// </summary>
        private static bool _IsDisposingOldForm = false;

        /// <summary>
        /// 用户登出后再登录时实例化两次主窗体，这时要释放旧窗体的内存。        
        /// </summary>
        private static void DisposeOldForm()
        {
            if (_OldMainForm != null)
            {
                _IsDisposingOldForm = true;//打上标记进入销毁状态
                _OldMainForm.Dispose();
                _OldMainForm = null;
                _IsDisposingOldForm = false;//销毁完成，重置标记
            }
        }

        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (_IsDisposingOldForm == false)
                Application.Exit();//关闭主窗体，系统终止!
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.ExistsDataChanged())
            {
                bool ok = SystemMessageBox.Confirm("系统检测到有数据没有保存，真的要退出吗?");
                if (!ok) e.Cancel = true;
            }
        }

        #endregion

        private void logoutSubMenuItem_Click(object sender, EventArgs e)
        {
            if (!Application.AllowQuit) return; //程序不允许退出

            if (!SystemMessageBox.Confirm("Are you sure logout??")) return;

            try
            {
                if (this.ExistsDataChanged())
                {
                    SystemMessageBox.ShowWarning("Cannot logout due to some unsaved windows!");
                    return;
                }

                this.Hide();
                if (frmLogin.Login())
                {
                    frmMain.DisposeOldForm();//关闭旧的主窗体，释放内存
                    frmMain.CurrentMainForm.Show();//显示登录窗体                
                }

                GC.Collect();
            }
            catch (Exception ex)
            {
                SystemMessageBox.ShowException(ex);
            }
        }

        private void exitSubMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 检查数据窗体没有保存
        /// </summary>
        /// <returns></returns>
        private bool ExistsDataChanged()
        {
            return false;
        }

        private void SubMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem menuItem = sender as ToolStripMenuItem;

            if (menuItem != null)
            {
                string funcTag = menuItem.Tag as string;
                if (!String.IsNullOrEmpty(funcTag))
                {
                    // Check if the current user has permission to access this feature
                }

                Form form = null;
                if (funcTag == "Database Server Setting")
                {
                    form = new frmDatabaseSettings();
                }
                else if (funcTag == "Email Server Setting")
                {
                    form = new frmEmailSettings();
                }
                else if (funcTag == "Roles")
                {
                    form = new frmRoles();
                }
                else if (funcTag == "Users")
                {
                    form = new frmUsers();
                }
                else if (funcTag == "Groups")
                {
                    form = new frmGroups();
                }
                else if (funcTag == "Permissions")
                {
                    form = new frmPermissions();
                }
                else if (funcTag == "Create Sub Task")
                {
                    form = new frmCreateSubTask();
                }
                else if (funcTag == "Create DB Ticket")
                {
                    form = new frmCreateDBTicket();
                }
                else if (funcTag == "Work Log Report")
                {
                    form = new frmWorkLogReport();
                }
                else if (funcTag == "Delivery Progress Report")
                {
                    form = new frmDeliveryProgressReport();
                }
                else if (funcTag == "Scan Case Status Cross Project")
                {
                    form = new frmScanCaseStatusCrossProject();
                }
                else if (funcTag == "Daily Case Manager")
                {
                    form = new frmDailyCaseManager();
                }
                else if (funcTag == "Weekly Case Manager")
                {
                    form = new frmWeeklyCaseManager();
                }
                else if (funcTag == "Scan Release Status")
                {
                    form = new frmScanReleaseStatus();
                }
                else if (funcTag == "Scan New FTP Upload")
                {
                    form = new frmScanNewFTPUpload();
                }
                else if (funcTag == "Merge Attachments")
                {
                    form = new frmMergeAttachments();
                }
                else if (funcTag == "Contact")
                {
                    form = new frmContactInfo();
                }
                else if (funcTag == "License")
                {
                    form = new frmLicenseInfo();
                }
                else if (funcTag == "Version")
                {
                    form = new frmVersionInfo();
                }
                

                if (form != null)
                {
                    form.ShowInTaskbar = false;
                    form.MaximizeBox = false;
                    form.MinimizeBox = false;

                    if (funcTag == "Database Server Setting"
                        || funcTag == "Email Server Setting"
                        || funcTag == "Contact"
                        || funcTag == "License"
                        || funcTag == "Version")
                    {                        
                        form.StartPosition = FormStartPosition.CenterParent;
                        form.ShowDialog();
                    }
                    else
                    {
                        foreach (Form child in this.MdiChildren)
                        {
                            child.Close();
                            child.Dispose();
                        }
                                                
                        //form.Dock = DockStyle.Fill;
                        form.MdiParent = this;
                        form.ControlBox = true;
                        form.ShowIcon = false;
                        form.MaximizeBox = false;
                        form.MinimizeBox = false;
                        form.WindowState = FormWindowState.Maximized;
                        form.Show();
                    }
                }
                else
                {
                    SystemMessageBox.ShowError("No form is initialized.");
                }
            }
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            if (this.MdiChildren.Length == 0)
            {
                frmDashboard form = new frmDashboard();
                form.WindowState = FormWindowState.Maximized;
                form.MdiParent = this;
                form.ControlBox = true;
                form.ShowIcon = false;
                form.Show();
            }
        }

        private void toolMenuItem_Click(object sender, EventArgs e)
        {
            frmSmartTask form = new frmSmartTask();
            form.StartPosition = FormStartPosition.CenterParent;
            form.ShowDialog();
        }

        private void toolMenuBackDefaultDashboard_Click(object sender, EventArgs e)
        {
            foreach (Form child in this.MdiChildren)
            {
                child.Close();
                child.Dispose();
            }

            if (this.MdiChildren.Length == 0)
            {
                frmDashboard form = new frmDashboard();
                form.WindowState = FormWindowState.Maximized;
                form.MdiParent = this;
                form.ControlBox = true;
                form.ShowIcon = false;
                form.Show();
            }
        }

        private void toolMenuExpressToReviewCase_Click(object sender, EventArgs e)
        {
            string sfNo = Interaction.InputBox("Please enter one salesforce case NO.", "Express to Review Case");

            foreach (Form child in this.MdiChildren)
            {
                child.Close();
                child.Dispose();
            }

            frmExpressToReviewCase form = new frmExpressToReviewCase();
            form.WindowState = FormWindowState.Maximized;
            form.MdiParent = this;
            form.ControlBox = true;
            form.ShowIcon = false;
            form.Show();
        }
    }
}
