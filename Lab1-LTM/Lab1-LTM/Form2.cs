using Lab1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab1_LTM
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            foreach (Control c in Controls)
            {
                if (c is TextBox)
                {
                    c.Text = string.Empty;
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            Form1 f1 = new Form1();
            f1.Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int input1;
                int input2;
                if (int.TryParse(textBox1.Text, out input1) && int.TryParse(textBox2.Text, out input2))
                {
                    int result = input1 + input2;
                    textBox3.Text = (input1 + input2).ToString();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Hãy nhập số nguyên", "Error", MessageBoxButtons.OK);

            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
