using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace SmartEngineer.Core.Models
{
    [DataContract]
    public class Permission : BasicDataModel
    {
        [DataMember]
        public int ID { get; set; }
        public int FeatureID { get; set; }
        public int FeatureName { get; set; }
        public bool Read { get; set; }
        public bool Full { get; set; }
        public bool None { get; set; }
    }
}