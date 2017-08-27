﻿using log4net;
using SmartEngineer.Core.Adapters;
using SmartEngineer.Core.Models;
using SmartEngineer.Framework.Logger;
using TechTalk.JiraRestClient;

namespace SmartEngineer.Service.Adapter
{
    public class JiraAdapter : IJiraAdapter
    {
        /// <summary>
        /// Logger object.
        /// </summary>
        private static readonly ILog Logger = LogFactory.Instance.GetLogger(typeof(JiraAdapter));

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