using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Runtime.InteropServices;
using LayeredSkin.Controls;
using LayeredSkin.DirectUI;
using System.Windows.Forms;
using System.IO;
using System.Threading;

namespace DeclineAplay
{
    public partial class PlayerForm : BaseForm
    {
        private LayeredWindow lw = new LayeredWindow();
        ToolTip toolTip1 = new ToolTip();
        private System.Timers.Timer LayeredWindowShowTimer = new System.Timers.Timer();
        private Controls.PlayeListControl Play_List;
        public Color defaultSkinColor = Color.Black;//Color.FromArgb(120, 56, 249, 215);//Color.FromArgb(255, 92, 138);
        DuiLabel dl_PlayerExplain = null;//播放器窗体上说明控件
        DuiLabel dl_TvName = null;
        Point playerPoint = new Point();
        bool IsFull = false;//是否全屏
        Rectangle Nor = new Rectangle(0, 0, 0, 0);//位置
        int volumeNum = 50;//视频音量
        bool isControlValid = false;
        public string tvUrl = "";
        public string tvName = "";
        string cacheFileName = "";
        string filePath = AppDomain.CurrentDomain.BaseDirectory + @"CacheTv\";
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
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            #region 变量初始
            //tvUrl = "http://hd.yinyuetai.com/uploads/videos/common/E6E90165F112591DC08AF52DA40112E9.mp4";
            //tvUrl = string.IsNullOrEmpty(tvUrl) ? "http://video.aajka.cn:8081/1jxxl/JXXL669FEG/JXXL669FEG.m3u8" : tvUrl;
            //tvUrl = "http://220.194.238.105/8/w/o/i/p/woipppekntdgjmavnqnyqmrewqnxpd/he.yinyuetai.com/AEF80142ECA75C75BA3860D4D0D5EFFC.flv";
            tvUrl = "http://cdn-2.haku99.com/hls/2018/12/06/bb2TbMGU/playlist.m3u8";
            //tvName = "纵有疾风起，人生不言弃";
            tvName = string.IsNullOrEmpty(tvName) ? "捉迷藏(T-ara)" : tvName;
            tkb_jdt.Value = 0;
            tkb_jdt.Enabled = false;
            #endregion
            SetDefaultSkin();
            AddControl();
            lw.axPlayer.SetVolume(50);
            tkb_sound.Value = 50 / 200;
            lw.axPlayer.OnStateChanged += AxPlayer_OnStateChanged;//状态变化事件
            lw.axPlayer.OnDownloadCodec += AxPlayer_OnDownloadCodec;//在 APlayer 引擎播放某个媒体文件缺少对应的解码器时
            lw.axPlayer.OnBuffer += AxPlayer_OnBuffer;//网络缓冲
            lw.axPlayer.OnMessage += AxPlayer_OnMessage;//鼠标键盘操作事件
            lw.axPlayer.OnOpenSucceeded += AxPlayer_OnOpenSucceeded;//媒体文件打开成功的事件
            lw.axPlayer.OnSeekCompleted += AxPlayer_OnSeekCompleted;//在用户进行一个 SetPosition 的异步调用完成后
            lw.axPlayer.OnVideoSizeChanged += AxPlayer_OnVideoSizeChanged;//在所播放的视频的分辨率改变时触发
            lw.axPlayer.OnEvent += AxPlayer_OnEvent;//特定扩展事件
            lw.axPlayer.Leave += BaseControl_MouseLeave;
        }
        /// <summary>
        /// 设置播放器配置
        /// </summary>
        private void SetAplayConfig()
        {
            lw.axPlayer.SetConfig(8, "1");//设置是否打开成功后自动播放，0-不自动播放，1-自动播放，默认为1
            lw.axPlayer.SetConfig(1102, "10");//播放 HTTP 网络视频时，失败重连次数，默认为 5 次
            lw.axPlayer.SetConfig(1001, "500");//设置当网络没有读取到数据时，等待多少个视频帧进入缓冲（可以通过视频帧率换算成时间），默认为 500
            lw.axPlayer.SetConfig(1002, "1000");//设置在缓冲状态下，缓冲多少个帧退出缓冲，默认为 1000
            lw.axPlayer.SetConfig(1003, "1000");//设置未缓冲状态下，最多预先读取多少个帧，即数据读取时间点超前当前播放时间点的距离
            lw.axPlayer.SetConfig(1004, "100");//设置拖动播放进度后，没有数据时多久进入缓冲，单位毫秒。
            cacheFileName = filePath;
            if (!Directory.Exists(cacheFileName))
            {
                Directory.CreateDirectory(cacheFileName);
            }
            cacheFileName = cacheFileName + new Uri(tvUrl).Segments[new Uri(tvUrl).Segments.Length - 1];
            lw.axPlayer.SetConfig(2201, cacheFileName);//在线播放时本地缓存文件名，如设置为空字符串，则不缓存到本地；该参数默认值为空字符串；缓存文件也可以用 APlayer 打开继续播放。
            Logger.Singleton.Info("播放视频" + tvName + "地址为:" + tvUrl);
            lw.axPlayer.SetConfig(2207, "1");//设置是否在播放媒体文件时贪婪下载所有的数据到缓存文件。
        }

        private void BaseControl_MouseLeave(object sender, EventArgs e)
        {
            //playPanel.Visible = false;
            dl_TvName.Visible = false;
        }

        private void BaseControl_MouseMove(object sender, MouseEventArgs e)
        {
            dl_TvName.Visible = true;
        }
        private void BaseControl_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                AxPlayer_PlayOrPause(tvUrl);
            }
            else
            {
                updatePlayerExplain("鼠标右键单击");
            }
        }

        private void BaseControl_MouseHover(object sender, EventArgs e)
        {
            //updatePlayerExplain("鼠标悬停");
            //playPanel.Visible = false;
        }

        private void BaseControl_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //updatePlayerExplain("鼠标双击");
            fullScreen();
        }

        private void BaseControl_KeyPress(object sender, KeyPressEventArgs e)
        {
            switch ((int)e.KeyChar)
            {
                case Utils.ConstClass.VK_SPACE:
                    if (!lw.Visible)
                    {
                        lw.Show();
                    }
                    //updatePlayerExplain("空格键事件");
                    AxPlayer_PlayOrPause(tvUrl);//("http://hd.yinyuetai.com/uploads/videos/common/E6E90165F112591DC08AF52DA40112E9.mp4?sc=dfeae283fd371dfd&br=1094&vid=3293228&aid=39611&area=KR&vst=0");
                    break;
                default:
                    break;
            }
        }

        private void BaseControl_KeyDown(object sender, KeyEventArgs e)
        {
            //updatePlayerExplain(e.KeyValue.ToString());
        }

        private void BaseControl_KeyUp(object sender, KeyEventArgs e)
        {
            updatePlayerExplain(e.KeyValue.ToString());
            switch (e.KeyValue)
            {
                case Utils.ConstClass.VK_LEFT:
                    //updatePlayerExplain("键盘左方向键事件");
                    lw.axPlayer.SetPosition((lw.axPlayer.GetPosition() - 10000 < 0 ? 0 : lw.axPlayer.GetPosition() - 10000));//快退10S
                    updatePlayerExplain("快退10秒");
                    isControlValid = false;
                    break;
                case Utils.ConstClass.VK_RIGHT:
                    //updatePlayerExplain("键盘右方向键事件");
                    lw.axPlayer.SetPosition((lw.axPlayer.GetPosition() + 10000 > lw.axPlayer.GetDuration() ? lw.axPlayer.GetDuration() - 1000 : lw.axPlayer.GetPosition() + 10000));//快进10S
                    updatePlayerExplain("快进10秒");
                    isControlValid = false;
                    break;

                case Utils.ConstClass.VK_UP:
                    volumeNum = lw.axPlayer.GetVolume();
                    if (volumeNum < 200)
                    {
                        volumeNum += 10;
                    }
                    else
                    {
                        volumeNum += 30;
                    }
                    volumeNum = volumeNum >= 1000 ? 1000 : volumeNum;
                    lw.axPlayer.SetVolume(volumeNum);
                    updatePlayerExplain(volumeNum >= 1000 ? "当前已是最大音量！" : "当前音量：" + lw.axPlayer.GetVolume().ToString());
                    break;
                case Utils.ConstClass.VK_DOWN:
                    volumeNum = lw.axPlayer.GetVolume();
                    if (volumeNum > 200)
                    {
                        volumeNum -= 30;
                    }
                    else
                    {
                        volumeNum -= 10;
                    }
                    volumeNum = volumeNum <= 0 ? 0 : volumeNum;
                    lw.axPlayer.SetVolume(volumeNum);
                    updatePlayerExplain(volumeNum <= 0 ? "当前已是最小音量！" : "当前音量：" + lw.axPlayer.GetVolume().ToString());
                    break;
                case Utils.ConstClass.VK_ESCAPE:
                    //updatePlayerExplain("键盘ESC键事件");
                    fullScreen();
                    break;
                default:
                    break;
            }
            Thread thread = new Thread(() => updateTime());
            thread.Start();
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
                    dl_PlayerExplain.Location = new Point(5, 5);
                }
                btnScreenShot.Location = new Point(playPanel.Width - 150, 25);
                btnFullScreen.Location = new Point(playPanel.Width - 100, 25);
                btnList.Location = new Point(playPanel.Width - 50, 25);
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
                    dl_PlayerExplain.Location = new Point(5, 5);
                }
            }
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
                    updatePlayerExplain("准备就绪");
                    break;
                case 1: //正在打开
                    updatePlayerExplain("正在打开");
                    break;
                case 2://正在暂停
                    updatePlayerExplain("正在暂停");
                    break;
                case 3://暂停中
                    updatePlayerExplain("暂停中");
                    break;
                case 4://正在开始播放
                    updatePlayerExplain("正在开始播放");
                    break;
                case 5://播放中
                    updatePlayerExplain("播放中");
                    break;
                case 6://正在开始关闭
                    updatePlayerExplain("正在开始关闭");
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
            if (e.nPercent != 100)
            {
                updatePlayerExplain("正在缓冲(" + lw.axPlayer.GetBufferProgress().ToString() + "%)  下载速度：" + lw.axPlayer.GetConfig(41) + "KB/s");
            }
            else
            {
                updatePlayerExplain("正在播放"); ;
            }
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
        public void AxPlayer_PlayOrPause(string url)
        {
            tvUrl = url;
            if (!lw.Visible)
            {
                lw.Show();
                lw.TopMost = true;
                this.TopMost = true;
                playPanel.BringToFront();
                BindPlayerControl();
            }
            if (lw.axPlayer.GetState() == 5)
            {
                lw.axPlayer.Pause();
                if (btnPlay != null)
                {
                    btnPlay.BackgroundImage = Properties.Resources.play1;
                    btnPlay.Tag = "播放";
                }
            }
            else if (lw.axPlayer.GetState() == 0)
            {
                BaseControl.BackColor = Color.FromArgb(1, 255, 255, 255);
                lw.axPlayer.Open(url);
                lw.axPlayer.Play();
                BaseControl.BackgroundImage = null;
                if (btnPlay != null)
                {
                    btnPlay.BackgroundImage = Properties.Resources.pause1;
                    btnPlay.Tag = "暂停";
                }
                SetAplayConfig();
            }
            else if (lw.axPlayer.GetState() == 3)
            {
                lw.axPlayer.Play();
                if (btnPlay != null)
                {
                    btnPlay.BackgroundImage = Properties.Resources.pause1;
                    btnPlay.Tag = "暂停";
                }
            }
        }
        /// <summary>
        /// 绑定播放器相关控制到控件
        /// </summary>
        private void BindPlayerControl()
        {
            lb_bfjd.Text = "00:00:00/" + TimeToString(TimeSpan.FromMilliseconds(lw.axPlayer.GetDuration()));
            tkb_jdt.Enabled = true;
            timer1.Start();
        }
        private void tkb_jdt_MouseUp(object sender, MouseEventArgs e)
        {
            isControlValid = false;
            lw.axPlayer.SetPosition((int)(tkb_jdt.Value * lw.axPlayer.GetDuration()));
            lb_bfjd.Text = TimeToString(TimeSpan.FromMilliseconds(lw.axPlayer.GetPosition())) + "/" + TimeToString(TimeSpan.FromMilliseconds(lw.axPlayer.GetDuration()));
        }

        private void tkb_jdt_MouseDown(object sender, MouseEventArgs e)
        {
            isControlValid = true;
        }

        private void tkb_sound_MouseUp(object sender, MouseEventArgs e)
        {
            isControlValid = false;
            lw.axPlayer.SetVolume((int)(tkb_sound.Value * 200));
            updatePlayerExplain("当前音量：" + lw.axPlayer.GetVolume().ToString());
        }
        #endregion

        #region 窗体控件添加
        private void AddControl()
        {
            #region 添加左上角显示内容标签（状态，声音等）
            if (dl_PlayerExplain == null)
            {
                dl_PlayerExplain = new DuiLabel();
                BaseControl.DUIControls.Add(dl_PlayerExplain);
            }
            updatePlayerExplain("");
            dl_PlayerExplain.TextAlign = ContentAlignment.MiddleLeft;
            dl_PlayerExplain.Font = new Font("微软雅黑", 10F, FontStyle.Regular);
            dl_PlayerExplain.Size = new Size(500, 20);
            dl_PlayerExplain.ForeColor = Color.White;
            dl_PlayerExplain.Location = new Point(5, 5);
            dl_PlayerExplain.Visible = true;
            #endregion

            #region 标题控件
            if (dl_TvName == null)
            {
                dl_TvName = new DuiLabel();
                dl_TvName.Dock = DockStyle.Top;
                dl_TvName.TextAlign = ContentAlignment.MiddleCenter;
                dl_TvName.Font = new Font("微软雅黑", 15F, FontStyle.Bold);
                dl_TvName.Size = new Size(BaseControl.Width, 35);
                dl_TvName.ForeColor = Color.White;
                dl_TvName.Location = new Point(0, 0);
                dl_TvName.BackColor = Color.Transparent;
                dl_TvName.Visible = true;
                dl_TvName.MouseDown += Dl_TvName_MouseDown;
                dl_TvName.MouseUp += Dl_TvName_MouseUp;
                dl_TvName.MouseMove += Dl_TvName_MouseMove;
                dl_TvName.MouseLeave += Dl_TvName_MouseLeave;
                BaseControl.DUIControls.Add(dl_TvName);
            }
            dl_TvName.Text = tvName.Length > 15 ? tvName.Substring(0, 15) + "......" : tvName;
            #endregion

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
            btnStop.Cursor = Cursors.Hand;
            btnStop.Tag = "停止";
            btnStop.MouseEnter += BtnPlayControl_MouseEnter;
            btnStop.MouseLeave += BtnPlayControl_MouseLeave;
            btnStop.MouseClick += BtnPlayControl_MouseClick;
            //上一个按钮
            btnPrev.Name = "btnPrev";
            btnPrev.Size = new Size(30, 30);
            btnPrev.ShowBorder = false;
            btnPrev.BaseColor = Color.Transparent;
            btnPrev.BackgroundImage = Properties.Resources.sys1;
            btnPrev.BackgroundImageLayout = ImageLayout.Zoom;
            btnPrev.Cursor = Cursors.Hand;
            btnPrev.IsPureColor = true;
            btnPrev.Tag = "上一个";
            btnPrev.MouseEnter += BtnPlayControl_MouseEnter;
            btnPrev.MouseLeave += BtnPlayControl_MouseLeave;
            btnPrev.MouseClick += BtnPlayControl_MouseClick;
            //播放按钮
            btnPlay.Name = "btnPlay";
            btnPlay.Size = new Size(30, 30);
            btnPlay.ShowBorder = false;
            btnPlay.BaseColor = Color.Transparent;
            btnPlay.BackgroundImage = Properties.Resources.play1;
            btnPlay.BackgroundImageLayout = ImageLayout.Zoom;
            btnPlay.IsPureColor = true;
            btnPlay.Cursor = Cursors.Hand;
            btnPlay.Tag = "播放";
            btnPlay.MouseEnter += BtnPlayControl_MouseEnter;
            btnPlay.MouseLeave += BtnPlayControl_MouseLeave;
            btnPlay.MouseClick += BtnPlayControl_MouseClick;
            //下一个按钮
            btnNext.Name = "btnNext";
            btnNext.Size = new Size(30, 30);
            btnNext.ShowBorder = false;
            btnNext.BaseColor = Color.Transparent;
            btnNext.BackgroundImage = Properties.Resources.xys1;
            btnNext.BackgroundImageLayout = ImageLayout.Zoom;
            btnNext.IsPureColor = true;
            btnNext.Cursor = Cursors.Hand;
            btnNext.Tag = "下一个";
            btnNext.MouseEnter += BtnPlayControl_MouseEnter;
            btnNext.MouseLeave += BtnPlayControl_MouseLeave;
            btnNext.MouseClick += BtnPlayControl_MouseClick;
            //打开文件按钮
            btnOpenFile.Name = "btnOpenFile";
            btnOpenFile.Size = new Size(30, 30);
            btnOpenFile.ShowBorder = false;
            btnOpenFile.BaseColor = Color.Transparent;
            btnOpenFile.BackgroundImage = Properties.Resources.dkwj1;
            btnOpenFile.BackgroundImageLayout = ImageLayout.Zoom;
            btnOpenFile.IsPureColor = true;
            btnOpenFile.Cursor = Cursors.Hand;
            btnOpenFile.Tag = "打开文件";
            btnOpenFile.MouseEnter += BtnPlayControl_MouseEnter;
            btnOpenFile.MouseLeave += BtnPlayControl_MouseLeave;
            btnOpenFile.MouseClick += BtnPlayControl_MouseClick;
            //声音按钮
            btnVolume.Name = "btnVolume";
            btnVolume.Size = new Size(30, 30);
            btnVolume.ShowBorder = false;
            btnVolume.BaseColor = Color.Transparent;
            btnVolume.BackgroundImage = Properties.Resources.volume1;
            btnVolume.BackgroundImageLayout = ImageLayout.Zoom;
            btnVolume.IsPureColor = true;
            btnVolume.Cursor = Cursors.Hand;
            btnVolume.Tag = "静音";
            btnVolume.MouseEnter += BtnPlayControl_MouseEnter;
            btnVolume.MouseLeave += BtnPlayControl_MouseLeave;
            btnVolume.MouseClick += BtnPlayControl_MouseClick;
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
            btnScreenShot.Cursor = Cursors.Hand;
            btnScreenShot.Tag = "截图";
            btnScreenShot.MouseEnter += BtnPlayControl_MouseEnter;
            btnScreenShot.MouseLeave += BtnPlayControl_MouseLeave;
            btnScreenShot.MouseClick += BtnPlayControl_MouseClick;
            //全屏按钮
            btnFullScreen.Name = "btnFullScreen";
            btnFullScreen.Size = new Size(30, 30);
            btnFullScreen.ShowBorder = false;
            btnFullScreen.BaseColor = Color.Transparent;
            btnFullScreen.BackgroundImage = Properties.Resources.allSize1;
            btnFullScreen.BackgroundImageLayout = ImageLayout.Zoom;
            btnFullScreen.IsPureColor = true;
            btnFullScreen.Cursor = Cursors.Hand;
            btnFullScreen.Tag = "全屏";
            btnFullScreen.MouseEnter += BtnPlayControl_MouseEnter;
            btnFullScreen.MouseLeave += BtnPlayControl_MouseLeave;
            btnFullScreen.MouseClick += BtnPlayControl_MouseClick;
            //列表按钮
            btnList.Name = "btnList";
            btnList.Size = new Size(30, 30);
            btnList.ShowBorder = false;
            btnList.BaseColor = Color.Transparent;
            btnList.BackgroundImage = Properties.Resources.list1;
            btnList.BackgroundImageLayout = ImageLayout.Zoom;
            btnList.IsPureColor = true;
            btnList.Cursor = Cursors.Hand;
            btnList.Tag = "列表";
            btnList.MouseEnter += BtnPlayControl_MouseEnter;
            btnList.MouseLeave += BtnPlayControl_MouseLeave;
            btnList.MouseClick += BtnPlayControl_MouseClick;
            //playPanel.DUIControls.AddRange(new LayeredSkin.DirectUI.DuiBaseControl[] {
            //    btnStop,btnPrev,btnPlay,btnNext,btnOpenFile,btnVolume,btnScreenShot,btnFullScreen,btnList
            //});
            playPanel.DUIControls.Add(btnStop);
            playPanel.DUIControls.Add(btnPrev);
            playPanel.DUIControls.Add(btnPlay);
            playPanel.DUIControls.Add(btnNext);
            playPanel.DUIControls.Add(btnOpenFile);
            playPanel.DUIControls.Add(btnVolume);
            playPanel.DUIControls.Add(btnScreenShot);
            playPanel.DUIControls.Add(btnFullScreen);
            playPanel.DUIControls.Add(btnList);
            #endregion

            #region 播放器列表控件添加
            Play_List = new DeclineAplay.Controls.PlayeListControl();
            Play_List.Size = new Size(100, BaseControl.Height - 20);
            Play_List.Location = new Point(BaseControl.Width - 100, 20);
            Play_List.plf = this;
            Play_List.Visible = true;
            List<Utils.PlayListEntity> playLists = new List<Utils.PlayListEntity>();
            Utils.PlayListEntity ple = new Utils.PlayListEntity();
            ple.tvImgUrl = "视频图片地址";
            ple.tvName = tvName;
            ple.tvUrl = tvUrl;
            ple.tvTimeLength = "12分钟";
            playLists.Add(ple);
            Play_List.AddList(playLists);
            this.Controls.Add(Play_List);
            #endregion
        }
        #endregion

        #region 播放器控制控件事件
        private void BtnPlayControl_MouseLeave(object sender, EventArgs e)
        {
            toolTip1.Hide(this);
            DuiButton mbu = sender as DuiButton;
            switch (mbu.Name)
            {
                case "btnStop"://停止按钮
                    mbu.BackgroundImage = Properties.Resources.stop1;
                    break;
                case "btnPrev"://上一个
                    mbu.BackgroundImage = Properties.Resources.sys1;
                    break;
                case "btnPlay"://播放或暂停;
                    if (mbu.BackgroundImage == Properties.Resources.play2)
                    {
                        mbu.BackgroundImage = Properties.Resources.play1;
                    }
                    else if (mbu.BackgroundImage == Properties.Resources.play1)
                    {
                        mbu.BackgroundImage = Properties.Resources.play2;
                    }
                    else if (mbu.BackgroundImage == Properties.Resources.pause1)
                    {
                        mbu.BackgroundImage = Properties.Resources.pause2;
                    }
                    else
                    {
                        mbu.BackgroundImage = Properties.Resources.pause1;
                    }
                    break;
                case "btnNext"://下一个
                    mbu.BackgroundImage = Properties.Resources.xys1;
                    break;
                case "btnOpenFile"://打开文件
                    mbu.BackgroundImage = Properties.Resources.dkwj1;
                    break;
                case "btnVolume"://静音
                    mbu.BackgroundImage = Properties.Resources.volume1;
                    break;
                case "btnScreenShot"://截图
                    mbu.BackgroundImage = Properties.Resources.jietu1;
                    break;
                case "btnFullScreen"://全屏
                    mbu.BackgroundImage = Properties.Resources.allSize1;
                    break;
                case "btnList"://列表
                    mbu.BackgroundImage = Properties.Resources.list1;
                    break;
                default:
                    break;
            }
        }

        private void BtnPlayControl_MouseEnter(object sender, EventArgs e)
        {
            toolTip1.Show(((DuiButton)sender).Tag.ToString().ToString(), this, PointToClient(MousePosition).X, PointToClient(MousePosition).Y + 15, 2000);
            DuiButton mbu = sender as DuiButton;
            switch (mbu.Name)
            {
                case "btnStop"://停止按钮
                    mbu.BackgroundImage = Properties.Resources.stop2;
                    break;
                case "btnPrev"://上一个
                    mbu.BackgroundImage = Properties.Resources.sys2;
                    break;
                case "btnPlay"://播放或暂停
                    if (mbu.BackgroundImage == Properties.Resources.play1)
                    {
                        mbu.BackgroundImage = Properties.Resources.play2;
                    }
                    else if (mbu.BackgroundImage == Properties.Resources.play2)
                    {
                        mbu.BackgroundImage = Properties.Resources.play1;
                    }
                    else if (mbu.BackgroundImage == Properties.Resources.pause1)
                    {
                        mbu.BackgroundImage = Properties.Resources.pause2;
                    }
                    else
                    {
                        mbu.BackgroundImage = Properties.Resources.pause1;
                    }
                    break;
                case "btnNext"://下一个
                    mbu.BackgroundImage = Properties.Resources.xys2;
                    break;
                case "btnOpenFile"://打开文件
                    mbu.BackgroundImage = Properties.Resources.dkwj2;
                    break;
                case "btnVolume"://静音
                    mbu.BackgroundImage = Properties.Resources.volume2;
                    break;
                case "btnScreenShot"://截图
                    mbu.BackgroundImage = Properties.Resources.jietu2;
                    break;
                case "btnFullScreen"://全屏
                    mbu.BackgroundImage = Properties.Resources.allSize2;
                    break;
                case "btnList"://列表
                    mbu.BackgroundImage = Properties.Resources.list2;
                    break;
                default:
                    break;
            }
        }

        private void BtnPlayControl_MouseClick(object sender, DuiMouseEventArgs e)
        {
            DuiButton mbu = sender as DuiButton;
            switch (mbu.Name)
            {
                case "btnStop"://停止按钮
                    lw.axPlayer.Close();
                    lw.Hide();
                    BaseControl.BackColor = defaultSkinColor;
                    BaseControl.BackgroundImage = Properties.Resources._5;
                    Thread thread = new Thread(() => convertCacheFileToOther());
                    thread.Start();
                    break;
                case "btnPrev"://上一个

                    break;
                case "btnPlay"://播放或暂停
                    AxPlayer_PlayOrPause(tvUrl);
                    break;
                case "btnNext"://下一个

                    break;
                case "btnOpenFile"://打开文件

                    break;
                case "btnVolume"://静音

                    break;
                case "btnScreenShot"://截图

                    break;
                case "btnFullScreen"://全屏
                    fullScreen();
                    break;
                case "btnList"://列表
                    isShowList();
                    break;
                default:
                    break;
            }
        }
        #endregion

        #region 窗体样式配置
        /// <summary>
        /// 设置默认背景
        /// </summary>
        private void SetDefaultSkin()
        {
            BaseControl.BackColor = defaultSkinColor;
            playPanel.BackColor = Color.FromArgb(1, 255, 255, 255);
            btnStop.Location = new Point(20, 25);
            btnPrev.Location = new Point(70, 25);
            btnPlay.Location = new Point(120, 25);
            btnNext.Location = new Point(170, 25);
            btnOpenFile.Location = new Point(220, 25);
            btnVolume.Location = new Point(270, 25);
            btnScreenShot.Location = new Point(playPanel.Width - 150, 25);
            btnFullScreen.Location = new Point(playPanel.Width - 100, 25);
            btnList.Location = new Point(playPanel.Width - 50, 25);
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
            else if (sender is LayeredBaseControl)
            {
                LayeredBaseControl lns = sender as LayeredBaseControl;
                thisZ = lns.Size;
            }
            //鼠标移动过程中，坐标时刻在改变 
            //当鼠标移动时横坐标距离窗体右边缘5像素以内且纵坐标距离下边缘也在5像素以内时，要将光标变为倾斜的箭头形状，同时拖拽方向direction置为MouseDirection.Declining 
            //(e.Location.X <= 5 && e.Location.Y <= 5) || (e.Location.X >= thisZ.Width - 5 && e.Location.Y <= 5) || (e.Location.X <= 4 && e.Location.Y >= thisZ.Height - 5)
            if ((e.Location.X >= thisZ.Width - 5 && e.Location.Y >= thisZ.Height - 5))
            {
                this.Cursor = Cursors.SizeNWSE;
                direction = MouseDirection.Declining;
            }
            ////当鼠标移动时横坐标距离窗体右边缘5像素以内时，要将光标变为倾斜的箭头形状，同时拖拽方向direction置为MouseDirection.Herizontal
            //else if (e.Location.X <= 5 || e.Location.X >= thisZ.Width - 5)
            //{
            //    this.Cursor = Cursors.SizeWE;
            //    direction = MouseDirection.Herizontal;
            //}
            ////同理当鼠标移动时纵坐标距离窗体下边缘5像素以内时，要将光标变为倾斜的箭头形状，同时拖拽方向direction置为MouseDirection.Vertical
            //else if (e.Location.Y <= 5 || e.Location.Y >= thisZ.Height - 5)
            //{
            //    this.Cursor = Cursors.SizeNS;
            //    direction = MouseDirection.Vertical;

            //}
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

        private void Dl_TvName_MouseDown(object sender, DuiMouseEventArgs e)
        {
            //为当前的应用程序释放鼠标捕获
            ReleaseCapture();
            //发送消息﹐让系統误以为在标题栏上按下鼠标
            SendMessage((int)this.Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
            dl_TvName.Cursor = Cursors.Arrow;
        }
        private void Dl_TvName_MouseUp(object sender, DuiMouseEventArgs e)
        {
            dl_TvName.Cursor = Cursors.Arrow;
        }

        private void Dl_TvName_MouseLeave(object sender, EventArgs e)
        {
            dl_TvName.Cursor = Cursors.Arrow;
        }

        private void Dl_TvName_MouseMove(object sender, DuiMouseEventArgs e)
        {
            //dl_TvName.Cursor = Cursors.SizeAll;
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

        /// <summary>
        /// 时间格式转换
        /// </summary>
        /// <param name="span"></param>
        /// <returns></returns>
        string TimeToString(TimeSpan span)
        {
            return span.Hours.ToString("00") + ":" +
            span.Minutes.ToString("00") + ":" +
            span.Seconds.ToString("00");
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Thread thread = new Thread(() => updateTime());
            thread.Start();
        }

        private void updateTime()
        {
            lb_bfjd.Text = TimeToString(TimeSpan.FromMilliseconds(lw.axPlayer.GetPosition())) + "/" + TimeToString(TimeSpan.FromMilliseconds(lw.axPlayer.GetDuration()));
            if (lw.axPlayer.GetDuration() != 0 && !isControlValid)
            {
                tkb_jdt.Value = Math.Round((Double)lw.axPlayer.GetPosition() / lw.axPlayer.GetDuration(), 3);
                tkb_sound.Value = lw.axPlayer.GetVolume() >= 200 ? 1.0 : Math.Round((Double)lw.axPlayer.GetVolume() / 200, 3);
            }
            if (lw.axPlayer.GetBufferProgress() > 0)
            {
                updatePlayerExplain("正在缓冲(" + lw.axPlayer.GetBufferProgress().ToString() + "%)  下载速度：" + lw.axPlayer.GetConfig(41) + "KB/s");
            }
            else
            {
                Thread thread = new Thread(() => getCacheFileProgress());
                if (lw.axPlayer.GetState() != 0)
                {
                    thread.Start();
                }
            }
        }

        delegate void AsynupdatePlayerExplain(string textStr);
        private void updatePlayerExplain(string textStr)
        {
            if (this.BaseControl.InvokeRequired)
            {
                AsynupdatePlayerExplain au = new AsynupdatePlayerExplain(updatePlayerExplain);
                this.Invoke(au, new object[] { textStr });
            }
            else
            {
                dl_PlayerExplain.Text = textStr;
            }
        }
        /// <summary>
        /// 获取播放媒体缓存进度
        /// </summary>
        private void getCacheFileProgress()
        {
            string fileList = lw.axPlayer.GetConfig(2203);
            string sfileList = "";//缓存完成
            string efileList = "";//缓存未完成
            for (int i = 0; i < fileList.Length; i++)
            {
                string nChar = fileList.Substring(i, 1);
                sfileList = sfileList + (nChar.Equals("1") ? "1" : "");
                efileList = efileList + (nChar.Equals("0") ? "0" : "");
            }
            //updatePlayerExplain("缓存完成:" + GetString(sfileList.Length * 640 * 1024) + "未完成:" + GetString((efileList.Length <= 0 ? 0 : efileList.Length) * 640 * 1024));
            string bufferStr = (Math.Round((sfileList.Length > 0 ? (Double)sfileList.Length / (sfileList.Length + efileList.Length) : (Double)0), 3) * 100).ToString();
            if (!bufferStr.Equals("100"))
            {
                updatePlayerExplain("缓冲进度:" + bufferStr + "%");
            }
        }

        private void convertCacheFileToOther()
        {
            if (lw.axPlayer.SetConfig(2204, cacheFileName) == 1)
            {
                Logger.Singleton.Info("缓存文件:" + cacheFileName + ";转换后的文件:" + filePath + tvName.Trim() + "." + (cacheFileName.Replace("m3u8", "mp4")).Split('.')[1]);
                lw.axPlayer.SetConfig(2205, cacheFileName + ";" + filePath + tvName.Trim() + "." + (cacheFileName.Replace("m3u8", "mp4")).Split('.')[1]);//把缓存文件转换成媒体文件，参数格式："缓存文件名;媒体文件名"，即使未下载完成的缓存文件也能转换成媒体文件，不过未完成的数据块被填充为0。
            }
            else
            {
                Logger.Singleton.Info("缓存未完成，没有进行视频转换！");
            }
        }

        public static string GetString(long b)
        {
            const int GB = 1024 * 1024 * 1024;
            const int MB = 1024 * 1024;
            const int KB = 1024;

            if (b / GB >= 1)
            {
                return Math.Round(b / (float)GB, 2) + "GB";
            }


            if (b / MB >= 1)
            {
                return Math.Round(b / (float)MB, 2) + "MB";
            }


            if (b / KB >= 1)
            {
                return Math.Round(b / (float)KB, 2) + "KB";
            }


            return b + "B";
        }

        private void isShowList()
        {
            if (Play_List.Visible)
            {
                Play_List.Visible = false;
                Play_List.SendToBack();
            }
            else
            {
                Play_List.Visible = true;
                Play_List.BringToFront();
            }
        }
        #endregion

        private void tkb_sound_ValueChanged(object sender, EventArgs e)
        {
            if (lw.axPlayer != null)
            {
                lw.axPlayer.SetVolume((int)(tkb_sound.Value * 200));
                updatePlayerExplain("当前音量：" + lw.axPlayer.GetVolume().ToString());
            }
        }
    }
}
