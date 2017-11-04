using System.Runtime.Serialization;

namespace SmartEngineer.Core.Models
{
    [DataContract]
    public class ConfigOption
    {
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public string ConfigOptionValue { get; set; }
        [DataMember]
        public string ConfigOptionDesc { get; set; }
        [DataMember]
        public bool IsActive { get; set; }
        [DataMember]
        public int ConfigID { get; set; }
        [DataMember]
        public int TenantID { get; set; }
        [DataMember]
        public string ConfigExtra { get; set; }
    }
}