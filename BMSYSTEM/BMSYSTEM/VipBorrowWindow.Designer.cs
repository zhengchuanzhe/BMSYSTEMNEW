namespace BMSYSTEM
{
    partial class VipBorrowWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VipBorrowWindow));
            this.lbVIPNum = new System.Windows.Forms.Label();
            this.txtVIPNum = new System.Windows.Forms.TextBox();
            this.lbVipName = new System.Windows.Forms.Label();
            this.txtVipName = new System.Windows.Forms.TextBox();
            this.lbVipLv = new System.Windows.Forms.Label();
            this.lbCard = new System.Windows.Forms.Label();
            this.txtCard = new System.Windows.Forms.TextBox();
            this.txtVipLv = new System.Windows.Forms.TextBox();
            this.lbPhone = new System.Windows.Forms.Label();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.lbBirthday = new System.Windows.Forms.Label();
            this.lbVipCard = new System.Windows.Forms.Label();
            this.txtBirthday = new System.Windows.Forms.TextBox();
            this.txtVipCard = new System.Windows.Forms.TextBox();
            this.lbAddress = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.lbVipDp = new System.Windows.Forms.Label();
            this.txtDp = new System.Windows.Forms.TextBox();
            this.gbVip = new System.Windows.Forms.GroupBox();
            this.btnAddPhoto = new System.Windows.Forms.Button();
            this.txtInte = new System.Windows.Forms.TextBox();
            this.lbInte = new System.Windows.Forms.Label();
            this.txtBalance = new System.Windows.Forms.TextBox();
            this.lbBalance = new System.Windows.Forms.Label();
            this.gbPic = new System.Windows.Forms.GroupBox();
            this.pbVip = new System.Windows.Forms.PictureBox();
            this.gbBbk = new System.Windows.Forms.GroupBox();
            this.btfreshen = new System.Windows.Forms.Button();
            this.txtMark = new System.Windows.Forms.TextBox();
            this.lbMark = new System.Windows.Forms.Label();
            this.txtNum = new System.Windows.Forms.TextBox();
            this.lbNum = new System.Windows.Forms.Label();
            this.cmbKind = new System.Windows.Forms.ComboBox();
            this.lbKind = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCencel = new System.Windows.Forms.Button();
            this.epMessage = new System.Windows.Forms.ErrorProvider(this.components);
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
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
            this.gbVip.SuspendLayout();
            this.gbPic.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbVip)).BeginInit();
            this.gbBbk.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.epMessage)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lbVIPNum
            // 
            this.lbVIPNum.AutoSize = true;
            this.lbVIPNum.Location = new System.Drawing.Point(58, 39);
            this.lbVIPNum.Name = "lbVIPNum";
            this.lbVIPNum.Size = new System.Drawing.Size(59, 12);
            this.lbVIPNum.TabIndex = 0;
            this.lbVIPNum.Text = "会员编号:";
            // 
            // txtVIPNum
            // 
            this.txtVIPNum.Location = new System.Drawing.Point(121, 34);
            this.txtVIPNum.Name = "txtVIPNum";
            this.txtVIPNum.ReadOnly = true;
            this.txtVIPNum.Size = new System.Drawing.Size(100, 21);
            this.txtVIPNum.TabIndex = 1;
            // 
            // lbVipName
            // 
            this.lbVipName.AutoSize = true;
            this.lbVipName.Location = new System.Drawing.Point(58, 71);
            this.lbVipName.Name = "lbVipName";
            this.lbVipName.Size = new System.Drawing.Size(59, 12);
            this.lbVipName.TabIndex = 2;
            this.lbVipName.Text = "会员名称:";
            // 
            // txtVipName
            // 
            this.txtVipName.Location = new System.Drawing.Point(121, 68);
            this.txtVipName.Name = "txtVipName";
            this.txtVipName.ReadOnly = true;
            this.txtVipName.Size = new System.Drawing.Size(100, 21);
            this.txtVipName.TabIndex = 3;
            // 
            // lbVipLv
            // 
            this.lbVipLv.AutoSize = true;
            this.lbVipLv.Location = new System.Drawing.Point(227, 72);
            this.lbVipLv.Name = "lbVipLv";
            this.lbVipLv.Size = new System.Drawing.Size(59, 12);
            this.lbVipLv.TabIndex = 4;
            this.lbVipLv.Text = "会员等级:";
            // 
            // lbCard
            // 
            this.lbCard.AutoSize = true;
            this.lbCard.Location = new System.Drawing.Point(227, 38);
            this.lbCard.Name = "lbCard";
            this.lbCard.Size = new System.Drawing.Size(59, 12);
            this.lbCard.TabIndex = 5;
            this.lbCard.Text = "会员卡号:";
            // 
            // txtCard
            // 
            this.txtCard.Location = new System.Drawing.Point(292, 34);
            this.txtCard.Name = "txtCard";
            this.txtCard.ReadOnly = true;
            this.txtCard.Size = new System.Drawing.Size(100, 21);
            this.txtCard.TabIndex = 6;
            // 
            // txtVipLv
            // 
            this.txtVipLv.Location = new System.Drawing.Point(292, 68);
            this.txtVipLv.Name = "txtVipLv";
            this.txtVipLv.ReadOnly = true;
            this.txtVipLv.Size = new System.Drawing.Size(100, 21);
            this.txtVipLv.TabIndex = 7;
            // 
            // lbPhone
            // 
            this.lbPhone.AutoSize = true;
            this.lbPhone.Location = new System.Drawing.Point(58, 107);
            this.lbPhone.Name = "lbPhone";
            this.lbPhone.Size = new System.Drawing.Size(59, 12);
            this.lbPhone.TabIndex = 8;
            this.lbPhone.Text = "会员电话:";
            // 
            // txtPhone
            // 
            this.txtPhone.Location = new System.Drawing.Point(121, 101);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.ReadOnly = true;
            this.txtPhone.Size = new System.Drawing.Size(100, 21);
            this.txtPhone.TabIndex = 9;
            // 
            // lbBirthday
            // 
            this.lbBirthday.AutoSize = true;
            this.lbBirthday.Location = new System.Drawing.Point(227, 106);
            this.lbBirthday.Name = "lbBirthday";
            this.lbBirthday.Size = new System.Drawing.Size(59, 12);
            this.lbBirthday.TabIndex = 10;
            this.lbBirthday.Text = "会员生日:";
            // 
            // lbVipCard
            // 
            this.lbVipCard.AutoSize = true;
            this.lbVipCard.Location = new System.Drawing.Point(58, 139);
            this.lbVipCard.Name = "lbVipCard";
            this.lbVipCard.Size = new System.Drawing.Size(59, 12);
            this.lbVipCard.TabIndex = 11;
            this.lbVipCard.Text = "身份证号:";
            // 
            // txtBirthday
            // 
            this.txtBirthday.Location = new System.Drawing.Point(292, 101);
            this.txtBirthday.Name = "txtBirthday";
            this.txtBirthday.ReadOnly = true;
            this.txtBirthday.Size = new System.Drawing.Size(100, 21);
            this.txtBirthday.TabIndex = 12;
            // 
            // txtVipCard
            // 
            this.txtVipCard.Location = new System.Drawing.Point(121, 134);
            this.txtVipCard.Name = "txtVipCard";
            this.txtVipCard.ReadOnly = true;
            this.txtVipCard.Size = new System.Drawing.Size(100, 21);
            this.txtVipCard.TabIndex = 13;
            // 
            // lbAddress
            // 
            this.lbAddress.AutoSize = true;
            this.lbAddress.Location = new System.Drawing.Point(68, 203);
            this.lbAddress.Name = "lbAddress";
            this.lbAddress.Size = new System.Drawing.Size(47, 12);
            this.lbAddress.TabIndex = 14;
            this.lbAddress.Text = "现居地:";
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(123, 201);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.ReadOnly = true;
            this.txtAddress.Size = new System.Drawing.Size(269, 21);
            this.txtAddress.TabIndex = 15;
            // 
            // lbVipDp
            // 
            this.lbVipDp.AutoSize = true;
            this.lbVipDp.Location = new System.Drawing.Point(227, 139);
            this.lbVipDp.Name = "lbVipDp";
            this.lbVipDp.Size = new System.Drawing.Size(59, 12);
            this.lbVipDp.TabIndex = 16;
            this.lbVipDp.Text = "所属分店:";
            // 
            // txtDp
            // 
            this.txtDp.Location = new System.Drawing.Point(292, 134);
            this.txtDp.Name = "txtDp";
            this.txtDp.ReadOnly = true;
            this.txtDp.Size = new System.Drawing.Size(100, 21);
            this.txtDp.TabIndex = 17;
            // 
            // gbVip
            // 
            this.gbVip.Controls.Add(this.btnAddPhoto);
            this.gbVip.Controls.Add(this.txtInte);
            this.gbVip.Controls.Add(this.lbInte);
            this.gbVip.Controls.Add(this.txtBalance);
            this.gbVip.Controls.Add(this.lbBalance);
            this.gbVip.Controls.Add(this.gbPic);
            this.gbVip.Controls.Add(this.lbVIPNum);
            this.gbVip.Controls.Add(this.txtDp);
            this.gbVip.Controls.Add(this.txtVIPNum);
            this.gbVip.Controls.Add(this.lbVipDp);
            this.gbVip.Controls.Add(this.lbCard);
            this.gbVip.Controls.Add(this.txtAddress);
            this.gbVip.Controls.Add(this.txtCard);
            this.gbVip.Controls.Add(this.lbAddress);
            this.gbVip.Controls.Add(this.lbVipName);
            this.gbVip.Controls.Add(this.txtVipCard);
            this.gbVip.Controls.Add(this.txtVipName);
            this.gbVip.Controls.Add(this.lbVipCard);
            this.gbVip.Controls.Add(this.txtBirthday);
            this.gbVip.Controls.Add(this.lbVipLv);
            this.gbVip.Controls.Add(this.txtVipLv);
            this.gbVip.Controls.Add(this.lbBirthday);
            this.gbVip.Controls.Add(this.lbPhone);
            this.gbVip.Controls.Add(this.txtPhone);
            this.gbVip.Location = new System.Drawing.Point(0, 47);
            this.gbVip.Name = "gbVip";
            this.gbVip.Size = new System.Drawing.Size(784, 243);
            this.gbVip.TabIndex = 18;
            this.gbVip.TabStop = false;
            this.gbVip.Text = "会员信息";
            // 
            // btnAddPhoto
            // 
            this.btnAddPhoto.Location = new System.Drawing.Point(453, 213);
            this.btnAddPhoto.Name = "btnAddPhoto";
            this.btnAddPhoto.Size = new System.Drawing.Size(75, 23);
            this.btnAddPhoto.TabIndex = 24;
            this.btnAddPhoto.Text = "加载照片";
            this.btnAddPhoto.UseVisualStyleBackColor = true;
            this.btnAddPhoto.Click += new System.EventHandler(this.btnAddPhoto_Click);
            // 
            // txtInte
            // 
            this.txtInte.Location = new System.Drawing.Point(292, 168);
            this.txtInte.Name = "txtInte";
            this.txtInte.ReadOnly = true;
            this.txtInte.Size = new System.Drawing.Size(100, 21);
            this.txtInte.TabIndex = 23;
            // 
            // lbInte
            // 
            this.lbInte.AutoSize = true;
            this.lbInte.Location = new System.Drawing.Point(227, 172);
            this.lbInte.Name = "lbInte";
            this.lbInte.Size = new System.Drawing.Size(59, 12);
            this.lbInte.TabIndex = 22;
            this.lbInte.Text = "会员积分:";
            // 
            // txtBalance
            // 
            this.txtBalance.Location = new System.Drawing.Point(123, 168);
            this.txtBalance.Name = "txtBalance";
            this.txtBalance.ReadOnly = true;
            this.txtBalance.Size = new System.Drawing.Size(100, 21);
            this.txtBalance.TabIndex = 21;
            // 
            // lbBalance
            // 
            this.lbBalance.AutoSize = true;
            this.lbBalance.Location = new System.Drawing.Point(58, 172);
            this.lbBalance.Name = "lbBalance";
            this.lbBalance.Size = new System.Drawing.Size(59, 12);
            this.lbBalance.TabIndex = 20;
            this.lbBalance.Text = "会员余额:";
            // 
            // gbPic
            // 
            this.gbPic.Controls.Add(this.pbVip);
            this.gbPic.Location = new System.Drawing.Point(428, 34);
            this.gbPic.Name = "gbPic";
            this.gbPic.Size = new System.Drawing.Size(132, 172);
            this.gbPic.TabIndex = 19;
            this.gbPic.TabStop = false;
            this.gbPic.Text = "会员照片";
            // 
            // pbVip
            // 
            this.pbVip.BackgroundImage = global::BMSYSTEM.Properties.Resources.未标题_1;
            this.pbVip.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbVip.Location = new System.Drawing.Point(3, 17);
            this.pbVip.Name = "pbVip";
            this.pbVip.Size = new System.Drawing.Size(126, 152);
            this.pbVip.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbVip.TabIndex = 0;
            this.pbVip.TabStop = false;
            // 
            // gbBbk
            // 
            this.gbBbk.Controls.Add(this.btfreshen);
            this.gbBbk.Controls.Add(this.txtMark);
            this.gbBbk.Controls.Add(this.lbMark);
            this.gbBbk.Controls.Add(this.txtNum);
            this.gbBbk.Controls.Add(this.lbNum);
            this.gbBbk.Controls.Add(this.cmbKind);
            this.gbBbk.Controls.Add(this.lbKind);
            this.gbBbk.Location = new System.Drawing.Point(0, 295);
            this.gbBbk.Name = "gbBbk";
            this.gbBbk.Size = new System.Drawing.Size(784, 110);
            this.gbBbk.TabIndex = 19;
            this.gbBbk.TabStop = false;
            this.gbBbk.Text = "租车信息";
            // 
            // btfreshen
            // 
            this.btfreshen.Location = new System.Drawing.Point(445, 30);
            this.btfreshen.Name = "btfreshen";
            this.btfreshen.Size = new System.Drawing.Size(75, 23);
            this.btfreshen.TabIndex = 6;
            this.btfreshen.Text = "刷新";
            this.btfreshen.UseVisualStyleBackColor = true;
            this.btfreshen.Click += new System.EventHandler(this.btfreshen_Click);
            // 
            // txtMark
            // 
            this.txtMark.Location = new System.Drawing.Point(127, 64);
            this.txtMark.Name = "txtMark";
            this.txtMark.Size = new System.Drawing.Size(433, 21);
            this.txtMark.TabIndex = 5;
            // 
            // lbMark
            // 
            this.lbMark.AutoSize = true;
            this.lbMark.Location = new System.Drawing.Point(82, 68);
            this.lbMark.Name = "lbMark";
            this.lbMark.Size = new System.Drawing.Size(35, 12);
            this.lbMark.TabIndex = 4;
            this.lbMark.Text = "备注:";
            // 
            // txtNum
            // 
            this.txtNum.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold);
            this.txtNum.ForeColor = System.Drawing.Color.Red;
            this.txtNum.Location = new System.Drawing.Point(300, 33);
            this.txtNum.Name = "txtNum";
            this.txtNum.Size = new System.Drawing.Size(100, 23);
            this.txtNum.TabIndex = 3;
            this.txtNum.Text = "1";
            // 
            // lbNum
            // 
            this.lbNum.AutoSize = true;
            this.lbNum.Location = new System.Drawing.Point(237, 36);
            this.lbNum.Name = "lbNum";
            this.lbNum.Size = new System.Drawing.Size(59, 12);
            this.lbNum.TabIndex = 2;
            this.lbNum.Text = "租车数量:";
            // 
            // cmbKind
            // 
            this.cmbKind.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbKind.FormattingEnabled = true;
            this.cmbKind.Location = new System.Drawing.Point(124, 32);
            this.cmbKind.Name = "cmbKind";
            this.cmbKind.Size = new System.Drawing.Size(100, 20);
            this.cmbKind.TabIndex = 1;
            // 
            // lbKind
            // 
            this.lbKind.AutoSize = true;
            this.lbKind.Location = new System.Drawing.Point(58, 36);
            this.lbKind.Name = "lbKind";
            this.lbKind.Size = new System.Drawing.Size(59, 12);
            this.lbKind.TabIndex = 0;
            this.lbKind.Text = "租车类别:";
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(264, 428);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 20;
            this.btnOK.Text = "确  认";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCencel
            // 
            this.btnCencel.Location = new System.Drawing.Point(443, 428);
            this.btnCencel.Name = "btnCencel";
            this.btnCencel.Size = new System.Drawing.Size(75, 23);
            this.btnCencel.TabIndex = 21;
            this.btnCencel.Text = "取  消";
            this.btnCencel.UseVisualStyleBackColor = true;
            this.btnCencel.Click += new System.EventHandler(this.btnCencel_Click);
            // 
            // epMessage
            // 
            this.epMessage.ContainerControl = this;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(292, 275);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(100, 23);
            this.progressBar1.TabIndex = 44;
            this.progressBar1.Visible = false;
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
            this.panel2.TabIndex = 38;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(299, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(185, 20);
            this.label1.TabIndex = 7;
            this.label1.Text = "————会员租车————";
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
            this.panel1.TabIndex = 37;
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
            this.pictureBox1.Location = new System.Drawing.Point(105, 440);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(580, 95);
            this.pictureBox1.TabIndex = 39;
            this.pictureBox1.TabStop = false;
            // 
            // VipBorrowWindow
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnCencel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.gbBbk);
            this.Controls.Add(this.gbVip);
            this.Controls.Add(this.pictureBox1);
            this.MaximizeBox = false;
            this.Name = "VipBorrowWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "会员租车";
            this.Load += new System.EventHandler(this.VipBorrowWindow_Load);
            this.gbVip.ResumeLayout(false);
            this.gbVip.PerformLayout();
            this.gbPic.ResumeLayout(false);
            this.gbPic.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbVip)).EndInit();
            this.gbBbk.ResumeLayout(false);
            this.gbBbk.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.epMessage)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbVIPNum;
        private System.Windows.Forms.TextBox txtVIPNum;
        private System.Windows.Forms.Label lbVipName;
        private System.Windows.Forms.TextBox txtVipName;
        private System.Windows.Forms.Label lbVipLv;
        private System.Windows.Forms.Label lbCard;
        private System.Windows.Forms.TextBox txtCard;
        private System.Windows.Forms.TextBox txtVipLv;
        private System.Windows.Forms.Label lbPhone;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.Label lbBirthday;
        private System.Windows.Forms.Label lbVipCard;
        private System.Windows.Forms.TextBox txtBirthday;
        private System.Windows.Forms.TextBox txtVipCard;
        private System.Windows.Forms.Label lbAddress;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label lbVipDp;
        private System.Windows.Forms.TextBox txtDp;
        private System.Windows.Forms.GroupBox gbVip;
        private System.Windows.Forms.GroupBox gbPic;
        private System.Windows.Forms.PictureBox pbVip;
        private System.Windows.Forms.GroupBox gbBbk;
        private System.Windows.Forms.TextBox txtMark;
        private System.Windows.Forms.Label lbMark;
        private System.Windows.Forms.TextBox txtNum;
        private System.Windows.Forms.Label lbNum;
        private System.Windows.Forms.ComboBox cmbKind;
        private System.Windows.Forms.Label lbKind;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCencel;
        private System.Windows.Forms.ErrorProvider epMessage;
        private System.Windows.Forms.TextBox txtBalance;
        private System.Windows.Forms.Label lbBalance;
        private System.Windows.Forms.PictureBox pictureBox1;
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
        private System.Windows.Forms.TextBox txtInte;
        private System.Windows.Forms.Label lbInte;
        private System.Windows.Forms.Button btnAddPhoto;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button btfreshen;
    }
}