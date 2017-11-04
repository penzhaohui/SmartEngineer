using SmartEngineer.Common;
using SmartEngineer.Framework.Constant;
using SmartEngineer.Notification;
using SmartEngineer.ServiceClient.Adapters;
using SmartEngineer.ServiceClient.SettingService;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SmartEngineer.Forms
{
    public partial class frmDatabaseSettings : Form, IBasicForm
    {
        private static readonly IConfigAdapter ConfigAdapter = new ConfigAdapter();
        private static readonly IDatabaseAdapter DatabaseAdapter = new DatabaseAdapter();
        private static List<ConfigOption> Options = new List<ConfigOption>();

        public frmDatabaseSettings()
        {
            InitializeComponent();
            Initialize();
        }

        public void Initialize()
        {
            this.cmbAuthenticationType.Items.Clear();
            this.cmbAuthenticationType.Items.Add("Windows Authentication");
            this.cmbAuthenticationType.Items.Add("SQL Server Authentication");

            Options = ConfigAdapter.GetConfigOptions(DBSettingConstant.OPTION_NAME);
            this.txtServerName.Text = Options.GetOptionValue(DBSettingConstant.SERVER_LOCATION);
            string DBType = Options.GetOptionValue(DBSettingConstant.DATABASE_TYPE);
            this.cmbAuthenticationType.SelectedValue = Options.GetOptionValue(DBSettingConstant.AUTH_TYPE);
            this.txtUserName.Text = Options.GetOptionValue(DBSettingConstant.LOGIN_USER);
            this.txtPassword.Text = Options.GetOptionValue(DBSettingConstant.LOGIN_PASSWORD);

            RefreshDBInstances();

            this.cmbMembership.SelectedValue = Options.GetOptionValue(DBSettingConstant.MEMBERSHIP_INSTANCE);
            this.cmbSmartEngineer.SelectedValue = Options.GetOptionValue(DBSettingConstant.SMARTENGINEER_INSTANCE);
            this.cmbAuditLog.SelectedValue = Options.GetOptionValue(DBSettingConstant.AUDIT_LOG_INSTANCE);
        }

        public void RefreshDBInstances()
        {
            if (txtServerName.Text.Trim().Length == 0)
            {
                txtServerName.Focus();
                SystemMessageBox.ShowInformation("Please enter database server name or ip.");
                return;
            }

            if (txtUserName.Text.Trim().Length == 0)
            {
                txtUserName.Focus();
                SystemMessageBox.ShowInformation("Please enter database user name.");
                return;
            }

            if (txtPassword.Text.Trim().Length == 0)
            {
                txtPassword.Focus();
                SystemMessageBox.ShowInformation("Please enter database user password.");
                return;
            }

            if (cmbAuthenticationType.SelectedIndex == -1)
            {
                cmbAuthenticationType.Focus();
                SystemMessageBox.ShowInformation("Please select one authentication type at least.");
                return;
            }

            List<string> dbInstanceNameList = DatabaseAdapter.GetDBInstances(txtServerName.Text, (cmbAuthenticationType.SelectedValue as string), txtUserName.Text, txtPassword.Text);

            if (dbInstanceNameList != null && dbInstanceNameList.Count > 0)
            {
                this.cmbMembership.DataSource = dbInstanceNameList;
                this.cmbSmartEngineer.DataSource = dbInstanceNameList;
                this.cmbAuditLog.DataSource = dbInstanceNameList;
            }
            else
            {
                SystemMessageBox.ShowInformation("No Database Instance is found.");
            }
        }

        public string FormName => throw new NotImplementedException();

        public void InitUserInterface(IShowMessage messager)
        {
            this.cmbAuthenticationType.Items.Clear();
            this.cmbAuthenticationType.Items.Add("MSSQL");
            this.cmbAuthenticationType.Items.Add("SQLite");
            this.cmbAuthenticationType.Items.Add("MySQL");
            this.cmbAuthenticationType.Items.Add("Oracle");
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
            this.Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            List<ConfigOption> options = GollectConfigOption();
            bool isUpdateSuccess = ConfigAdapter.UpdateConfigOptions(DBSettingConstant.OPTION_NAME, options);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RefreshDBInstances();
        }

        private void btnTestConnection_Click(object sender, EventArgs e)
        {

        }

        private void btnAdvancedSettings_Click(object sender, EventArgs e)
        {
            SystemMessageBox.ShowInformation("It is being implemented...");
        }

        private List<ConfigOption> GollectConfigOption()
        {
            string serverName = this.txtServerName.Text;            
            string authType = this.cmbAuthenticationType.SelectedValue as string;
            string userName = this.txtUserName.Text;
            string password = this.txtPassword.Text;
            string dbMembership = this.cmbMembership.SelectedValue as string;
            string dbSmartEngineer = this.cmbSmartEngineer.SelectedValue as string;
            string dbAuditLog = this.cmbAuditLog.SelectedValue as string;

            List<ConfigOption> options = new List<ConfigOption>();
            options.Add(CreateConfigOption(DBSettingConstant.SERVER_LOCATION, serverName));
            options.Add(CreateConfigOption(DBSettingConstant.AUTH_TYPE, authType));
            options.Add(CreateConfigOption(DBSettingConstant.LOGIN_USER, userName));
            options.Add(CreateConfigOption(DBSettingConstant.LOGIN_PASSWORD, password));
            options.Add(CreateConfigOption(DBSettingConstant.MEMBERSHIP_INSTANCE, dbMembership));
            options.Add(CreateConfigOption(DBSettingConstant.SMARTENGINEER_INSTANCE, dbSmartEngineer));
            options.Add(CreateConfigOption(DBSettingConstant.AUDIT_LOG_INSTANCE, dbAuditLog));

            return options;
        }

        private ConfigOption CreateConfigOption(string name, string value)
        {
            ConfigOption option = new ConfigOption();
            option.ConfigOptionValue = name;
            option.ConfigOptionDesc = value;
            option.IsActive = true;
            option.ConfigExtra = string.Empty;

            return option;
        }
    }
}
