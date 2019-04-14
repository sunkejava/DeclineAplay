namespace DeclineAplay
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.Panel_main = new LayeredSkin.Controls.LayeredPanel();
            this.aplayerBase1 = new DeclineAplay.AplayControl.AplayerBase();
            this.btn_play = new LayeredSkin.Controls.LayeredButton();
            this.Panel_main.SuspendLayout();
            this.SuspendLayout();
            // 
            // Panel_main
            // 
            this.Panel_main.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.Panel_main.Borders.BottomColor = System.Drawing.Color.Empty;
            this.Panel_main.Borders.BottomWidth = 1;
            this.Panel_main.Borders.LeftColor = System.Drawing.Color.Empty;
            this.Panel_main.Borders.LeftWidth = 1;
            this.Panel_main.Borders.RightColor = System.Drawing.Color.Empty;
            this.Panel_main.Borders.RightWidth = 1;
            this.Panel_main.Borders.TopColor = System.Drawing.Color.Empty;
            this.Panel_main.Borders.TopWidth = 1;
            this.Panel_main.Canvas = ((System.Drawing.Bitmap)(resources.GetObject("Panel_main.Canvas")));
            this.Panel_main.Controls.Add(this.btn_play);
            this.Panel_main.Controls.Add(this.aplayerBase1);
            this.Panel_main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Panel_main.Location = new System.Drawing.Point(0, 0);
            this.Panel_main.Name = "Panel_main";
            this.Panel_main.Size = new System.Drawing.Size(728, 527);
            this.Panel_main.TabIndex = 0;
            // 
            // aplayerBase1
            // 
            this.aplayerBase1.AplayBackColor = System.Drawing.Color.White;
            this.aplayerBase1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.aplayerBase1.Borders.BottomColor = System.Drawing.Color.Empty;
            this.aplayerBase1.Borders.BottomWidth = 1;
            this.aplayerBase1.Borders.LeftColor = System.Drawing.Color.Empty;
            this.aplayerBase1.Borders.LeftWidth = 1;
            this.aplayerBase1.Borders.RightColor = System.Drawing.Color.Empty;
            this.aplayerBase1.Borders.RightWidth = 1;
            this.aplayerBase1.Borders.TopColor = System.Drawing.Color.Empty;
            this.aplayerBase1.Borders.TopWidth = 1;
            this.aplayerBase1.Canvas = ((System.Drawing.Bitmap)(resources.GetObject("aplayerBase1.Canvas")));
            this.aplayerBase1.DefaultImage = global::DeclineAplay.Properties.Resources._19;
            this.aplayerBase1.Location = new System.Drawing.Point(3, 20);
            this.aplayerBase1.LogoLocation = new System.Drawing.Point(50, 50);
            this.aplayerBase1.Name = "aplayerBase1";
            this.aplayerBase1.Size = new System.Drawing.Size(722, 455);
            this.aplayerBase1.Speedup = true;
            this.aplayerBase1.TabIndex = 0;
            // 
            // btn_play
            // 
            this.btn_play.AdaptImage = true;
            this.btn_play.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btn_play.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btn_play.Borders.BottomColor = System.Drawing.Color.Empty;
            this.btn_play.Borders.BottomWidth = 1;
            this.btn_play.Borders.LeftColor = System.Drawing.Color.Empty;
            this.btn_play.Borders.LeftWidth = 1;
            this.btn_play.Borders.RightColor = System.Drawing.Color.Empty;
            this.btn_play.Borders.RightWidth = 1;
            this.btn_play.Borders.TopColor = System.Drawing.Color.Empty;
            this.btn_play.Borders.TopWidth = 1;
            this.btn_play.Canvas = ((System.Drawing.Bitmap)(resources.GetObject("btn_play.Canvas")));
            this.btn_play.ControlState = LayeredSkin.Controls.ControlStates.Normal;
            this.btn_play.HaloColor = System.Drawing.Color.White;
            this.btn_play.HaloSize = 5;
            this.btn_play.HoverImage = null;
            this.btn_play.IsPureColor = false;
            this.btn_play.Location = new System.Drawing.Point(333, 485);
            this.btn_play.Name = "btn_play";
            this.btn_play.NormalImage = null;
            this.btn_play.PressedImage = null;
            this.btn_play.Radius = 15;
            this.btn_play.ShowBorder = true;
            this.btn_play.Size = new System.Drawing.Size(76, 30);
            this.btn_play.TabIndex = 1;
            this.btn_play.Text = "播放";
            this.btn_play.TextLocationOffset = new System.Drawing.Point(0, 0);
            this.btn_play.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
            this.btn_play.TextShowMode = LayeredSkin.TextShowModes.Halo;
            this.btn_play.Click += new System.EventHandler(this.btn_play_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(728, 527);
            this.Controls.Add(this.Panel_main);
            this.EnabledDWM = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.IsLayeredWindowForm = false;
            this.Name = "MainForm";
            this.Radius = 25;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Panel_main.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private LayeredSkin.Controls.LayeredPanel Panel_main;
        private AplayControl.AplayerBase aplayerBase1;
        private LayeredSkin.Controls.LayeredButton btn_play;
    }
}

