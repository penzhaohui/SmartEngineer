﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using SmartEngineer.Core.Models;

namespace SmartEngineer.Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ReleaseService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select ReleaseService.svc or ReleaseService.svc.cs at the Solution Explorer and start debugging.
    public class ReleaseService : IReleaseService
    {
        public bool AddCodeBanch(int id, string product, string url)
        {
            throw new NotImplementedException();
        }

        public bool AddJiraFilter(int id, string url)
        {
            throw new NotImplementedException();
        }

        public bool AddTestRail(int id, string testrun, string url)
        {
            throw new NotImplementedException();
        }

        public void DoWork()
        {
        }

        public List<IssueInfo> GetExistingScopeItems(int id)
        {
            throw new NotImplementedException();
        }

        public int GetReleaseInfo(int id)
        {
            throw new NotImplementedException();
        }

        public bool SubmitNewScopeItems(string name, List<IssueInfo> items)
        {
            throw new NotImplementedException();
        }

        public int SubmitReleaseInfo(ReleaseInfo releaseInfo)
        {
            throw new NotImplementedException();
        }
    }
}
