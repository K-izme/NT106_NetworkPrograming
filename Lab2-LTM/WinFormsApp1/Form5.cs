using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Globalization;

namespace WinFormsApp1
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }
        OpenFileDialog ofd = new OpenFileDialog();

        public void button3_Click(object sender, EventArgs e)
        {
            try
            {
                ofd.ShowDialog();
                string outputText = rtbHocVien.Text;
                string writeFilePath = ofd.FileName;

                // Ghi nội dung in hoa xuống file output.txt
                File.WriteAllText(writeFilePath, outputText);
            }
            catch (Exception)
            {
            }
        }

        public void button1_Click(object sender, EventArgs e)
        {
            rtbHocVien.Clear();
            int count = 1;

            // Đọc file
            StreamReader str = new StreamReader(ofd.FileName);

            while (!str.EndOfStream)
            {
                try
                {
                    rtbHocVien.Text += count.ToString() + ": ";
                    string mssv = str.ReadLine();
                    rtbHocVien.Text += mssv + "  \n";
                    string name = str.ReadLine();
                    rtbHocVien.Text += name + "  \n";
                    string n_phone = str.ReadLine();
                    rtbHocVien.Text += n_phone + "\n";

                    float score_math = float.Parse(str.ReadLine());
                    rtbHocVien.Text += "Điểm toán: \t" + score_math.ToString() + "\n";

                    float score_literature = float.Parse(str.ReadLine());
                    rtbHocVien.Text += "Điểm văn: \t" + score_literature.ToString() + "\n";

                    float score_average = (score_math + score_literature) / 2;
                    rtbHocVien.Text += "Điểm trung bình: \t" + score_literature.ToString() + "\n\n";

                    // Hàng trống.
                    str.ReadLine();
                    count++;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Plz provide input in correctly format.", "Error.", MessageBoxButtons.OK);
                }
            }
            str.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Đã ghi vào Output.txt", "XUẤT FILE");

            // Path output
            string path = "D:/output.txt";

            // Ghi file
            StreamWriter stw = new StreamWriter(path);
            StreamReader str = new StreamReader(ofd.FileName);
            if (!File.Exists(path))
                File.CreateText(path);
            else
            {
                while (!str.EndOfStream)
                {
                    try
                    {
                        string mssv = str.ReadLine();
                        stw.WriteLine(mssv);

                        string name = str.ReadLine();
                        stw.WriteLine(name);

                        string n_phone = str.ReadLine();
                        stw.WriteLine(n_phone);

                        float score_math = float.Parse(str.ReadLine());
                        stw.WriteLine(score_math.ToString());

                        float score_literature = float.Parse(str.ReadLine());
                        stw.WriteLine(score_literature.ToString());

                        float score_average = (score_math + score_literature) / 2;
                        stw.WriteLine(score_average.ToString());

                        // Hàng trống.
                        stw.WriteLine("\n");
                        str.ReadLine();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Input isnt in correct format.", "Error.", MessageBoxButtons.OK);
                    }

                }
            }
            stw.Close();
            str.Close();
        }

        private void Form5_Load(object sender, EventArgs e)
        {

        }


        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
            Form1 f1 = new Form1();
            f1.Show();
        }
    }
}
