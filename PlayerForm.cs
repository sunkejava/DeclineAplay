﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Runtime.InteropServices;
using LayeredSkin.Controls;
using LayeredSkin.DirectUI;
using System.Windows.Forms;

namespace DeclineAplay
{
    public partial class PlayerForm : BaseForm
    {
        private LayeredWindow lw = new LayeredWindow();
        private int flg_LayeredWindow_is_show = 0;
        private System.Timers.Timer LayeredWindowShowTimer = new System.Timers.Timer();
        public Color defaultSkinColor = Color.FromArgb(120, 56, 249, 215);//Color.FromArgb(255, 92, 138);
        DuiLabel dl_PlayerExplain = null;//播放器窗体上说明控件
        Point playerPoint = new Point();
        bool IsFull = false;//是否全屏
        Rectangle Nor = new Rectangle(0, 0, 0, 0);//位置
        int volumeNum = 50;//视频音量
        int tvPosition = 0;//视频播放进度
        string tvUrl = "";
        #region 播放器控件
        DuiButton btnStop = new DuiButton();//停止按钮
        DuiButton btnPrev = new DuiButton();//上一个按钮
        DuiButton btnPlay = new DuiButton();//播放按钮
        DuiButton btnNext = new DuiButton();//下一个按钮
        DuiButton btnOpenFile = new DuiButton();//打开文件按钮
        DuiButton btnVolume = new DuiButton();//声音按钮
        DuiButton btnScreenShot = new DuiButton();//截图按钮
        DuiButton btnFullScreen = new DuiButton();//全屏按钮
        DuiButton btnList = new DuiButton();//列表按钮
        #endregion

        #region 模拟窗体移动变量
        [DllImport("user32.dll", EntryPoint = "SendMessageA")]
        private static extern int SendMessage(int hwnd, int wMsg, int wParam, int lParam);

        [DllImport("user32.dll")]
        private static extern int ReleaseCapture();
        private const int WM_NCLBUTTONDOWN = 0XA1;   //.定义鼠標左鍵按下
        private const int HTCAPTION = 2;
        #endregion

        #region 主窗体事件

        public PlayerForm()
        {
            InitializeComponent();
            //creatTimerforLayeredWindowShow();//定时器要随对象一起创建
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            SetDefaultSkin();
            AddControl();
            lw.axPlayer.SetVolume(50);
            lw.axPlayer.OnStateChanged += AxPlayer_OnStateChanged;//状态变化事件
            lw.axPlayer.OnDownloadCodec += AxPlayer_OnDownloadCodec;//在 APlayer 引擎播放某个媒体文件缺少对应的解码器时
            lw.axPlayer.OnBuffer += AxPlayer_OnBuffer;//网络缓冲
            lw.axPlayer.OnMessage += AxPlayer_OnMessage;//鼠标键盘操作事件
            lw.axPlayer.OnOpenSucceeded += AxPlayer_OnOpenSucceeded;//媒体文件打开成功的事件
            lw.axPlayer.OnSeekCompleted += AxPlayer_OnSeekCompleted;//在用户进行一个 SetPosition 的异步调用完成后
            lw.axPlayer.OnVideoSizeChanged += AxPlayer_OnVideoSizeChanged;//在所播放的视频的分辨率改变时触发
            lw.axPlayer.OnEvent += AxPlayer_OnEvent;//特定扩展事件
            lw.axPlayer.Move += BaseControl_MouseMove;
            lw.axPlayer.Leave += BaseControl_MouseLeave;
            BaseControl.BringToFront();
            panel_close.BringToFront();
            panel_min.BringToFront();
            tvUrl = "http://hd.yinyuetai.com/uploads/videos/common/E6E90165F112591DC08AF52DA40112E9.mp4?sc=dfeae283fd371dfd&br=1094&vid=3293228&aid=39611&area=KR&vst=0";
            //"http://video.aajka.cn:8081/1jxxl/JXXL669FEG/JXXL669FEG.m3u8";
        }

        private void BaseControl_MouseMove(object sender, EventArgs e)
        {
            dl_PlayerExplain.Text = "鼠标经过";
            playPanel.Visible = true;
            Control_MouseMove(sender, (MouseEventArgs)e);
        }

        private void BaseControl_MouseLeave(object sender, EventArgs e)
        {
            dl_PlayerExplain.Text = "鼠标离开";
            playPanel.Visible = false;
        }

        private void BaseControl_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                if (!lw.Visible)
                {
                    lw.Show();
                }
                dl_PlayerExplain.Text = "鼠标左键单击";
                AxPlayer_PlayOrPause(tvUrl);
            }
            else
            {
                dl_PlayerExplain.Text = "鼠标右键单击";
            }

        }

        private void BaseControl_MouseHover(object sender, EventArgs e)
        {
            dl_PlayerExplain.Text = "鼠标悬停";
            //playerControl.Visible = false;
        }

        private void BaseControl_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            dl_PlayerExplain.Text = "鼠标双击";
            fullScreen();
        }

        private void BaseControl_KeyPress(object sender, KeyPressEventArgs e)
        {
            dl_PlayerExplain.Text = e.KeyChar.ToString();
            switch ((int)e.KeyChar)
            {
                case Utils.ConstClass.VK_SPACE:
                    if (!lw.Visible)
                    {
                        lw.Show();
                    }
                    dl_PlayerExplain.Text = ("空格键事件");
                    AxPlayer_PlayOrPause(tvUrl);//("http://hd.yinyuetai.com/uploads/videos/common/E6E90165F112591DC08AF52DA40112E9.mp4?sc=dfeae283fd371dfd&br=1094&vid=3293228&aid=39611&area=KR&vst=0");
                    break;
                default:
                    break;
            }
        }


        private void BaseControl_KeyUp(object sender, KeyEventArgs e)
        {
            dl_PlayerExplain.Text = e.KeyValue.ToString();
            switch (e.KeyValue)
            {
                case Utils.ConstClass.VK_LEFT:
                    dl_PlayerExplain.Text = ("键盘左方向键事件");
                    break;
                case Utils.ConstClass.VK_UP:
                    if (volumeNum < 1000)
                    {
                        volumeNum++;
                    }
                    lw.axPlayer.SetVolume(volumeNum);
                    dl_PlayerExplain.Text = ("当前音量：" + lw.axPlayer.GetVolume().ToString());
                    break;
                case Utils.ConstClass.VK_RIGHT:
                    dl_PlayerExplain.Text = ("键盘右方向键事件");
                    break;
                case Utils.ConstClass.VK_DOWN:
                    if (volumeNum > 0)
                    {
                        volumeNum--;
                    }
                    lw.axPlayer.SetVolume(volumeNum);
                    dl_PlayerExplain.Text = ("当前音量：" + lw.axPlayer.GetVolume().ToString());
                    break;
                case Utils.ConstClass.VK_ESCAPE:
                    dl_PlayerExplain.Text = ("键盘ESC键事件");
                    fullScreen();
                    break;
                default:
                    break;
            }
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

        private void MainForm_SizeChanged(object sender, EventArgs e)
        {
            if (lw != null)
            {
                lw.Size = new Size(this.Width, this.Height);
                lw.Location = new Point(this.Location.X, this.Location.Y);
                playerPoint = lw.Location;
                lw.axPlayer.Refresh();
                lw.Refresh();

                if (dl_PlayerExplain != null)
                {
                    dl_PlayerExplain.Location = new Point(playerPoint.X - this.Location.X, playerPoint.Y - this.Location.Y);
                }
                BaseControl.Refresh();
                btnScreenShot.Location = new Point(playPanel.Width - 150, 5);
                btnFullScreen.Location = new Point(playPanel.Width - 100, 5);
                btnList.Location = new Point(playPanel.Width - 50, 5);
                this.Refresh();
            }
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
            if (lw != null)
            {
                lw.Size = new Size(this.Width, this.Height);
                lw.Location = new Point(this.Location.X, this.Location.Y);
                playerPoint = lw.Location;
                if (dl_PlayerExplain != null)
                {
                    dl_PlayerExplain.Location = new Point(playerPoint.X - this.Location.X, playerPoint.Y - this.Location.Y);
                }
                BaseControl.Refresh();
            }
            this.Refresh();
        }
        #endregion

        #region 播放器相关事件
        /// <summary>
        /// 播放器状态发生变化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AxPlayer_OnStateChanged(object sender, AxAPlayer3Lib._IPlayerEvents_OnStateChangedEvent e)
        {
            switch (e.nNewState)
            {
                case 0: //准备就绪
                    dl_PlayerExplain.Text = "准备就绪";
                    break;
                case 1: //正在打开
                    dl_PlayerExplain.Text = "正在打开";
                    break;
                case 2://正在暂停
                    dl_PlayerExplain.Text = "正在暂停";
                    break;
                case 3://暂停中
                    dl_PlayerExplain.Text = "暂停中";
                    break;
                case 4://正在开始播放
                    dl_PlayerExplain.Text = "正在开始播放";
                    break;
                case 5://播放中
                    dl_PlayerExplain.Text = "播放中";
                    break;
                case 6://正在开始关闭
                    dl_PlayerExplain.Text = "正在开始关闭";
                    break;
                default:
                    break;
            }

        }
        /// <summary>
        /// 需要的解码器
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AxPlayer_OnDownloadCodec(object sender, AxAPlayer3Lib._IPlayerEvents_OnDownloadCodecEvent e)
        {
            Logger.Singleton.Error("需要解码器：" + e.strCodecPath);
        }
        /// <summary>
        /// 事件发生在 APlayer 从网络缓冲媒体数据的过程中
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AxPlayer_OnBuffer(object sender, AxAPlayer3Lib._IPlayerEvents_OnBufferEvent e)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 鼠标键盘操作事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AxPlayer_OnMessage(object sender, AxAPlayer3Lib._IPlayerEvents_OnMessageEvent e)
        {
            switch (e.nMessage)
            {
                case Utils.ConstClass.WM_LBUTTONDBLCLK://左键双击
                    fullScreen();
                    break;
                case Utils.ConstClass.WM_LBUTTONDOWN://左键按下
                    if (!lw.Visible)
                    {
                        lw.Show();
                    }
                    AxPlayer_PlayOrPause(tvUrl);//("http://hd.yinyuetai.com/uploads/videos/common/E6E90165F112591DC08AF52DA40112E9.mp4?sc=dfeae283fd371dfd&br=1094&vid=3293228&aid=39611&area=KR&vst=0");
                    break;
                case Utils.ConstClass.WM_LBUTTONUP://左键弹起
                    break;
                case Utils.ConstClass.WM_RBUTTONDOWN://右键按下
                    break;
                case Utils.ConstClass.WM_MOUSEMOVE://鼠标移动
                    break;
                case Utils.ConstClass.WM_MOUSELEAVE://鼠标离开
                    break;
                case Utils.ConstClass.WM_MOUSEHOVER://鼠标悬停
                    break;
                default:
                    break;
            }
            //键盘按键判断
            switch (e.wParam)
            {
                case Utils.ConstClass.VK_LEFT:
                    Logger.Singleton.Info("键盘左方向键事件");
                    break;
                case Utils.ConstClass.VK_UP:
                    Logger.Singleton.Info("键盘上方向键事件");
                    break;
                case Utils.ConstClass.VK_RIGHT:
                    Logger.Singleton.Info("键盘右方向键事件");
                    break;
                case Utils.ConstClass.VK_DOWN:
                    Logger.Singleton.Info("键盘下方向键事件");
                    break;
                case Utils.ConstClass.VK_ESCAPE:
                    Logger.Singleton.Info("键盘ESC键事件");
                    fullScreen();
                    break;
                case Utils.ConstClass.VK_SPACE:
                    Logger.Singleton.Info("空格键事件");
                    AxPlayer_PlayOrPause(tvUrl);//("http://hd.yinyuetai.com/uploads/videos/common/E6E90165F112591DC08AF52DA40112E9.mp4?sc=dfeae283fd371dfd&br=1094&vid=3293228&aid=39611&area=KR&vst=0");
                    break;
                default:
                    break;
            }
        }
        /// <summary>
        /// 在 APlayer 引擎成功打开一个媒体文件时
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AxPlayer_OnOpenSucceeded(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 在用户进行一个 SetPosition 的异步调用完成后
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AxPlayer_OnSeekCompleted(object sender, AxAPlayer3Lib._IPlayerEvents_OnSeekCompletedEvent e)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 在所播放的视频的分辨率改变时触发
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AxPlayer_OnVideoSizeChanged(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 特定扩展事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AxPlayer_OnEvent(object sender, AxAPlayer3Lib._IPlayerEvents_OnEventEvent e)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 播放器暂停或播放
        /// </summary>
        /// <param name="url"></param>
        private void AxPlayer_PlayOrPause(string url)
        {
            if (lw.axPlayer.GetState() == 5)
            {
                lw.axPlayer.Pause();
            }
            else if (lw.axPlayer.GetState() == 0)
            {
                lw.axPlayer.Open(url);
                lw.axPlayer.Play();
                BaseControl.BackgroundImage = null;
                BaseControl.Refresh();
            }
            else if (lw.axPlayer.GetState() == 3)
            {
                lw.axPlayer.Play();
            }
        }
        #endregion

        #region 窗体控件添加
        private void AddControl()
        {
            //添加左上角显示内容标签（状态，声音等）
            if (dl_PlayerExplain == null)
            {
                dl_PlayerExplain = new DuiLabel();
                BaseControl.DUIControls.Add(dl_PlayerExplain);
            }
            dl_PlayerExplain.Text = "";
            dl_PlayerExplain.TextAlign = ContentAlignment.MiddleCenter;
            dl_PlayerExplain.Font = new Font("微软雅黑", 10F, FontStyle.Regular);
            dl_PlayerExplain.Size = new Size(200, 20);
            dl_PlayerExplain.ForeColor = Color.White;
            dl_PlayerExplain.Location = new Point(playerPoint.X - this.Location.X, playerPoint.Y - this.Location.Y);
            dl_PlayerExplain.Visible = true;

            #region 播放器控制控件添加
            //添加播放器控制控件
            //停止按钮
            btnStop.Name = "btnStop";
            btnStop.Size = new Size(30, 30);
            btnStop.ShowBorder = false;
            btnStop.BaseColor = Color.Transparent;
            btnStop.BackgroundImage = Properties.Resources.stop1;
            btnStop.BackgroundImageLayout = ImageLayout.Zoom;
            btnStop.IsPureColor = true;
            btnStop.Tag = "停止";
            //上一个按钮
            btnPrev.Name = "btnPrev";
            btnPrev.Size = new Size(30, 30);
            btnPrev.ShowBorder = false;
            btnPrev.BaseColor = Color.Transparent;
            btnPrev.BackgroundImage = Properties.Resources.sys1;
            btnPrev.BackgroundImageLayout = ImageLayout.Zoom;
            btnPrev.IsPureColor = true;
            btnPrev.Tag = "上一个";
            //播放按钮
            btnPlay.Name = "btnPlay";
            btnPlay.Size = new Size(30, 30);
            btnPlay.ShowBorder = false;
            btnPlay.BaseColor = Color.Transparent;
            btnPlay.BackgroundImage = Properties.Resources.play1;
            btnPlay.BackgroundImageLayout = ImageLayout.Zoom;
            btnPlay.IsPureColor = true;
            btnPlay.Tag = "播放";
            //下一个按钮
            btnNext.Name = "btnNext";
            btnNext.Size = new Size(30, 30);
            btnNext.ShowBorder = false;
            btnNext.BaseColor = Color.Transparent;
            btnNext.BackgroundImage = Properties.Resources.xys1;
            btnNext.BackgroundImageLayout = ImageLayout.Zoom;
            btnNext.IsPureColor = true;
            btnNext.Tag = "下一个";
            //打开文件按钮
            btnOpenFile.Name = "btnOpenFile";
            btnOpenFile.Size = new Size(30, 30);
            btnOpenFile.ShowBorder = false;
            btnOpenFile.BaseColor = Color.Transparent;
            btnOpenFile.BackgroundImage = Properties.Resources.dkwj1;
            btnOpenFile.BackgroundImageLayout = ImageLayout.Zoom;
            btnOpenFile.IsPureColor = true;
            btnOpenFile.Tag = "打开文件";
            //声音按钮
            btnVolume.Name = "btnVolume";
            btnVolume.Size = new Size(30, 30);
            btnVolume.ShowBorder = false;
            btnVolume.BaseColor = Color.Transparent;
            btnVolume.BackgroundImage = Properties.Resources.volume1;
            btnVolume.BackgroundImageLayout = ImageLayout.Zoom;
            btnVolume.IsPureColor = true;
            btnVolume.Tag = "静音";
            //声音进度条

            //播放进度条

            //播放进度标签

            //截图按钮
            btnScreenShot.Name = "btnScreenShot";
            btnScreenShot.Size = new Size(30, 30);
            btnScreenShot.ShowBorder = false;
            btnScreenShot.BaseColor = Color.Transparent;
            btnScreenShot.BackgroundImage = Properties.Resources.jietu1;
            btnScreenShot.BackgroundImageLayout = ImageLayout.Zoom;
            btnScreenShot.IsPureColor = true;
            btnScreenShot.Tag = "截图";
            //全屏按钮
            btnFullScreen.Name = "btnFullScreen";
            btnFullScreen.Size = new Size(30, 30);
            btnFullScreen.ShowBorder = false;
            btnFullScreen.BaseColor = Color.Transparent;
            btnFullScreen.BackgroundImage = Properties.Resources.allSize1;
            btnFullScreen.BackgroundImageLayout = ImageLayout.Zoom;
            btnFullScreen.IsPureColor = true;
            btnFullScreen.Tag = "全屏";
            //列表按钮
            btnList.Name = "btnList";
            btnList.Size = new Size(30, 30);
            btnList.ShowBorder = false;
            btnList.BaseColor = Color.Transparent;
            btnList.BackgroundImage = Properties.Resources.list1;
            btnList.BackgroundImageLayout = ImageLayout.Zoom;
            btnList.IsPureColor = true;
            btnList.Tag = "列表";
            playPanel.DUIControls.AddRange(new LayeredSkin.DirectUI.DuiBaseControl[] {
                btnStop,btnPrev,btnPlay,btnNext,btnOpenFile,btnVolume,btnScreenShot,btnFullScreen,btnList
            });
            #endregion
        }

        #endregion

        #region 窗体样式配置
        /// <summary>
        /// 设置默认背景
        /// </summary>
        private void SetDefaultSkin()
        {
            BaseControl.BackColor = Color.FromArgb(1, 255, 255, 255);
            btnStop.Location = new Point(20, 5);
            btnPrev.Location = new Point(70, 5);
            btnPlay.Location = new Point(120, 5);
            btnNext.Location = new Point(170, 5);
            btnOpenFile.Location = new Point(220, 5);
            btnVolume.Location = new Point(270, 5);
            btnScreenShot.Location = new Point(playPanel.Width - 150, 5);
            btnFullScreen.Location = new Point(playPanel.Width - 100, 5);
            btnList.Location = new Point(playPanel.Width - 50, 5);
        }

        private void Panel_Top_MouseDown(object sender, MouseEventArgs e)
        {
            //为当前的应用程序释放鼠标捕获
            ReleaseCapture();
            //发送消息﹐让系統误以为在标题栏上按下鼠标
            SendMessage((int)this.Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
        }

        #endregion

        #region 窗体大小修改及位置移动

        bool isMouseDown = false; //表示鼠标当前是否处于按下状态，初始值为否 
        MouseDirection direction = MouseDirection.None;//表示拖动的方向，起始为None，表示不拖动

        private void Control_MouseDown(object sender, MouseEventArgs e)
        {
            //鼠标按下 
            isMouseDown = true;
        }

        private void Control_MouseUp(object sender, MouseEventArgs e)
        {
            // 鼠标弹起，

            isMouseDown = false;
            //既然鼠标弹起了，那么就不能再改变窗体尺寸，拖拽方向置 none
            direction = MouseDirection.None;
        }

        private void Control_MouseMove(object sender, MouseEventArgs e)
        {
            Size thisZ = new Size();
            if (sender is LayeredPanel)
            {
                LayeredPanel lpn = sender as LayeredPanel;
                thisZ = lpn.Size;
            }
            else if (sender is DuiButton)
            {
                DuiButton btn_Resize = sender as DuiButton;
                thisZ = btn_Resize.Size;
            }
            //鼠标移动过程中，坐标时刻在改变 
            //当鼠标移动时横坐标距离窗体右边缘5像素以内且纵坐标距离下边缘也在5像素以内时，要将光标变为倾斜的箭头形状，同时拖拽方向direction置为MouseDirection.Declining 
            if (e.Location.X <= 5 && e.Location.Y <= 5)
            {
                this.Cursor = Cursors.SizeNWSE;
                direction = MouseDirection.Declining;
            }
            //当鼠标移动时横坐标距离窗体右边缘5像素以内时，要将光标变为倾斜的箭头形状，同时拖拽方向direction置为MouseDirection.Herizontal
            else if (e.Location.X <= 5)
            {
                this.Cursor = Cursors.SizeWE;
                direction = MouseDirection.Herizontal;
            }
            //同理当鼠标移动时纵坐标距离窗体下边缘5像素以内时，要将光标变为倾斜的箭头形状，同时拖拽方向direction置为MouseDirection.Vertical
            else if (e.Location.Y <= 5)
            {
                this.Cursor = Cursors.SizeNS;
                direction = MouseDirection.Vertical;

            }
            //否则，以外的窗体区域，鼠标星座均为单向箭头（默认）             
            else
                this.Cursor = Cursors.Arrow;
            //设定好方向后，调用下面方法，改变窗体大小  
            ResizeWindow();
        }

        private void ResizeWindow()
        {
            //这个判断很重要，只有在鼠标按下时才能拖拽改变窗体大小，如果不作判断，那么鼠标弹起和按下时，窗体都可以改变 
            if (!isMouseDown)
                return;
            if (MousePosition.X - this.Left < 730 || MousePosition.Y - this.Top < 520)
            {
                return;
            }
            //MousePosition的参考点是屏幕的左上角，表示鼠标当前相对于屏幕左上角的坐标this.left和this.top的参考点也是屏幕，属性MousePosition是该程序的重点
            if (direction == MouseDirection.Declining)
            {
                //此行代码在mousemove事件中已经写过，在此再写一遍，并不多余，一定要写
                this.Cursor = Cursors.SizeNWSE;
                //下面是改变窗体宽和高的代码，不明白的可以仔细思考一下
                this.Width = MousePosition.X - this.Left;
                this.Height = MousePosition.Y - this.Top;
            }
            //以下同理
            if (direction == MouseDirection.Herizontal)
            {
                this.Cursor = Cursors.SizeWE;
                this.Width = MousePosition.X - this.Left;
            }
            else if (direction == MouseDirection.Vertical)
            {
                this.Cursor = Cursors.SizeNS;
                this.Height = MousePosition.Y - this.Top;
            }
            //即使鼠标按下，但是不在窗口右和下边缘，那么也不能改变窗口大小
            else
            {
                this.Cursor = Cursors.Arrow;
                //为当前的应用程序释放鼠标捕获
                ReleaseCapture();
                //发送消息﹐让系統误以为在标题栏上按下鼠标
                SendMessage((int)this.Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
            }
        }
        //定义一个枚举，表示拖动方向
        public enum MouseDirection
        {
            Herizontal,//水平方向拖动，只改变窗体的宽度        
            Vertical,//垂直方向拖动，只改变窗体的高度 
            Declining,//倾斜方向，同时改变窗体的宽度和高度        
            None//不做标志，即不拖动窗体改变大小 
        }

        #endregion

        #region 自定义事件
        public void fullScreen()
        {
            if (IsFull)
            {
                this.WindowState = FormWindowState.Normal;
                IsFull = false;
            }
            else
            {
                this.WindowState = FormWindowState.Maximized;
                IsFull = true;
            }
            BaseControl.Focus();
            //lw.axPlayer.Focus();
        }

        [DllImport("user32.dll", EntryPoint = "SetParent")]
        public static extern int SetParent(IntPtr hWndChild, IntPtr hWndNewParent);

        [DllImport("User32.dll")]
        public static extern IntPtr GetForegroundWindow();     //获取活动窗口句柄

        private void creatTimerforLayeredWindowShow()
        {
            LayeredWindowShowTimer.Interval = 50;
            LayeredWindowShowTimer.Elapsed += LayeredWindowShowTimer_Elapsed; //定时时间到的时候的回调函数
            LayeredWindowShowTimer.AutoReset = true;//需要反复检测鼠标
            LayeredWindowShowTimer.Enabled = true;  //启动定时器

        }

        /* 定时器回调函数 */
        private void LayeredWindowShowTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            //如果鼠标在窗体边缘附近  
            if (this.WindowState != FormWindowState.Minimized)
            {
                IntPtr hWnd = GetForegroundWindow();    //获取活动窗口句柄

                if (flg_LayeredWindow_is_show == 0 && this.Handle == hWnd)
                {
                    //lw.Location = new Point(this.Left, this.Top);
                    lw.TopMost = true;
                    this.TopMost = true;
                    //lw.TopLevel = false;
                    SetParent(this.Handle, lw.Handle);
                    lw.Show();
                }
                flg_LayeredWindow_is_show = 1;
            }
            else
            {
                lw.Hide();
                //lw.TopMost = false;
                //this.TopMost = false;
                flg_LayeredWindow_is_show = 0;
            }
        }
        #endregion

    }
}