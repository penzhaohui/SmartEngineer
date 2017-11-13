using SmartEngineer.Common;
using SmartEngineer.Notification;
using SmartEngineer.ServiceClient.Adapters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace SmartEngineer.Forms
{
    public partial class frmWeeklyCaseManager : Form, IBasicForm
    {
        public frmWeeklyCaseManager()
        {
            InitializeComponent();
        }

        public string FormName => "Weekly Case Management";

        public void InitUserInterface(IShowMessage messager)
        {
            DateTime currentDateTime = DateTimeUtil.GetCurrentDateTime();
            int currentYear = DateTime.Now.Year;
            int currentWeekOfYear = DateTimeUtil.GetWeekOfYear(currentDateTime);

            this.cmbYears.Items.Clear();
            // 初始化日期时间字段
            for (int i = -3; i < 7; i++)
            {
                int year = currentYear + i;
                this.cmbYears.Items.Add(new ListItem(("" + year), year));
                if (currentYear == year) this.cmbYears.SelectedIndex = (i + 3);
            }

            this.cmbWeeks.Items.Clear();
            // 初始化星期字段
            for (int j = 1; j < 52; j++)
            {
                this.cmbWeeks.Items.Add(new ListItem(("" + j), j));
                if (currentWeekOfYear == j) this.cmbWeeks.SelectedIndex = (j-1);
            }

            DateTime monday = DateTime.MinValue;
            DateTime sunday = DateTime.MinValue;
            bool isSuccess = DateTimeUtil.GetDaysOfWeeks(currentYear, currentWeekOfYear, System.Globalization.CalendarWeekRule.FirstDay, out monday, out sunday);
            if (isSuccess)
            {
                ClearAllTextBox();
                this.lblQueryCondition.Text = $"Do query between {monday.ToString("MM/dd/yyyy")} to {sunday.ToString("MM/dd/yyyy")}";
            }
        }

        private void btnPull_Click(object sender, EventArgs e)
        {
            this.btnPull.Enabled = false;

            if (this.cmbYears.SelectedIndex < 0)
            {
                return;
            }

            if (this.cmbWeeks.SelectedIndex < 0)
            {
                return;
            }

            int year = (this.cmbYears.SelectedItem as ListItem).Value;
            int week = (this.cmbWeeks.SelectedItem as ListItem).Value;

            DateTime monday = DateTime.MinValue;
            DateTime sunday = DateTime.MinValue;

            bool isSuccess = DateTimeUtil.GetDaysOfWeeks(year, week, System.Globalization.CalendarWeekRule.FirstDay, out monday, out sunday);
            if (isSuccess)
            {
                ClearAllTextBox();

                IJiraAdapter jiraAdapter = new JiraAdapter();
                ICaseAdapter caseAdapter = new CaseAdapter();

                this.txtNewSFCaseCount.Text = jiraAdapter.GetNewIssues(monday, sunday).Count.ToString();
                this.txtTotalSFCaseCount.Text = caseAdapter.GetEngineerCasesList().Count.ToString();
                this.txtNewProductionBugCount.Text = caseAdapter.GetProductionBugList(monday, sunday).Count.ToString();
                this.txtTotalProductionBugCount.Text = jiraAdapter.GetProductionBugs().Count.ToString();
                this.txtTotalResolvedCaseCount.Text = jiraAdapter.GetResolvedIssues(monday, sunday).Count.ToString();

                this.lblQueryCondition.Text = $"Do query between {monday.ToString("MM/dd/yyyy")} to {sunday.ToString("MM/dd/yyyy")}";
                DateTime tuesday = monday.AddDays(1);
                DateTime wendesday = monday.AddDays(2);
                DateTime thursday = monday.AddDays(3);
                DateTime friday = monday.AddDays(4);
                DateTime saturday = monday.AddDays(5);
                DateTime nextMonday = monday.AddDays(7);

                
                List<string> mondayCaseNoList = caseAdapter.GetCommentedCases(monday, tuesday);
                List<string> tuesdayCaseNoList = caseAdapter.GetCommentedCases(tuesday, wendesday);
                List<string> wendesdayCaseNoList = caseAdapter.GetCommentedCases(wendesday, thursday);
                List<string> thursdayCaseNoList = caseAdapter.GetCommentedCases(thursday, friday);
                List<string> fridayCaseNoList = caseAdapter.GetCommentedCases(friday, saturday);
                List<string> saturdayCaseNoList = caseAdapter.GetCommentedCases(saturday, sunday);
                List<string> sundayCaseNoList = caseAdapter.GetCommentedCases(sunday, nextMonday);

                int mondayCaseCommentCount = mondayCaseNoList.Count;
                int tuesdayCaseCommentCount = tuesdayCaseNoList.Count;
                int wendesdayCaseCommentCount = wendesdayCaseNoList.Count;
                int thursdayCaseCommentCount = thursdayCaseNoList.Count;
                int fridayCaseCommentCount = fridayCaseNoList.Count;
                int saturdayCaseCommentCount = saturdayCaseNoList.Count;
                int sundayCaseCommentCount = sundayCaseNoList.Count;

                this.txtMonday.Text = mondayCaseCommentCount.ToString();               
                this.txtTuesday.Text = tuesdayCaseCommentCount.ToString();
                this.txtWendesday.Text = wendesdayCaseCommentCount.ToString();
                this.txtThursday.Text = thursdayCaseCommentCount.ToString();
                this.txtFriday.Text = fridayCaseCommentCount.ToString();
                this.txtSaturday.Text = saturdayCaseCommentCount.ToString();
                this.txtSunday.Text = sundayCaseCommentCount.ToString();

                this.txtCaseCommentCount.Text = (mondayCaseCommentCount
                                                + tuesdayCaseCommentCount
                                                + wendesdayCaseCommentCount
                                                + thursdayCaseCommentCount
                                                + thursdayCaseCommentCount
                                                + saturdayCaseCommentCount
                                                + sundayCaseCommentCount).ToString();

                List<string> allCaseNoList = mondayCaseNoList;
                allCaseNoList.AddRange(tuesdayCaseNoList.Where(c => !allCaseNoList.Contains(c)).Select(c => c).ToList<string>());
                allCaseNoList.AddRange(wendesdayCaseNoList.Where(c => !allCaseNoList.Contains(c)).Select(c => c).ToList<string>());
                allCaseNoList.AddRange(thursdayCaseNoList.Where(c => !allCaseNoList.Contains(c)).Select(c => c).ToList<string>());
                allCaseNoList.AddRange(fridayCaseNoList.Where(c => !allCaseNoList.Contains(c)).Select(c => c).ToList<string>());
                allCaseNoList.AddRange(saturdayCaseNoList.Where(c => !allCaseNoList.Contains(c)).Select(c => c).ToList<string>());
                allCaseNoList.AddRange(sundayCaseNoList.Where(c => !allCaseNoList.Contains(c)).Select(c => c).ToList<string>());

                this.txtActualCaseCount.Text = allCaseNoList.Count.ToString();
            }

            this.btnPull.Enabled = true;
        }

        private void ClearAllTextBox()
        {
            this.txtNewSFCaseCount.Text = "";
            this.txtTotalSFCaseCount.Text = "";
            this.txtNewProductionBugCount.Text = "";
            this.txtTotalProductionBugCount.Text = "";
            this.txtTotalResolvedCaseCount.Text = "";

            this.txtMonday.Text = "";
            this.txtTuesday.Text = "";
            this.txtWendesday.Text = "";
            this.txtThursday.Text = "";
            this.txtFriday.Text = "";
            this.txtSaturday.Text = "";
            this.txtSunday.Text = "";
            this.txtCaseCommentCount.Text = "";
            this.txtActualCaseCount.Text = "";
        }

        private void btnEmail_Click(object sender, EventArgs e)
        {

        }
    }
}
