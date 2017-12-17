using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace SmartEmail
{
    public interface IEmailMessage
    {
        /// <summary>
        /// Set Email Subject
        /// </summary>
        /// <param name="subject">Email Subject</param>
        /// <param name="encoding">Encoding</param>
        /// <returns>Self Email Message</returns>
        IEmailMessage SetSubject(string subject, Encoding encoding);

        /// <summary>
        /// Set Email Content
        /// </summary>
        /// <param name="content">Email Content</param>
        /// <param name="isHtml">Html or not</param>
        /// <param name="encoding">Encoding</param>
        /// <returns>Self Email Message</returns>
        IEmailMessage SetContent(string content, bool isHtml, Encoding encoding);

        /// <summary>
        /// Set Sender's Email Address
        /// </summary>
        /// <param name="fromAddress">Email Address</param>
        /// <param name="displayName">Display Name</param>
        /// <returns>Self Email Message</returns>
        IEmailMessage SetSender(string fromAddress, string displayName);

        /// <summary>
        /// Set Recipient's Email Address
        /// </summary>
        /// <param name="toAddress">Email Address</param>
        /// <param name="displayName">Display Name</param>
        /// <returns>Self Email Message</returns>
        IEmailMessage AppendToAddress(string toAddress, string displayName);

        /// <summary>
        /// Set CC's Email Address
        /// </summary>
        /// <param name="ccAddress">Email Address</param>
        /// <param name="displayName">Display Name</param>
        /// <returns>Self Email Message</returns>
        IEmailMessage AppendCCAddress(string ccAddress, string displayName);

        /// <summary>
        /// Set BCC's Email Address
        /// </summary>
        /// <param name="bccAddress">Email Address</param>
        /// <param name="displayName">Display Name</param>
        /// <returns>Self Email Message</returns>
        IEmailMessage AppendBCCAddress(string bccAddress, string displayName);
        
        /// <summary>
        /// Add attachments
        /// </summary>
        /// <param name="attachment">attachment</param>
        /// <returns>Self Email Message</returns>
        IEmailMessage AppendAttachment(Attachment attachment);

        /// <summary>
        /// Add attachments
        /// </summary>
        /// <param name="fieldPath">file path</param>
        /// <param name="fileName">file name</param>
        /// <returns>Self Email Message</returns>
        IEmailMessage AppendAttachment(string fieldPath, string fileName);

        /// <summary>
        /// Add inline attachments
        /// </summary>
        /// <param name="fieldPath">file path</param>
        /// <param name="cidName">cid name</param>
        /// <returns>Self Email Message</returns>
        IEmailMessage AppendInlineAttachment(string fieldPath, string cidName);

        /// <summary>
        /// Add one alternate view
        /// </summary>
        /// <param name="filePath">file path</param>
        /// <returns>Self Email Message</returns>
        IEmailMessage AddAlterViewPath(string filePath);

        /// <summary>
        /// Add one alternate view
        /// </summary>
        /// <param name="mailContent">mail content</param>
        /// <returns>Self Email Message</returns>
        IEmailMessage AddAlterViewContent(string mailContent);

        /// <summary>
        /// Add one alternate view
        /// </summary>
        /// <param name="contentStream">content stream</param>
        /// <returns>Self Email Message</returns>
        IEmailMessage AddAlterViewStream(Stream contentStream);

        /// <summary>
        /// Add one alternate view
        /// </summary>
        /// <param name="alternateView">alternate view</param>
        /// <returns>Self Email Message</returns>
        IEmailMessage AddAlternateView(AlternateView alternateView);

        /// <summary>
        /// Set Priority
        /// </summary>
        /// <param name="priority">priority</param>
        /// <returns>Self Email Message</returns>
        IEmailMessage SetPriority(MailPriority priority);

        /// <summary>
        /// Build Email Message List
        /// </summary>
        /// <returns>Email Message List</returns>
        List<MailMessage> Build();

        /// <summary>
        /// Reset Email Message
        /// </summary>
        void Reset();
    }
}
