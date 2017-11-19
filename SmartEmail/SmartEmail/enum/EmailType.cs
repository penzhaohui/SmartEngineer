namespace SmartEmail
{
    /// <summary>
    /// 邮箱类型
    /// </summary>
    public enum EmailType
    {
        None = 0,
        /// <summary>
        /// Google 的网络邮件服务
        /// </summary>
        Gmail = 2,
        /// <summary>
        /// HotMail/Live
        /// </summary>
        HotMail = 4,
        /// <summary>
        /// QQ/FoxMail（Foxmail被腾讯收购）
        /// </summary>
        QQ_FoxMail = 8,
        /// <summary>
        /// QQ企业邮箱 http://service.exmail.qq.com/cgi-bin/help?subtype=1&id=28&no=1000585
        /// </summary>
        QQ_Exmail = 16,
        /// <summary>
        /// 网易126   http://zhidao.baidu.com/question/254278953.html
        /// </summary>
        Mail_126 = 32,
        /// <summary>
        /// 网易163   http://zhidao.baidu.com/question/254278953.html
        /// </summary>
        Mail_163 = 64,
        /// <summary>
        /// 新浪邮箱
        /// </summary>
        Sina = 128,
        /// <summary>
        /// Tom
        /// </summary>
        Tom = 256,
        /// <summary>
        /// 搜狐邮箱
        /// </summary>
        SoHu = 512,
        /// <summary>
        /// 雅虎邮箱    http://zhidao.baidu.com/question/543474569.html
        /// </summary>
        Yahoo = 1024        
    }
}