using SmartEngineer.Core.Adapter;
using SmartEngineer.Core.Models;
using System;
using System.Collections.Generic;

namespace SmartEngineer.Service
{
    public class SalesforceService : ISalesforceService
    {
        public ISalesforceAdapterV2 SalesforceAdapter;
        public IJiraAdapter JiraAdapter;

        public SalesforceService() { }

        public SalesforceService(ISalesforceAdapterV2 salesforceAdapter, IJiraAdapter jiraAdapter)
        {
            SalesforceAdapter = salesforceAdapter;
            JiraAdapter = jiraAdapter;
        }

        public List<CaseInfo> GetCasesByCaseNOs(List<string> caseNOs)
        {
            List<CaseInfo> caseList = new List<CaseInfo>();
            
            List<string> unStoredCaseNoList = new List<string>();
            foreach (string caseNo in caseNOs)
            {
                if (!SalesforceAdapter.IsExistsLocalCase(caseNo))
                {
                    unStoredCaseNoList.Add(caseNo);
                }
            }
            
            SalesforceAdapter.BatchStoreCaseInfoToLocalSync(unStoredCaseNoList);

            IList<AccelaCase> engineerCases = SalesforceAdapter.PullCasesByCaseNos(unStoredCaseNoList);
            foreach (AccelaCase engineerCase in engineerCases)
            {
                caseNOs.Remove(engineerCase.CaseNumber);
                CaseInfo caseInfo = new CaseInfo();
                caseInfo.Initialize(engineerCase);
                caseList.Add(caseInfo);
            }

            List<CaseInfo> localCaseList = SalesforceAdapter.GetCaseInfoByCaseNos(caseNOs);
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

            List<string> processedCaseNos = SalesforceAdapter.GetProcessedCaseNOs(start, end, "status", "Accela Support Team");
            List<CaseInfo> caseInfoList = SalesforceAdapter.GetCaseInfoByCaseNos(processedCaseNos);
            foreach (CaseInfo caseInfo in caseInfoList)
            {
                processedCaseNos.Remove(caseInfo.CaseNumber);

                IList<AccelaCaseComment> caseComments = SalesforceAdapter.PullCaseCommentsByParentID(caseInfo.CaseID, "00560000003Wzud", start, end);
                if (caseComments.Count > 0)
                {
                    commentedCaseList.Add(caseInfo.CaseNumber);
                }
            }

            IList<AccelaCase> accelaCaseList = SalesforceAdapter.PullCasesByCaseNos(processedCaseNos);
            foreach (AccelaCase accelaCase in accelaCaseList)
            {
                IList<AccelaCaseComment> caseComments = SalesforceAdapter.PullCaseCommentsByParentID(accelaCase.Id, "00560000003Wzud", start, end);
                if (caseComments.Count > 0)
                {
                    commentedCaseList.Add(accelaCase.CaseNumber);
                }
            }

            // Update the commented case in local database
            SalesforceAdapter.BatchStoreCaseInfoToLocalSync(commentedCaseList);

            return commentedCaseList;
        }

        public List<string> GetProductionBugList(DateTime start, DateTime end)
        {
            // 1. Get those cases with some change on Engineer Status field
            List<string> processedCaseNos = SalesforceAdapter.GetProcessedCaseNOs(start, end, "Engineering_Status__c", null);

            // 2. Check if they are real producton bug
            if (processedCaseNos.Count > 0)
            {
                IList<AccelaCase> engineerCases = SalesforceAdapter.PullCasesByCaseNos(processedCaseNos);
                foreach (AccelaCase engineerCase in engineerCases)
                {
                    if (String.IsNullOrEmpty(engineerCase.BZID))
                    {
                        processedCaseNos.Remove(engineerCase.CaseNumber);
                    }
                }
            }

            return processedCaseNos;
        }

        public List<string> GetNewCasesList()
        {
            // 1. Pull case data from Salesforce
            // 2. Check if it is stored locally
            //    2.1 Yes, update it locally only
            //    2.2 No, store it locally and return case info
            // 3. Return the new engineer case list

            List<string> newCaseList = new List<string>();

            IList<AccelaCase> engineerCases = SalesforceAdapter.QueryCasesByEngineerQueue("Engineer");

            if (engineerCases.Count == 0) return newCaseList;

            List<string> unStoredCaseNoList = new List<string>();
            List<string> caseNos = new List<string>();
            foreach (AccelaCase caseInfo in engineerCases)
            {
                caseNos.Add(caseInfo.CaseNumber);

                if (!SalesforceAdapter.IsExistsLocalCase(caseInfo.CaseNumber))
                {
                    unStoredCaseNoList.Add(caseInfo.CaseNumber);
                }
            }

            newCaseList = JiraAdapter.GetUnimportedCases(caseNos);
           
            SalesforceAdapter.BatchStoreCaseInfoToLocalSync(unStoredCaseNoList);

            return newCaseList;
        }

        public List<string> GetEngineerCasesList()
        {
            List<string> newCaseList = new List<string>();

            IList<AccelaCase> engineerCases = SalesforceAdapter.QueryCasesByEngineerQueue("Engineer");
            foreach (AccelaCase caseInfo in engineerCases)
            {
                newCaseList.Add(caseInfo.CaseNumber);
            }

            return newCaseList;
        }
    }
}
