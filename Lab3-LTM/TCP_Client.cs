using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab03_LTM
{
    public partial class TCP_Client : Form
    {
        IPEndPoint IPEP;
        TcpClient tcpClient;
        Stream ns;
        public TCP_Client()
        {
            InitializeComponent();
            // CheckForIllegalCrossThreadCalls = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            send();
        }

        void StartConnect()
        {

            // Prefer a using declaration to ensure the instance is Disposed later.
            this.IPEP = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8080);
            this.tcpClient = new TcpClient();
            this.tcpClient.Connect(IPEP);
            this.ns = tcpClient.GetStream();

        }
        void send()
        {
            Byte[] data = Encoding.ASCII.GetBytes("Hello server\n");
            ns.Write(data, 0, data.Length);

        }
        void closeConnect()
        {
            Byte[] data = System.Text.Encoding.UTF8.GetBytes("Stop\n");
            this.ns.Write(data, 0, data.Length);
            this.ns.Close();
            this.tcpClient.Close();

        }

        private void TCP_Client_Load(object sender, EventArgs e)
        {
            StartConnect();
        }


        private void TCP_Client_FormClosed(object sender, FormClosedEventArgs e)
        {
            closeConnect();
        }
    }
}

