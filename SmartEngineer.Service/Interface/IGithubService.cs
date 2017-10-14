using System.ServiceModel;

namespace SmartEngineer.Service
{
    [ServiceContract]
    public interface IGithubService
    {
        [OperationContract]
        void DoWork();
    }
}
