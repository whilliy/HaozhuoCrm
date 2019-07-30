namespace HaoZhuoCRM
{
    partial class FormDispatch
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
            this.components = new System.ComponentModel.Container();
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.miDispatch = new System.Windows.Forms.ToolStripMenuItem();
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cmbProjects = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbCustomerSources = new System.Windows.Forms.ComboBox();
            this.butReset = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtMobile = new System.Windows.Forms.TextBox();
            this.panelQuery = new System.Windows.Forms.Panel();
            this.labelName = new System.Windows.Forms.Label();
            this.butQuery = new System.Windows.Forms.Button();
            this.txtName = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnDispatch = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lvClients = new System.Windows.Forms.ListView();
            this.columnHeader0 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader16 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader15 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pager = new HaoZhuoCRM.Controls.PagerControl();
            this.checkBoxAll = new System.Windows.Forms.CheckBox();
            this.contextMenuStrip1.SuspendLayout();
            this.panelQuery.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "省";
            this.columnHeader5.Width = 80;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "市";
            this.columnHeader6.Width = 80;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "区";
            this.columnHeader7.Width = 80;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "录入时间";
            this.columnHeader9.Width = 150;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miDispatch});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(118, 26);
            // 
            // miDispatch
            // 
            this.miDispatch.Name = "miDispatch";
            this.miDispatch.Size = new System.Drawing.Size(117, 22);
            this.miDispatch.Text = "分派(&D)";
            this.miDispatch.Click += new System.EventHandler(this.MiDispatch_Click);
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "客户来源";
            this.columnHeader8.Width = 70;
            // 
            // cmbProjects
            // 
            this.cmbProjects.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProjects.FormattingEnabled = true;
            this.cmbProjects.Location = new System.Drawing.Point(367, 9);
            this.cmbProjects.Margin = new System.Windows.Forms.Padding(2);
            this.cmbProjects.Name = "cmbProjects";
            this.cmbProjects.Size = new System.Drawing.Size(84, 20);
            this.cmbProjects.TabIndex = 19;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(322, 13);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 12);
            this.label8.TabIndex = 18;
            this.label8.Text = "项目：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(476, 13);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 14;
            this.label6.Text = "客户来源：";
            // 
            // cmbCustomerSources
            // 
            this.cmbCustomerSources.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCustomerSources.FormattingEnabled = true;
            this.cmbCustomerSources.Location = new System.Drawing.Point(549, 9);
            this.cmbCustomerSources.Margin = new System.Windows.Forms.Padding(2);
            this.cmbCustomerSources.Name = "cmbCustomerSources";
            this.cmbCustomerSources.Size = new System.Drawing.Size(76, 20);
            this.cmbCustomerSources.TabIndex = 15;
            // 
            // butReset
            // 
            this.butReset.Location = new System.Drawing.Point(733, 8);
            this.butReset.Margin = new System.Windows.Forms.Padding(2);
            this.butReset.Name = "butReset";
            this.butReset.Size = new System.Drawing.Size(58, 21);
            this.butReset.TabIndex = 13;
            this.butReset.Text = "清空(&R)";
            this.butReset.UseVisualStyleBackColor = true;
            this.butReset.Click += new System.EventHandler(this.ButReset_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(158, 13);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "手机号码：";
            // 
            // txtMobile
            // 
            this.txtMobile.Location = new System.Drawing.Point(225, 9);
            this.txtMobile.Margin = new System.Windows.Forms.Padding(2);
            this.txtMobile.MaxLength = 11;
            this.txtMobile.Name = "txtMobile";
            this.txtMobile.Size = new System.Drawing.Size(88, 21);
            this.txtMobile.TabIndex = 3;
            this.txtMobile.WordWrap = false;
            // 
            // panelQuery
            // 
            this.panelQuery.Controls.Add(this.cmbProjects);
            this.panelQuery.Controls.Add(this.label8);
            this.panelQuery.Controls.Add(this.label6);
            this.panelQuery.Controls.Add(this.cmbCustomerSources);
            this.panelQuery.Controls.Add(this.butReset);
            this.panelQuery.Controls.Add(this.label1);
            this.panelQuery.Controls.Add(this.txtMobile);
            this.panelQuery.Controls.Add(this.labelName);
            this.panelQuery.Controls.Add(this.butQuery);
            this.panelQuery.Controls.Add(this.txtName);
            this.panelQuery.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelQuery.Location = new System.Drawing.Point(0, 0);
            this.panelQuery.Margin = new System.Windows.Forms.Padding(2);
            this.panelQuery.Name = "panelQuery";
            this.panelQuery.Size = new System.Drawing.Size(971, 38);
            this.panelQuery.TabIndex = 4;
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(8, 13);
            this.labelName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(65, 12);
            this.labelName.TabIndex = 0;
            this.labelName.Text = "客户姓名：";
            // 
            // butQuery
            // 
            this.butQuery.Location = new System.Drawing.Point(656, 9);
            this.butQuery.Margin = new System.Windows.Forms.Padding(2);
            this.butQuery.Name = "butQuery";
            this.butQuery.Size = new System.Drawing.Size(58, 21);
            this.butQuery.TabIndex = 12;
            this.butQuery.Text = "查询(&Q)";
            this.butQuery.UseVisualStyleBackColor = true;
            this.butQuery.Click += new System.EventHandler(this.ButQuery_Click);
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(79, 9);
            this.txtName.Margin = new System.Windows.Forms.Padding(2);
            this.txtName.MaxLength = 20;
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(73, 21);
            this.txtName.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.checkBoxAll);
            this.panel1.Controls.Add(this.btnDispatch);
            this.panel1.Controls.Add(this.btnNew);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 475);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(971, 36);
            this.panel1.TabIndex = 5;
            // 
            // btnDispatch
            // 
            this.btnDispatch.Location = new System.Drawing.Point(162, 10);
            this.btnDispatch.Margin = new System.Windows.Forms.Padding(2);
            this.btnDispatch.Name = "btnDispatch";
            this.btnDispatch.Size = new System.Drawing.Size(68, 22);
            this.btnDispatch.TabIndex = 1;
            this.btnDispatch.Text = "分派(&D)";
            this.btnDispatch.UseVisualStyleBackColor = true;
            this.btnDispatch.Click += new System.EventHandler(this.BtnDispatch_Click);
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(6, 10);
            this.btnNew.Margin = new System.Windows.Forms.Padding(2);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(68, 22);
            this.btnNew.TabIndex = 0;
            this.btnNew.Text = "新增(&N)";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.BtnNew_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.panel2.Controls.Add(this.lvClients);
            this.panel2.Controls.Add(this.pager);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 38);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(971, 437);
            this.panel2.TabIndex = 6;
            // 
            // lvClients
            // 
            this.lvClients.CheckBoxes = true;
            this.lvClients.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader0,
            this.columnHeader1,
            this.columnHeader16,
            this.columnHeader2,
            this.columnHeader15,
            this.columnHeader3,
            this.columnHeader8,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader9});
            this.lvClients.ContextMenuStrip = this.contextMenuStrip1;
            this.lvClients.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvClients.FullRowSelect = true;
            this.lvClients.GridLines = true;
            this.lvClients.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvClients.HideSelection = false;
            this.lvClients.Location = new System.Drawing.Point(0, 0);
            this.lvClients.Margin = new System.Windows.Forms.Padding(2);
            this.lvClients.MultiSelect = false;
            this.lvClients.Name = "lvClients";
            this.lvClients.Size = new System.Drawing.Size(971, 403);
            this.lvClients.TabIndex = 2;
            this.lvClients.UseCompatibleStateImageBehavior = false;
            this.lvClients.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader0
            // 
            this.columnHeader0.Text = "";
            this.columnHeader0.Width = 30;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "序号";
            this.columnHeader1.Width = 40;
            // 
            // columnHeader16
            // 
            this.columnHeader16.Text = "所属项目";
            this.columnHeader16.Width = 100;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "姓名";
            this.columnHeader2.Width = 80;
            // 
            // columnHeader15
            // 
            this.columnHeader15.Text = "性别";
            this.columnHeader15.Width = 46;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "手机号码";
            this.columnHeader3.Width = 120;
            // 
            // pager
            // 
            this.pager.BackColor = System.Drawing.SystemColors.Control;
            this.pager.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pager.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(78)))), ((int)(((byte)(151)))));
            this.pager.JumpText = "Go";
            this.pager.Location = new System.Drawing.Point(0, 403);
            this.pager.Name = "pager";
            this.pager.NeedExcuteQuery = true;
            this.pager.PageIndex = 1;
            this.pager.PageSize = 20;
            this.pager.RecordCount = 0;
            this.pager.Size = new System.Drawing.Size(971, 34);
            this.pager.TabIndex = 3;
            this.pager.OnPageChanged += new System.EventHandler(this.Pager_OnPageChanged);
            // 
            // checkBoxAll
            // 
            this.checkBoxAll.AutoSize = true;
            this.checkBoxAll.Location = new System.Drawing.Point(86, 13);
            this.checkBoxAll.Name = "checkBoxAll";
            this.checkBoxAll.Size = new System.Drawing.Size(66, 16);
            this.checkBoxAll.TabIndex = 7;
            this.checkBoxAll.Text = "全选(&A)";
            this.checkBoxAll.UseVisualStyleBackColor = true;
            this.checkBoxAll.CheckedChanged += new System.EventHandler(this.CheckBoxAll_CheckedChanged);
            // 
            // FormDispatch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(971, 511);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelQuery);
            this.Name = "FormDispatch";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "数据分派";
            this.Load += new System.EventHandler(this.FormPublic_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.panelQuery.ResumeLayout(false);
            this.panelQuery.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ComboBox cmbProjects;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbCustomerSources;
        private System.Windows.Forms.Button butReset;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtMobile;
        private System.Windows.Forms.Panel panelQuery;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Button butQuery;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ListView lvClients;
        private System.Windows.Forms.ColumnHeader columnHeader0;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader16;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader15;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private Controls.PagerControl pager;
        private System.Windows.Forms.Button btnDispatch;
        private System.Windows.Forms.ToolStripMenuItem miDispatch;
        private System.Windows.Forms.CheckBox checkBoxAll;
    }
}