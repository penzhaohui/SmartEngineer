using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartEngineer.Core.Models
{
    public class MemberGroup : BasicDataModel
    {
        public int ID { get; set; }
        public int MemberID { get; set; }
        public int RoleID { get; set; }
        public int TenantID { get; set; }
        public bool IsActive { get; set; }
    }
}
