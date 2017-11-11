using log4net;
using SmartEngineer.Common;
using SmartEngineer.Framework.Logger;
using SmartEngineer.ServiceClient.AccountService;
using System;
using System.Security.Principal;
using System.ServiceModel;

namespace SmartEngineer.ServiceClient.Adapters
{
    public class AccountAdapter : IAccountAdapter
    {
        /// <summary>
        /// Logger object.
        /// </summary>
        private static readonly ILog Logger = LogFactory.Instance.GetLogger(typeof(AccountAdapter));

        public Account GetAccountProfile(string accessToken)
        {
            throw new NotImplementedException();
        }

        public string Login(AccountType accountType, string userName, string Password)
        {
            Logger.Info("User Name:" + userName);
            System.Console.WriteLine("WindowsIdentity.GetCurrent().Name = " + WindowsIdentity.GetCurrent().Name);
            //InstanceContext callbackInstance = new InstanceContext(null);
            AccountServiceClient client = WSFactory.Instance.GetWCFClient<AccountServiceClient, IAccountService>();
            return client.Login(accountType, userName, Password);
        }

        public void Logout(string accessToken)
        {
            throw new NotImplementedException();
        }

        public bool ValidateToken(string accessToken)
        {
            throw new NotImplementedException();
        }
    }
}
