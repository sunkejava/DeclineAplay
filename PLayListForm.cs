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
    public partial class PLayListForm : LayeredForm
    {
        public List<Utils.PlayListEntity> playList = null;
        public PlayerForm plf = null;
        public PLayListForm()
        {
            InitializeComponent();
        }

        private void PLayListForm_Load(object sender, EventArgs e)
        {
            playeListControl1.plf = plf;
            playeListControl1.AddList(playList);
            playeListControl1.RefreshList();
        }
    }
}
