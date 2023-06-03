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
            using (SmtpClient client = new SmtpClient("127.0.0.1"))
            {
                string mailFrom = fromBox.Text.ToString().Trim();
                string mailTo = toBox.Text.ToString().Trim();
                string pass = passBox.Text.ToString().Trim();
                var basicCredential = new NetworkCredential(mailFrom, pass);
                using (MailMessage mailMessage = new MailMessage())
                {
                    MailAddress fromAdd = new MailAddress(mailFrom);
                    client.UseDefaultCredentials = false;
                    client.Credentials = basicCredential;

                    mailMessage.From = fromAdd;
                    mailMessage.Subject = subBox.Text.ToString().Trim();
                    mailMessage.IsBodyHtml = true;
                    mailMessage.Body = rtbBody.Text.ToString();
                    mailMessage.To.Add(mailTo);

                    try
                    {
                        client.Send(mailMessage);
                        MessageBox.Show("Mail sent!");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void Bai1_Load(object sender, EventArgs e)
        {

        }
    }
}