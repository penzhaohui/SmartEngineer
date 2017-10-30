using SmartEngineer.Core.Adapter;
using SmartEngineer.Core.DAOs;
using SmartEngineer.Core.Models;
using SmartEngineer.Framework.Context;
using Xunit;

namespace SmartEngineer.Core.Test.Adapter
{
    public class AccountAdapterTest
    {
        private static IAccountAdapter AccountAdapter = new AccountAdapter();
        private static AccountDAO<Account> AccountDAO = new AccountDAO<Account>();

        [Fact]        
        public void TestAccessToken()
        {
            SmartContext.TenantID = "Missionsky";
            Account initAccount = AccountDAO.GetEntityByID<int>(1);

            string accessToken = AccountAdapter.CreateAccessToken(initAccount);
            Assert.NotNull(accessToken);

            bool isValid = AccountAdapter.ValidateToken(accessToken);
            Assert.True(isValid);

            Account newAccount = AccountAdapter.GetAccountProfile(accessToken);
            Assert.Equal(initAccount.UserName, newAccount.UserName);

            AccountAdapter.DisableAccessToken(accessToken);
            Account newAccount2 = AccountAdapter.GetAccountProfile(accessToken);
            Assert.Null(newAccount2);
        }
    }
}
