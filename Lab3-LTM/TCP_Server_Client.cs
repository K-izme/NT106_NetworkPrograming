using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.DataFormats;

namespace Lab03_LTM
{
    public partial class TCP_Server_Client : Form
    {
        public TCP_Server_Client()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TCP_Server sv = new TCP_Server();
            sv.Show();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            TCP_Client sv = new TCP_Client();
            sv.Show();

        }
    }
}
