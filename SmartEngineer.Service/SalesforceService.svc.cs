using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using SmartEngineer.Core.Models;
using SmartEngineer.Core.Adapter;

namespace SmartEngineer.Service
{
    public class SalesforceService : ISalesforceService
    {
        private static readonly ISalesforceAdapter salesforceAdapter = new SalesforceAdapter();
        private static readonly ISalesforceAdapterV2 salesforceAdapterV2 = new SalesforceAdapterV2();
        private static readonly IJiraAdapter jiraAdapter = new JiraAdapter();

        public int GetCaseCommentCount(DateTime from, DateTime to)
        {
            throw new NotImplementedException();
        }

        public List<CaseInfo> GetCasesByCaseNOs(List<string> caseNOs)
        {
            List<CaseInfo> caseList = new List<CaseInfo>();
            
            List<string> unStoredCaseNoList = new List<string>();
            foreach (string caseNo in caseNOs)
            {
                if (!salesforceAdapterV2.IsExistsLocalCase(caseNo))
                {
                    unStoredCaseNoList.Add(caseNo);
                }
            }
            
            salesforceAdapterV2.BatchStoreCaseInfoToLocalSync(unStoredCaseNoList);

            IList<AccelaCase> engineerCases = salesforceAdapterV2.PullCasesByCaseNos(unStoredCaseNoList);
            foreach (AccelaCase engineerCase in engineerCases)
            {
                caseNOs.Remove(engineerCase.CaseNumber);
                CaseInfo caseInfo = new CaseInfo();
                caseInfo.Initialize(engineerCase);
                caseList.Add(caseInfo);
            }

            List<CaseInfo> localCaseList = salesforceAdapterV2.GetCaseInfoByCaseNos(caseNOs);
            foreach (CaseInfo localCase in localCaseList)
            {
                if (!unStoredCaseNoList.Contains(localCase.CaseNumber))
                {
                    caseList.Add(localCase);
                }
            }

            return caseList;
        }

        public List<string> GetCommentedCaseList(DateTime start, DateTime end)
        {
            // 1. Pull case data from salesforce
            // 2. Check if it is already stored locally
            //    2.1 Yes, update it only
            //    2.2 No, store it into local database dump and jira
            // 3. Return the commented case list    
            List<string> commentedCaseList = new List<string>();

            List<string> processedCaseNos = salesforceAdapterV2.GetProcessedCaseNOs(start, end, "Accela Support Team");
            List<CaseInfo> caseInfoList = salesforceAdapterV2.GetCaseInfoByCaseNos(processedCaseNos);
            foreach (CaseInfo caseInfo in caseInfoList)
            {
                processedCaseNos.Remove(caseInfo.CaseNumber);

                IList<AccelaCaseComment> caseComments = salesforceAdapterV2.PullCaseCommentsByParentID(caseInfo.CaseID, "00560000003Wzud", start, end);
                if (caseComments.Count > 0)
                {
                    commentedCaseList.Add(caseInfo.CaseNumber);
                }
            }

            IList<AccelaCase> accelaCaseList = salesforceAdapterV2.PullCasesByCaseNos(processedCaseNos);
            foreach (AccelaCase accelaCase in accelaCaseList)
            {
                IList<AccelaCaseComment> caseComments = salesforceAdapterV2.PullCaseCommentsByParentID(accelaCase.Id, "00560000003Wzud", start, end);
                if (caseComments.Count > 0)
                {
                    commentedCaseList.Add(accelaCase.CaseNumber);
                }
            }

            // Update the commented case in local database
            salesforceAdapterV2.BatchStoreCaseInfoToLocalSync(commentedCaseList);

            return commentedCaseList;
        }

        public List<string> GetNewCasesList()
        {
            // 1. Pull case data from Salesforce
            // 2. Check if it is stored locally
            //    2.1 Yes, update it locally only
            //    2.2 No, store it locally and return case info
            // 3. Return the new engineer case list

            List<string> newCaseList = new List<string>();

            IList<AccelaCase> engineerCases = salesforceAdapterV2.QueryCasesByEngineerQueue("Engineer");

            if (engineerCases.Count == 0) return newCaseList;

            List<string> unStoredCaseNoList = new List<string>();
            List<string> caseNos = new List<string>();
            foreach (AccelaCase caseInfo in engineerCases)
            {
                caseNos.Add(caseInfo.CaseNumber);

                if (!salesforceAdapterV2.IsExistsLocalCase(caseInfo.CaseNumber))
                {
                    unStoredCaseNoList.Add(caseInfo.CaseNumber);
                }
            }

            newCaseList = jiraAdapter.GetUnimportedCases(caseNos);
           
            salesforceAdapterV2.BatchStoreCaseInfoToLocalSync(unStoredCaseNoList);

            return newCaseList;
        }

        private void ImportAccelaCaseToLocalAndJira(AccelaCase caseInfo, string jiraAccount, string jiraPassword)
        {
            if (salesforceAdapter.IsExistsLocalCase(caseInfo.CaseNumber))
            {
                salesforceAdapter.UpdateLocalCaseInfo(caseInfo);
            }
            else
            {
                salesforceAdapter.StoreCaseInfoToLocal(caseInfo);
                jiraAdapter.CreateIssue("ENGSUPP", "Case", null, jiraAccount, jiraPassword);
            }

            salesforceAdapter.AppendCaseAttachmentToLocalCase();
            salesforceAdapter.AppendCaseCommentToLocaCase();
        }

        public List<CaseInfo> GetProcessedCase(DateTime from, DateTime to, List<string> sfAccounts)
        {
            throw new NotImplementedException();
        }

        public int GetReviewedCaseCount(DateTime from, DateTime to)
        {
            throw new NotImplementedException();
        }

        /*
        public int GetReviewedCaseCount(DateTime workday)
        {
            throw new NotImplementedException();
        }
        */

        public int GetTotalNewCaseCount()
        {
            throw new NotImplementedException();
        }
    }
}
