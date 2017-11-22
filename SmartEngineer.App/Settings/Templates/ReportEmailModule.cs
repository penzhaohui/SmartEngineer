using SmartEngineer.Common;
using SmartEngineer.ServiceClient.SettingService;
using System;
using System.Collections.Generic;

namespace SmartEngineer.UserControls
{
    public partial class ReportEmailModule : UserControl
    {
        private static readonly string DisplayName = "Display Name";
        private static readonly string FromEmailAddress = "From Email Address";
        private static readonly string UserName = "User Name";
        private static readonly string Password = "Password";
        private static readonly string ToEmailAddress = "To Email Address";
        private static readonly string CCEmailAddress = "CC Email Address";
        private static readonly string BCCEmailAddress = "BCC Email Address";
        private static readonly string SingaturePath = "Singature Path";
        private static readonly string EmailContent = "Email Content";

        private dynamic OriginalValue;
        public string ReportName { get; set; }
        public Func<string, UserControl, bool> SaveFunc { get; set; }
        public Func<string, UserControl, bool> TestFunc { get; set; }

        public ReportEmailModule()
        {
            InitializeComponent();
        }

        public override string OptionName => "Report Email Setting";

        public override List<ConfigOption> CollectOption()
        {
            string displayName = this.txtDisplayName.Text.Trim();
            string from = this.txtFrom.Text.Trim();
            string userName = this.txtUserName.Text.Trim();
            string password = this.txtPassword.Text.Trim();
            string toAddress = this.txtTO.Text.Trim();
            string ccAddress = this.txtCC.Text.Trim();
            string bccAddress = this.txtBCC.Text.Trim();
            string signaturePath = this.txtSignature.Text.Trim();
            string emailContent = this.rtbEmailContent.Text;

            List<ConfigOption> options = new List<ConfigOption>();
            options.Add(CreateConfigOption(DisplayName, displayName));
            options.Add(CreateConfigOption(FromEmailAddress, from));
            options.Add(CreateConfigOption(UserName, userName));
            options.Add(CreateConfigOption(Password, password));
            options.Add(CreateConfigOption(ToEmailAddress, toAddress));
            options.Add(CreateConfigOption(CCEmailAddress, ccAddress));
            options.Add(CreateConfigOption(BCCEmailAddress, bccAddress));
            options.Add(CreateConfigOption(SingaturePath, signaturePath));
            options.Add(CreateConfigOption(EmailContent, emailContent));

            return options;
        }

        public override void Initialize(List<ConfigOption> options)
        {
            this.grpEmailSetting.Text = ReportName + " " + this.grpEmailSetting.Text;

            if (options == null || options.Count == 0) return;
           
            this.txtDisplayName.Text = options.GetOptionValue(DisplayName);
            this.txtFrom.Text = options.GetOptionValue(FromEmailAddress);
            this.txtUserName.Text = options.GetOptionValue(UserName);
            this.txtPassword.Text = options.GetOptionValue(Password);
            this.txtTO.Text = options.GetOptionValue(ToEmailAddress);
            this.txtCC.Text = options.GetOptionValue(CCEmailAddress);
            this.txtBCC.Text = options.GetOptionValue(BCCEmailAddress);
            this.txtSignature.Text = options.GetOptionValue(SingaturePath);
            this.rtbEmailContent.Text = options.GetOptionValue(EmailContent);

            OriginalValue = new {
                DisplayName = this.txtDisplayName.Text.Trim(),
                From = this.txtFrom.Text.Trim(),
                UserName = this.txtUserName.Text.Trim(),
                Password = this.txtPassword.Text.Trim(),
                TO = this.txtTO.Text.Trim(),
                CC = this.txtCC.Text.Trim(),
                BCC = this.txtBCC.Text.Trim(),
                Signature = this.txtSignature.Text.Trim(),
                EmailContent = this.rtbEmailContent.Text
            };
        }

        public override bool IsModified()
        {
            if(OriginalValue == null) return true;

            string displayName = this.txtDisplayName.Text.Trim();
            string from = this.txtFrom.Text.Trim();
            string userName = this.txtUserName.Text.Trim();
            string password = this.txtPassword.Text.Trim();
            string toAddress = this.txtTO.Text.Trim();
            string ccAddress = this.txtCC.Text.Trim();
            string bccAddress = this.txtBCC.Text.Trim();
            string signaturePath = this.txtSignature.Text.Trim();
            string emailContent = this.rtbEmailContent.Text;

            if (displayName != OriginalValue.DisplayName
                || from != OriginalValue.From
                || userName != OriginalValue.UserName
                || password != OriginalValue.Password
                || toAddress != OriginalValue.TO
                || ccAddress != OriginalValue.CC
                || bccAddress != OriginalValue.BCC
                || signaturePath != OriginalValue.Signature
                || emailContent != OriginalValue.EmailContent)
            {
                return true;
            }

            return false;
        }

        private void btnSave_Click(object sender, System.EventArgs e)
        {
            if (SaveFunc != null)
            {
                SaveFunc($"{ReportName} {OptionName}", this);
            }
        }

        private void btnTest_Click(object sender, System.EventArgs e)
        {
            if (TestFunc != null)
            {
                TestFunc($"{ReportName} {OptionName}", this);
            }
        }
    }
}
