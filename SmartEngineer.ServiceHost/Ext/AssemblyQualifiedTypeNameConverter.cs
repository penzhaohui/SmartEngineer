using System;
using System.Configuration;
using System.ComponentModel;
using System.Globalization;

namespace SmartEngineer.Ext
{
    public class AssemblyQualifiedTypeNameConverter : ConfigurationConverterBase
    {
        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            string typeName = (string)value;
            if (string.IsNullOrEmpty(typeName))
            {
                return null;
            }

            Type result = Type.GetType(typeName, false);
            if (result == null)
            {
                throw new ArgumentException($"Cannot load the type {typeName}");
            }

            return result;
        }

        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            Type type = value as Type;
            if (null == type)
            {
                throw new ArgumentNullException($"invalid type:{value}");
            }

            return type.AssemblyQualifiedName;
        }
    }
}
