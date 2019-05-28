namespace DeclineAplay
{
    partial class MessageForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MessageForm));
            this.layeredLabel2 = new LayeredSkin.Controls.LayeredLabel();
            this.layeredLabel1 = new LayeredSkin.Controls.LayeredLabel();
            this.btn_close = new LayeredSkin.Controls.LayeredButton();
            this.SuspendLayout();
            // 
            // layeredLabel2
            // 
            this.layeredLabel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.layeredLabel2.Borders.BottomColor = System.Drawing.Color.Empty;
            this.layeredLabel2.Borders.BottomWidth = 1;
            this.layeredLabel2.Borders.LeftColor = System.Drawing.Color.Empty;
            this.layeredLabel2.Borders.LeftWidth = 1;
            this.layeredLabel2.Borders.RightColor = System.Drawing.Color.Empty;
            this.layeredLabel2.Borders.RightWidth = 1;
            this.layeredLabel2.Borders.TopColor = System.Drawing.Color.Empty;
            this.layeredLabel2.Borders.TopWidth = 1;
            this.layeredLabel2.Canvas = ((System.Drawing.Bitmap)(resources.GetObject("layeredLabel2.Canvas")));
            this.layeredLabel2.Font = new System.Drawing.Font("宋体", 11F);
            this.layeredLabel2.ForeColor = System.Drawing.Color.Orange;
            this.layeredLabel2.HaloSize = 5;
            this.layeredLabel2.Location = new System.Drawing.Point(159, 56);
            this.layeredLabel2.Name = "layeredLabel2";
            this.layeredLabel2.Size = new System.Drawing.Size(126, 24);
            this.layeredLabel2.TabIndex = 3;
            this.layeredLabel2.Text = "点击打开保存目录";
            this.layeredLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.layeredLabel2.TextShowMode = LayeredSkin.TextShowModes.Ordinary;
            // 
            // layeredLabel1
            // 
            this.layeredLabel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.layeredLabel1.Borders.BottomColor = System.Drawing.Color.Empty;
            this.layeredLabel1.Borders.BottomWidth = 1;
            this.layeredLabel1.Borders.LeftColor = System.Drawing.Color.Empty;
            this.layeredLabel1.Borders.LeftWidth = 1;
            this.layeredLabel1.Borders.RightColor = System.Drawing.Color.Empty;
            this.layeredLabel1.Borders.RightWidth = 1;
            this.layeredLabel1.Borders.TopColor = System.Drawing.Color.Empty;
            this.layeredLabel1.Borders.TopWidth = 1;
            this.layeredLabel1.Canvas = ((System.Drawing.Bitmap)(resources.GetObject("layeredLabel1.Canvas")));
            this.layeredLabel1.Font = new System.Drawing.Font("宋体", 11F);
            this.layeredLabel1.ForeColor = System.Drawing.Color.White;
            this.layeredLabel1.HaloSize = 5;
            this.layeredLabel1.Location = new System.Drawing.Point(60, 56);
            this.layeredLabel1.Name = "layeredLabel1";
            this.layeredLabel1.Size = new System.Drawing.Size(101, 24);
            this.layeredLabel1.TabIndex = 2;
            this.layeredLabel1.Text = "壁纸保存成功";
            this.layeredLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.layeredLabel1.TextShowMode = LayeredSkin.TextShowModes.Ordinary;
            // 
            // btn_close
            // 
            this.btn_close.AdaptImage = true;
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
            this.btn_close.HoverImage = null;
            this.btn_close.IsPureColor = false;
            this.btn_close.Location = new System.Drawing.Point(342, -1);
            this.btn_close.Name = "btn_close";
            this.btn_close.NormalImage = global::DeclineAplay.Properties.Resources.close;
            this.btn_close.PressedImage = global::DeclineAplay.Properties.Resources.close;
            this.btn_close.Radius = 18;
            this.btn_close.ShowBorder = true;
            this.btn_close.Size = new System.Drawing.Size(18, 18);
            this.btn_close.TabIndex = 4;
            this.btn_close.TextLocationOffset = new System.Drawing.Point(0, 0);
            this.btn_close.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
            this.btn_close.TextShowMode = LayeredSkin.TextShowModes.Halo;
            // 
            // MessageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.ClientSize = new System.Drawing.Size(360, 139);
            this.Controls.Add(this.btn_close);
            this.Controls.Add(this.layeredLabel2);
            this.Controls.Add(this.layeredLabel1);
            this.Name = "MessageForm";
            this.ShowInTaskbar = false;
            this.Text = "";
            this.ResumeLayout(false);

        }

        #endregion

        private LayeredSkin.Controls.LayeredLabel layeredLabel2;
        private LayeredSkin.Controls.LayeredLabel layeredLabel1;
        private LayeredSkin.Controls.LayeredButton btn_close;
    }
}