using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartEngineer.Core.Model.Common
{
    public class IDStore
    {
        public string SeqName { get; set; }
        public string SeqDesc { get; set; }
        public long LastNumber { get; set; }
        public int Increment { get; set; }
        public int CacheSize { get; set; }
        public bool Status { get; set; }
    }
}
