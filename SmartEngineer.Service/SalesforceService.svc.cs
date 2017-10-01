using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SmartEngineer.Service
{
    public class SalesforceService : ISalesforceService
    {        
        public void GetCaseIDListByQueue()
        {
            // Not need
            throw new NotImplementedException();
        }

        public void GetCommentedCaseList()
        {
            throw new NotImplementedException();
        }

        public void GetNewCaseList()
        {
            throw new NotImplementedException();
        }
    }
}
