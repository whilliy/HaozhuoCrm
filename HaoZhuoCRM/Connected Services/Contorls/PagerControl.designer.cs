namespace HaoZhuoCRM.Controls
{
    partial class PagerControl
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
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.btnGo = new System.Windows.Forms.Button();
            this.txtPageNum = new System.Windows.Forms.TextBox();
            this.lnkLast = new System.Windows.Forms.LinkLabel();
            this.lnkNext = new System.Windows.Forms.LinkLabel();
            this.lnkPrev = new System.Windows.Forms.LinkLabel();
            this.lnkFirst = new System.Windows.Forms.LinkLabel();
            this.lblCurrentPage = new System.Windows.Forms.Label();
            this.lblMsg2 = new System.Windows.Forms.Label();
            this.lblTotalCount = new System.Windows.Forms.Label();
            this.lblMsg1 = new System.Windows.Forms.Label();
            this.lblMsg3 = new System.Windows.Forms.Label();
            this.lblMsg4 = new System.Windows.Forms.Label();
            this.lblSept = new System.Windows.Forms.Label();
            this.lblPageCount = new System.Windows.Forms.Label();
            this.panelAll = new System.Windows.Forms.Panel();
            this.panelMiddle = new System.Windows.Forms.Panel();
            this.cmbPageSizes = new System.Windows.Forms.ComboBox();
            this.panelLeft = new System.Windows.Forms.Panel();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.panelRight = new System.Windows.Forms.Panel();
            this.panelAll.SuspendLayout();
            this.panelMiddle.SuspendLayout();
            this.panelLeft.SuspendLayout();
            this.panelRight.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnGo
            // 
            this.btnGo.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.btnGo.ForeColor = System.Drawing.Color.Black;
            this.btnGo.Location = new System.Drawing.Point(235, 7);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(45, 23);
            this.btnGo.TabIndex = 48;
            this.btnGo.Text = "跳转";
            this.btnGo.UseVisualStyleBackColor = false;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // txtPageNum
            // 
            this.txtPageNum.Location = new System.Drawing.Point(197, 8);
            this.txtPageNum.Name = "txtPageNum";
            this.txtPageNum.Size = new System.Drawing.Size(29, 21);
            this.txtPageNum.TabIndex = 46;
            this.txtPageNum.TextChanged += new System.EventHandler(this.txtPageNum_TextChanged);
            this.txtPageNum.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPageNum_KeyPress);
            // 
            // lnkLast
            // 
            this.lnkLast.AutoSize = true;
            this.lnkLast.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lnkLast.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.lnkLast.LinkColor = System.Drawing.Color.Black;
            this.lnkLast.Location = new System.Drawing.Point(153, 12);
            this.lnkLast.Name = "lnkLast";
            this.lnkLast.Size = new System.Drawing.Size(29, 12);
            this.lnkLast.TabIndex = 45;
            this.lnkLast.TabStop = true;
            this.lnkLast.Text = "尾页";
            this.lnkLast.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkLast_LinkClicked);
            // 
            // lnkNext
            // 
            this.lnkNext.AutoSize = true;
            this.lnkNext.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lnkNext.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.lnkNext.LinkColor = System.Drawing.Color.Black;
            this.lnkNext.Location = new System.Drawing.Point(106, 12);
            this.lnkNext.Name = "lnkNext";
            this.lnkNext.Size = new System.Drawing.Size(41, 12);
            this.lnkNext.TabIndex = 44;
            this.lnkNext.TabStop = true;
            this.lnkNext.Text = "下一页";
            this.lnkNext.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkNext_LinkClicked);
            // 
            // lnkPrev
            // 
            this.lnkPrev.AutoSize = true;
            this.lnkPrev.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lnkPrev.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.lnkPrev.LinkColor = System.Drawing.Color.Black;
            this.lnkPrev.Location = new System.Drawing.Point(59, 12);
            this.lnkPrev.Name = "lnkPrev";
            this.lnkPrev.Size = new System.Drawing.Size(41, 12);
            this.lnkPrev.TabIndex = 43;
            this.lnkPrev.TabStop = true;
            this.lnkPrev.Text = "上一页";
            this.lnkPrev.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkPrev_LinkClicked);
            // 
            // lnkFirst
            // 
            this.lnkFirst.AutoSize = true;
            this.lnkFirst.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lnkFirst.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.lnkFirst.LinkColor = System.Drawing.Color.Black;
            this.lnkFirst.Location = new System.Drawing.Point(24, 12);
            this.lnkFirst.Name = "lnkFirst";
            this.lnkFirst.Size = new System.Drawing.Size(29, 12);
            this.lnkFirst.TabIndex = 42;
            this.lnkFirst.TabStop = true;
            this.lnkFirst.Text = "首页";
            this.lnkFirst.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkFirst_LinkClicked);
            // 
            // lblCurrentPage
            // 
            this.lblCurrentPage.ForeColor = System.Drawing.Color.Red;
            this.lblCurrentPage.Location = new System.Drawing.Point(55, 12);
            this.lblCurrentPage.Name = "lblCurrentPage";
            this.lblCurrentPage.Size = new System.Drawing.Size(26, 12);
            this.lblCurrentPage.TabIndex = 49;
            this.lblCurrentPage.Text = "1";
            this.lblCurrentPage.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblMsg2
            // 
            this.lblMsg2.AutoSize = true;
            this.lblMsg2.Location = new System.Drawing.Point(254, 12);
            this.lblMsg2.Name = "lblMsg2";
            this.lblMsg2.Size = new System.Drawing.Size(41, 12);
            this.lblMsg2.TabIndex = 50;
            this.lblMsg2.Text = "条记录";
            // 
            // lblTotalCount
            // 
            this.lblTotalCount.ForeColor = System.Drawing.Color.Red;
            this.lblTotalCount.Location = new System.Drawing.Point(208, 12);
            this.lblTotalCount.Name = "lblTotalCount";
            this.lblTotalCount.Size = new System.Drawing.Size(41, 12);
            this.lblTotalCount.TabIndex = 51;
            this.lblTotalCount.Text = "0";
            this.lblTotalCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblMsg1
            // 
            this.lblMsg1.AutoSize = true;
            this.lblMsg1.Location = new System.Drawing.Point(188, 12);
            this.lblMsg1.Name = "lblMsg1";
            this.lblMsg1.Size = new System.Drawing.Size(17, 12);
            this.lblMsg1.TabIndex = 52;
            this.lblMsg1.Text = "共";
            // 
            // lblMsg3
            // 
            this.lblMsg3.AutoSize = true;
            this.lblMsg3.Location = new System.Drawing.Point(56, 13);
            this.lblMsg3.Name = "lblMsg3";
            this.lblMsg3.Size = new System.Drawing.Size(29, 12);
            this.lblMsg3.TabIndex = 53;
            this.lblMsg3.Text = "每页";
            // 
            // lblMsg4
            // 
            this.lblMsg4.AutoSize = true;
            this.lblMsg4.Location = new System.Drawing.Point(147, 13);
            this.lblMsg4.Name = "lblMsg4";
            this.lblMsg4.Size = new System.Drawing.Size(17, 12);
            this.lblMsg4.TabIndex = 55;
            this.lblMsg4.Text = "条";
            // 
            // lblSept
            // 
            this.lblSept.AutoSize = true;
            this.lblSept.Location = new System.Drawing.Point(84, 12);
            this.lblSept.Name = "lblSept";
            this.lblSept.Size = new System.Drawing.Size(35, 12);
            this.lblSept.TabIndex = 56;
            this.lblSept.Text = "/ 共:";
            // 
            // lblPageCount
            // 
            this.lblPageCount.ForeColor = System.Drawing.Color.Red;
            this.lblPageCount.Location = new System.Drawing.Point(124, 12);
            this.lblPageCount.Name = "lblPageCount";
            this.lblPageCount.Size = new System.Drawing.Size(26, 12);
            this.lblPageCount.TabIndex = 57;
            this.lblPageCount.Text = "1";
            this.lblPageCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panelAll
            // 
            this.panelAll.Controls.Add(this.panelMiddle);
            this.panelAll.Controls.Add(this.panelLeft);
            this.panelAll.Controls.Add(this.panelRight);
            this.panelAll.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelAll.Location = new System.Drawing.Point(0, 0);
            this.panelAll.Name = "panelAll";
            this.panelAll.Size = new System.Drawing.Size(837, 34);
            this.panelAll.TabIndex = 58;
            // 
            // panelMiddle
            // 
            this.panelMiddle.Controls.Add(this.cmbPageSizes);
            this.panelMiddle.Controls.Add(this.lblMsg3);
            this.panelMiddle.Controls.Add(this.lblMsg4);
            this.panelMiddle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMiddle.Location = new System.Drawing.Point(303, 0);
            this.panelMiddle.Name = "panelMiddle";
            this.panelMiddle.Size = new System.Drawing.Size(230, 34);
            this.panelMiddle.TabIndex = 2;
            // 
            // cmbPageSizes
            // 
            this.cmbPageSizes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPageSizes.FormattingEnabled = true;
            this.cmbPageSizes.Items.AddRange(new object[] {
            "10",
            "20",
            "30",
            "50"});
            this.cmbPageSizes.Location = new System.Drawing.Point(90, 9);
            this.cmbPageSizes.Name = "cmbPageSizes";
            this.cmbPageSizes.Size = new System.Drawing.Size(49, 20);
            this.cmbPageSizes.TabIndex = 56;
            this.cmbPageSizes.SelectedIndexChanged += new System.EventHandler(this.CmbPageSizes_SelectedIndexChanged);
            // 
            // panelLeft
            // 
            this.panelLeft.Controls.Add(this.label11);
            this.panelLeft.Controls.Add(this.label10);
            this.panelLeft.Controls.Add(this.lblTotalCount);
            this.panelLeft.Controls.Add(this.lblPageCount);
            this.panelLeft.Controls.Add(this.lblCurrentPage);
            this.panelLeft.Controls.Add(this.lblSept);
            this.panelLeft.Controls.Add(this.lblMsg2);
            this.panelLeft.Controls.Add(this.lblMsg1);
            this.panelLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelLeft.Location = new System.Drawing.Point(0, 0);
            this.panelLeft.Name = "panelLeft";
            this.panelLeft.Size = new System.Drawing.Size(303, 34);
            this.panelLeft.TabIndex = 1;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(5, 12);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(47, 12);
            this.label11.TabIndex = 59;
            this.label11.Text = "当前页:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(155, 12);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(17, 12);
            this.label10.TabIndex = 58;
            this.label10.Text = "页";
            // 
            // panelRight
            // 
            this.panelRight.Controls.Add(this.lnkFirst);
            this.panelRight.Controls.Add(this.lnkPrev);
            this.panelRight.Controls.Add(this.lnkNext);
            this.panelRight.Controls.Add(this.lnkLast);
            this.panelRight.Controls.Add(this.txtPageNum);
            this.panelRight.Controls.Add(this.btnGo);
            this.panelRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelRight.Location = new System.Drawing.Point(533, 0);
            this.panelRight.Name = "panelRight";
            this.panelRight.Size = new System.Drawing.Size(304, 34);
            this.panelRight.TabIndex = 0;
            // 
            // PagerControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.panelAll);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(78)))), ((int)(((byte)(151)))));
            this.Name = "PagerControl";
            this.Size = new System.Drawing.Size(837, 34);
            this.panelAll.ResumeLayout(false);
            this.panelMiddle.ResumeLayout(false);
            this.panelMiddle.PerformLayout();
            this.panelLeft.ResumeLayout(false);
            this.panelLeft.PerformLayout();
            this.panelRight.ResumeLayout(false);
            this.panelRight.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.TextBox txtPageNum;
        private System.Windows.Forms.LinkLabel lnkLast;
        private System.Windows.Forms.LinkLabel lnkNext;
        private System.Windows.Forms.LinkLabel lnkPrev;
        private System.Windows.Forms.LinkLabel lnkFirst;
        private System.Windows.Forms.Label lblCurrentPage;
        private System.Windows.Forms.Label lblMsg2;
        private System.Windows.Forms.Label lblTotalCount;
        private System.Windows.Forms.Label lblMsg1;
        private System.Windows.Forms.Label lblMsg3;
        private System.Windows.Forms.Label lblMsg4;
        private System.Windows.Forms.Label lblSept;
        private System.Windows.Forms.Label lblPageCount;
        private System.Windows.Forms.Panel panelAll;
        private System.Windows.Forms.Panel panelMiddle;
        private System.Windows.Forms.Panel panelLeft;
        private System.Windows.Forms.Panel panelRight;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cmbPageSizes;
    }
}
