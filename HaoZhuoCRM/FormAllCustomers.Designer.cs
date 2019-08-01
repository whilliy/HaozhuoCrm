namespace HaoZhuoCRM
{
    partial class FormAllCustomers
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
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.miView = new System.Windows.Forms.ToolStripMenuItem();
            this.miModify = new System.Windows.Forms.ToolStripMenuItem();
            this.butReset = new System.Windows.Forms.Button();
            this.panelQuery = new System.Windows.Forms.Panel();
            this.btnSelect = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.txtFollowUserName = new System.Windows.Forms.TextBox();
            this.cmbProjects = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbCustomerSources = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbCustomerTypes = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbCounties = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbCities = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbProvinces = new System.Windows.Forms.ComboBox();
            this.txtMobile = new System.Windows.Forms.TextBox();
            this.labelName = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.butQuery = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.btnView = new System.Windows.Forms.Button();
            this.btnModify = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lvClients = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader16 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader15 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader17 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader18 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader19 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader12 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader11 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader13 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader14 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pager = new HaoZhuoCRM.Controls.PagerControl();
            this.contextMenuStrip1.SuspendLayout();
            this.panelQuery.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miView,
            this.miModify});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(181, 70);
            // 
            // miView
            // 
            this.miView.Name = "miView";
            this.miView.Size = new System.Drawing.Size(180, 22);
            this.miView.Text = "查看(&V)";
            this.miView.Click += new System.EventHandler(this.MiView_Click);
            // 
            // miModify
            // 
            this.miModify.Name = "miModify";
            this.miModify.Size = new System.Drawing.Size(120, 22);
            this.miModify.Text = "修改(&M)";
            this.miModify.Click += new System.EventHandler(this.MiModify_Click);
            // 
            // butReset
            // 
            this.butReset.Location = new System.Drawing.Point(871, 46);
            this.butReset.Margin = new System.Windows.Forms.Padding(2);
            this.butReset.Name = "butReset";
            this.butReset.Size = new System.Drawing.Size(58, 21);
            this.butReset.TabIndex = 13;
            this.butReset.Text = "清空(&R)";
            this.butReset.UseVisualStyleBackColor = true;
            this.butReset.Click += new System.EventHandler(this.ButReset_Click);
            // 
            // panelQuery
            // 
            this.panelQuery.Controls.Add(this.btnSelect);
            this.panelQuery.Controls.Add(this.label9);
            this.panelQuery.Controls.Add(this.txtFollowUserName);
            this.panelQuery.Controls.Add(this.cmbProjects);
            this.panelQuery.Controls.Add(this.label8);
            this.panelQuery.Controls.Add(this.label7);
            this.panelQuery.Controls.Add(this.cmbStatus);
            this.panelQuery.Controls.Add(this.label6);
            this.panelQuery.Controls.Add(this.cmbCustomerSources);
            this.panelQuery.Controls.Add(this.label5);
            this.panelQuery.Controls.Add(this.cmbCustomerTypes);
            this.panelQuery.Controls.Add(this.label4);
            this.panelQuery.Controls.Add(this.cmbCounties);
            this.panelQuery.Controls.Add(this.label3);
            this.panelQuery.Controls.Add(this.cmbCities);
            this.panelQuery.Controls.Add(this.label2);
            this.panelQuery.Controls.Add(this.label1);
            this.panelQuery.Controls.Add(this.cmbProvinces);
            this.panelQuery.Controls.Add(this.txtMobile);
            this.panelQuery.Controls.Add(this.labelName);
            this.panelQuery.Controls.Add(this.txtName);
            this.panelQuery.Controls.Add(this.butReset);
            this.panelQuery.Controls.Add(this.butQuery);
            this.panelQuery.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelQuery.Location = new System.Drawing.Point(0, 0);
            this.panelQuery.Margin = new System.Windows.Forms.Padding(2);
            this.panelQuery.Name = "panelQuery";
            this.panelQuery.Size = new System.Drawing.Size(971, 76);
            this.panelQuery.TabIndex = 4;
            // 
            // btnSelect
            // 
            this.btnSelect.Location = new System.Drawing.Point(822, 43);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(33, 23);
            this.btnSelect.TabIndex = 40;
            this.btnSelect.Text = "选";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.BtnSelect_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(638, 48);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(77, 12);
            this.label9.TabIndex = 38;
            this.label9.Text = "当前跟进人：";
            // 
            // txtFollowUserName
            // 
            this.txtFollowUserName.Location = new System.Drawing.Point(722, 44);
            this.txtFollowUserName.Margin = new System.Windows.Forms.Padding(2);
            this.txtFollowUserName.MaxLength = 11;
            this.txtFollowUserName.Name = "txtFollowUserName";
            this.txtFollowUserName.ReadOnly = true;
            this.txtFollowUserName.Size = new System.Drawing.Size(94, 21);
            this.txtFollowUserName.TabIndex = 39;
            this.txtFollowUserName.WordWrap = false;
            // 
            // cmbProjects
            // 
            this.cmbProjects.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProjects.FormattingEnabled = true;
            this.cmbProjects.Location = new System.Drawing.Point(371, 8);
            this.cmbProjects.Margin = new System.Windows.Forms.Padding(2);
            this.cmbProjects.Name = "cmbProjects";
            this.cmbProjects.Size = new System.Drawing.Size(84, 20);
            this.cmbProjects.TabIndex = 37;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(326, 12);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 12);
            this.label8.TabIndex = 36;
            this.label8.Text = "项目：";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 47);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 12);
            this.label7.TabIndex = 34;
            this.label7.Text = "客户状态：";
            // 
            // cmbStatus
            // 
            this.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Location = new System.Drawing.Point(83, 43);
            this.cmbStatus.Margin = new System.Windows.Forms.Padding(2);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(73, 20);
            this.cmbStatus.TabIndex = 35;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(638, 11);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 32;
            this.label6.Text = "客户来源：";
            // 
            // cmbCustomerSources
            // 
            this.cmbCustomerSources.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCustomerSources.FormattingEnabled = true;
            this.cmbCustomerSources.Location = new System.Drawing.Point(722, 7);
            this.cmbCustomerSources.Margin = new System.Windows.Forms.Padding(2);
            this.cmbCustomerSources.Name = "cmbCustomerSources";
            this.cmbCustomerSources.Size = new System.Drawing.Size(94, 20);
            this.cmbCustomerSources.TabIndex = 33;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(469, 12);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 24;
            this.label5.Text = "客户类型：";
            // 
            // cmbCustomerTypes
            // 
            this.cmbCustomerTypes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCustomerTypes.FormattingEnabled = true;
            this.cmbCustomerTypes.Location = new System.Drawing.Point(540, 8);
            this.cmbCustomerTypes.Margin = new System.Windows.Forms.Padding(2);
            this.cmbCustomerTypes.Name = "cmbCustomerTypes";
            this.cmbCustomerTypes.Size = new System.Drawing.Size(44, 20);
            this.cmbCustomerTypes.TabIndex = 25;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(469, 47);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 30;
            this.label4.Text = "区：";
            // 
            // cmbCounties
            // 
            this.cmbCounties.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCounties.FormattingEnabled = true;
            this.cmbCounties.Location = new System.Drawing.Point(501, 43);
            this.cmbCounties.Margin = new System.Windows.Forms.Padding(2);
            this.cmbCounties.Name = "cmbCounties";
            this.cmbCounties.Size = new System.Drawing.Size(104, 20);
            this.cmbCounties.TabIndex = 31;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(295, 47);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 28;
            this.label3.Text = "市：";
            // 
            // cmbCities
            // 
            this.cmbCities.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCities.FormattingEnabled = true;
            this.cmbCities.Location = new System.Drawing.Point(328, 43);
            this.cmbCities.Margin = new System.Windows.Forms.Padding(2);
            this.cmbCities.Name = "cmbCities";
            this.cmbCities.Size = new System.Drawing.Size(112, 20);
            this.cmbCities.TabIndex = 29;
            this.cmbCities.SelectedIndexChanged += new System.EventHandler(this.CmbCities_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(166, 47);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 26;
            this.label2.Text = "省：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(162, 12);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 22;
            this.label1.Text = "手机号码：";
            // 
            // cmbProvinces
            // 
            this.cmbProvinces.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProvinces.FormattingEnabled = true;
            this.cmbProvinces.Location = new System.Drawing.Point(200, 43);
            this.cmbProvinces.Margin = new System.Windows.Forms.Padding(2);
            this.cmbProvinces.Name = "cmbProvinces";
            this.cmbProvinces.Size = new System.Drawing.Size(87, 20);
            this.cmbProvinces.TabIndex = 27;
            this.cmbProvinces.SelectedIndexChanged += new System.EventHandler(this.CmbProvinces_SelectedIndexChanged);
            // 
            // txtMobile
            // 
            this.txtMobile.Location = new System.Drawing.Point(229, 8);
            this.txtMobile.Margin = new System.Windows.Forms.Padding(2);
            this.txtMobile.MaxLength = 11;
            this.txtMobile.Name = "txtMobile";
            this.txtMobile.Size = new System.Drawing.Size(88, 21);
            this.txtMobile.TabIndex = 23;
            this.txtMobile.WordWrap = false;
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(12, 12);
            this.labelName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(65, 12);
            this.labelName.TabIndex = 20;
            this.labelName.Text = "客户姓名：";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(83, 8);
            this.txtName.Margin = new System.Windows.Forms.Padding(2);
            this.txtName.MaxLength = 20;
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(73, 21);
            this.txtName.TabIndex = 21;
            // 
            // butQuery
            // 
            this.butQuery.Location = new System.Drawing.Point(871, 7);
            this.butQuery.Margin = new System.Windows.Forms.Padding(2);
            this.butQuery.Name = "butQuery";
            this.butQuery.Size = new System.Drawing.Size(58, 21);
            this.butQuery.TabIndex = 12;
            this.butQuery.Text = "查询(&Q)";
            this.butQuery.UseVisualStyleBackColor = true;
            this.butQuery.Click += new System.EventHandler(this.ButQuery_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.btnView);
            this.panel1.Controls.Add(this.btnModify);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 477);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(971, 34);
            this.panel1.TabIndex = 5;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(884, 6);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "查看(&V)";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // btnView
            // 
            this.btnView.Location = new System.Drawing.Point(12, 6);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(75, 23);
            this.btnView.TabIndex = 5;
            this.btnView.Text = "查看(&V)";
            this.btnView.UseVisualStyleBackColor = true;
            this.btnView.Click += new System.EventHandler(this.BtnView_Click);
            // 
            // btnModify
            // 
            this.btnModify.Location = new System.Drawing.Point(103, 6);
            this.btnModify.Name = "btnModify";
            this.btnModify.Size = new System.Drawing.Size(75, 23);
            this.btnModify.TabIndex = 6;
            this.btnModify.Text = "修改(&M)";
            this.btnModify.UseVisualStyleBackColor = true;
            this.btnModify.Click += new System.EventHandler(this.BtnModify_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.panel2.Controls.Add(this.lvClients);
            this.panel2.Controls.Add(this.pager);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 76);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(971, 401);
            this.panel2.TabIndex = 6;
            // 
            // lvClients
            // 
            this.lvClients.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader16,
            this.columnHeader2,
            this.columnHeader15,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader17,
            this.columnHeader18,
            this.columnHeader8,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader19,
            this.columnHeader9,
            this.columnHeader10,
            this.columnHeader12,
            this.columnHeader11,
            this.columnHeader13,
            this.columnHeader14});
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
            this.lvClients.Size = new System.Drawing.Size(971, 367);
            this.lvClients.TabIndex = 4;
            this.lvClients.UseCompatibleStateImageBehavior = false;
            this.lvClients.View = System.Windows.Forms.View.Details;
            this.lvClients.DoubleClick += new System.EventHandler(this.LvClients_DoubleClick);
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
            this.columnHeader15.Width = 45;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "手机号码";
            this.columnHeader3.Width = 90;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "客户类型";
            this.columnHeader4.Width = 62;
            // 
            // columnHeader17
            // 
            this.columnHeader17.Text = "客户状态";
            this.columnHeader17.Width = 70;
            // 
            // columnHeader18
            // 
            this.columnHeader18.Text = "当前跟进人";
            this.columnHeader18.Width = 100;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "客户来源";
            this.columnHeader8.Width = 70;
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
            // columnHeader19
            // 
            this.columnHeader19.Text = "留言时间";
            this.columnHeader19.Width = 150;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "录入时间";
            this.columnHeader9.Width = 150;
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "上次跟进时间";
            this.columnHeader10.Width = 150;
            // 
            // columnHeader12
            // 
            this.columnHeader12.Text = "上次跟进人";
            this.columnHeader12.Width = 80;
            // 
            // columnHeader11
            // 
            this.columnHeader11.Text = "最后跟进时间";
            this.columnHeader11.Width = 150;
            // 
            // columnHeader13
            // 
            this.columnHeader13.Text = "最后跟进人";
            this.columnHeader13.Width = 80;
            // 
            // columnHeader14
            // 
            this.columnHeader14.Text = "下次跟进时间";
            this.columnHeader14.Width = 150;
            // 
            // pager
            // 
            this.pager.BackColor = System.Drawing.SystemColors.Control;
            this.pager.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pager.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(78)))), ((int)(((byte)(151)))));
            this.pager.JumpText = "Go";
            this.pager.Location = new System.Drawing.Point(0, 367);
            this.pager.Name = "pager";
            this.pager.NeedExcuteQuery = true;
            this.pager.PageIndex = 1;
            this.pager.PageSize = 20;
            this.pager.RecordCount = 0;
            this.pager.Size = new System.Drawing.Size(971, 34);
            this.pager.TabIndex = 3;
            this.pager.OnPageChanged += new System.EventHandler(this.Pager_OnPageChanged);
            // 
            // FormAllCustomers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(971, 511);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelQuery);
            this.Name = "FormAllCustomers";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "所有客户";
            this.Load += new System.EventHandler(this.FormPublic_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.panelQuery.ResumeLayout(false);
            this.panelQuery.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Button butReset;
        private System.Windows.Forms.Panel panelQuery;
        private System.Windows.Forms.Button butQuery;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private Controls.PagerControl pager;
        private System.Windows.Forms.ToolStripMenuItem miModify;
        private System.Windows.Forms.ComboBox cmbProjects;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbCustomerSources;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbCustomerTypes;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbCounties;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbCities;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbProvinces;
        private System.Windows.Forms.TextBox txtMobile;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.ListView lvClients;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader16;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader15;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader17;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.ColumnHeader columnHeader10;
        private System.Windows.Forms.ColumnHeader columnHeader12;
        private System.Windows.Forms.ColumnHeader columnHeader11;
        private System.Windows.Forms.ColumnHeader columnHeader13;
        private System.Windows.Forms.ColumnHeader columnHeader14;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtFollowUserName;
        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.ColumnHeader columnHeader18;
        private System.Windows.Forms.ColumnHeader columnHeader19;
        private System.Windows.Forms.Button btnView;
        private System.Windows.Forms.Button btnModify;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ToolStripMenuItem miView;
    }
}