﻿using SmartEngineer.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmartEngineer.Core.Adapters
{
    public interface IJiraAdapter
    {
        /// <summary>
        /// Validate jira user
        /// </summary>
        /// <param name="userOrEmailAddress">user name or email address</param>
        /// <param name="password">password</param>
        /// <returns>account</returns>
        Account ValidateAccount(string userOrEmailAddress, string password);
    }
}