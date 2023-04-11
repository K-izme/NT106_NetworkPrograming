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
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                FolderBrowserDialog fbd = new FolderBrowserDialog();
                fbd.ShowDialog();
                string path = fbd.SelectedPath;
                string[] files = Directory.GetFiles(path);
                foreach (string file in files)
                {
                    FileInfo fi = new FileInfo(file);
                    ListViewItem it = new ListViewItem(fi.Name);
                    it.SubItems.Add((fi.Length).ToString() + " bytes");
                    it.SubItems.Add(fi.Extension);
                    it.SubItems.Add(fi.LastWriteTime.ToString());
                    listView1.Items.Add(it);

                }

            }
            catch (Exception)
            {
            }
        }

        private void Form6_Load(object sender, EventArgs e)
        {

        }
    }
}
