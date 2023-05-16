﻿using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography;

class Server
{
    private ECDiffieHellmanCng serverECDH;
    private byte[] sharedKey;
    private byte[] iv;

    public void Run()
    {
        
        serverECDH = new ECDiffieHellmanCng(ECCurve.NamedCurves.nistP256);

        // Generate server's ephemeral key pair
        byte[] serverPublicKey = serverECDH.PublicKey.ToByteArray();

        // Start listening for incoming connections
        TcpListener listener = new TcpListener(IPAddress.Any, 1234);
        listener.Start();
        Console.WriteLine("Server started. Waiting for a client to connect...");

        // Accept client connection
        TcpClient client = listener.AcceptTcpClient();
        Console.WriteLine("Client connected.");

        using (NetworkStream stream = client.GetStream())
        {
            stream.Write(serverPublicKey, 0, serverPublicKey.Length);
            Console.WriteLine("Server public key sent.");

            // Receive client's public key
            byte[] clientPublicKey = new byte[serverPublicKey.Length];
            stream.Read(clientPublicKey, 0, clientPublicKey.Length);
            Console.WriteLine("Client public key received.");

            // Derive shared secret key
            sharedKey = serverECDH.DeriveKeyMaterial(CngKey.Import(clientPublicKey, CngKeyBlobFormat.EccPublicBlob));

            // Generate random IV for AES encryption
            using (Aes aes = Aes.Create())
            {
                iv = aes.IV;
            }

            // Send IV to the client
            stream.Write(iv, 0, iv.Length);
            Console.WriteLine("IV sent.");

            // Start receiving and decrypting messages from the client
            while (true)
            {
                byte[] encryptedMessageLengthBytes = new byte[sizeof(int)];
                stream.Read(encryptedMessageLengthBytes, 0, encryptedMessageLengthBytes.Length);
                int encryptedMessageLength = BitConverter.ToInt32(encryptedMessageLengthBytes, 0);

                byte[] encryptedMessage = new byte[encryptedMessageLength];
                stream.Read(encryptedMessage, 0, encryptedMessage.Length);

                string decryptedMessage = DecryptMessage(encryptedMessage);
                Console.WriteLine("Received from client: " + decryptedMessage);
            }
        }
    }

    private string DecryptMessage(byte[] encryptedMessage)
    {
        using (Aes aes = Aes.Create())
        {
            aes.Key = sharedKey;
            aes.IV = iv;

            ICryptoTransform decryptor = aes.CreateDecryptor();

            using (MemoryStream memoryStream = new MemoryStream(encryptedMessage))
            using (CryptoStream cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read))
            using (StreamReader reader = new StreamReader(cryptoStream))
            {
                return reader.ReadToEnd();
            }
        }
    }

    static void Main()
    {
        Server server = new Server();
        server.Run();
    }
}
