using System;
using System.Windows.Forms;

namespace SmartEngineer.Notification
{
    public class SystemMessageBox
    {
        public static bool Confirm(string msg)
        {
            DialogResult r;
            r = MessageBox.Show(msg, "Confirm",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2);
            return (r == DialogResult.Yes);
        }

        public static void ShowException(Exception e)
        {
            string s = e.Message;
            string innerMsg = string.Empty;

            if (e.InnerException != null)
            {
                innerMsg = e.InnerException.Message;
                s += "\n" + innerMsg;
            }

            ShowWarning(s);
        }

        public static void ShowWarning(string msg)
        {
            MessageBox.Show(msg, "Waring",
                MessageBoxButtons.OK,
                MessageBoxIcon.Exclamation,
                MessageBoxDefaultButton.Button1);
        }

        public static void ShowError(string msg)
        {
            MessageBox.Show(msg, "Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Hand,
                MessageBoxDefaultButton.Button1);
        }

        public static void ShowInformation(string msg)
        {
            MessageBox.Show(msg, "Info",
                MessageBoxButtons.OK,
                MessageBoxIcon.Asterisk,
                MessageBoxDefaultButton.Button1);
        }
    }
}
