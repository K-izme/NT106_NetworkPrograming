using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using System.Security.Cryptography;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Lab1_LTM;

namespace Lab1
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int dec = new int();
            string bin;
            string hexa;
            int x = new int();
            string bridge = string.Empty;

           
            try
            {
                //kiểm tra đầu vào cho hex,octal,decimal
                if (comboBox1.SelectedIndex == 2)
                {
                    char[] allowedChars = new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'A', 'B', 'C', 'D', 'E', 'F' };
                    foreach (char character in textBox1.Text.ToUpper().ToArray())
                    {
                        if (!allowedChars.Contains(character))
                        {
                            throw new Exception();

                        }

                    }
                }
                else if (comboBox1.SelectedIndex == 1)
                {
                    char[] allowedChars = new char[] { '0', '1' };
                    foreach (char character in textBox1.Text.ToUpper().ToArray())
                    {
                        if (!allowedChars.Contains(character))
                        {
                            throw new Exception();
                        }

                    }
                }
                switch (comboBox1.SelectedIndex)
                {
                    case 0:
                        if (int.TryParse(textBox1.Text, out dec))
                            x = dec;
                        else
                            throw new Exception();
                        break;
                    case 1:
                        bin = textBox1.Text;
                        x = Convert.ToInt32(bin, 2);
                        break;
                    case 2:
                        hexa = textBox1.Text;
                        x = Convert.ToInt32(hexa, 16);
                        break;
                    default:
                        break;
                }

                switch (comboBox2.SelectedIndex)
                {
                    case 0:
                        textBox2.Text = x.ToString();
                        break;
                    case 1:
                        bridge = Convert.ToString(x, 2);
                        textBox2.Text = bridge;
                        break;
                    case 2:
                        bridge = Convert.ToString(x, 16);
                        break;
                    default:
                        break;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Vui lòng nhập đúng định dạng", "Error", MessageBoxButtons.OK);
            }
        }
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            Form1 f1 = new Form1();
            f1.Show();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form5_Load(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
