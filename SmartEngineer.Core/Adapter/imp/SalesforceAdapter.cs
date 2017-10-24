using log4net;
using Salesforce.Common;
using Salesforce.Force;
using SmartEngineer.Core.Models;
using SmartEngineer.Framework.Logger;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Threading.Tasks;

namespace SmartEngineer.Core.Adapter
{
    public class SalesforceAdapter : ISalesforceAdapter
    {
        /// <summary>
        /// Logger object.
        /// </summary>
        private static readonly ILog Logger = LogFactory.Instance.GetLogger(typeof(SalesforceAdapter));
        
        private static readonly string SecurityToken = ConfigurationManager.AppSettings["SecurityToken"];
        private static readonly string ConsumerKey = ConfigurationManager.AppSettings["ConsumerKey"];
        private static readonly string ConsumerSecret = ConfigurationManager.AppSettings["ConsumerSecret"];
        private static readonly string Username = ConfigurationManager.AppSettings["Username"];
        private static readonly string Password = ConfigurationManager.AppSettings["Password"] + SecurityToken;
        private static readonly string IsSandboxUser = ConfigurationManager.AppSettings["IsSandboxUser"];
        private static IForceClient Client = null;

        public SalesforceAdapter()
        {
        }

        public async static Task<IForceClient> CreateAuthenticationClientAsync()
        {
            var auth = new AuthenticationClient();

            // Authenticate with Salesforce           
            var url = IsSandboxUser.Equals("true", StringComparison.CurrentCultureIgnoreCase)
                ? "https://test.salesforce.com/services/oauth2/token"
                : "https://login.salesforce.com/services/oauth2/token";

            System.Console.WriteLine("Start to connect Salesforce.");

            await auth.UsernamePasswordAsync(ConsumerKey, ConsumerSecret, Username, Password, url);

            System.Console.WriteLine("Connect to Salesforce successfully.");

            Client = new ForceClient(auth.InstanceUrl, auth.AccessToken, auth.ApiVersion);

            return Client;
        }

        private static List<string> GetSupportedProducts()
        {
            List<string> supportProducts = new List<string>();

            return supportProducts;
        }

        #region External Service

        public async Task<List<AccelaCase>> QueryCasesByEngineerQueue(string queueName, int n = 100)
        {
            if (Client == null)
            {
                await CreateAuthenticationClientAsync();
            }

            string sql = @"select id, casenumber, current_version__c, priority, go_live_critical__c, case.account.name, case.owner.name, origin, patch_number__c, subject, ownerid, type, description, createddate, 
                                  case.createdby.name, status, bzid__c, product__c, solution__c, release_info__c, targeted_release__c, customer__r.name ";


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
            sql += " order by createddate desc limit " + n;

            var cases = new List<AccelaCase>();
            var results = await Client.QueryAsync<AccelaCase>(sql);
            var totalSize = results.TotalSize;

            Console.WriteLine("Queried " + totalSize + " records.");

            cases.AddRange(results.Records);

            return cases;
        }

        public async Task<List<AccelaCase>> QueryCasesByLastModifer(string lastModifier, int n = 100)
        {
            string sql = @"select id, casenumber, current_version__c, priority, go_live_critical__c, case.account.name, case.owner.name, origin, patch_number__c, subject, ownerid, type, description, createddate, 
                                  case.createdby.name, status, bzid__c, product__c, solution__c, release_info__c, targeted_release__c, customer__r.name
                            from case 
                            where case.lastmodifiedby.name = 'Accela Support Team' 
                            and status != 'Dev Released'
                            order by case.lastmodifieddate desc
                            limit " + n;

            var cases = new List<AccelaCase>();
            var results = await Client.QueryAsync<AccelaCase>(sql);
            var totalSize = results.TotalSize;

            Console.WriteLine("Queried " + totalSize + " records.");

            cases.AddRange(results.Records);

            return cases;
        }


        public async Task<List<AccelaCase>> QueryCasesByCaseNos(List<string> caseNos)
        {
            string sql = @"select id, casenumber, current_version__c, priority, go_live_critical__c, rank_order__c, services_rank__c, case.account.name, 
                                              case.owner.name, origin, patch_number__c, subject, ownerid, type, description, createddate, 
                                              case.createdby.name, status, internal_type__c, engineering_status__c, bzid__c, product__c, solution__c, release_info__c, targeted_release__c, customer__r.name
                       from case 
                       where ";

            bool isFirstCase = true;
            foreach (string caseNo in caseNos)
            {
                if (isFirstCase)
                {
                    sql += " casenumber='" + caseNo + "' ";
                    isFirstCase = false;
                }
                else
                {
                    sql += " OR casenumber='" + caseNo + "' ";
                }
            }
            sql += ")";

            var cases = new List<AccelaCase>();
            var results = await Client.QueryAsync<AccelaCase>(sql);
            var totalSize = results.TotalSize;

            cases.AddRange(results.Records);

            return cases;
        }

        public async Task<string> CreateCaseComment(NewCaseComment comment)
        {
            var results = await Client.CreateAsync("CaseComment", comment);

            return results;
        }

        public async Task<List<CaseComment>> GetCaseCommentsByCaseID(string id)
        {
            string sql = @"SELECT Id, CommentBody, CreatedById, CreatedDate, IsPublished, LastModifiedById, LastModifiedDate, ParentId
                           from CaseComment
                           WHERE ParentId= '{0}' ";
            sql = String.Format(sql, id);

            var comments = new List<CaseComment>();
            var results = await Client.QueryAllAsync<CaseComment>(sql);
            comments.AddRange(results.Records);

            return comments;
        }

        // select Id, NewValue, OldValue, CreatedDate, CreatedById, CaseId from CaseHistory story where case.CaseNumber = '17ACC-253892'

        #endregion

        #region Internal Service

        public List<CaseInfo> GetCaseInfoByCaseNos(List<string> caseNos)
        {
            return null;
        }

        public List<string> GetUnstoredCaseNo(List<string> caseNos)
        {
            return null;
        }

        public bool IsExistsLocalCase(string caseNo)
        {
            return true;
        }

        public bool StoreCaseInfoToLocal(AccelaCase caseInfo)
        {
            return true;
        }

        public bool UpdateLocalCaseInfo(AccelaCase caseInfo)
        {
            return true;
        }

        public bool AppendCaseCommentToLocaCase()
        {
            return true;
        }

        public bool AppendCaseAttachmentToLocalCase()
        {
            return true;
        }

        #endregion

    }
}