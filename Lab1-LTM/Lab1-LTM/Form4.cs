using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Humanizer;
using Lab1_LTM;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Lab1
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            foreach (Control c in Controls)
            {
                if (c is System.Windows.Forms.TextBox)
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

        private void button1_Click(object sender, EventArgs e)
        {
            int num;
            try
            {
                if (int.TryParse(textBox1.Text, out num))
                {
                    textBox2.Text = num.ToWords().ToLower()
                    .Replace("-", " ").Replace("hundred", "trăm").Replace("thousand", "nghìn").Replace("million", "triệu").Replace(" and", "")
                    .Replace("eleven", "mười một").Replace("twelve", "mười hai").Replace("thirteen", "mười ba").Replace("fourteen", "mười bốn").Replace("fifteen", "mười lăm")
                    .Replace("sixteen", "mười sáu").Replace("seventeen", "mười bảy").Replace("eighteen", "mười tám").Replace("nineteen", "mười chín")
                    .Replace("ten", "mười").Replace("twenty", "hai mươi").Replace("thirty", "ba mươi").Replace("forty", "Bốn mươi").Replace("fifty", "năm mươi")
                    .Replace("sixty", "sáu mươi").Replace("seventy", "bảy mươi").Replace("eighty", "tám mươi").Replace("ninety", "chín mươi")
                    .Replace("one", "một").Replace("two", "hai").Replace("three", "ba").Replace("four", "bốn").Replace("five", "năm")
                    .Replace("six", "sáu").Replace("seven", "bảy").Replace("eight", "tám").Replace("nine", "chín").Replace("zero", "không").Replace("minus", "âm");
                }
                else
                    throw new Exception();
            }
            catch (Exception)
            {
                MessageBox.Show("Hãy nhập số nguyên", "Error", MessageBoxButtons.OK);

            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
