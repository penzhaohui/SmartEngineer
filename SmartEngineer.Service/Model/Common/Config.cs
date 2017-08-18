﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmartEngineer.Service.Model
{
    public class Config
    {
        public int ID { get; set; }
        public int Name { get; set; }

        public List<ConfigOption> Options { get; set; }
    }
}