using Xunit;
using SmartEngineer.Core.DAOs;
using SmartEngineer.Core.Models;
using SmartSql.Abstractions;
using System.Data.SqlClient;

namespace SmartEngineer.Core.Test.DAO
{
    public class AccountDAOTest
    {
        [Fact]
        public void CreateSQLMapperInstance()
        {
            AccountDAO<Account> AccountDAO = new AccountDAO<Account>();
            Assert.NotNull(AccountDAO.SQLMapper);
        }
    }
}
