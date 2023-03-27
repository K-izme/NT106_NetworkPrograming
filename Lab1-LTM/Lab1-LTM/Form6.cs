using Lab1_LTM;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab1
{
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string[] array = textBox1.Text
                    .Split(',')
                    .Select(a => a.Trim())
                    .Where(a => float.TryParse(a, out float num) && num >= 0 && num <= 10)
                    .ToArray();
                for (int i = 0; i < array.Length; ++i)
                {
                    listView1.Items.Add("Môn " + (i + 1) + ": " + array[i]);
                }
                float[] array1 = textBox1.Text
                    .Split(',')
                    .Select(a => a.Trim())
                    .Select(float.Parse)
                    .ToArray();
                string xepLoai = string.Empty;
                if (array1.Average() >= 8 && array1.Count(x => x < 6.5) == 0)
                    xepLoai = "Giỏi";
                else if (array1.Average() >= 6.5 && array1.Average() < 8 && array1.Count(x => x < 5) == 0)
                    xepLoai = "Khá";
                else if (array1.Average() >= 5 && array1.Average() < 6.5 && array1.Count(x => x < 3.5) == 0)
                    xepLoai = "Trung Bình";
                else if (array1.Average() >= 3.5 && array1.Average() < 5 && array1.Count(x => x < 2) == 0)
                    xepLoai = "Yếu";
                else
                    xepLoai = "Kém";

                label2.Text = label2.Text + Math.Round(array1.Average(), 2);
                label3.Text = label3.Text + array1.Max();
                label4.Text = label4.Text + array1.Count(x => x >= 5);
                label5.Text = label5.Text + xepLoai;
                label6.Text = label6.Text + array1.Min();
                label7.Text = label7.Text + array1.Count(x => x < 5);



            }
            catch (Exception)
            {
                MessageBox.Show("Vui lòng nhập điểm hợp lệ", "Error", MessageBoxButtons.OK);
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
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
            listView1.Items.Clear();

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            Form1 f1 = new Form1();
            f1.Show();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
