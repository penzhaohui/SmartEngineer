﻿using System;
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
    public partial class frmRoles : Form, IBasicForm
    {
        public frmRoles()
        {
            InitializeComponent();
        }

        public string FormName => throw new NotImplementedException();

        public void InitUserInterface(IShowMessage messager)
        {
            throw new NotImplementedException();
        }
    }
}
