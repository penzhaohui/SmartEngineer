namespace SmartEmail
{
    /// <summary>
    /// 发邮件错误信息
    /// </summary>
    public enum MailInfoType : int
    {
        None = 0,

        #region 10-69 会 导致发送邮件错误的 设置信息

        /// <summary>
        /// 发信人的电子邮件地址未设置
        /// </summary>
        FromEmpty = 10,
        /// <summary>
        /// 收件人的电子邮件地址未设置
        /// </summary>
        ToEmpty = 11,

        /// <summary>
        /// 发信人的电子邮件地址格式错误
        /// </summary>
        FromFormat = 30,
        /// <summary>
        /// 收件人的电子邮件地址格式错误
        /// </summary>
        ToFormat = 31,

        #region SMTP相关检查

        /// <summary>
        /// SmtpClient 实例未设置
        /// </summary>
        SmtpClientEmpty = 14,
        /// <summary>
        /// SMTP主服务器未设置
        /// </summary>
        HostEmpty = 16,
        /// <summary>
        /// 若SMTP启用ssl，则证书不能为空      根据 SmtpClient.EnableSsl 属性来判断
        /// </summary>
        CertificateEmpty = 18,

        #endregion

        

        #endregion
        
        #region 70-139 不会 导致发送邮件错误的 设置信息

        /// <summary>
        /// 邮件主题为空
        /// </summary>
        SubjectEmpty = 71,
        /// <summary>
        /// 邮件内容为空  （若有附件不能算为空）
        /// </summary>
        BodyEmpty = 72,

        /// <summary>
        /// 抄送人的电子邮件地址格式错误
        /// </summary>
        CCFormat = 74,
        /// <summary>
        /// 密送人的电子邮件地址格式错误
        /// </summary>
        BccFormat = 75,

        #endregion

        //#region 140-169 SmtpClient.Send 异常

        ///// <summary>
        ///// SmtpClient 的 SmtpException 异常
        ///// </summary>
        //SmtpEx = 144,
        ///// <summary>
        ///// SmtpClient 的 InvalidOperationException 异常
        ///// </summary>
        //SmtpOperationEx=146,
        ///// <summary>
        ///// SmtpClient 的 SmtpFailedRecipientsException 异常
        ///// </summary>
        //SmtpFailedRecipientsEx=148,
        ///// <summary>
        ///// SmtpClient 的 ObjectDisposedException 异常
        ///// </summary>
        //SmtpDisposedEx=150,

        //#endregion
    }

    
}