using System.Collections.Generic;
using System.Runtime.Serialization;

namespace SmartEngineer.Core.Models
{
    [DataContract]
    public class Config : BasicDataModel
    {
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public string ConfigName { get; set; }
        [DataMember]
        public bool IsActive { get; set; }
        [DataMember]
        public int TenantID { get; set; }

        [DataMember]
        public List<ConfigOption> Options { get; set; }
    }
}