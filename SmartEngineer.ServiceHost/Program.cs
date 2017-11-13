using Autofac;
using Autofac.Integration.Wcf;
using Autofac.Multitenant;
using Autofac.Multitenant.Wcf;
using Castle.DynamicProxy;
using SmartEngineer.Core.Adapter;
using SmartEngineer.Ext;
using SmartEngineer.Service;
using SmartEngineer.WCFService.Ext.Behaviors;
using SmartEngineer.WCFService.Ext.Validators;
using System;
using System.ServiceModel;

namespace SmartEngineer
{
    /// <summary>
    /// WCF服务的批量寄宿: http://www.cnblogs.com/artech/archive/2011/12/07/batching-hosting.html
    /// WCF中常用的binding方式: http://www.cnblogs.com/faron/articles/4305557.html
    /// </summary>
    public class Program
    {
        public static void Proxy<TInterface, TImplementer>(ContainerBuilder builder, bool enableInterceptor) 
            where TImplementer : TInterface, new()
            where TInterface : class
        {
            if (enableInterceptor)
            {
                // .NET 通过 Autofac 和 DynamicProxy 实现AOP
                // https://www.cnblogs.com/stulzq/p/6880394.html
                // https://stackoverflow.com/questions/9709355/autofac-castle-dynamicproxy-order-of-interceptors
                // .NET：动态代理的 “5 + 1” 模式 
                // https://www.cnblogs.com/happyframework/p/3295853.html
                ProxyGenerator generator = new ProxyGenerator();
                var options = new ProxyGenerationOptions()
                {
                    Hook = new Framework.AOP.Filter.InterceptorFilter(),
                    Selector = new Framework.AOP.Selector.InterceptorSelector()
                };

                TInterface adapter = new TImplementer();                   
                var proxy = generator.CreateInterfaceProxyWithTarget<TInterface>(adapter, options, new Framework.AOP.AuditLogInterceptor());
                builder.RegisterInstance(proxy).As<TInterface>().SingleInstance();
            }
            else
            {
                builder.RegisterType<TImplementer>().As<TInterface>().SingleInstance();
            }
        }

        public static void Main(string[] args)
        {
            LaunchServiceAsync();

            // Create the tenant ID strategy. Required for multitenant integration.
            var tenantIdStrategy = new OperationContextTenantIdentificationStrategy();

            // Register application-level dependencies and service implementations.
            // Note that we are registering the services as the interface type
            // because the .svc files refer to the interfaces. We could potentially
            // use named service types as well.
            var builder = new ContainerBuilder();

            /*
            builder.RegisterType<AccountAdapter>().As<IAccountAdapter>().SingleInstance();
            builder.RegisterType<JiraAdapter>().As<IJiraAdapter>().SingleInstance();
            builder.RegisterType<SalesforceAdapterV2>().As<ISalesforceAdapterV2>().SingleInstance();
            builder.RegisterType<ConfigAdapter>().As<IConfigAdapter>().SingleInstance();
            builder.RegisterType<DatabaseAdapter>().As<IDatabaseAdapter>().SingleInstance();
            builder.RegisterType<MemberAdapter>().As<IMemberAdapter>().SingleInstance();
            */

            Proxy<IAccountAdapter, AccountAdapter>(builder, false);
            Proxy<IJiraAdapter, JiraAdapter>(builder, true);
            Proxy<ISalesforceAdapterV2, SalesforceAdapterV2>(builder, true);
            Proxy<IConfigAdapter, ConfigAdapter>(builder, false);
            Proxy<IDatabaseAdapter, DatabaseAdapter>(builder, false);
            Proxy<IMemberAdapter, MemberAdapter>(builder, false);

            builder.RegisterType<AccountService>();
            builder.RegisterType<DatabaseService>();
            builder.RegisterType<GithubService>();
            builder.RegisterType<JiraService>();
            builder.RegisterType<JiraServiceForDatabase>();
            builder.RegisterType<JiraServiceForENGSupp>();
            builder.RegisterType<MemberService>();
            builder.RegisterType<ReleaseService>();
            builder.RegisterType<ReportService>();
            builder.RegisterType<SalesforceService>();
            builder.RegisterType<SettingService>();
            builder.RegisterType<TestRailService>();

            // Adding the tenant ID strategy into the container so services
            // can return output about the current tenant.
            builder.RegisterInstance(tenantIdStrategy).As<ITenantIdentificationStrategy>();

            // Create the multitenant container based on the application
            // defaults - here's where the multitenant bits truly come into play.
            var mtc = new MultitenantContainer(tenantIdStrategy, builder.Build());

            // Notice we configure tenant IDs as strings below because the tenant
            // identification strategy retrieves string values from the message
            // headers.

            // Configure overrides for tenant 1 - dependencies, service implementations, etc.
            mtc.ConfigureTenant("Missionsky",
                b =>
                {
                });

            // Configure overrides for tenant 2 - dependencies, service implementations, etc.
            mtc.ConfigureTenant("Accela",
                b =>
                {
                });

            // Configure overrides for the default tenant. That means the default
            // tenant will have some different dependencies than other unconfigured
            // tenants.
            //mtc.ConfigureTenant(null, b => b.RegisterType<DefaultTenantDependency>().As<IDependency>().SingleInstance());

            // Multitenant service hosting requires use of a different service implementation
            // data provider that will allow you to define a metadata buddy class that isn't
            // tenant-specific.
            AutofacHostFactory.ServiceImplementationDataProvider = new MultitenantServiceImplementationDataProvider();

            // Add a behavior to service hosts that get created so incoming messages
            // get inspected and the tenant ID can be parsed from message headers.
            // For multitenancy to work, you need to know for which tenant a
            // given request is being made. In this case, the incoming message headers
            // expect to see a string for the tenant ID; if your tenant ID coming
            // from clients is different, change that here.
            AutofacHostFactory.HostConfigurationAction =
                host =>
                    host.Opening += (s, args1) =>
                        host.Description.Behaviors.Add(new TenantPropagationBehavior<string>(tenantIdStrategy));

            // Finally, set the host factory application container on the multitenant
            // WCF host to a multitenant container. This is similar to standard
            // Autofac WCF integration.
            AutofacHostFactory.Container = mtc;            

            using (ServiceHostCollection hosts = new ServiceHostCollection())
            {
                int port = 8080;
                foreach (ServiceHost host in hosts)
                {
                    ExtServiceHost(host, port++);
                    host.Opened += (sender, args2) => Console.WriteLine("Start to monitor the WCF service: {0}", (sender as ServiceHost).Description.ServiceType);
                }
                hosts.Open(mtc);
                Console.Write("Please any key to stop this application:");
                Console.Read();
            }            
        }

        private static void LaunchServiceAsync()
        {
            SalesforceAdapter.CreateAuthenticationClientAsync();
            SalesforceAdapterV2.CreateAuthenticationClient();
        }

        private static void ExtServiceHost(ServiceHost host, int port)
        {
            // 设置服务端证书
            host.Credentials.ServiceCertificate.SetCertificate("CN=peter.peng");
            // 设置不验证客户端证书的有效性
            host.Credentials.ClientCertificate.Authentication.CertificateValidationMode = System.ServiceModel.Security.X509CertificateValidationMode.None;

            host.Credentials.UserNameAuthentication.UserNamePasswordValidationMode = System.ServiceModel.Security.UserNamePasswordValidationMode.Custom;
            host.Credentials.UserNameAuthentication.CustomUserNamePasswordValidator = new CustomUserNamePasswordValidatorcs();

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
