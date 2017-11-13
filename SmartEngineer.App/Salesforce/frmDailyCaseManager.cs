using SmartEngineer.Notification;
using SmartEngineer.ServiceClient.Adapters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace SmartEngineer.Forms
{
    public partial class frmDailyCaseManager : Form, IBasicForm
    {
        public frmDailyCaseManager()
        {
            InitializeComponent();
        }

        public string FormName => throw new NotImplementedException();

        public void InitUserInterface(IShowMessage messager)
        {
        }

        private void btnGetNewCasesFromSalesforce_Click(object sender, EventArgs e)
        {
            this.btnGetNewCasesFromSalesforce.Enabled = false;

            ICaseAdapter caseAdapter = new CaseAdapter();
            List<string> newCaseNoList = caseAdapter.GetNewCasesForToday();
            this.txtInputCaseNOs.Text = string.Join(",", newCaseNoList.ToArray());

            this.btnGetNewCasesFromSalesforce.Enabled = true;
        }

        private void btnGetCommentedCasesFromSalesforce_Click(object sender, EventArgs e)
        {
            this.btnGetCommentedCasesFromSalesforce.Enabled = false;

            ICaseAdapter caseAdapter = new CaseAdapter();
            List<string> newCaseNoList = caseAdapter.GetCommentedCasesForToday();
            this.txtInputCaseNOs.Text = string.Join(",", newCaseNoList.ToArray());

            this.btnGetCommentedCasesFromSalesforce.Enabled = true;
        }

        private void btnGetPendingCasesFromJira_Click(object sender, EventArgs e)
        {
            this.btnGetPendingCasesFromJira.Enabled = false;

            IJiraAdapter caseAdapter = new JiraAdapter();
            List<string> pengdingCaseNoList = caseAdapter.GetPendingCasesForToday();
            this.txtInputCaseNOs.Text = string.Join(",", pengdingCaseNoList.ToArray());

            this.btnGetPendingCasesFromJira.Enabled = true;
        }

        private void btnPullDetailedInfo_Click(object sender, EventArgs e)
        {
            this.btnPullDetailedInfo.Enabled = false;

            try
            {
                List<string> caseNoList = SplitCaseNoList(this.txtInputCaseNOs.Text);

                ICaseAdapter caseAdapter = new CaseAdapter();
                dgvCaseList.AutoGenerateColumns = false;
                dgvCaseList.DataSource = caseAdapter.PullDetailedCaseInfo(caseNoList);
            }
            catch (Exception ex)
            {
                SystemMessageBox.ShowException(ex);
            }

            this.btnPullDetailedInfo.Enabled = true;
        } 

        private void btnSyncSalesforceToJira_Click(object sender, EventArgs e)
        {
            this.btnSyncSalesforceToJira.Enabled = false;

            List<string> caseNoList = new List<string>();

            string caseNo = string.Empty;
            DataTable dt = this.dgvCaseList.DataSource as DataTable;
            foreach (DataRow row in dt.Rows)
            {
                caseNo = row["CaseNo"] as string;
                caseNoList.Add(caseNo);
            }

            IJiraAdapter caseAdapter = new JiraAdapter();
            caseAdapter.SyncSalesforceToJira(caseNoList);

            this.btnSyncSalesforceToJira.Enabled = true;
        }

        private void btnSendOutCaseSummary_Click(object sender, EventArgs e)
        {
            // bool ReportService.SendOutDailyReviewedCaseReport(List<string> caseNos)
        }

        private void btnSendOutClosedCases_Click(object sender, EventArgs e)
        {
            // bool ReportService.SendOutClosedCaseReport(List<string> caseNos)
        }

        private List<string> SplitCaseNoList(string caseNoString)
        {
            List<string> caseNoList = new List<string>();
            string caseIDs = caseNoString.Replace(",,", ",");

            if (String.IsNullOrEmpty(caseIDs) || caseIDs.Trim().Length == 0) return caseNoList;

            string[] caseIDArray = caseIDs.Split(',');
            Regex reg = new Regex(@"\d{2}ACC-\d{5}");
            foreach (string caseId in caseIDArray)
            {
                if (reg.IsMatch(caseId))
                {
                    if (!caseNoList.Contains(caseId.Trim()))
                    {
                        caseNoList.Add(caseId.Trim());
                    }
                }
                else
                {
                    if (caseId.Trim().Length == 0)
                    {
                        continue;
                    }
                    else
                    {
                        // Skip
                        //throw new Exception($"Invalid Case NO: {caseId}");
                    }
                }
            }

            return caseNoList;
        }
    }
}
