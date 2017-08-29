﻿using SmartEngineer.Core.Adapter;
using SmartEngineer.Core.Adapters;
using SmartEngineer.Core.Models;
using SmartEngineer.Service.Adapter;
using System;

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
                account = accountAdapter.ValidateAccount(account);
            }

            // Disable other access token associated to the current user                    
            // Generate one access token 
            accountAdapter.DisableAccessToken(account.ID);
            accessToken = accountAdapter.CreateAccessToken(account);

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
