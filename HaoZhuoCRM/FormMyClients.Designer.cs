namespace HaoZhuoCRM
{
    partial class FormMyClients
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
            this.labelName = new System.Windows.Forms.Label();
            this.cmbProvinces = new System.Windows.Forms.ComboBox();
            this.butQuery = new System.Windows.Forms.Button();
            this.txtName = new System.Windows.Forms.TextBox();
            this.panelQuery = new System.Windows.Forms.Panel();
            this.cmbProjects = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbCustomerSources = new System.Windows.Forms.ComboBox();
            this.butReset = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbCustomerTypes = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbCounties = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbCities = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtMobile = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnNew = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lvClients = new System.Windows.Forms.ListView();
            this.columnHeader0 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader16 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader15 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader12 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader11 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader13 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader14 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel3 = new System.Windows.Forms.Panel();
            this.cmbPagesizes = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.lblTotalCount = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.lblPageCount = new System.Windows.Forms.Label();
            this.lblCurrentPage = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.btnFirstPage = new System.Windows.Forms.Button();
            this.btnPrePage = new System.Windows.Forms.Button();
            this.btnNextPage = new System.Windows.Forms.Button();
            this.btnLastPage = new System.Windows.Forms.Button();
            this.panelQuery.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(8, 12);
            this.labelName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(65, 12);
            this.labelName.TabIndex = 0;
            this.labelName.Text = "客户姓名：";
            // 
            // cmbProvinces
            // 
            this.cmbProvinces.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProvinces.FormattingEnabled = true;
            this.cmbProvinces.Location = new System.Drawing.Point(196, 46);
            this.cmbProvinces.Margin = new System.Windows.Forms.Padding(2);
            this.cmbProvinces.Name = "cmbProvinces";
            this.cmbProvinces.Size = new System.Drawing.Size(87, 20);
            this.cmbProvinces.TabIndex = 7;
            this.cmbProvinces.SelectedIndexChanged += new System.EventHandler(this.CmbProvinces_SelectedIndexChanged);
            // 
            // butQuery
            // 
            this.butQuery.Location = new System.Drawing.Point(759, 8);
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
            this.txtName.Location = new System.Drawing.Point(79, 10);
            this.txtName.Margin = new System.Windows.Forms.Padding(2);
            this.txtName.MaxLength = 20;
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(73, 21);
            this.txtName.TabIndex = 1;
            // 
            // panelQuery
            // 
            this.panelQuery.Controls.Add(this.cmbProjects);
            this.panelQuery.Controls.Add(this.label8);
            this.panelQuery.Controls.Add(this.label7);
            this.panelQuery.Controls.Add(this.cmbStatus);
            this.panelQuery.Controls.Add(this.label6);
            this.panelQuery.Controls.Add(this.cmbCustomerSources);
            this.panelQuery.Controls.Add(this.butReset);
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
            this.panelQuery.Controls.Add(this.butQuery);
            this.panelQuery.Controls.Add(this.txtName);
            this.panelQuery.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelQuery.Location = new System.Drawing.Point(0, 0);
            this.panelQuery.Margin = new System.Windows.Forms.Padding(2);
            this.panelQuery.Name = "panelQuery";
            this.panelQuery.Size = new System.Drawing.Size(1077, 82);
            this.panelQuery.TabIndex = 0;
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
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(8, 48);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 12);
            this.label7.TabIndex = 16;
            this.label7.Text = "客户状态：";
            // 
            // cmbStatus
            // 
            this.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Location = new System.Drawing.Point(79, 46);
            this.cmbStatus.Margin = new System.Windows.Forms.Padding(2);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(73, 20);
            this.cmbStatus.TabIndex = 17;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(596, 12);
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
            this.cmbCustomerSources.Location = new System.Drawing.Point(669, 10);
            this.cmbCustomerSources.Margin = new System.Windows.Forms.Padding(2);
            this.cmbCustomerSources.Name = "cmbCustomerSources";
            this.cmbCustomerSources.Size = new System.Drawing.Size(76, 20);
            this.cmbCustomerSources.TabIndex = 15;
            // 
            // butReset
            // 
            this.butReset.Location = new System.Drawing.Point(759, 44);
            this.butReset.Margin = new System.Windows.Forms.Padding(2);
            this.butReset.Name = "butReset";
            this.butReset.Size = new System.Drawing.Size(58, 21);
            this.butReset.TabIndex = 13;
            this.butReset.Text = "清空(&R)";
            this.butReset.UseVisualStyleBackColor = true;
            this.butReset.Click += new System.EventHandler(this.ButReset_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(465, 12);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 4;
            this.label5.Text = "客户类型：";
            // 
            // cmbCustomerTypes
            // 
            this.cmbCustomerTypes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCustomerTypes.FormattingEnabled = true;
            this.cmbCustomerTypes.Location = new System.Drawing.Point(536, 10);
            this.cmbCustomerTypes.Margin = new System.Windows.Forms.Padding(2);
            this.cmbCustomerTypes.Name = "cmbCustomerTypes";
            this.cmbCustomerTypes.Size = new System.Drawing.Size(44, 20);
            this.cmbCustomerTypes.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(465, 48);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 10;
            this.label4.Text = "区：";
            // 
            // cmbCounties
            // 
            this.cmbCounties.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCounties.FormattingEnabled = true;
            this.cmbCounties.Location = new System.Drawing.Point(497, 46);
            this.cmbCounties.Margin = new System.Windows.Forms.Padding(2);
            this.cmbCounties.Name = "cmbCounties";
            this.cmbCounties.Size = new System.Drawing.Size(104, 20);
            this.cmbCounties.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(291, 48);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 8;
            this.label3.Text = "市：";
            // 
            // cmbCities
            // 
            this.cmbCities.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCities.FormattingEnabled = true;
            this.cmbCities.Location = new System.Drawing.Point(324, 46);
            this.cmbCities.Margin = new System.Windows.Forms.Padding(2);
            this.cmbCities.Name = "cmbCities";
            this.cmbCities.Size = new System.Drawing.Size(112, 20);
            this.cmbCities.TabIndex = 9;
            this.cmbCities.SelectedIndexChanged += new System.EventHandler(this.CmbCities_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(162, 48);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 6;
            this.label2.Text = "省：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(158, 12);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "手机号码：";
            // 
            // txtMobile
            // 
            this.txtMobile.Location = new System.Drawing.Point(225, 10);
            this.txtMobile.Margin = new System.Windows.Forms.Padding(2);
            this.txtMobile.MaxLength = 11;
            this.txtMobile.Name = "txtMobile";
            this.txtMobile.Size = new System.Drawing.Size(88, 21);
            this.txtMobile.TabIndex = 3;
            this.txtMobile.WordWrap = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnNew);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 472);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1077, 37);
            this.panel1.TabIndex = 2;
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(6, 9);
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
            this.panel2.Controls.Add(this.lvClients);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 82);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1077, 390);
            this.panel2.TabIndex = 3;
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
            this.columnHeader4,
            this.columnHeader8,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader9,
            this.columnHeader10,
            this.columnHeader12,
            this.columnHeader11,
            this.columnHeader13,
            this.columnHeader14});
            this.lvClients.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvClients.FullRowSelect = true;
            this.lvClients.GridLines = true;
            this.lvClients.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvClients.HideSelection = false;
            this.lvClients.Location = new System.Drawing.Point(0, 0);
            this.lvClients.Margin = new System.Windows.Forms.Padding(2);
            this.lvClients.MultiSelect = false;
            this.lvClients.Name = "lvClients";
            this.lvClients.Size = new System.Drawing.Size(1077, 354);
            this.lvClients.TabIndex = 2;
            this.lvClients.UseCompatibleStateImageBehavior = false;
            this.lvClients.View = System.Windows.Forms.View.Details;
            this.lvClients.DoubleClick += new System.EventHandler(this.LvClients_DoubleClick);
            // 
            // columnHeader0
            // 
            this.columnHeader0.Text = "";
            this.columnHeader0.Width = 40;
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
            // columnHeader4
            // 
            this.columnHeader4.Text = "客户类型";
            this.columnHeader4.Width = 70;
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
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.panel3.Controls.Add(this.btnLastPage);
            this.panel3.Controls.Add(this.btnNextPage);
            this.panel3.Controls.Add(this.btnPrePage);
            this.panel3.Controls.Add(this.btnFirstPage);
            this.panel3.Controls.Add(this.cmbPagesizes);
            this.panel3.Controls.Add(this.button1);
            this.panel3.Controls.Add(this.textBox2);
            this.panel3.Controls.Add(this.label16);
            this.panel3.Controls.Add(this.label15);
            this.panel3.Controls.Add(this.label14);
            this.panel3.Controls.Add(this.lblTotalCount);
            this.panel3.Controls.Add(this.label12);
            this.panel3.Controls.Add(this.lblPageCount);
            this.panel3.Controls.Add(this.lblCurrentPage);
            this.panel3.Controls.Add(this.label9);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 354);
            this.panel3.Margin = new System.Windows.Forms.Padding(2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1077, 36);
            this.panel3.TabIndex = 3;
            // 
            // cmbPagesizes
            // 
            this.cmbPagesizes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPagesizes.FormattingEnabled = true;
            this.cmbPagesizes.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "20"});
            this.cmbPagesizes.Location = new System.Drawing.Point(436, 8);
            this.cmbPagesizes.Name = "cmbPagesizes";
            this.cmbPagesizes.Size = new System.Drawing.Size(52, 20);
            this.cmbPagesizes.TabIndex = 15;
            this.cmbPagesizes.SelectedIndexChanged += new System.EventHandler(this.CmbPagesizes_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(889, 7);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 14;
            this.button1.Text = "跳转";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(837, 8);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(46, 21);
            this.textBox2.TabIndex = 13;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(500, 12);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(17, 12);
            this.label16.TabIndex = 8;
            this.label16.Text = "条";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(396, 12);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(29, 12);
            this.label15.TabIndex = 7;
            this.label15.Text = "每页";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(269, 12);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(41, 12);
            this.label14.TabIndex = 6;
            this.label14.Text = "条记录";
            // 
            // lblTotalCount
            // 
            this.lblTotalCount.Location = new System.Drawing.Point(213, 12);
            this.lblTotalCount.Name = "lblTotalCount";
            this.lblTotalCount.Size = new System.Drawing.Size(52, 12);
            this.lblTotalCount.TabIndex = 5;
            this.lblTotalCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(194, 12);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(17, 12);
            this.label12.TabIndex = 4;
            this.label12.Text = "共";
            // 
            // lblPageCount
            // 
            this.lblPageCount.Location = new System.Drawing.Point(97, 12);
            this.lblPageCount.Name = "lblPageCount";
            this.lblPageCount.Size = new System.Drawing.Size(41, 12);
            this.lblPageCount.TabIndex = 3;
            this.lblPageCount.Text = "1";
            this.lblPageCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCurrentPage
            // 
            this.lblCurrentPage.Location = new System.Drawing.Point(27, 12);
            this.lblCurrentPage.Name = "lblCurrentPage";
            this.lblCurrentPage.Size = new System.Drawing.Size(47, 12);
            this.lblCurrentPage.TabIndex = 2;
            this.lblCurrentPage.Text = "1";
            this.lblCurrentPage.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(80, 12);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(11, 12);
            this.label9.TabIndex = 0;
            this.label9.Text = "/";
            // 
            // btnFirstPage
            // 
            this.btnFirstPage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFirstPage.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnFirstPage.Location = new System.Drawing.Point(548, 7);
            this.btnFirstPage.Name = "btnFirstPage";
            this.btnFirstPage.Size = new System.Drawing.Size(56, 23);
            this.btnFirstPage.TabIndex = 16;
            this.btnFirstPage.Text = "首页";
            this.btnFirstPage.UseVisualStyleBackColor = true;
            this.btnFirstPage.Click += new System.EventHandler(this.BtnFirstPage_Click);
            // 
            // btnPrePage
            // 
            this.btnPrePage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrePage.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnPrePage.Location = new System.Drawing.Point(617, 7);
            this.btnPrePage.Name = "btnPrePage";
            this.btnPrePage.Size = new System.Drawing.Size(56, 23);
            this.btnPrePage.TabIndex = 17;
            this.btnPrePage.Text = "上页";
            this.btnPrePage.UseVisualStyleBackColor = true;
            this.btnPrePage.Click += new System.EventHandler(this.BtnPrePage_Click);
            // 
            // btnNextPage
            // 
            this.btnNextPage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNextPage.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnNextPage.Location = new System.Drawing.Point(686, 7);
            this.btnNextPage.Name = "btnNextPage";
            this.btnNextPage.Size = new System.Drawing.Size(56, 23);
            this.btnNextPage.TabIndex = 18;
            this.btnNextPage.Text = "下页";
            this.btnNextPage.UseVisualStyleBackColor = true;
            this.btnNextPage.Click += new System.EventHandler(this.BtnNextPage_Click);
            // 
            // btnLastPage
            // 
            this.btnLastPage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLastPage.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnLastPage.Location = new System.Drawing.Point(755, 7);
            this.btnLastPage.Name = "btnLastPage";
            this.btnLastPage.Size = new System.Drawing.Size(56, 23);
            this.btnLastPage.TabIndex = 19;
            this.btnLastPage.Text = "尾页";
            this.btnLastPage.UseVisualStyleBackColor = true;
            this.btnLastPage.Click += new System.EventHandler(this.BtnLastPage_Click);
            // 
            // FormMyClients
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1077, 509);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelQuery);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FormMyClients";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "我的客户";
            this.Load += new System.EventHandler(this.FormMyClients_Load);
            this.panelQuery.ResumeLayout(false);
            this.panelQuery.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.ComboBox cmbProvinces;
        private System.Windows.Forms.Button butQuery;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Panel panelQuery;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtMobile;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbCounties;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbCities;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbCustomerTypes;
        private System.Windows.Forms.Button butReset;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ListView lvClients;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.ColumnHeader columnHeader10;
        private System.Windows.Forms.ColumnHeader columnHeader11;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbCustomerSources;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader0;
        private System.Windows.Forms.ColumnHeader columnHeader12;
        private System.Windows.Forms.ColumnHeader columnHeader13;
        private System.Windows.Forms.ColumnHeader columnHeader14;
        private System.Windows.Forms.ColumnHeader columnHeader15;
        private System.Windows.Forms.ComboBox cmbProjects;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ColumnHeader columnHeader16;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label lblTotalCount;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lblPageCount;
        private System.Windows.Forms.Label lblCurrentPage;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cmbPagesizes;
        private System.Windows.Forms.Button btnFirstPage;
        private System.Windows.Forms.Button btnLastPage;
        private System.Windows.Forms.Button btnNextPage;
        private System.Windows.Forms.Button btnPrePage;
    }
}