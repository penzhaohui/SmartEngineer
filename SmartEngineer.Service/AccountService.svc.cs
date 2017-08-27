using SmartEngineer.Core.Adapters;
using SmartEngineer.Core.Models;
using SmartEngineer.Service.Adapter;
using System;

namespace SmartEngineer.Service
{
    public class AccountService : IAccountService
    {
        #region IAccountService Implemtation

        Account IAccountService.GetAccountProfile(string accessToken)
        {
            throw new NotImplementedException();
        }

        string IAccountService.Login(AccountType accountType, string userName, string Password)
        {
            string accessToken = String.Empty;

            if (accountType == AccountType.Jira)
            {
                IJiraAdapter jiraAdapter = new JiraAdapter();
                Account account = jiraAdapter.ValidateAccount(userName, Password);

                if (account != null)
                {
                    // Generate one access token
                    // Disable other access token associated to the current user
                    // Update access token
                }
            }
            else
            {
            }

            return accessToken;
        }

        void IAccountService.Logout(string accessToken)
        {
            // Disable this access token
            throw new NotImplementedException();
        }

        bool IAccountService.ValidateToken(string accessToken)
        {
            // Check if this access token is valid or not
            throw new NotImplementedException();
        }

        #endregion
    }
}
