using Newtonsoft.Json;
using System;

namespace SmartEngineer.Core.Models
{
    // https://developer.salesforce.com/docs/atlas.en-us.api.meta/api/sforce_api_objects_attachment.htm
    public class CaseComment
    {
        [JsonProperty(PropertyName = "Body")]
        public Byte[] Body { get; set; }

        [JsonProperty(PropertyName = "attributes")]
        public AttributeType Attributes { get; set; }

        [JsonProperty(PropertyName = "CommentBody")]
        public string CommentBody { get; set; }

        [JsonProperty(PropertyName = "CreatedBy")]
        public Account CreatedBy { get; set; }

        [JsonProperty(PropertyName = "CreatedDate")]
        public DateTime CreatedDate { get; set; }

        [JsonProperty(PropertyName = "LastModifiedBy")]
        public Account LastModifiedBy { get; set; }

        [JsonProperty(PropertyName = "LastModifiedDate")]
        public DateTime LastModifiedDate { get; set; }

        [JsonProperty(PropertyName = "ParentId")]
        public string ParentId { get; set; }

        [JsonProperty(PropertyName = "IsPublished")]
        public bool IsPublished { get; set; }
    }
}
