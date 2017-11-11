using SmartEngineer.Core.Adapter;
using SmartEngineer.Core.Models;
using System;
using System.ServiceModel;

namespace SmartEngineer.Service
{
    public class AccountService : IAccountService
    {
        public IJiraAdapter JiraAdapter { get; set; }
        public IAccountAdapter AccountAdapter { get; set; }

        public AccountService(IJiraAdapter jiraAdapter, IAccountAdapter accountAdapter)
        {
            JiraAdapter = jiraAdapter;
            AccountAdapter = accountAdapter;
        }

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
                account = JiraAdapter.ValidateAccount(userName, Password);               
            }
            else
            {
                account = new Account();
                account.UserName = userName;
                account.Password = Password;
                account = AccountAdapter.ValidateAccount(account);
            }

            // Disable other access token associated to the current user                    
            // Generate one access token 
            AccountAdapter.DisableAccessToken(account.ID);
            accessToken = AccountAdapter.CreateAccessToken(account);

            System.Console.WriteLine("ServiceSecurityContext.Current. PrimaryIdentity.Name = " + ServiceSecurityContext.Current.PrimaryIdentity.Name);
            // ServiceSecurityContext.IsAnonymous returns true if the caller is not authenticated
            System.Console.WriteLine("ServiceSecurityContext.Current.IsAnonymous = " + ServiceSecurityContext.Current.IsAnonymous);

            return accessToken;
        }

        void IAccountService.Logout(string accessToken)
        {
            AccountAdapter.DisableAccessToken(accessToken);
        }

        bool IAccountService.ValidateToken(string accessToken)
        {
            return AccountAdapter.ValidateToken(accessToken);
        }

        #endregion
    }
}
