using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmartEngineer.Service.Model
{
    public class Permission
    {
        public int FeatureID { get; set; }
        public int FeatureName { get; set; }
        public bool Read { get; set; }
        public bool Full { get; set; }
        public bool None { get; set; }
    }
}