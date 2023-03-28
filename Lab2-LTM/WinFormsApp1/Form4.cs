using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WinFormsApp1
{
    public partial class Form4 : Form
    {
        public string inputFileLocation = @"C:\Users\gohan\OneDrive\Desktop\input.txt";
        public string outputFileLocation = @"C:\Users\gohan\OneDrive\Desktop\output.txt";
        public Form4()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            Form1 f1 = new Form1();
            f1.Show();
        }

        protected void button1_Click(object sender, EventArgs e)
        {
            //input text if not exist create file 
            if (!File.Exists(inputFileLocation))
            {
                string createText = "1 + 1" + Environment.NewLine;
                File.WriteAllText(inputFileLocation, createText);
            }
            string inputText = File.ReadAllText(inputFileLocation);
            richTextBox1.Text = inputText;
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string[] inputLines = File.ReadAllLines(inputFileLocation);
            //Streamwriter to write data
            using (StreamWriter sw = new StreamWriter(outputFileLocation))
            {
                foreach (string line in inputLines)
                {
                    // DataTable compute
                    DataTable func = new DataTable();
                    string result = func.Compute(line, "").ToString();
                    sw.WriteLine($"{line} = {result}");
                }
            }
            richTextBox1.Text = File.ReadAllText(outputFileLocation);
        }
    }
}
