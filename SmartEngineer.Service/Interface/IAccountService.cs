using SmartEngineer.Core.Models;
using System.ServiceModel;

namespace SmartEngineer.Service
{
    //[ServiceContract(SessionMode = SessionMode.Required, CallbackContract = typeof(IAccountServiceCallback))]
    [ServiceContract]
    public interface IAccountService
    {
        /// <summary>
        /// validate user
        /// 
        /// Note, other login will be forcely logout.
        /// </summary>
        /// <param name="accountType">account type</param>
        /// <param name="userName">user name</param>
        /// <param name="Password">password</param>
        /// <returns>access token</returns>
        [OperationContract]
        string Login(AccountType accountType, string userName, string Password);

        /// <summary>
        /// logout user
        /// Ref: http://www.cnblogs.com/anyihen/p/5557984.html
        /// </summary>
        /// <param name="token">access token</param>
        [OperationContract(IsOneWay = true)]
        void Logout(string accessToken);

        /// <summary>
        /// validate access token
        /// </summary>
        /// <param name="accessToken">access token</param>
        /// <returns></returns>
        [OperationContract]
        bool ValidateToken(string accessToken);

        [OperationContract]
        Account GetAccountProfile(string accessToken);
    }

    public interface IAccountServiceCallback
    {
        [OperationContract(IsOneWay = true)]
        void ValidateTokenCallback(bool result);
    }
}
