using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace SmartEmail.Sample
{
    public class EmailMessage : EmailMessageBase
    {
        public override List<MailMessage> Build()
        {
            List<MailMessage> messages = new List<MailMessage>();
            
            int i = 0;
            foreach (string toMailAddress in toAddresses.Keys)
            {
                MailMessage newMailMessage = new MailMessage();
                newMailMessage.Subject = "[" + (i++) + "] " + message.Subject;
                newMailMessage.SubjectEncoding = message.SubjectEncoding;
                newMailMessage.IsBodyHtml = message.IsBodyHtml;
                newMailMessage.Body = message.Body;
                newMailMessage.BodyEncoding = message.BodyEncoding;
                newMailMessage.Priority = message.Priority;
                newMailMessage.From = message.From;

                newMailMessage.To.Add(new MailAddress(toMailAddress, toAddresses[toMailAddress]));

                foreach (string ccMailAddress in ccAddresses.Keys)
                {
                    newMailMessage.CC.Add(new MailAddress(ccMailAddress, toAddresses[ccMailAddress]));
                }

                foreach (string bccMailAddress in bccAddresses.Keys)
                {
                    newMailMessage.CC.Add(new MailAddress(bccMailAddress, toAddresses[bccMailAddress]));
                }

                foreach (Attachment attachment in message.Attachments)
                {
                    newMailMessage.Attachments.Add(attachment);
                }

                messages.Add(newMailMessage);
            }
            
            return messages;
        }
    }
}
