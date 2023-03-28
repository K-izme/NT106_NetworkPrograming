using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //input text if not exist create file 
            string inputFileLocation = textBox1.Text;
            if (!File.Exists(inputFileLocation))
            {
                string createText = "Hi, i created a file for you" + Environment.NewLine;
                File.WriteAllText(inputFileLocation, createText);
            }
            string inputText = File.ReadAllText(inputFileLocation);
            richTextBox1.Text = inputText;
        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //output text if not exist create file 
            string outputFileLocation = textBox2.Text;
            File.WriteAllText(outputFileLocation, richTextBox1.Text.ToUpper());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            Form1 f1 = new Form1();
            f1.Show();
        }
    }
}
