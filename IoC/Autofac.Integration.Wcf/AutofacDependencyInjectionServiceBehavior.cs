﻿// This software is part of the Autofac IoC container
// Copyright © 2011 Autofac Contributors
// http://autofac.org
//
// Permission is hereby granted, free of charge, to any person
// obtaining a copy of this software and associated documentation
// files (the "Software"), to deal in the Software without
// restriction, including without limitation the rights to use,
// copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the
// Software is furnished to do so, subject to the following
// conditions:
//
// The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES
// OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT
// HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY,
// WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
// FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR
// OTHER DEALINGS IN THE SOFTWARE.

using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;

namespace Autofac.Integration.Wcf
{
    /// <summary>
    /// Sets the instance provider to an AutofacInstanceProvider.
    /// </summary>
    public class AutofacDependencyInjectionServiceBehavior : IServiceBehavior
    {
        private readonly ILifetimeScope _rootLifetimeScope;
        private readonly ServiceImplementationData _serviceData;


        /// <summary>
        /// Initializes a new instance of the <see cref="AutofacDependencyInjectionServiceBehavior"/> class.
        /// </summary>
        /// <param name="rootLifetimeScope">
        /// The container from which service implementations should be resolved.
        /// </param>
        /// <param name="serviceData">
        /// Data about which service type should be hosted and how to resolve
        /// the type to use for the service implementation.
        /// </param>
        /// <exception cref="System.ArgumentNullException">
        /// Thrown if <paramref name="rootLifetimeScope" /> or <paramref name="serviceData" /> is <see langword="null" />.
        /// </exception>
        public AutofacDependencyInjectionServiceBehavior(ILifetimeScope rootLifetimeScope, ServiceImplementationData serviceData)
        {
            if (rootLifetimeScope == null)
            {
                throw new ArgumentNullException("rootLifetimeScope");
            }
            if (serviceData == null)
            {
                throw new ArgumentNullException("serviceData");
            }

            _rootLifetimeScope = rootLifetimeScope;
            _serviceData = serviceData;
        }

        /// <summary>
        /// Provides the ability to inspect the service host and the service description to confirm that the service can run successfully.
        /// </summary>
        /// <param name="serviceDescription">The service description.</param>
        /// <param name="serviceHostBase">The service host that is currently being constructed.</param>
        public void Validate(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
        {
        }

        /// <summary>
        /// Provides the ability to pass custom data to binding elements to support the contract implementation.
        /// </summary>
        /// <param name="serviceDescription">The service description of the service.</param>
        /// <param name="serviceHostBase">The host of the service.</param>
        /// <param name="endpoints">The service endpoints.</param>
        /// <param name="bindingParameters">Custom objects to which binding elements have access.</param>
        public void AddBindingParameters(
            ServiceDescription serviceDescription, ServiceHostBase serviceHostBase,
            Collection<ServiceEndpoint> endpoints, BindingParameterCollection bindingParameters)
        {
        }

        /// <summary>
        /// Provides the ability to change run-time property values or insert custom extension objects such as error handlers, message or parameter interceptors, security extensions, and other custom extension objects.
        /// </summary>
        /// <param name="serviceDescription">The service description.</param>
        /// <param name="serviceHostBase">The host that is currently being built.</param>
        /// <exception cref="System.ArgumentNullException">
        /// Thrown if <paramref name="serviceDescription" /> or
        /// <paramref name="serviceHostBase" /> is <see langword="null" />.
        /// </exception>
        public void ApplyDispatchBehavior(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
        {
            if (serviceDescription == null)
            {
                throw new ArgumentNullException("serviceDescription");
            }
            if (serviceHostBase == null)
            {
                throw new ArgumentNullException("serviceHostBase");
            }

            var implementedContracts =
                (from ep in serviceDescription.Endpoints
                 where ep.Contract.ContractType.IsAssignableFrom(_serviceData.ServiceTypeToHost)
                 select ep.Contract.Name).ToArray();

            var instanceProvider = new AutofacInstanceProvider(_rootLifetimeScope, _serviceData);

            var endpointDispatchers =
                from cd in serviceHostBase.ChannelDispatchers.OfType<ChannelDispatcher>()
                from ed in cd.Endpoints
                where implementedContracts.Contains(ed.ContractName)
                select ed;

            foreach (var ed in endpointDispatchers)
            {
                ed.DispatchRuntime.InstanceProvider = instanceProvider;
            }
        }
    }
}