using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SmartEngineer.Notification;

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

            if (!SystemMessageBox.Confirm("真的要登出吗?")) return;

            try
            {
                if (this.ExistsDataChanged())
                {
                    SystemMessageBox.ShowWarning("系统检测到有数据窗体没有保存，不能登出!");
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

                foreach (Form child in this.MdiChildren)
                {
                    child.Close();
                    child.Dispose();
                }

                if (form != null)
                {
                    form.ShowInTaskbar = false;
                    form.MaximizeBox = false;
                    form.MinimizeBox = false;

                    if (funcTag == "Contact"
                        || funcTag == "License"
                        || funcTag == "Version")
                    {
                        form.ShowDialog();
                        form.StartPosition = FormStartPosition.CenterScreen;
                    }
                    else
                    {
                        form.WindowState = FormWindowState.Maximized;
                        form.MdiParent = this;
                        form.ControlBox = true;
                        form.ShowIcon = false;
                        form.Show();
                    }
                }
                else
                {
                    SystemMessageBox.ShowError("No form is initialized.");
                }
            }
        }
    }
}
