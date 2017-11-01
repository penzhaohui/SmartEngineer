using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmartEngineer.Core.Models
{
    public class ConfigOption
    {
        public int ID { get; set; }
        public string ConfigOptionValue { get; set; }
        public string ConfigOptionDesc { get; set; }
        public bool IsActive { get; set; }
        public int ConfigID { get; set; }
        public string ConfigExtra { get; set; }
    }
}