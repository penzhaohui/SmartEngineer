using Castle.DynamicProxy;
using SmartEngineer.Framework.Cache;
using SmartEngineer.Framework.IoC;
using System;
using System.Diagnostics;

namespace SmartEngineer.Framework.AOP
{
    public class AuditLogInterceptor : IInterceptor
    {
        public static readonly ICacheProvider Cache = new DictionaryProvider();

        private int _indent = 0;

        private void PreProceed(IInvocation invocation)
        {
            if (this._indent > 0)
                Console.Write(" ".PadRight(this._indent * 4, ' '));
            this._indent++;
            Console.Write("Intercepting: " + invocation.Method.Name + "(");
            if (invocation.Arguments != null && invocation.Arguments.Length > 0)
            {
                for (int i = 0; i < invocation.Arguments.Length; i++)
                {
                    if (i != 0) Console.Write(", ");
                    Console.Write(invocation.Arguments[i] == null
                    ? "null"
                    : invocation.Arguments[i].GetType() == typeof(string)
                    ? "\"" + invocation.Arguments[i].ToString() + "\""
                    : invocation.Arguments[i].ToString());
                }
            }
            Console.WriteLine(")");
        }

        private void PostProceed(IInvocation invocation)
        {
            //invocation.Method;
            //invocation.Arguments;
            //invocation.ReturnValue;

            this._indent--;
        }

        public void Intercept(IInvocation invocation)
        {
            PreProceed(invocation);

            string key = invocation.Method.Name + "(";
            if (invocation.Arguments != null && invocation.Arguments.Length > 0)
            {
                for (int i = 0; i < invocation.Arguments.Length; i++)
                {
                    if (i != 0) Console.Write(", ");
                    if (invocation.Arguments[i] == null)
                    {
                        key += "null";
                    }
                    else if (invocation.Arguments[i].GetType().IsValueType)
                    {
                        key += invocation.Arguments[i].ToString();
                    }
                    else if (invocation.Arguments[i].GetType() == typeof(string))
                    {
                        key += "\"" + invocation.Arguments[i].ToString() + "\"";
                    }
                    else
                    {
                        key += invocation.Arguments[i].ToString();
                    }
                }
            }
            key += ")";

            if (Cache.Exists(key))
            {
                invocation.ReturnValue = Cache.Get(key);
            }
            else
            {
                // C#计算一段程序运行时间的三种方法
                // http://blog.csdn.net/xzjxylophone/article/details/6832160
                Stopwatch sw = new Stopwatch();
                sw.Start();

                invocation.Proceed();

                sw.Stop();
                TimeSpan ts = sw.Elapsed;
                Console.WriteLine($"Execute the function {invocation.Method.Name} totally spent: {ts.TotalMilliseconds} milliseconds.");

                if (ts.TotalMilliseconds > 500)
                {
                    Cache.Add(invocation.ReturnValue, key, 5);
                }
            }

            PostProceed(invocation);
        }
    }
}
