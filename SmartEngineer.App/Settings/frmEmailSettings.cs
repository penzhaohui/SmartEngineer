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
using SmartEngineer.ServiceClient.SettingService;
using SmartEngineer.ServiceClient.Adapters;
using SmartEngineer.Common;
using SmartEngineer.Framework.Constant;
using SmartEngineer.Framework.Utils;

namespace SmartEngineer.Forms
{
    public partial class frmEmailSettings : Form, IBasicForm
    {
        private static readonly IConfigAdapter ConfigAdapter = new ConfigAdapter();

        public frmEmailSettings()
        {
            InitializeComponent();
            Initialize();
        }

        public void Initialize()
        {
            this.cmbAccountType.Items.Clear();
            this.cmbAccountType.Items.Add("POP3");
            this.cmbAccountType.Items.Add("IMAP");

            List<ConfigOption> options = ConfigAdapter.GetConfigOptions(EmailSettingConstant.OPTION_NAME);
            this.txtDisplayName.Text = options.GetOptionValue(EmailSettingConstant.DISPLAY_NAME);
            this.txtUserName.Text = options.GetOptionValue(EmailSettingConstant.USER_NAME);
            this.txtEmailAddress.Text = options.GetOptionValue(EmailSettingConstant.EMAIL_ADDRESS);
            this.txtPassword.Text = options.GetOptionValue(EmailSettingConstant.EMAIL_PASSWORD);

            this.cmbAccountType.SelectedItem = options.GetOptionValue(EmailSettingConstant.ACCOUNT_TYPE);
            this.txtIncomingMailServer.Text = options.GetOptionValue(EmailSettingConstant.INCOMING_MAIL_SERVER);
            this.txtOutgoingMailServer.Text = options.GetOptionValue(EmailSettingConstant.OUTGOING_MAIL_SERVER);
            this.chkRequireSPA .Checked = CommonUtil.IsTrue(options.GetOptionValue(EmailSettingConstant.SECURITY_PASSWORD_AUTHENTICATION));
        }

        public string FormName => throw new NotImplementedException();

        public void InitUserInterface(IShowMessage messager)
        {
            throw new NotImplementedException();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
            this.Close(); 
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            List<ConfigOption> options = GollectConfigOption();
            bool isUpdateSuccess = ConfigAdapter.UpdateConfigOptions(EmailSettingConstant.OPTION_NAME, options);
            if (isUpdateSuccess)
            {
                SystemMessageBox.ShowInformation("Save successfully.");
            }
            else
            {
                SystemMessageBox.ShowInformation("Failed to save, please contact administrator.");
            }
        }

        private List<ConfigOption> GollectConfigOption()
        {
            string displayName = this.txtDisplayName.Text;
            string userName = this.txtUserName.Text;
            string emailAddress = this.txtEmailAddress.Text;
            string password = this.txtPassword.Text;
            string accountType = this.cmbAccountType.SelectedItem as string;
            string incomingMailServer = this.txtIncomingMailServer.Text;
            string outGoingMailServer = this.txtOutgoingMailServer.Text;
            string spa = this.chkRequireSPA.Checked.ToString();


            List<ConfigOption> options = new List<ConfigOption>();
            options.Add(CreateConfigOption(EmailSettingConstant.DISPLAY_NAME, displayName));
            options.Add(CreateConfigOption(EmailSettingConstant.USER_NAME, userName));
            options.Add(CreateConfigOption(EmailSettingConstant.EMAIL_ADDRESS, emailAddress));
            options.Add(CreateConfigOption(EmailSettingConstant.EMAIL_PASSWORD, password));
            options.Add(CreateConfigOption(EmailSettingConstant.ACCOUNT_TYPE, accountType));
            options.Add(CreateConfigOption(EmailSettingConstant.INCOMING_MAIL_SERVER, incomingMailServer));
            options.Add(CreateConfigOption(EmailSettingConstant.OUTGOING_MAIL_SERVER, outGoingMailServer));
            options.Add(CreateConfigOption(EmailSettingConstant.SECURITY_PASSWORD_AUTHENTICATION, spa));

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
