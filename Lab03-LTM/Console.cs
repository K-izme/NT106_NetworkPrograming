using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab03_LTM
{
    public partial class Console : Form
    {
        public Console()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ex2 ex = new ex2();
            ex.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            TCP_Server_Client sv = new TCP_Server_Client();
            sv.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MultiChat_Server ms = new MultiChat_Server();
            ms.Show();
            MultiChat_Client mc = new MultiChat_Client();
            mc.Show();
            MultiChat_Client mc1 = new MultiChat_Client();
            mc1.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Bai1 bai1 = new Bai1();
            bai1.Show();
        }
    }
}
