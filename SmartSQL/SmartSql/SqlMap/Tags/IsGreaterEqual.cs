using SmartSql.Common;
using System;

namespace SmartSql.SqlMap.Tags
{
    public class IsGreaterEqual : CompareTag
    {
        public override TagType Type => TagType.IsGreaterEqual;

        public override bool IsCondition(object paramObj)
        {
            Object reqVal = paramObj.GetValue(Property);

            Decimal reqValNum = 0M;
            Decimal comVal = 0M;
            if (reqVal is Enum)
            {
                reqValNum = reqVal.GetHashCode();
            }
            else
            {
                if (!Decimal.TryParse(reqVal.ToString(), out reqValNum)) { return false; }
            }

            if (!Decimal.TryParse(CompareValue, out comVal)) { return false; }
            return reqValNum >= comVal;
        }
    }
}
