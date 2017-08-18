using SmartEngineer.Service.Model;
using TechTalk.JiraRestClient;

namespace SmartEngineer.Service.Adapter
{
    public class JiraAdapter : IJiraAdapter
    {
        public Account ValidateAccount(string userOrEmailAddress, string password)
        {
            Account account = null;

            IJiraClient client = new JiraClient("https://accelaeng.atlassian.net/", userOrEmailAddress, password); // TODO: Need cache every login user's client
            JiraUser user = client.GetMySelf();
            if (user != null)
            {
                account = new Account();
                account.UserName = user.name;
                account.Password = password; // TODO: Need encryption here.
                account.DisplayName = user.displayName;
                account.EmailAddress = user.displayName;
            }

            return account;
        }
    }
}