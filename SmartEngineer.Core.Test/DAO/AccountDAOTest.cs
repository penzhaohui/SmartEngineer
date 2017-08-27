using Xunit;
using SmartEngineer.Core.DAOs;
using SmartEngineer.Core.Models;
using SmartSql.Abstractions;
using System.Data.SqlClient;

namespace SmartEngineer.Core.Test.DAO
{
    public class AccountDAOTest
    {
        private static AccountDAO<Account> AccountDAO = new AccountDAO<Account>();

        [Fact]
        public void CreateSQLMapperInstance()
        {           
            Assert.NotNull(AccountDAO.SQLMapper);
        }

        [Theory]
        [InlineData("peter.peng@missionsky.com", "peter.peng", "peter.peng@missionsky.com", "Peter Peng")]
        public void CreateAccessToken(string userName, string password, string emailAddress, string displayName)
        {
            Account temp = new Account();
            temp.UserName = userName;
            temp.Password = password;
            temp.EmailAddress = emailAddress;
            temp.DisplayName = displayName;

            if (!AccountDAO.IsExist(temp))
            {
                AccountDAO.Insert(temp);
            }

            AccountDAO.GetEntityByID<int>(2);
            AccountDAO.GetEntity(temp);
        }
    }
}
