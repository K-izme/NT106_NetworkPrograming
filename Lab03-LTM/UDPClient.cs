using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.CodeDom;

namespace Lab03_LTM
{
    public partial class UDPClient : Form
    {
        public UDPClient()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            UdpClient udpClient = new UdpClient();
            int port = Convert.ToInt16(textBox2.Text);
            string IP = textBox1.Text;
            IPEndPoint IPEP = new IPEndPoint(IPAddress.Parse(IP), port);


            Byte[] BytesSend = Encoding.UTF8.GetBytes(richTextBox1.Text);

            udpClient.Send(BytesSend, BytesSend.Length, IPEP);
        }

        private void UDPClient_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
        }

        private void UDPClient_Load_1(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
