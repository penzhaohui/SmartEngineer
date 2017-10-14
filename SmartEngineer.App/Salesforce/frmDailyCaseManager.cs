using SmartEngineer.Notification;
using System;
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
            // List<CaseInfo> SalesforceService.GetNewCasesList()
        }

        private void btnGetCommentedCasesFromSalesforce_Click(object sender, EventArgs e)
        {
            // List<CaseInfo> SalesforceService.GetCommentedCasesList()
        }

        private void btnGetPendingCasesFromJira_Click(object sender, EventArgs e)
        {
            // List<IssueInfo> JiraServiceForENGSupp.GetIssuesByStatuses(List<string> statuses)
        }

        private void btnPullDetailedInfo_Click(object sender, EventArgs e)
        {
            // List<CaseInfo> SalesforceService.GetCasesByCaseNOs(List<string> caseNOs)
            // List<IssueInfo> JiraServiceForENGSupp.GetIssuesByCaseNos(List<string> caseNOs)
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
