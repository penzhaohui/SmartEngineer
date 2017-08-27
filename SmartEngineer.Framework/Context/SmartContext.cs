using System.Runtime.Remoting.Messaging;

namespace SmartEngineer.Framework.Context
{
    public sealed class SmartContext
    {
        public static string TenantID
        {
            get
            {
                return CallContext.GetData("TenantID") as string;
            }
            set
            {
                CallContext.SetData("TenantID", value);
            }
        }
    }
}
