using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Form5 : Form
    {
        public string writeFileLocation = @"C:\Users\gohan\OneDrive\Desktop\input.txt";
        public string write1FileLocation = @"C:\Users\gohan\OneDrive\Desktop\output.txt";
        public Form5()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
        
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
             FileStream fs = new FileStream(writeFileLocation, FileMode.Open);
             BinaryFormatter bf = new BinaryFormatter();
             bf.Serialize(fs, textBox1.Text+"\n");
        }
    }
}
