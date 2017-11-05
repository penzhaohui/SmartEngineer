using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace SmartEngineer.Core.Models
{
    [DataContract]
    public class Group : BasicDataModel
    {
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public bool IsActive { get; set; }
        [DataMember]
        public int TenantID { get; set; }
    }
}
