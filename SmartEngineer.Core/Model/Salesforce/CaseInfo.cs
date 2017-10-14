using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SmartEngineer.Core.Models
{
    [DataContract]
    public class CaseInfo
    {
        public string ID { get; set; }
        public string No { get; set; }
        public string Product { get; set; }
        public string Orgin { get; set; }
        public string Severity { get; set; }
        public string Customer { get; set; }
        public string Version { get; set; }
        public string Owner { get; set; }
        public string Status { get; set; }        
        public string Summary { get; set; }
        public string Description { get; set; }
        public string LastCommentContent { get; set; }
        public string LastCommentReviewer { get; set; }
        public string LastCommentedDate { get; set; }
    }
}
