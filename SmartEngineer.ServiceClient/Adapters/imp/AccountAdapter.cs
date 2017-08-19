using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartEngineer.ServiceClient.Enums;
using SmartEngineer.ServiceClient.Models;
using SmartEngineer.Common;
using SmartEngineer.ServiceClient.Services;
using System.ServiceModel;

namespace SmartEngineer.ServiceClient.Adapters
{
    public class AccountAdapter : IAccountAdapter
    {
        public Account GetAccountProfile(string accessToken)
        {
            throw new NotImplementedException();
        }

        public string Login(AccountType accountType, string userName, string Password)
        {
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
