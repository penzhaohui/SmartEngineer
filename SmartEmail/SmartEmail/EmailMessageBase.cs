using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace SmartEmail
{
    public abstract class EmailMessageBase : IEmailMessage
    {
        protected MailMessage message = new MailMessage();
        protected Dictionary<string, string> toAddresses = new Dictionary<string, string>();
        protected Dictionary<string, string> ccAddresses = new Dictionary<string, string>();
        protected Dictionary<string, string> bccAddresses = new Dictionary<string, string>();        

        /// <summary>
        /// Set Email Subject
        /// </summary>
        /// <param name="subject">Email Subject</param>
        /// <param name="encoding">Encoding</param>
        /// <returns>Self Email Message</returns>
        public IEmailMessage SetSubject(string subject, Encoding encoding = null)
        {
            if (encoding == null)
            {
                encoding = Encoding.UTF8;
            }

            message.Subject = subject;
            message.SubjectEncoding = encoding;
            return this;
        }

        /// <summary>
        /// Set Email Content
        /// </summary>
        /// <param name="content">Email Content</param>
        /// <param name="isHtml">Html or not</param>
        /// <param name="encoding">Encoding</param>
        /// <returns>Self Email Message</returns>
        public IEmailMessage SetContent(string content, bool isHtml = true, Encoding encoding = null)
        {
            message.Body = content;
            message.BodyEncoding = encoding;
            message.IsBodyHtml = isHtml;
            return this;
        }

        /// <summary>
        /// Set Sender's Email Address
        /// </summary>
        /// <param name="fromAddress">Email Address</param>
        /// <param name="displayName">Display Name</param>
        /// <returns>Self Email Message</returns>
        public IEmailMessage SetSender(string fromAddress, string displayName)
        {
            message.From = new MailAddress(fromAddress, displayName);

            return this;
        }

        /// <summary>
        /// Set Recipient's Email Address
        /// </summary>
        /// <param name="toAddress">Email Address</param>
        /// <param name="displayName">Display Name</param>
        /// <returns>Self Email Message</returns>
        public IEmailMessage AppendToAddress(string toAddress, string displayName = null)
        {
            if (!toAddresses.ContainsKey(toAddress))
            {
                toAddresses.Add(toAddress, displayName);
            }

            return this;
        }

        /// <summary>
        /// Set CC's Email Address
        /// </summary>
        /// <param name="ccAddress">Email Address</param>
        /// <param name="displayName">Display Name</param>
        /// <returns>Self Email Message</returns>
        public IEmailMessage AppendCCAddress(string ccAddress, string displayName = null)
        {
            if (!ccAddresses.ContainsKey(ccAddress))
            {
                ccAddresses.Add(ccAddress, displayName);
            }

            return this;
        }

        /// <summary>
        /// Set BCC's Email Address
        /// </summary>
        /// <param name="bccAddress">Email Address</param>
        /// <param name="displayName">Display Name</param>
        /// <returns>Self Email Message</returns>
        public IEmailMessage AppendBCCAddress(string bccAddress, string displayName = null)
        {
            if (!bccAddresses.ContainsKey(bccAddress))
            {
                bccAddresses.Add(bccAddress, displayName);
            }

            return this;
        }

        /// <summary>
        /// Add attachments
        /// </summary>
        /// <param name="attachment">attachment</param>
        /// <returns>Self Email Message</returns>
        public IEmailMessage AppendAttachment(Attachment attachment)
        {
            message.Attachments.Add(attachment);
            return this;
        }

        /// <summary>
        /// Add attachments
        /// </summary>
        /// <param name="fieldPath">file path</param>
        /// <param name="fileName">file name</param>
        /// <returns>Self Email Message</returns>
        public IEmailMessage AppendAttachment(string fieldPath, string fileName = "")
        {
            AddAttachment(fieldPath, fileName, false, String.Empty);
            return this;
        }

        /// <summary>
        /// Add inline attachments
        /// </summary>
        /// <param name="fieldPath">file path</param>
        /// <param name="cidName">cid name</param>
        /// <returns>Self Email Message</returns>
        public IEmailMessage AppendInlineAttachment(string fieldPath, string cidName)
        {
            AddAttachment(fieldPath, String.Empty, true, cidName);
            return this;
        }

        /// <summary>
        /// Add attachment
        /// </summary>
        /// <param name="fieldPath">file path</param>
        /// <param name="fileName">file name</param>
        /// <param name="isInline">isline resource or not</param>
        /// <param name="cidName">cid name</param>
        private void AddAttachment(string fieldPath, string fileName, bool isInline, string cidName)
        {
            FileInfo file = new FileInfo(fieldPath);
            Stream stream = file.Open(FileMode.Open, FileAccess.Read, FileShare.Read);
            Attachment data = new Attachment(stream, String.Empty);

            ContentDisposition disposition = data.ContentDisposition;

            if (isInline)
            {
                disposition.Inline = true;               
                data.ContentId = cidName;
            }

            disposition.CreationDate = file.CreationTime;
            disposition.ModificationDate = file.LastWriteTime;
            disposition.ReadDate = file.LastAccessTime;
            if (String.IsNullOrEmpty(fileName))
            {
                disposition.FileName = file.Name.ToString();
            }
            else
            {
                disposition.FileName = fileName + Path.GetExtension(fieldPath);
            }

            message.Attachments.Add(data);
        }

        protected Attachment CloneAttachment(Attachment attachment)
        {
            // 1. SMTPException One of the streams has already been used and can't be reset to the origin
            // https://stackoverflow.com/questions/33342212/smtpexception-one-of-the-streams-has-already-been-used-and-cant-be-reset-to-the            
            MemoryStream stream = new MemoryStream();
            CopyStream(attachment.ContentStream, stream);            
            attachment.ContentStream.Position = 0;
            stream.Position = 0;

            Attachment newAttachment = new Attachment(stream, attachment.Name);

            ContentDisposition disposition = newAttachment.ContentDisposition;
            disposition.Inline = attachment.ContentDisposition.Inline;
            newAttachment.ContentId = attachment.ContentId;
            disposition.CreationDate = attachment.ContentDisposition.CreationDate;
            disposition.ModificationDate = attachment.ContentDisposition.ModificationDate;
            disposition.ReadDate = attachment.ContentDisposition.ReadDate;
            disposition.FileName = attachment.ContentDisposition.FileName;

            return newAttachment;
        }

        
        private void CopyStream(Stream input, Stream output)
        {
            // 1. How to get a MemoryStream from a Stream in .NET?
            // https://stackoverflow.com/questions/3212707/how-to-get-a-memorystream-from-a-stream-in-net
            byte[] buffer = new byte[16 * 1024];
            int read;
            while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
            {
                output.Write(buffer, 0, read);
            }
        }

        /// <summary>
        /// Add one alternate view
        /// </summary>
        /// <param name="filePath">file path</param>
        /// <returns>Self Email Message</returns>
        public IEmailMessage AddAlterViewPath(string filePath)
        {
            message.AlternateViews.Add(new AlternateView(filePath));
            return this;
        }

        /// <summary>
        /// Add one alternate view
        /// </summary>
        /// <param name="mailContent">mail content</param>
        /// <returns>Self Email Message</returns>
        public IEmailMessage AddAlterViewContent(string mailContent)
        {
            message.AlternateViews.Add(AlternateView.CreateAlternateViewFromString(mailContent));
            return this;
        }

        /// <summary>
        /// Add one alternate view
        /// </summary>
        /// <param name="contentStream">content stream</param>
        /// <returns>Self Email Message</returns>
        public IEmailMessage AddAlterViewStream(Stream contentStream)
        {
            message.AlternateViews.Add(new AlternateView(contentStream));
            return this;
        }

        /// <summary>
        /// Add one alternate view
        /// </summary>
        /// <param name="alternateView">alternate view</param>
        /// <returns>Self Email Message</returns>
        public IEmailMessage AddAlternateView(AlternateView alternateView)
        {
            message.AlternateViews.Add(alternateView);
            return this;
        }

        /// <summary>
        /// Set Priority
        /// </summary>
        /// <param name="priority">priority</param>
        /// <returns>Self Email Message</returns>
        public IEmailMessage SetPriority(MailPriority priority)
        {
            message.Priority = priority;
            return this;
        }

        /// <summary>
        /// Build Email Message List
        /// </summary>
        /// <returns>Email Message List</returns>
        public abstract List<MailMessage> Build();

        /// <summary>
        /// Reset Email Message
        /// </summary>
        public void Reset()
        {
            message.Subject = "";
            message.SubjectEncoding = Encoding.UTF8;
            message.Body = "";
            message.BodyEncoding = Encoding.UTF8;
            message.IsBodyHtml = true;
            message.From = null;
            message.To.Clear();
            message.CC.Clear();
            message.Bcc.Clear();
            message.Priority = MailPriority.Normal;
        }
    }
}
