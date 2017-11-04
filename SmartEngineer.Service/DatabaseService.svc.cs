using SmartEngineer.Core.Adapter;
using SmartEngineer.Core.Models;
using System;
using System.Collections.Generic;

namespace SmartEngineer.Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "DatabaseService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select DatabaseService.svc or DatabaseService.svc.cs at the Solution Explorer and start debugging.
    public class DatabaseService : IDatabaseService
    {
        private static readonly IDatabaseAdapter DatabaseAdapter = new DatabaseAdapter();

        public List<string> GetDBInstances(string ip, string authType, string userName, string password)
        {            
            return DatabaseAdapter.GetDBInstances(ip, authType, userName, password);
        }

        public List<DBConnection> GetDBConnections(string customer)
        {
            throw new NotImplementedException();
        }

        public DBInfo GetDetailedConnectionInfo(string connectionId)
        {
            throw new NotImplementedException();
        }

        public bool PingDBConnection(string connectionId)
        {
            throw new NotImplementedException();
        }

        public bool ResetAAPassword(string connectionId)
        {
            throw new NotImplementedException();
        }

        public bool ResetAASequence(string connectionId)
        {
            throw new NotImplementedException();
        }

        public bool ResetAAURLs(string connectionId)
        {
            throw new NotImplementedException();
        }
    }
}
