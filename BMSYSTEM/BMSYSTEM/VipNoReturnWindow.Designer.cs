namespace BMSYSTEM
{
    partial class VipNoReturnWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VipNoReturnWindow));
            this.gbVipNo = new System.Windows.Forms.GroupBox();
            this.txtVipNoNumber = new System.Windows.Forms.TextBox();
            this.txtVipNoId = new System.Windows.Forms.TextBox();
            this.lbVipNoNumber = new System.Windows.Forms.Label();
            this.lbVipNoId = new System.Windows.Forms.Label();
            this.gbVN = new System.Windows.Forms.GroupBox();
            this.cmbVNName = new System.Windows.Forms.ComboBox();
            this.txtVNCard = new System.Windows.Forms.TextBox();
            this.txtVNPhone = new System.Windows.Forms.TextBox();
            this.lbVNCard = new System.Windows.Forms.Label();
            this.lbVNPhone = new System.Windows.Forms.Label();
            this.lbVNName = new System.Windows.Forms.Label();
            this.gbBorrowMSG = new System.Windows.Forms.GroupBox();
            this.txtVNNum = new System.Windows.Forms.Label();
            this.labNightCost = new System.Windows.Forms.Label();
            this.txtBorrowTime = new System.Windows.Forms.TextBox();
            this.txtMark = new System.Windows.Forms.TextBox();
            this.txtBorrowKind = new System.Windows.Forms.TextBox();
            this.lbMark = new System.Windows.Forms.Label();
            this.lbBorrowNum = new System.Windows.Forms.Label();
            this.lbBorrowKind = new System.Windows.Forms.Label();
            this.lbBorrowTime = new System.Windows.Forms.Label();
            this.gbReturn = new System.Windows.Forms.GroupBox();
            this.txtCost = new System.Windows.Forms.Label();
            this.txtBBKTime = new System.Windows.Forms.Label();
            this.lbReturnNum = new System.Windows.Forms.Label();
            this.txtReturnNum = new System.Windows.Forms.TextBox();
            this.lbBBKTime = new System.Windows.Forms.Label();
            this.lbCost = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancle = new System.Windows.Forms.Button();
            this.epMessage = new System.Windows.Forms.ErrorProvider(this.components);
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.gbVipNo.SuspendLayout();
            this.gbVN.SuspendLayout();
            this.gbBorrowMSG.SuspendLayout();
            this.gbReturn.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.epMessage)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // gbVipNo
            // 
            this.gbVipNo.Controls.Add(this.txtVipNoNumber);
            this.gbVipNo.Controls.Add(this.txtVipNoId);
            this.gbVipNo.Controls.Add(this.lbVipNoNumber);
            this.gbVipNo.Controls.Add(this.lbVipNoId);
            this.gbVipNo.Location = new System.Drawing.Point(0, 47);
            this.gbVipNo.Name = "gbVipNo";
            this.gbVipNo.Size = new System.Drawing.Size(784, 67);
            this.gbVipNo.TabIndex = 0;
            this.gbVipNo.TabStop = false;
            this.gbVipNo.Text = "非会员信息";
            // 
            // txtVipNoNumber
            // 
            this.txtVipNoNumber.Location = new System.Drawing.Point(394, 27);
            this.txtVipNoNumber.Name = "txtVipNoNumber";
            this.txtVipNoNumber.ReadOnly = true;
            this.txtVipNoNumber.Size = new System.Drawing.Size(161, 21);
            this.txtVipNoNumber.TabIndex = 3;
            // 
            // txtVipNoId
            // 
            this.txtVipNoId.Location = new System.Drawing.Point(146, 27);
            this.txtVipNoId.Name = "txtVipNoId";
            this.txtVipNoId.ReadOnly = true;
            this.txtVipNoId.Size = new System.Drawing.Size(161, 21);
            this.txtVipNoId.TabIndex = 2;
            // 
            // lbVipNoNumber
            // 
            this.lbVipNoNumber.AutoSize = true;
            this.lbVipNoNumber.Location = new System.Drawing.Point(318, 31);
            this.lbVipNoNumber.Name = "lbVipNoNumber";
            this.lbVipNoNumber.Size = new System.Drawing.Size(77, 12);
            this.lbVipNoNumber.TabIndex = 1;
            this.lbVipNoNumber.Text = "非会员卡号：";
            // 
            // lbVipNoId
            // 
            this.lbVipNoId.AutoSize = true;
            this.lbVipNoId.Location = new System.Drawing.Point(72, 31);
            this.lbVipNoId.Name = "lbVipNoId";
            this.lbVipNoId.Size = new System.Drawing.Size(77, 12);
            this.lbVipNoId.TabIndex = 0;
            this.lbVipNoId.Text = "非会员编号：";
            // 
            // gbVN
            // 
            this.gbVN.Controls.Add(this.cmbVNName);
            this.gbVN.Controls.Add(this.txtVNCard);
            this.gbVN.Controls.Add(this.txtVNPhone);
            this.gbVN.Controls.Add(this.lbVNCard);
            this.gbVN.Controls.Add(this.lbVNPhone);
            this.gbVN.Controls.Add(this.lbVNName);
            this.gbVN.Location = new System.Drawing.Point(0, 120);
            this.gbVN.Name = "gbVN";
            this.gbVN.Size = new System.Drawing.Size(783, 93);
            this.gbVN.TabIndex = 1;
            this.gbVN.TabStop = false;
            this.gbVN.Text = "租车人信息";
            // 
            // cmbVNName
            // 
            this.cmbVNName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbVNName.FormattingEnabled = true;
            this.cmbVNName.Location = new System.Drawing.Point(146, 27);
            this.cmbVNName.Name = "cmbVNName";
            this.cmbVNName.Size = new System.Drawing.Size(161, 20);
            this.cmbVNName.TabIndex = 5;
            this.cmbVNName.SelectedIndexChanged += new System.EventHandler(this.cmbVNName_SelectedIndexChanged);
            // 
            // txtVNCard
            // 
            this.txtVNCard.Location = new System.Drawing.Point(146, 57);
            this.txtVNCard.Name = "txtVNCard";
            this.txtVNCard.ReadOnly = true;
            this.txtVNCard.Size = new System.Drawing.Size(161, 21);
            this.txtVNCard.TabIndex = 4;
            // 
            // txtVNPhone
            // 
            this.txtVNPhone.Location = new System.Drawing.Point(394, 26);
            this.txtVNPhone.Name = "txtVNPhone";
            this.txtVNPhone.ReadOnly = true;
            this.txtVNPhone.Size = new System.Drawing.Size(161, 21);
            this.txtVNPhone.TabIndex = 3;
            // 
            // lbVNCard
            // 
            this.lbVNCard.AutoSize = true;
            this.lbVNCard.Location = new System.Drawing.Point(84, 60);
            this.lbVNCard.Name = "lbVNCard";
            this.lbVNCard.Size = new System.Drawing.Size(65, 12);
            this.lbVNCard.TabIndex = 2;
            this.lbVNCard.Text = "身份证号：";
            // 
            // lbVNPhone
            // 
            this.lbVNPhone.AutoSize = true;
            this.lbVNPhone.Location = new System.Drawing.Point(318, 30);
            this.lbVNPhone.Name = "lbVNPhone";
            this.lbVNPhone.Size = new System.Drawing.Size(77, 12);
            this.lbVNPhone.TabIndex = 1;
            this.lbVNPhone.Text = "租车人电话：";
            // 
            // lbVNName
            // 
            this.lbVNName.AutoSize = true;
            this.lbVNName.Location = new System.Drawing.Point(72, 30);
            this.lbVNName.Name = "lbVNName";
            this.lbVNName.Size = new System.Drawing.Size(77, 12);
            this.lbVNName.TabIndex = 0;
            this.lbVNName.Text = "租车人姓名：";
            // 
            // gbBorrowMSG
            // 
            this.gbBorrowMSG.Controls.Add(this.txtVNNum);
            this.gbBorrowMSG.Controls.Add(this.labNightCost);
            this.gbBorrowMSG.Controls.Add(this.txtBorrowTime);
            this.gbBorrowMSG.Controls.Add(this.txtMark);
            this.gbBorrowMSG.Controls.Add(this.txtBorrowKind);
            this.gbBorrowMSG.Controls.Add(this.lbMark);
            this.gbBorrowMSG.Controls.Add(this.lbBorrowNum);
            this.gbBorrowMSG.Controls.Add(this.lbBorrowKind);
            this.gbBorrowMSG.Controls.Add(this.lbBorrowTime);
            this.gbBorrowMSG.Location = new System.Drawing.Point(0, 219);
            this.gbBorrowMSG.Name = "gbBorrowMSG";
            this.gbBorrowMSG.Size = new System.Drawing.Size(783, 100);
            this.gbBorrowMSG.TabIndex = 2;
            this.gbBorrowMSG.TabStop = false;
            this.gbBorrowMSG.Text = "租车信息";
            // 
            // txtVNNum
            // 
            this.txtVNNum.AutoSize = true;
            this.txtVNNum.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtVNNum.ForeColor = System.Drawing.Color.Red;
            this.txtVNNum.Location = new System.Drawing.Point(145, 46);
            this.txtVNNum.Name = "txtVNNum";
            this.txtVNNum.Size = new System.Drawing.Size(55, 14);
            this.txtVNNum.TabIndex = 11;
            this.txtVNNum.Text = "label9";
            // 
            // labNightCost
            // 
            this.labNightCost.AutoSize = true;
            this.labNightCost.ForeColor = System.Drawing.Color.Red;
            this.labNightCost.Location = new System.Drawing.Point(392, 48);
            this.labNightCost.Name = "labNightCost";
            this.labNightCost.Size = new System.Drawing.Size(0, 12);
            this.labNightCost.TabIndex = 10;
            // 
            // txtBorrowTime
            // 
            this.txtBorrowTime.Location = new System.Drawing.Point(146, 13);
            this.txtBorrowTime.Name = "txtBorrowTime";
            this.txtBorrowTime.ReadOnly = true;
            this.txtBorrowTime.Size = new System.Drawing.Size(161, 21);
            this.txtBorrowTime.TabIndex = 9;
            // 
            // txtMark
            // 
            this.txtMark.Location = new System.Drawing.Point(146, 70);
            this.txtMark.Name = "txtMark";
            this.txtMark.ReadOnly = true;
            this.txtMark.Size = new System.Drawing.Size(409, 21);
            this.txtMark.TabIndex = 8;
            // 
            // txtBorrowKind
            // 
            this.txtBorrowKind.Location = new System.Drawing.Point(394, 10);
            this.txtBorrowKind.Name = "txtBorrowKind";
            this.txtBorrowKind.ReadOnly = true;
            this.txtBorrowKind.Size = new System.Drawing.Size(161, 21);
            this.txtBorrowKind.TabIndex = 5;
            // 
            // lbMark
            // 
            this.lbMark.AutoSize = true;
            this.lbMark.Location = new System.Drawing.Point(107, 74);
            this.lbMark.Name = "lbMark";
            this.lbMark.Size = new System.Drawing.Size(41, 12);
            this.lbMark.TabIndex = 4;
            this.lbMark.Text = "备注：";
            this.lbMark.Click += new System.EventHandler(this.lbMark_Click);
            // 
            // lbBorrowNum
            // 
            this.lbBorrowNum.AutoSize = true;
            this.lbBorrowNum.Location = new System.Drawing.Point(83, 46);
            this.lbBorrowNum.Name = "lbBorrowNum";
            this.lbBorrowNum.Size = new System.Drawing.Size(65, 12);
            this.lbBorrowNum.TabIndex = 2;
            this.lbBorrowNum.Text = "租车辆数：";
            // 
            // lbBorrowKind
            // 
            this.lbBorrowKind.AutoSize = true;
            this.lbBorrowKind.Location = new System.Drawing.Point(330, 14);
            this.lbBorrowKind.Name = "lbBorrowKind";
            this.lbBorrowKind.Size = new System.Drawing.Size(65, 12);
            this.lbBorrowKind.TabIndex = 1;
            this.lbBorrowKind.Text = "租车类型：";
            // 
            // lbBorrowTime
            // 
            this.lbBorrowTime.AutoSize = true;
            this.lbBorrowTime.Location = new System.Drawing.Point(83, 17);
            this.lbBorrowTime.Name = "lbBorrowTime";
            this.lbBorrowTime.Size = new System.Drawing.Size(65, 12);
            this.lbBorrowTime.TabIndex = 0;
            this.lbBorrowTime.Text = "租车时间：";
            // 
            // gbReturn
            // 
            this.gbReturn.Controls.Add(this.txtCost);
            this.gbReturn.Controls.Add(this.txtBBKTime);
            this.gbReturn.Controls.Add(this.lbReturnNum);
            this.gbReturn.Controls.Add(this.txtReturnNum);
            this.gbReturn.Controls.Add(this.lbBBKTime);
            this.gbReturn.Controls.Add(this.lbCost);
            this.gbReturn.Location = new System.Drawing.Point(0, 325);
            this.gbReturn.Name = "gbReturn";
            this.gbReturn.Size = new System.Drawing.Size(783, 83);
            this.gbReturn.TabIndex = 3;
            this.gbReturn.TabStop = false;
            this.gbReturn.Text = "还车信息";
            // 
            // txtCost
            // 
            this.txtCost.AutoSize = true;
            this.txtCost.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtCost.ForeColor = System.Drawing.Color.Red;
            this.txtCost.Location = new System.Drawing.Point(391, 49);
            this.txtCost.Name = "txtCost";
            this.txtCost.Size = new System.Drawing.Size(17, 16);
            this.txtCost.TabIndex = 9;
            this.txtCost.Text = "0";
            // 
            // txtBBKTime
            // 
            this.txtBBKTime.AutoSize = true;
            this.txtBBKTime.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtBBKTime.ForeColor = System.Drawing.Color.Red;
            this.txtBBKTime.Location = new System.Drawing.Point(146, 52);
            this.txtBBKTime.Name = "txtBBKTime";
            this.txtBBKTime.Size = new System.Drawing.Size(17, 16);
            this.txtBBKTime.TabIndex = 8;
            this.txtBBKTime.Text = "0";
            // 
            // lbReturnNum
            // 
            this.lbReturnNum.AutoSize = true;
            this.lbReturnNum.Location = new System.Drawing.Point(83, 26);
            this.lbReturnNum.Name = "lbReturnNum";
            this.lbReturnNum.Size = new System.Drawing.Size(65, 12);
            this.lbReturnNum.TabIndex = 0;
            this.lbReturnNum.Text = "还车数目：";
            // 
            // txtReturnNum
            // 
            this.txtReturnNum.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtReturnNum.ForeColor = System.Drawing.Color.Red;
            this.txtReturnNum.Location = new System.Drawing.Point(146, 17);
            this.txtReturnNum.Name = "txtReturnNum";
            this.txtReturnNum.Size = new System.Drawing.Size(161, 26);
            this.txtReturnNum.TabIndex = 6;
            this.txtReturnNum.Text = "1";
            // 
            // lbBBKTime
            // 
            this.lbBBKTime.AutoSize = true;
            this.lbBBKTime.Location = new System.Drawing.Point(83, 53);
            this.lbBBKTime.Name = "lbBBKTime";
            this.lbBBKTime.Size = new System.Drawing.Size(65, 12);
            this.lbBBKTime.TabIndex = 3;
            this.lbBBKTime.Text = "租车时间：";
            // 
            // lbCost
            // 
            this.lbCost.AutoSize = true;
            this.lbCost.Location = new System.Drawing.Point(330, 53);
            this.lbCost.Name = "lbCost";
            this.lbCost.Size = new System.Drawing.Size(65, 12);
            this.lbCost.TabIndex = 4;
            this.lbCost.Text = "租车花费：";
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(265, 448);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 4;
            this.btnOK.Text = "确  认";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancle
            // 
            this.btnCancle.Location = new System.Drawing.Point(440, 448);
            this.btnCancle.Name = "btnCancle";
            this.btnCancle.Size = new System.Drawing.Size(75, 23);
            this.btnCancle.TabIndex = 5;
            this.btnCancle.Text = "取  消";
            this.btnCancle.UseVisualStyleBackColor = true;
            this.btnCancle.Click += new System.EventHandler(this.btnCancle_Click);
            // 
            // epMessage
            // 
            this.epMessage.ContainerControl = this;
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
            this.panel2.Size = new System.Drawing.Size(784, 41);
            this.panel2.TabIndex = 41;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(292, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(199, 20);
            this.label1.TabIndex = 7;
            this.label1.Text = "————非会员还车————";
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
            this.panel1.Size = new System.Drawing.Size(784, 25);
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
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(120, 441);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(580, 95);
            this.pictureBox1.TabIndex = 42;
            this.pictureBox1.TabStop = false;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // VipNoReturnWindow
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnCancle);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.gbReturn);
            this.Controls.Add(this.gbBorrowMSG);
            this.Controls.Add(this.gbVN);
            this.Controls.Add(this.gbVipNo);
            this.Controls.Add(this.pictureBox1);
            this.MinimizeBox = false;
            this.Name = "VipNoReturnWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "非会员还车";
            this.Load += new System.EventHandler(this.VipNoReturnWindow_Load);
            this.gbVipNo.ResumeLayout(false);
            this.gbVipNo.PerformLayout();
            this.gbVN.ResumeLayout(false);
            this.gbVN.PerformLayout();
            this.gbBorrowMSG.ResumeLayout(false);
            this.gbBorrowMSG.PerformLayout();
            this.gbReturn.ResumeLayout(false);
            this.gbReturn.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.epMessage)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbVipNo;
        private System.Windows.Forms.TextBox txtVipNoNumber;
        private System.Windows.Forms.TextBox txtVipNoId;
        private System.Windows.Forms.Label lbVipNoNumber;
        private System.Windows.Forms.Label lbVipNoId;
        private System.Windows.Forms.GroupBox gbVN;
        private System.Windows.Forms.TextBox txtVNPhone;
        private System.Windows.Forms.Label lbVNCard;
        private System.Windows.Forms.Label lbVNPhone;
        private System.Windows.Forms.Label lbVNName;
        private System.Windows.Forms.ComboBox cmbVNName;
        private System.Windows.Forms.TextBox txtVNCard;
        private System.Windows.Forms.GroupBox gbBorrowMSG;
        private System.Windows.Forms.TextBox txtMark;
        private System.Windows.Forms.TextBox txtBorrowKind;
        private System.Windows.Forms.Label lbMark;
        private System.Windows.Forms.Label lbBorrowNum;
        private System.Windows.Forms.Label lbBorrowKind;
        private System.Windows.Forms.Label lbBorrowTime;
        private System.Windows.Forms.GroupBox gbReturn;
        private System.Windows.Forms.Label lbCost;
        private System.Windows.Forms.Label lbBBKTime;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancle;
        private System.Windows.Forms.TextBox txtBorrowTime;
        private System.Windows.Forms.ErrorProvider epMessage;
        private System.Windows.Forms.Label lbReturnNum;
        private System.Windows.Forms.TextBox txtReturnNum;
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
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Label labNightCost;
        private System.Windows.Forms.Label txtVNNum;
        private System.Windows.Forms.Label txtCost;
        private System.Windows.Forms.Label txtBBKTime;
    }
}