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
using System.Xml.Serialization;
using static System.Windows.Forms.LinkLabel;

namespace WinFormsApp1
{
    public partial class Form5 : Form
    {
        public string inputFileLocation = @"C:\Users\gohan\OneDrive\Desktop\input.txt";
        public string outputFileLocation = @"C:\Users\gohan\OneDrive\Desktop\output.txt";

        internal class HocVien
        {
            internal string mssv { get; set; }
            internal string hoten { get; set; }
            internal string dienthoai { get; set; }
            internal float diemtoan { get; set; }
            internal float diemvan { get; set; }
            internal float diemtb { get; set; }

            internal HocVien(string mssv, string hoten, string dienthoai, float diemtoan, float diemvan)
            {
                this.mssv = mssv;
                this.hoten = hoten;
                this.dienthoai = dienthoai;
                this.diemtoan = diemtoan;
                this.diemvan = diemvan;
                this.diemtb = (diemtoan + diemvan) / 2;
            }
        }

        public Form5()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        public void button1_Click(object sender, EventArgs e)
        {
            //split input by lines
            string[] lines = richTextBox1.Text.Split('\n', StringSplitOptions.RemoveEmptyEntries);

            //array hocvien 
            HocVien[] hocVienArr = new HocVien[lines.Length];
            for (int i = 0; i < lines.Length; i++)
            {
                string[] fields = lines[i].Split(',',StringSplitOptions.RemoveEmptyEntries);
                hocVienArr[i] = new HocVien(
                    fields[0],
                    fields[1],
                    fields[2],
                    float.Parse(fields[3]),
                    float.Parse(fields[4])
                );
            }

            //write to input.txt using binaryformatter
            BinaryFormatter bf = new BinaryFormatter();
            using (FileStream fs = new FileStream(inputFileLocation, FileMode.Open, FileAccess.Write))
            {
                foreach (var item in hocVienArr)
                {
                    bf.Serialize(fs, item);
                }
            }
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
