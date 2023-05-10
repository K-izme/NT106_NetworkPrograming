using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab03_LTM
{
    public partial class ex2 : Form
    {
        Socket listenerSocket;
        Thread serverTh;
        Socket client;
        
        public ex2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = true;
            serverTh = new Thread(new ThreadStart(StartUnsafeThread));
            serverTh.Start();
            serverTh.IsBackground = true;

        }
        bool SocketConnected(Socket s)
        {
            bool part1 = s.Poll(1000, SelectMode.SelectRead);
            bool part2 = (s.Available == 0);
            if (part1 && part2)
                return false;
            else
                return true;
        }
        void StartUnsafeThread()
        {

            int byteReceive = 0;
            byte[] recv = new byte[1];
            listenerSocket = new Socket
                (
                AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp
                );
            IPEndPoint ipServer = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8080);
            listenerSocket.Bind(ipServer);
            listenerSocket.Listen(-1);
            client = listenerSocket.Accept();

            listView1.Invoke((MethodInvoker)(() => listView1.Items.Add(new ListViewItem("Telnet running on " + client.RemoteEndPoint))));
            while (client.Connected)
            {
                string text = "";
                do
                {
                    byteReceive = client.Receive(recv);
                    text += Encoding.ASCII.GetString(recv);
                }
                while (text[text.Length - 1] != '\n');
                listView1.Invoke((MethodInvoker)(() => listView1.Items.Add(new ListViewItem(text))));

                if (SocketConnected(client) == false)
                {
                    listView1.Invoke((MethodInvoker)(() => listView1.Items.Add(new ListViewItem("Disconnected"))));
                    listenerSocket.Close();
                    break;

                }
            }
         

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ex2_Load(object sender, EventArgs e)
        {

        }


        private void ex2_FormClosed(object sender, FormClosedEventArgs e)
        {
           
        }

        private void ex2_FormClosing(object sender, FormClosingEventArgs e)
        {
            listenerSocket.Close();
        }
    }
}
