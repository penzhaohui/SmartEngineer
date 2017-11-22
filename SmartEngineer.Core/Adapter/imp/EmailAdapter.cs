﻿using SmartEmail;
using System;
using System.Net.Mail;

namespace SmartEngineer.Core.Adapter
{
    public class EmailAdapter : IEmailAdapter
    {
        public MailClient GetEmailClientInstance(string emailKey)
        {
            // Initialize SMTP client using email key
            // Initialized SMTP 
            MailClient emailClient = new MailClient(true);

            return emailClient;
        }
    }
}
