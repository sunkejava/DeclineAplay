namespace DeclineAplay.Controls
{
    partial class PlayControl
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
            this.btn_Prev = new DeclineAplay.Controls.RadiusControlButton();
            this.btn_stop = new DeclineAplay.Controls.RadiusControlButton();
            this.SuspendLayout();
            // 
            // btn_Prev
            // 
            this.btn_Prev.BackColor = System.Drawing.Color.Transparent;
            this.btn_Prev.IsBdtb = true;
            this.btn_Prev.IsSelect = true;
            this.btn_Prev.IsShowBorder = true;
            this.btn_Prev.Location = new System.Drawing.Point(40, 25);
            this.btn_Prev.Name = "btn_Prev";
            this.btn_Prev.Radius = 30;
            this.btn_Prev.SetBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(230)))), ((int)(((byte)(161)))));
            this.btn_Prev.SetDefaultIcon = global::DeclineAplay.Properties.Resources.sys1;
            this.btn_Prev.SetDefaultImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_Prev.SetIconSize = 15;
            this.btn_Prev.SetSelectIcon = global::DeclineAplay.Properties.Resources.sys2;
            this.btn_Prev.Size = new System.Drawing.Size(30, 30);
            this.btn_Prev.TabIndex = 1;
            // 
            // btn_stop
            // 
            this.btn_stop.BackColor = System.Drawing.Color.Transparent;
            this.btn_stop.IsBdtb = true;
            this.btn_stop.IsSelect = true;
            this.btn_stop.IsShowBorder = true;
            this.btn_stop.Location = new System.Drawing.Point(5, 25);
            this.btn_stop.Name = "btn_stop";
            this.btn_stop.Radius = 30;
            this.btn_stop.SetBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(230)))), ((int)(((byte)(161)))));
            this.btn_stop.SetDefaultIcon = global::DeclineAplay.Properties.Resources.stop1;
            this.btn_stop.SetDefaultImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_stop.SetIconSize = 15;
            this.btn_stop.SetSelectIcon = global::DeclineAplay.Properties.Resources.stop2;
            this.btn_stop.Size = new System.Drawing.Size(30, 30);
            this.btn_stop.TabIndex = 0;
            // 
            // PlayControl
            // 
            //this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            //this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.btn_Prev);
            this.Controls.Add(this.btn_stop);
            this.Name = "PlayControl";
            this.Size = new System.Drawing.Size(700, 60);
            this.ResumeLayout(false);

        }

        #endregion

        private RadiusControlButton btn_stop;
        private RadiusControlButton btn_Prev;
    }
}
