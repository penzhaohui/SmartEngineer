using SmartEngineer.Core.DAOs;
using SmartEngineer.Core.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartEngineer.Core.Adapter
{
    public partial class SalesforceAdapterV2 : ISalesforceAdapterV2
    {
        #region Internal Service

        private static readonly IMemberAdapter MemberAdapter = new MemberAdapter();
        private static readonly ISFCaseDAO<CaseInfo> SFCaseDAO = new SFCaseDAO<CaseInfo>();
        private static readonly ISFCaseCommentDAO<CaseCommentInfo> SFCaseCommentDAO = new SFCaseCommentDAO<CaseCommentInfo>();
        private static readonly ISFAccountDAO<CaseAccountInfo> SFAccountDAO = new SFAccountDAO<CaseAccountInfo>();

        public List<CaseInfo> GetCaseInfoByCaseNos(List<string> caseNos)
        {
            List<Member> engineers = MemberAdapter.GetMemberByGroupName("Accela Support Team");
            var entities = SFCaseDAO.GetEntitys(caseNos);
            foreach (CaseInfo entity in entities)
            {
                if (entity.LastEngineerComment == null || entity.LastEngineerComment.Trim().Length == 0)
                {
                    continue;
                }

                entity.LastEngineerComment = entity.LastEngineerComment.Trim();

                if (String.IsNullOrEmpty(entity.LastEngineerReviewer) || entity.LastEngineerReviewer.Trim().Length == 0)
                {
                    foreach (Member engineer in engineers)
                    {
                        if (entity.LastEngineerComment.EndsWith(engineer.Signature, StringComparison.OrdinalIgnoreCase)
                            || entity.LastEngineerComment.EndsWith($"{engineer.FirstName} {engineer.LastName}", StringComparison.OrdinalIgnoreCase)
                            || entity.LastEngineerComment.EndsWith($"{engineer.FirstName}.{engineer.LastName}", StringComparison.OrdinalIgnoreCase))
                        {
                            entity.LastEngineerReviewer = $"{engineer.FirstName} {engineer.LastName}";
                            break;
                        }
                    }
                }
            }

            return entities;
        }

        public List<string> GetUnstoredLocalCases(List<string> caseNos)
        {
            List<string> unstoredCaseNos = new List<string>();

            var caseInfos = SFCaseDAO.GetEntitys(caseNos);

            foreach (CaseInfo caseinfo in caseInfos)
            {
                caseNos.Remove(caseinfo.CaseNumber);
            }

            unstoredCaseNos.AddRange(caseNos);

            return unstoredCaseNos;
        }

        public bool IsExistsLocalCase(string caseNo)
        {
            return SFCaseDAO.IsExist(new { CaseNumber = caseNo });
        }

        public CaseInfo GetCaseInfoByCaseNo(string caseNo)
        {
            return SFCaseDAO.GetEntity(new { CaseNumber = caseNo });
        }

        public int StoreCaseInfoToLocal(CaseInfo caseInfo)
        {
            int ID = 0;

            if (!IsExistsLocalCase(caseInfo.CaseNumber))
            {
                CaseInfo entity = SFCaseDAO.Insert(caseInfo);
                ID = entity.ID;
            }
            else
            {
                SFCaseDAO.Update(caseInfo);
                ID = caseInfo.ID;
            }

            return ID;
        }

        public CaseInfo UpdateCaseInfoToLocal(string caseNo)
        {
            CaseInfo caseInfo = GetCaseInfoByCaseNo(caseNo);

            // If the case is already updated within the past half a day, skip it
            if (DateTime.Now.Subtract(caseInfo.LastUpdateTime).TotalHours < 4) return caseInfo;

            List<string> caseNoList = new List<string>();
            caseNoList.Add(caseNo);

            IList<AccelaCase> caseList = PullCasesByCaseNos(caseNoList);
            if (caseList != null && caseList.Count > 0)
            {
                caseInfo.Initialize(caseList[0]);
                caseInfo.ID = StoreCaseInfoToLocal(caseInfo);                
            }

            return caseInfo;
        }

        // Duplicated to public bool BatchStoreCaseCommentInfoToLocal(List<string> caseNos)
        public bool UpdateCaseCommentInfoToLocal(string caseNo)
        {
            CaseCommentInfo lastCaseCommentInfo = GetLatestCaseCommentByCaseNo(caseNo);
            
            if (lastCaseCommentInfo != null
                && DateTime.Now.Subtract(lastCaseCommentInfo.LastUpdateTime).TotalHours < 4)
            {
                return false;
            }

            CaseInfo caseInfo = GetCaseInfoByCaseNo(caseNo);
            if (lastCaseCommentInfo == null)
            {
                lastCaseCommentInfo = new CaseCommentInfo();
                lastCaseCommentInfo.LastUpdateTime = caseInfo.CreatedDate;
            }

            IList<AccelaCaseComment> comments = PullCaseCommentsByParentID(caseInfo.CaseID, null, lastCaseCommentInfo.LastUpdateTime);

            foreach (AccelaCaseComment comment in comments)
            {
                lastCaseCommentInfo.Initialize(caseNo, comment);
                SFCaseCommentDAO.Insert(lastCaseCommentInfo);
                BatchStoreCaseAccountInfoToLocalSync(comment.CreatedBy);
            } 

            return true;
        }

        public List<CaseCommentInfo> GetCommentInfoByCaseNo(string caseNo)
        {
            return SFCaseCommentDAO.GetEntitiesByCaseNos(new List<string>() { caseNo });
        }

        private CaseCommentInfo GetLatestCaseCommentByCaseNo(string caseNo)
        {
            List<CaseCommentInfo> CaseCommentList = GetCommentInfoByCaseNo(caseNo);

            return CaseCommentList.OrderByDescending(comment => comment.ID).FirstOrDefault();
        }

        public bool BatchStoreCaseInfoToLocal(List<string> caseNos)
        {
            if (caseNos.Count == 0) return true;

            IList<AccelaCase> sfCaseList = PullCasesByCaseNos(caseNos);

            CaseInfo caseInfo = null;

            foreach (AccelaCase sfCase in sfCaseList)
            {
                try
                {
                    caseInfo = new CaseInfo();
                    caseInfo.Initialize(sfCase);
                    StoreCaseInfoToLocal(caseInfo);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Logger.Error($"Encouter one exception while executing the function BatchStoreCaseInfoToLocal, the detailed message {ex.Message}");
                }
            }

            return true;
        }

        public async Task<bool> BatchStoreCaseInfoToLocalSync(List<string> caseNos)
        {
            return await Task.Run(() =>
            {
                try
                {
                    BatchStoreCaseInfoToLocal(caseNos);
                    BatchStoreCaseCommentInfoToLocal(caseNos);
                }
                catch (Exception ex)
                {
                    Logger.Error("Failed to store case infor to local databse", ex);
                }

                return true;
            });
        }

        public bool BatchStoreCaseCommentInfoToLocal(List<string> caseNos)
        {
            if (caseNos.Count == 0) return true;

            List<CaseInfo> caseInfoList = GetCaseInfoByCaseNos(caseNos);
            foreach (CaseInfo caseInfo in caseInfoList)
            {
                string caseId = caseInfo.CaseID;
                string caseNumber = caseInfo.CaseNumber;

                CaseCommentInfo lastCommentInfo = GetLatestCaseCommentByCaseNo(caseNumber);

                // The minimum update interval is 1 hour at least.
                if (lastCommentInfo != null && DateTime.Now.Subtract(lastCommentInfo.LastUpdateTime).TotalHours < 1)
                {
                    continue;
                }

                if (lastCommentInfo == null)
                {
                    lastCommentInfo = new CaseCommentInfo();
                    lastCommentInfo.LastUpdateTime = caseInfo.CreatedDate;
                }
               
                IList<AccelaCaseComment> caseCommentList = PullCaseCommentsByParentID(caseId, null, lastCommentInfo.LastUpdateTime, DateTime.Now);
                foreach (AccelaCaseComment caseComment in caseCommentList)
                {
                    CaseCommentInfo commentInfo = new CaseCommentInfo();
                    commentInfo.Initialize(caseInfo.CaseNumber, caseComment);
                    if (!SFCaseCommentDAO.IsExist(commentInfo))
                    {
                        SFCaseCommentDAO.Insert(commentInfo);
                    }

                    BatchStoreCaseAccountInfoToLocalSync(caseComment.CreatedBy);
                    //BatchStoreCaseAccountInfoToLocalSync(caseComment.LastModifiedBy);
                }
                
            }

            return true;
        }

        private async Task<bool> BatchStoreCaseAccountInfoToLocalSync(AccelaCaseAccount accelaCaseAccount)
        {
            return await Task.Run(() =>
            {
                if (accelaCaseAccount == null) return false;

                try
                {
                    CaseAccountInfo accountInfo = new CaseAccountInfo();
                    accountInfo.Initialize(accelaCaseAccount);

                    if (!SFAccountDAO.IsExist(accountInfo))
                    {
                        SFAccountDAO.Insert(accountInfo);
                    }
                }
                catch (Exception ex)
                {
                    Logger.Error("Failed to store case account to local databse", ex);
                }

                return true;
            });
        }

        #endregion
    }
}