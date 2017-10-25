﻿using System;
using System.Runtime.Serialization;

namespace SmartEngineer.Core.Models
{
    [DataContract]
    public class CaseInfo
    {
        public void Initialize(AccelaCase sfCase)
        {
            this.CaseType = sfCase.CaseType.Type;
            this.CaseID = sfCase.Id;
            this.CaseNumber = sfCase.CaseNumber;
            this.CreaedBy = sfCase.CreatedBy.Name;
            this.CreatedDate = sfCase.CreatedDate;
            this.CaseOwner = sfCase.Owner.Name;
            this.LastCommentAddedBy = sfCase.LastCommentCreatedBy;
            if (this.LastCommentAddedBy != null)
            {
                int index = sfCase.LastCommentCreatedBy.IndexOf(":");
                this.LastModifiedBy = sfCase.LastCommentCreatedBy.Substring(0, index).Trim();
                this.LastModifiedDateTime = Convert.ToDateTime(sfCase.LastCommentCreatedBy.Substring(index + 1).Trim());
            }
            this.Origin = sfCase.Origin;
            this.CurrentOnMaintenance = sfCase.CurrentOnMaintenance;
            this.JiraIssueURL = sfCase.JiraIssueURL;
            this.AccountName = (sfCase.Account == null ? "" : sfCase.Account.Name);
            this.CustomerName = (sfCase.Customer == null ? "" : sfCase.Customer.Name);
            this.AgencyHosted = "Agency Hosted".Equals(sfCase.Hosted, StringComparison.OrdinalIgnoreCase);
            this.SensitiveClient = sfCase.SensitiveClient;
            this.ContactName = (sfCase.Contact == null ? "" : sfCase.Contact.Name);
            this.ContactEmail = (sfCase.Contact == null ? "" : sfCase.Contact.Email);
            this.ContactPhone = (sfCase.Contact == null ? "" : sfCase.Contact.Phone);
            this.Priority = sfCase.Priority.Split(' ')[1];
            this.IssueType = sfCase.Type;
            this.Status = sfCase.Status;
            this.ParentCase = sfCase.ParentCaseId;
            this.Product = AdjustProductName(sfCase.Product, sfCase.Solution, sfCase.Subject, sfCase.Description);
            this.ReleaseInfo = sfCase.ReleaseInfo;
            this.Solution = sfCase.Solution;
            this.CurrentVersion = sfCase.CurrentVersion;
            this.TargetedRelease = sfCase.TargetedRelease;
            this.PatchNumber = sfCase.PatchNumber;
            this.Blocked = sfCase.Blocked;
            this.EscalatedBy = sfCase.EscalatedBy;
            this.Subject = sfCase.Subject;
            this.Description = sfCase.Description;
            this.EngineeringStatus = sfCase.EngineeringStatus;
            this.InternalSeverity = sfCase.InternalSeverity;
            this.EngineeringAssignment = sfCase.EngineeringAssignment;
            this.EngineeringComment = sfCase.EngineeringComment;
            this.InternalType = sfCase.InternalType;
            this.BZID = sfCase.BZID;
            this.IssueCategory = sfCase.IssueCategory;
            this.DevLOEEConfidence = sfCase.DevLOEEConfidence;
            this.ReleaseNoteContent = sfCase.ReleaseNoteContent;
            this.RankOrder = sfCase.RankOrder;
            this.GoLiveCritical = sfCase.GoLiveCritical;
            this.ServicesRank = sfCase.ServicesRank;
        }

        private string AdjustProductName(string product, string solution, string subject, string description)
        {
            string productName = product;

            if ("AdHoc Reports" == product)
            {
                productName = product;
            }

            if ("Inspector" == product || "Civic Hero" == product || "Code Officer" == product || "Work Crew" == product || "Support Access" == product)
            {
                productName = product;
            }

            if ("Inspector" == solution || "Civic Hero" == solution || "Code Officer" == solution || "Work Crew" == solution || "Support Access" == solution)
            {
                productName = solution;
            }

            if ("Civic Cloud Platform" == product || "Accela Asset Management" == product || "Accela Licensing & Case Management" == product)
            {
                productName = product;
            }

            if ("Standard history conversion" == product)
            {
                productName = product;
            }

            if ("Mobile Office" == solution)
            {
                productName = solution;
            }

            if ("Accela Mobile" == productName)
            {
                if ((subject != null && (subject.ToUpper().Contains("AMO") || subject.ToUpper().Contains("MOBILE OFFICE")))
                    || (description != null && (description.ToUpper().Contains("AMO") || description.ToUpper().Contains("MOBILE OFFICE"))))
                {
                    productName = "Mobile Office";
                }
            }

            return productName;
        }

        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public string CaseType { get; set; }
        [DataMember]
        public string CaseID { get; set; }
        [DataMember]
        public string CaseNumber { get; set; }
        [DataMember]
        public string CreaedBy { get; set; }
        [DataMember]
        public DateTime CreatedDate { get; set; }
        [DataMember]
        public string CaseOwner { get; set; }
        [DataMember]
        public string LastCommentAddedBy { get; set; }
        [DataMember]
        public string LastModifiedBy { get; set; }
        [DataMember]
        public DateTime? LastModifiedDateTime { get; set; }
        [DataMember]
        public string Origin { get; set; }
        [DataMember]
        public bool CurrentOnMaintenance { get; set; }
        [DataMember]
        public string JiraIssueURL { get; set; }
        [DataMember]
        public string AccountName { get; set; }
        [DataMember]
        public string CustomerName { get; set; }
        [DataMember]
        public bool AgencyHosted { get; set; }
        [DataMember]
        public bool SensitiveClient { get; set; }
        [DataMember]
        public string ContactName { get; set; }
        [DataMember]
        public string ContactEmail { get; set; }
        [DataMember]
        public string ContactPhone { get; set; }
        [DataMember]
        public string Priority { get; set; }
        [DataMember]
        public string IssueType { get; set; }
        [DataMember]
        public string Status { get; set; }
        [DataMember]
        public string ParentCase { get; set; }
        [DataMember]
        public string Product { get; set; }
        [DataMember]
        public string ReleaseInfo { get; set; }
        [DataMember]
        public string Solution { get; set; }
        [DataMember]
        public string CurrentVersion { get; set; }
        [DataMember]
        public string TargetedRelease { get; set; }
        [DataMember]
        public string PatchNumber { get; set; }
        [DataMember]
        public bool Blocked { get; set; }
        [DataMember]
        public string EscalatedBy { get; set; }
        [DataMember]
        public string Subject { get; set; }        
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public string EngineeringStatus { get; set; }
        [DataMember]
        public string InternalSeverity { get; set; }
        [DataMember]
        public string EngineeringAssignment { get; set; }
        [DataMember]
        public string EngineeringComment { get; set; }
        [DataMember]
        public string InternalType { get; set; }
        [DataMember]
        public string BZID { get; set; }
        [DataMember]
        public string IssueCategory { get; set; }
        [DataMember]
        public string DevLOEEConfidence { get; set; }
        [DataMember]
        public string ReleaseNoteContent { get; set; }
        [DataMember]
        public string RankOrder { get; set; }
        [DataMember]
        public bool GoLiveCritical { get; set; }
        [DataMember]
        public string ServicesRank { get; set; }
    }
}
