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
            this.comB_Type = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.text_typeid = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.text_tvid = new System.Windows.Forms.TextBox();
            this.text_search = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btn_play = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.page_text = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btn_get
            // 
            this.btn_get.Location = new System.Drawing.Point(572, 2);
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
            // comB_Type
            // 
            this.comB_Type.FormattingEnabled = true;
            this.comB_Type.Items.AddRange(new object[] {
            "版本号",
            "配置",
            "购买信息",
            "用户登录",
            "获取分类",
            "获取首页菜单分类",
            "热门标签",
            "免费视频",
            "最新视频",
            "根据类型获取视频",
            "搜索视频",
            "视频详情",
            "视频地址"});
            this.comB_Type.Location = new System.Drawing.Point(54, 4);
            this.comB_Type.Name = "comB_Type";
            this.comB_Type.Size = new System.Drawing.Size(121, 20);
            this.comB_Type.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "类型：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(181, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "视频分类ID：";
            // 
            // text_typeid
            // 
            this.text_typeid.Location = new System.Drawing.Point(254, 4);
            this.text_typeid.Name = "text_typeid";
            this.text_typeid.Size = new System.Drawing.Size(49, 21);
            this.text_typeid.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(309, 7);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "视频ID：";
            // 
            // text_tvid
            // 
            this.text_tvid.Location = new System.Drawing.Point(354, 4);
            this.text_tvid.Name = "text_tvid";
            this.text_tvid.Size = new System.Drawing.Size(49, 21);
            this.text_tvid.TabIndex = 7;
            // 
            // text_search
            // 
            this.text_search.Location = new System.Drawing.Point(454, 4);
            this.text_search.Name = "text_search";
            this.text_search.Size = new System.Drawing.Size(49, 21);
            this.text_search.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(409, 7);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 8;
            this.label4.Text = "关键字：";
            // 
            // btn_play
            // 
            this.btn_play.Location = new System.Drawing.Point(631, 2);
            this.btn_play.Name = "btn_play";
            this.btn_play.Size = new System.Drawing.Size(52, 22);
            this.btn_play.TabIndex = 10;
            this.btn_play.Text = "播放";
            this.btn_play.UseVisualStyleBackColor = true;
            this.btn_play.Click += new System.EventHandler(this.btn_play_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(504, 7);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 11;
            this.label5.Text = "页码：";
            // 
            // page_text
            // 
            this.page_text.Location = new System.Drawing.Point(537, 4);
            this.page_text.Name = "page_text";
            this.page_text.Size = new System.Drawing.Size(29, 21);
            this.page_text.TabIndex = 12;
            this.page_text.Text = "1";
            // 
            // DebugForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(707, 405);
            this.Controls.Add(this.page_text);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btn_play);
            this.Controls.Add(this.text_search);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.text_tvid);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.text_typeid);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comB_Type);
            this.Controls.Add(this.textBox_resoult);
            this.Controls.Add(this.btn_get);
            this.Controls.Add(this.label1);
            this.Name = "DebugForm";
            this.Text = "Debug";
            this.Load += new System.EventHandler(this.DebugForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_get;
        private System.Windows.Forms.RichTextBox textBox_resoult;
        private System.Windows.Forms.ComboBox comB_Type;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox text_typeid;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox text_tvid;
        private System.Windows.Forms.TextBox text_search;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btn_play;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox page_text;
    }
}