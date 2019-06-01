namespace DeclineAplay
{
    partial class PlayerForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PlayerForm));
            this.BaseControl = new LayeredSkin.Controls.LayeredBaseControl();
            this.playPanel = new LayeredSkin.Controls.LayeredPanel();
            this.lb_bfjd = new LayeredSkin.Controls.LayeredLabel();
            this.tkb_sound = new LayeredSkin.Controls.LayeredTrackBar();
            this.tkb_jdt = new LayeredSkin.Controls.LayeredTrackBar();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel_min.SuspendLayout();
            this.panel_close.SuspendLayout();
            this.playPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel_min
            // 
            this.panel_min.Borders.BottomColor = System.Drawing.Color.Empty;
            this.panel_min.Borders.BottomWidth = 1;
            this.panel_min.Borders.LeftColor = System.Drawing.Color.Empty;
            this.panel_min.Borders.LeftWidth = 1;
            this.panel_min.Borders.RightColor = System.Drawing.Color.Empty;
            this.panel_min.Borders.RightWidth = 1;
            this.panel_min.Borders.TopColor = System.Drawing.Color.Empty;
            this.panel_min.Borders.TopWidth = 1;
            this.panel_min.Location = new System.Drawing.Point(670, 0);
            // 
            // panel_close
            // 
            this.panel_close.Borders.BottomColor = System.Drawing.Color.Empty;
            this.panel_close.Borders.BottomWidth = 1;
            this.panel_close.Borders.LeftColor = System.Drawing.Color.Empty;
            this.panel_close.Borders.LeftWidth = 1;
            this.panel_close.Borders.RightColor = System.Drawing.Color.Empty;
            this.panel_close.Borders.RightWidth = 1;
            this.panel_close.Borders.TopColor = System.Drawing.Color.Empty;
            this.panel_close.Borders.TopWidth = 1;
            this.panel_close.Location = new System.Drawing.Point(700, 0);
            // 
            // btn_min
            // 
            this.btn_min.Borders.BottomColor = System.Drawing.Color.Empty;
            this.btn_min.Borders.BottomWidth = 1;
            this.btn_min.Borders.LeftColor = System.Drawing.Color.Empty;
            this.btn_min.Borders.LeftWidth = 1;
            this.btn_min.Borders.RightColor = System.Drawing.Color.Empty;
            this.btn_min.Borders.RightWidth = 1;
            this.btn_min.Borders.TopColor = System.Drawing.Color.Empty;
            this.btn_min.Borders.TopWidth = 1;
            // 
            // btn_close
            // 
            this.btn_close.Borders.BottomColor = System.Drawing.Color.Empty;
            this.btn_close.Borders.BottomWidth = 1;
            this.btn_close.Borders.LeftColor = System.Drawing.Color.Empty;
            this.btn_close.Borders.LeftWidth = 1;
            this.btn_close.Borders.RightColor = System.Drawing.Color.Empty;
            this.btn_close.Borders.RightWidth = 1;
            this.btn_close.Borders.TopColor = System.Drawing.Color.Empty;
            this.btn_close.Borders.TopWidth = 1;
            // 
            // BaseControl
            // 
            this.BaseControl.BackgroundImage = global::DeclineAplay.Properties.Resources._5;
            this.BaseControl.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.BaseControl.Borders.BottomColor = System.Drawing.Color.Empty;
            this.BaseControl.Borders.BottomWidth = 1;
            this.BaseControl.Borders.LeftColor = System.Drawing.Color.Empty;
            this.BaseControl.Borders.LeftWidth = 1;
            this.BaseControl.Borders.RightColor = System.Drawing.Color.Empty;
            this.BaseControl.Borders.RightWidth = 1;
            this.BaseControl.Borders.TopColor = System.Drawing.Color.Empty;
            this.BaseControl.Borders.TopWidth = 1;
            this.BaseControl.Canvas = ((System.Drawing.Bitmap)(resources.GetObject("BaseControl.Canvas")));
            this.BaseControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BaseControl.Location = new System.Drawing.Point(0, 0);
            this.BaseControl.Name = "BaseControl";
            this.BaseControl.Size = new System.Drawing.Size(730, 520);
            this.BaseControl.TabIndex = 6;
            this.BaseControl.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BaseControl_KeyDown);
            this.BaseControl.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.BaseControl_KeyPress);
            this.BaseControl.KeyUp += new System.Windows.Forms.KeyEventHandler(this.BaseControl_KeyUp);
            this.BaseControl.MouseClick += new System.Windows.Forms.MouseEventHandler(this.BaseControl_MouseClick);
            this.BaseControl.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.BaseControl_MouseDoubleClick);
            this.BaseControl.MouseLeave += new System.EventHandler(this.BaseControl_MouseLeave);
            this.BaseControl.MouseHover += new System.EventHandler(this.BaseControl_MouseHover);
            this.BaseControl.MouseMove += new System.Windows.Forms.MouseEventHandler(this.BaseControl_MouseMove);
            // 
            // playPanel
            // 
            this.playPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.playPanel.Borders.BottomColor = System.Drawing.Color.Empty;
            this.playPanel.Borders.BottomWidth = 1;
            this.playPanel.Borders.LeftColor = System.Drawing.Color.Empty;
            this.playPanel.Borders.LeftWidth = 1;
            this.playPanel.Borders.RightColor = System.Drawing.Color.Empty;
            this.playPanel.Borders.RightWidth = 1;
            this.playPanel.Borders.TopColor = System.Drawing.Color.Empty;
            this.playPanel.Borders.TopWidth = 1;
            this.playPanel.Canvas = ((System.Drawing.Bitmap)(resources.GetObject("playPanel.Canvas")));
            this.playPanel.Controls.Add(this.lb_bfjd);
            this.playPanel.Controls.Add(this.tkb_sound);
            this.playPanel.Controls.Add(this.tkb_jdt);
            this.playPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.playPanel.Location = new System.Drawing.Point(0, 442);
            this.playPanel.Name = "playPanel";
            this.playPanel.Size = new System.Drawing.Size(730, 78);
            this.playPanel.TabIndex = 7;
            this.playPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Control_MouseDown);
            this.playPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Control_MouseMove);
            this.playPanel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Control_MouseUp);
            // 
            // lb_bfjd
            // 
            this.lb_bfjd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.lb_bfjd.Borders.BottomColor = System.Drawing.Color.Empty;
            this.lb_bfjd.Borders.BottomWidth = 1;
            this.lb_bfjd.Borders.LeftColor = System.Drawing.Color.Empty;
            this.lb_bfjd.Borders.LeftWidth = 1;
            this.lb_bfjd.Borders.RightColor = System.Drawing.Color.Empty;
            this.lb_bfjd.Borders.RightWidth = 1;
            this.lb_bfjd.Borders.TopColor = System.Drawing.Color.Empty;
            this.lb_bfjd.Borders.TopWidth = 1;
            this.lb_bfjd.Canvas = ((System.Drawing.Bitmap)(resources.GetObject("lb_bfjd.Canvas")));
            this.lb_bfjd.ForeColor = System.Drawing.Color.White;
            this.lb_bfjd.HaloSize = 5;
            this.lb_bfjd.Location = new System.Drawing.Point(0, 3);
            this.lb_bfjd.Name = "lb_bfjd";
            this.lb_bfjd.Size = new System.Drawing.Size(115, 16);
            this.lb_bfjd.TabIndex = 45;
            this.lb_bfjd.Text = "00:00:00/00:00:00";
            this.lb_bfjd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tkb_sound
            // 
            this.tkb_sound.AdaptImage = true;
            this.tkb_sound.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tkb_sound.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.tkb_sound.BackImage = null;
            this.tkb_sound.BackLineColor = System.Drawing.Color.Gray;
            this.tkb_sound.Borders.BottomColor = System.Drawing.Color.Empty;
            this.tkb_sound.Borders.BottomWidth = 1;
            this.tkb_sound.Borders.LeftColor = System.Drawing.Color.Empty;
            this.tkb_sound.Borders.LeftWidth = 1;
            this.tkb_sound.Borders.RightColor = System.Drawing.Color.Empty;
            this.tkb_sound.Borders.RightWidth = 1;
            this.tkb_sound.Borders.TopColor = System.Drawing.Color.Empty;
            this.tkb_sound.Borders.TopWidth = 1;
            this.tkb_sound.Canvas = ((System.Drawing.Bitmap)(resources.GetObject("tkb_sound.Canvas")));
            this.tkb_sound.ControlRectangle = new System.Drawing.Rectangle(5, 5, 247, 2);
            this.tkb_sound.LineWidth = 2;
            this.tkb_sound.Location = new System.Drawing.Point(312, 34);
            this.tkb_sound.MouseCanControl = true;
            this.tkb_sound.Name = "tkb_sound";
            this.tkb_sound.Orientation = LayeredSkin.Controls.Orientations.Horizontal;
            this.tkb_sound.PointImage = ((System.Drawing.Image)(resources.GetObject("tkb_sound.PointImage")));
            this.tkb_sound.PointImageHover = null;
            this.tkb_sound.PointImagePressed = null;
            this.tkb_sound.PointState = LayeredSkin.Controls.ControlStates.Normal;
            this.tkb_sound.Size = new System.Drawing.Size(257, 12);
            this.tkb_sound.SurfaceImage = null;
            this.tkb_sound.SurfaceLineColor = System.Drawing.Color.White;
            this.tkb_sound.TabIndex = 44;
            this.tkb_sound.Value = 0.5D;
            this.tkb_sound.ValueChanged += new System.EventHandler(this.tkb_sound_ValueChanged);
            this.tkb_sound.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tkb_jdt_MouseDown);
            this.tkb_sound.MouseUp += new System.Windows.Forms.MouseEventHandler(this.tkb_sound_MouseUp);
            // 
            // tkb_jdt
            // 
            this.tkb_jdt.AdaptImage = true;
            this.tkb_jdt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tkb_jdt.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.tkb_jdt.BackImage = null;
            this.tkb_jdt.BackLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.tkb_jdt.Borders.BottomColor = System.Drawing.Color.Empty;
            this.tkb_jdt.Borders.BottomWidth = 1;
            this.tkb_jdt.Borders.LeftColor = System.Drawing.Color.Empty;
            this.tkb_jdt.Borders.LeftWidth = 1;
            this.tkb_jdt.Borders.RightColor = System.Drawing.Color.Empty;
            this.tkb_jdt.Borders.RightWidth = 1;
            this.tkb_jdt.Borders.TopColor = System.Drawing.Color.Empty;
            this.tkb_jdt.Borders.TopWidth = 1;
            this.tkb_jdt.Canvas = ((System.Drawing.Bitmap)(resources.GetObject("tkb_jdt.Canvas")));
            this.tkb_jdt.ControlRectangle = new System.Drawing.Rectangle(5, 5, 608, 15);
            this.tkb_jdt.LineWidth = 3;
            this.tkb_jdt.Location = new System.Drawing.Point(112, 0);
            this.tkb_jdt.MouseCanControl = true;
            this.tkb_jdt.Name = "tkb_jdt";
            this.tkb_jdt.Orientation = LayeredSkin.Controls.Orientations.Horizontal;
            this.tkb_jdt.PointImage = ((System.Drawing.Image)(resources.GetObject("tkb_jdt.PointImage")));
            this.tkb_jdt.PointImageHover = ((System.Drawing.Image)(resources.GetObject("tkb_jdt.PointImageHover")));
            this.tkb_jdt.PointImagePressed = ((System.Drawing.Image)(resources.GetObject("tkb_jdt.PointImagePressed")));
            this.tkb_jdt.PointState = LayeredSkin.Controls.ControlStates.Normal;
            this.tkb_jdt.Size = new System.Drawing.Size(618, 25);
            this.tkb_jdt.SurfaceImage = null;
            this.tkb_jdt.SurfaceLineColor = System.Drawing.Color.White;
            this.tkb_jdt.TabIndex = 43;
            this.tkb_jdt.Value = 0.7D;
            this.tkb_jdt.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tkb_jdt_MouseDown);
            this.tkb_jdt.MouseUp += new System.Windows.Forms.MouseEventHandler(this.tkb_jdt_MouseUp);
            // 
            // timer1
            // 
            this.timer1.Interval = 200;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // PlayerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(730, 520);
            this.Controls.Add(this.playPanel);
            this.Controls.Add(this.BaseControl);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.DoubleBuffered = true;
            this.Name = "PlayerForm";
            this.Radius = 0;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.LocationChanged += new System.EventHandler(this.MainForm_LocationChanged);
            this.SizeChanged += new System.EventHandler(this.MainForm_SizeChanged);
            this.Controls.SetChildIndex(this.BaseControl, 0);
            this.Controls.SetChildIndex(this.playPanel, 0);
            this.Controls.SetChildIndex(this.panel_close, 0);
            this.Controls.SetChildIndex(this.panel_min, 0);
            this.panel_min.ResumeLayout(false);
            this.panel_close.ResumeLayout(false);
            this.playPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        public LayeredSkin.Controls.LayeredBaseControl BaseControl;
        private LayeredSkin.Controls.LayeredPanel playPanel;
        private System.Windows.Forms.Timer timer1;
        private LayeredSkin.Controls.LayeredLabel lb_bfjd;
        private LayeredSkin.Controls.LayeredTrackBar tkb_sound;
        public LayeredSkin.Controls.LayeredTrackBar tkb_jdt;
    }
}