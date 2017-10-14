using System.ServiceModel;

namespace SmartEngineer.Service
{
    [ServiceContract]
    public interface IJiraServiceForDatabase
    {
        [OperationContract]
        string GetDBTicket(string sfNo);

        //[OperationContract]
        //void SubmitDBTicket(string jiraKey, DBTicket ticket);
    }
}
