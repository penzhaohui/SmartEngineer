using System;
using System.Runtime.Serialization;

namespace SmartEngineer.Core.Models
{
    [DataContract]
    public class Tenant : BasicDataModel
    {
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string DomainPattern { get; set; }
        [DataMember]
        public DateTime CreateDate { get; set; }
        [DataMember]
        public bool IsActive { get; set; }
        [DataMember]
        public string TimeZone { get; set; }
        [DataMember]
        public int MaxAccountNumber { get; set; }
    }
}