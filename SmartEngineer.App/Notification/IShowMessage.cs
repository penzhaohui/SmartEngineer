using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartEngineer.Notification
{
    public interface IShowMessage
    {
        void ShowMessage(string msg);
    }

    public class StatusBarMessager : IShowMessage
    {
        private ToolStripStatusLabel _label = null;

        public StatusBarMessager(ToolStripStatusLabel label)
        {
            _label = label;
        }

        public void ShowMessage(string msg)
        {
            _label.Text = msg;
            _label.Invalidate();

            Thread.Sleep(200);//用于演示效果.
        }
    }


    public class LabelMessager : IShowMessage
    {
        private Label _label = null;

        public LabelMessager(Label label)
        {
            _label = label;
        }

        public void ShowMessage(string msg)
        {
            _label.Text = msg;
            _label.Invalidate();

            Application.DoEvents();
            Thread.Sleep(200);//用于演示效果.
        }
    }
}
