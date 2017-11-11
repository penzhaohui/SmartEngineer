using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SmartEngineer.Framework.AOP.Selector
{
    public class InterceptorSelector : IInterceptorSelector
    {
        public IInterceptor[] SelectInterceptors(Type type, MethodInfo method, IInterceptor[] interceptors)
        {
            if (method.Name.StartsWith("set_"))
            {
                return interceptors;
            }
            else
            {
                return interceptors.Where(c => c is AuditLogInterceptor).ToArray();
            }
        }
    }
}
