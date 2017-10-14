using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using SmartEngineer.Core.Models;

namespace SmartEngineer.Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "DatabaseService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select DatabaseService.svc or DatabaseService.svc.cs at the Solution Explorer and start debugging.
    public class DatabaseService : IDatabaseService
    {
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
