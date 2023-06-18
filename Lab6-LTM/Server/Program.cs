using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace Server
{
    class Program
    {
        static Server server = new Server(5432);
        static void Main(string[] args)
        {
            while (true)
            {
                // add client to server
                TcpClient client = server.newClient();
                // connect new client in seperate thread
                Task.Run(() =>
                {
                    Console.WriteLine("user joined");
                    // while thread is running, send message, else exit loop.
                    while (true)
                    {
                        try
                        {
                            string message = server.receive(client);
                            Console.WriteLine("received " + message);
                            server.sendToAll(message);
                        }
                        catch
                        {
                            break;
                        }
                    }
                });
            }
            // wait for client
        }
    }
}
