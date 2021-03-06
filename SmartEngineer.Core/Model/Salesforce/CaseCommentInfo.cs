﻿using SmartEngineer.Core.Adapter;
using System;
using System.Runtime.Serialization;

namespace SmartEngineer.Core.Models
{
    [DataContract]
    public class CaseCommentInfo : BasicDataModel
    {
        public void Initialize(string caseNumber, AccelaCaseComment sfCaseComment)
        {
            this.CommentID = sfCaseComment.CommentId;
            this.CommentBody = sfCaseComment.CommentBody;
            this.CreatedByID = sfCaseComment.CreatedBy.Id;
            this.CreatedByName = sfCaseComment.CreatedBy.Name;
            this.CreatedDateTime = sfCaseComment.CreatedDate;
            this.LastModifiedByID = sfCaseComment.LastModifiedBy.Id;
            this.LastModifiedByName = sfCaseComment.LastModifiedBy.Name;
            this.LastModifiedDateTime = sfCaseComment.LastModifiedDate;
            this.CaseID = sfCaseComment.ParentId;
            this.CaseNumber = caseNumber;
            this.IsPublished = sfCaseComment.IsPublished;
            this.CommentAuthor = GetCommentAuthor();
        }        

        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public string CommentID { get; set; }
        [DataMember]
        public string CommentBody { get; set; }
        [DataMember]
        public string CreatedByID { get; set; }
        [DataMember]
        public string CreatedByName { get; set; }
        [DataMember]
        public DateTime CreatedDateTime { get; set; }
        [DataMember]
        public string LastModifiedByID { get; set; }
        [DataMember]
        public string LastModifiedByName { get; set; }
        [DataMember]
        public DateTime LastModifiedDateTime { get; set; }
        [DataMember]
        public string CaseID { get; set; }
        [DataMember]
        public string CaseNumber { get; set; }
        [DataMember]
        public bool IsPublished { get; set; }
        [DataMember]
        public string CommentAuthor { get; set; }

        private string GetCommentAuthor()
        {
            string author = "";
            
            if (CreatedByName != "Accela Support Team") return LastModifiedByName;
            if (String.IsNullOrEmpty(CommentBody)) return LastModifiedByName;

            CommentBody = CommentBody.Trim();

            IMemberAdapter MemberAdapter = new MemberAdapter();
            var members = MemberAdapter.GetMemberByGroupName("Accela Support Team");
            foreach (Member member in members)
            {
                if (CommentBody.EndsWith(member.FirstName, StringComparison.OrdinalIgnoreCase)
                    || CommentBody.EndsWith($"{member.FirstName}.{member.LastName}", StringComparison.OrdinalIgnoreCase)
                    || CommentBody.EndsWith($"{member.FirstName} {member.LastName}", StringComparison.OrdinalIgnoreCase))
                {
                    author = $"{member.FirstName} {member.LastName}";
                    break;
                }
            }

            return author;
        }
    }
}
