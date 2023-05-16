using System.Net.Sockets;
using System.Net;
using System.Security.Cryptography;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using System;
using MessageLibrary;

namespace ECDH_Client
{
    public partial class Client : Form
    {
        public enum Adder { Client, Server };
        private bool isConnect = false;
        private readonly int _maxBuffer = 1024; //1024 Byte
        private bool isAccept = false;
        Thread thClient;
        Socket server;
        IPEndPoint ipE; //IP endpoint
        Socket client;

        private ECDiffieHellmanCng DiffieHellman;
        private byte[] key;
        public Client()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            autoGetIP();
        }
        private void Connect()
        {
            connectButton.Text = "DISCONNECT";
            ipBox.Enabled = false;
            isConnect = true;

        }

        private void Disconnect()
        {
            connectButton.Text = "CONNECT";
            ipBox.Enabled = true;
            isConnect = false;

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
        private void AddLog(string msg)
        {
            rtbLog.Invoke(new MethodInvoker(delegate ()
            {
                rtbLog.AppendText("[" + DateTime.Now + "]" + Environment.NewLine + msg + Environment.NewLine);
            }));
        }
        //get IP function
        public void autoGetIP()
        {
            IPHostEntry host = Dns.GetHostEntry(Dns.GetHostName());

            foreach (IPAddress addr in host.AddressList)
            {
                if (addr.AddressFamily == AddressFamily.InterNetwork)
                {
                    ipBox.Text = addr.ToString();
                }
            }

        }
        private void connectButton_Click(object sender, EventArgs e)
        {
            bool isExcept = false;
            if (!isConnect)
            {
                //Start check exception
                IPAddress ipDes;
                int portDes;
                if (!IPAddress.TryParse(ipBox.Text, out ipDes))
                {
                    isExcept = true;
                    MessageBox.Show("Invalid IP Address");
                }

                if (int.TryParse(portBox.Text, out portDes))
                {
                    if (portDes <= 0 || portDes >= 65535)
                    {
                        isExcept = true;
                        MessageBox.Show("Invalid Port");
                    }
                }
                else
                {
                    isExcept = true;
                    MessageBox.Show("Invalid Port");
                }
                //end check exception

                //Connect
                if (!isExcept)
                {
                    if (Connect(ipDes, portDes))
                    {
                        AddLog("Connected to server." + ipDes.ToString() + ":" + portDes.ToString());
                        isConnect = true;
                        DiffieHellman = new ECDiffieHellmanCng();
                        DiffieHellman.KeyDerivationFunction = ECDiffieHellmanKeyDerivationFunction.Hash;
                        DiffieHellman.HashAlgorithm = CngAlgorithm.Sha256;
                        thClient = new Thread(Listen);
                        thClient.IsBackground = true;
                        thClient.Start(client);
                    }
                    else
                    {
                        AddLog("Cannot connect to Server " + ipDes.ToString() + ":" + portDes.ToString());
                    }
                }
            }
            else
            {
                //Disconnect
                Disconnect();
                CloseConnect();
            }
        }
        private bool Connect(IPAddress ip, int port)
        {
            try
            {

                ipE = new IPEndPoint(ip, port);
                client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                client.Connect(ipE);
            }
            catch (SocketException e)
            {
                AddLog(e.Message);
                return false;
            }
            return true;
        }
        public void Listen(object obj)
        {
            Socket sk = (Socket)obj;
            try
            {
                while (true)
                {
                    byte[] buff = new byte[1024];
                    int recv = sk.Receive(buff);
                    if (recv == 0) break;
                    receiveMess(buff);
                }
            }
            catch (SocketException)
            {
                AddLog("Sever is Closed!");
                Disconnect();
                CloseConnect();
                key = null;
                return;
            }

        }
        private void receiveMess(byte[] buff)
        {
            MessStruct msgStr = Deserialize(buff);

            switch (msgStr.mode)
            {
                case 0:
                    key = DiffieHellman.DeriveKeyMaterial(CngKey.Import(msgStr.msg, CngKeyBlobFormat.EccPublicBlob));

                    AddLog("Received key from Server");
                    sendMess("Real key", 0); //send pub key
                    Connect();
                    break;
                case 1:
                    while (key == null) ;
                    msgStr.Decrypt(key);
                    addMess(msgStr.GetString(), Adder.Server);
                    break;
            }
        }
        private void sendMess(string msg, int mode = 1)
        {
            MessStruct msgStr = new MessStruct(msg);
            if (mode == 0)
            {
                try
                {
                    msgStr.msg = DiffieHellman.PublicKey.ToByteArray();
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Close();
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
        private void addMess(string msg, Adder adder)
        {
            rtbMess.AppendText("[" + DateTime.Now + "] " + msg);
            rtbMess.AppendText(Environment.NewLine);
            rtbMess.ScrollToCaret();
        }
        private void CloseConnect()
        {
            isConnect = false;
            if (!thClient.Join(TimeSpan.FromSeconds(60)))
            {
                thClient.Interrupt();
                thClient.Join();
            }
            client.Close();

        }

        private void sendButton_Click(object sender, EventArgs e)
        {
            string msg = "Client: " + messBox.Text + Environment.NewLine;
            sendMess(msg);
            addMess(msg, Adder.Client);
            messBox.Clear();
        }
    }
}