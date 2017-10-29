using log4net;
using SmartEngineer.Common;
using SmartEngineer.Framework.Logger;
using SmartEngineer.ServiceClient.JiraServiceForENGSupp;
using SmartEngineer.ServiceClient.SalesforceService;
using System;
using System.Collections.Generic;
using System.Data;

namespace SmartEngineer.ServiceClient.Adapters
{
    public class CaseAdapter : ICaseAdapter
    {
        /// <summary>
        /// Logger object.
        /// </summary>
        private static readonly ILog Logger = LogFactory.Instance.GetLogger(typeof(CaseAdapter));

        public List<string> GetCommentedCasesForToday()
        {
            List<string> caseNOList = new List<string>();            

            var chinaCurrentTime = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById("China Standard Time"));
            var start = DateTime.UtcNow.AddHours(-chinaCurrentTime.Hour);
            var end = DateTime.UtcNow.AddHours(1);

            SalesforceServiceClient client = WSFactory.Instance.GetWCFClient<SalesforceServiceClient, ISalesforceService>();
            string[] caseNOs = client.GetCommentedCaseList(start, end);

            caseNOList.AddRange(caseNOs);

            return caseNOList;
        }

        public List<string> GetNewCasesForToday()
        {
            List<string> caseNOs = new List<string>();

            SalesforceServiceClient client = WSFactory.Instance.GetWCFClient<SalesforceServiceClient, ISalesforceService>();
            caseNOs.AddRange(client.GetNewCasesList());
            return caseNOs;
        }

        public List<string> GetPendingCasesForToday()
        {
            throw new NotImplementedException();
        }

        public DataTable PullDetailedCaseInfo(List<string> caseNos)
        {
            DataTable table = new DataTable("Case List");           
            table.Columns.Add("No", typeof(int));
            table.Columns.Add("Product", typeof(string));
            table.Columns.Add("CaseID", typeof(string));
            table.Columns.Add("CaseNo", typeof(string));            
            table.Columns.Add("Serverity", typeof(string));
            table.Columns.Add("Version", typeof(string));
            table.Columns.Add("CaseType", typeof(string));
            table.Columns.Add("Customer", typeof(string));
            table.Columns.Add("Origin", typeof(string));
            table.Columns.Add("OpenDate", typeof(string));
            table.Columns.Add("Summary", typeof(string));
            table.Columns.Add("LastReviewer", typeof(string));
            table.Columns.Add("CommentCount", typeof(string));
            table.Columns.Add("CaseOwner", typeof(string));
            table.Columns.Add("CaseStatus", typeof(string));
            table.Columns.Add("JiraKey", typeof(string));
            table.Columns.Add("JiraStatus", typeof(string));
            table.Columns.Add("JiraNextStatus", typeof(string));
                       

            JiraServiceForENGSuppClient jiraServiceForENGSuppClient = WSFactory.Instance.GetWCFClient<JiraServiceForENGSuppClient, IJiraServiceForENGSupp>();
            var issueList = jiraServiceForENGSuppClient.GetIssuesByCaseNos(caseNos.ToArray());

            Dictionary<string, List<JiraIssue>> JiraIssueMapper = new Dictionary<string, List<JiraIssue>>();
            List<JiraIssue> jiraIssues = null;
            foreach (JiraIssue issueInfo in issueList)
            {
                if (!JiraIssueMapper.ContainsKey(issueInfo.CaseNumber))
                {
                    JiraIssueMapper.Add(issueInfo.CaseNumber, new List<JiraIssue>());
                }

                jiraIssues = JiraIssueMapper[issueInfo.CaseNumber];
                jiraIssues.Add(issueInfo);
                JiraIssueMapper[issueInfo.CaseNumber] = jiraIssues;
            }

            SalesforceServiceClient salesforceServiceClient = WSFactory.Instance.GetWCFClient<SalesforceServiceClient, ISalesforceService>();
            var caseList = salesforceServiceClient.GetCasesByCaseNOs(caseNos.ToArray());

            int index = 1;
            foreach (CaseInfo caseInfo in caseList)
            {
                if (JiraIssueMapper.ContainsKey(caseInfo.CaseNumber))
                {
                    jiraIssues = JiraIssueMapper[caseInfo.CaseNumber];
                    foreach (JiraIssue jiraIssue in jiraIssues)
                    {
                        DataRow row = table.NewRow();
                        row["No"] = index;
                        row["Product"] = caseInfo.Product;
                        row["CaseID"] = caseInfo.CaseID;
                        row["CaseNo"] = caseInfo.CaseNumber;
                        row["Serverity"] = caseInfo.Priority;
                        row["Version"] = caseInfo.CurrentVersion;
                        row["CaseType"] = caseInfo.CaseType;
                        row["Customer"] = (String.IsNullOrEmpty(caseInfo.AccountName) || String.IsNullOrWhiteSpace(caseInfo.AccountName) ? caseInfo.CustomerName : caseInfo.AccountName);
                        row["Origin"] = caseInfo.Origin;
                        row["OpenDate"] = caseInfo.CreatedDate.ToShortDateString();
                        row["Summary"] = caseInfo.Subject;
                        row["LastReviewer"] = caseInfo.LastCommentAddedBy;
                        //row["CommentCount"] = ;
                        row["CaseOwner"] = caseInfo.CaseOwner;
                        row["CaseStatus"] = caseInfo.Status;
                        row["JiraKey"] = jiraIssue.JiraKey;
                        row["JiraStatus"] = jiraIssue.Status;
                        row["JiraNextStatus"] = jiraIssue.Status;
                        table.Rows.Add(row);
                    }
                }
                else
                {
                    DataRow row = table.NewRow();
                    row["No"] = index;
                    row["Product"] = caseInfo.Product;
                    row["CaseID"] = caseInfo.CaseID;
                    row["CaseNo"] = caseInfo.CaseNumber;
                    row["Serverity"] = caseInfo.Priority;
                    row["Version"] = caseInfo.CurrentVersion;
                    row["CaseType"] = caseInfo.CaseType;
                    row["Customer"] = (String.IsNullOrEmpty(caseInfo.AccountName) || String.IsNullOrWhiteSpace(caseInfo.AccountName) ? caseInfo.CustomerName : caseInfo.AccountName);
                    row["Origin"] = caseInfo.Origin;
                    row["OpenDate"] = caseInfo.CreatedDate.ToShortDateString();
                    row["Summary"] = caseInfo.Subject;
                    row["LastReviewer"] = caseInfo.LastCommentAddedBy;
                    //row["CommentCount"] = ;
                    row["CaseOwner"] = caseInfo.CaseOwner;
                    row["CaseStatus"] = caseInfo.Status;
                    table.Rows.Add(row);
                }

                index++;
            }

            return table;
        }
    }
}
