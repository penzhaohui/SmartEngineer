using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace SmartEngineer.Core.Models
{
    [DataContract]
    public class AttributeType
    {
        [DataMember]
        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }

        [DataMember]
        [JsonProperty(PropertyName = "url")]
        public string Url { get; set; }
    }
}
