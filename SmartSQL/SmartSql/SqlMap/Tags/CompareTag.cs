﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace SmartSql.SqlMap.Tags
{
    public abstract class CompareTag : Tag
    {
        public String CompareValue { get; set; }
    }
}
