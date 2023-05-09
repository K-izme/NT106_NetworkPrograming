namespace Lab4_LTM
{
    public partial class Console : Form
    {
        public Console()
        {
            InitializeComponent();
        }



        private void button1_Click_1(object sender, EventArgs e)
        {
            Bai1 b1 = new Bai1();
            b1.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Bai2 b2 = new Bai2();
            b2.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Bai3 b3 = new Bai3();
            b3.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Bai4 b4 = new Bai4();
            b4.Show();
        }
    }
}