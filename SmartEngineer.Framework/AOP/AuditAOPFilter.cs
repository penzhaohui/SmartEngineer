using KingAOP.Aspects;
using System;

namespace SmartEngineer.Framework.AOP
{
    public class AuditAOPFilter : OnMethodBoundaryAspect
    {
        public override void OnEntry(MethodExecutionArgs args)
        {
            Console.WriteLine("call-------->AopFilter------>OnEntry");
            base.OnEntry(args);
        }

        public override void OnExit(MethodExecutionArgs args)
        {
            Console.WriteLine("call-------->AopFilter------>OnExit");
            base.OnException(args);
        }

        public override void OnSuccess(MethodExecutionArgs args)
        {
            Console.WriteLine("call-------->AopFilter------>OnSuccess");
            base.OnException(args);
        }

        public override void OnException(MethodExecutionArgs args)
        {
            Console.WriteLine("call-------->AopFilter------>OnException");
            base.OnException(args);
        }
    }
}
