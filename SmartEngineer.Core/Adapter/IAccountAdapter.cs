using SmartEngineer.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartEngineer.Core.Adapter
{
    public interface IAccountAdapter
    {
        Account ValidateAccount(Account account);

        Account CreateAccount(Account newAccount);

        void DisableAccessToken(int userID);

        string CreateAccessToken(Account account);

        Account GetAccountProfile(string accessToken);

        void DisableAccessToken(string accessToken);

        bool ValidateToken(string accessToken);
    }
}
