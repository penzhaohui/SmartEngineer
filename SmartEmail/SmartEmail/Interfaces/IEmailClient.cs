using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace SmartEmail
{
    public interface IEmailClient
    {
        /// <summary>
        /// The flag to indicates which method is preferred, send or sendasync
        /// </summary>
        bool IsSendAsync { get; private set; }
        /// <summary>
        /// Return the original SMTP Client
        /// </summary>
        SmtpClient EmailClient { get; private set; }

        /// <summary>
        /// Initialize one Smtp Client Instance
        /// </summary>
        /// <param name="host">Host</param>
        /// <param name="port">Port</param>
        /// <param name="ssl">Flag to enable ssl</param>
        /// <param name="enableHtml">Flag to enable html</param>
        /// <param name="userName">User Name</param>
        /// <param name="password">User Password</param>
        /// <returns>Self Email Client</returns>
        IEmailClient Initialized(string host, int port, bool ssl, bool enableHtml, string userName, string password);

        /// <summary>
        /// Set the time out value for SmtpClient.Send()
        /// </summary>
        /// <param name="timeout">Time out value</param>
        /// <returns>Self Email Client</returns>
        IEmailClient SetTimeout(int timeout);

        /// <summary>
        /// Set one method about how email messages are delivered.
        /// </summary>
        /// <param name="deliveryMethod">0/1/2</param>
        /// <returns>Self Email Client</returns>
        IEmailClient SetDeliveryMethod(int deliveryMethod);

        /// <summary>
        /// Add one certificate
        /// </summary>
        /// <param name="certificate">Certificate file</param>
        /// <returns>Self Email Client</returns>
        IEmailClient AddClientCertificate(X509Certificate certificate);

        /// <summary>
        /// Add one certificate
        /// </summary>
        /// <param name="certPath">Certificate file path</param>
        /// <param name="password">Certificate password</param>
        /// <returns>Self Email Client</returns>
        IEmailClient AddClientCertificate(string certPath, string password);

        /// <summary>
        /// New Email Message
        /// </summary>
        /// <returns>One Email Message</returns>
        IEmailMessage NewEmailMessage();

        /// <summary>
        /// Send Email
        /// </summary>
        /// <param name="emailMessage">Email Message</param>
        /// <returns>success or failed</returns>
        bool Send(IEmailMessage emailMessage);

        /// <summary>
        /// Send Email
        /// </summary>
        /// <param name="message">Email Message</param>
        /// <returns>success or failed</returns>
        bool SendAsync(IEmailMessage message);

        /// <summary>
        /// Cancel Send email
        /// </summary>
        void SendAsyncCancel();
    }
}
