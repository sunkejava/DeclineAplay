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
    /// 类    名: ImageListControl.cs
    /// CLR 版本: 4.0.30319.42000
    /// 作    者: sunkejava 
    /// 邮    箱：declineaberdeen@foxmail.com
    /// 创建时间: 2018/12/31 11:50:51
    /// 说    明：图片列表控件
    /// </summary>
    public class ImageListControl : LayeredSkin.Controls.LayeredListBox
    {
        ToolTip toolTip1 = new ToolTip();
        int x, y;//记录鼠标进入控件时的位置
        Color defaultColor = Color.FromArgb(125, 255, 92, 138);
        public Entity.UserEntity userEntity = new Entity.UserEntity();
        public delegate String getImagePathByUIrlDelegate(string url);
        #region 控件事件

        /// <summary>
        /// 图片列表失去焦点后的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Dp_MouseLeave(object sender, EventArgs e)
        {
            Point ms = Control.MousePosition;
            if (ms.Y != y || (ms.X != x))
            {
                DuiBaseControl dp = null;
                string strId = "";
                if (sender is DuiBaseControl)
                {
                    dp = sender as DuiBaseControl;
                    if (dp.Name.Contains("btnBaseControl_"))
                    {
                        strId = (dp != null ? dp.Name.Replace("btnBaseControl_", "") : "");
                    }
                }
                if (sender is DuiButton)
                {
                    dp = (sender as DuiButton).Parent as DuiBaseControl;
                    strId = (sender as DuiButton).Name.Replace("btn_Download_", "").Replace("btn_Setting_", "");
                }
                if (sender is DuiPictureBox)
                {
                    strId = (sender as DuiPictureBox).Name.Replace("back_", "");
                    dp = (sender as DuiPictureBox).Parent as DuiBaseControl;
                }
                //隐藏按钮
                if (dp.FindControl("btnBaseControl_" + strId).Count > 0)
                {
                    DuiBaseControl ldl = dp.FindControl("btnBaseControl_" + strId)[0];
                    if (!ldl.IsMouseEnter)
                    {
                        ldl.Visible = false;
                        //显示名称
                        if (dp.FindControl("imgTag_" + strId).Count > 0)
                        {
                            DuiLabel dl = (DuiLabel)dp.FindControl("imgTag_" + strId)[0];
                            dl.Visible = true;
                        }
                        //显示时长
                        if (dp.FindControl("tvLength_" + strId).Count > 0)
                        {
                            DuiLabel dl = (DuiLabel)dp.FindControl("tvLength_" + strId)[0];
                            dl.Visible = true;
                        }
                    }
                }
            }
        }
        /// <summary>
        /// 图片列表获取焦点后的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Dp_MouseEnter(object sender, EventArgs e)
        {
            Point ms = Control.MousePosition;
            x = ms.X;
            y = ms.Y;
            DuiBaseControl dp = null;
            string strId = "";
            if (sender is DuiBaseControl)
            {
                dp = sender as DuiBaseControl;
            }
            if (sender is DuiButton)
            {
                dp = (sender as DuiButton).Parent as DuiBaseControl;
                strId = (sender as DuiButton).Name.Replace("btn_Download_", "").Replace("btn_Setting_", "");
            }
            if (sender is DuiPictureBox)
            {
                strId = (sender as DuiPictureBox).Name.Replace("back_", "");
                dp = (sender as DuiPictureBox).Parent as DuiBaseControl;
            }
            //隐藏标题
            if (dp.FindControl("imgTag_" + strId).Count > 0)
            {
                DuiLabel dl = (DuiLabel)dp.FindControl("imgTag_" + strId)[0];
                dl.Visible = false;
            }
            //隐藏时长
            if (dp.FindControl("tvLength_" + strId).Count > 0)
            {
                DuiLabel dl = (DuiLabel)dp.FindControl("tvLength_" + strId)[0];
                dl.Visible = false;
            }
            //显示按钮
            if (dp.FindControl("btnBaseControl_" + strId).Count > 0)
            {
                DuiBaseControl ldl = dp.FindControl("btnBaseControl_" + strId)[0];
                ldl.Visible = true;
            }
        }
        /// <summary>
        /// 播放按钮点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_Download_MouseClick(object sender, DuiMouseEventArgs e)
        {
            //播放视频
            DuiButton dbn = sender as DuiButton;
            Entity.MovieListEntity.DataItem moveInfo = new Entity.MovieListEntity.DataItem();
            if (dbn.Tag != null)
            {
                moveInfo = dbn.Tag as Entity.MovieListEntity.DataItem;
            }
            string url = "";
            try
            {
                API.TvAPI tva = new API.TvAPI();
                Entity.MovePlayEntity plav = tva.getVideoUrl(userEntity.email, userEntity.psw, moveInfo.videoID.ToString(), "all", userEntity.imei);
                Console.WriteLine(plav.toJsonString());
                Console.WriteLine(plav.data);
                PlayerForm plF = new PlayerForm();
                url = plav.data.ToString();
                plF.tvUrl = plav.data.ToString();
                plF.tvName = moveInfo.videoName;
                plF.Show();
                plF.AxPlayer_PlayOrPause(url);
            }
            catch (Exception ex)
            {
                Logger.Singleton.Error("name:" + moveInfo.videoName + "---地址:" + url, ex);
                throw;
            }

        }

        private void Btn_Download_MouseLeave(object sender, EventArgs e)
        {
            toolTip1.Hide(this);
        }

        private void Btn_Download_MouseEnter(object sender, EventArgs e)
        {
            Entity.MovieListEntity.DataItem moveinfo = (sender as DuiButton).Tag as Entity.MovieListEntity.DataItem;
            toolTip1.Show(moveinfo.videoName, this, PointToClient(MousePosition).X, PointToClient(MousePosition).Y + 15, 2000);
        }

        private void BtnBaseControl_MouseMove(object sender, DuiMouseEventArgs e)
        {
            Point ms = Control.MousePosition;
            x = ms.X;
            y = ms.Y;
        }
        #endregion

        #region 自定义事件
        /// <summary>
        /// 添加图片列表
        /// </summary>
        /// <param name="imgInfos"></param>
        /// <returns></returns>
        public Boolean AddImgList(List<Entity.MovieListEntity.DataItem> imgInfos)
        {
            if (imgInfos.Count == 0)
            {
                return false;
            }
            int thisWidth = this.Width - 5;//减去滚动条宽度
            int zWidth = (int)(thisWidth / 3);
            int zHeight = (int)(thisWidth / 3 * 0.57);
            DuiBaseControl baseControl = new DuiBaseControl();
            baseControl.Size = new Size(thisWidth, zHeight);
            baseControl.BackColor = Color.FromArgb(245, 245, 247);
            int i = 0;
            string baseID = "0";
            foreach (var imgInfo in imgInfos)
            {
                //EDate.DataItem newImgInfo = isValidImgInfo(imgInfo);
                baseID = imgInfo.videoID.ToString();
                DuiBaseControl abaseControl = new DuiBaseControl();
                abaseControl.Size = new Size(zWidth, zHeight);
                abaseControl.Location = new Point(i * zWidth, 0);
                abaseControl.Name = "back_" + imgInfo.videoID.ToString();
                //背景图
                DuiPictureBox dp = new DuiPictureBox();
                dp.Size = new Size(zWidth - 4, zHeight - 4);
                int thisWidthScreen = Screen.PrimaryScreen.Bounds.Width;
                int thisHeiightScreen = Screen.PrimaryScreen.Bounds.Height;
                dp.Tag = imgInfo.photo;
                getImagePathByUIrlDelegate newg = new getImagePathByUIrlDelegate(PicDeal.DownloaImage);
                dp.BackgroundImage = Image.FromFile(newg(imgInfo.photo));
                dp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
                dp.Name = "back_" + imgInfo.videoID.ToString();
                dp.Location = new Point(2, 2);
                //dp.Cursor = System.Windows.Forms.Cursors.Hand;
                dp.MouseEnter += Dp_MouseEnter;
                dp.MouseLeave += Dp_MouseLeave;
                //dp.MouseClick += Dp_MouseClick;
                //视频名称
                DuiLabel imgTag = new DuiLabel();
                imgTag.TextRenderMode = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;
                string ingTxt = (string.IsNullOrEmpty(imgInfo.videoName) ? imgInfo.videoType : imgInfo.videoName);
                if (ingTxt.Length * 12 > zWidth)
                {
                    imgTag.Size = new Size(zWidth - 4, 12 * 4);
                    imgTag.Location = new Point(2, zHeight - 48);
                }
                else
                {
                    imgTag.Size = new Size(zWidth - 4, 12 * 2);
                    imgTag.Location = new Point(2, zHeight - 24);
                }
                imgTag.Font = new Font("微软雅黑", 9F, FontStyle.Regular);
                imgTag.ForeColor = Color.White;
                imgTag.TextAlign = ContentAlignment.MiddleCenter;
                //imgTag.BackColor = Color.FromArgb(100, 0, 0, 0);
                imgTag.BackgroundImage = Properties.Resources.mask_shadow;
                imgTag.BackColor = Color.FromArgb(125, 255, 92, 138);
                imgTag.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
                imgTag.Text = ingTxt;
                imgTag.Name = "imgTag_" + imgInfo.videoID.ToString();
                imgTag.MouseLeave += Dp_MouseLeave;
                imgTag.Cursor = System.Windows.Forms.Cursors.Hand;
                //视频时长
                DuiLabel tvLength = new DuiLabel();
                tvLength.TextRenderMode = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;
                string tvTimeStr = "上架时间：";
                if (!string.IsNullOrEmpty(imgInfo.onDate))
                {
                    tvTimeStr = "上架时间：" + imgInfo.onDate;
                }
                tvLength.Size = new Size(tvTimeStr.Length * 12, 12 * 2);
                tvLength.Location = new Point(zWidth - tvTimeStr.Length * 12 - 2, 2);
                tvLength.Font = new Font("微软雅黑", 9F, FontStyle.Regular);
                tvLength.ForeColor = Color.White;
                tvLength.TextAlign = ContentAlignment.MiddleCenter;
                //imgTag.BackColor = Color.FromArgb(100, 0, 0, 0);
                tvLength.BackgroundImage = Properties.Resources.mask_shadow;
                tvLength.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
                tvLength.Text = tvTimeStr;
                tvLength.Name = "tvLength_" + imgInfo.videoID.ToString();
                tvLength.MouseLeave += Dp_MouseLeave;
                tvLength.Cursor = System.Windows.Forms.Cursors.Hand;
                //播放按钮
                DuiButton btn_Download = new DuiButton();
                btn_Download.Size = new Size(35, 35);
                btn_Download.Radius = 35;
                btn_Download.Name = "btn_Download_" + imgInfo.videoID.ToString();
                btn_Download.Text = "";
                btn_Download.Location = new Point((zWidth - 20 - 35) / 2, (zHeight - 20 - 35) / 2);
                btn_Download.Cursor = System.Windows.Forms.Cursors.Hand;
                btn_Download.AdaptImage = false;
                btn_Download.IsPureColor = true;
                btn_Download.BaseColor = Color.Transparent;
                btn_Download.BackgroundImage = Properties.Resources.play1;
                btn_Download.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
                btn_Download.ShowBorder = false;
                btn_Download.MouseClick += Btn_Download_MouseClick;
                btn_Download.Tag = imgInfo;
                btn_Download.MouseEnter += Btn_Download_MouseEnter;
                btn_Download.MouseLeave += Btn_Download_MouseLeave;
                //收藏次数
                DuiButton btn_sc = new DuiButton();
                btn_sc.Location = new Point(0, 0);
                btn_sc.Size = new Size(30, 30);
                btn_sc.Text = "";
                btn_sc.Cursor = System.Windows.Forms.Cursors.Hand;
                btn_sc.AdaptImage = false;
                btn_sc.Name = "btn_Sc_" + imgInfo.videoID.ToString();
                btn_sc.BaseColor = Color.Transparent;//Color.FromArgb(100, 0, 0, 0);
                //btn_sc.Radius = 35;
                btn_sc.ShowBorder = false;
                btn_sc.BackgroundImage = Properties.Resources.sc0;
                btn_sc.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
                btn_sc.IsPureColor = true;
                btn_sc.Tag = imgInfo;
                btn_sc.MouseEnter += Btn_Download_MouseEnter;
                btn_sc.MouseLeave += Btn_Download_MouseLeave;
                DuiLabel dltxt = new DuiLabel();
                dltxt.Text = imgInfo.actorName.ToString();
                dltxt.Size = new Size(30, 16);
                dltxt.ForeColor = Color.White;
                dltxt.Location = new Point(30, 7);
                dltxt.BackColor = Color.Transparent;
                DuiBaseControl scControl = new DuiBaseControl();
                scControl.Name = "scControl_" + imgInfo.videoID.ToString();
                scControl.Size = new Size(60, 30);
                scControl.Location = new Point(zWidth - 20 - 60, zHeight - 20 - 30);
                scControl.Controls.Add(btn_sc);
                scControl.Controls.Add(dltxt);
                //查看次数
                DuiButton btn_Setting = new DuiButton();
                btn_Setting.Location = new Point(0, 0);
                btn_Setting.Size = new Size(30, 30);
                btn_Setting.Text = "";
                btn_Setting.Cursor = System.Windows.Forms.Cursors.Hand;
                btn_Setting.AdaptImage = false;
                btn_Setting.Name = "btn_Setting_" + imgInfo.videoID.ToString();
                btn_Setting.BaseColor = Color.Transparent;//Color.FromArgb(100, 0, 0, 0);
                //btn_Setting.Radius = 35;
                btn_Setting.Tag = imgInfo;
                btn_Setting.ShowBorder = false;
                btn_Setting.BackgroundImage = Properties.Resources.eye;
                btn_Setting.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
                btn_Setting.IsPureColor = true;
                btn_Setting.MouseEnter += Btn_Download_MouseEnter;
                btn_Setting.MouseLeave += Btn_Download_MouseLeave;
                DuiLabel dlatxt = new DuiLabel();
                dlatxt.Text = imgInfo.videoTypeID.ToString();
                dlatxt.Size = new Size(30, 16);
                dlatxt.Location = new Point(30, 7);
                dlatxt.BackColor = Color.Transparent;
                dlatxt.ForeColor = Color.White;
                DuiBaseControl seeControl = new DuiBaseControl();
                seeControl.Name = "seeControl_" + imgInfo.videoID.ToString();
                seeControl.Size = new Size(60, 30);
                seeControl.Location = new Point(0, zHeight - 20 - 30);
                seeControl.Controls.Add(btn_Setting);
                seeControl.Controls.Add(dlatxt);
                //按钮底层控件
                DuiBaseControl btnBaseControl = new DuiBaseControl();
                btnBaseControl.Size = new Size(zWidth - 20, zHeight - 20);
                btnBaseControl.Cursor = System.Windows.Forms.Cursors.Hand;
                btnBaseControl.Location = new Point(10, 10);
                btnBaseControl.BackColor = Color.Transparent;
                btnBaseControl.MouseLeave += Dp_MouseLeave;
                btnBaseControl.MouseMove += BtnBaseControl_MouseMove;
                btnBaseControl.Controls.Add(btn_Download);
                btnBaseControl.Controls.Add(scControl);
                btnBaseControl.Controls.Add(seeControl);
                btnBaseControl.Name = "btnBaseControl_" + imgInfo.videoID.ToString();
                btnBaseControl.Visible = false;

                Borders baseBorder = new Borders(baseControl);
                baseBorder.BottomWidth = 2;
                baseBorder.TopWidth = 2;
                baseBorder.LeftWidth = 2;
                baseBorder.RightWidth = 2;

                abaseControl.Borders = baseBorder;
                abaseControl.Controls.Add(dp);
                abaseControl.Controls.Add(imgTag);
                abaseControl.Controls.Add(tvLength);
                abaseControl.Controls.Add(btnBaseControl);
                baseControl.Controls.Add(abaseControl);
                i++;
            }
            baseControl.Name = "imgListBaseControl_" + baseID;
            Items.Add(baseControl);
            //更新列表
            RefreshList();
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
