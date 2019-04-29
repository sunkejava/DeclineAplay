using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LayeredSkin.Forms;

namespace DeclineAplay
{
    public partial class LayeredWindow : LayeredForm
    {
        public LayeredWindow()
        {
            InitializeComponent();
        }

        private void LayeredWindow_Load(object sender, EventArgs e)
        {
            MainForm mf = new MainForm(this);
            mf.Show();
        }

        private void LayeredWindow_AutoSizeChanged(object sender, EventArgs e)
        {
            axPlayer.Size = this.Size;
        }
    }
}
