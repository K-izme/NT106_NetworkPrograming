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

namespace Lab5_LTM
{
    public partial class Bai2 : Form
    {
        public Bai2()
        {
            InitializeComponent();
        }

        private void logBut_Click(object sender, EventArgs e)
        {
            try
            {
                using (var imapClient = new ImapClient())
                {
                    imapClient.Connect("127.0.0.1", 143, SecureSocketOptions.None);
                    imapClient.Authenticate(mailBox.Text.ToString().Trim(), passBox.Text.ToString().Trim());
                    var inbox = imapClient.Inbox;
                    inbox.Open(FolderAccess.ReadOnly);
                    label3.Text += inbox.Count.ToString();
                    label4.Text += inbox.Recent.ToString();
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
                    imapClient.Disconnect(true);
                    MessageBox.Show("Get data successfully");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Bai2_Load(object sender, EventArgs e)
        {

        }
    }
}
