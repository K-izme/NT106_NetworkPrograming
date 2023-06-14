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
        static List<TcpClient> clients = new List<TcpClient>();
        static List<StreamWriter> writers = new List<StreamWriter>();

        static void Main(string[] args)
        {
            TcpListener server = new TcpListener(IPAddress.Any, 1234); // Replace with your desired port number
            server.Start();

            Console.WriteLine("Server started. Waiting for connections...");

            while (true)
            {
                TcpClient client = server.AcceptTcpClient();
                Console.WriteLine("Client connected.");

                // Add the new client to the clients list
                clients.Add(client);

                // Start a new thread to handle the client
                Thread clientThread = new Thread(HandleClient);
                clientThread.Start(client);
            }
        }

        static void HandleClient(object obj)
        {
            TcpClient client = (TcpClient)obj;

            // Get the client stream and readers/writers
            NetworkStream stream = client.GetStream();
            StreamWriter writer = new StreamWriter(stream);
            writers.Add(writer);

            StreamReader reader = new StreamReader(stream);

            try
            {
                while (true)
                {
                    string data = reader.ReadLine();

                    // Broadcast the received data to all connected clients
                    BroadcastData(data);
                }
            }
            catch (IOException)
            {
                // An error occurred while reading data from the client
                // Handle the error or gracefully terminate the client connection
                client.Close();
                writers.Remove(writer);
                clients.Remove(client);
                Console.WriteLine("Client disconnected.");
            }
        }

        static void BroadcastData(string data)
        {
            // Send the data to all connected clients
            foreach (StreamWriter writer in writers)
            {
                writer.WriteLine(data);
                writer.Flush();
            }
        }
    }
}
