using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LayeredSkin.Forms;

namespace DeclineAplay
{
    public partial class MessageForm : LayeredForm
    {
        private string messageStr = "";
        Timer tm;
        public MessageForm(string msg)
        {
            InitializeComponent();
            messageStr = msg;
            getDefaultControl();
        }
        /// <summary>
        /// 定时事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Tm_Tick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void getDefaultControl()
        {
            if (!string.IsNullOrEmpty(messageStr))
            {
                layeredLabel1.Text = messageStr;
                //int zHeight = 15;
                //if ((Width - 4) / 11 < messageStr.Length)
                //{
                //    zHeight = (int)Math.Ceiling((decimal)(messageStr.Length / ((Width - 4) / 11)));
                //}
                layeredLabel1.Size = new Size(Width - 10, Height - 20);
                layeredLabel1.Location = new Point(5, 15);
                layeredLabel1.TextAlign = ContentAlignment.MiddleCenter;
                layeredLabel2.Visible = false;
            }
            else
            {
                layeredLabel2.Cursor = Cursors.Hand;
            }
            this.BackColor = Color.FromArgb(120, 0, 0, 0);
            btn_close.Cursor = Cursors.Hand;

        }

        private void layeredLabel2_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("explorer.exe", AppDomain.CurrentDomain.BaseDirectory + @"ImageWallpaper\");
            this.Close();
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MessageForm_Load(object sender, EventArgs e)
        {
            tm = new Timer();
            tm.Interval = 3500;
            tm.Enabled = true;
            tm.Tick += Tm_Tick;
        }
    }
}
