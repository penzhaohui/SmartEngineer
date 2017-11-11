﻿using System;
using System.ServiceModel;
using Autofac.Multitenant.Wcf;

namespace MultitenantExample.WcfService
{
    [ServiceContract]
    [ServiceMetadataType(typeof(MetadataConsumerBuddyClass))]
    public interface IMetadataConsumer
    {
        [OperationContract]
        GetServiceInfoResponse GetServiceInfo();
    }
}
