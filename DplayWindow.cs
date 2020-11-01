using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DeclineAplay
{
    public partial class DplayWindow : Form
    {
        public DplayWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 播放地址
        /// </summary>
        public string tvUrl { get; set; }

        private void DplayWindow_Load(object sender, EventArgs e)
        {
            webBrowser1.StatusTextChanged += WebBrowser1_StatusTextChanged;
            string tvUrls = "http://localhost/Dplayer/index.html?url=" + UrlEncode(tvUrl) + "&type=hls";
            Console.WriteLine(tvUrls);
            webBrowser1.Navigate(new Uri(tvUrls));
            webBrowser1.ScriptErrorsSuppressed = true;
        }

        private void WebBrowser1_StatusTextChanged(object sender, EventArgs e)
        {
            Console.WriteLine(webBrowser1.StatusText);
        }

        /// <summary>
        /// URL编码
        /// </summary>
        /// <param name="str">要进行编码的字符串</param>
        /// <returns></returns>
        public static string UrlEncode(string str)
        {
            StringBuilder sb = new StringBuilder();
            byte[] byStr = System.Text.Encoding.UTF8.GetBytes(str); //默认是System.Text.Encoding.Default.GetBytes(str)
            for (int i = 0; i < byStr.Length; i++)
            {
                sb.Append(@"%" + Convert.ToString(byStr[i], 16));
            }

            return (sb.ToString());
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }
    }
}
