using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HtmlAgilityPack;

namespace Lab4_LTM
{
    public partial class Bai4 : Form
    {
        public Bai4()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            WebBrowser wb = new WebBrowser();
            wb.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string url = textBox1.Text;

                HtmlWeb web = new HtmlWeb();
                HtmlAgilityPack.HtmlDocument document = web.Load(url);

                // Save the downloaded HTML to a file
                string fileName = "D:/Lab04/downloaded.html";
                document.Save(fileName);

                DownloadImages(document, url);

                MessageBox.Show("Website downloaded successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        static void DownloadImages(HtmlAgilityPack.HtmlDocument document, string baseUrl)
        {
            // Create a directory to store the downloaded images
            string imagesDirectory = "D:/Lab04";
            Directory.CreateDirectory(imagesDirectory);

            // Get all <img> tags in the HTML document
            HtmlNodeCollection imgNodes = document.DocumentNode.SelectNodes("//img");
            if (imgNodes != null)
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    foreach (HtmlNode imgNode in imgNodes)
                    {
                        string imageUrl = imgNode.GetAttributeValue("src", null);
                        if (!string.IsNullOrEmpty(imageUrl))
                        {
                            try
                            {
                                // Create a unique file name for the image based on its URL
                                string imageFileName = Path.GetFileName(imageUrl);
                                string imageFilePath = Path.Combine(imagesDirectory, imageFileName);

                                // Download the image and save it to the specified file path
                                byte[] imageData = httpClient.GetByteArrayAsync(new Uri(new Uri(baseUrl), imageUrl)).Result;
                                File.WriteAllBytes(imageFilePath, imageData);
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show($"Failed to download image: {imageUrl}. Error: {ex.Message}");
                            }
                        }
                    }
                }
            }
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            string url = textBox1.Text;

            using (HttpClient httpClient = new HttpClient())
            {
                try
                {
                    string html = await httpClient.GetStringAsync(url);
                    // Create a new form
                    Form sourceForm = new Form();
                    sourceForm.Text = "HTML Source";
                    sourceForm.Width = 600;
                    sourceForm.Height = 400;

                    // Create a RichTextBox control
                    RichTextBox richTextBox = new RichTextBox();
                    richTextBox.Dock = DockStyle.Fill;
                    richTextBox.ReadOnly = true;
                    richTextBox.Text = html;

                    // Add the RichTextBox control to the form
                    sourceForm.Controls.Add(richTextBox);

                    // Show the new form
                    sourceForm.ShowDialog();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}");
                }
            }
        }
    }
}
