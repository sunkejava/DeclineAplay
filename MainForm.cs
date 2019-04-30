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
    public partial class MainForm : BaseForm
    {
        LayeredWindow lw = null;
        public Color defaultSkinColor = Color.FromArgb(255, 92, 138);
        DuiLabel dl_PlayerExplain = null;//播放器窗体上说明控件
        Point playerPoint = new Point();


        #region 模拟窗体移动变量
        [DllImport("user32.dll", EntryPoint = "SendMessageA")]
        private static extern int SendMessage(int hwnd, int wMsg, int wParam, int lParam);

        [DllImport("user32.dll")]
        private static extern int ReleaseCapture();
        private const int WM_NCLBUTTONDOWN = 0XA1;   //.定义鼠標左鍵按下
        private const int HTCAPTION = 2;
        #endregion

        public MainForm(LayeredWindow ilw)
        {
            InitializeComponent();
            lw = ilw;
            SetDefaultSkin();
            SetDefaultAnchr();
            AddControl();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

            lw.axPlayer.SetVolume(50);
            //lw.axPlayer.Open("http://hd.yinyuetai.com/uploads/videos/common/E6E90165F112591DC08AF52DA40112E9.mp4?sc=dfeae283fd371dfd&br=1094&vid=3293228&aid=39611&area=KR&vst=0");
            //lw.axPlayer.Play();
            lw.axPlayer.OnStateChanged += AxPlayer_OnStateChanged;//状态变化事件
            lw.axPlayer.OnDownloadCodec += AxPlayer_OnDownloadCodec;//在 APlayer 引擎播放某个媒体文件缺少对应的解码器时
            lw.axPlayer.OnBuffer += AxPlayer_OnBuffer;//网络缓冲
            lw.axPlayer.OnMessage += AxPlayer_OnMessage;//鼠标键盘操作事件
            lw.axPlayer.OnOpenSucceeded += AxPlayer_OnOpenSucceeded;//媒体文件打开成功的事件
            lw.axPlayer.OnSeekCompleted += AxPlayer_OnSeekCompleted;//在用户进行一个 SetPosition 的异步调用完成后
            lw.axPlayer.OnVideoSizeChanged += AxPlayer_OnVideoSizeChanged;//在所播放的视频的分辨率改变时触发
            lw.axPlayer.OnEvent += AxPlayer_OnEvent;//特定扩展事件
            BaseControl.BackColor = Panel_Bottom.BackColor;
            Logger.Singleton.Error("播放器宽高及位置：" + lw.Size.ToString() + lw.Location.ToString());
            Logger.Singleton.Error("BaseControl宽高及位置：" + BaseControl.Size.ToString() + BaseControl.Location.ToString());
            Logger.Singleton.Error("控件窗体MainForm宽高及位置" + this.Size.ToString() + this.Location.ToString());
            Logger.Singleton.Error("Panel_Left宽高及位置：" + Panel_Left.Size.ToString() + Panel_Left.Location.ToString());
            Logger.Singleton.Error("Panel_Right宽高及位置：" + Panel_Right.Size.ToString() + Panel_Right.Location.ToString());
            Logger.Singleton.Error("Panel_Top宽高及位置：" + Panel_Top.Size.ToString() + Panel_Top.Location.ToString());
            Logger.Singleton.Error("Panel_Bottom宽高及位置：" + Panel_Bottom.Size.ToString() + Panel_Bottom.Location.ToString());
            //Logger.Singleton.Error("dl_PlayerExplain宽高及位置：" + dl_PlayerExplain.Size.ToString() + dl_PlayerExplain.Location.ToString());
        }
        #region 播放器相关事件
        /// <summary>
        /// 播放器状态发生变化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AxPlayer_OnStateChanged(object sender, AxAPlayer3Lib._IPlayerEvents_OnStateChangedEvent e)
        {
            if (e.nNewState == 0)
            {
                //初始化操作
                BaseControl.BackColor = Panel_Top.BackColor;
                lw.TopLevel = false;
                lw.Visible = false;
            }
            else
            {
                BaseControl.BackColor = Color.Transparent;
                lw.TopLevel = true;
                lw.Visible = true;
            }
            switch (e.nNewState)
            {
                case 0: //准备就绪

                    break;
                case 1: //正在打开

                    break;
                case 2://正在暂停

                    break;
                case 3://暂停中

                    break;
                case 4://正在开始播放

                    break;
                case 5://播放中

                    break;
                case 6://正在开始关闭

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
            throw new NotImplementedException();
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
        #endregion

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
                lw.Size = new Size(this.Width - Panel_Left.Width - Panel_Right.Width, this.Height - Panel_Top.Height - Panel_Bottom.Height);
                lw.Location = new Point(this.Location.X + Panel_Left.Width, this.Location.Y + Panel_Top.Height);
                playerPoint = lw.Location;
            }
            this.Refresh();
        }

        #region 窗体控件添加
        private void AddControl()
        {
            DuiButton btn_reSize = new DuiButton();
            btn_reSize.Size = new Size(40, 40);
            btn_reSize.Location = new Point(Panel_Bottom.Width - 40, Panel_Bottom.Height - 40);
            btn_reSize.BackColor = Color.Transparent;
            btn_reSize.BaseColor = btn_reSize.BackColor;
            btn_reSize.AdaptImage = true;
            btn_reSize.NormalImage = Properties.Resources.resize_bottom_right;
            btn_reSize.PressedImage = Properties.Resources.resize_bottom_right;
            btn_reSize.HoverImage = Properties.Resources.resize_bottom_right;
            btn_reSize.MouseDown += Control_MouseDown;
            btn_reSize.MouseUp += Control_MouseUp;
            btn_reSize.MouseMove += Control_MouseMove;
            btn_reSize.Name = "btn_reSize";
            //Panel_Bottom.DUIControls.Add(btn_reSize);
            Panel_Bottom.SizeChanged += Panel_Bottom_SizeChanged;
        }

        private void Panel_Bottom_SizeChanged(object sender, EventArgs e)
        {
            foreach (DuiBaseControl item in BaseControl.DUIControls)
            {
                if (item.Name == "btn_reSize")
                {
                    item.Location = new Point(Panel_Bottom.Width - 40, Panel_Bottom.Height - 40);
                }
            }
            this.Refresh();
        }

        #endregion

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
            Panel_Right.MouseDown += Control_MouseDown;
            Panel_Right.MouseUp += Control_MouseUp;
            Panel_Right.MouseMove += Control_MouseMove;
            Panel_Bottom.MouseDown += Control_MouseDown;
            Panel_Bottom.MouseUp += Control_MouseUp;
            Panel_Bottom.MouseMove += Control_MouseMove;
            Panel_Top.MouseDown += Panel_Top_MouseDown;
            //Panel_Left.MouseDown += Panel_Top_MouseDown;
        }

        private void Panel_Top_MouseDown(object sender, MouseEventArgs e)
        {
            //为当前的应用程序释放鼠标捕获
            ReleaseCapture();
            //发送消息﹐让系統误以为在标题栏上按下鼠标
            SendMessage((int)this.Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
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
        }

        private void BaseControl_MouseLeave(object sender, EventArgs e)
        {
            if (dl_PlayerExplain != null)
            {
                dl_PlayerExplain.Visible = false;
                dl_PlayerExplain.Size = new Size(0, 0);
                dl_PlayerExplain.Location = new Point(0, 0);
                dl_PlayerExplain.Text = "";
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
                Logger.Singleton.Error("控件为：" + (sender as LayeredPanel).Name + "--鼠标位置为：" + e.Location.ToString());
                thisZ = lpn.Size;
            }
            else if (sender is DuiButton)
            {
                DuiButton btn_Resize = sender as DuiButton;
                Logger.Singleton.Error("控件为：" + (sender as DuiButton).Name + "--鼠标位置为：" + e.Location.ToString());
                thisZ = btn_Resize.Size;
            }
            //鼠标移动过程中，坐标时刻在改变 
            //当鼠标移动时横坐标距离窗体右边缘5像素以内且纵坐标距离下边缘也在5像素以内时，要将光标变为倾斜的箭头形状，同时拖拽方向direction置为MouseDirection.Declining 
            if (e.Location.X >= thisZ.Width - 5 && e.Location.Y > thisZ.Height - 5)
            {
                this.Cursor = Cursors.SizeNWSE;
                direction = MouseDirection.Declining;
            }
            //当鼠标移动时横坐标距离窗体右边缘5像素以内时，要将光标变为倾斜的箭头形状，同时拖拽方向direction置为MouseDirection.Herizontal
            else if (e.Location.X >= thisZ.Width - 5)
            {
                this.Cursor = Cursors.SizeWE;
                direction = MouseDirection.Herizontal;
            }
            //同理当鼠标移动时纵坐标距离窗体下边缘5像素以内时，要将光标变为倾斜的箭头形状，同时拖拽方向direction置为MouseDirection.Vertical
            else if (e.Location.Y >= thisZ.Height - 5)
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
            Logger.Singleton.Error("位置：" + MousePosition.ToString());
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

        private void MainForm_SizeChanged(object sender, EventArgs e)
        {
            if (lw != null)
            {
                lw.Size = new Size(this.Width - Panel_Left.Width - Panel_Right.Width, this.Height - Panel_Top.Height - Panel_Bottom.Height);
                lw.Location = new Point(this.Location.X + Panel_Left.Width, this.Location.Y + Panel_Top.Height);
                playerPoint = lw.Location;
                lw.axPlayer.Refresh();
                lw.Refresh();
            }
            this.Refresh();
        }
    }
}
