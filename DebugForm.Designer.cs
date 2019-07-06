namespace DeclineAplay
{
    partial class DebugForm
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
            this.btn_get = new System.Windows.Forms.Button();
            this.textBox_resoult = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // btn_get
            // 
            this.btn_get.Location = new System.Drawing.Point(633, 2);
            this.btn_get.Name = "btn_get";
            this.btn_get.Size = new System.Drawing.Size(52, 22);
            this.btn_get.TabIndex = 0;
            this.btn_get.Text = "获取";
            this.btn_get.UseVisualStyleBackColor = true;
            this.btn_get.Click += new System.EventHandler(this.btn_get_Click);
            // 
            // textBox_resoult
            // 
            this.textBox_resoult.Location = new System.Drawing.Point(3, 30);
            this.textBox_resoult.Name = "textBox_resoult";
            this.textBox_resoult.Size = new System.Drawing.Size(700, 370);
            this.textBox_resoult.TabIndex = 1;
            this.textBox_resoult.Text = "";
            // 
            // DebugForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(707, 405);
            this.Controls.Add(this.textBox_resoult);
            this.Controls.Add(this.btn_get);
            this.Name = "DebugForm";
            this.Text = "Debug";
            this.Load += new System.EventHandler(this.DebugForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_get;
        private System.Windows.Forms.RichTextBox textBox_resoult;
    }
}