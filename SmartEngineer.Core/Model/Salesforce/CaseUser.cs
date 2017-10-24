using Newtonsoft.Json;
using SmartEngineer.Core.Models;

namespace SmartEngineer.Core.Models
{
    public class CaseUser
    {
        [JsonProperty(PropertyName = "attributes")]
        public AttributeType Attributes { get; set; }

        [JsonProperty(PropertyName = "Name")]
        public string Name { get; set; }
    }
}
