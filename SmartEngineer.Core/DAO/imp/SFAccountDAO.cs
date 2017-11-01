using SmartEngineer.Core.Models;
using SmartSql;
using SmartSql.Abstractions;
using System.Collections.Generic;
using System;

namespace SmartEngineer.Core.DAOs
{
    public class SFAccountDAO<T> : BaseDAO<T>, ISFAccountDAO<T>
        where T : CaseAccountInfo
    {
        public override string TableName
        {
            get
            {
                return "SFAccount";
            }
        }

        public List<CaseAccountInfo> GetEntitiesByName(List<string> Names)
        {
            List<CaseAccountInfo> caseAccountList = new List<CaseAccountInfo>();

            if (Names == null || Names.Count == 0) return caseAccountList;

            var entities = SQLMapper.Query<CaseAccountInfo>(new RequestContext
            {
                Scope = this.Scope,
                SqlId = "GetEntities",
                Request = new { Name = Names }
            });

            foreach (CaseAccountInfo entity in entities)
            {
                caseAccountList.Add(entity);
            }

            return caseAccountList;
        }

        public List<CaseAccountInfo> GetEntitiesByUserID(List<string> UserIDs)
        {
            List<CaseAccountInfo> caseAccountList = new List<CaseAccountInfo>();

            if (UserIDs == null || UserIDs.Count == 0) return caseAccountList;

            var entities = SQLMapper.Query<CaseAccountInfo>(new RequestContext
            {
                Scope = this.Scope,
                SqlId = "GetEntities",
                Request = new { UserID = UserIDs }
            });

            foreach (CaseAccountInfo entity in entities)
            {
                caseAccountList.Add(entity);
            }

            return caseAccountList;
        }

        public override T Insert(T entity)
        {
            entity.ID = this.NewID();
            base.Insert(entity);

            return entity;
        }
    }
}
