using System.ServiceModel;

namespace SmartEngineer.Service
{
    [ServiceContract]
    public interface ITestRailService
    {
        [OperationContract]
        void DoWork();
    }
}
