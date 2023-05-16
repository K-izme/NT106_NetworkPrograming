using System.Net.Sockets;
using System.Net;
using System.Security.Cryptography;
using System.Windows.Forms;
using System.Runtime.Serialization.Formatters.Binary;
using MessageLibrary;

namespace ECDH
{
    public partial class Server : Form
    {
        public enum Adder { Client, Server };
        private bool isConnect = false;
        private readonly int _maxBuffer = 1024; //1024 Byte
        private bool isAccept = false;
        Thread thListener;
        Socket server;
        IPEndPoint ipE; //IP endpoint
        Socket client;


        private ECDiffieHellmanCng DiffieHellman;
        private byte[] key;
        public Server()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            autoGetIP();
        }
        //Send - Receive Byte function
        private byte[] Serialize(MessStruct msgStr)
        {
            MemoryStream stream = new MemoryStream();
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(stream, msgStr);
            byte[] buff = new byte[_maxBuffer];
            return stream.ToArray();
        }

        private MessStruct Deserialize(byte[] buff)
        {
            MemoryStream stream = new MemoryStream(buff);
            BinaryFormatter bf = new BinaryFormatter();
            return (MessStruct)bf.Deserialize(stream);
        }
        //get IP function
        public void autoGetIP()
        {
            IPHostEntry host = Dns.GetHostEntry(Dns.GetHostName());

            foreach (IPAddress addr in host.AddressList)
            {
                if (addr.AddressFamily == AddressFamily.InterNetwork)
                {
                    ipBox.Items.Add(addr.ToString());
                }
            }

        }
        private void rtbMess_TextChanged(object sender, EventArgs e)
        {

        }

        private void ipBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void sendButton_Click(object sender, EventArgs e)
        {
            MessStruct msgStr = new MessStruct();
            string msg = "Server: " + messBox.Text + Environment.NewLine;
            sendMess(msg);
            addMess(msg, Adder.Server);
            messBox.Text = string.Empty;
        }
        //send - receive message
        private void addMess(string msg, Adder adder)
        {
            rtbMes.AppendText("[" + DateTime.Now + "] " + msg);
            rtbMes.AppendText(Environment.NewLine);
            rtbMes.ScrollToCaret();
        }
        private void sendMess(string msg, int mode = 1)
        {
            MessStruct msgStr = new MessStruct(msg);
            if (mode ==0)
            {
                try
                {
                    msgStr.msg = DiffieHellman.PublicKey.ToByteArray();
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                    return;
                }
            }
            else
            {
                msgStr.Encrypt(key);
            }

            msgStr.mode = mode;
            client.Send(Serialize(msgStr));
        }
        //show how the program is running
        private void AddLog(string msg)
        {
            rtbLog.Invoke(new MethodInvoker(delegate ()
            {
                rtbLog.AppendText("[" + DateTime.Now + "]" + Environment.NewLine + msg + Environment.NewLine);
            }));
        }

        private void connectButton_Click(object sender, EventArgs e)
        {
            if (!isConnect)
            {
                if (Listen())
                {
                    DiffieHellman = new ECDiffieHellmanCng();
                    DiffieHellman.KeyDerivationFunction = ECDiffieHellmanKeyDerivationFunction.Hash;
                    DiffieHellman.HashAlgorithm = CngAlgorithm.Sha256;
                    connectButton.Enabled = false;
                    isConnect = true;
                    ipBox.Enabled = false;
                    portBox.Enabled = false;
                    connectButton.Text = "Connecting";
                    AddLog("Port opened:" + portBox.Text);
                }
                else
                {
                    MessageBox.Show("Can not connect.");
                }
            }
            else
            {
                isConnect = false;
                connectButton.Text = "CONNECT";
                ipBox.Enabled = true;
                portBox.Enabled = true;
                if (!thListener.Join(TimeSpan.FromSeconds(60)))
                {
                    thListener.Interrupt();
                    thListener.Join();
                }
                server.Shutdown(SocketShutdown.Both);
                server.Disconnect(false);
                server.Close();
            }
        }
        private bool Listen()
        {
            try
            {
                IPAddress ip;
                int port;
                try
                {
                    ipBox.SelectedItem.ToString();
                }
                catch (Exception)
                {
                    MessageBox.Show("IP is missing", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                if (!IPAddress.TryParse(ipBox.SelectedItem.ToString(), out ip))
                {
                    MessageBox.Show("Invalid IP");
                    return false;
                }

                if (!Int32.TryParse(portBox.Text.Trim(), out port))
                {
                    MessageBox.Show("Invalid Port");
                    return false;
                }

                if (port <= 0 || port >= 65535)
                {
                    MessageBox.Show("Invalid Port");
                    return false;
                }

                ipE = new IPEndPoint(ip, port);

                server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                thListener = new Thread(new ThreadStart(Listener));
                thListener.IsBackground = true;
                thListener.Start();
            }
            catch (SocketException)
            {
                return false;
            }
            return true;
        }
        public void Listener()
        {
            server.Bind(ipE);
            server.Listen(1);
            try
            {
                while (true)
                {
                    if (isAccept == false)
                    {

                        client = server.Accept();
                        isAccept = true;
                        AddLog("Connection accepted from: " + client.RemoteEndPoint.ToString());
                        sendMess("Thisiskey", 0); //send private message
                        Thread clientProccess = new Thread(threadClient);
                        clientProccess.IsBackground = true;
                        clientProccess.Start(client);

                    }
                }
            }
            catch
            {
                server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            }

        }
        public void threadClient(Object obj)
        {
            if (!isConnect) return;
            Socket skClient = (Socket)obj;
            bool isWhile = true;

            try
            {
                while (isWhile)
                {
                    byte[] buff = new byte[1024];
                    int recv = skClient.Receive(buff);
                    string msg;
                    if (recv == 0)
                    {
                        AddLog(skClient.RemoteEndPoint.ToString() + " Disconnected.");
                        isAccept = false;
                        sendButton.Hide();
                        break;
                    }
                    MessStruct msgStr = Deserialize(buff);
                    switch (msgStr.mode)
                    {
                        case 0: //Key exchange
                            key = DiffieHellman.DeriveKeyMaterial(CngKey.Import(msgStr.msg, CngKeyBlobFormat.EccPublicBlob));
                            AddLog("Key received from client");
                            msg = "Server: We are connected " + client.RemoteEndPoint.ToString() + Environment.NewLine;
                            addMess(msg, Adder.Server);
                            sendMess(msg);
                            sendButton.Show();

                            break;
                        case 1:
                            while (key == null) ;
                            msgStr.Decrypt(key);
                            addMess(msgStr.GetString(), Adder.Client);
                            break;
                    }
                }
            }
            catch (SocketException)
            {
                AddLog(skClient.RemoteEndPoint.ToString() + " disconnected.");
                isAccept = false;
                sendButton.Hide();
                isWhile = false;
                key = null;
                return;
            }
        }

        private void rtbMes_TextChanged(object sender, EventArgs e)
        {

        }
    }

}