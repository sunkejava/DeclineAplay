namespace DeclineAplay
{
    partial class LayeredWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LayeredWindow));
            this.axPlayer = new AxAPlayer3Lib.AxPlayer();
            ((System.ComponentModel.ISupportInitialize)(this.axPlayer)).BeginInit();
            this.SuspendLayout();
            // 
            // axPlayer
            // 
            this.axPlayer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.axPlayer.Enabled = true;
            this.axPlayer.Location = new System.Drawing.Point(0, 0);
            this.axPlayer.Name = "axPlayer";
            this.axPlayer.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axPlayer.OcxState")));
            this.axPlayer.Size = new System.Drawing.Size(622, 408);
            this.axPlayer.TabIndex = 0;
            // 
            // LayeredWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(622, 408);
            this.Controls.Add(this.axPlayer);
            this.DrawIcon = false;
            this.EnableAnimation = false;
            this.HaloColor = System.Drawing.Color.Transparent;
            this.IsLayeredWindowForm = false;
            this.Name = "LayeredWindow";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "";
            this.TransparencyKey = System.Drawing.Color.Transparent;
            this.AutoSizeChanged += new System.EventHandler(this.LayeredWindow_AutoSizeChanged);
            this.Load += new System.EventHandler(this.LayeredWindow_Load);
            ((System.ComponentModel.ISupportInitialize)(this.axPlayer)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public AxAPlayer3Lib.AxPlayer axPlayer;
    }
}