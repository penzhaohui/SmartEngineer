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

                        binding.Security.Mode = SecurityMode.Transport;
                        binding.Security.Transport.ClientCredentialType = TcpClientCredentialType.Certificate;

                        //create a new instance of T
                        clientInstance = (TClient)Activator.CreateInstance(typeof(TClient), callbackInstance, binding, remoteAddress);

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
