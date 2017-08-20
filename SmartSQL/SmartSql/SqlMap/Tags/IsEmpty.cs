using SmartSql.Common;
using System;

namespace SmartSql.SqlMap.Tags
{
    public class IsEmpty : Tag
    {
        public override TagType Type => TagType.IsEmpty;

        public override bool IsCondition(object paramObj)
        {
            Object reqVal = paramObj.GetValue(Property);
            return !((reqVal != null) && (reqVal.ToString().Length > 0));
        }
    }
}
