﻿using System;
using Autofac.Multitenant;
using MultitenantExample.WcfService.Dependencies;

namespace MultitenantExample.WcfService.ServiceImplementations
{
    public class Tenant1Implementation : IMultitenantService, IMetadataConsumer
    {
        public Tenant1Implementation(IDependency dependency, ITenantIdentificationStrategy tenantIdStrategy)
        {
            this.Dependency = dependency;
            this.TenantIdentificationStrategy = tenantIdStrategy;
        }

        public IDependency Dependency { get; set; }

        public ITenantIdentificationStrategy TenantIdentificationStrategy { get; set; }

        public GetServiceInfoResponse GetServiceInfo()
        {
            var response = ServiceInfoBuilder.Build(this, this.Dependency, this.TenantIdentificationStrategy);
            response.ServiceImplementationTypeName += " [Custom value from Tenant 1 service imp.]";
            return response;
        }
    }
}