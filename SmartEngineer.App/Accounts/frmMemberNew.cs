using SmartEngineer.Notification;
using SmartEngineer.ServiceClient.Adapters;
using SmartEngineer.ServiceClient.MemberService;
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
    public partial class frmMemberNew : Form
    {
        private readonly static IMemberAdapter MemberAdapter = new MemberAdapter();

        public frmMemberNew()
        {
            InitializeComponent();
        }

        public void InitializeMemberProfile(Member member)
        {
            this.txtMemberID.Text = "" + member.ID;
            this.txtLoginAccountID.Text = "" + member.AccountID;
            this.txtLoginAccountName.Text = member.AccountName;
            this.txtUserName.Text = member.UserName;
            this.txtDisplayName.Text = member.DisplayName;
            this.txtSignature.Text = member.Signature;
            this.txtFirstName.Text = member.FirstName;
            this.txtLastName.Text = member.LastName;
            this.chkIsActive.Checked = member.IsActive;

            this.txtEmailAccount.Text = member.EmailAddress;
            this.txtEmailPassword.Text = member.EmailPassword;
            this.txtJiraAccount.Text = member.JiraAccount;
            this.txtJiraPassword.Text = member.JiraPassword;
            this.txtTestRailAccount.Text = member.TestRailAccount;
            this.txtTestRailPassword.Text = member.TestRailPassword;
            this.txtGitHubAccount.Text = member.GitHubAccount;
            this.txtGitHubPassword.Text = member.GitHubPassword;

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int ID = this.txtMemberID.Text.Trim().Length == 0 ? 0 : int.Parse(this.txtMemberID.Text.Trim());
            int accountID = this.txtLoginAccountID.Text.Trim().Length == 0 ? 0 : int.Parse(this.txtLoginAccountID.Text.Trim());
            string accountName = this.txtLoginAccountName.Text.Trim();
            int tenantID = 0;
            string tenantName = string.Empty;
            string userName = this.txtUserName.Text.Trim();
            string displayName = this.txtDisplayName.Text.Trim();
            string firstName = this.txtFirstName.Text.Trim();
            string lastName = this.txtLastName.Text.Trim();
            string signature = this.txtSignature.Text.Trim();
            bool isActive = this.chkIsActive.Checked;
            string emailAddress = this.txtEmailAccount.Text.Trim();
            string emailPassword = this.txtEmailPassword.Text.Trim();
            string jiraAccountID = "";
            string jiraAccount = this.txtJiraAccount.Text.Trim();
            string jiraPassword = this.txtJiraPassword.Text.Trim();
            string testRailAccountID = "";
            string testRailAccount = this.txtTestRailAccount.Text.Trim();
            string testRailPassword = this.txtTestRailPassword.Text.Trim();
            string gitHubAccountID = "";
            string gitHubAccount = this.txtGitHubAccount.Text.Trim();
            string gitHubPassword = this.txtGitHubPassword.Text.Trim();

            Member member = new Member();
            member.ID = ID;
            member.AccountID = accountID;
            member.TenantID = tenantID;
            member.UserName = userName;
            member.DisplayName = displayName;
            member.FirstName = firstName;
            member.LastName = lastName;
            member.Signature = signature;
            member.IsActive = isActive;
            member.EmailAddress = emailAddress;
            member.EmailPassword = emailPassword;
            member.JiraAccountID = jiraAccountID;
            member.JiraAccount = jiraAccount;
            member.JiraPassword = jiraPassword;
            member.TestRailAccountID = testRailAccountID;
            member.TestRailAccount = testRailAccount;
            member.TestRailPassword = testRailPassword;
            member.GitHubAccountID = gitHubAccountID;
            member.GitHubAccount = gitHubAccount;
            member.GitHubPassword = gitHubPassword;

            ID = MemberAdapter.UpdateMember(member);
            if (ID > 0)
            {
                SystemMessageBox.ShowInformation("Save successfully.");
                this.DialogResult = DialogResult.OK; //成功
                this.Close();
            }
            else
            {
                SystemMessageBox.ShowInformation("Failed to save, please contact administrator.");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel; //成功
            this.Close();
        }
    }    
}
