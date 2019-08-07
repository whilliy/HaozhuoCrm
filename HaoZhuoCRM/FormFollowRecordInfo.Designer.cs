namespace HaoZhuoCRM
{
    partial class FormFollowRecordInfo
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
            this.label1 = new System.Windows.Forms.Label();
            this.labelProjectName = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.labelCommunicationTime = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.labelFollowUserName = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.labelNextFollowTime = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtRemark = new System.Windows.Forms.RichTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "项目：";
            // 
            // labelProjectName
            // 
            this.labelProjectName.Location = new System.Drawing.Point(137, 5);
            this.labelProjectName.Name = "labelProjectName";
            this.labelProjectName.Size = new System.Drawing.Size(254, 21);
            this.labelProjectName.TabIndex = 1;
            this.labelProjectName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 37);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "沟通时间：";
            // 
            // labelCommunicationTime
            // 
            this.labelCommunicationTime.Location = new System.Drawing.Point(137, 33);
            this.labelCommunicationTime.Name = "labelCommunicationTime";
            this.labelCommunicationTime.Size = new System.Drawing.Size(254, 21);
            this.labelCommunicationTime.TabIndex = 3;
            this.labelCommunicationTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 65);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 4;
            this.label5.Text = "沟通人：";
            // 
            // labelFollowUserName
            // 
            this.labelFollowUserName.Location = new System.Drawing.Point(137, 61);
            this.labelFollowUserName.Name = "labelFollowUserName";
            this.labelFollowUserName.Size = new System.Drawing.Size(254, 21);
            this.labelFollowUserName.TabIndex = 5;
            this.labelFollowUserName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(16, 93);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(89, 12);
            this.label7.TabIndex = 6;
            this.label7.Text = "下次沟通时间：";
            // 
            // labelNextFollowTime
            // 
            this.labelNextFollowTime.Location = new System.Drawing.Point(137, 89);
            this.labelNextFollowTime.Name = "labelNextFollowTime";
            this.labelNextFollowTime.Size = new System.Drawing.Size(254, 21);
            this.labelNextFollowTime.TabIndex = 7;
            this.labelNextFollowTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(16, 121);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 12);
            this.label9.TabIndex = 8;
            this.label9.Text = "沟通记录：";
            // 
            // txtRemark
            // 
            this.txtRemark.Location = new System.Drawing.Point(12, 144);
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.Size = new System.Drawing.Size(573, 128);
            this.txtRemark.TabIndex = 9;
            this.txtRemark.Text = "";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(236, 278);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 10;
            this.button1.Text = "看完了(&OK)";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // FormFollowRecordInfo
            // 
            this.ClientSize = new System.Drawing.Size(597, 304);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtRemark);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.labelNextFollowTime);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.labelFollowUserName);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.labelCommunicationTime);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.labelProjectName);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormFollowRecordInfo";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "沟通相信信息";
            this.Load += new System.EventHandler(this.FormFollowRecordInfo_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelProjectName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labelCommunicationTime;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label labelFollowUserName;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label labelNextFollowTime;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.RichTextBox txtRemark;
        private System.Windows.Forms.Button button1;
    }
}
