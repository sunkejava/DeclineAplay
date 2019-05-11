namespace DeclineAplay.Controls
{
    partial class RadiusControlButton
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RadiusControlButton));
            this.radiusControl1 = new DeclineAplay.Controls.RadiusControl();
            this.skinButton_play = new DeclineAplay.Controls.ButtonControl();
            this.SuspendLayout();
            // 
            // radiusControl1
            // 
            this.radiusControl1.BackColor = System.Drawing.Color.Transparent;
            this.radiusControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radiusControl1.IsShowBorder = false;
            this.radiusControl1.Location = new System.Drawing.Point(0, 0);
            this.radiusControl1.Name = "radiusControl1";
            this.radiusControl1.Radius = 100;
            this.radiusControl1.SetBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(92)))), ((int)(((byte)(138)))));
            this.radiusControl1.SetBackgroundImage = null;
            this.radiusControl1.SetBackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.radiusControl1.Size = new System.Drawing.Size(100, 100);
            this.radiusControl1.TabIndex = 0;
            // 
            // skinButton_play
            // 
            this.skinButton_play.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(92)))), ((int)(((byte)(138)))));
            this.skinButton_play.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("skinButton_play.BackgroundImage")));
            this.skinButton_play.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.skinButton_play.Location = new System.Drawing.Point(25, 25);
            this.skinButton_play.Name = "skinButton_play";
            this.skinButton_play.Size = new System.Drawing.Size(50, 50);
            this.skinButton_play.TabIndex = 1;
            // 
            // RadiusControlButton
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.skinButton_play);
            this.Controls.Add(this.radiusControl1);
            this.Name = "RadiusControlButton";
            this.Size = new System.Drawing.Size(100, 100);
            this.ResumeLayout(false);

        }

        #endregion

        private RadiusControl radiusControl1;
        private ButtonControl skinButton_play;
    }
}
