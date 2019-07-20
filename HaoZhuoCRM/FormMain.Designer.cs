namespace HaoZhuoCRM
{
    partial class FormMain
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.文件FToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.miExit = new System.Windows.Forms.ToolStripMenuItem();
            this.客户CToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.公海PToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.miMyClients = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.文件FToolStripMenuItem,
            this.客户CToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(2173, 42);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 文件FToolStripMenuItem
            // 
            this.文件FToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miExit});
            this.文件FToolStripMenuItem.Name = "文件FToolStripMenuItem";
            this.文件FToolStripMenuItem.Size = new System.Drawing.Size(111, 38);
            this.文件FToolStripMenuItem.Text = "文件(&F)";
            // 
            // miExit
            // 
            this.miExit.Name = "miExit";
            this.miExit.Size = new System.Drawing.Size(224, 44);
            this.miExit.Text = "退出(&E)";
            this.miExit.Click += new System.EventHandler(this.MiExit_Click);
            // 
            // 客户CToolStripMenuItem
            // 
            this.客户CToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miMyClients,
            this.公海PToolStripMenuItem});
            this.客户CToolStripMenuItem.Name = "客户CToolStripMenuItem";
            this.客户CToolStripMenuItem.Size = new System.Drawing.Size(114, 38);
            this.客户CToolStripMenuItem.Text = "客户(&C)";
            // 
            // 公海PToolStripMenuItem
            // 
            this.公海PToolStripMenuItem.Name = "公海PToolStripMenuItem";
            this.公海PToolStripMenuItem.Size = new System.Drawing.Size(359, 44);
            this.公海PToolStripMenuItem.Text = "公海(&P)";
            // 
            // miMyClients
            // 
            this.miMyClients.Name = "miMyClients";
            this.miMyClients.Size = new System.Drawing.Size(359, 44);
            this.miMyClients.Text = "我的客户(&M)";
            this.miMyClients.Click += new System.EventHandler(this.MiMyClients_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2173, 1014);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CRM系统";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 文件FToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem miExit;
        private System.Windows.Forms.ToolStripMenuItem 客户CToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem miMyClients;
        private System.Windows.Forms.ToolStripMenuItem 公海PToolStripMenuItem;
    }
}

