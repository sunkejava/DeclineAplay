using DeclineAplay.Utils;
using LayeredSkin.DirectUI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace DeclineAplay.Controls
{
    /// <summary>
    /// 类    名: PlayeListControl.cs
    /// CLR 版本: 4.0.30319.42000
    /// 作    者: sunkejava 
    /// 邮    箱：declineaberdeen@foxmail.com
    /// 创建时间: 2019/06/13 11:50:51
    /// 说    明：播放器列表控件
    /// </summary>
    public class PlayeListControl : LayeredSkin.Controls.LayeredListBox
    {
        ToolTip toolTip1 = new ToolTip();
        int x, y;//记录鼠标进入控件时的位置
        Color defaultColor = Color.FromArgb(120, 0, 0, 0);

        public PlayerForm plf = null;

        #region 控件事件

        /// <summary>
        /// 图片列表失去焦点后的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Dp_MouseLeave(object sender, EventArgs e)
        {


        }

        /// <summary>
        /// 图片列表获取焦点后的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Dp_MouseEnter(object sender, EventArgs e)
        {

        }

        private void ImgTag_MouseClick(object sender, DuiMouseEventArgs e)
        {
            DuiLabel dlt = sender as DuiLabel;
            plf.tvUrl = dlt.Name.Replace("imgTag_", "");
            plf.tvName = dlt.Text.Trim();
            plf.Axplayer_Play(dlt.Name.Replace("imgTag_", ""));
        }

        #endregion

        #region 自定义事件
        /// <summary>
        /// 添加列表
        /// </summary>
        /// <param name="imgInfos"></param>
        /// <returns></returns>
        public Boolean AddList(List<Utils.PlayListEntity> tvInfos)
        {
            if (tvInfos.Count == 0)
            {
                return false;
            }
            int thisWidth = this.Width - 6;//减去滚动条宽度
            int zWidth = thisWidth;
            int zHeight = (int)(thisWidth * 0.2);
            int i = 0;
            string baseUrl = "0";
            foreach (Utils.PlayListEntity tvInfo in tvInfos)
            {
                DuiBaseControl baseControl = new DuiBaseControl();
                baseControl.Size = new Size(thisWidth, zHeight);
                baseControl.BackColor = defaultColor;//Color.FromArgb(245, 245, 247);
                baseUrl = tvInfo.tvUrl.ToString();
                DuiBaseControl abaseControl = new DuiBaseControl();
                abaseControl.Size = new Size(zWidth, zHeight);
                //abaseControl.Location = new Point(3, i * zHeight);
                abaseControl.Name = "back_" + tvInfo.tvUrl.ToString();
                abaseControl.BackColor = Color.Transparent;
                //视频名称
                DuiLabel imgTag = new DuiLabel();
                imgTag.TextRenderMode = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;
                string ingTxt = tvInfo.tvName;
                imgTag.Size = new Size(zWidth - 4, zHeight - 4);
                imgTag.Location = new Point(2, 2);
                imgTag.Font = new Font("微软雅黑", 10F, FontStyle.Bold);
                imgTag.ForeColor = Color.White;
                imgTag.BackColor = Color.Transparent;
                imgTag.TextAlign = ContentAlignment.MiddleCenter;
                //imgTag.BackColor = Color.FromArgb(100, 0, 0, 0);
                //imgTag.BackgroundImage = Properties.Resources.mask_shadow;
                //imgTag.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
                imgTag.Text = ingTxt;
                imgTag.Name = "imgTag_" + tvInfo.tvUrl.ToString();
                imgTag.MouseLeave += Dp_MouseLeave;
                imgTag.Cursor = System.Windows.Forms.Cursors.Hand;
                imgTag.MouseClick += ImgTag_MouseClick;

                Borders baseBorder = new Borders(baseControl);
                baseBorder.BottomWidth = 2;
                baseBorder.TopWidth = 2;
                baseBorder.LeftWidth = 2;
                baseBorder.RightWidth = 2;

                abaseControl.Borders = baseBorder;
                abaseControl.Controls.Add(imgTag);
                baseControl.Controls.Add(abaseControl);

                baseControl.Name = "imgListBaseControl_" + baseUrl;
                Items.Add(baseControl);
                //更新列表
                RefreshList();
                i++;
            }
            GC.Collect();
            return true;
        }


        public bool addIsNull()
        {
            try
            {
                this.BackColor = Color.White;
                DuiBaseControl abaseControl = new DuiBaseControl();
                abaseControl.Size = new Size(this.Width - 5, this.Height);
                abaseControl.Location = new Point(0, 0);
                abaseControl.Name = "imgListBaseControl_backnull";
                Items.Add(abaseControl);
                //更新列表
                RefreshList();
                GC.Collect();
                //背景图
                DuiPictureBox dp = new DuiPictureBox();
                dp.Size = new Size(510, 109);
                dp.BackgroundImage = Properties.Resources.bnull;
                dp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
                dp.Name = "back_pnull";
                dp.Location = new Point((this.Width - 5 - 510) / 2, (this.Height - 2 - 109) / 2);
                abaseControl.Controls.Add(dp);

                Items.Add(abaseControl);
                //更新列表
                RefreshList();
                GC.Collect();
                return true;
            }
            catch (Exception e)
            {

                throw new Exception("未搜索到内容，原因为：" + e.Message);
            }
        }

        private void showMessageForm()
        {
            MessageForm mfm = new MessageForm("");
            mfm.Show(this);
        }
        /// <summary>
        /// 列表刷新
        /// </summary>
        public new void RefreshList()
        {
            if (RefreshListed != null)
                RefreshListed(this, new EventArgs());
            base.RefreshList();
        }
        #endregion

        #region 委托事件
        /// <summary>
        /// 刷新列表事件
        /// </summary>
        [Description("列表刷新事件"), Category("自定义事件")]
        public event EventHandler RefreshListed;


        #endregion

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // ImageListControl
            // 
            this.Borders.BottomColor = System.Drawing.Color.Empty;
            this.Borders.BottomWidth = 1;
            this.Borders.LeftColor = System.Drawing.Color.Empty;
            this.Borders.LeftWidth = 1;
            this.Borders.RightColor = System.Drawing.Color.Empty;
            this.Borders.RightWidth = 1;
            this.Borders.TopColor = System.Drawing.Color.Empty;
            this.Borders.TopWidth = 1;
            this.ResumeLayout(false);

        }
    }
}
