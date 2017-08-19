using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Web.Services.Protocols;
using Microsoft.Web.Services3;
using SmartEngineer.Config;
using SmartEngineer.WCFService.Ext.Behaviors;

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
                        WebServiceParameter p = WebServiceConfig.GetWebServiceParameter(typeof(T));
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
                        WebServiceParameter p = WebServiceConfig.GetWebServiceParameter(typeof(T));
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
        public TClient GetWCFClient<TClient, TChannel, TService>(InstanceContext callbackInstance)
            where TClient : DuplexClientBase<TService>
            where TChannel : class
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
                        //create a new instance of T
                        clientInstance = (TClient)Activator.CreateInstance(typeof(TClient), callbackInstance);

                        //cast it as ClientBace<T> to allow access to the configuration (e.g. end-point. binding etc.)
                        var client = clientInstance as DuplexClientBase<TService>;

                        //set end-point address and some other settings
                        var endpointUrl = client.Endpoint.Address != null ? client.Endpoint.Address.ToString() : "";

                        if (!string.IsNullOrWhiteSpace(endpointUrl))
                        {
                            var endpointMethod = typeof(TChannel).Name;

                            //clear all trailing slashes
                            endpointUrl = endpointUrl.TrimEnd('/');

                           //endpointUrl = string.Format("{0}/{1}", endpointUrl, endpointMethod);
                        }
                        else
                        {
                            var config = WebServiceConfig.GetWebServiceParameter(typeof(TClient));

                            if (config != null)
                                endpointUrl = config.Url;
                            else
                                throw new Exception("Web service configuration is missing or invalid");
                        }

                        client.Endpoint.Address = new EndpointAddress(endpointUrl);

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

        /// <summary>
        /// Returns instance of WCF client
        /// </summary>
        /// <typeparam name="TClient"></typeparam>
        /// <typeparam name="TChannel"></typeparam>
        /// <returns></returns>
        public TClient GetWCFClient<TClient, TChannel, TService>()
            where TClient : ClientBase<TService>, new()
            where TChannel : class
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
                        //create a new instance of T
                       clientInstance = new TClient();

                        //cast it as ClientBace<T> to allow access to the configuration (e.g. end-point. binding etc.)
                        var client = clientInstance as ClientBase<TService>;
                        client.Endpoint.EndpointBehaviors.Add(new Base64BodyFormatterEndpointBehavior());
                        foreach (var op in client.Endpoint.Contract.Operations)
                        {
                            op.Behaviors.Add(new Base64BodyFormatterOperationBehavior());
                        }

                        //set end-point address and some other settings
                        var endpointUrl = client.Endpoint.Address != null ? client.Endpoint.Address.ToString() : "";
                        

                        if (!string.IsNullOrWhiteSpace(endpointUrl))
                        {
                            var endpointMethod = typeof(TChannel).Name;

                            //clear all trailing slashes
                            endpointUrl = endpointUrl.TrimEnd('/');

                            //endpointUrl = string.Format("{0}/{1}", endpointUrl, endpointMethod);
                        }
                        else
                        {
                            var config = WebServiceConfig.GetWebServiceParameter(typeof(TClient));

                            if (config != null)
                                endpointUrl = config.Url;
                            else
                                throw new Exception("Web service configuration is missing or invalid");
                        }

                        client.Endpoint.Address = new EndpointAddress(endpointUrl);

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
