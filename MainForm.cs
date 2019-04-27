using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AxAPlayer3Lib;

namespace DeclineAplay
{
    public partial class MainForm : BaseForm
    {

        public MainForm()
        {
            InitializeComponent();
        }
        AxAPlayer3Lib.AxPlayer _apl = null;
        private void MainForm_Load(object sender, EventArgs e)
        {
            _apl = new AxAPlayer3Lib.AxPlayer();
            _apl.Name = "defaultAplayer";
            _apl.Size = new Size(500, 350);
            _apl.Location = new Point(10, 15);
            _apl.Visible = true;
            this.Controls.Add(_apl);
            _apl.SetVolume(50);
            _apl.Open("http://hd.yinyuetai.com/uploads/videos/common/E6E90165F112591DC08AF52DA40112E9.mp4?sc=dfeae283fd371dfd&br=1094&vid=3293228&aid=39611&area=KR&vst=0");
            _apl.Play();
            foreach (Control item in this.Controls)
            {
                Logger.Singleton.Error(item.Name + " SIZE:" + item.Size.ToString() + " V:" + item.Visible.ToString());
            }

        }

        public override void btn_close_Click(object sender, EventArgs e)
        {
            if (_apl != null)
            {
                _apl.Dispose();
            }
            base.btn_close_Click(sender, e);
        }
    }
}
