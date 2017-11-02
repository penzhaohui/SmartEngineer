using System;
using System.Collections.Generic;
using TechTalk.JiraRestClient;

namespace SmartEngineer.Core.Models
{
    public static class ModelExtension
    {
        public static Issue ConvertToIssue(this CaseInfo caseInfo)
        {
            Issue issue = new Issue();

            issue.fields.CaseNumber = caseInfo.CaseNumber;
            issue.fields.Summary = caseInfo.Subject;
            issue.fields.Description = caseInfo.Description;
            if (!string.IsNullOrEmpty(caseInfo.CurrentVersion))
            {
                issue.fields.BuildVersion = new List<string>();
                issue.fields.BuildVersion.Add(caseInfo.CurrentVersion);
                issue.fields.SFCurrentVersion = caseInfo.CurrentVersion;
            }
            issue.fields.SFOpenedDateTime = caseInfo.CreatedDate;
            issue.fields.EstimatedEffort = 16;  // hours, default unit
            issue.fields.SFPriority = caseInfo.Priority;
            issue.fields.Priority = new IssuePriority();
            issue.fields.Priority.name = caseInfo.Priority;
            issue.fields.Severity = new IssueSeverity();
            issue.fields.Severity.name = ("High" == caseInfo.Priority ? "Major" : caseInfo.Priority);
            issue.fields.SFProduct = (String.IsNullOrEmpty(caseInfo.Solution) ? caseInfo.Product : caseInfo.Solution);

            // Jira Product List Field
            IssueProduct product = new IssueProduct();
            product.value = caseInfo.Product;
            issue.fields.Product = new List<IssueProduct>();
            issue.fields.Product.Add(product);
          
            issue.fields.SFCustomer = (String.IsNullOrEmpty(caseInfo.AccountName) ? caseInfo.CustomerName : caseInfo.AccountName);
            issue.fields.SFOrigin = new IssueOrigin();
            if ("Delivery".Equals(caseInfo.Origin, StringComparison.CurrentCultureIgnoreCase))
            {
                issue.fields.SFOrigin.value = "Other";
            }
            else
            {
                // To deal with one special case - "Email-MEA"
                issue.fields.SFOrigin.value = (caseInfo.Origin.IndexOf("Email") >= 0) ? "Email" : caseInfo.Origin;
            }
            issue.fields.SFLastModifiedDate = caseInfo.LastModifiedDateTime;
            issue.fields.SFCommentCount = 0;// TO-DO
            issue.fields.SFSalesforceLink = "https://na26.salesforce.com/" + caseInfo.CaseID;

            return issue;
        }

        public static Issue MergeToIssue(this CaseInfo caseInfo, Issue issue)
        {
            issue.fields.CaseNumber = caseInfo.CaseNumber;
            issue.fields.Summary = caseInfo.Subject;
            issue.fields.Description = caseInfo.Description;
            if (!string.IsNullOrEmpty(caseInfo.CurrentVersion))
            {
                if (issue.fields.BuildVersion != null
                    && !issue.fields.BuildVersion.Contains(caseInfo.CurrentVersion))
                {
                    issue.fields.BuildVersion.Add(caseInfo.CurrentVersion);
                }
                issue.fields.SFCurrentVersion = caseInfo.CurrentVersion;
            }

            issue.fields.SFOpenedDateTime = caseInfo.CreatedDate;
            issue.fields.SFPriority = caseInfo.Priority;
            issue.fields.Priority = new IssuePriority();
            issue.fields.Priority.name = caseInfo.Priority;
            issue.fields.Severity = new IssueSeverity();
            issue.fields.Severity.name = ("High" == caseInfo.Priority ? "Major" : caseInfo.Priority);
            issue.fields.SFProduct = (String.IsNullOrEmpty(caseInfo.Solution)  ? caseInfo.Product : caseInfo.Solution);

            // Jira Product List Field
            IssueProduct product = new IssueProduct();
            product.value = caseInfo.Product;
            issue.fields.Product = new List<IssueProduct>();
            issue.fields.Product.Add(product);

            issue.fields.SFCustomer = (String.IsNullOrEmpty(caseInfo.AccountName) ? caseInfo.CustomerName : caseInfo.AccountName);
            issue.fields.SFOrigin = new IssueOrigin();
            if ("Delivery".Equals(caseInfo.Origin, StringComparison.CurrentCultureIgnoreCase))
            {
                issue.fields.SFOrigin.value = "Other";
            }
            else
            {
                // To deal with one special case - "Email-MEA"
                issue.fields.SFOrigin.value = (caseInfo.Origin.IndexOf("Email") >= 0) ? "Email" : caseInfo.Origin;
            }
            issue.fields.SFLastModifiedDate = caseInfo.LastModifiedDateTime;
            issue.fields.SFCommentCount = 0;// TO-DO
            issue.fields.SFSalesforceLink = "https://na26.salesforce.com/" + caseInfo.CaseID;

            issue.fields.Labels = ProcessJiraLabels(issue, caseInfo);

            return issue;
        }

        private static List<string> ProcessJiraLabels(Issue issue, CaseInfo caseInfo)
        {
            List<string> jiraLabelList = issue.fields.Labels;

            if (jiraLabelList == null) jiraLabelList = new List<string>();

            string jiraStatus = issue.fields.Status.name;
            string nextJiraStatus = "";

            #region Label "Missionsky"

            if (jiraLabelList.Contains("Missionsky"))
            {
                jiraLabelList.Remove("Missionsky");
            }

            #endregion

            #region Label "SupportQA"

            if (jiraLabelList.Contains("SupportQA"))
            {
                jiraLabelList.Remove("SupportQA");
            }

            if (caseInfo.Status != null && caseInfo.Status.ToLower().IndexOf("qa") >= 0)
            {
                jiraLabelList.Add("SupportQA");
            }

            #endregion

            #region Label "ENG_BUG_BACKLOG"

            if (!String.IsNullOrEmpty(caseInfo.BZID) && !jiraLabelList.Contains("ENG_BUG_BACKLOG"))
            {
                if ("Development in Progress" == jiraStatus || "Development in Progress" == nextJiraStatus)
                {
                    jiraLabelList.Add("ENG_BUG_BACKLOG");
                }
            }

            if (jiraLabelList.Contains("ENG_BUG_BACKLOG"))
            {
                // If it is already schedued into one version, remove 2 labels such as ENG_BUG_BUCKET and ENG_BUG_BACKLOG
                if (issue.fields.FixVersions != null && issue.fields.FixVersions.Count > 0)
                {
                    jiraLabelList.Remove("ENG_BUG_BACKLOG");
                }

                if ("Resolved".Equals(jiraStatus, StringComparison.InvariantCultureIgnoreCase)
                    || "Closed".Equals(jiraStatus, StringComparison.InvariantCultureIgnoreCase))
                {
                    jiraLabelList.Remove("ENG_BUG_BACKLOG");
                }
            }

            if (jiraLabelList.Contains("ENG_BUG_BUCKET"))
            {
                jiraLabelList.Remove("ENG_BUG_BUCKET");
            }

            if (jiraLabelList.Contains("BUG_BUCKET"))
            {
                jiraLabelList.Remove("BUG_BUCKET");
            }

            #endregion

            #region Label "DB"

            if (jiraLabelList.Contains("DB"))
            {
                if ("Resolved".Equals(jiraStatus, StringComparison.InvariantCultureIgnoreCase)
                                || "Closed".Equals(jiraStatus, StringComparison.InvariantCultureIgnoreCase)
                                || "Development in Progress".Equals(jiraStatus, StringComparison.InvariantCultureIgnoreCase)
                                || "Resolved".Equals(nextJiraStatus, StringComparison.InvariantCultureIgnoreCase)
                                || "Closed".Equals(nextJiraStatus, StringComparison.InvariantCultureIgnoreCase)
                                || "Development in Progress".Equals(nextJiraStatus, StringComparison.InvariantCultureIgnoreCase))
                {

                    jiraLabelList.Remove("DB");
                }
            }

            #endregion

            return jiraLabelList;
        }

        public static bool IsEqualCase(this JiraIssue jiraIssue, CaseInfo caseInfo)
        {
            bool isEqual = true;

            if (caseInfo == null) return false;

            if (jiraIssue.CaseNumber != caseInfo.CaseNumber
                || jiraIssue.Summary != caseInfo.Subject
                || jiraIssue.Description != caseInfo.Description
                || jiraIssue.SFPriority != caseInfo.Priority
                || jiraIssue.SFCurrentVersion != caseInfo.CurrentVersion
                || (jiraIssue.SFCustomer != caseInfo.CustomerName && jiraIssue.SFCustomer != caseInfo.AccountName)
                || (jiraIssue.SFLastModifiedDate != null && !jiraIssue.SFLastModifiedDate.Equals(caseInfo.LastModifiedDateTime))
                //|| (jiraIssue.SFOpenedDateTime != null && !jiraIssue.SFOpenedDateTime.Equals(caseInfo.CreatedDate))
                || jiraIssue.SFOrigin != caseInfo.Origin
                || jiraIssue.SFProduct != caseInfo.Product
                || jiraIssue.SFTargetedRelease != caseInfo.TargetedRelease)
            {
                isEqual = false;
            }

            return isEqual;
        }

        public static bool IsEqualJiraIssue(this CaseInfo caseInfo, JiraIssue jiraIssue)
        {
            if (jiraIssue == null) return false;

            return jiraIssue.IsEqualCase(caseInfo);
        }
    }
}
