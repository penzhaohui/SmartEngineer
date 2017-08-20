using SmartSql.Common;
using System;

namespace SmartSql.SqlMap.Tags
{
    public class IsNull : Tag
    {
        public override TagType Type => TagType.IsNull;

        public override bool IsCondition(object paramObj)
        {
            Object reqVal = paramObj.GetValue(Property);
            return reqVal == null;
        }
    }
}
