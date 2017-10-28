using Newtonsoft.Json;
using SmartEngineer.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartEngineer.Core.Models
{
    public class AccelaCaseHistory
    {
        [JsonProperty(PropertyName = "attributes")]
        public AttributeType Attributes { get; set; }

        [JsonProperty(PropertyName = "Id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "Case")]
        public AccelaCaseBasic Case { get; set; }

        [JsonProperty(PropertyName = "CreatedBy")]
        public AccelaCaseAccount CreatedBy { get; set; }

        [JsonProperty(PropertyName = "CreatedDate")]
        public DateTime CreatedDate { get; set; }

        [JsonProperty(PropertyName = "NewValue")]
        public string NewValue { get; set; }

        [JsonProperty(PropertyName = "OldValue")]
        public string OldValue { get; set; }

        [JsonProperty(PropertyName = "IsDeleted")]
        public bool IsDeleted { get; set; }
    }
}
