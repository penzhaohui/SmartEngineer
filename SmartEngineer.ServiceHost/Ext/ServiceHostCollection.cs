using System;
using System.ServiceModel;
using System.Collections.ObjectModel;
using Autofac.Integration.Wcf;
using Autofac;

namespace SmartEngineer.Ext
{
    public class ServiceHostCollection : Collection<ServiceHost>, IDisposable
    {
        public ServiceHostCollection(params Type[] serviceTypes)
        {
            BatchingHostingSettings settings = BatchingHostingSettings.GetSection();
            foreach (ServiceTypeElement element in settings.ServiceTypes)
            {             
                this.Add(element.ServiceType);
            }

            if (null != serviceTypes)
            {
                Array.ForEach<Type>(serviceTypes, serviceType => this.Add(new ServiceHost(serviceType)));
            }
        }
        public void Add(params Type[] serviceTypes)
        {
            if (null != serviceTypes)
            {
                Array.ForEach<Type>(serviceTypes, serviceType => this.Add(new ServiceHost(serviceType)));
            }
        }
        public void Open(IContainer container)
        {
            foreach (ServiceHost host in this)
            {
                // http://blog.csdn.net/gulijiang2008/article/details/45747275
                host.AddDependencyInjectionBehavior(host.Description.ServiceType, container);
                host.Open();
            }
        }
        public void Dispose()
        {
            foreach (IDisposable host in this)
            {
                host.Dispose();
            }
        }
    }
}
