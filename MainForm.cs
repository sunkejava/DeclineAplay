using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LayeredSkin.Forms;
using LayeredSkin.Controls;
using LayeredSkin.DirectUI;

namespace DeclineAplay
{
    public partial class MainForm : LayeredForm
    {
        private AxAPlayer3Lib.AxPlayer axPlayer1;
        delegate void AsynUpdateConfigInfoUI(DuiTextBox dtb);//委托更新加载控件显示
        LayeredPanel lp_main = new LayeredPanel();
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            axPlayer1 = new AxAPlayer3Lib.AxPlayer();
            axPlayer1.Size = new Size(this.Width - 10, this.Height - 10);
            axPlayer1.Location = new Point(5, 5);
            this.Panel_main.Controls.Add(axPlayer1);
            axPlayer1.Visible = true;
            Bitmap bmp = new Bitmap(Image.FromFile(@"E:\CNetProject\DeclineAplay\Resources\2.png"));
            axPlayer1.SetCustomLogo(bmp.GetHbitmap().ToInt32());
            axPlayer1.SetConfig(207, "1");//智能去除当前视频黑边
            axPlayer1.SetConfig(36, "16761024;50;20");//Logo 风格设置，格式："backcolor;xpercent;ypercent"，例如设置白色背景(16777215为0xffffff的十进制串)、水平偏左(30%)、垂直居中(50%)的 Logo 位置："16777215;30;50"

            axPlayer1.SetVolume(5);
            axPlayer1.Open("http://hd.yinyuetai.com/uploads/videos/common/E6E90165F112591DC08AF52DA40112E9.mp4?sc=dfeae283fd371dfd&br=1094&vid=3293228&aid=39611&area=KR&vst=0");
            axPlayer1.Play();

            lp_main.Size = new Size(100, 300);
            lp_main.BackColor = Color.Transparent;
            Panel_main.Controls.Add(lp_main);
            lp_main.Location = new Point(0, 0);

            DuiTextBox lbt = new DuiTextBox();
            lbt.Size = lp_main.Size;
            lbt.Multiline = true;
            lp_main.DUIControls.Add(lbt);
            lbt.Location = new Point(0, 0);
            lp_main.BringToFront();
            lbt.BackColor = Color.Transparent;
            //getAplayerConfigInfo(lbt);
            lbt.Text = axPlayer1.GetConfig(205);
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            axPlayer1.Dispose();
            this.Close();
        }

        private void getAplayerConfigInfo(DuiTextBox lbt)
        {
            if (lp_main.InvokeRequired)
            {
                AsynUpdateConfigInfoUI au = new AsynUpdateConfigInfoUI(getAplayerConfigInfo);
                this.Invoke(au, new object[] { lbt });
            }
            {
                for (int i = 1; i < 42; i++)
                {
                    lbt.Text += "Aplayer配置" + i.ToString() + "内容为：" + axPlayer1.GetConfig(i) + "\r\n";
                }
                for (int i = 101; i < 122; i++)
                {
                    lbt.Text += axPlayer1.GetConfig(i) + "\r\n";
                }
                for (int i = 201; i < 222; i++)
                {
                    lbt.Text += axPlayer1.GetConfig(i) + "\r\n";
                }
                for (int i = 301; i < 316; i++)
                {
                    lbt.Text += axPlayer1.GetConfig(i) + "\r\n";
                }
                for (int i = 401; i < 418; i++)
                {
                    lbt.Text += axPlayer1.GetConfig(i) + "\r\n";
                }
                for (int i = 501; i < 512; i++)
                {
                    lbt.Text += axPlayer1.GetConfig(i) + "\r\n";
                }
                for (int i = 601; i < 625; i++)
                {
                    lbt.Text += axPlayer1.GetConfig(i) + "\r\n";
                }
                for (int i = 701; i < 713; i++)
                {
                    lbt.Text += axPlayer1.GetConfig(i) + "\r\n";
                }
                for (int i = 801; i < 805; i++)
                {
                    lbt.Text += axPlayer1.GetConfig(i) + "\r\n";
                }
                for (int i = 901; i < 908; i++)
                {
                    lbt.Text += axPlayer1.GetConfig(i) + "\r\n";
                }
                for (int i = 1001; i < 1005; i++)
                {
                    lbt.Text += axPlayer1.GetConfig(i) + "\r\n";
                }
                for (int i = 1101; i < 1112; i++)
                {
                    lbt.Text += axPlayer1.GetConfig(i) + "\r\n";
                }
                for (int i = 1301; i < 1329; i++)
                {
                    lbt.Text += axPlayer1.GetConfig(i) + "\r\n";
                }
                for (int i = 1401; i < 1416; i++)
                {
                    lbt.Text += axPlayer1.GetConfig(i) + "\r\n";
                }
                for (int i = 1501; i < 1504; i++)
                {
                    lbt.Text += axPlayer1.GetConfig(i) + "\r\n";
                }
                for (int i = 1801; i < 1805; i++)
                {
                    lbt.Text += axPlayer1.GetConfig(i) + "\r\n";
                }
                for (int i = 2101; i < 2112; i++)
                {
                    lbt.Text += axPlayer1.GetConfig(i) + "\r\n";
                }
                for (int i = 2201; i < 2208; i++)
                {
                    lbt.Text += axPlayer1.GetConfig(i) + "\r\n";
                }
                for (int i = 2301; i < 2314; i++)
                {
                    lbt.Text += axPlayer1.GetConfig(i) + "\r\n";
                }
                for (int i = 2401; i < 2411; i++)
                {
                    lbt.Text += axPlayer1.GetConfig(i) + "\r\n";
                }
                for (int i = 2501; i < 2519; i++)
                {
                    lbt.Text += axPlayer1.GetConfig(i) + "\r\n";
                }
                for (int i = 2601; i < 2610; i++)
                {
                    lbt.Text += axPlayer1.GetConfig(i) + "\r\n";
                }
            }
        }
    }
}
