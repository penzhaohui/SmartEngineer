using SmartEngineer.Core.DAO;
using SmartEngineer.Core.DAOs;
using SmartEngineer.Core.Models;
using SmartEngineer.Framework.Context;
using System;

namespace SmartEngineer.Core.Adapter
{
    public class AccountAdapter : IAccountAdapter
    {
        private static readonly IAccountSessionDAO<AccountSession> AccountSessionDAO = new AccountSessionDAO<AccountSession>();

        public string CreateAccessToken(Account account)
        {
            AccountSession session = new AccountSession();
            session.TenantCode = SmartContext.TenantID;
            session.UserID = account.ID;
            session.UserName = account.UserName;
            // https://msdn.microsoft.com/zh-cn/library/97af8hh4.aspx
            session.AccessToken = Guid.NewGuid().ToString("N");
            session.CreatedTime = DateTime.Now;
            session.ExpiredTime = DateTime.Now.AddHours(1);
            session.Active = true;

            AccountSessionDAO.Insert(session);

            return session.AccessToken;
        }

        public void DisableAccessToken(string accessToken)
        {
            AccountSession session = new AccountSession();
            session.TenantCode = SmartContext.TenantID;
            session.AccessToken = accessToken;
            session.ExpiredTime = DateTime.Now;
            session.Active = false;

            AccountSessionDAO.Update(session);
        }

        public Account GetAccountProfile(string accessToken)
        {
            AccountSession session = new AccountSession();
            session.TenantCode = SmartContext.TenantID;
            session.AccessToken = accessToken;

            AccountSession result = AccountSessionDAO.GetEntity(session);

            Account account = null;
            if (result.Active)
            {
                account = new Account();
                account.UserName = result.UserName;
                account.ID = result.UserID;
            }

            return account;
        }

        public bool ValidateToken(string accessToken)
        {
            AccountSession session = new AccountSession();
            session.TenantCode = SmartContext.TenantID;
            session.AccessToken = accessToken;

            return AccountSessionDAO.IsExist(session);
        }
    }
}
