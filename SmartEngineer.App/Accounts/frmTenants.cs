using SmartEngineer.Common;
using SmartEngineer.Notification;
using SmartEngineer.ServiceClient.Adapters;
using SmartEngineer.ServiceClient.MemberService;
using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Windows.Forms;

namespace SmartEngineer.Forms
{
    public partial class frmTenants : Form
    {
        private readonly static IMemberAdapter MemberAdapter = new MemberAdapter();

        public frmTenants()
        {
            InitializeComponent();

            Initialize();
        }

        private void Initialize()
        {
            this.cmbTimeZone.Items.Clear();
            ReadOnlyCollection<TimeZoneInfo> timeZones = TimeZoneInfo.GetSystemTimeZones();
            foreach (TimeZoneInfo timeZone in timeZones)
            {
                bool hasDST = timeZone.SupportsDaylightSavingTime;
                TimeSpan offsetFromUtc = timeZone.BaseUtcOffset;
                cmbTimeZone.Items.Add(new ListItem(timeZone.DisplayName, timeZone.StandardName));
            }

            DataTable table = new DataTable("Tenant List");
            table.Columns.Add("TenantID", typeof(int));
            table.Columns.Add("TenantName", typeof(string));
            table.Columns.Add("Description", typeof(string));
            table.Columns.Add("DomainPattern", typeof(string));
            table.Columns.Add("Active", typeof(bool));
            table.Columns.Add("RegisterDate", typeof(string));
            table.Columns.Add("TimeZone", typeof(string));
            table.Columns.Add("MaxAccountNumber", typeof(int));

            var tenants = MemberAdapter.GetAllTenants();
            foreach (Tenant tenant in tenants)
            {
                DataRow row = table.NewRow();
                row["TenantID"] = tenant.ID;
                row["TenantName"] = tenant.Name;
                row["Description"] = tenant.Description;
                row["RegisterDate"] = tenant.CreateDate.ToShortDateString();
                row["DomainPattern"] = tenant.DomainPattern;
                row["Active"] = tenant.IsActive;
                row["TimeZone"] = tenant.TimeZone;
                row["MaxAccountNumber"] = tenant.MaxAccountNumber;

                table.Rows.Add(row);
            }

            this.dgrTenantList.AutoGenerateColumns = false;
            this.dgrTenantList.DataSource = table;            
        }

        private void btnNewTenant_Click(object sender, System.EventArgs e)
        {
            frmTenantNew frmTenantNew = new frmTenantNew();
            frmTenantNew.StartPosition = FormStartPosition.CenterParent;
            frmTenantNew.ShowDialog();
        }

        private void dgrTenantList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dgrTenantList_CellClick(sender, e);
        }

        private void btnSaveTenant_Click(object sender, EventArgs e)
        {
            SaveTenant();
        }

        private void btnActivateTenant_Click(object sender, EventArgs e)
        {
            this.chkIsActive.Checked = true;
            SaveTenant();
        }

        private void btnForbiddenTenant_Click(object sender, EventArgs e)
        {
            this.chkIsActive.Checked = false;
            SaveTenant();
        }

        private void SaveTenant()
        {
            if (String.IsNullOrEmpty(this.txtTenantID.Text))
            {
                return;
            }

            int ID = int.Parse(this.txtTenantID.Text);
            string tenantName = this.txtTenantName.Text;
            string domainPattern = this.txtDomainPattern.Text;
            string timeZone = ((ListItem)this.cmbTimeZone.SelectedItem).Value;
            int MaxUserCount = int.Parse(this.txtMaxUserCount.Text);
            bool isActive = this.chkIsActive.Checked;
            string description = this.txtDescription.Text;

            Tenant tenant = new Tenant();
            tenant.ID = ID;
            tenant.Name = tenantName;
            tenant.DomainPattern = domainPattern;
            tenant.TimeZone = timeZone;
            tenant.MaxAccountNumber = MaxUserCount;
            tenant.IsActive = isActive;
            tenant.Description = description;
            

            ID = MemberAdapter.UpdateTenant(tenant);
            if (ID > 0)
            {
                SystemMessageBox.ShowInformation("Save successfully.");
            }
            else
            {
                SystemMessageBox.ShowInformation("Failed to save, please contact administrator.");
            }
        }

        private void dgrTenantList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowindex = e.RowIndex;

            this.dgrTenantList.Rows[rowindex].Selected = true;

            DataTable table = this.dgrTenantList.DataSource as DataTable;
            DataRow row = table.Rows[rowindex];
            this.txtTenantID.Text = "" + row["TenantID"];
            this.txtTenantName.Text = row["TenantName"] as string;
            this.txtDescription.Text = row["Description"] as string;
            this.txtDomainPattern.Text = row["DomainPattern"] as string;
            this.chkIsActive.Checked = (bool)row["Active"];
            string TimeZone = row["TimeZone"] as string;

            int index = -1;
            this.cmbTimeZone.SelectedIndex = -1;
            foreach (ListItem item in this.cmbTimeZone.Items)
            {
                index++;
                if (item.Value == TimeZone)
                {
                    this.cmbTimeZone.SelectedIndex = index;
                    break;
                }
            }
            this.txtMaxUserCount.Text = "" + row["MaxAccountNumber"];
        }
    }
}
