using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using LayeredSkin.DirectUI;

namespace DeclineAplay
{
    public partial class MainForm : BaseForm
    {
        LayeredWindow lw = null;
        public Color defaultSkinColor = Color.FromArgb(80, 255, 92, 138);
        DuiLabel dl_PlayerExplain = null;//播放器窗体上说明控件
        Point playerPoint = new Point();
        public MainForm(LayeredWindow ilw)
        {
            InitializeComponent();
            lw = ilw;
            SetDefaultSkin();
            SetDefaultPosition();
            SetDefaultAnchr();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            BaseControl.BringToFront();
            panel_min.BringToFront();
            panel_close.BringToFront();
            lw.axPlayer.SetVolume(50);
            lw.axPlayer.Open("http://hd.yinyuetai.com/uploads/videos/common/E6E90165F112591DC08AF52DA40112E9.mp4?sc=dfeae283fd371dfd&br=1094&vid=3293228&aid=39611&area=KR&vst=0");
            lw.axPlayer.Play();
        }

        private void BaseControl_Leave(object sender, EventArgs e)
        {
            if (dl_PlayerExplain != null)
            {
                dl_PlayerExplain.Visible = false;
                dl_PlayerExplain.Size = new Size(0, 0);
                dl_PlayerExplain.Location = new Point(0, 0);
                dl_PlayerExplain.Text = "";
            }
        }

        private void BaseControl_Enter(object sender, EventArgs e)
        {
            if (dl_PlayerExplain == null)
            {
                dl_PlayerExplain = new DuiLabel();
                BaseControl.DUIControls.Add(dl_PlayerExplain);
            }
            dl_PlayerExplain.Text = "已获取到焦点";
            dl_PlayerExplain.TextAlign = ContentAlignment.MiddleCenter;
            dl_PlayerExplain.Font = new Font("微软雅黑", 10F, FontStyle.Regular);
            dl_PlayerExplain.Size = new Size(dl_PlayerExplain.Text.Length * 10, 30);
            dl_PlayerExplain.ForeColor = defaultSkinColor;
            dl_PlayerExplain.Location = playerPoint;
            dl_PlayerExplain.Visible = true;
        }

        public override void btn_close_Click(object sender, EventArgs e)
        {
            if (lw != null)
            {
                lw.axPlayer.Dispose();
                lw.Close();
            }
            base.btn_close_Click(sender, e);
        }

        private void MainForm_LocationChanged(object sender, EventArgs e)
        {
            SetDefaultPosition();
            if (lw != null)
            {
                lw.Size = new Size(this.Width - Panel_Left.Width - Panel_Right.Width + 4, this.Height - Panel_Top.Height - Panel_Bottom.Height + 4);
                lw.Location = new Point(this.Location.X + Panel_Left.Width - 2, this.Location.Y + Panel_Top.Height - 2);
                playerPoint = lw.Location;
            }
        }
        #region 窗体样式配置
        /// <summary>
        /// 设置默认背景
        /// </summary>
        private void SetDefaultSkin()
        {
            this.Panel_Left.BackColor = defaultSkinColor;
            this.Panel_Top.BackColor = defaultSkinColor;
            this.Panel_Right.BackColor = defaultSkinColor;
            this.Panel_Bottom.BackColor = defaultSkinColor;
            this.Panel_Left.Width = this.Panel_Left.Width + 2;
            this.Panel_Top.Size = new Size(this.Panel_Top.Width + 2, this.Panel_Top.Height + 2);
            this.Panel_Right.Width = this.Panel_Right.Width + 2;
            this.Panel_Bottom.Size = new Size(this.Panel_Bottom.Width + 2, this.Panel_Bottom.Height + 2);
        }
        /// <summary>
        /// 设置默认位置
        /// </summary>
        private void SetDefaultPosition()
        {
            this.Panel_Top.Location = new Point(-2, -2);
            this.Panel_Left.Location = new Point(-2, this.Panel_Top.Height - 2);
            this.Panel_Right.Location = new Point(this.Width + 2 - this.Panel_Right.Width, this.Panel_Top.Height - 2);
            this.Panel_Bottom.Location = new Point(-2, this.Height - this.Panel_Bottom.Height + 2);
        }
        /// <summary>
        /// 设置固定位置
        /// </summary>
        private void SetDefaultAnchr()
        {
            this.Panel_Left.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Top)));
            this.Panel_Top.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Panel_Right.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right | System.Windows.Forms.AnchorStyles.Top)));
            this.Panel_Bottom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));

        }

        #endregion

        private void BaseControl_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (dl_PlayerExplain != null)
            {
                dl_PlayerExplain.Visible = false;
                dl_PlayerExplain.Size = new Size(0, 0);
                dl_PlayerExplain.Location = new Point(0, 0);
                dl_PlayerExplain.Text = "";
            }
        }

        private void BaseControl_MouseLeave(object sender, EventArgs e)
        {
            if (!BaseControl.Focus())
            {
                return;
            }
            if (dl_PlayerExplain == null)
            {
                dl_PlayerExplain = new DuiLabel();
                BaseControl.DUIControls.Add(dl_PlayerExplain);
            }
            Logger.Singleton.Error("播放器坐标：" + playerPoint.ToString());
            dl_PlayerExplain.Text = "已获取到焦点";
            dl_PlayerExplain.TextAlign = ContentAlignment.MiddleCenter;
            dl_PlayerExplain.Font = new Font("微软雅黑", 10F, FontStyle.Regular);
            dl_PlayerExplain.Size = new Size(dl_PlayerExplain.Text.Length * 5, 20);
            dl_PlayerExplain.ForeColor = Color.White;
            dl_PlayerExplain.Location = new Point(playerPoint.X - this.Location.X, playerPoint.Y - this.Location.Y);
            dl_PlayerExplain.Visible = true;
            Logger.Singleton.Error("播放器宽高及位置：" + lw.Size.ToString() + lw.Location.ToString());
            Logger.Singleton.Error("BaseControl宽高及位置：" + BaseControl.Size.ToString() + BaseControl.Location.ToString());
            Logger.Singleton.Error("控件窗体MainForm宽高及位置" + this.Size.ToString() + this.Location.ToString());
            Logger.Singleton.Error("Panel_Left宽高及位置：" + Panel_Left.Size.ToString() + Panel_Left.Location.ToString());
            Logger.Singleton.Error("Panel_Right宽高及位置：" + Panel_Right.Size.ToString() + Panel_Right.Location.ToString());
            Logger.Singleton.Error("Panel_Top宽高及位置：" + Panel_Top.Size.ToString() + Panel_Top.Location.ToString());
            Logger.Singleton.Error("Panel_Bottom宽高及位置：" + Panel_Bottom.Size.ToString() + Panel_Bottom.Location.ToString());
            Logger.Singleton.Error("dl_PlayerExplain宽高及位置：" + dl_PlayerExplain.Size.ToString() + dl_PlayerExplain.Location.ToString());

        }

        private void MainForm_FormClosed(object sender, System.Windows.Forms.FormClosedEventArgs e)
        {
            if (lw != null)
            {
                lw.axPlayer.Dispose();
                lw.Close();
            }
            base.btn_close_Click(sender, e);
        }
    }
}
