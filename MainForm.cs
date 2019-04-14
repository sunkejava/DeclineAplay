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
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            aplayerBase1.Dispose();
            this.Close();
        }

        private void getAplayerConfigInfo(DuiTextBox lbt)
        {
            {
                for (int i = 1; i < 42; i++)
                {
                    lbt.Text += "Aplayer配置" + i.ToString() + "内容为：" + aplayerBase1.GetConfig(i) + "\r\n";
                }
                for (int i = 101; i < 122; i++)
                {
                    lbt.Text += aplayerBase1.GetConfig(i) + "\r\n";
                }
                for (int i = 201; i < 222; i++)
                {
                    lbt.Text += aplayerBase1.GetConfig(i) + "\r\n";
                }
                for (int i = 301; i < 316; i++)
                {
                    lbt.Text += aplayerBase1.GetConfig(i) + "\r\n";
                }
                for (int i = 401; i < 418; i++)
                {
                    lbt.Text += aplayerBase1.GetConfig(i) + "\r\n";
                }
                for (int i = 501; i < 512; i++)
                {
                    lbt.Text += aplayerBase1.GetConfig(i) + "\r\n";
                }
                for (int i = 601; i < 625; i++)
                {
                    lbt.Text += aplayerBase1.GetConfig(i) + "\r\n";
                }
                for (int i = 701; i < 713; i++)
                {
                    lbt.Text += aplayerBase1.GetConfig(i) + "\r\n";
                }
                for (int i = 801; i < 805; i++)
                {
                    lbt.Text += aplayerBase1.GetConfig(i) + "\r\n";
                }
                for (int i = 901; i < 908; i++)
                {
                    lbt.Text += aplayerBase1.GetConfig(i) + "\r\n";
                }
                for (int i = 1001; i < 1005; i++)
                {
                    lbt.Text += aplayerBase1.GetConfig(i) + "\r\n";
                }
                for (int i = 1101; i < 1112; i++)
                {
                    lbt.Text += aplayerBase1.GetConfig(i) + "\r\n";
                }
                for (int i = 1301; i < 1329; i++)
                {
                    lbt.Text += aplayerBase1.GetConfig(i) + "\r\n";
                }
                for (int i = 1401; i < 1416; i++)
                {
                    lbt.Text += aplayerBase1.GetConfig(i) + "\r\n";
                }
                for (int i = 1501; i < 1504; i++)
                {
                    lbt.Text += aplayerBase1.GetConfig(i) + "\r\n";
                }
                for (int i = 1801; i < 1805; i++)
                {
                    lbt.Text += aplayerBase1.GetConfig(i) + "\r\n";
                }
                for (int i = 2101; i < 2112; i++)
                {
                    lbt.Text += aplayerBase1.GetConfig(i) + "\r\n";
                }
                for (int i = 2201; i < 2208; i++)
                {
                    lbt.Text += aplayerBase1.GetConfig(i) + "\r\n";
                }
                for (int i = 2301; i < 2314; i++)
                {
                    lbt.Text += aplayerBase1.GetConfig(i) + "\r\n";
                }
                for (int i = 2401; i < 2411; i++)
                {
                    lbt.Text += aplayerBase1.GetConfig(i) + "\r\n";
                }
                for (int i = 2501; i < 2519; i++)
                {
                    lbt.Text += aplayerBase1.GetConfig(i) + "\r\n";
                }
                for (int i = 2601; i < 2610; i++)
                {
                    lbt.Text += aplayerBase1.GetConfig(i) + "\r\n";
                }
            }
        }

        private void btn_play_Click(object sender, EventArgs e)
        {
            aplayerBase1.SetVolume(50);
            aplayerBase1.Open("http://hd.yinyuetai.com/uploads/videos/common/E6E90165F112591DC08AF52DA40112E9.mp4?sc=dfeae283fd371dfd&br=1094&vid=3293228&aid=39611&area=KR&vst=0");
            aplayerBase1.Play();
        }
    }
}
