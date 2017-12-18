using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Net;
using System.Net.Mail;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Threading;

namespace SmartEmail
{
    public class EmailClientBase : IEmailClient
    {
        protected Stopwatch watch = new Stopwatch();

        /// <summary>
        /// The flag to indicates which method is preferred, send or sendasync
        /// </summary>
        public bool IsSendAsync { get; private set; }

        /// <summary>
        /// Return the original SMTP Client
        /// </summary>
        public SmtpClient EmailClient { get; private set; }

        /// <summary>
        /// The user state when invoke sendAsyc()
        /// </summary>
        public object AsycUserState { get; set; }

        /// <summary>
        /// Initialize one Smtp Client Instance
        /// </summary>
        /// <returns>Self Email Client</returns>
        public IEmailClient Initialized()
        {
            if (EmailClient == null)
            {
                EmailClient = new SmtpClient();
            }

            return this;
        }

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
        public IEmailClient Initialized(string host, int port, bool ssl, bool enableHtml, string userName, string password)
        {
            if (EmailClient == null)
            {
                EmailClient = new SmtpClient(host, port);
                EmailClient.EnableSsl = ssl;
                EmailClient.UseDefaultCredentials = false;
                EmailClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                EmailClient.Credentials = new NetworkCredential(userName, password);
                EmailClient.Timeout = 100000;
            }

            return this;
        }

        /// <summary>
        /// Set the time out value for SmtpClient.Send()
        /// </summary>
        /// <param name="timeout">Time out value</param>
        /// <returns>Self Email Client</returns>
        public IEmailClient SetTimeout(int timeout)
        {
            if (timeout > 0)
            {
                EmailClient.Timeout = timeout;
            }

            return this;
        }

        /// <summary>
        /// Set one method about how email messages are delivered.
        /// </summary>
        /// <param name="deliveryMethod">0/1/2</param>
        /// <returns>Self Email Client</returns>
        public IEmailClient SetDeliveryMethod(int deliveryMethod)
        {
            if (deliveryMethod < 0 || deliveryMethod > 2)
            {
                deliveryMethod = 0; //  Network（默认）
            }

            EmailClient.DeliveryMethod = (SmtpDeliveryMethod)deliveryMethod;

            return this;
        }


        /// <summary>
        /// Add one certificate
        /// </summary>
        /// <param name="certificate">Certificate file</param>
        /// <returns>Self Email Client</returns>
        public IEmailClient AddClientCertificate(X509Certificate certificate)
        {
            EmailClient.EnableSsl = true;
            EmailClient.ClientCertificates.Add(certificate);

            return this;
        }

        /// <summary>
        /// Add one certificate
        /// </summary>
        /// <param name="certPath">Certificate file path</param>
        /// <param name="password">Certificate password</param>
        /// <returns>Self Email Client</returns>
        public IEmailClient AddClientCertificate(string certPath, string password)
        {
            ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(
                (object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors errors) =>
                {
                    if (errors == SslPolicyErrors.None)
                    {
                        return true;
                    }

                    return false;
                });

            X509Certificate cert = new X509Certificate(certPath, password);
            AddClientCertificate(cert);

            return this;
        }

        /// <summary>
        /// New Email Message
        /// </summary>
        /// <returns>One Email Message</returns>
        public IEmailMessage NewEmailMessage<T>() where T : EmailMessageBase, new()
        {
            IEmailMessage newMessage = new T();
            return newMessage;
        }

        private long messageQueueItemCount = 0;
        private long planedSendCount = 0;
        private long completedSendCount = 0;

        /// <summary>
        /// The count of emails planed to be sent out
        /// </summary>
        public long PlanedSendCount
        {
            get { return Interlocked.Read(ref planedSendCount); }
            private set { Interlocked.Exchange(ref planedSendCount, value); }
        }

        /// <summary>
        /// The count of emails already finished to be sent out
        /// </summary>
        public long CompletedSendCount
        {
            get { return Interlocked.Read(ref completedSendCount); }
            private set { Interlocked.Exchange(ref completedSendCount, value); }
        }

        private ConcurrentQueue<MailMessageItem> messageQueue = null;
        /// <summary>
        /// Email Message Queue
        /// </summary>
        private ConcurrentQueue<MailMessageItem> MessageQueue
        {
            get
            {
                if (messageQueue == null)
                {
                    messageQueue = new ConcurrentQueue<MailMessageItem>();
                }

                return messageQueue;
            }
        }

        private Thread SendMailThread = null;
        private AutoResetEvent autoResetEvent = null;
        private AutoResetEvent AutoResetEvent
        {
            get
            {
                if (autoResetEvent == null)
                {
                    autoResetEvent = new AutoResetEvent(true);
                }
                return autoResetEvent;
            }
        }

        /// <summary>
        /// Send Email
        /// </summary>
        /// <param name="emailMessage">Email Message</param>
        /// <returns>success or failed</returns>
        public bool Send(IEmailMessage emailMessage)
        {
            List<MailMessage> messages = emailMessage.Build();

            return Send(messages);
        }

        /// <summary>
        /// Batch Send Email
        /// </summary>
        /// <param name="emailMessageCollection">Email Message Collection</param>
        /// <returns></returns>
        public bool Send(MailMessageCollectionBase emailMessageCollection)
        {
            List<MailMessage> messages = new List<MailMessage>();

            foreach (IEmailMessage emailMessage in emailMessageCollection)
            {
                messages.AddRange(emailMessage.Build());
            }

            return Send(messages);
        }

        /// <summary>
        /// Sending mail synchronously
        /// </summary>
        /// <param name="messages">Mail Message Array</param>
        /// <returns>Success or failure</returns>
        private bool Send(List<MailMessage> messages)
        {
            watch.Reset();
            watch.Start();

            IsSendAsync = false;

            PlanedSendCount = messages.Count;

            foreach (MailMessage message in messages)
            {
                try
                {
                    EmailClient.Send(message);

                    CompletedSendCount++;
                }
                catch (ObjectDisposedException smtpObjectDisposedEx)
                {
#if DEBUG
                    Debug.WriteLine("Failed to send one email. " + smtpObjectDisposedEx);
#endif
                }
                catch (InvalidOperationException smtpInvalidOperationEx)
                {
#if DEBUG
                    Debug.WriteLine("Failed to send one email. " + smtpInvalidOperationEx);
#endif
                }
                catch (SmtpFailedRecipientsException smtpFailedRecipientsEx)
                {
#if DEBUG
                    Debug.WriteLine("Failed to send one email. " + smtpFailedRecipientsEx);
#endif
                }
                catch (SmtpException smtpEx)
                {
#if DEBUG
                    Debug.WriteLine("Failed to send one email. " + smtpEx);
#endif
                }
                catch (Exception ex)
                {
#if DEBUG
                    Debug.WriteLine("Failed to send one email. " + ex);
#endif
                }
                finally
                {
                    DisposeMessage(message);
                }
            }

            return true;
        }

        /// <summary>
        /// Send Email
        /// </summary>
        /// <param name="message">Email Message</param>
        /// <returns>Success or failure</returns>
        public bool SendAsync(IEmailMessage message)
        {
            List<MailMessage> messages = message.Build();

            return SendAsync(messages);
        }


        /// <summary>
        /// Batch Send Email
        /// </summary>
        /// <param name="emailMessageCollection">Email Message Collection</param>
        /// <returns>Success or failure</returns>
        public bool SendAsync(MailMessageCollectionBase emailMessageCollection)
        {
            List<MailMessage> messages = new List<MailMessage>();

            foreach (IEmailMessage emailMessage in emailMessageCollection)
            {
                messages.AddRange(emailMessage.Build());
            }

            return SendAsync(messages);
        }

        /// <summary>
        /// Sending mail asynchronously
        /// </summary>
        /// <param name="messages">Email Message Collection</param>
        /// <returns>Success or failure</returns>
        private bool SendAsync(List<MailMessage> messages)
        {
            watch.Reset();
            watch.Start();
            IsSendAsync = true;

            planedSendCount = messages.Count;
            EmailClient.SendCompleted += new SendCompletedEventHandler(this.SendCompleted4Dispose);

            if (planedSendCount == 0)
            {
                MailMessageItem mailMessageItem = new MailMessageItem()
                {
                    Message = messages[0],
                    Client = EmailClient,
                    IsAutoReleaseSmtpClient = true,
                    IsBatchSendAsync = false
                };

                ThreadPool.QueueUserWorkItem((item) => {

                    MailMessageItem currentMessageItem = (MailMessageItem)item;
                    if (currentMessageItem.Client != null)
                    {
                        currentMessageItem.Client.SendAsync(currentMessageItem.Message, currentMessageItem);
                    }
                    else
                    {
                        throw new Exception("No SMTP Client is set.");
                    }

                }, mailMessageItem);
            }
            else
            {
                BatchSendAsync(messages);
            }

            return true;
        }

        /// <summary>
        /// Cancel Send email
        /// </summary>
        public void SendAsyncCancel()
        {
            // 因为此类为非线程安全类，所以 SendAsyncCancel 和发送邮件方法中操作MessageQueue部分的代码肯定是串行化的。
            // 所以不存在一边入队，一边出队导致无法完全取消所有邮件发送

            // 1、清空队列。
            // 2、取消正在异步发送的mail。
            // 3、设置计划数量=完成数量
            // 4、执行 AutoDisposeSmtp() 

            if (IsSendAsync)
            {
                // 1、清空队列。
                MailMessageItem mailMessageItem;
                while (MessageQueue.TryDequeue(out mailMessageItem))
                {
                    Interlocked.Decrement(ref messageQueueItemCount);
                    MailMessage message = mailMessageItem.Message;
                    DisposeMessage(message);
                }
                mailMessageItem = null;
                // 2、取消正在异步发送的mail。
                EmailClient.SendAsyncCancel();
                // 3、设置计划数量=完成数量
                planedSendCount = completedSendCount;
                // 4、执行 AutoDisposeSmtp() 
                this.AutoDisposeSMTPClient();
            }
            else
            {
                throw new Exception("MailValidatorHelper.EMAIL_ASYNC_CALL_ERROR");
            }
        }

        private void BatchSendAsync(List<MailMessage> messages)
        {
            foreach (MailMessage emailMessage in messages)
            {
                MailMessageItem mailMessageItem = new MailMessageItem()
                {
                    Message = emailMessage,
                    Client = EmailClient,
                    IsAutoReleaseSmtpClient = true,
                    IsBatchSendAsync = true
                };

                MessageQueue.Enqueue(mailMessageItem);
                Interlocked.Increment(ref messageQueueItemCount);
            }

            if (SendMailThread == null)
            {
                SendMailThread = new Thread(() =>
                {
                    // the counter to record how many times no email message is retrived from message queue.
                    int noItemCount = 0;
                    while (true)
                    {
                        if (planedSendCount != 0 && planedSendCount == completedSendCount)
                        {
                            // Send all messages already
                            break;
                        }
                        else
                        {
                            MailMessageItem mailMessageItem;
                            if (!MessageQueue.IsEmpty)
                            {
                                AutoResetEvent.WaitOne();

                                if (MessageQueue.TryDequeue(out mailMessageItem))
                                {
                                    Interlocked.Decrement(ref messageQueueItemCount);
                                    // Send email
                                    EmailClient.SendAsync(mailMessageItem.Message, mailMessageItem);                                    
                                }
                            }
                            else
                            {
                                if (noItemCount >= 10)
                                {
                                    throw new Exception("No email message item exists in the message queue.");
                                }

                                Thread.Sleep(1000);
                                noItemCount++;
                            }
                        }

                        // Check if the email client is released or not
                        if (EmailClient == null)
                        {
                            break;
                        }
                    }
                });

                SendMailThread.Start();
            }
        }

        /// <summary>
        /// Dispose Mail Message
        /// </summary>
        /// <param name="message">Message</param>
        private void DisposeMessage(MailMessage message)
        {
            if (message != null)
            {
                if (message.AlternateViews.Count > 0)
                {
                    message.AlternateViews.Dispose();
                }

                message.Dispose();
                message = null;
            }
        }

        /// <summary>
        /// 声明在 SmtpClient.SendAsync() 执行完后释放相关对象的回调方法   最后触发的委托
        /// </summary>
        protected void SendCompleted4Dispose(object sender, AsyncCompletedEventArgs e)
        {
            MailMessageItem userState = (MailMessageItem)e.UserState;

            if (userState.Message != null)
            {
                MailMessage message = userState.Message;
                DisposeMessage(message);
                userState.Message = null;
            }

            if (userState.IsBatchSendAsync == false)
            {
                if (userState.IsAutoReleaseSmtpClient && userState.Client != null)
                {
                    DisposeSMTPClient();
                }
            }
            else
            {
                if (!e.Cancelled)   // 取消的就不计数
                {
                    completedSendCount++;
                }

                if (userState.IsAutoReleaseSmtpClient)
                {
                    AutoDisposeSMTPClient();
                }

                // 若批量异步发送，需要设置信号
#if DEBUG
                Debug.WriteLine("Set" + Thread.CurrentThread.ManagedThreadId);
#endif
                AutoResetEvent.Set();
            }

            // 先释放资源，处理错误逻辑
            if (e.Error != null && !userState.IsErrorHandled)
            {
                throw e.Error;
            }
        }

        /// <summary>
        /// 释放SmtpClient
        /// </summary>
        private void AutoDisposeSMTPClient()
        {
            if (EmailClient != null)
            {
                if (planedSendCount == 0)
                {
                    // PrepareSendCount=0 说明还未设置计划批量邮件数，所以不自动释放SmtpClient。
                    // 不能因为小于CompletedSendCount就报错，因为可能是先发送再设置计划邮件数量
                }
                else if (planedSendCount < completedSendCount)
                {
                    throw new Exception("MailValidatorHelper.EMAIL_ASYNC_SEND_PREPARE_ERROR");
                }
                else if (planedSendCount == completedSendCount)
                {
                    DisposeSMTPClient();
                }
            }
        }

        /// <summary>
        /// 释放SmtpClient
        /// </summary>
        private void DisposeSMTPClient()
        {
            if (EmailClient != null)
            {
#if DEBUG
                Debug.WriteLine("释放SMTP Client");
#endif
                EmailClient.Dispose();
                EmailClient = null;

                planedSendCount = 0;
                completedSendCount = 0;
                watch.Stop();
            }
        }
        
        private class MailMessageItem
        {
            /// <summary>
            /// Mail Message
            /// </summary>
            public MailMessage Message { get; set; }
            /// <summary>
            /// SMTP Client
            /// </summary>
            public SmtpClient Client { get; set; }           
            /// <summary>
            /// The flag indicates whether the smtp client will be automatically released or not
            /// </summary>
            public bool IsAutoReleaseSmtpClient { get; set; }
            /// <summary>
            /// The flag indicates whether it is batch send or not
            /// </summary>
            public bool IsBatchSendAsync { get; set; }
            /// <summary>
            /// User State
            /// </summary>
            public object UserState { get; set; }
            /// <summary>
            /// The flag indicates whether the exception/error is handled or not
            /// </summary>
            public bool IsErrorHandled { get; set; }
        }
    }   
}
