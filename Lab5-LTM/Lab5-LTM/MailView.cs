using MailKit.Net.Imap;
using MailKit.Security;
using MailKit;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using MimeKit;

namespace Lab5_LTM
{
    public partial class MailView : Form
    {
        private ImapClient client;
        public MailView()
        {
            InitializeComponent();
        }
        public string mailUser { get; set; }

        public string Password { get; set; }

        private void MailView_Load(object sender, EventArgs e)
        {
            try
            {
                client = new ImapClient();
                client.Connect("127.0.0.1", 143, SecureSocketOptions.None);
                client.Authenticate(mailUser.Trim(), Password.Trim());
                var inbox = client.Inbox;
                inbox.Open(FolderAccess.ReadOnly);
                textBox1.Text = inbox.Count.ToString();
                textBox2.Text = inbox.Recent.ToString();
                listView1.Columns.Add("Email", 200);
                listView1.Columns.Add("From", 100);
                listView1.Columns.Add("Time", 200);
                listView1.View = View.Details;
                for (int i = 0; i < inbox.Count; i++)
                {
                    var message = inbox.GetMessage(i);
                    ListViewItem name = new ListViewItem(message.Subject);
                    ListViewItem.ListViewSubItem from = new ListViewItem.ListViewSubItem(name, message.From.ToString());
                    name.SubItems.Add(from);
                    ListViewItem.ListViewSubItem date = new ListViewItem.ListViewSubItem(name, message.Date.ToString());
                    name.SubItems.Add(date);
                    listView1.Items.Add(name);
                }
                client.Disconnect(true);
                listView1.SelectedIndexChanged += listView1_SelectedIndexChanged;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                var selectedEmail = listView1.SelectedItems[0];
                string subject = selectedEmail.SubItems[0].Text;
                string from = selectedEmail.SubItems[1].Text;
                string date = selectedEmail.SubItems[2].Text;

                int selectedIndex = listView1.SelectedItems[0].Index;

                using (var client = new ImapClient())
                {
                    client.Connect("127.0.0.1", 143, SecureSocketOptions.None);
                    client.Authenticate(mailUser.Trim(), Password.Trim());
                    var inbox = client.Inbox;
                    inbox.Open(FolderAccess.ReadOnly);
                    var message = inbox.GetMessage(selectedIndex);
                    client.Disconnect(true);

                    //Display plaintext 
                    MessageBox.Show($"Subject: {subject}\nFrom: {from}\nDate: {date}\n\nBody:\n{message.TextBody}");
                }
            }
        }


        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SendMail sendMail = new SendMail();
            sendMail.mailUser = this.mailUser;
            sendMail.Password = this.Password;
            sendMail.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
