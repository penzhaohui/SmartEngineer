using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SmartEngineer.Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IReportService" in both code and config file together.
    [ServiceContract]
    public interface IReportService
    {
        [OperationContract]
        void SendOutDailyCaseReport();

        [OperationContract]
        void SendOutDailyCaseCommentReport();

        [OperationContract]
        void SendOutClosedCaseReport();

        [OperationContract]
        void SendOutWeeklyCaseReport();
    }
}
