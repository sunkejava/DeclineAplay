using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AxAPlayer3Lib;

namespace DeclineAplay.AplayControl
{
    public partial class AplayerBase : AxPlayer
    {
        public AplayerBase()
        {
            InitializeComponent();
            new AxPlayer();
        }

        [Description("设置APlayer引擎视频区域"), Category("Aplayer自带属性")]
        public Boolean setDefaultSize(Size sz)
        {
            this.Size = sz;
            return true;
        }

        [Description("设置APlayer引擎视频区域在未播放视频时显示的图片"), Category("Aplayer自带方法")]
        public bool setDefaultLogo(Image img)
        {
            Bitmap bmp = new Bitmap(img);
            this.SetCustomLogo(bmp.GetHbitmap().ToInt32());
            return true;
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }
    }
}
