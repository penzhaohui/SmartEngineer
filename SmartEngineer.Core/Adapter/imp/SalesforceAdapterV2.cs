using log4net;
using SalesforceSharp;
using SalesforceSharp.Security;
using SmartEngineer.Core.DAOs;
using SmartEngineer.Core.Models;
using SmartEngineer.Framework.Logger;
using System;
using System.Collections.Generic;
using System.Configuration;

namespace SmartEngineer.Core.Adapter
{
    public partial class SalesforceAdapterV2 : ISalesforceAdapterV2
    {
        /// <summary>
        /// Logger object.
        /// </summary>
        private static readonly ILog Logger = LogFactory.Instance.GetLogger(typeof(SalesforceAdapter));
        
        private static readonly string SecurityToken = ConfigurationManager.AppSettings["SecurityToken"];
        private static readonly string ConsumerKey = ConfigurationManager.AppSettings["ConsumerKey"];
        private static readonly string ConsumerSecret = ConfigurationManager.AppSettings["ConsumerSecret"];
        private static readonly string Username = ConfigurationManager.AppSettings["Username"];
        private static readonly string Password = ConfigurationManager.AppSettings["Password"];
        private static readonly string IsSandboxUser = ConfigurationManager.AppSettings["IsSandboxUser"];
        private static SalesforceClient Client = null;

        public SalesforceAdapterV2()
        {
        }

        public static bool CreateAuthenticationClient()
        {
            // all actions should be in a try-catch - i'll just do the authentication one for an example
            try
            {
                var authFlow = new UsernamePasswordAuthenticationFlow(ConsumerKey, ConsumerSecret, Username, Password + SecurityToken);

                Client = new SalesforceClient();               
                Client.Authenticate(authFlow);
            }
            catch (SalesforceException ex)
            {
                Console.WriteLine("Authentication failed: {0} : {1}", ex.Error, ex.Message);
                Client = null;
                return false;
            }

            return true;
        }

        private static List<string> GetSupportedProducts()
        {
            List<string> supportProducts = new List<string>();

            return supportProducts;
        }

        #region External Service

        public IList<AccelaCase> QueryCasesByEngineerQueue(string queueName, int n = 100)
        {
            // 
            string sql = @"select id, CaseNumber, 
                                  case.createdby.name, CreatedDate, case.owner.name, Last_Comment_By__c, Origin, Current_on_Maintenance__c, LastModifiedById, Jira_Issue_URL__c,
                                  case.account.name, customer__r.name, hosted__c, Sensitive_Client__c, contact.id, account.id, contact.Email,  contact.Phone, contact.MobilePhone, contact.Name,
                                  Priority, type, Status, ParentId, Product__c, release_info__c, solution__c, Current_Version__c, targeted_release__c, Patch_Number__c, Blocked__c, Escalated_By__c,
                                  Subject, Description, 
                                  Internal_Type__c, Engineering_Status__c, Engineering_Assignment__c, Engineering_Comment__c, Internal_Severity__c, BZID__c, Issue_Category__c, Dev_LOEE_Confidence__c, Release_Note_Content__c,
                                  Rank_Order__c,
                                  Go_Live_Critical__c, Services_Rank__c ";

            sql += @"      from case 
                            where case.owner.name='engineering'
                            and product__c != 'Springbrook' 
                            and product__c != 'SoftRight' 
                            and product__c != 'Legislative Management' 
                            and product__c != 'Environmental Health'
                            and product__c != 'Kiva' 
                            and product__c != 'GeoTMS'
                            and product__c != 'KVS Standard'
                            and product__c != 'KVS Enterprise' 
                            and product__c != 'PublicStuff' 
                            and product__c != 'Citizen Relationship Management' 
                            and product__c != 'Support Access' ";

            sql += " and (status ='eng new' or status ='eng qa' or status ='qa in progress' or status ='engqa') ";
            sql += " order by createddate desc ";

            // https://developer.salesforce.com/docs/atlas.en-us.soql_sosl.meta/soql_sosl/sforce_api_calls_soql_select_examples.htm
            // https://developer.salesforce.com/docs/atlas.en-us.soql_sosl.meta/soql_sosl/sforce_api_calls_soql_select_offset.htm?search_text=contact
            // SELECT Name, Id FROM Merchandise__c ORDER BY Name LIMIT 20 OFFSET 100

            var cases = new List<AccelaCase>();

            bool isEndNextQuery = false;
            int offset = 0;
            int limit = 50;
            do
            {
                var results = Client.Query<AccelaCase>($" {sql} limit {limit} offset {offset} ");

                if (results.Count > 0)
                {
                    cases.AddRange(results);
                }

                if (results.Count < limit)
                {
                    isEndNextQuery = true;
                }
                else
                {
                    isEndNextQuery = false;
                    offset += results.Count; // Adjust offset position
                }

            } while (!isEndNextQuery);
            
            
            return cases;
        }

        public IList<AccelaCase> QueryCasesByLastModifer(string lastModifier, int n = 100)
        {
            string sql = @"select id, CaseNumber, 
                                  case.createdby.name, CreatedDate, case.owner.name, Last_Comment_By__c, Origin, Current_on_Maintenance__c, LastModifiedById, Jira_Issue_URL__c,
                                  case.account.name, customer__r.name, hosted__c, Sensitive_Client__c, contact.id, account.id, contact.Email,  contact.Phone, contact.MobilePhone, contact.Name,
                                  Priority, type, Status, ParentId, Product__c, release_info__c, solution__c, Current_Version__c, targeted_release__c, Patch_Number__c, Blocked__c, Escalated_By__c,
                                  Subject, Description, 
                                  Internal_Type__c, Engineering_Status__c, Engineering_Assignment__c, Engineering_Comment__c, Internal_Severity__c, BZID__c, Issue_Category__c, Dev_LOEE_Confidence__c, Release_Note_Content__c,
                                  Rank_Order__c,
                                  Go_Live_Critical__c, Services_Rank__c ";

            sql += @"       from case 
                            where case.lastmodifiedby.name = 'Accela Support Team' 
                            and status != 'Dev Released'
                            order by case.lastmodifieddate desc
                            limit " + n;

            var cases = new List<AccelaCase>();
            var results = Client.Query<AccelaCase>(sql);

            return results;
        }

        public IList<AccelaCase> QueryCasesByCaseNos(List<string> caseNos)
        {
            var cases = new List<AccelaCase>();

            string sql = @"select id, CaseNumber, 
                                  case.createdby.name, CreatedDate, case.owner.name, Last_Comment_By__c, Origin, Current_on_Maintenance__c, LastModifiedById, Jira_Issue_URL__c,
                                  case.account.name, customer__r.name, hosted__c, Sensitive_Client__c, contact.id, account.id, contact.Email,  contact.Phone, contact.MobilePhone, contact.Name,
                                  Priority, type, Status, ParentId, Product__c, release_info__c, solution__c, Current_Version__c, targeted_release__c, Patch_Number__c, Blocked__c, Escalated_By__c,
                                  Subject, Description, 
                                  Internal_Type__c, Engineering_Status__c, Engineering_Assignment__c, Engineering_Comment__c, Internal_Severity__c, BZID__c, Issue_Category__c, Dev_LOEE_Confidence__c, Release_Note_Content__c,
                                  Rank_Order__c,
                                  Go_Live_Critical__c, Services_Rank__c ";

            sql += @"       from case  ";
                       
            int offset = 0;
            int limit = 50;            
            int recordCount = caseNos.Count;
            int endIndex = (offset + limit > recordCount ? recordCount : (offset + limit));

            string[] caseNoArray = caseNos.ToArray();
            string condition = "";
            bool isEndNextQuery = false;

            do
            {
                condition = String.Empty;
                for (int i = offset; i < endIndex; i++)
                {
                    if (String.IsNullOrEmpty(condition))
                    {
                        condition += " casenumber='" + caseNoArray[i] + "' ";
                    }
                    else
                    {
                        condition += " OR casenumber='" + caseNoArray[i] + "' ";
                    }
                }

                offset = offset + limit;
                endIndex = (offset + limit > recordCount ? recordCount : (offset + limit));

                var results = Client.Query<AccelaCase>($" {sql} where {condition} ");
                if (results.Count > 0)
                {
                    cases.AddRange(results);
                }

                if (offset >= recordCount)
                {
                    isEndNextQuery = true;
                }

            } while (!isEndNextQuery);
            

            return cases;
        }

        public string CreateCaseComment(NewCaseComment comment)
        {
            return null;
        }

        public IList<CaseComment> GetCaseCommentsByCaseID(string id)
        {
            return null;
        }

        #endregion
    }
}