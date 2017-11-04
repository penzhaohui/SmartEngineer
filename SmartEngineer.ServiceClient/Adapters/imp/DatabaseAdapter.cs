using log4net;
using SmartEngineer.Common;
using SmartEngineer.Framework.Logger;
using SmartEngineer.ServiceClient.DatabaseService;
using System.Collections.Generic;

namespace SmartEngineer.ServiceClient.Adapters
{
    public class DatabaseAdapter : IDatabaseAdapter
    {
        /// <summary>
        /// Logger object.
        /// </summary>
        private static readonly ILog Logger = LogFactory.Instance.GetLogger(typeof(CaseAdapter));
        private static readonly DatabaseServiceClient DatabaseServiceClient = WSFactory.Instance.GetWCFClient<DatabaseServiceClient, IDatabaseService>();

        public List<string> GetDBInstances(string ip, string authType, string userName, string password)
        {
            List<string> dbInstances = new List<string>();
            var result = DatabaseServiceClient.GetDBInstances(ip, authType, userName, password);
            return dbInstances;
        }
    }
}
