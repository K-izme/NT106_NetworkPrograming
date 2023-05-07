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
using System.Runtime.Serialization.Formatters.Binary;

namespace Lab03_LTM
{
    public partial class MultiChat_Server : Form
    {
        IPEndPoint IP;
        Socket server;
        List<Socket> clientList;
        public MultiChat_Server()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            connect();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (Socket item in clientList)
            {
                sendMess(item);
            }
            addMess(textBox1.Text);
            textBox1.Clear();
        }
        void connect()
        {
            clientList = new List<Socket>();

            IP = new IPEndPoint(IPAddress.Any, 9999);
            server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            server.Bind(IP);

            Thread Listen = new Thread(() =>
            {
                try
                {
                    while (true)
                    {
                        server.Listen(100);
                        Socket client = server.Accept();
                        clientList.Add(client);
                        addMess(" New client connection from: " + client.RemoteEndPoint.ToString());
                        Thread receive = new Thread(receiveMess);
                        receive.IsBackground = true;
                        receive.Start(client);
                    }
                }
                catch
                {
                    IP = new IPEndPoint(IPAddress.Any, 9999);
                    server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);

                }
            });
            Listen.IsBackground = true;
            Listen.Start();

        }
        void receiveMess(object obj)
        {
            Socket client = obj as Socket;
            try
            {
                while (true)
                {
                    byte[] data = new byte[1024 * 5000];
                    client.Receive(data);
                    string message = (string)Deserialize(data);

                    foreach (Socket item in clientList)
                    {
                        if (item != null && item != client)
                            item.Send(Serialize(message));

                    }

                    addMess(message);
                }
            }
            catch
            {
                clientList.Remove(client);
                client.Close();

            }
        }
        void addMess(string s)
        {
            listView1.Items.Add(new ListViewItem() { Text = DateTime.Now + s });
        }
        void sendMess(Socket client)
        {
            if (client != null && textBox1.Text != string.Empty)
                client.Send(Serialize("Server: "+textBox1.Text));
        }
        byte[] Serialize(object obj)
        {
            MemoryStream ms = new MemoryStream();
            BinaryFormatter bf = new BinaryFormatter();

            bf.Serialize(ms, obj);

            return ms.ToArray();
        }
        object Deserialize(byte[] data)
        {
            MemoryStream ms = new MemoryStream(data);
            BinaryFormatter bf = new BinaryFormatter();

            return bf.Deserialize(ms);
        }

        private void MultiChat_Server_FormClosed(object sender, FormClosedEventArgs e)
        {
            server.Close();
        }

        private void MultiChat_Server_FormClosing(object sender, FormClosingEventArgs e)
        {
            server.Close();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
