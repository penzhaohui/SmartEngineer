using System;
using SmartEngineer.Core.Model.Common;
using SmartSql;
using SmartSql.Abstractions;
using SmartSQL;
using System.Collections.Generic;

namespace SmartEngineer.Core.DAOs
{
    public class IDStoreDAO<T> : BaseDAO<T>, IIDStoreDAO<T>
        where T : IDStore
    {
        public override string TableName
        {
            get
            {
                return "sys_IDStore";
            }
        }

        public override string Scope
        {
            get
            {
                return "IDStore";
            }
        }

        public int Update(T entity, long lastNumber, DateTime lastTime)
        {
            Dictionary<string, object> additionalParams = new Dictionary<string, object>();
            additionalParams.Add("OldLastNumber", lastNumber);
            additionalParams.Add("OldLastTime", lastTime);

            dynamic objRequest = new System.Dynamic.ExpandoObject();
            foreach (KeyValuePair<string, object> param in additionalParams)
            {
                ((IDictionary<string, object>)objRequest).Add(param.Key, param.Value);
            }

            System.Reflection.PropertyInfo[] properties = entity.GetType().GetProperties(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public);

            if (properties.Length > 0)
            {
                foreach (System.Reflection.PropertyInfo item in properties)
                {
                    string name = item.Name;
                    object value = item.GetValue(entity, null);

                    if (item.PropertyType.IsValueType || item.PropertyType.Name.StartsWith("String", StringComparison.InvariantCultureIgnoreCase))
                    {
                        ((IDictionary<string, object>)objRequest).Add(name, value);
                    }
                }
            }

            return SQLMapper.Execute(new RequestContext
            {
                Scope = this.Scope,
                SqlId = DefaultSqlId.Update,
                Request = objRequest
            });
        }
    }
}
