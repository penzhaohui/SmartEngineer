using System;
using System.Configuration;
using System.Linq;
using System.Security.Principal;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;
using System.Threading;

namespace SmartEngineer.WCFService.Ext.Inspectors
{
    public class MessageInspector : IClientMessageInspector, IDispatchMessageInspector
    {
        private static string UserName = System.Configuration.ConfigurationManager.AppSettings["username"];
        private static string Password = System.Configuration.ConfigurationManager.AppSettings["password"];

        #region IClientMessageInspector 成员

        public void AfterReceiveReply(ref System.ServiceModel.Channels.Message reply, object correlationState)
        {
            //Console.WriteLine(reply.ToString());
        }

        public object BeforeSendRequest(ref System.ServiceModel.Channels.Message request, System.ServiceModel.IClientChannel channel)
        {
            MessageHeader userNameHeader = MessageHeader.CreateHeader("OperationUserName", "http://tempuri.org", UserName, false, "");
            MessageHeader pwdNameHeader = MessageHeader.CreateHeader("OperationPwd", "http://tempuri.org", Password, false, "");
            request.Headers.Add(userNameHeader);
            request.Headers.Add(pwdNameHeader);

            Console.WriteLine(request.ToString());
            return null;
        }

        #endregion

        #region IDispatchMessageInspector 成员

        public object AfterReceiveRequest(ref System.ServiceModel.Channels.Message request, System.ServiceModel.IClientChannel channel, System.ServiceModel.InstanceContext instanceContext)
        {
            Console.WriteLine("Session ID: " + OperationContext.Current.SessionId);
            Console.WriteLine(request.ToString());

            string username = GetHeaderValue("OperationUserName");
            string pwd = GetHeaderValue("OperationPwd");

            if (username == "peter.peng" && pwd == "peter.peng")
            {
            }
            else
            {
                throw new Exception("操作中的用户名，密码不正确！");
            }

            IPrincipal windowsPrincipal = (IPrincipal)Thread.CurrentPrincipal;
            System.Console.WriteLine("WindowsPrincipal.Identity.Name = " + windowsPrincipal.Identity.Name);

            // WCF 之 限制IP访问: http://blog.csdn.net/ry513705618/article/details/48812421
            var remote = OperationContext.Current.IncomingMessageProperties[RemoteEndpointMessageProperty.Name] as RemoteEndpointMessageProperty;

            if (!AllowConnect(remote.Address))
            {
                var msg = string.Format("IP:{0},不在允许的访问列表，禁止访问。", remote.Address);
                Console.WriteLine(msg);
                throw new Exception(msg);
            }

            return null;
        }

        public void BeforeSendReply(ref System.ServiceModel.Channels.Message reply, object correlationState)
        {
            //Console.WriteLine(reply.ToString());
        }

        string GetHeaderValue(string key)
        {
            int index = OperationContext.Current.IncomingMessageHeaders.FindHeader(key, "http://tempuri.org");
            if (index >= 0)
            {
                return OperationContext.Current.IncomingMessageHeaders.GetHeader<string>(index).ToString();
            }

            return null;
        }

        public bool AllowConnect(string ip)
        {
            Tuple<long, long>[] m_IpRanges;
            var ipRange = ConfigurationManager.AppSettings["IpRangeFilter"];

            string[] ipRangeArray;

            if (string.IsNullOrEmpty(ipRange)
                || (ipRangeArray = ipRange.Split(new char[] { ',', ';' }, StringSplitOptions.RemoveEmptyEntries)).Length <= 0)
            {
                throw new ArgumentException("The ipRange doesn't exist in configuration!");
            }

            m_IpRanges = new Tuple<long, long>[ipRangeArray.Length];

            for (int i = 0; i < ipRangeArray.Length; i++)
            {
                var range = ipRangeArray[i];
                m_IpRanges[i] = GenerateIpRange(range);
            }
            
            var ipValue = ConvertIpToLong(ip);

            var iplist = new System.Collections.Generic.List<long>();
            for (var i = 0; i < m_IpRanges.Length; i++)
            {
                var range = m_IpRanges[i];

                iplist.Add(range.Item1);
                iplist.Add(range.Item2);
            }

            iplist = iplist.OrderBy(a => a).ToList();//我这里认为，IP地址是成对出现的。那么，判断是否是符合标准的IP，则判断是否在范围内即可，或者范围外。  
            for (var i = 1; i <= iplist.Count; i += 2)
            {
                var item = iplist[i];
                bool isodd = i % 2 == 1;
                if (isodd)//是奇数，代表是从列表的偶数位。1,3,5,7,9  
                {
                    var last = iplist[i - 1];
                    if (last <= ipValue && item >= ipValue)
                        return true;
                }
            }

            return false;
        }

        private Tuple<long, long> GenerateIpRange(string range)
        {
            var ipArray = range.Split(new char[] { '-' }, StringSplitOptions.RemoveEmptyEntries);

            if (ipArray.Length != 2)
                throw new ArgumentException("Invalid ipRange exist in configuration!");

            return new Tuple<long, long>(ConvertIpToLong(ipArray[0]), ConvertIpToLong(ipArray[1]));
        }

        private long ConvertIpToLong(string ip)
        {
            var points = ip.Split(new char[] { '.' }, StringSplitOptions.RemoveEmptyEntries);

            if (points.Length != 4)
                throw new ArgumentException("Invalid ipRange exist in configuration!");

            long value = 0;
            long unit = 1;

            for (int i = points.Length - 1; i >= 0; i--)
            {
                value += unit * Convert.ToInt32(points[i]);
                unit *= 256;
            }

            return value;
        }

        #endregion
    }
}
