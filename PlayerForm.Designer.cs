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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PlayerForm));
            this.BaseControl = new LayeredSkin.Controls.LayeredBaseControl();
            this.playPanel = new LayeredSkin.Controls.LayeredPanel();
            this.tkb_sound = new LayeredSkin.Controls.LayeredTrackBar();
            this.tkb_basic = new LayeredSkin.Controls.LayeredTrackBar();
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
            this.BaseControl.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
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
            this.BaseControl.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.BaseControl_KeyPress);
            this.BaseControl.KeyUp += new System.Windows.Forms.KeyEventHandler(this.BaseControl_KeyUp);
            this.BaseControl.MouseClick += new System.Windows.Forms.MouseEventHandler(this.BaseControl_MouseClick);
            this.BaseControl.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.BaseControl_MouseDoubleClick);
            this.BaseControl.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Control_MouseDown);
            this.BaseControl.MouseLeave += new System.EventHandler(this.BaseControl_MouseLeave);
            this.BaseControl.MouseHover += new System.EventHandler(this.BaseControl_MouseHover);
            this.BaseControl.MouseMove += new System.Windows.Forms.MouseEventHandler(this.BaseControl_MouseMove);
            this.BaseControl.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Control_MouseUp);
            // 
            // playPanel
            // 
            this.playPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
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
            this.playPanel.Controls.Add(this.tkb_sound);
            this.playPanel.Controls.Add(this.tkb_basic);
            this.playPanel.Location = new System.Drawing.Point(0, 479);
            this.playPanel.Name = "playPanel";
            this.playPanel.Size = new System.Drawing.Size(730, 40);
            this.playPanel.TabIndex = 7;
            // 
            // tkb_sound
            // 
            this.tkb_sound.AdaptImage = true;
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
            this.tkb_sound.ControlRectangle = new System.Drawing.Rectangle(5, 5, 40, 2);
            this.tkb_sound.LineWidth = 2;
            this.tkb_sound.Location = new System.Drawing.Point(149, 14);
            this.tkb_sound.MouseCanControl = true;
            this.tkb_sound.Name = "tkb_sound";
            this.tkb_sound.Orientation = LayeredSkin.Controls.Orientations.Horizontal;
            this.tkb_sound.PointImage = ((System.Drawing.Image)(resources.GetObject("tkb_sound.PointImage")));
            this.tkb_sound.PointImageHover = null;
            this.tkb_sound.PointImagePressed = null;
            this.tkb_sound.PointState = LayeredSkin.Controls.ControlStates.Normal;
            this.tkb_sound.Size = new System.Drawing.Size(50, 12);
            this.tkb_sound.SurfaceImage = null;
            this.tkb_sound.SurfaceLineColor = System.Drawing.Color.White;
            this.tkb_sound.TabIndex = 44;
            this.tkb_sound.Value = 0.5D;
            // 
            // tkb_basic
            // 
            this.tkb_basic.AdaptImage = true;
            this.tkb_basic.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.tkb_basic.BackImage = null;
            this.tkb_basic.BackLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.tkb_basic.Borders.BottomColor = System.Drawing.Color.Empty;
            this.tkb_basic.Borders.BottomWidth = 1;
            this.tkb_basic.Borders.LeftColor = System.Drawing.Color.Empty;
            this.tkb_basic.Borders.LeftWidth = 1;
            this.tkb_basic.Borders.RightColor = System.Drawing.Color.Empty;
            this.tkb_basic.Borders.RightWidth = 1;
            this.tkb_basic.Borders.TopColor = System.Drawing.Color.Empty;
            this.tkb_basic.Borders.TopWidth = 1;
            this.tkb_basic.Canvas = ((System.Drawing.Bitmap)(resources.GetObject("tkb_basic.Canvas")));
            this.tkb_basic.ControlRectangle = new System.Drawing.Rectangle(5, 5, 383, 15);
            this.tkb_basic.LineWidth = 3;
            this.tkb_basic.Location = new System.Drawing.Point(223, 8);
            this.tkb_basic.MouseCanControl = true;
            this.tkb_basic.Name = "tkb_basic";
            this.tkb_basic.Orientation = LayeredSkin.Controls.Orientations.Horizontal;
            this.tkb_basic.PointImage = ((System.Drawing.Image)(resources.GetObject("tkb_basic.PointImage")));
            this.tkb_basic.PointImageHover = ((System.Drawing.Image)(resources.GetObject("tkb_basic.PointImageHover")));
            this.tkb_basic.PointImagePressed = ((System.Drawing.Image)(resources.GetObject("tkb_basic.PointImagePressed")));
            this.tkb_basic.PointState = LayeredSkin.Controls.ControlStates.Normal;
            this.tkb_basic.Size = new System.Drawing.Size(393, 25);
            this.tkb_basic.SurfaceImage = null;
            this.tkb_basic.SurfaceLineColor = System.Drawing.Color.White;
            this.tkb_basic.TabIndex = 43;
            this.tkb_basic.Value = 0.7D;
            // 
            // PlayerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.BackgroundImage = global::DeclineAplay.Properties.Resources._5;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(730, 520);
            this.Controls.Add(this.playPanel);
            this.Controls.Add(this.BaseControl);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.DoubleBuffered = true;
            this.Name = "PlayerForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.LocationChanged += new System.EventHandler(this.MainForm_LocationChanged);
            this.SizeChanged += new System.EventHandler(this.MainForm_SizeChanged);
            this.Controls.SetChildIndex(this.BaseControl, 0);
            this.Controls.SetChildIndex(this.panel_close, 0);
            this.Controls.SetChildIndex(this.panel_min, 0);
            this.Controls.SetChildIndex(this.playPanel, 0);
            this.panel_min.ResumeLayout(false);
            this.panel_close.ResumeLayout(false);
            this.playPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        public LayeredSkin.Controls.LayeredBaseControl BaseControl;
        private LayeredSkin.Controls.LayeredPanel playPanel;
        public LayeredSkin.Controls.LayeredTrackBar tkb_basic;
        private LayeredSkin.Controls.LayeredTrackBar tkb_sound;
    }
}