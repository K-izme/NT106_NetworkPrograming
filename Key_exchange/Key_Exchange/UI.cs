using System.Numerics;

namespace Key_Exchange
{
    public partial class UI : Form
    {
        public UI()
        {
            InitializeComponent();
        }
        static Random random = new Random();
        //generate a random hex number with 'x' digits use for key generate
        public static string getRandomHex(int digits)
        {
            var final = random.Next(1, 9).ToString();
            for (int i = 0; i < digits - 1; i++)
            {
                final += random.Next(0, 9).ToString();
            }
            return BigInteger.Parse(final).ToString("X");
        }

        private void pubBig_TextChanged(object sender, EventArgs e)
        {

        }

        private void serverPrivate_TextChanged(object sender, EventArgs e)
        {
        }

        private void pubPrime_TextChanged(object sender, EventArgs e)
        {
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void gen_1_Click(object sender, EventArgs e)
        {
            pubPrime.Text = getRandomHex(3);
        }

        private void gen_2_Click(object sender, EventArgs e)
        {
            pubBig.Text = getRandomHex(128);
        }

        private void gen_3_Click(object sender, EventArgs e)
        {
            serverPrivate.Text = getRandomHex(128);
        }

        private void gen_priKey_client_Click(object sender, EventArgs e)
        {
            clientPrivate.Text = getRandomHex(128);
        }

        private void serverOp_Click(object sender, EventArgs e)
        {

        }

        private void clientPrivate_TextChanged(object sender, EventArgs e)
        {

        }
    }
}