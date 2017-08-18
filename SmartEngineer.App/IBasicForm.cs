using SmartEngineer.Notification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartEngineer
{
    public interface IBasicForm
    {
        string FormName { get; }
        void InitUserInterface(IShowMessage messager);
    }
}
