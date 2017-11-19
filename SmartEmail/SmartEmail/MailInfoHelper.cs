using System;
using System.Collections.Generic;
using System.Text;

namespace SmartEmail
{
    public static class MailInfoHelper
    {
        public static string GetMailInfoStr(MailInfoType type)
        {
            string str = String.Empty;

            switch (type)
            {
                #region 会 导致发送邮件错误的信息

                case MailInfoType.FromEmpty:
                    str = "发信人的电子邮件地址不能为空。";
                    break;
                case MailInfoType.ToEmpty:
                    str = "收件人的电子邮件地址不能为空。";
                    break;


                case MailInfoType.SmtpClientEmpty:
                    str = "SmtpClient 实例未设置，不能发送邮件。";
                    break;
                case MailInfoType.HostEmpty:
                    str = "SMTP主服务器未设置，不能发送邮件。";
                    break;
                case MailInfoType.CertificateEmpty:
                    str = "SmtpClient 实例设置启用ssl，证书不能为空。";
                    break;


                case MailInfoType.FromFormat:
                    str = "发信人\"{0}\"的电子邮件地址\"{1}\"格式错误。";
                    break;
                case MailInfoType.ToFormat:
                    str = "收件人\"{0}\"的电子邮件地址\"{1}\"格式错误。";
                    break;

                #endregion

                #region 不会 导致发送邮件错误的信息

                case MailInfoType.SubjectEmpty:
                    str = "待发送邮件主题为空，请确认是否继续发送。";
                    break;
                case MailInfoType.BodyEmpty:
                    str = "待发送邮件内容为空，请确认是否继续发送。";
                    break;
                case MailInfoType.CCFormat:
                    str = "抄送人\"{0}\"的电子邮件地址\"{1}\"格式错误。";
                    break;
                case MailInfoType.BccFormat:
                    str = "密送人\"{0}\"的电子邮件地址\"{1}\"格式错误。";
                    break;

                    #endregion

                    //#region SmtpClient.Send 异常

                    //case MailInfoType.SmtpEx:
                    //    str = "SmtpException异常，状态码SmtpStatusCode：{0}，异常详细信息为：{1}.";
                    //    break;
                    //case MailInfoType.SmtpOperationEx:
                    //    str = "InvalidOperationException异常，异常详细信息为：{0}.";
                    //    break;
                    //case MailInfoType.SmtpFailedRecipientsEx:
                    //    str = "SmtpFailedRecipientsException异常，异常详细信息为：{0}.";
                    //    break;
                    //case MailInfoType.SmtpDisposedEx:
                    //    str = "SmtpDisposedEx异常，异常详细信息为：{0}.";
                    //    break;

                    //#endregion
            }

            return str;
        }

        /// <summary>
        /// 根据信息集合判断是否包含错误
        /// （MailInfoType 枚举值为10-69 会 导致发送邮件错误的信息）
        /// </summary>
        /// <param name="dicMsg">信息集合</param>
        /// <returns>true：包含错误；false：包含提示信息或者待检查集合为空</returns>
        public static bool ExistsError(Dictionary<MailInfoType, string> dicMsg)
        {
            if (dicMsg.Count > 0)
            {
                return dicMsg.ContainsKey(MailInfoType.FromEmpty) || dicMsg.ContainsKey(MailInfoType.ToEmpty) || dicMsg.ContainsKey(MailInfoType.SmtpClientEmpty)
                    || dicMsg.ContainsKey(MailInfoType.HostEmpty) || dicMsg.ContainsKey(MailInfoType.CertificateEmpty) || dicMsg.ContainsKey(MailInfoType.FromFormat)
                    || dicMsg.ContainsKey(MailInfoType.ToFormat);
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 获取邮件发送错误和提示信息字符串合集
        /// </summary>
        /// <param name="dicMsg">邮件发送错误和提示</param>
        /// <returns></returns>
        public static string GetMailInfoStr(Dictionary<MailInfoType, string> dicMsg)
        {
            if (dicMsg.Count > 0)
            {
                StringBuilder sBuilder = new StringBuilder(256);
                foreach (KeyValuePair<MailInfoType, string> keyValue in dicMsg)
                {
                    if (sBuilder.Length > 0)
                        sBuilder.AppendLine();
                    sBuilder.Append(keyValue.Value);
                }
                return sBuilder.ToString();
            }
            else
            {
                return String.Empty;
            }
        }
    }
}
