using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab4_LTM
{
    public partial class Bai1 : Form
    {
        public Bai1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                richTextBox1.Text = getHTTP(textBox1.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private string getHTTP(string url)
        {
            WebRequest request;
            WebResponse response;
            string content = "";
            Stream rs;
            Byte[] RecvBytes = new byte[Byte.MaxValue];
            Int32 bytes;
            request = (WebRequest) WebRequest.Create(url);
            response = (WebResponse)
                request.GetResponse();
            rs = response.GetResponseStream();
            while (true)
            {
                bytes = rs.Read(RecvBytes, 0, RecvBytes.Length);
                if (bytes <= 0) break;
                content += System.Text.Encoding.UTF8.GetString(RecvBytes, 0, bytes);

            }
            return content;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            richTextBox1.Clear();
        }
    }
}
