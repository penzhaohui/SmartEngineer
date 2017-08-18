using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartEngineer.ServiceClient.Enums
{
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name = "AccountType", Namespace = "http://schemas.datacontract.org/2004/07/SmartEngineer.Service.Model")]
    public enum AccountType : int
    {
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Normal = 0,

        [System.Runtime.Serialization.EnumMemberAttribute()]
        Jira = 1,
    }
}