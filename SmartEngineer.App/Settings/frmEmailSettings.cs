using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SmartEngineer.Notification;

namespace SmartEngineer.Forms
{
    public partial class frmEmailSettings : Form, IBasicForm
    {
        public frmEmailSettings()
        {
            InitializeComponent();
        }

        public string FormName => throw new NotImplementedException();

        public void InitUserInterface(IShowMessage messager)
        {
            throw new NotImplementedException();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
            this.Close(); 
        }

        private void btnOk_Click(object sender, EventArgs e)
        {

        }
    }
}
