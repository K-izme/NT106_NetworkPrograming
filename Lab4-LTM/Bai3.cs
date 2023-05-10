using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab4_LTM
{
    public partial class Bai3 : Form
    {
        public Bai3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox3.Text == "")
                textBox3.Text = "download";
            string path = textBox2.Text + @"\" + textBox3.Text + ".html";
            if (textBox1.Text == "" || textBox2.Text == " ")
                MessageBox.Show("Please input all the information", "Error!", MessageBoxButtons.OK);
            

            try
            {
                if (!File.Exists(path)) // If file does not exists
                {
                    File.Create(path).Close(); // Create file
                    WebClient client = new WebClient();
                    client.DownloadFile(textBox1.Text, path);
                    richTextBox1.Text = client.DownloadString(textBox1.Text);
                }

                else // If file already exists

                    throw new Exception();
            }
            catch (Exception)
            {
                MessageBox.Show("This file name is already existed", "Error!", MessageBoxButtons.OK);
            }

           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    textBox2.Text = fbd.SelectedPath;
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            richTextBox1.Clear();
        }
    }
}
