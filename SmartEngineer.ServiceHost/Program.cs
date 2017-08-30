using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using SmartEngineer.Ext;
using SmartEngineer.WCFService.Ext.Behaviors;

namespace SmartEngineer
{
    /// <summary>
    /// WCF服务的批量寄宿: http://www.cnblogs.com/artech/archive/2011/12/07/batching-hosting.html
    /// WCF中常用的binding方式: http://www.cnblogs.com/faron/articles/4305557.html
    /// </summary>
    public class Program
    {
        static void Main(string[] args)
        {
            using (ServiceHostCollection hosts = new ServiceHostCollection())
            {
                int port = 8080;
                foreach (ServiceHost host in hosts)
                {
                    ExtServiceHost(host, port++);
                    host.Opened += (sender, arg) => Console.WriteLine("Start to monitor the WCF service: {0}", (sender as ServiceHost).Description.ServiceType);
                }
                hosts.Open();
                Console.Write("Please any key to stop this application:");
                Console.Read();
            }            
        }

        private static void ExtServiceHost(ServiceHost host, int port)
        {
            // 设置服务端证书
            host.Credentials.ServiceCertificate.SetCertificate("CN=peter.peng");
            // 设置不验证客户端证书的有效性
            host.Credentials.ClientCertificate.Authentication.CertificateValidationMode = System.ServiceModel.Security.X509CertificateValidationMode.None;

            if (host.Description.Behaviors.Find<System.ServiceModel.Description.ServiceMetadataBehavior>() == null)
            {
                System.ServiceModel.Description.ServiceMetadataBehavior svcMetaBehavior = new System.ServiceModel.Description.ServiceMetadataBehavior();
                svcMetaBehavior.HttpGetEnabled = true;
                svcMetaBehavior.HttpGetUrl = new Uri($"http://127.0.0.1:{port}/mex");
                host.Description.Behaviors.Add(svcMetaBehavior);
            }
            
            foreach (var endpoint in host.Description.Endpoints)
            {
                endpoint.Behaviors.Add(new GlobalEndpointBehavior());
                //endpoint.Behaviors.Add(new BinaryFormatterEndpointBehavior());
                foreach (var op in endpoint.Contract.Operations)
                {
                    op.Behaviors.Add(new Base64BodyFormatterOperationBehavior());
                }
            }
        }
    }
}
