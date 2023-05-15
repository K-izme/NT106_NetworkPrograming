using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Numerics;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace Key_Exchange
{


    public partial class Server : Form
    {
        int pp;
        BigInteger pb;
        BigInteger pk;
        TcpListener server = null;
        Socket client;
        ECDH exchangeAg;
        bool EnableEncryption = false;
        public Server(string ip, int port, string Mode, string public_big_num, string public_prime_key, string private_key)
        {
            InitializeComponent();

            server = new TcpListener(System.Net.IPAddress.Parse(ip), port);

            pp = Int32.Parse(Int32.Parse(public_prime_key, System.Globalization.NumberStyles.HexNumber).ToString());
            pb = BigInteger.Parse(public_big_num, System.Globalization.NumberStyles.HexNumber);
            pk = BigInteger.Parse(private_key, System.Globalization.NumberStyles.HexNumber);

            var server_thread = new Thread(() => openConnection());
            server_thread.Start();

        }
        private void openConnection()
        {
            Thread.Sleep(250);
            while (true)
            {
                PrintLine("Starting server listener...\n");
                PrintLine("Waiting for connections...\n");
                server.Start();
                client = server.AcceptSocket();
                PrintLine("Connection accepted...\n");
                PrintLine("Sending secure connection data...\n");
                server.Stop();

                var childSocketThread = new Thread(() => Client());
                childSocketThread.Start();

            }
        }
        private void Client()
        {


            exchangeAg = new ECDH(pp, pb, pk);
            client.Send(Encoding.ASCII.GetBytes("100 " + exchangeAg.midkey.ToString("X")));
            Thread.Sleep(100);
            client.Send(Encoding.ASCII.GetBytes("120 " + exchangeAg.n.ToString("X")));
            Thread.Sleep(100);
            client.Send(Encoding.ASCII.GetBytes("130 " + exchangeAg.g.ToString("X")));
            client.Send(Encoding.ASCII.GetBytes(""));



            try
            {
                while (true)
                {
                    byte[] data = new byte[1024];
                    int size = client.Receive(data);
                    if (size == 0)
                    {
                        PrintLine("Connection Closed...\n");
                        break;
                    }

                    var incomingdata = "";
                    for (int i = 0; i < size; i++)
                    {
                        incomingdata += Convert.ToChar(data[i]).ToString();
                    }

                    if (EnableEncryption)
                    {
                        incomingdata = exchangeAg.Decrypt(incomingdata);
                        PrintLine("Client : " + incomingdata + "\n");

                    }
                    else
                    {

                        if (incomingdata.Substring(0, 3) == "100")
                        {
                            exchangeAg.CalculatePrivateKey(
                                BigInteger.Parse(
                                    incomingdata.Substring(4, incomingdata.Length - 4),
                                    System.Globalization.NumberStyles.HexNumber
                            ));
                            EnableEncryption = true;
                            PrintLine("Secure Connection Ready...\n\n");

                        }
                        else
                        {
                            PrintLine("Unsecure : Client : " + incomingdata + "\n");

                        }
                    }


                }
            }
            catch (System.Net.Sockets.SocketException e)
            {
                PrintLine("Closed Connection\n");
            }
        }

        private void PrintLine(string text)
        {
            messBox.Text += text;

        }
        private void SendMessage(string message, bool show = true)
        {
            if (EnableEncryption)
            {
                client.Send(Encoding.ASCII.GetBytes(exchangeAg.Encrypt(message)));
                if (show)
                {
                    PrintLine("You : " + message + "\n");
                }
            }
            else
            {
                client.Send(Encoding.ASCII.GetBytes(message));
                if (show)
                {
                    PrintLine("Unsecure : You : " + message + "\n");
                }
            }
        }
        private void Server_Load(object sender, EventArgs e)
        {

        }

        private void send_Click(object sender, EventArgs e)
        {
            SendMessage(chatBoxServer.Text);
        }

        private void Server_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (client != null) { client.Close(); }
            server.Stop();
        }
    }
}
