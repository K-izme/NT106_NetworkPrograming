using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Policy;
using System.Text.RegularExpressions;

namespace Lab4_LTM
{
    public partial class Bai2 : Form
    {
        public Bai2()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string url = textBox1.Text;
                if (IsUrlValid(url))
                {
                    string postData = textBox2.Text;

                    //to bytes
                    byte[] byteArray = Encoding.UTF8.GetBytes(postData);

                    using (var httpClient = new HttpClient())
                    {
                        using (var content = new ByteArrayContent(byteArray))
                        {
                            //content length content type
                            content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/x-www-form-urlencoded");
                            content.Headers.ContentLength = byteArray.Length;

                            HttpResponseMessage response = await httpClient.PostAsync(url, content);

                            if (response.IsSuccessStatusCode)
                            {
                                string responseData = await response.Content.ReadAsStringAsync();
                                richTextBox1.Text = responseData;
                            }
                            else
                            {
                                richTextBox1.Text = "POST request failed. Status code: " + response.StatusCode;
                            }
                        }
                    }
                }
                else throw new Exception();
            }
            catch (Exception) 
            {
                MessageBox.Show("Error with url");
            }
            
        }

        private bool IsUrlValid(string url)
        {

            string pattern = @"^(http|https|ftp|)\://|[a-zA-Z0-9\-\.]+\.[a-zA-Z](:[a-zA-Z0-9]*)?/?([a-zA-Z0-9\-\._\?\,\'/\\\+&amp;%\$#\=~])*[^\.\,\)\(\s]$";
            Regex reg = new Regex(pattern, RegexOptions.Compiled | RegexOptions.IgnoreCase);
            return reg.IsMatch(url);
        }
    }
}
