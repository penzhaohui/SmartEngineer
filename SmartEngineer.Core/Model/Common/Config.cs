using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmartEngineer.Core.Models
{
    public class Config
    {
        public int ID { get; set; }
        public string ConfigName { get; set; }
        public bool IsActive { get; set; }

        public List<ConfigOption> Options { get; set; }
    }
}