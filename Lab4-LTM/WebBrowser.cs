using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Web.WebView2.WinForms;

namespace Lab4_LTM
{
    public partial class WebBrowser : Form
    {
        public WebBrowser(string url)
        {
            InitializeComponent();

            webView21.Source = new Uri(url);
        }

        private void WebBrowser_Load(object sender, EventArgs e)
        {

        }
    }
}
