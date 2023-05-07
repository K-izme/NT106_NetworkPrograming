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
    public partial class MultiChat_Client : Form
    {
        IPEndPoint IP;
        Socket client;
        public MultiChat_Client()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            connectServer();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            sendMess();
            addMess(textBox1.Text);
        }
        void connectServer()
        {
            TcpClient ex = new TcpClient();
            IP = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 9999);
            client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                client.Connect(IP);
            }
            catch
            {
                MessageBox.Show("Can not create a connection!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Thread listen = new Thread(receiveMess);
            listen.IsBackground = true;
            listen.Start();

        }
        void receiveMess()
        {
            try
            {
                while (true)
                {
                    byte[] data = new byte[1024 * 5000];
                    client.Receive(data);
                    string message = (string)Deserialize(data);
                    addMess(message);
                }
            }
            catch
            {
                Close();
            }
        }
        void addMess(string s)
        {
            try
            {
                if (String.IsNullOrEmpty(textBox2.Text))
                {
                    throw new Exception();
                }
                else
                {
                    listView1.Items.Add(new ListViewItem() { Text = " " + DateTime.Now + " " + s });
                    textBox1.Clear();
                }
            }
            catch (Exception)
            {

            }

        }
        void sendMess()
        {
            try
            {
                if (String.IsNullOrEmpty(textBox2.Text))
                    throw new Exception();
                else
                    if (textBox1.Text != string.Empty)
                    client.Send(Serialize(" " + textBox2.Text + ": " + textBox1.Text));
            }
            catch (Exception)
            {
                MessageBox.Show("Please input your name", "Error", MessageBoxButtons.OK);
            }

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

        private void MultiChat_Client_FormClosed(object sender, FormClosedEventArgs e)
        {
            client.Close();
        }

        private void MultiChat_Client_Load(object sender, EventArgs e)
        {

        }
    }
}
