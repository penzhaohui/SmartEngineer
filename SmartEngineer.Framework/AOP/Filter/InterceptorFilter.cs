using Castle.DynamicProxy;
using System;
using System.Reflection;

namespace SmartEngineer.Framework.AOP.Filter
{
    public class InterceptorFilter : IProxyGenerationHook
    {
        public void MethodsInspected()
        {
        }

        public void NonProxyableMemberNotification(Type type, MemberInfo memberInfo)
        {
        }

        public bool ShouldInterceptMethod(Type type, MethodInfo methodInfo)
        {
            System.Console.WriteLine($"Type: {type.FullName}");
            System.Console.WriteLine($"Menthod: {methodInfo.Name}");
            return true;
        }
    }
}
