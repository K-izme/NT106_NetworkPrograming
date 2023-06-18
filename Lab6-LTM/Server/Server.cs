using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;

namespace Server
{
    class Server
    {
        int port;
        TcpListener listener;
        public List<TcpClient> clients = new List<TcpClient>();

        public Server(int port = 5432)
        {
            this.port = port;
            listener = new TcpListener(IPAddress.Any, port);
            listener.Start();
        }

        public void sendToAll(string message)
        {
            byte[] bytes = ASCIIEncoding.ASCII.GetBytes(message);
            for (int x = 0; x < clients.Count; x++)
            {
                try
                {
                    clients[x].GetStream().Write(bytes, 0, bytes.Length);
                }
                catch
                {
                    clients.RemoveAt(x);
                    if (x - 1 < 0)
                    {
                        x--;
                    }
                }
            }
            if (clients.Count > 6)
            {
                SendEmailNotification(clients.Count);
            }
        }

        public TcpClient newClient()
        {
            TcpClient client = listener.AcceptTcpClient();
            clients.Add(client);
            SendConnectedClientsCount();
            return client;
        }

        public string receive(TcpClient client)
        {
            byte[] bytes = new byte[client.ReceiveBufferSize];
            int toRead = client.GetStream().Read(bytes, 0, client.ReceiveBufferSize);
            return ASCIIEncoding.ASCII.GetString(bytes, 0, toRead);
        }

        private void SendConnectedClientsCount()
        {
            string countMessage = $"CLIENTS_COUNT|{clients.Count}";
            sendToAll(countMessage);
        }

        private void SendEmailNotification(int clientCount)
        {
            string emailFrom = "kietngo2552@gmail.com";
            string emailTo = "kietngo255@gmail.com";
            string emailSubject = "Client Limit Exceeded";
            string emailBody = $"The number of connected clients has exceeded the limit. Current count: {clientCount}";

            using (SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587))
            {
                smtpClient.EnableSsl = true;
                smtpClient.Credentials = new NetworkCredential("kietngo2552@gmail.com", "zqfguhvsqzumlvps");

                using (MailMessage mailMessage = new MailMessage(emailFrom, emailTo, emailSubject, emailBody))
                {
                    try
                    {
                        smtpClient.Send(mailMessage);
                        Console.WriteLine("Email notification sent successfully.");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Failed to send email notification: {ex.Message}");
                    }
                }
            }
        }

    }
}