using SmartEngineer.ServiceClient.Adapters;
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
using SmartEngineer.ServiceClient.MemberService;
using SmartEngineer.Common;

namespace SmartEngineer.Forms
{
    public partial class frmAssignToRole : Form, IBasicForm
    {
        private readonly static IMemberAdapter MemberAdapter = new MemberAdapter();
        public string MemberEmailAddress { get; set; }

        public string FormName => throw new NotImplementedException();

        public frmAssignToRole()
        {
            InitializeComponent();
        }

        public void InitUserInterface(IShowMessage messager)
        {
            if (String.IsNullOrEmpty(MemberEmailAddress))
            {
                messager.ShowMessage("No email address on the selected member.");
                return;
            }

            var roles = MemberAdapter.GetAllRoles();
            var linkedRoles = MemberAdapter.GetLinkedRoles(MemberEmailAddress);

            this.lbxUnassignedRoles.Items.Clear();
            this.lbxAssignedRoles.Items.Clear();

            foreach (Role role in roles)
            {
                if (linkedRoles.Contains(role.ID))
                {
                    this.lbxAssignedRoles.Items.Add(role.Name);
                }
                else
                {
                    this.lbxUnassignedRoles.Items.Add(role.Name);
                }
            }
        }

        private void btnMoveToRight_Click(object sender, EventArgs e)
        {
            var selectedItems = this.lbxUnassignedRoles.SelectedItems;
            foreach (var item in selectedItems)
            {
                this.lbxAssignedRoles.Items.Add(item);
                this.lbxUnassignedRoles.Items.Remove(item);

                if (selectedItems.Count == 0) break;
            }
        }

        private void btnMoveToLeft_Click(object sender, EventArgs e)
        {
            var selectedItems = this.lbxAssignedRoles.SelectedItems;
            foreach (var item in selectedItems)
            {
                this.lbxUnassignedRoles.Items.Add(item);
                this.lbxAssignedRoles.Items.Remove(item);

                if (selectedItems.Count == 0) break;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            List<string> unAssignedRoleNames = new List<string>();
            List<string> assignedRoleNames = new List<string>();

            var selectedItems = this.lbxAssignedRoles.Items;
            foreach (var item in selectedItems)
            {
                assignedRoleNames.Add(item as string);
            }

            selectedItems = this.lbxUnassignedRoles.Items;
            foreach (var item in selectedItems)
            {
                unAssignedRoleNames.Add(item as string);
            }

            bool assignSuccess = MemberAdapter.LinkToRoles(MemberEmailAddress, assignedRoleNames, true);
            bool unassignSuccess = MemberAdapter.LinkToRoles(MemberEmailAddress, unAssignedRoleNames, false);

            if (assignSuccess && unassignSuccess)
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
