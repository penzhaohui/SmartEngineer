using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartEngineer.WCFService.Ext.Validators
{
    public class CustomUserNamePasswordValidatorcs : System.IdentityModel.Selectors.UserNamePasswordValidator
    {
        public override void Validate(string userName, string password)
        {
            if (userName == "peter.peng" && password == "peter.peng")
            {
            }
            else
            {
                throw new Exception("操作中的用户名，密码不正确！");
            }
        }
    }
}
