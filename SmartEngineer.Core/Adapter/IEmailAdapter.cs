using SmartEmail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace SmartEngineer.Core.Adapter
{
    public interface IEmailAdapter
    {
        IEmailClient GetEmailClientInstance(string emailKey);
    }
}
