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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.miFile = new System.Windows.Forms.ToolStripMenuItem();
            this.miModifyPassword = new System.Windows.Forms.ToolStripMenuItem();
            this.miChangeUser = new System.Windows.Forms.ToolStripMenuItem();
            this.miExit = new System.Windows.Forms.ToolStripMenuItem();
            this.miClients = new System.Windows.Forms.ToolStripMenuItem();
            this.miMyClients = new System.Windows.Forms.ToolStripMenuItem();
            this.miPublic = new System.Windows.Forms.ToolStripMenuItem();
            this.miHighPriorityCustomers = new System.Windows.Forms.ToolStripMenuItem();
            this.miDispatch = new System.Windows.Forms.ToolStripMenuItem();
            this.miImport = new System.Windows.Forms.ToolStripMenuItem();
            this.miAllCustomers = new System.Windows.Forms.ToolStripMenuItem();
            this.miAddCustomer = new System.Windows.Forms.ToolStripMenuItem();
            this.miManagement = new System.Windows.Forms.ToolStripMenuItem();
            this.miProjectManagement = new System.Windows.Forms.ToolStripMenuItem();
            this.miUserManagement = new System.Windows.Forms.ToolStripMenuItem();
            this.miOrganizationManagement = new System.Windows.Forms.ToolStripMenuItem();
            this.miHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.miAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.labelCurrentName = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lableCurrentOrganization = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.labelCurrentProject = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miFile,
            this.miClients,
            this.miManagement,
            this.miHelp});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(3, 1, 0, 1);
            this.menuStrip1.Size = new System.Drawing.Size(752, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // miFile
            // 
            this.miFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miModifyPassword,
            this.miChangeUser,
            this.miExit});
            this.miFile.Name = "miFile";
            this.miFile.Size = new System.Drawing.Size(58, 22);
            this.miFile.Text = "文件(&F)";
            this.miFile.Visible = false;
            // 
            // miModifyPassword
            // 
            this.miModifyPassword.Name = "miModifyPassword";
            this.miModifyPassword.Size = new System.Drawing.Size(153, 22);
            this.miModifyPassword.Text = "修改密码(&M)...";
            this.miModifyPassword.Visible = false;
            this.miModifyPassword.Click += new System.EventHandler(this.MenuModifyPassword_Click);
            // 
            // miChangeUser
            // 
            this.miChangeUser.Name = "miChangeUser";
            this.miChangeUser.Size = new System.Drawing.Size(153, 22);
            this.miChangeUser.Text = "切换用户(&C)...";
            this.miChangeUser.Visible = false;
            this.miChangeUser.Click += new System.EventHandler(this.MiChangeUser_Click);
            // 
            // miExit
            // 
            this.miExit.Name = "miExit";
            this.miExit.Size = new System.Drawing.Size(153, 22);
            this.miExit.Text = "退出(&E)";
            this.miExit.Visible = false;
            this.miExit.Click += new System.EventHandler(this.MiExit_Click);
            // 
            // miClients
            // 
            this.miClients.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miMyClients,
            this.miPublic,
            this.miHighPriorityCustomers,
            this.miDispatch,
            this.miImport,
            this.miAllCustomers,
            this.miAddCustomer});
            this.miClients.Name = "miClients";
            this.miClients.Size = new System.Drawing.Size(60, 22);
            this.miClients.Text = "客户(&C)";
            this.miClients.Visible = false;
            // 
            // miMyClients
            // 
            this.miMyClients.Image = global::HaoZhuoCRM.Properties.Resources.my_customers;
            this.miMyClients.Name = "miMyClients";
            this.miMyClients.Size = new System.Drawing.Size(196, 38);
            this.miMyClients.Text = "我的(&M)";
            this.miMyClients.Visible = false;
            this.miMyClients.Click += new System.EventHandler(this.MiMyClients_Click);
            // 
            // miPublic
            // 
            this.miPublic.Image = global::HaoZhuoCRM.Properties.Resources._public;
            this.miPublic.Name = "miPublic";
            this.miPublic.Size = new System.Drawing.Size(196, 38);
            this.miPublic.Text = "公海(&P)";
            this.miPublic.Visible = false;
            this.miPublic.Click += new System.EventHandler(this.MiPublic_Click);
            // 
            // miHighPriorityCustomers
            // 
            this.miHighPriorityCustomers.Name = "miHighPriorityCustomers";
            this.miHighPriorityCustomers.Size = new System.Drawing.Size(196, 38);
            this.miHighPriorityCustomers.Text = "优先客户";
            this.miHighPriorityCustomers.Visible = false;
            this.miHighPriorityCustomers.Click += new System.EventHandler(this.miHighPriorityCustomers_Click);
            // 
            // miDispatch
            // 
            this.miDispatch.Name = "miDispatch";
            this.miDispatch.Size = new System.Drawing.Size(196, 38);
            this.miDispatch.Text = "分派(&D)";
            this.miDispatch.Visible = false;
            this.miDispatch.Click += new System.EventHandler(this.MiDispatch_Click);
            // 
            // miImport
            // 
            this.miImport.Name = "miImport";
            this.miImport.Size = new System.Drawing.Size(196, 38);
            this.miImport.Text = "导入(&I)";
            this.miImport.Visible = false;
            this.miImport.Click += new System.EventHandler(this.MiImport_Click);
            // 
            // miAllCustomers
            // 
            this.miAllCustomers.Name = "miAllCustomers";
            this.miAllCustomers.Size = new System.Drawing.Size(196, 38);
            this.miAllCustomers.Text = "所有(&A)";
            this.miAllCustomers.Visible = false;
            this.miAllCustomers.Click += new System.EventHandler(this.MiAllCustomers_Click);
            // 
            // miAddCustomer
            // 
            this.miAddCustomer.Name = "miAddCustomer";
            this.miAddCustomer.Size = new System.Drawing.Size(196, 38);
            this.miAddCustomer.Text = "新增(&N)";
            this.miAddCustomer.Visible = false;
            this.miAddCustomer.Click += new System.EventHandler(this.MiAddCustomer_Click);
            // 
            // miManagement
            // 
            this.miManagement.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miProjectManagement,
            this.miUserManagement,
            this.miOrganizationManagement});
            this.miManagement.Name = "miManagement";
            this.miManagement.Size = new System.Drawing.Size(64, 22);
            this.miManagement.Text = "管理(&M)";
            this.miManagement.Visible = false;
            // 
            // miProjectManagement
            // 
            this.miProjectManagement.Name = "miProjectManagement";
            this.miProjectManagement.Size = new System.Drawing.Size(151, 22);
            this.miProjectManagement.Text = "项目管理(&P)";
            this.miProjectManagement.Visible = false;
            this.miProjectManagement.Click += new System.EventHandler(this.MenuItemProjectManagement_Click);
            // 
            // miUserManagement
            // 
            this.miUserManagement.Name = "miUserManagement";
            this.miUserManagement.Size = new System.Drawing.Size(151, 22);
            this.miUserManagement.Text = "用户管理(&U)...";
            this.miUserManagement.Visible = false;
            this.miUserManagement.Click += new System.EventHandler(this.MenuItemUser_Click);
            // 
            // miOrganizationManagement
            // 
            this.miOrganizationManagement.Name = "miOrganizationManagement";
            this.miOrganizationManagement.Size = new System.Drawing.Size(151, 22);
            this.miOrganizationManagement.Text = "组织架构(&O)...";
            this.miOrganizationManagement.Visible = false;
            this.miOrganizationManagement.Click += new System.EventHandler(this.组织架构OToolStripMenuItem_Click);
            // 
            // miHelp
            // 
            this.miHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miAbout});
            this.miHelp.Name = "miHelp";
            this.miHelp.Size = new System.Drawing.Size(61, 22);
            this.miHelp.Text = "帮助(&H)";
            // 
            // miAbout
            // 
            this.miAbout.Name = "miAbout";
            this.miAbout.Size = new System.Drawing.Size(125, 22);
            this.miAbout.Text = "关于(&A)...";
            this.miAbout.Click += new System.EventHandler(this.MiAbout_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.labelCurrentName,
            this.toolStripStatusLabel2,
            this.lableCurrentOrganization,
            this.toolStripStatusLabel3,
            this.labelCurrentProject});
            this.statusStrip1.Location = new System.Drawing.Point(0, 468);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(752, 22);
            this.statusStrip1.TabIndex = 3;
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(68, 17);
            this.toolStripStatusLabel1.Text = "当前用户：";
            // 
            // labelCurrentName
            // 
            this.labelCurrentName.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelCurrentName.ForeColor = System.Drawing.Color.Blue;
            this.labelCurrentName.Name = "labelCurrentName";
            this.labelCurrentName.Size = new System.Drawing.Size(0, 17);
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(68, 17);
            this.toolStripStatusLabel2.Text = "当前部门：";
            // 
            // lableCurrentOrganization
            // 
            this.lableCurrentOrganization.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lableCurrentOrganization.ForeColor = System.Drawing.Color.Blue;
            this.lableCurrentOrganization.Name = "lableCurrentOrganization";
            this.lableCurrentOrganization.Size = new System.Drawing.Size(0, 17);
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(68, 17);
            this.toolStripStatusLabel3.Text = "当前项目：";
            // 
            // labelCurrentProject
            // 
            this.labelCurrentProject.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelCurrentProject.ForeColor = System.Drawing.Color.Red;
            this.labelCurrentProject.Name = "labelCurrentProject";
            this.labelCurrentProject.Size = new System.Drawing.Size(0, 17);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(752, 490);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CRM系统";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.Resize += new System.EventHandler(this.FormMain_Resize);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem miFile;
        private System.Windows.Forms.ToolStripMenuItem miExit;
        private System.Windows.Forms.ToolStripMenuItem miClients;
        private System.Windows.Forms.ToolStripMenuItem miMyClients;
        private System.Windows.Forms.ToolStripMenuItem miPublic;
        private System.Windows.Forms.ToolStripMenuItem miManagement;
        private System.Windows.Forms.ToolStripMenuItem miProjectManagement;
        private System.Windows.Forms.ToolStripMenuItem miModifyPassword;
        private System.Windows.Forms.ToolStripMenuItem miUserManagement;
        private System.Windows.Forms.ToolStripMenuItem miOrganizationManagement;
        private System.Windows.Forms.ToolStripMenuItem miChangeUser;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel labelCurrentName;
        private System.Windows.Forms.ToolStripMenuItem miDispatch;
        private System.Windows.Forms.ToolStripMenuItem miAddCustomer;
        private System.Windows.Forms.ToolStripMenuItem miImport;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel lableCurrentOrganization;
        private System.Windows.Forms.ToolStripMenuItem miHelp;
        private System.Windows.Forms.ToolStripMenuItem miAbout;
        private System.Windows.Forms.ToolStripMenuItem miAllCustomers;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStripStatusLabel labelCurrentProject;
        private System.Windows.Forms.ToolStripMenuItem miHighPriorityCustomers;
        public System.Windows.Forms.StatusStrip statusStrip1;
    }
}

