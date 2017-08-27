using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace SmartEngineer.Core.Models
{
    [DataContract]
    public class Account
    {
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public string UserName { get; set; }
        [DataMember]
        public string Password { get; set; }
        [DataMember]
        public string EmailAddress { get; set; }
        [DataMember]
        public string DisplayName { get; set; }
        [DataMember]
        public string AccessToken { get; set; }
        /// <summary>
        /// Note, One account can be associated to multiple tenants.
        /// </summary>
        [DataMember]
        public List<Tenant> Tenants {get; set;}
        /// <summary>
        /// Note, One account can be associated to multiple roles.
        /// </summary>
        public List<Role> Roles { get; set; }
        /// <summary>
        /// Note, The permission is one union based on role's permission.
        /// </summary>
        public List<Permission> Permissions { get; set; }
    }
}