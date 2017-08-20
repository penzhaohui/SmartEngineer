﻿using SmartSql.Abstractions;
using System;

namespace SmartSql.SqlMap.Tags
{
    public interface ITag
    {
        TagType Type { get; }
        String BuildSql(RequestContext context, String parameterPrefix);
    }

    public enum TagType
    {
        SqlText,
        IsEmpty,
        IsEqual,
        IsGreaterEqual,
        IsGreaterThan,
        IsLessEqual,
        IsLessThan,
        IsNotEmpty,
        IsNotEqual,
        IsNotNull,
        IsNull,
        IsTrue,
        IsFalse,
        Include,
        Switch,
        SwitchCase,
        SwitchDefault,
        Where,
        Dynamic
    }
}
