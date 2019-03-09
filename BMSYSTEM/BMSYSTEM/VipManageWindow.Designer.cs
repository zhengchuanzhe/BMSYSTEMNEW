namespace BMSYSTEM
{
    partial class VipManageWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VipManageWindow));
            this.lvVip = new System.Windows.Forms.ListView();
            this.colVipId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colVipNumber = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colVipName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colBalance = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colIntegral = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colVipLevel = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colVipSex = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colVipPhone = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colVipCard = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colVipBirth = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colVipAddress = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colAddDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colMark = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.修改会员信息ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.删除会员ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnOK = new System.Windows.Forms.Button();
            this.cmbDepart = new System.Windows.Forms.ComboBox();
            this.lbDepart = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.label9 = new System.Windows.Forms.Label();
            this.backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
            this.txtVipName = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.labCount = new System.Windows.Forms.Label();
            this.contextMenuStrip1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lvVip
            // 
            this.lvVip.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvVip.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colVipId,
            this.colVipNumber,
            this.colVipName,
            this.colBalance,
            this.colIntegral,
            this.colVipLevel,
            this.colVipSex,
            this.colVipPhone,
            this.colVipCard,
            this.colVipBirth,
            this.colVipAddress,
            this.colAddDate,
            this.colMark});
            this.lvVip.ContextMenuStrip = this.contextMenuStrip1;
            this.lvVip.FullRowSelect = true;
            this.lvVip.GridLines = true;
            this.lvVip.Location = new System.Drawing.Point(-3, 82);
            this.lvVip.Name = "lvVip";
            this.lvVip.Size = new System.Drawing.Size(1001, 462);
            this.lvVip.TabIndex = 1;
            this.lvVip.UseCompatibleStateImageBehavior = false;
            this.lvVip.View = System.Windows.Forms.View.Details;
            // 
            // colVipId
            // 
            this.colVipId.Text = "会员编号";
            this.colVipId.Width = 70;
            // 
            // colVipNumber
            // 
            this.colVipNumber.Text = "会员卡号";
            this.colVipNumber.Width = 80;
            // 
            // colVipName
            // 
            this.colVipName.Text = "会员姓名";
            this.colVipName.Width = 70;
            // 
            // colBalance
            // 
            this.colBalance.Text = "会员余额(元)";
            this.colBalance.Width = 90;
            // 
            // colIntegral
            // 
            this.colIntegral.Text = "会员积分";
            this.colIntegral.Width = 80;
            // 
            // colVipLevel
            // 
            this.colVipLevel.Text = "会员等级";
            this.colVipLevel.Width = 70;
            // 
            // colVipSex
            // 
            this.colVipSex.Text = "会员性别";
            this.colVipSex.Width = 70;
            // 
            // colVipPhone
            // 
            this.colVipPhone.Text = "会员电话";
            this.colVipPhone.Width = 70;
            // 
            // colVipCard
            // 
            this.colVipCard.Text = "身份证号";
            this.colVipCard.Width = 70;
            // 
            // colVipBirth
            // 
            this.colVipBirth.Text = "会员生日";
            this.colVipBirth.Width = 70;
            // 
            // colVipAddress
            // 
            this.colVipAddress.Text = "会员地址";
            this.colVipAddress.Width = 70;
            // 
            // colAddDate
            // 
            this.colAddDate.Text = "注册时间";
            this.colAddDate.Width = 70;
            // 
            // colMark
            // 
            this.colMark.Text = "备注";
            this.colMark.Width = 80;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.修改会员信息ToolStripMenuItem,
            this.删除会员ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(149, 48);
            // 
            // 修改会员信息ToolStripMenuItem
            // 
            this.修改会员信息ToolStripMenuItem.Name = "修改会员信息ToolStripMenuItem";
            this.修改会员信息ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.修改会员信息ToolStripMenuItem.Text = "修改会员信息";
            this.修改会员信息ToolStripMenuItem.Click += new System.EventHandler(this.修改会员信息ToolStripMenuItem_Click);
            // 
            // 删除会员ToolStripMenuItem
            // 
            this.删除会员ToolStripMenuItem.Name = "删除会员ToolStripMenuItem";
            this.删除会员ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.删除会员ToolStripMenuItem.Text = "删除会员";
            this.删除会员ToolStripMenuItem.Click += new System.EventHandler(this.删除会员ToolStripMenuItem_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(473, 49);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(70, 23);
            this.btnOK.TabIndex = 2;
            this.btnOK.Text = "确  认";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // cmbDepart
            // 
            this.cmbDepart.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDepart.FormattingEnabled = true;
            this.cmbDepart.Location = new System.Drawing.Point(79, 51);
            this.cmbDepart.Name = "cmbDepart";
            this.cmbDepart.Size = new System.Drawing.Size(121, 20);
            this.cmbDepart.TabIndex = 1;
            // 
            // lbDepart
            // 
            this.lbDepart.AutoSize = true;
            this.lbDepart.Location = new System.Drawing.Point(15, 55);
            this.lbDepart.Name = "lbDepart";
            this.lbDepart.Size = new System.Drawing.Size(59, 12);
            this.lbDepart.TabIndex = 0;
            this.lbDepart.Text = "选择分店:";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel2.BackgroundImage")));
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.ForeColor = System.Drawing.Color.Black;
            this.panel2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1001, 41);
            this.panel2.TabIndex = 41;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(386, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(185, 20);
            this.label1.TabIndex = 7;
            this.label1.Text = "————会员信息————";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(591, 10);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(0, 12);
            this.label6.TabIndex = 6;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(84, 72);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 12);
            this.label7.TabIndex = 5;
            this.label7.Text = "123465789";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(18, 72);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(59, 12);
            this.label8.TabIndex = 3;
            this.label8.Text = "店铺电话:";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.ForeColor = System.Drawing.Color.Black;
            this.panel1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.panel1.Location = new System.Drawing.Point(0, 537);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1001, 25);
            this.panel1.TabIndex = 40;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("微软雅黑", 8F);
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(247, 6);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(289, 16);
            this.label5.TabIndex = 7;
            this.label5.Text = "©2014 畅达车行 版权所有     技术支持 Dreamtech工作组";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(591, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 12);
            this.label3.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(84, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "123465789";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(18, 72);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "店铺电话:";
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(491, 285);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(100, 23);
            this.progressBar1.TabIndex = 42;
            this.progressBar1.Visible = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(258, 54);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(83, 12);
            this.label9.TabIndex = 43;
            this.label9.Text = "卡号/用户名：";
            // 
            // backgroundWorker2
            // 
            this.backgroundWorker2.WorkerReportsProgress = true;
            this.backgroundWorker2.WorkerSupportsCancellation = true;
            this.backgroundWorker2.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker2_DoWork);
            this.backgroundWorker2.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker2_ProgressChanged);
            this.backgroundWorker2.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker2_RunWorkerCompleted);
            // 
            // txtVipName
            // 
            this.txtVipName.Location = new System.Drawing.Point(341, 50);
            this.txtVipName.Name = "txtVipName";
            this.txtVipName.Size = new System.Drawing.Size(111, 21);
            this.txtVipName.TabIndex = 45;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(571, 54);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(47, 12);
            this.label10.TabIndex = 46;
            this.label10.Text = "会员数:";
            // 
            // labCount
            // 
            this.labCount.AutoSize = true;
            this.labCount.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold);
            this.labCount.Location = new System.Drawing.Point(615, 54);
            this.labCount.Name = "labCount";
            this.labCount.Size = new System.Drawing.Size(15, 14);
            this.labCount.TabIndex = 47;
            this.labCount.Text = "0";
            // 
            // VipManageWindow
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1001, 562);
            this.Controls.Add(this.labCount);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtVipName);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.cmbDepart);
            this.Controls.Add(this.lvVip);
            this.Controls.Add(this.lbDepart);
            this.MaximizeBox = false;
            this.Name = "VipManageWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "会员管理";
            this.Load += new System.EventHandler(this.VipManageWindow_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lvVip;
        private System.Windows.Forms.ColumnHeader colVipId;
        private System.Windows.Forms.ColumnHeader colVipNumber;
        private System.Windows.Forms.ColumnHeader colVipLevel;
        private System.Windows.Forms.ColumnHeader colVipName;
        private System.Windows.Forms.ColumnHeader colVipSex;
        private System.Windows.Forms.ColumnHeader colVipPhone;
        private System.Windows.Forms.ColumnHeader colVipCard;
        private System.Windows.Forms.ColumnHeader colVipBirth;
        private System.Windows.Forms.ColumnHeader colVipAddress;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 修改会员信息ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 删除会员ToolStripMenuItem;
        private System.Windows.Forms.ColumnHeader colAddDate;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.ComboBox cmbDepart;
        private System.Windows.Forms.Label lbDepart;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ColumnHeader colBalance;
        private System.Windows.Forms.ColumnHeader colIntegral;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label label9;
        private System.ComponentModel.BackgroundWorker backgroundWorker2;
        private System.Windows.Forms.TextBox txtVipName;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label labCount;
        private System.Windows.Forms.ColumnHeader colMark;
    }
}