using SmartEngineer.Core.Adapter;
using SmartEngineer.Core.Models;
using System;
using System.ServiceModel;

namespace SmartEngineer.Service
{
    public class AccountService : IAccountService
    {
        private static readonly IJiraAdapter jiraAdapter = new JiraAdapter();
        private static readonly IAccountAdapter accountAdapter = new AccountAdapter();

        #region IAccountService Implemtation

        Account IAccountService.GetAccountProfile(string accessToken)
        {
            throw new NotImplementedException();
        }

        string IAccountService.Login(AccountType accountType, string userName, string Password)
        {
            string accessToken = String.Empty;
            Account account = null;

            if (accountType == AccountType.Jira)
            {
                account = jiraAdapter.ValidateAccount(userName, Password);               
            }
            else
            {
                account = new Account();
                account.UserName = userName;
                account.Password = Password;
                account = accountAdapter.ValidateAccount(account);
            }

            // Disable other access token associated to the current user                    
            // Generate one access token 
            accountAdapter.DisableAccessToken(account.ID);
            accessToken = accountAdapter.CreateAccessToken(account);

            System.Console.WriteLine("ServiceSecurityContext.Current. PrimaryIdentity.Name = " + ServiceSecurityContext.Current.PrimaryIdentity.Name);
            // ServiceSecurityContext.IsAnonymous returns true if the caller is not authenticated
            System.Console.WriteLine("ServiceSecurityContext.Current.IsAnonymous = " + ServiceSecurityContext.Current.IsAnonymous);

            return accessToken;
        }

        void IAccountService.Logout(string accessToken)
        {
            accountAdapter.DisableAccessToken(accessToken);
        }

        bool IAccountService.ValidateToken(string accessToken)
        {
            return accountAdapter.ValidateToken(accessToken);
        }

        #endregion
    }
}
