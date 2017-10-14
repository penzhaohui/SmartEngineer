using Newtonsoft.Json;
using System;
using System.Runtime.Serialization;

namespace SmartEngineer.Core.Models
{
    [DataContract]
    public class NewCaseComment
    {
        [JsonProperty(PropertyName = "Body")]
        public Byte[] Body { get; set; }

        [JsonProperty(PropertyName = "CommentBody")]
        public string CommentBody { get; set; }

        [JsonProperty(PropertyName = "ParentId")]
        public string ParentId { get; set; }

        [JsonProperty(PropertyName = "IsPublished")]
        public bool IsPublished { get; set; }
    }
}
