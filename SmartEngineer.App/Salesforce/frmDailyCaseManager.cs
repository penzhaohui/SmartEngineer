using SmartEngineer.Notification;
using SmartEngineer.ServiceClient.Adapters;
using System;
using System.Collections.Generic;
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
            throw new NotImplementedException();
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
            // List<IssueInfo> JiraServiceForENGSupp.GetIssuesByStatuses(List<string> statuses)
        }

        private void btnPullDetailedInfo_Click(object sender, EventArgs e)
        {
            this.btnPullDetailedInfo.Enabled = false;

            string caseIDs = this.txtInputCaseNOs.Text.Replace(",,", ",");
            List<string> caseNoList = new List<string>();

            if (!String.IsNullOrEmpty(caseIDs) && caseIDs.Trim().Length > 0)
            {
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
                            this.btnPullDetailedInfo.Enabled = true;
                            return;
                        }
                    }
                }

                ICaseAdapter caseAdapter = new CaseAdapter();
                dgvCaseList.AutoGenerateColumns = false;
                dgvCaseList.DataSource = caseAdapter.PullDetailedCaseInfo(caseNoList);
            }

            this.btnPullDetailedInfo.Enabled = true;
        }

        private void btnSyncSalesforceToJira_Click(object sender, EventArgs e)
        {
            // bool JiraServiceForENGSupp.ImportCaseNOs(List<string> caseNOs)
        }

        private void btnSendOutCaseSummary_Click(object sender, EventArgs e)
        {
            // bool ReportService.SendOutDailyReviewedCaseReport(List<string> caseNos)
        }

        private void btnSendOutClosedCases_Click(object sender, EventArgs e)
        {
            // bool ReportService.SendOutClosedCaseReport(List<string> caseNos)
        }
    }
}
