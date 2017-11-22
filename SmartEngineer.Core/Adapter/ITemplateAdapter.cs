using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace SmartEngineer.Core.Adapter
{
    public interface ITemplateAdapter
    {
        string RenderEmailBody(string templateKey);

        string RenderEmailBody(string templateKey, dynamic model);
    }
}
