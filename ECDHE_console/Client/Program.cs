using System;
using System.IO;
using System.Net.Sockets;
using System.Security.Cryptography;

class Client
{
    private ECDiffieHellmanCng clientECDH;
    private byte[] sharedKey;
    private byte[] iv;

    public void Run()
    {
        clientECDH = new ECDiffieHellmanCng(ECCurve.NamedCurves.nistP256);

        byte[] clientPublicKey = clientECDH.PublicKey.ToByteArray();

        // Connect to the server
        TcpClient client = new TcpClient();
        client.Connect("localhost", 1234);
        Console.WriteLine("Connected to the server.");

        // Receive server's public key
        byte[] serverPublicKey = new byte[clientPublicKey.Length];
        using (NetworkStream stream = client.GetStream())
        {
            stream.Read(serverPublicKey, 0, serverPublicKey.Length);
            Console.WriteLine("Server public key received.");

            stream.Write(clientPublicKey, 0, clientPublicKey.Length);
            Console.WriteLine("Client public key sent.");

            // Derive shared secret key
            sharedKey = clientECDH.DeriveKeyMaterial(CngKey.Import(serverPublicKey, CngKeyBlobFormat.EccPublicBlob));

            // Receive IV from the server
            iv = new byte[16];
            stream.Read(iv, 0, iv.Length);
            Console.WriteLine("IV received.");

            // Start sending encrypted messages to the server
            while (true)
            {
                Console.Write("Enter a message to send to the server: ");
                string message = Console.ReadLine();

                byte[] encryptedMessage = EncryptMessage(message);
                byte[] encryptedMessageLengthBytes = BitConverter.GetBytes(encryptedMessage.Length);

                stream.Write(encryptedMessageLengthBytes, 0, encryptedMessageLengthBytes.Length);
                stream.Write(encryptedMessage, 0, encryptedMessage.Length);

                Console.WriteLine("Message sent to the server.");
            }
        }
    }

    private byte[] EncryptMessage(string message)
    {
        using (Aes aes = Aes.Create())
        {
            aes.Key = sharedKey;
            aes.IV = iv;

            ICryptoTransform encryptor = aes.CreateEncryptor();

            using (MemoryStream memoryStream = new MemoryStream())
            using (CryptoStream cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
            {
                using (StreamWriter writer = new StreamWriter(cryptoStream))
                {
                    writer.Write(message);
                }

                return memoryStream.ToArray();
            }
        }
    }
    static void Main()
    {
        Client client = new Client();
        client.Run();
    }
}
