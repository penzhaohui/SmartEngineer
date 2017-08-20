using log4net;
using SmartEngineer.Common;
using SmartEngineer.Framework.Logger;
using SmartEngineer.ServiceClient.Enums;
using SmartEngineer.ServiceClient.Models;
using SmartEngineer.ServiceClient.Services;
using System;
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
            InstanceContext callbackInstance = new InstanceContext(new AccountServiceCallback());
            AccountServiceClient client = WSFactory.Instance.GetWCFClient<AccountServiceClient, IAccountService>(callbackInstance);
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

    public class AccountServiceCallback : IAccountServiceCallback
    {
        public void ValidateTokenCallback(bool result)
        {
            throw new NotImplementedException();
        }
    }
}
