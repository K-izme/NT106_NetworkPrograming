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

namespace Lab03_LTM
{
    public partial class TCP_Server : Form
    {
        public TCP_Server()
        {
            InitializeComponent();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        void StartUnsafeThread()
        {

            int byteReceive = 0;
            byte[] recv = new byte[1];
            Socket client;
            Socket listenerSocket = new Socket
                (
                AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp
                );
            IPEndPoint ipServer = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8080);
            listView1.Invoke((MethodInvoker)(() => listView1.Items.Add(new ListViewItem("Server running on 127.0.0.1:8080"))));
            listView1.Invoke((MethodInvoker)(() => listView1.Items.Add(new ListViewItem("New client connected"))));

            listenerSocket.Bind(ipServer);
            listenerSocket.Listen(-1);
            client = listenerSocket.Accept();


            while (client.Connected)
            {
                string text = "";
                do
                {
                    byteReceive = client.Receive(recv);
                    text += Encoding.ASCII.GetString(recv);
                } while (text[text.Length - 1] != '\n');

                if (text == "Stop\n")
                    {
                    listView1.Items.Add(new ListViewItem("Disconnected"));
                    break;
                    }
                listView1.Items.Add(new ListViewItem(text));

            }
            listenerSocket.Close();


        }
        private void button1_Click(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
            Thread serverTh = new Thread(new ThreadStart(StartUnsafeThread));
            serverTh.Start();
            serverTh.IsBackground = true;
        }

        private void TCP_Server_Load(object sender, EventArgs e)
        {

        }
    }
}
