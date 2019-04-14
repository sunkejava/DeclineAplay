using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AxAPlayer3Lib;
using LayeredSkin.Controls;

namespace DeclineAplay.AplayControl
{
    public partial class AplayerBase : LayeredBaseControl
    {
        public AxPlayer _axPlayer;
        private Image defaultImage;
        private Color aplaybackColor;
        private bool speedup = false;
        private Point logoLocation;

        public AplayerBase()
        {
            InitializeComponent();
            _axPlayer = new AxPlayer();
        }
        #region Aplayer自带属性
        [Description("设置APlayer引擎视频区域在未播放视频时显示的图片"), Category("Aplayer自带属性")]
        public Image DefaultImage {
            get
            {
                return defaultImage;
            }
            set
            {
                defaultImage = value;
            }
        }
        [Description("设置APlayer引擎视频区域在未播放视频时的背景色"), Category("Aplayer自带属性")]
        public Color AplayBackColor
        {
            get
            {
                return aplaybackColor;
            }
            set
            {
                aplaybackColor = value;
            } 
        }

        [Description("获取或设置是否开启硬件加速，1-开启，0-不开启"), Category("Aplayer自带属性")]
        public Boolean Speedup
        {
            get
            {
                return speedup;
            }
            set
            {
                speedup = value;
            }
        }
        [Description("Logo 风格设置设置logo位置，配合AplayBackColor使用，有一个未设置均不生效"), Category("Aplayer自带属性")]
        public Point LogoLocation
        {
            get
            {
                return logoLocation;
            }
            set
            {
                logoLocation = value;
            }
        }
        #endregion

        #region Aplayer自带方法
        [Description("打开需要播放的媒体文件"), Category("Aplayer自带方法")]
        public void Open(string url)
        {
            _axPlayer.Open(url);
        }
        [Description("使 APlayer 引擎由暂停状态进入播放状态"), Category("Aplayer自带方法")]
        public void Play()
        {
            _axPlayer.Play();
        }
        [Description("使 APlayer 引擎由播放状态进入暂停状态"), Category("Aplayer自带方法")]
        public void Pause()
        {
            _axPlayer.Pause();
        }
        [Description("关闭 APlayer 引擎正在播放的媒体文件"), Category("Aplayer自带方法")]
        public void Close()
        {
            _axPlayer.Close();
        }
        [Description("设置 APlayer 引擎"), Category("Aplayer自带方法")]
        public int SetConfig(int nConfigId, string strValue)
        {
            return _axPlayer.SetConfig(nConfigId, strValue);
        }
        [Description("获取 APlayer 引擎的设置"), Category("Aplayer自带方法")]
        public string GetConfig(int nConfigId)
        {
            return _axPlayer.GetConfig(nConfigId);
        }
        [Description("获取 APlayer 引擎的版本号"), Category("Aplayer自带方法")]
        public string GetVersion()
        {
            return _axPlayer.GetVersion();
        }
        [Description("获取 APlayer 引擎的当前状态"), Category("Aplayer自带方法")]
        public int GetState()
        {
            return _axPlayer.GetState();
        }
        [Description("获取当前播放媒体文件的持续时长"), Category("Aplayer自带方法")]
        public int GetDuration()
        {
            return _axPlayer.GetDuration();
        }
        [Description("获取当前播放媒体文件的播放进度"), Category("Aplayer自带方法")]
        public int GetPosition()
        {
            return _axPlayer.GetPosition();
        }
        [Description("设置当前播放媒体文件的播放位置"), Category("Aplayer自带方法")]
        public int SetPosition(int nPosition)
        {
            return _axPlayer.SetPosition(nPosition);
        }
        [Description("获取当前播放音量"), Category("Aplayer自带方法")]
        public int GetVolume()
        {
            return _axPlayer.GetVolume();
        }
        [Description("设置当前播放音量"), Category("Aplayer自带方法")]
        public int SetVolume(int nVolume)
        {
            return _axPlayer.SetVolume(nVolume);
        }
        [Description("获取 APlayer 引擎当前是否处于设置播放进度(Seek)过程中"), Category("Aplayer自带方法")]
        public int IsSeeking()
        {
            return _axPlayer.IsSeeking();
        }
        [Description("获取 APlayer 引擎播放网络文件时的数据缓冲进度"), Category("Aplayer自带方法")]
        public int GetBufferProgress()
        {
            return _axPlayer.GetBufferProgress();
        }
        #endregion

        protected override void OnPaint(PaintEventArgs pe)
        {
            this.Controls.Add(_axPlayer);
            _axPlayer.Dock = DockStyle.Fill;
            if (defaultImage is null)
            {
                _axPlayer.SetCustomLogo(-1);
            }
            else
            {
                //设置背景图片
                Bitmap bmp = new Bitmap(defaultImage);
                _axPlayer.SetCustomLogo(bmp.GetHbitmap().ToInt32());
            }
            //设置背景颜色及自定义logo位置aplaybackColor.ToArgb().ToString() +
            _axPlayer.SetConfig(36,  "16777215;" + (logoLocation.X).ToString() + ";" + (logoLocation.Y).ToString());
            //是否硬件加速
            _axPlayer.SetConfig(209, speedup ? "1" : "0");

            base.OnPaint(pe);
        }
    }
}
