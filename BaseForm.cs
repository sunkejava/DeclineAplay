using LayeredSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DeclineAplay
{
    public partial class BaseForm : LayeredSkin.Forms.LayeredForm
    {
        public BaseForm()
        {
            InitializeComponent();
        }

        private void btn_min_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
            if (sender is LayeredButton)
            {
                LayeredButton thisButton = sender as LayeredButton;
                thisButton.BackColor = Color.Transparent;
            }
            else if (sender is LayeredPanel)
            {
                LayeredPanel thisButton = sender as LayeredPanel;
                thisButton.BackColor = Color.Transparent;
            }
        }

        private void btn_min_MouseEnter(object sender, EventArgs e)
        {
            LayeredButton thisButton = sender as LayeredButton;
            switch (thisButton.Name)
            {
                case "btn_min":
                    panel_min.BackColor = Color.FromArgb(100, 234, 234, 234);
                    break;
                default:
                    panel_close.BackColor = Color.FromArgb(255, 88, 88);
                    break;
            }
        }

        private void btn_min_MouseLeave(object sender, EventArgs e)
        {
            LayeredButton thisButton = sender as LayeredButton;
            thisButton.BackColor = Color.Transparent;
        }

        private void panel_min_MouseEnter(object sender, EventArgs e)
        {
            LayeredPanel thisButton = sender as LayeredPanel;
            switch (thisButton.Name)
            {
                case "panel_close":
                    thisButton.BackColor = Color.FromArgb(255, 88, 88);
                    break;
                default:
                    thisButton.BackColor = Color.FromArgb(100, 234, 234, 234);
                    break;
            }
        }

        private void panel_min_MouseLeave(object sender, EventArgs e)
        {
            LayeredPanel thisButton = sender as LayeredPanel;
            thisButton.BackColor = Color.Transparent;
        }

        public virtual void btn_close_Click(object sender, EventArgs e)
        {
            this.Dispose();
            this.Close();
        }
    }
}
