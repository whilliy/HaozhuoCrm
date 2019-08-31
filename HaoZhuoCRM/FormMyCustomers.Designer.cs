namespace HaoZhuoCRM
{
    partial class FormMyCustomers
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMyCustomers));
            this.labelName = new System.Windows.Forms.Label();
            this.cmbProvinces = new System.Windows.Forms.ComboBox();
            this.butQuery = new System.Windows.Forms.Button();
            this.txtName = new System.Windows.Forms.TextBox();
            this.panelQuery = new System.Windows.Forms.Panel();
            this.cbLeaveWordsTime = new System.Windows.Forms.CheckBox();
            this.label17 = new System.Windows.Forms.Label();
            this.dtpLeaveWordsTimeEnd = new System.Windows.Forms.DateTimePicker();
            this.dtpLeaveWordsTimeBegin = new System.Windows.Forms.DateTimePicker();
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
            this.checkBoxAll = new System.Windows.Forms.CheckBox();
            this.btnReturnToPublic = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lvClients = new System.Windows.Forms.ListView();
            this.columnHeader0 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader16 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader15 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader17 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader18 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader14 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader13 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader11 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader12 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuItemReturnToPublic = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemTransfer = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.miModify = new System.Windows.Forms.ToolStripMenuItem();
            this.panel3 = new System.Windows.Forms.Panel();
            this.pager = new HaoZhuoCRM.Controls.PagerControl();
            this.cbNextFollowTime = new System.Windows.Forms.CheckBox();
            this.label9 = new System.Windows.Forms.Label();
            this.dtpNextFollowTimeEnd = new System.Windows.Forms.DateTimePicker();
            this.dtpNextFollowTimeStart = new System.Windows.Forms.DateTimePicker();
            this.panelQuery.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(8, 13);
            this.labelName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(65, 12);
            this.labelName.TabIndex = 1;
            this.labelName.Text = "客户姓名：";
            // 
            // cmbProvinces
            // 
            this.cmbProvinces.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProvinces.FormattingEnabled = true;
            this.cmbProvinces.Location = new System.Drawing.Point(515, 43);
            this.cmbProvinces.Margin = new System.Windows.Forms.Padding(2);
            this.cmbProvinces.Name = "cmbProvinces";
            this.cmbProvinces.Size = new System.Drawing.Size(87, 20);
            this.cmbProvinces.TabIndex = 20;
            this.cmbProvinces.SelectedIndexChanged += new System.EventHandler(this.CmbProvinces_SelectedIndexChanged);
            // 
            // butQuery
            // 
            this.butQuery.Location = new System.Drawing.Point(777, 76);
            this.butQuery.Margin = new System.Windows.Forms.Padding(2);
            this.butQuery.Name = "butQuery";
            this.butQuery.Size = new System.Drawing.Size(58, 21);
            this.butQuery.TabIndex = 14;
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
            this.txtName.TabIndex = 2;
            // 
            // panelQuery
            // 
            this.panelQuery.Controls.Add(this.cbNextFollowTime);
            this.panelQuery.Controls.Add(this.label9);
            this.panelQuery.Controls.Add(this.dtpNextFollowTimeEnd);
            this.panelQuery.Controls.Add(this.dtpNextFollowTimeStart);
            this.panelQuery.Controls.Add(this.cbLeaveWordsTime);
            this.panelQuery.Controls.Add(this.label17);
            this.panelQuery.Controls.Add(this.dtpLeaveWordsTimeEnd);
            this.panelQuery.Controls.Add(this.dtpLeaveWordsTimeBegin);
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
            this.panelQuery.Size = new System.Drawing.Size(1084, 104);
            this.panelQuery.TabIndex = 0;
            // 
            // cbLeaveWordsTime
            // 
            this.cbLeaveWordsTime.AutoSize = true;
            this.cbLeaveWordsTime.Location = new System.Drawing.Point(12, 45);
            this.cbLeaveWordsTime.Name = "cbLeaveWordsTime";
            this.cbLeaveWordsTime.Size = new System.Drawing.Size(108, 16);
            this.cbLeaveWordsTime.TabIndex = 15;
            this.cbLeaveWordsTime.Text = "留言时间范围：";
            this.cbLeaveWordsTime.UseVisualStyleBackColor = true;
            this.cbLeaveWordsTime.CheckedChanged += new System.EventHandler(this.CbLeaveWordsTime_CheckedChanged);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(282, 47);
            this.label17.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(17, 12);
            this.label17.TabIndex = 17;
            this.label17.Text = "至";
            // 
            // dtpLeaveWordsTimeEnd
            // 
            this.dtpLeaveWordsTimeEnd.CustomFormat = "yyyy-MM-dd";
            this.dtpLeaveWordsTimeEnd.Enabled = false;
            this.dtpLeaveWordsTimeEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpLeaveWordsTimeEnd.Location = new System.Drawing.Point(325, 43);
            this.dtpLeaveWordsTimeEnd.MinDate = new System.DateTime(2019, 1, 1, 0, 0, 0, 0);
            this.dtpLeaveWordsTimeEnd.Name = "dtpLeaveWordsTimeEnd";
            this.dtpLeaveWordsTimeEnd.Size = new System.Drawing.Size(133, 21);
            this.dtpLeaveWordsTimeEnd.TabIndex = 18;
            // 
            // dtpLeaveWordsTimeBegin
            // 
            this.dtpLeaveWordsTimeBegin.CustomFormat = "yyyy-MM-dd";
            this.dtpLeaveWordsTimeBegin.Enabled = false;
            this.dtpLeaveWordsTimeBegin.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpLeaveWordsTimeBegin.Location = new System.Drawing.Point(126, 41);
            this.dtpLeaveWordsTimeBegin.MinDate = new System.DateTime(2019, 1, 1, 0, 0, 0, 0);
            this.dtpLeaveWordsTimeBegin.Name = "dtpLeaveWordsTimeBegin";
            this.dtpLeaveWordsTimeBegin.Size = new System.Drawing.Size(136, 21);
            this.dtpLeaveWordsTimeBegin.TabIndex = 16;
            // 
            // cmbProjects
            // 
            this.cmbProjects.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProjects.FormattingEnabled = true;
            this.cmbProjects.Location = new System.Drawing.Point(367, 9);
            this.cmbProjects.Margin = new System.Windows.Forms.Padding(2);
            this.cmbProjects.Name = "cmbProjects";
            this.cmbProjects.Size = new System.Drawing.Size(84, 20);
            this.cmbProjects.TabIndex = 6;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(322, 13);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 12);
            this.label8.TabIndex = 5;
            this.label8.Text = "项目：";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(774, 13);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 12);
            this.label7.TabIndex = 11;
            this.label7.Text = "客户状态：";
            // 
            // cmbStatus
            // 
            this.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Location = new System.Drawing.Point(845, 9);
            this.cmbStatus.Margin = new System.Windows.Forms.Padding(2);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(73, 20);
            this.cmbStatus.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(614, 13);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 9;
            this.label6.Text = "客户来源：";
            // 
            // cmbCustomerSources
            // 
            this.cmbCustomerSources.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCustomerSources.FormattingEnabled = true;
            this.cmbCustomerSources.Location = new System.Drawing.Point(687, 9);
            this.cmbCustomerSources.Margin = new System.Windows.Forms.Padding(2);
            this.cmbCustomerSources.Name = "cmbCustomerSources";
            this.cmbCustomerSources.Size = new System.Drawing.Size(76, 20);
            this.cmbCustomerSources.TabIndex = 10;
            // 
            // butReset
            // 
            this.butReset.Location = new System.Drawing.Point(861, 75);
            this.butReset.Margin = new System.Windows.Forms.Padding(2);
            this.butReset.Name = "butReset";
            this.butReset.Size = new System.Drawing.Size(58, 21);
            this.butReset.TabIndex = 1;
            this.butReset.Text = "清空(&R)";
            this.butReset.UseVisualStyleBackColor = true;
            this.butReset.Click += new System.EventHandler(this.ButReset_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(483, 13);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 7;
            this.label5.Text = "客户类型：";
            // 
            // cmbCustomerTypes
            // 
            this.cmbCustomerTypes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCustomerTypes.FormattingEnabled = true;
            this.cmbCustomerTypes.Location = new System.Drawing.Point(554, 9);
            this.cmbCustomerTypes.Margin = new System.Windows.Forms.Padding(2);
            this.cmbCustomerTypes.Name = "cmbCustomerTypes";
            this.cmbCustomerTypes.Size = new System.Drawing.Size(44, 20);
            this.cmbCustomerTypes.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(784, 47);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 23;
            this.label4.Text = "区：";
            // 
            // cmbCounties
            // 
            this.cmbCounties.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCounties.FormattingEnabled = true;
            this.cmbCounties.Location = new System.Drawing.Point(816, 43);
            this.cmbCounties.Margin = new System.Windows.Forms.Padding(2);
            this.cmbCounties.Name = "cmbCounties";
            this.cmbCounties.Size = new System.Drawing.Size(104, 20);
            this.cmbCounties.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(610, 47);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 21;
            this.label3.Text = "市：";
            // 
            // cmbCities
            // 
            this.cmbCities.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCities.FormattingEnabled = true;
            this.cmbCities.Location = new System.Drawing.Point(643, 43);
            this.cmbCities.Margin = new System.Windows.Forms.Padding(2);
            this.cmbCities.Name = "cmbCities";
            this.cmbCities.Size = new System.Drawing.Size(112, 20);
            this.cmbCities.TabIndex = 22;
            this.cmbCities.SelectedIndexChanged += new System.EventHandler(this.CmbCities_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(481, 47);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 19;
            this.label2.Text = "省：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(158, 13);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "手机号码：";
            // 
            // txtMobile
            // 
            this.txtMobile.Location = new System.Drawing.Point(225, 9);
            this.txtMobile.Margin = new System.Windows.Forms.Padding(2);
            this.txtMobile.MaxLength = 11;
            this.txtMobile.Name = "txtMobile";
            this.txtMobile.Size = new System.Drawing.Size(88, 21);
            this.txtMobile.TabIndex = 4;
            this.txtMobile.WordWrap = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.checkBoxAll);
            this.panel1.Controls.Add(this.btnReturnToPublic);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 474);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1084, 37);
            this.panel1.TabIndex = 1;
            // 
            // checkBoxAll
            // 
            this.checkBoxAll.AutoSize = true;
            this.checkBoxAll.Location = new System.Drawing.Point(10, 12);
            this.checkBoxAll.Name = "checkBoxAll";
            this.checkBoxAll.Size = new System.Drawing.Size(66, 16);
            this.checkBoxAll.TabIndex = 0;
            this.checkBoxAll.Text = "全选(&A)";
            this.checkBoxAll.UseVisualStyleBackColor = true;
            this.checkBoxAll.CheckedChanged += new System.EventHandler(this.CheckBoxAll_CheckedChanged);
            // 
            // btnReturnToPublic
            // 
            this.btnReturnToPublic.Location = new System.Drawing.Point(96, 8);
            this.btnReturnToPublic.Margin = new System.Windows.Forms.Padding(2);
            this.btnReturnToPublic.Name = "btnReturnToPublic";
            this.btnReturnToPublic.Size = new System.Drawing.Size(97, 22);
            this.btnReturnToPublic.TabIndex = 1;
            this.btnReturnToPublic.Text = "扔回公海(&P)";
            this.btnReturnToPublic.UseVisualStyleBackColor = true;
            this.btnReturnToPublic.Click += new System.EventHandler(this.BtnReturnToPublic_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lvClients);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 104);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1084, 370);
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
            this.columnHeader17,
            this.columnHeader8,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader18,
            this.columnHeader14,
            this.columnHeader9,
            this.columnHeader13,
            this.columnHeader11,
            this.columnHeader12,
            this.columnHeader10});
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
            this.lvClients.Size = new System.Drawing.Size(1084, 334);
            this.lvClients.TabIndex = 2;
            this.lvClients.UseCompatibleStateImageBehavior = false;
            this.lvClients.View = System.Windows.Forms.View.Details;
            this.lvClients.DoubleClick += new System.EventHandler(this.LvClients_DoubleClick);
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
            this.columnHeader16.Width = 70;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "姓名";
            this.columnHeader2.Width = 70;
            // 
            // columnHeader15
            // 
            this.columnHeader15.Text = "性别";
            this.columnHeader15.Width = 40;
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
            // columnHeader17
            // 
            this.columnHeader17.Text = "客户状态";
            this.columnHeader17.Width = 70;
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
            this.columnHeader7.Width = 25;
            // 
            // columnHeader18
            // 
            this.columnHeader18.Text = "留言时间";
            this.columnHeader18.Width = 130;
            // 
            // columnHeader14
            // 
            this.columnHeader14.Text = "下次跟进时间";
            this.columnHeader14.Width = 150;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "录入时间";
            this.columnHeader9.Width = 150;
            // 
            // columnHeader13
            // 
            this.columnHeader13.Text = "最后跟进人";
            this.columnHeader13.Width = 80;
            // 
            // columnHeader11
            // 
            this.columnHeader11.Text = "最后跟进时间";
            this.columnHeader11.Width = 150;
            // 
            // columnHeader12
            // 
            this.columnHeader12.Text = "上次跟进人";
            this.columnHeader12.Width = 80;
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "上次跟进时间";
            this.columnHeader10.Width = 150;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemReturnToPublic,
            this.menuItemTransfer,
            this.menuItemEdit,
            this.miModify});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(125, 92);
            // 
            // menuItemReturnToPublic
            // 
            this.menuItemReturnToPublic.Name = "menuItemReturnToPublic";
            this.menuItemReturnToPublic.Size = new System.Drawing.Size(124, 22);
            this.menuItemReturnToPublic.Text = "丢回公海";
            this.menuItemReturnToPublic.Click += new System.EventHandler(this.MenuItemReturnToPublic_Click);
            // 
            // menuItemTransfer
            // 
            this.menuItemTransfer.Name = "menuItemTransfer";
            this.menuItemTransfer.Size = new System.Drawing.Size(124, 22);
            this.menuItemTransfer.Text = "转让...";
            this.menuItemTransfer.Click += new System.EventHandler(this.MenuItemTransfer_Click);
            // 
            // menuItemEdit
            // 
            this.menuItemEdit.Name = "menuItemEdit";
            this.menuItemEdit.Size = new System.Drawing.Size(124, 22);
            this.menuItemEdit.Text = "跟进...";
            this.menuItemEdit.ToolTipText = "添加跟进记录，同时可以修改用户基本信息";
            this.menuItemEdit.Click += new System.EventHandler(this.MenuItemFollow_Click);
            // 
            // miModify
            // 
            this.miModify.Name = "miModify";
            this.miModify.Size = new System.Drawing.Size(124, 22);
            this.miModify.Text = "修改(&M)";
            this.miModify.ToolTipText = "仅仅修改一下客户的基本信息";
            this.miModify.Click += new System.EventHandler(this.MiModify_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.panel3.Controls.Add(this.pager);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 334);
            this.panel3.Margin = new System.Windows.Forms.Padding(2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1084, 36);
            this.panel3.TabIndex = 0;
            // 
            // pager
            // 
            this.pager.BackColor = System.Drawing.SystemColors.Control;
            this.pager.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pager.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(78)))), ((int)(((byte)(151)))));
            this.pager.JumpText = "Go";
            this.pager.Location = new System.Drawing.Point(0, 2);
            this.pager.Name = "pager";
            this.pager.NeedExcuteQuery = true;
            this.pager.PageIndex = 1;
            this.pager.PageSize = 20;
            this.pager.RecordCount = 0;
            this.pager.Size = new System.Drawing.Size(1084, 34);
            this.pager.TabIndex = 4;
            this.pager.OnPageChanged += new System.EventHandler(this.Pager_OnPageChanged);
            // 
            // cbNextFollowTime
            // 
            this.cbNextFollowTime.AutoSize = true;
            this.cbNextFollowTime.Location = new System.Drawing.Point(11, 78);
            this.cbNextFollowTime.Name = "cbNextFollowTime";
            this.cbNextFollowTime.Size = new System.Drawing.Size(108, 16);
            this.cbNextFollowTime.TabIndex = 24;
            this.cbNextFollowTime.Text = "下次沟通时间：";
            this.cbNextFollowTime.UseVisualStyleBackColor = true;
            this.cbNextFollowTime.CheckedChanged += new System.EventHandler(this.CbNextFollowTime_CheckedChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(281, 80);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(17, 12);
            this.label9.TabIndex = 26;
            this.label9.Text = "至";
            // 
            // dtpNextFollowTimeEnd
            // 
            this.dtpNextFollowTimeEnd.CustomFormat = "yyyy-MM-dd HH:mm";
            this.dtpNextFollowTimeEnd.Enabled = false;
            this.dtpNextFollowTimeEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpNextFollowTimeEnd.Location = new System.Drawing.Point(324, 76);
            this.dtpNextFollowTimeEnd.MinDate = new System.DateTime(2019, 1, 1, 0, 0, 0, 0);
            this.dtpNextFollowTimeEnd.Name = "dtpNextFollowTimeEnd";
            this.dtpNextFollowTimeEnd.Size = new System.Drawing.Size(136, 21);
            this.dtpNextFollowTimeEnd.TabIndex = 27;
            // 
            // dtpNextFollowTimeStart
            // 
            this.dtpNextFollowTimeStart.CustomFormat = "yyyy-MM-dd HH:mm";
            this.dtpNextFollowTimeStart.Enabled = false;
            this.dtpNextFollowTimeStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpNextFollowTimeStart.Location = new System.Drawing.Point(125, 74);
            this.dtpNextFollowTimeStart.MinDate = new System.DateTime(2019, 1, 1, 0, 0, 0, 0);
            this.dtpNextFollowTimeStart.Name = "dtpNextFollowTimeStart";
            this.dtpNextFollowTimeStart.Size = new System.Drawing.Size(136, 21);
            this.dtpNextFollowTimeStart.TabIndex = 25;
            // 
            // FormMyCustomers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1084, 511);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelQuery);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FormMyCustomers";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "我的客户";
            this.Load += new System.EventHandler(this.FormMyClients_Load);
            this.panelQuery.ResumeLayout(false);
            this.panelQuery.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
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
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbCustomerSources;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader12;
        private System.Windows.Forms.ColumnHeader columnHeader13;
        private System.Windows.Forms.ColumnHeader columnHeader14;
        private System.Windows.Forms.ColumnHeader columnHeader15;
        private System.Windows.Forms.ComboBox cmbProjects;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ColumnHeader columnHeader16;
        private System.Windows.Forms.ColumnHeader columnHeader17;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuItemReturnToPublic;
        private System.Windows.Forms.ToolStripMenuItem menuItemTransfer;
        private System.Windows.Forms.ToolStripMenuItem menuItemEdit;
        private System.Windows.Forms.Button btnReturnToPublic;
        private System.Windows.Forms.CheckBox checkBoxAll;
        private System.Windows.Forms.ColumnHeader columnHeader0;
        private System.Windows.Forms.ColumnHeader columnHeader18;
        private System.Windows.Forms.DateTimePicker dtpLeaveWordsTimeBegin;
        private System.Windows.Forms.DateTimePicker dtpLeaveWordsTimeEnd;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.CheckBox cbLeaveWordsTime;
        private Controls.PagerControl pager;
        private System.Windows.Forms.ToolStripMenuItem miModify;
        private System.Windows.Forms.CheckBox cbNextFollowTime;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DateTimePicker dtpNextFollowTimeEnd;
        private System.Windows.Forms.DateTimePicker dtpNextFollowTimeStart;
    }
}