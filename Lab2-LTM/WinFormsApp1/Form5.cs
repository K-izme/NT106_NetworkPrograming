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
using System.Runtime.Serialization.Formatters;
using System.Runtime.Serialization.Formatters.Binary;
using WinFormsApp1;

namespace WinForms1App1
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }
        List<Student> students = new List<Student>();
        private void btnThem_Click(object sender, EventArgs e)
        {
            Student student = new Student();
            student.Mssv = tbMssv.Text;
            student.HoTen = tbHoTen.Text;
            student.Sđt = tbSđt.Text;
            student.toan = float.Parse(tbToan.Text);
            student.van = float.Parse(tbVan.Text);
            students.Add(student);
            LoadData();
        }
        private void LoadData()
        {
            listView.Items.Clear();
            foreach (Student student in students)
            {
                ListViewItem item = new ListViewItem(student.Mssv);
                item.SubItems.Add(student.HoTen);
                item.SubItems.Add(student.Sđt);
                item.SubItems.Add(student.toan.ToString());
                item.SubItems.Add(student.van.ToString());
                listView.Items.Add(item);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                FileStream fi = new FileStream("input.txt", FileMode.OpenOrCreate);
                BinaryFormatter bi = new BinaryFormatter();
                bi.Serialize(fi, students);
                fi.Close();
                MessageBox.Show("Student info is saved in input.txt");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            rtbFile.Clear();
            try
            {
                FileStream fi = new FileStream("output.txt", FileMode.Open);
                BinaryFormatter bi = new BinaryFormatter();
                List<Student> list = new List<Student>();
                list = (List<Student>)bi.Deserialize(fi);
                foreach (Student St in list)
                {
                    rtbFile.Text = rtbFile.Text + St.GetSt().ToString() + "\n";
                }
                fi.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            tbHoTen.Text = null;
            tbMssv.Text = null;
            tbSđt.Text = null;
            tbToan.Text = null;
            tbVan.Text = null;
            listView.Items.Clear();
            rtbFile.Text = null;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
            Form1 f1 = new Form1();
            f1.Show();
        }

        private void btnTinh_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (Student St in students)
                {
                    St.Tinh();
                }
                FileStream fi = new FileStream("output.txt", FileMode.Create);
                BinaryFormatter bi = new BinaryFormatter();
                bi.Serialize(fi, students);
                fi.Close();
                MessageBox.Show("Average point is saved in output.txt");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void tbMssv_TextChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {
        }
    }
}
