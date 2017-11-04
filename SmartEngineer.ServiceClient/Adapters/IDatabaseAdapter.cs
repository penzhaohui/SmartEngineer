using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartEngineer.ServiceClient.Adapters
{
    public interface IDatabaseAdapter
    {
        List<string> GetDBInstances(string ip, string authType, string userName, string password);
    }
}
