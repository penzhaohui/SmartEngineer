using SmartEngineer.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SmartEngineer.Service
{
    [ServiceContract]
    public interface IDatabaseService
    {
        [OperationContract]
        List<DBConnection> GetDBConnections(string customer);

        [OperationContract]
        bool PingDBConnection(string connectionId);
        
        [OperationContract]
        bool ResetAAPassword(string connectionId);

        [OperationContract]
        bool ResetAASequence(string connectionId);

        [OperationContract]
        bool ResetAAURLs(string connectionId);

        [OperationContract]
        DBInfo GetDetailedConnectionInfo(string connectionId);
    }
}
