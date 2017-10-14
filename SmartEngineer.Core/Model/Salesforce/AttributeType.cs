using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace SmartEngineer.Core.Models
{
    [DataContract]
    public class AttributeType
    {

        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }

        [JsonProperty(PropertyName = "url")]
        public string Url { get; set; }
    }
}
