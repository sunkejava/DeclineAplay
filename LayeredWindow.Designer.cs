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
            this.axPlayer1 = new AxAPlayer3Lib.AxPlayer();
            ((System.ComponentModel.ISupportInitialize)(this.axPlayer1)).BeginInit();
            this.SuspendLayout();
            // 
            // axPlayer1
            // 
            this.axPlayer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.axPlayer1.Enabled = true;
            this.axPlayer1.Location = new System.Drawing.Point(0, 0);
            this.axPlayer1.Name = "axPlayer1";
            this.axPlayer1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axPlayer1.OcxState")));
            this.axPlayer1.Size = new System.Drawing.Size(622, 408);
            this.axPlayer1.TabIndex = 0;
            // 
            // LayeredWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(622, 408);
            this.Controls.Add(this.axPlayer1);
            this.DrawIcon = false;
            this.EnableAnimation = false;
            this.HaloColor = System.Drawing.Color.Transparent;
            this.IsLayeredWindowForm = false;
            this.Name = "LayeredWindow";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LayeredWindow";
            this.TransparencyKey = System.Drawing.Color.Transparent;
            this.AutoSizeChanged += new System.EventHandler(this.LayeredWindow_AutoSizeChanged);
            this.Load += new System.EventHandler(this.LayeredWindow_Load);
            ((System.ComponentModel.ISupportInitialize)(this.axPlayer1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public AxAPlayer3Lib.AxPlayer axPlayer1;
    }
}