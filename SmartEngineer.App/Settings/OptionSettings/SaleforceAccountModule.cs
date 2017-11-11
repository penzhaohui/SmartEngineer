using SmartEngineer.Common;
using SmartEngineer.Framework.Utils;
using SmartEngineer.ServiceClient.SettingService;
using System;
using System.Collections.Generic;

namespace SmartEngineer.UserControls
{
    public partial class SaleforceAccountModule : UserControl
    {
        private static readonly string APIBaseUrl = "API Base Url";
        private static readonly string SecurityToken = "Security Token";
        private static readonly string ConsumerKey = "Consumer Key";
        private static readonly string ConsumerSecret = "Consumer Secret";
        private static readonly string Username = "Username";
        private static readonly string Password = "Password";
        private static readonly string IsSandboxUser = "Is Sandbox User";
        private static readonly string UpdateInterval = "Update Interval";
        private List<ConfigOption> ConfigOptions = null;

        public SaleforceAccountModule()
        {
            InitializeComponent();
        }

        public override string OptionName => "Salesforce Account Setting";

        public override List<ConfigOption> CollectOption()
        {
            string baseUrl = this.txtAPIBaseUrl.Text;
            string securityToken = this.txtSecurityToken.Text;
            string consumerKey = this.txtConsumerKey.Text;
            string consumerSecret = this.txtConsumerSecret.Text;
            string userName = this.txtUserName.Text;
            string password = this.txtPassword.Text;
            string isSandBoxUser = this.chkSandBox.Checked ? "Yes" : "No";
            string updateInterval = this.cmbUpdateInterval.SelectedItem as string;

            List<ConfigOption> options = new List<ConfigOption>();
            options.Add(CreateConfigOption(APIBaseUrl, baseUrl));
            options.Add(CreateConfigOption(SecurityToken, securityToken));
            options.Add(CreateConfigOption(ConsumerKey, consumerKey));
            options.Add(CreateConfigOption(ConsumerSecret, consumerSecret));
            options.Add(CreateConfigOption(Username, userName));
            options.Add(CreateConfigOption(Password, password));
            options.Add(CreateConfigOption(IsSandboxUser, isSandBoxUser));
            options.Add(CreateConfigOption(UpdateInterval, updateInterval)); ;

            return options;
        }

        public override void Initialize(List<ConfigOption> options)
        {
            this.ConfigOptions = options;

            if (options == null) return;

            this.txtAPIBaseUrl.Text = options.GetOptionValue(APIBaseUrl);
            this.txtSecurityToken.Text = options.GetOptionValue(SecurityToken);
            this.txtConsumerKey.Text = options.GetOptionValue(ConsumerKey);
            this.txtConsumerSecret.Text = options.GetOptionValue(ConsumerSecret);
            this.txtUserName.Text = options.GetOptionValue(Username);
            this.txtPassword.Text = options.GetOptionValue(Password);
            this.chkSandBox.Checked = CommonUtil.IsTrue(options.GetOptionValue(IsSandboxUser));
            this.cmbUpdateInterval.SelectedItem = options.GetOptionValue(UpdateInterval);
        }

        public override bool IsModified()
        {
            if (ConfigOptions == null) return true;

            string baseUrl = this.txtAPIBaseUrl.Text;
            string securityToken = this.txtSecurityToken.Text;
            string consumerKey = this.txtConsumerKey.Text;
            string consumerSecret = this.txtConsumerSecret.Text;
            string userName = this.txtUserName.Text;
            string password = this.txtPassword.Text;
            string isSandBoxUser = this.chkSandBox.Checked ? "Yes" : "No";
            string updateInterval = this.cmbUpdateInterval.SelectedItem as string;

            if (baseUrl != ConfigOptions.GetOptionValue(APIBaseUrl)
                || securityToken != ConfigOptions.GetOptionValue(SecurityToken)
                || consumerKey != ConfigOptions.GetOptionValue(ConsumerKey)
                || consumerSecret != ConfigOptions.GetOptionValue(ConsumerSecret)
                || userName != ConfigOptions.GetOptionValue(Username)
                || password != ConfigOptions.GetOptionValue(Password)
                || isSandBoxUser != ConfigOptions.GetOptionValue(IsSandboxUser)
                || updateInterval != ConfigOptions.GetOptionValue(UpdateInterval))
            {
                return true;
            }

            return false;
        }

        private void SaleforceAccountModule_Load(object sender, EventArgs e)
        {
            
        }
    }
}
