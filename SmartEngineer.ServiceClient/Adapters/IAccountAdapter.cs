using SmartEngineer.ServiceClient.AccountService;

namespace SmartEngineer.ServiceClient.Adapters
{
    public interface IAccountAdapter
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
        string Login(AccountType accountType, string userName, string Password);

        /// <summary>
        /// logout user
        /// Ref: http://www.cnblogs.com/anyihen/p/5557984.html
        /// </summary>
        /// <param name="token">access token</param>
        void Logout(string accessToken);

        /// <summary>
        /// validate access token
        /// </summary>
        /// <param name="accessToken">access token</param>
        /// <returns></returns>
        bool ValidateToken(string accessToken);

        Account GetAccountProfile(string accessToken);
    }
}
