using Castle.DynamicProxy;
using System;

namespace SmartEngineer.Framework.AOP
{
    public class AuditLogInterceptor : IInterceptor
    {
        private int _indent = 0;

        private void PreProceed(IInvocation invocation)
        {
            if (this._indent > 0)
                Console.Write(" ".PadRight(this._indent * 4, ' '));
            this._indent++;
            Console.Write("Intercepting: " + invocation.Method.Name + "(");
            if (invocation.Arguments != null && invocation.Arguments.Length > 0)
                for (int i = 0; i < invocation.Arguments.Length; i++)
                {
                    if (i != 0) Console.Write(", ");
                    Console.Write(invocation.Arguments[i] == null
                    ? "null"
                    : invocation.Arguments[i].GetType() == typeof(string)
                    ? "\"" + invocation.Arguments[i].ToString() + "\""
                    : invocation.Arguments[i].ToString());
                }
            Console.WriteLine(")");
        }

        private void PostProceed(IInvocation invocation)
        {
            this._indent--;
        }

        public void Intercept(IInvocation invocation)
        {
            PreProceed(invocation);

            invocation.Proceed();

            PostProceed(invocation);
        }
    }
}
