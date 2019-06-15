namespace DeclineAplay
{
    partial class PLayListForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PLayListForm));
            this.playeListControl1 = new DeclineAplay.Controls.PlayeListControl();
            this.SuspendLayout();
            // 
            // playeListControl1
            // 
            this.playeListControl1.AutoFocus = false;
            this.playeListControl1.BackColor = System.Drawing.Color.Transparent;
            this.playeListControl1.Borders.BottomColor = System.Drawing.Color.Empty;
            this.playeListControl1.Borders.BottomWidth = 1;
            this.playeListControl1.Borders.LeftColor = System.Drawing.Color.Empty;
            this.playeListControl1.Borders.LeftWidth = 1;
            this.playeListControl1.Borders.RightColor = System.Drawing.Color.Empty;
            this.playeListControl1.Borders.RightWidth = 1;
            this.playeListControl1.Borders.TopColor = System.Drawing.Color.Empty;
            this.playeListControl1.Borders.TopWidth = 1;
            this.playeListControl1.Canvas = ((System.Drawing.Bitmap)(resources.GetObject("playeListControl1.Canvas")));
            this.playeListControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.playeListControl1.EnabledMouseWheel = true;
            this.playeListControl1.ItemSize = new System.Drawing.Size(100, 100);
            this.playeListControl1.ListTop = 0;
            this.playeListControl1.Location = new System.Drawing.Point(0, 0);
            this.playeListControl1.Name = "playeListControl1";
            this.playeListControl1.Orientation = LayeredSkin.Controls.ListOrientation.Vertical;
            this.playeListControl1.RollSize = 20;
            this.playeListControl1.ScrollBarBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.playeListControl1.ScrollBarColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.playeListControl1.ScrollBarHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.playeListControl1.ScrollBarWidth = 10;
            this.playeListControl1.ShowScrollBar = true;
            this.playeListControl1.Size = new System.Drawing.Size(184, 545);
            this.playeListControl1.SmoothScroll = true;
            this.playeListControl1.TabIndex = 0;
            this.playeListControl1.Text = "playeListControl1";
            this.playeListControl1.Ulmul = false;
            this.playeListControl1.Value = 0D;
            // 
            // PLayListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.ClientSize = new System.Drawing.Size(184, 545);
            this.Controls.Add(this.playeListControl1);
            this.HaloColor = System.Drawing.Color.Transparent;
            this.Name = "PLayListForm";
            this.Radius = 20;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "";
            this.Activated += new System.EventHandler(this.PLayListForm_Activated);
            this.Load += new System.EventHandler(this.PLayListForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.PlayeListControl playeListControl1;
    }
}