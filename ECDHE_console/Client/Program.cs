using System;
using System.IO;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;

class Client
{
    private ECDiffieHellmanCng clientECDH;
    private byte[] sharedKey;
    private byte[] iv;

    public void Run()
    {

        byte[] curve = new byte[8];
        // Connect to the server
        TcpClient client = new TcpClient();
        client.Connect("192.168.1.108", 1234);
        Console.WriteLine("Connected to the server.");

       
        
        using (NetworkStream stream = client.GetStream())
        {
            stream.Read(curve, 0, curve.Length);
            Console.WriteLine("Server curve name received.");

            string curveName = Encoding.ASCII.GetString(curve);
            switch (curveName)
            {
                case "nistP512":
                    clientECDH = new ECDiffieHellmanCng(ECCurve.NamedCurves.nistP521);
                    break;
                case "nistP384":
                    clientECDH = new ECDiffieHellmanCng(ECCurve.NamedCurves.nistP384);
                    break;
                case "nistP256":
                    clientECDH = new ECDiffieHellmanCng(ECCurve.NamedCurves.nistP256);
                    break;

            }
            byte[] clientPublicKey = clientECDH.PublicKey.ToByteArray();
            byte[] serverPublicKey = new byte[clientPublicKey.Length];

            // Receive Server public key
            stream.Read(serverPublicKey, 0, serverPublicKey.Length);
            Console.WriteLine("Server public key received.");

            //Send Client public key
            stream.Write(clientPublicKey, 0, clientPublicKey.Length);
            Console.WriteLine("Client public key sent.");


            // Derive shared secret key
            sharedKey = clientECDH.DeriveKeyMaterial(CngKey.Import(serverPublicKey, CngKeyBlobFormat.EccPublicBlob));
            Console.WriteLine("Session key derived: " + BitConverter.ToString(sharedKey));

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
