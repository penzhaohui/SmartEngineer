using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartEngineer.Core.Models
{
    public class Identifier
    {
        public string TableName { get; set; }
        public int LastID { get; set; }
        public int Increment { get; set; }
    }
}
