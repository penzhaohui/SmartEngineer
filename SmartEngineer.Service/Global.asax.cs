using Autofac;
using Autofac.Integration.Wcf;
using SmartEngineer.Core.Adapter;
using System;

namespace SmartEngineer.Service
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            // 注：以下代码对SmartEngineer项目非必需，因为SmartEngineer主要以Service Host方式启动，而不是以Web项目启动
            // WCF integration docs are at:
            // http://autofac.readthedocs.io/en/latest/integration/wcf.html
            var builder = new ContainerBuilder();            

            // Register your service implementations.
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

            // Register your dependencies.
            builder.RegisterType<AccountAdapter>().As<IAccountAdapter>();
            builder.RegisterType<JiraAdapter>().As<IJiraAdapter>();           
            builder.RegisterType<SalesforceAdapterV2>().As<ISalesforceAdapterV2>();
            builder.RegisterType<ConfigAdapter>().As<IConfigAdapter>();
            builder.RegisterType<DatabaseAdapter>().As<IDatabaseAdapter>();
            builder.RegisterType<MemberAdapter>().As<IMemberAdapter>();

            // Set the dependency resolver. This works for both regular
            // WCF services and REST-enabled services.
            var container = builder.Build();
            AutofacHostFactory.Container = container;
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}