namespace DeclineAplay
{
    partial class BaseForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BaseForm));
            this.panel_min = new LayeredSkin.Controls.LayeredPanel();
            this.btn_min = new LayeredSkin.Controls.LayeredButton();
            this.panel_close = new LayeredSkin.Controls.LayeredPanel();
            this.btn_close = new LayeredSkin.Controls.LayeredButton();
            this.panel_min.SuspendLayout();
            this.panel_close.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel_min
            // 
            this.panel_min.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel_min.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.panel_min.Borders.BottomColor = System.Drawing.Color.Empty;
            this.panel_min.Borders.BottomWidth = 1;
            this.panel_min.Borders.LeftColor = System.Drawing.Color.Empty;
            this.panel_min.Borders.LeftWidth = 1;
            this.panel_min.Borders.RightColor = System.Drawing.Color.Empty;
            this.panel_min.Borders.RightWidth = 1;
            this.panel_min.Borders.TopColor = System.Drawing.Color.Empty;
            this.panel_min.Borders.TopWidth = 1;
            this.panel_min.Canvas = ((System.Drawing.Bitmap)(resources.GetObject("panel_min.Canvas")));
            this.panel_min.Controls.Add(this.btn_min);
            this.panel_min.Location = new System.Drawing.Point(470, 0);
            this.panel_min.Name = "panel_min";
            this.panel_min.Size = new System.Drawing.Size(30, 30);
            this.panel_min.TabIndex = 0;
            this.panel_min.Click += new System.EventHandler(this.btn_min_Click);
            this.panel_min.MouseEnter += new System.EventHandler(this.panel_min_MouseEnter);
            this.panel_min.MouseLeave += new System.EventHandler(this.panel_min_MouseLeave);
            // 
            // btn_min
            // 
            this.btn_min.AdaptImage = true;
            this.btn_min.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_min.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btn_min.BaseColor = System.Drawing.Color.Transparent;
            this.btn_min.Borders.BottomColor = System.Drawing.Color.Empty;
            this.btn_min.Borders.BottomWidth = 1;
            this.btn_min.Borders.LeftColor = System.Drawing.Color.Empty;
            this.btn_min.Borders.LeftWidth = 1;
            this.btn_min.Borders.RightColor = System.Drawing.Color.Empty;
            this.btn_min.Borders.RightWidth = 1;
            this.btn_min.Borders.TopColor = System.Drawing.Color.Empty;
            this.btn_min.Borders.TopWidth = 1;
            this.btn_min.Canvas = ((System.Drawing.Bitmap)(resources.GetObject("btn_min.Canvas")));
            this.btn_min.ControlState = LayeredSkin.Controls.ControlStates.Normal;
            this.btn_min.HaloColor = System.Drawing.Color.Transparent;
            this.btn_min.HaloSize = 5;
            this.btn_min.HoverImage = global::DeclineAplay.Properties.Resources.min1;
            this.btn_min.IsPureColor = true;
            this.btn_min.Location = new System.Drawing.Point(7, 7);
            this.btn_min.Name = "btn_min";
            this.btn_min.NormalImage = global::DeclineAplay.Properties.Resources.min0;
            this.btn_min.PressedImage = global::DeclineAplay.Properties.Resources.min1;
            this.btn_min.Radius = 10;
            this.btn_min.ShowBorder = false;
            this.btn_min.Size = new System.Drawing.Size(16, 16);
            this.btn_min.TabIndex = 3;
            this.btn_min.TextLocationOffset = new System.Drawing.Point(0, 0);
            this.btn_min.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
            this.btn_min.TextShowMode = LayeredSkin.TextShowModes.Halo;
            this.btn_min.Click += new System.EventHandler(this.btn_min_Click);
            this.btn_min.MouseEnter += new System.EventHandler(this.btn_min_MouseEnter);
            this.btn_min.MouseLeave += new System.EventHandler(this.btn_min_MouseLeave);
            // 
            // panel_close
            // 
            this.panel_close.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel_close.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.panel_close.Borders.BottomColor = System.Drawing.Color.Empty;
            this.panel_close.Borders.BottomWidth = 1;
            this.panel_close.Borders.LeftColor = System.Drawing.Color.Empty;
            this.panel_close.Borders.LeftWidth = 1;
            this.panel_close.Borders.RightColor = System.Drawing.Color.Empty;
            this.panel_close.Borders.RightWidth = 1;
            this.panel_close.Borders.TopColor = System.Drawing.Color.Empty;
            this.panel_close.Borders.TopWidth = 1;
            this.panel_close.Canvas = ((System.Drawing.Bitmap)(resources.GetObject("panel_close.Canvas")));
            this.panel_close.Controls.Add(this.btn_close);
            this.panel_close.Location = new System.Drawing.Point(500, 0);
            this.panel_close.Name = "panel_close";
            this.panel_close.Size = new System.Drawing.Size(30, 30);
            this.panel_close.TabIndex = 1;
            this.panel_close.Click += new System.EventHandler(this.btn_close_Click);
            this.panel_close.MouseEnter += new System.EventHandler(this.panel_min_MouseEnter);
            this.panel_close.MouseLeave += new System.EventHandler(this.panel_min_MouseLeave);
            // 
            // btn_close
            // 
            this.btn_close.AdaptImage = true;
            this.btn_close.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_close.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btn_close.BaseColor = System.Drawing.Color.Transparent;
            this.btn_close.Borders.BottomColor = System.Drawing.Color.Empty;
            this.btn_close.Borders.BottomWidth = 1;
            this.btn_close.Borders.LeftColor = System.Drawing.Color.Empty;
            this.btn_close.Borders.LeftWidth = 1;
            this.btn_close.Borders.RightColor = System.Drawing.Color.Empty;
            this.btn_close.Borders.RightWidth = 1;
            this.btn_close.Borders.TopColor = System.Drawing.Color.Empty;
            this.btn_close.Borders.TopWidth = 1;
            this.btn_close.Canvas = ((System.Drawing.Bitmap)(resources.GetObject("btn_close.Canvas")));
            this.btn_close.ControlState = LayeredSkin.Controls.ControlStates.Normal;
            this.btn_close.HaloColor = System.Drawing.Color.Transparent;
            this.btn_close.HaloSize = 5;
            this.btn_close.HoverImage = global::DeclineAplay.Properties.Resources.close1;
            this.btn_close.IsPureColor = true;
            this.btn_close.Location = new System.Drawing.Point(7, 7);
            this.btn_close.Name = "btn_close";
            this.btn_close.NormalImage = global::DeclineAplay.Properties.Resources.close0;
            this.btn_close.PressedImage = global::DeclineAplay.Properties.Resources.close1;
            this.btn_close.Radius = 10;
            this.btn_close.ShowBorder = false;
            this.btn_close.Size = new System.Drawing.Size(16, 16);
            this.btn_close.TabIndex = 5;
            this.btn_close.TextLocationOffset = new System.Drawing.Point(0, 0);
            this.btn_close.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
            this.btn_close.TextShowMode = LayeredSkin.TextShowModes.Halo;
            this.btn_close.Click += new System.EventHandler(this.btn_close_Click);
            this.btn_close.MouseEnter += new System.EventHandler(this.btn_min_MouseEnter);
            this.btn_close.MouseLeave += new System.EventHandler(this.btn_min_MouseLeave);
            // 
            // BaseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(123)))), ((int)(((byte)(88)))), ((int)(((byte)(88)))));
            this.ClientSize = new System.Drawing.Size(530, 340);
            this.Controls.Add(this.panel_close);
            this.Controls.Add(this.panel_min);
            this.DoubleBuffered = false;
            this.Name = "BaseForm";
            this.Radius = 25;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BaseForm";
            this.panel_min.ResumeLayout(false);
            this.panel_close.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        public LayeredSkin.Controls.LayeredPanel panel_min;
        public LayeredSkin.Controls.LayeredPanel panel_close;
        public LayeredSkin.Controls.LayeredButton btn_min;
        public LayeredSkin.Controls.LayeredButton btn_close;
    }
}