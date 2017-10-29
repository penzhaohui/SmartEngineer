﻿using System.Collections.Generic;
using System.Net;
using ECommon.Remoting;
using ECommon.Socketing;

namespace ECommon.Extensions
{
    public static class RemotingClientUtils
    {
        public static IEnumerable<SocketRemotingClient> ToRemotingClientList(this IEnumerable<IPEndPoint> endpointList, SocketSetting socketSetting)
        {
            var remotingClientList = new List<SocketRemotingClient>();
            foreach (var endpoint in endpointList)
            {
                var remotingClient = new SocketRemotingClient(endpoint, socketSetting);
                remotingClientList.Add(remotingClient);
            }
            return remotingClientList;
        }
    }
}
