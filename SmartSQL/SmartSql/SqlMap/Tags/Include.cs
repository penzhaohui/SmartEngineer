using SmartSql.Abstractions;
using System;

namespace SmartSql.SqlMap.Tags
{
    public class Include : ITag
    {
        public TagType Type => TagType.Include;
        public String RefId { get; set; }
        public Statement Ref { get; set; }

        public string BuildSql(RequestContext context, string parameterPrefix)
        {
            return Ref.BuildSql(context);
        }
    }
}
