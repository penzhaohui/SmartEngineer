using log4net;
using SmartEngineer.Framework.Logger;
using SmartEngineer.Notification;
using SmartEngineer.ServiceClient.Adapters;
using SmartEngineer.ServiceClient.Enums;
using SmartSql;
using SmartSql.Abstractions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartEngineer.Forms
{
    public partial class frmLogin : Form
    {
        /// <summary>
        /// Logger object.
        /// </summary>
        private static readonly ILog Logger = LogFactory.Instance.GetLogger(typeof(frmLogin));

        public frmLogin()
        {
            InitializeComponent();
            CheckRemotServer();
        }

        private void CheckRemotServer()
        {
            this.ShowConnectInfo("The remote server is ready.");
        }

        /// <summary>
        /// 打开登录窗体 
        /// </summary>
        /// <returns></returns>
        public static bool Login()
        {
            frmLogin frmLogin = new frmLogin();
            DialogResult result = frmLogin.ShowDialog(); 
            return (result == DialogResult.OK);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            try
            {
                if (false == this.ValidateInput()) return;

                this.Cursor = Cursors.WaitCursor;
                this.SetButtonEnable(false);
                this.Update();//必须
                this.ShowConnectInfo("Processing to validate user and password");

                /*
                IJiraAdapter4ENGSUPP adapter1 = new JiraAdapter4ENGSUPP();
                List<string> labels = new List<string>();
                labels.Add("Resolved");
                labels.Add("Closed");
                labels.Add("In Progress");
                adapter1.GetIssuesByLabelList(labels.ToArray());
                */

                ISmartSqlMapper sqlMapperManager = SQLMapperManager.Instance.GetSQLMapper(AppDomain.CurrentDomain.BaseDirectory + "\\Config\\SmartSqlMapConfig.xml");

                Logger.Info("Debug");
                IAccountAdapter adapter = new AccountAdapter();
                adapter.Login(AccountType.Normal, this.txtUser.Text, this.txtPassword.Text);
                

                if (this.ValidateInput()) //调用系统安全管理模块登录方法
                {
                    //
                    //授权成功, 下载用户权限数据.....
                    //
                    //登录成功，初始化主窗体，初始化进度在登录窗体的状态栏显示
                    IBasicForm MainFrom = frmMain.CreateMainFormInsatance();
                    MainFrom.InitUserInterface(new LabelMessager(lblConnectStatus));                   

                    this.DialogResult = DialogResult.OK; //成功
                    this.Close(); //关闭登陆窗体
                }
                else
                {
                    this.ShowConnectInfo("Failed to connect，please check user name and password!");
                    SystemMessageBox.ShowWarning("Failed to connect，please check user name and password!");
                }
            }
            catch(Exception ex)
            {
                Logger.Error("Failed to login, the detailed exception is listed as below:\n" + ex);
                this.SetButtonEnable(true);
                this.ShowConnectInfo("Failed to connect, please contact the system administrator!");
                SystemMessageBox.ShowWarning("Failed to connect, please contact the system administrator!");
            }

            this.Cursor = Cursors.Default;
        }

        private void ShowConnectInfo(string info)
        {
            lblConnectStatus.Text = info;
            lblConnectStatus.Invalidate();
        }

        private void SetButtonEnable(bool value)
        {
            this.btnConnect.Enabled = value;
            this.btnExit.Enabled = value;
            this.btnConnect.Update();
            this.btnExit.Update();
        }

        private bool ValidateInput()
        {

            if (String.IsNullOrEmpty(this.txtUser.Text.Trim()))
            {
                MessageBox.Show("User is required!", "Validating", MessageBoxButtons.OK);
                this.txtUser.Focus();
                return false;
            }

            if (String.IsNullOrEmpty(this.txtPassword.Text.Trim()))
            {
                MessageBox.Show("Password is required", "Validating", MessageBoxButtons.OK);
                this.txtPassword.Focus();
                return false;
            }

            return true;
        }
    }
}
