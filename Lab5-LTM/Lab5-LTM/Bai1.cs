using System.Net;
using System.Net.Mail;

namespace Lab5_LTM
{
    public partial class Bai1 : Form
    {
        public Bai1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (SmtpClient smptClient = new SmtpClient("127.0.0.1"))
            {
                string mailFrom = fromBox.Text.ToString().Trim();
                string mailTo = toBox.Text.ToString().Trim();
                string pass = passBox.Text.ToString().Trim();
                var basicCredential = new NetworkCredential(mailFrom, pass);
                using (MailMessage mailMessage = new MailMessage())
                {
                    MailAddress fromAdd = new MailAddress(mailFrom);
                    smptClient.UseDefaultCredentials = false;
                    smptClient.Credentials = basicCredential;

                    mailMessage.From = fromAdd;
                    mailMessage.Subject = subBox.Text.ToString().Trim();
                    mailMessage.IsBodyHtml = true;
                    mailMessage.Body = rtbBody.Text.ToString();
                    mailMessage.To.Add(mailTo);

                    try
                    {
                        smptClient.Send(mailMessage);
                        MessageBox.Show("Mail sent!");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }
            }
        }
    }
}