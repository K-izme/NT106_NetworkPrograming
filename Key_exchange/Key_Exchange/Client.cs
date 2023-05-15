using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Key_Exchange
{
    public partial class Client : Form
    {

        private Socket client;
        private ECDH exchangeAg;
        private bool EnableEncryption = false;

        public Client(string ip, int port, string public_big_num, string public_prime_key, string private_key)
        {
            client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            var pp = Int32.Parse(Int32.Parse(public_prime_key, System.Globalization.NumberStyles.HexNumber).ToString());
            var pb = BigInteger.Parse(public_big_num, System.Globalization.NumberStyles.HexNumber);
            var pk = BigInteger.Parse(private_key, System.Globalization.NumberStyles.HexNumber);

            Connect(ip, port);
            PerformKeyExchange(pp, pb, pk);
            StartReceiving();
        }

        private void Connect(string ip, int port)
        {
            try
            {
                client.Connect(ip, port);
                Console.WriteLine("Connected to the server.\n");
            }
            catch (SocketException e)
            {
                Console.WriteLine("Failed to connect to the server.\n");
            }
        }

        private void PerformKeyExchange(int pp, BigInteger pb, BigInteger pk)
        {
            exchangeAg = new ECDH(pp, pb, pk);

            SendData("100 " + exchangeAg.midkey.ToString("X"));
            Thread.Sleep(100);
            SendData("120 " + exchangeAg.n.ToString("X"));
            Thread.Sleep(100);
            SendData("130 " + exchangeAg.g.ToString("X"));
            SendData("");
        }

        private void StartReceiving()
        {
            try
            {
                while (true)
                {
                    byte[] data = new byte[1024];
                    int size = client.Receive(data);
                    if (size == 0)
                    {
                        Console.WriteLine("Connection Closed.\n");
                        break;
                    }

                    var incomingdata = Encoding.ASCII.GetString(data, 0, size);

                    if (EnableEncryption)
                    {
                        incomingdata = exchangeAg.Decrypt(incomingdata);
                        Console.WriteLine("Server: " + incomingdata + "\n");
                    }
                    else
                    {
                        if (incomingdata.Substring(0, 3) == "100")
                        {
                            exchangeAg.CalculatePrivateKey(
                                BigInteger.Parse(
                                    incomingdata.Substring(4, incomingdata.Length - 4),
                                    System.Globalization.NumberStyles.HexNumber
                                )
                            );
                            EnableEncryption = true;
                            Console.WriteLine("Secure Connection Ready.\n");
                        }
                        else
                        {
                            Console.WriteLine("Unsecure: Server: " + incomingdata + "\n");
                        }
                    }
                }
            }
            catch (SocketException e)
            {
                Console.WriteLine("Closed Connection.\n");
            }
        }

        public void SendData(string message)
        {
            if (EnableEncryption)
            {
                client.Send(Encoding.ASCII.GetBytes(exchangeAg.Encrypt(message)));
                Console.WriteLine("You: " + message + "\n");
            }
            else
            {
                client.Send(Encoding.ASCII.GetBytes(message));
                Console.WriteLine("Unsecure: You: " + message + "\n");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string message = textBox1.Text;
            SendData(message);
        }
        public Client()
        {
            InitializeComponent();
        }

        private void Client_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

    }
}
