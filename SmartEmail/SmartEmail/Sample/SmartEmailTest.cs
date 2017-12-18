using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartEmail.Sample
{
    public partial class SmartEmailTest : Form
    {
        public SmartEmailTest()
        {
            InitializeComponent();

            rdbSample1.Checked = true;
            chkReuseSmtpClient.Checked = true;
            cmbEmailCount.SelectedIndex = 0;

        }

        private void btnChooseAttachment_Click(object sender, EventArgs e)
        {
            Button btnSender = (Button)sender;
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Multiselect = true;
            fileDialog.InitialDirectory = Application.StartupPath + "\\Attachement";
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                if (fileDialog.FileNames.Length > 0)
                {
                    foreach (string filePath in fileDialog.FileNames)
                    {
                        if ("btnChooseAttachment1" == btnSender.Name)
                        {
                            txtAttachment1.Text = filePath;
                        }

                        if ("btnChooseAttachment2" == btnSender.Name)
                        {
                            txtAttachment2.Text = filePath;
                        }

                        if ("btnChooseAttachment3" == btnSender.Name)
                        {
                            txtAttachment3.Text = filePath;
                        }
                    }
                }
            }
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {

        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            string host = this.txtHost.Text;
            int port = int.Parse(this.txtPort.Text);
            string from = this.txtFrom.Text;
            string password = this.txtPassword.Text;
            string content = this.rtbContent.Text;

            string toAddressList = this.txtTo.Text;
            string ccAddressList = this.txtCC.Text;
            string bccAddressList = this.txtBCC.Text;
            string subject = this.txtSubject.Text;

            bool enableAsyc = chkEnableAsyc.Checked;
            bool reuseSmtpClient = chkReuseSmtpClient.Checked;
            int emailCount = 0;
            if (cmbEmailCount.SelectedIndex >= 0)
            {
                emailCount = int.Parse(cmbEmailCount.SelectedItem as string);
            }

            bool isAsyc = this.chkEnableAsyc.Checked;
            bool isResue = this.chkReuseSmtpClient.Checked;

            IEmailClient emailClient = new EmailClient();
            emailClient = emailClient.Initialized(host, port, true, true, from, password)
                                     .SetTimeout(100000)
                                     .SetDeliveryMethod(0);

            IEmailMessage emailMessage = emailClient.NewEmailMessage<EmailMessage>();
            emailMessage.SetSubject(subject + (isAsyc ? " [Asyc]" : ""), Encoding.UTF8)
                        .SetContent(content, true, Encoding.UTF8)
                        .SetSender(from, "")                        
                        .SetPriority(System.Net.Mail.MailPriority.High);

            string[] toAddresses = toAddressList.Split(';');
            foreach (string toAddress in toAddresses)
            {
                emailMessage.AppendToAddress(toAddress, "");
            }

            string[] ccAddresses = ccAddressList.Split(';');
            foreach (string ccAddress in ccAddresses)
            {
                emailMessage.AppendToAddress(ccAddress, "");
            }

            string[] bccAddresses = bccAddressList.Split(';');
            foreach (string bccAddress in bccAddresses)
            {
                emailMessage.AppendToAddress(bccAddress, "");
            }

            string attachment1 = this.txtAttachment1.Text;
            if (!String.IsNullOrEmpty(attachment1))
            {                
                emailMessage.AppendInlineAttachment(attachment1, "attachment1");
                emailMessage.SetContent(content + "<br/><img src =\"cid:attachment1\" /><a href=\"cid:attachment1\" target=\"_blank\">点击在新窗口打开图片</a>", true, Encoding.UTF8);
            }

            string attachment2 = this.txtAttachment2.Text;
            if (!String.IsNullOrEmpty(attachment2))
            {
                emailMessage.AppendAttachment(attachment2, "attachment2");
            }

            string attachment3 = this.txtAttachment3.Text;
            if (!String.IsNullOrEmpty(attachment3))
            {
                emailMessage.AppendAttachment(attachment3, "attachment3");
            }

            if (rdbSample1.Checked)
            {
                #region 实验一

                if (isAsyc)
                {
                    emailClient.SendAsync(emailMessage);
                }
                else
                {
                    emailClient.Send(emailMessage);
                }

                #endregion
            }
            else if (rdbSample2.Checked)
            {
                #region 实验二

                for (int i = 1; i <= emailCount; i++)
                {
                    if (i % 2 == 0)
                    {
                        emailMessage.AppendToAddress("peter.peng@missionsky.com", "");
                    }
                    else
                    {
                        emailMessage.AppendToAddress("451127509@qq.com", "");
                    }
                }

                if (isAsyc)
                {
                    emailClient.SendAsync(emailMessage);
                }
                else
                {
                    emailClient.Send(emailMessage);
                }

                #endregion
            }
            else if (rdbSample3.Checked)
            {
            }
            else if (rdbSample4.Checked)
            {
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {

        }
    }
}
