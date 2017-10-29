using SmartEngineer.Core.DAOs;
using SmartEngineer.Core.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartEngineer.Core.Adapter
{
    public partial class SalesforceAdapterV2 : ISalesforceAdapterV2
    {
        #region Internal Service

        private static readonly ISFCaseDAO<CaseInfo> SFCaseDAO = new SFCaseDAO<CaseInfo>();
        private static readonly ISFCaseCommentDAO<CaseCommentInfo> SFCaseCommentDAO = new SFCaseCommentDAO<CaseCommentInfo>();
        private static readonly ISFAccountDAO<CaseAccountInfo> SFAccountDAO = new SFAccountDAO<CaseAccountInfo>();

        public List<CaseInfo> GetCaseInfoByCaseNos(List<string> caseNos)
        {            
            return SFCaseDAO.GetEntitys(caseNos);
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

        public int StoreCaseInfoToLocal(CaseInfo caseInfo)
        {
            int ID = 0;
            CaseInfo entity = null;

            if (!IsExistsLocalCase(caseInfo.CaseNumber))
            {
                entity = SFCaseDAO.Insert(caseInfo);
                ID = entity.ID;
            }
            else
            {
                ID = SFCaseDAO.Update(caseInfo);
            }

            return ID;
        }

        public bool UpdateLocalCaseInfo(CaseInfo caseInfo)
        {
            return true;
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
                DateTime? lastModifiedDate = (caseInfo.LastModifiedDateTime == null || caseInfo.LastModifiedDateTime == DateTime.MinValue ? caseInfo.CreatedDate : caseInfo.LastModifiedDateTime);

                // The minimum update interval is 1 hour at least.
                if (DateTime.Now.Subtract(lastModifiedDate.Value).TotalHours < 1) continue;

                IList<AccelaCaseComment> caseCommentList = PullCaseCommentsByParentID(caseId, null, lastModifiedDate, DateTime.Now);
                foreach (AccelaCaseComment caseComment in caseCommentList)
                {
                    CaseCommentInfo commentInfo = new CaseCommentInfo();
                    commentInfo.Initialize(caseInfo.CaseNumber, caseComment);
                    SFCaseCommentDAO.Insert(commentInfo);

                    BatchStoreCaseAccountInfoToLocalSync(caseComment.CreatedBy);
                    BatchStoreCaseAccountInfoToLocalSync(caseComment.LastModifiedBy);
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