using System.Runtime.Serialization;
using System.Security.Cryptography;
using System.Text;

namespace Message
{
    public class MessStruct
    {
        private byte[] _msg;
        private int _mode;
        private byte[] _extData; //IV or Public key exchange

        public MessStruct()
        {
            msg = null;
            extData = null;
            mode = 1;

        }

        public MessStruct(byte[] txt, int mode)
        {
            this.msg = txt;
            this.mode = mode;
        }

        public MessStruct(string msg)
        {
            if (msg != null)
                this.msg = Encoding.UTF8.GetBytes(msg);
        }

        public MessStruct(MessStruct temp)
        {
            this.msg = temp.msg;
            this.mode = temp.mode;
        }


        //Serialize
        public void GetObjectData(SerializationInfo info, StreamingContext strcxt)
        {
            info.AddValue("msg", this.msg);
            info.AddValue("extData", this.extData);
            info.AddValue("mode", this.mode);

        }

        //Deserialize
        public MessStruct(SerializationInfo info, StreamingContext strcxt)
        {
            this.msg = (byte[])info.GetValue("msg", typeof(byte[]));
            this.extData = (byte[])info.GetValue("extData", typeof(byte[]));
            this.mode = (int)info.GetValue("mode", typeof(int));
        }

        public void Encrypt(byte[] key)
        {
            using (Aes aes = new AesCryptoServiceProvider())
            {
                aes.Key = key;
                extData = aes.IV;
                // Encrypt the message
                using (MemoryStream ciphertext = new MemoryStream())
                using (CryptoStream cs = new CryptoStream(ciphertext, aes.CreateEncryptor(), CryptoStreamMode.Write))
                {
                    cs.Write(msg, 0, msg.Length);
                    cs.Close();
                    msg = ciphertext.ToArray();
                }
            }
        }

        public void Decrypt(byte[] key)
        {
            using (Aes aes = new AesCryptoServiceProvider())
            {
                aes.Key = key;
                aes.IV = extData;
                // Decrypt the message
                using (MemoryStream plaintext = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(plaintext, aes.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(msg, 0, msg.Length);
                        cs.Close();
                        msg = plaintext.ToArray();
                    }
                }
            }
        }

        public string GetString()
        {
            return Encoding.UTF8.GetString(msg);
        }

        public byte[] msg
        {
            get
            {
                return _msg;
            }

            set
            {
                _msg = value;
            }
        }

        public int mode
        {
            get
            {
                return _mode;
            }

            set
            {
                _mode = value;
            }
        }

        public byte[] extData
        {
            get
            {
                return _extData;
            }

            set
            {
                _extData = value;
            }
        }

    }
}