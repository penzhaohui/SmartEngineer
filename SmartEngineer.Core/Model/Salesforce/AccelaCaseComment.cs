using Newtonsoft.Json;
using System;
using System.Runtime.Serialization;

namespace SmartEngineer.Core.Models
{
    // https://developer.salesforce.com/docs/atlas.en-us.api.meta/api/sforce_api_objects_casecomment.htm
    [DataContract]
    public class AccelaCaseComment
    {
        [DataMember]
        [JsonProperty(PropertyName = "Body")]
        public Byte[] Body { get; set; }

        [DataMember]
        [JsonProperty(PropertyName = "attributes")]
        public AttributeType Attributes { get; set; }

        [DataMember]
        [JsonProperty(PropertyName = "id")]
        public string CommentId { get; set; }

        [DataMember]
        [JsonProperty(PropertyName = "CommentBody")]
        public string CommentBody { get; set; }

        [DataMember]
        [JsonProperty(PropertyName = "CreatedBy")]
        public AccelaCaseAccount CreatedBy { get; set; }

        [DataMember]
        [JsonProperty(PropertyName = "CreatedDate")]
        public DateTime CreatedDate { get; set; }

        [DataMember]
        [JsonProperty(PropertyName = "LastModifiedBy")]
        public AccelaCaseAccount LastModifiedBy { get; set; }

        [DataMember]
        [JsonProperty(PropertyName = "LastModifiedDate")]
        public DateTime LastModifiedDate { get; set; }

        [DataMember]
        [JsonProperty(PropertyName = "ParentId")]
        public string ParentId { get; set; }

        [DataMember]
        [JsonProperty(PropertyName = "IsPublished")]
        public bool IsPublished { get; set; }
    }
}
