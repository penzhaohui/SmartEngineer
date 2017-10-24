using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Web.Services.Protocols;
using Microsoft.Web.Services3;
using SmartEngineer.Config;
using SmartEngineer.WCFService.Ext.Behaviors;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.Security.Cryptography.X509Certificates;

namespace SmartEngineer.Common
{
    /// <summary>
    /// Web Service Factory to ensure that all of web service instance is created by this factory.
    /// WSFactory is singleton class.
    /// </summary>
    public class WSFactory
    {
        #region Public Fields

        /// <summary>
        /// singleton pattern.
        /// </summary>
        public static readonly WSFactory Instance = new WSFactory();

        #endregion Public Fields

        #region Private Variables

        /// <summary>
        /// the web service instance that use SoapHttpClientProtocol
        /// </summary>
        private Dictionary<string, SoapHttpClientProtocol> _wsInstances = new Dictionary<string, SoapHttpClientProtocol>();

        /// <summary>
        /// the web service instance that use WebServicesClientProtocol
        /// </summary>
        private Dictionary<string, WebServicesClientProtocol> _ws3Instances = new Dictionary<string, WebServicesClientProtocol>();

        /// <summary>
        /// WCF client instances
        /// </summary>
        Dictionary<string, object> _wcfInstances = new Dictionary<string, object>();

        #endregion Private Variables

        /// <summary>
        /// Get Web Service instance according to the template T.
        /// </summary>
        /// <typeparam name="T">Web Service class which must inherit from SoapHttpClientProtocol.</typeparam>
        /// <returns>A instance of T.</returns>
        public T GetWebService<T>() where T : SoapHttpClientProtocol, new()
        {
            T t;
            string wsName = typeof(T).FullName;

            if (_wsInstances.ContainsKey(wsName))
            {
                t = _wsInstances[wsName] as T;
            }
            else
            {
                lock (typeof(T))
                {
                    if (!_wsInstances.ContainsKey(wsName))
                    {
                        t = new T();
                        WebServiceParameter p = WebServiceConfig.GetWebServiceParameter(typeof(T).Name);
                        t.Url = p.Url;
                        t.Timeout = p.Timeout;
                        _wsInstances.Add(wsName, t);
                    }
                    else
                    {
                        t = _wsInstances[wsName] as T;
                    }
                }
            }

            return t;
        }

        /// <summary>
        /// Get Web Service instance according to the template T.
        /// </summary>
        /// <typeparam name="T">Web Service class which must inherit from WebServicesClientProtocol.</typeparam>
        /// <returns>A instance of T.</returns>
        public T GetWebService3<T>() where T : WebServicesClientProtocol, new()
        {
            T t;
            string wsName = typeof(T).FullName;

            if (_ws3Instances.ContainsKey(wsName))
            {
                t = _ws3Instances[wsName] as T;
            }
            else
            {
                lock (typeof(T))
                {
                    if (!_ws3Instances.ContainsKey(wsName))
                    {
                        t = new T();
                        WebServiceParameter p = WebServiceConfig.GetWebServiceParameter(typeof(T).Name);
                        t.Url = p.Url;
                        t.Timeout = p.Timeout;
                        _ws3Instances.Add(wsName, t);
                    }
                    else
                    {
                        t = _ws3Instances[wsName] as T;
                    }
                }
            }

            return t;
        }

        /// <summary>
        /// Returns instance of WCF client
        /// </summary>
        /// <typeparam name="TClient"></typeparam>
        /// <typeparam name="TChannel"></typeparam>
        /// <returns></returns>
        public TClient GetWCFClient<TClient, TService>(InstanceContext callbackInstance = null)
            where TClient : class
            where TService : class
        {
            TClient clientInstance;

            //get name of the class to be used as key
            string wsName = typeof(TClient).FullName;

            //if instance already exists, use it
            if (_wcfInstances.ContainsKey(wsName) && _wcfInstances[wsName] is TClient)
            {
                clientInstance = _wcfInstances[wsName] as TClient;
            }
            else
            {
                lock (typeof(TClient))
                {
                    if (!_wcfInstances.ContainsKey(wsName))
                    {
                        var serviceName = typeof(TClient).Name.Replace("Client", "");
                        var endpointUrl = $"net.tcp://peter.peng:3721/{serviceName}";
                        var config = WebServiceConfig.GetWebServiceParameter(serviceName);
                        if (config != null)
                        {
                            endpointUrl = config.Url;
                        }

                        EndpointAddress remoteAddress = new EndpointAddress(endpointUrl);
                        NetTcpBinding binding = new NetTcpBinding();
                        // WCF Security基本概念: http://www.cnblogs.com/jfzhu/p/4066178.html
                        // None: 不采取任何安全措施，仅适合在内部安全环境使用
                        // Transport: 在传输协议级别上对通道的所有通讯进行加密，可使用的通讯协议包括 HTTPS、TCP、IPC 和 MSMQ。
                        // 优点是应用广泛，多平台支持，实施方便简单，效率极高，适合高吞吐量的服务使用；
                        // 缺点是只能实现点对点(point-to-point)的消息安全，在使用中介连接(Proxy)时可能会泄漏消息内容，比较适用于于 Intranet 或直接连接的环境。
                        // Message: 通过相关标准(如 WS-Security)直接对消息进行加密来达到安全目的。
                        // 优点是能实现端到端(end-to-end)的安全传输，不存在中介安全隐患，且扩展性较好。因采取工业安全标准，所以整合能力更强，适用于 Internet 服务。缺点是比 Transport 效率要低一些。
                        // Mixed(TransportWithMessageCredential): 混合了上面两种方式。使用 Transport 方式完成消息完整性、消息机密性以及服务器认证，而使用 Message 方式完成客户端认证。
                        // Both: 使用 Transport 和 Message 共同完成所有的安全过程，比较恐怖，性能低下，只有 NetMsmqBinding 支持这一安全方式。

                        //binding.Security.Mode = SecurityMode.Transport;
                        binding.Security.Mode = SecurityMode.TransportWithMessageCredential;
                        //binding.Security.Mode = SecurityMode.Message;
                        binding.Security.Message.ClientCredentialType = MessageCredentialType.UserName;
                        binding.Security.Transport.ClientCredentialType = TcpClientCredentialType.Certificate;

                        //create a new instance of T
                        if (callbackInstance == null)
                        {
                            clientInstance = (TClient)Activator.CreateInstance(typeof(TClient), binding, remoteAddress);
                        }
                        else
                        {
                            clientInstance = (TClient)Activator.CreateInstance(typeof(TClient), callbackInstance, binding, remoteAddress);
                        }

                        //cast it as ClientBace<T> to allow access to the configuration (e.g. end-point. binding etc.) 
                        var client = clientInstance as ClientBase<TService>;
                        if (client == null && callbackInstance != null)
                        {
                            client = clientInstance as DuplexClientBase<TService>;
                        }

                        // 设置客户端证书
                        client.ClientCredentials.ClientCertificate.SetCertificate("CN=SmartEngineer_Test", StoreLocation.CurrentUser, StoreName.My);
                        // 设置不验证服务端证书有效性
                        client.ClientCredentials.ServiceCertificate.Authentication.CertificateValidationMode = System.ServiceModel.Security.X509CertificateValidationMode.None;

                        // http://www.cnblogs.com/chnking/archive/2008/10/07/1305891.html
                        // http://www.cnblogs.com/artech/archive/2008/09/17/1292198.html
                        //为使用TcpTrace跟踪消息设置的TcpTrace监听端口
                        //ClientViaBehavior clientViaBehavior = new ClientViaBehavior(new Uri($"net.tcp://127.0.0.1:3722/{serviceName}"));
                        //client.Endpoint.Behaviors.Add(clientViaBehavior);

                        client.Endpoint.EndpointBehaviors.Add(new GlobalEndpointBehavior());
                        foreach (var op in client.Endpoint.Contract.Operations)
                        {
                            op.Behaviors.Add(new Base64BodyFormatterOperationBehavior());
                        }

                        client.ClientCredentials.UserName.UserName = "peter.peng";
                        client.ClientCredentials.UserName.Password = "peter.peng";

                        //add instance to the dictionary
                        _wcfInstances.Add(wsName, client);
                    }
                    else
                    {
                        clientInstance = _wcfInstances[wsName] as TClient;
                    }
                }
            }

            return clientInstance;
        }        
    }
}
