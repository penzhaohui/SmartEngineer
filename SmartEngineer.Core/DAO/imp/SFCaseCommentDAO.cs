using SmartEngineer.Core.Models;
using SmartSql;
using SmartSql.Abstractions;
using System.Collections.Generic;
using System;

namespace SmartEngineer.Core.DAOs
{
    public class SFCaseCommentDAO<T> : BaseDAO<T>, ISFCaseCommentDAO<T>
        where T : CaseCommentInfo
    {
        public override string TableName
        {
            get
            {
                return "SFCaseComment";
            }
        }

        public List<CaseCommentInfo> GetEntitiesByCaseId(List<string> CaseIDs)
        {
            List<CaseCommentInfo> caseCommentList = new List<CaseCommentInfo>();

            if (CaseIDs == null || CaseIDs.Count == 0) return caseCommentList;

            var entities = SQLMapper.Query<CaseCommentInfo>(new RequestContext
            {
                Scope = this.Scope,
                SqlId = "GetEntities",
                Request = new { CaseID = CaseIDs }
            });

            foreach (CaseCommentInfo entity in entities)
            {
                caseCommentList.Add(entity);
            }

            return caseCommentList;
        }

        public List<CaseCommentInfo> GetEntitiesByCaseNos(List<string> CaseNos)
        {
            List<CaseCommentInfo> caseCommentList = new List<CaseCommentInfo>();

            if (CaseNos == null || CaseNos.Count == 0) return caseCommentList;

            var entities = SQLMapper.Query<CaseCommentInfo>(new RequestContext
            {
                Scope = this.Scope,
                SqlId = "GetEntities",
                Request = new { CaseNumber = CaseNos }
            });

            foreach (CaseCommentInfo entity in entities)
            {
                caseCommentList.Add(entity);
            }

            return caseCommentList;
        }

        public List<CaseCommentInfo> GetEntitiesByAuthors(string caseNo, List<string> Authors)
        {
            List<CaseCommentInfo> caseCommentList = new List<CaseCommentInfo>();

            if (caseNo == null || caseNo.Trim().Length == 0
                || Authors == null || Authors.Count == 0)
            {
                return caseCommentList;
            }

            var entities = SQLMapper.Query<CaseCommentInfo>(new RequestContext
            {
                Scope = this.Scope,
                SqlId = "GetEntities",
                Request = new { CaseNumber = caseNo, CommentAuthor = Authors }
            });

            foreach (CaseCommentInfo entity in entities)
            {
                caseCommentList.Add(entity);
            }

            return caseCommentList;
        }

        public override T Insert(T entity)
        {
            entity.ID = this.NewID();
            base.Insert(entity);

            return entity;
        }
    }
}

