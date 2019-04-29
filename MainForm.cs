using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AxAPlayer3Lib;
using APlayer3Lib;

namespace DeclineAplay
{
    public partial class MainForm : BaseForm
    {
        LayeredWindow lw = null;
        public Color defaultSkinColor = Color.FromArgb(255, 92, 138);
        public MainForm(LayeredWindow ilw)
        {
            InitializeComponent();
            lw = ilw;
            SetDefaultSkin();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            lw.axPlayer1.SetVolume(50);
            lw.axPlayer1.Open("http://hd.yinyuetai.com/uploads/videos/common/E6E90165F112591DC08AF52DA40112E9.mp4?sc=dfeae283fd371dfd&br=1094&vid=3293228&aid=39611&area=KR&vst=0");
            lw.axPlayer1.Play();
        }

        public override void btn_close_Click(object sender, EventArgs e)
        {
            if (lw != null)
            {
                lw.Dispose();
            }
            base.btn_close_Click(sender, e);
        }

        private void MainForm_LocationChanged(object sender, EventArgs e)
        {
            if (lw != null)
            {
                lw.Size = new Size(this.Width - Panel_Left.Width - Panel_Right.Width, this.Height - Panel_Top.Height - Panel_Bottom.Height);
                lw.Location = new Point(this.Location.X + Panel_Left.Width, this.Location.Y + Panel_Top.Height);
            }
        }
        #region 窗体样式配置

        private void SetDefaultSkin()
        {
            this.Panel_Top.BackColor = defaultSkinColor;
            this.Panel_Left.BackColor = defaultSkinColor;
            this.Panel_Right.BackColor = defaultSkinColor;
            this.Panel_Bottom.BackColor = defaultSkinColor;
        }

        #endregion
    }
}
