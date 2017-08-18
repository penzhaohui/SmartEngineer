using System.Runtime.Serialization;

namespace SmartEngineer.Service.Model
{
    [DataContract]
    public class Tenant
    {
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public bool Primary { get; set; }
    }
}