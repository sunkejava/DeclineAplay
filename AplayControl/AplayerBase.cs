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
    public partial class AplayerBase : Panel
    {
        public AxPlayer _axPlayer;
        public AplayerBase()
        {
            InitializeComponent();
            _axPlayer = new AxPlayer();
        }

        [Category("Aplayer自带方法"), Description("设置APlayer引擎视频区域在未播放视频时显示的图片"), Browsable(true)]
        public bool setDefaultLogo(Image img)
        {
            Bitmap bmp = new Bitmap(img);
            _axPlayer.SetCustomLogo(bmp.GetHbitmap().ToInt32());
            return true;
        }

        [Category("Aplaye"), Description("设置cs"), Browsable(true)]
        public bool isSetW(bool isa)
        {

            return isa;
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            _axPlayer.Dock = DockStyle.Fill;
            this.Controls.Add(_axPlayer);
            base.OnPaint(pe);
        }
    }
}
