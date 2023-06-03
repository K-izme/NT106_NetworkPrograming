using MailKit.Net.Imap;
using MailKit.Security;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Security;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Lab5_LTM
{
    public partial class Bai3 : Form
    {

        public Bai3()
        {
            InitializeComponent();
        }

        public ImapClient client;
        public string name;
        public string password;

        private void Bai3_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                name = textBox1.Text.Trim();
                password = textBox2.Text.Trim();
                client = new ImapClient();
                client.Connect("127.0.0.1", 143, SecureSocketOptions.None);
                client.Authenticate(name, password);
                MailView mailView = new MailView();
                mailView.mailUser = textBox1.Text;
                mailView.Password = textBox2.Text;
                mailView.Show();
                MessageBox.Show("Login Successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
