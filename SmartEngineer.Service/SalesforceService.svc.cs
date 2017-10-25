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

            IList<AccelaCase> engineerCases = salesforceAdapterV2.QueryCasesByCaseNos(caseNOs);

            if (engineerCases.Count != 0)
            {
                foreach (AccelaCase engineerCase in engineerCases)
                {
                    CaseInfo caseInfo = new CaseInfo();
                    caseInfo.Initialize(engineerCase);
                    caseList.Add(caseInfo);
                }
            }

            return caseList;
        }

        public List<CaseInfo> GetCommentedCasesList()
        {
            // 1. Pull case data from salesforce
            // 2. Check if it is already stored locally
            //    2.1 Yes, update it only
            //    2.2 No, store it into local database dump and jira
            // 3. Return the commented case list

            List<CaseInfo> commentedCaseList = new List<CaseInfo>();

            // Jira Account comes from session context
            string jiraAccount = "";
            string jiraPassword = "";

            List<AccelaCase> engineerCases = new List<AccelaCase>();
            salesforceAdapter.QueryCasesByLastModifer("Accela Support Team");


            if (engineerCases.Count != 0)
            {
                foreach (AccelaCase caseInfo in engineerCases)
                {
                    ImportAccelaCaseToLocalAndJira(caseInfo, jiraAccount, jiraPassword);
                }
            }

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

            if (engineerCases.Count != 0)
            {
                List<string> unStoredCaseNoList = new List<string>();
                List<string> caseNos = new List<string>();
                foreach(AccelaCase caseInfo in engineerCases)
                {
                    caseNos.Add(caseInfo.CaseNumber);

                    if (!salesforceAdapterV2.IsExistsLocalCase(caseInfo.CaseNumber))
                    {
                        unStoredCaseNoList.Add(caseInfo.CaseNumber);
                    }
                }

                newCaseList = jiraAdapter.GetUnimportedCases(caseNos);

                // If salesforce case is not stored into local database, store it
                // Save case basic information into SFCase
                // Save case comment into SFCaseComments
                // Save case attachment into SFCaseAttachments
                salesforceAdapterV2.BatchStoreCaseInfoToLocalSync(unStoredCaseNoList);
            }

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
