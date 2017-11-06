using SmartEngineer.Common;
using SmartEngineer.Notification;
using SmartEngineer.ServiceClient.Adapters;
using SmartEngineer.ServiceClient.MemberService;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartEngineer.Forms
{
    public partial class frmTenantNew : Form
    {
        private readonly static IMemberAdapter MemberAdapter = new MemberAdapter();

        public frmTenantNew()
        {
            InitializeComponent();
            Initialize();
        }

        public void Initialize()
        {
            this.cmbTimeZone.Items.Clear();
            ReadOnlyCollection<TimeZoneInfo> timeZones = TimeZoneInfo.GetSystemTimeZones();
            foreach (TimeZoneInfo timeZone in timeZones)
            {
                bool hasDST = timeZone.SupportsDaylightSavingTime;
                TimeSpan offsetFromUtc = timeZone.BaseUtcOffset;
                cmbTimeZone.Items.Add(new ListItem(timeZone.DisplayName, timeZone.StandardName));
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string tenantName = this.txtTenantName.Text;
            string domainPattern = this.txtDomainPattern.Text;
            string timeZone = "";
            if (this.cmbTimeZone.SelectedIndex > 0)
            {
                timeZone = ((ListItem)this.cmbTimeZone.SelectedItem).Value;
            }
            int maxUserCount = 0;
            int.TryParse(this.txtMaxUserCount.Text, out maxUserCount);
            bool isActive = this.chkIsActive.Checked;
            string description = this.txtDescription.Text;

            Tenant newTenant = new Tenant();
            newTenant.Name = tenantName;
            newTenant.DomainPattern = domainPattern;
            newTenant.TimeZone = timeZone;
            newTenant.MaxAccountNumber = maxUserCount;
            newTenant.IsActive = isActive;
            newTenant.DomainPattern = domainPattern;
            newTenant.CreateDate = DateTime.Now;
            newTenant.Description = description;

            int ID = MemberAdapter.CreateTenant(newTenant);
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
            this.Close();            
        }
    }
}
