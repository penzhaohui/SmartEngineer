#define debug

using System.Net.Mail;

namespace SmartEmail
{
    /// <summary>
    /// 异步发送邮件时保存的信息，用于释放和传递数据
    /// </summary>
    internal class MailUserState
    {
        #region 由MailHelper内部的SendCompleted注册的事件使用

        // 用于释放 MailMessage 和 SmtpClient
        public MailMessage CurMailMessage { get; set; }
        public bool AutoReleaseSmtp { get; set; }
        public SmtpClient CurSmtpClient { get; set; }
        // 只发送单封邮件的时候使用此进行判断释放  
        public bool IsSmpleMail { get; set; }

        #endregion

        /// <summary>
        /// 用户传递的状态对象
        /// </summary>
        public object UserState { get; set; }

        /// <summary>
        /// 当异步发送报错时可通过此标识是否已经处理该异常
        /// </summary>
        public bool IsErrorHandle { get; set; }
    }
}
