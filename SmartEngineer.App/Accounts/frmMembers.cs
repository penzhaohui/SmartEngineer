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
using SmartEngineer.ServiceClient.Adapters;
using SmartEngineer.ServiceClient.MemberService;
using SmartEngineer.Common;

namespace SmartEngineer.Forms
{
    public partial class frmMembers : Form, IBasicForm
    {
        private readonly static IMemberAdapter MemberAdapter = new MemberAdapter();

        public frmMembers()
        {
            InitializeComponent();
        }

        public string FormName => throw new NotImplementedException();

        public void InitUserInterface(IShowMessage messager)
        {
            this.cmbTenants.Items.Clear();
            var tenants = MemberAdapter.GetAllTenants();
            foreach (Tenant tenant in tenants)
            {
                this.cmbTenants.Items.Add(new ListItem(tenant.Name, tenant.ID));
            }

            this.cmbRoles.Items.Clear();
            var roles = MemberAdapter.GetAllRoles();
            foreach (Role role in roles)
            {
                this.cmbRoles.Items.Add(new ListItem(role.Name, role.ID));
            }

            this.cmbGroups.Items.Clear();
            var groups = MemberAdapter.GetAllGroups();
            foreach (Group group in groups)
            {
                this.cmbGroups.Items.Add(new ListItem(group.Name, group.ID));
            }

            List<Member> members = MemberAdapter.GetAllMembers(null);

            this.dgvMemberList.AutoGenerateColumns = false;
            this.dgvMemberList.DataSource = members;
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            frmMemberNew frmMemberNew = new frmMemberNew();
            frmMemberNew.StartPosition = FormStartPosition.CenterParent;
            frmMemberNew.ShowDialog();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (this.dgvMemberList.SelectedRows.Count != 1)
            {
                SystemMessageBox.ShowInformation("Please select one member only.");
                return;
            }

            var members = this.dgvMemberList.DataSource as List<Member>;
            int index = this.dgvMemberList.SelectedRows[0].Index;
            frmMemberNew frmMemberNew = new frmMemberNew();
            frmMemberNew.InitializeMemberProfile(members[index]);
            frmMemberNew.StartPosition = FormStartPosition.CenterParent;
            frmMemberNew.ShowDialog();
        }

        private void dgvMemberList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowindex = e.RowIndex;
            if (rowindex >= 0)
            {
                dgvMemberList.Rows[rowindex].Selected = true;
            }
        }

        private void btnActivate_Click(object sender, EventArgs e)
        {
            if (this.dgvMemberList.SelectedRows.Count != 1)
            {
                SystemMessageBox.ShowInformation("Please select one member only.");
                return;
            }

            int index = this.dgvMemberList.SelectedRows[0].Index;
            var members = this.dgvMemberList.DataSource as List<Member>;
            if (!members[index].IsActive)
            {
                members[index].IsActive = true;
                int ID = MemberAdapter.UpdateMember(members[index]);
                if (ID > 0)
                {
                    SystemMessageBox.ShowInformation("Activate member successfully.");
                }
                else
                {
                    SystemMessageBox.ShowInformation("Failed to activate member.");
                }
            }
        }

        private void btnForbidden_Click(object sender, EventArgs e)
        {
            if (this.dgvMemberList.SelectedRows.Count != 1)
            {
                SystemMessageBox.ShowInformation("Please select one member only.");
                return;
            }

            int index = this.dgvMemberList.SelectedRows[0].Index;
            var members = this.dgvMemberList.DataSource as List<Member>;
            if (members[index].IsActive)
            {
                members[index].IsActive = false;
                int ID = MemberAdapter.UpdateMember(members[index]);
                if (ID > 0)
                {
                    SystemMessageBox.ShowInformation("Deactivate member successfully.");
                }
                else
                {
                    SystemMessageBox.ShowInformation("Failed to Deactivate member.");
                }
            }
        }

        private void btnResetPassword_Click(object sender, EventArgs e)
        {
            if (this.dgvMemberList.SelectedRows.Count != 1)
            {
                SystemMessageBox.ShowInformation("Please select one member only.");
                return;
            }

            int index = this.dgvMemberList.SelectedRows[0].Index;
            var members = this.dgvMemberList.DataSource as List<Member>;
            MemberAdapter.ResetPasswrord(members[index].EmailAddress);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            int tenantID = 0;
            ListItem selectedTenant = this.cmbTenants.SelectedItem as ListItem;
            if (selectedTenant != null)
            {
                tenantID = selectedTenant.Value;
            }

            int roleID = 0;
            ListItem selectedRole = this.cmbRoles.SelectedItem as ListItem;
            if (selectedRole != null)
            {
                roleID = selectedRole.Value;
            }

            int groupID = 0;
            ListItem selectedGroup = this.cmbGroups.SelectedItem as ListItem;
            if (selectedGroup != null)
            {
                groupID = selectedGroup.Value;
            }

            string emailAddress = this.txtEmail.Text.Trim();

            Member memberSearchCriteria = new Member();
            memberSearchCriteria.TenantID = tenantID;
            memberSearchCriteria.EmailAddress = emailAddress;

            var members = MemberAdapter.GetAllMembers(memberSearchCriteria);
            this.dgvMemberList.AutoGenerateColumns = false;
            this.dgvMemberList.DataSource = members;
        }

        private void btnAssignToRole_Click(object sender, EventArgs e)
        {
            if (this.dgvMemberList.SelectedRows.Count != 1)
            {
                SystemMessageBox.ShowInformation("Please select one member only.");
                return;
            }

            int index = this.dgvMemberList.SelectedRows[0].Index;
            var members = this.dgvMemberList.DataSource as List<Member>;

            frmAssignToRole frmAssignToRole = new frmAssignToRole();
            frmAssignToRole.StartPosition = FormStartPosition.CenterParent;
            frmAssignToRole.MemberEmailAddress = members[index].EmailAddress;
            frmAssignToRole.InitUserInterface(null);
            frmAssignToRole.ShowDialog();
        }

        private void btnAssignToGroup_Click(object sender, EventArgs e)
        {
            if (this.dgvMemberList.SelectedRows.Count != 1)
            {
                SystemMessageBox.ShowInformation("Please select one member only.");
                return;
            }

            int index = this.dgvMemberList.SelectedRows[0].Index;
            var members = this.dgvMemberList.DataSource as List<Member>;

            frmAssignToGroup frmAssignToGroup = new frmAssignToGroup();
            frmAssignToGroup.StartPosition = FormStartPosition.CenterParent;
            frmAssignToGroup.MemberEmailAddress = members[index].EmailAddress;
            frmAssignToGroup.InitUserInterface(null);
            frmAssignToGroup.ShowDialog();
        }
    }
}
