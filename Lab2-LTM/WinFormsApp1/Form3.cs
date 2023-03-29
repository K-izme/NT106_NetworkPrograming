using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox1.ReadOnly = true;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            textBox2.ReadOnly = true;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            textBox3.ReadOnly = true;
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            textBox4.ReadOnly = true;
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            textBox5.ReadOnly = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.ShowDialog();

            textBox1.Text = openFileDialog1.SafeFileName;
            textBox2.Text = openFileDialog1.FileName;
            textBox3.Text = Convert.ToString(File.ReadAllLines(openFileDialog1.FileName).Length);

            //count work
            string delimeterWord = " ?!,.;:|\r\n\t";
            string[] words = File.ReadAllText(openFileDialog1.FileName).Split(delimeterWord.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            textBox4.Text = words.Length.ToString();

            //count char
            textBox5.Text = File.ReadAllText(openFileDialog1.FileName).Length.ToString();

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            richTextBox1.ReadOnly = true;
        }
    }
}
