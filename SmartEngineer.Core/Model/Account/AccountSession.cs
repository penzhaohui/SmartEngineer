using System;

namespace SmartEngineer.Core.Models
{
    public class AccountSession
    {
        public int ID { get; set; }
        public string TenantCode { get; set; }
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string AccessToken { get; set; }
        public DateTime CreatedTime { get; set; }
        public DateTime ExpiredTime { get; set; }
        public bool Active { get; set; }
    }
}
