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
            this.menuModifyPassword = new System.Windows.Forms.ToolStripMenuItem();
            this.miExit = new System.Windows.Forms.ToolStripMenuItem();
            this.客户CToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.miMyClients = new System.Windows.Forms.ToolStripMenuItem();
            this.公海PToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.设置SToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemProjectManagement = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemUser = new System.Windows.Forms.ToolStripMenuItem();
            this.组织架构OToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.文件FToolStripMenuItem,
            this.客户CToolStripMenuItem,
            this.设置SToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(3, 1, 0, 1);
            this.menuStrip1.Size = new System.Drawing.Size(752, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 文件FToolStripMenuItem
            // 
            this.文件FToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuModifyPassword,
            this.miExit});
            this.文件FToolStripMenuItem.Name = "文件FToolStripMenuItem";
            this.文件FToolStripMenuItem.Size = new System.Drawing.Size(58, 22);
            this.文件FToolStripMenuItem.Text = "文件(&F)";
            // 
            // menuModifyPassword
            // 
            this.menuModifyPassword.Name = "menuModifyPassword";
            this.menuModifyPassword.Size = new System.Drawing.Size(153, 22);
            this.menuModifyPassword.Text = "修改密码(&M)...";
            this.menuModifyPassword.Click += new System.EventHandler(this.MenuModifyPassword_Click);
            // 
            // miExit
            // 
            this.miExit.Name = "miExit";
            this.miExit.Size = new System.Drawing.Size(153, 22);
            this.miExit.Text = "退出(&E)";
            this.miExit.Click += new System.EventHandler(this.MiExit_Click);
            // 
            // 客户CToolStripMenuItem
            // 
            this.客户CToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miMyClients,
            this.公海PToolStripMenuItem});
            this.客户CToolStripMenuItem.Name = "客户CToolStripMenuItem";
            this.客户CToolStripMenuItem.Size = new System.Drawing.Size(60, 22);
            this.客户CToolStripMenuItem.Text = "客户(&C)";
            // 
            // miMyClients
            // 
            this.miMyClients.Name = "miMyClients";
            this.miMyClients.Size = new System.Drawing.Size(144, 22);
            this.miMyClients.Text = "我的客户(&M)";
            this.miMyClients.Click += new System.EventHandler(this.MiMyClients_Click);
            // 
            // 公海PToolStripMenuItem
            // 
            this.公海PToolStripMenuItem.Name = "公海PToolStripMenuItem";
            this.公海PToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.公海PToolStripMenuItem.Text = "公海(&P)";
            // 
            // 设置SToolStripMenuItem
            // 
            this.设置SToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemProjectManagement,
            this.menuItemUser,
            this.组织架构OToolStripMenuItem});
            this.设置SToolStripMenuItem.Name = "设置SToolStripMenuItem";
            this.设置SToolStripMenuItem.Size = new System.Drawing.Size(64, 22);
            this.设置SToolStripMenuItem.Text = "管理(&M)";
            // 
            // menuItemProjectManagement
            // 
            this.menuItemProjectManagement.Name = "menuItemProjectManagement";
            this.menuItemProjectManagement.Size = new System.Drawing.Size(180, 22);
            this.menuItemProjectManagement.Text = "项目管理(&P)";
            this.menuItemProjectManagement.Click += new System.EventHandler(this.MenuItemProjectManagement_Click);
            // 
            // menuItemUser
            // 
            this.menuItemUser.Name = "menuItemUser";
            this.menuItemUser.Size = new System.Drawing.Size(180, 22);
            this.menuItemUser.Text = "用户管理(&U)...";
            this.menuItemUser.Click += new System.EventHandler(this.MenuItemUser_Click);
            // 
            // 组织架构OToolStripMenuItem
            // 
            this.组织架构OToolStripMenuItem.Name = "组织架构OToolStripMenuItem";
            this.组织架构OToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.组织架构OToolStripMenuItem.Text = "组织架构(&O)...";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(752, 490);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2);
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
        private System.Windows.Forms.ToolStripMenuItem 设置SToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuItemProjectManagement;
        private System.Windows.Forms.ToolStripMenuItem menuModifyPassword;
        private System.Windows.Forms.ToolStripMenuItem menuItemUser;
        private System.Windows.Forms.ToolStripMenuItem 组织架构OToolStripMenuItem;
    }
}

