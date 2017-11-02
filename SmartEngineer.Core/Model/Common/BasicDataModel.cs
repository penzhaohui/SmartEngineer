using System;
using System.Runtime.Serialization;

namespace SmartEngineer.Core.Models
{
    [DataContract]
    public class BasicDataModel
    {
        public DateTime LastUpdateTime { get; set; }
        public int LastUpdateUserID { get; set; }
    }
}
