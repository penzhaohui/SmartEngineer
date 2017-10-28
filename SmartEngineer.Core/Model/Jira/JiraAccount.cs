using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SmartEngineer.Core.Models
{
    [DataContract]
    public class JiraAccount
    {
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string EmailAddress { get; set; }
        [DataMember]
        public string DisplayName { get; set; }
        [DataMember]
        public string IsActive { get; set; }
    }
}
