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
using SmartEngineer.Common;
using SmartEngineer.ServiceClient.Adapters;
using SmartEngineer.ServiceClient.MemberService;

namespace SmartEngineer.Forms
{
    public partial class frmAssignToGroup : Form, IBasicForm
    {
        private readonly static IMemberAdapter MemberAdapter = new MemberAdapter();
        public string MemberEmailAddress { get; set; }

        public frmAssignToGroup()
        {
            InitializeComponent();
        }

        public string FormName => throw new NotImplementedException();
        
        public void InitUserInterface(IShowMessage messager)
        {
            if (String.IsNullOrEmpty(MemberEmailAddress))
            {
                messager.ShowMessage("No email address on the selected member.");
                return;
            }

            var groups = MemberAdapter.GetAllGroups();
            var linkedGroups = MemberAdapter.GetLinkedGroups(MemberEmailAddress);

            this.lbxAssignedGroups.Items.Clear();
            this.lbxUnassignedGroups.Items.Clear();

            foreach (Group group in groups)
            {
                if (linkedGroups.Contains(group.ID))
                {
                    this.lbxAssignedGroups.Items.Add(group.Name);
                }
                else
                {
                    this.lbxUnassignedGroups.Items.Add(group.Name);
                }
            }
        }

        private void btnMoveToRight_Click(object sender, EventArgs e)
        {
            var selectedItems = this.lbxUnassignedGroups.SelectedItems;
            foreach (var item in selectedItems)
            {
                this.lbxAssignedGroups.Items.Add(item);
                this.lbxUnassignedGroups.Items.Remove(item);

                if (selectedItems.Count == 0) break;
            }
        }

        private void btnMoveToLeft_Click(object sender, EventArgs e)
        {
            var selectedItems = this.lbxAssignedGroups.SelectedItems;
            foreach (var item in selectedItems)
            {
                this.lbxUnassignedGroups.Items.Add(item);
                this.lbxAssignedGroups.Items.Remove(item);

                if (selectedItems.Count == 0) break;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            List<string> unAssignedGroupNames = new List<string>();
            List<string> assignedGroupNames = new List<string>();

            var selectedItems = this.lbxAssignedGroups.Items;
            foreach (var item in selectedItems)
            {
                assignedGroupNames.Add(item as string);
            }

            selectedItems = this.lbxUnassignedGroups.Items;
            foreach (var item in selectedItems)
            {
                unAssignedGroupNames.Add(item as string);
            }

            bool assignSuccess = MemberAdapter.LinkToGroups(MemberEmailAddress, assignedGroupNames, true);
            bool unassignSuccess = MemberAdapter.LinkToGroups(MemberEmailAddress, unAssignedGroupNames, false);

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
