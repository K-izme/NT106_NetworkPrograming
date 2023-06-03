using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Mime;

namespace Lab5_LTM
{
    public partial class SendMail : Form
    {
        public SendMail()
        {
            InitializeComponent();
        }

        public string mailUser { get; set; }

        public string Password { get; set; }

        private void SendMail_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (SmtpClient client = new SmtpClient("127.0.0.1"))
            {
                string mailFrom = mailUser.Trim();
                string mailTo = textBox1.Text.Trim();
                string pass = Password.Trim();
                var cre = new NetworkCredential(mailFrom, pass);
                using (MailMessage mailMessage = new MailMessage())
                {
                    MailAddress fromAdd = new MailAddress(mailFrom);
                    client.UseDefaultCredentials = false;
                    client.Credentials = cre;

                    mailMessage.From = fromAdd;
                    mailMessage.Subject = textBox2.Text.Trim();

                    //send by html
                    mailMessage.IsBodyHtml = true;
                    mailMessage.Body = richTextBox1.Text;

                    //send by plaintext to can show in body yeyeah
                    string plainTextContent = richTextBox1.Text;
                    AlternateView plainTextView = AlternateView.CreateAlternateViewFromString(plainTextContent, Encoding.UTF8, MediaTypeNames.Text.Plain);
                    mailMessage.AlternateViews.Add(plainTextView);

                    mailMessage.To.Add(mailTo);

                    try
                    {
                        client.Send(mailMessage);
                        MessageBox.Show("Mail sent!");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
