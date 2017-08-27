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
                }
            }
            else
            {
            }

            return accessToken;
        }

        void IAccountService.Logout(string accessToken)
        {
            throw new NotImplementedException();
        }

        bool IAccountService.ValidateToken(string accessToken)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
