using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab03_LTM
{
    public partial class UDPServer : Form
    {
        public UDPServer()
        {
            InitializeComponent();
        }

        void serverThread()
        {
            int port = Convert.ToInt16(textBox1.Text);
            UdpClient udpClient = new UdpClient(port);

            IPEndPoint remoteEP = new IPEndPoint(IPAddress.Any, 0);
            while (true)
            {
                byte[] receivedBytes = udpClient.Receive(ref remoteEP);
                string message = Encoding.UTF8.GetString(receivedBytes);
                string formattedMessage = $"{remoteEP.Address}: {message}\n";

                AppendText(richTextBox1, formattedMessage);
            }
        }

        private void AppendText(RichTextBox richTextBox, string text)
        {
            if (richTextBox.InvokeRequired)
            {
                richTextBox.Invoke(new Action<RichTextBox, string>(AppendText), richTextBox, text);
            }
            else
            {
                richTextBox.AppendText(text);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            textBox1.Enabled = false;
            CheckForIllegalCrossThreadCalls = false;
            Thread server_Thread = new Thread(new ThreadStart(serverThread));
            server_Thread.IsBackground = true;
            server_Thread.Start();
        }

    }
}
