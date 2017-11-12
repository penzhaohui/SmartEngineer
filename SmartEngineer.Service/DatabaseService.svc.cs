using SmartEngineer.Core.Adapter;
using SmartEngineer.Core.Models;
using System;
using System.Collections.Generic;

namespace SmartEngineer.Service
{
    public class DatabaseService : IDatabaseService
    {
        public IDatabaseAdapter DatabaseAdapter { get; set; }

        public DatabaseService() { }

        public DatabaseService(IDatabaseAdapter databaseAdapter)
        {
            DatabaseAdapter = databaseAdapter;
        }

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
