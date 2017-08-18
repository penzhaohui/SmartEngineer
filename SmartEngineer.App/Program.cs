using SmartEngineer.Forms;
using SmartEngineer.Notification;
using System;
using System.Windows.Forms;

namespace SmartEngineer
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(Application_ThreadException);

            //首先打开登陆窗体,登陆成功后初始化MDI主窗体
            if (frmLogin.Login())
            {
                frmMain.CurrentMainForm.Show();//显示主窗体
                Application.Run();
            }
            else
            {
                //登录失败,退出程序
                Application.Exit();
            }
        }

        /// <summary>
        /// 应用程序异常处理
        /// </summary>
        private static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            SystemMessageBox.ShowException(e.Exception);
        }
    }
}
