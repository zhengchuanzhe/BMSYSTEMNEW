namespace BMSYSTEM
{
    partial class AddVipWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddVipWindow));
            this.lbVipNumber = new System.Windows.Forms.Label();
            this.lbVipLevel = new System.Windows.Forms.Label();
            this.lbVipName = new System.Windows.Forms.Label();
            this.lbVipSex = new System.Windows.Forms.Label();
            this.lbVipPWD = new System.Windows.Forms.Label();
            this.lbVipPWD2 = new System.Windows.Forms.Label();
            this.lbVipPhone = new System.Windows.Forms.Label();
            this.lbVipCard = new System.Windows.Forms.Label();
            this.lbVipAddress = new System.Windows.Forms.Label();
            this.txtNumber = new System.Windows.Forms.TextBox();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtPWD = new System.Windows.Forms.TextBox();
            this.txtPWDConfirm = new System.Windows.Forms.TextBox();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.txtCard = new System.Windows.Forms.TextBox();
            this.cmbSex = new System.Windows.Forms.ComboBox();
            this.picboxPhoto = new System.Windows.Forms.PictureBox();
            this.btnEnter = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnUploadPic = new System.Windows.Forms.Button();
            this.cmbLevel = new System.Windows.Forms.ComboBox();
            this.epName = new System.Windows.Forms.ErrorProvider(this.components);
            this.epPWD = new System.Windows.Forms.ErrorProvider(this.components);
            this.epPWD2 = new System.Windows.Forms.ErrorProvider(this.components);
            this.epPhone = new System.Windows.Forms.ErrorProvider(this.components);
            this.epCard = new System.Windows.Forms.ErrorProvider(this.components);
            this.epAddress = new System.Windows.Forms.ErrorProvider(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
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
            this.gbPic = new System.Windows.Forms.GroupBox();
            this.cameraButton = new System.Windows.Forms.Button();
            this.epLevel = new System.Windows.Forms.ErrorProvider(this.components);
            this.epNumber = new System.Windows.Forms.ErrorProvider(this.components);
            this.epSex = new System.Windows.Forms.ErrorProvider(this.components);
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.txtMoney = new System.Windows.Forms.TextBox();
            this.txtMark = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picboxPhoto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epPWD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epPWD2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epPhone)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epCard)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epAddress)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.gbPic.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.epLevel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epSex)).BeginInit();
            this.SuspendLayout();
            // 
            // lbVipNumber
            // 
            this.lbVipNumber.AutoSize = true;
            this.lbVipNumber.Location = new System.Drawing.Point(215, 87);
            this.lbVipNumber.Name = "lbVipNumber";
            this.lbVipNumber.Size = new System.Drawing.Size(59, 12);
            this.lbVipNumber.TabIndex = 0;
            this.lbVipNumber.Text = "会员卡号:";
            // 
            // lbVipLevel
            // 
            this.lbVipLevel.AutoSize = true;
            this.lbVipLevel.Location = new System.Drawing.Point(215, 115);
            this.lbVipLevel.Name = "lbVipLevel";
            this.lbVipLevel.Size = new System.Drawing.Size(59, 12);
            this.lbVipLevel.TabIndex = 1;
            this.lbVipLevel.Text = "会员等级:";
            // 
            // lbVipName
            // 
            this.lbVipName.AutoSize = true;
            this.lbVipName.Location = new System.Drawing.Point(215, 144);
            this.lbVipName.Name = "lbVipName";
            this.lbVipName.Size = new System.Drawing.Size(59, 12);
            this.lbVipName.TabIndex = 2;
            this.lbVipName.Text = "会员姓名:";
            // 
            // lbVipSex
            // 
            this.lbVipSex.AutoSize = true;
            this.lbVipSex.Location = new System.Drawing.Point(215, 172);
            this.lbVipSex.Name = "lbVipSex";
            this.lbVipSex.Size = new System.Drawing.Size(59, 12);
            this.lbVipSex.TabIndex = 3;
            this.lbVipSex.Text = "性    别:";
            // 
            // lbVipPWD
            // 
            this.lbVipPWD.AutoSize = true;
            this.lbVipPWD.Location = new System.Drawing.Point(215, 204);
            this.lbVipPWD.Name = "lbVipPWD";
            this.lbVipPWD.Size = new System.Drawing.Size(59, 12);
            this.lbVipPWD.TabIndex = 4;
            this.lbVipPWD.Text = "密    码:";
            // 
            // lbVipPWD2
            // 
            this.lbVipPWD2.AutoSize = true;
            this.lbVipPWD2.Location = new System.Drawing.Point(215, 236);
            this.lbVipPWD2.Name = "lbVipPWD2";
            this.lbVipPWD2.Size = new System.Drawing.Size(59, 12);
            this.lbVipPWD2.TabIndex = 5;
            this.lbVipPWD2.Text = "再次输入:";
            // 
            // lbVipPhone
            // 
            this.lbVipPhone.AutoSize = true;
            this.lbVipPhone.Location = new System.Drawing.Point(215, 266);
            this.lbVipPhone.Name = "lbVipPhone";
            this.lbVipPhone.Size = new System.Drawing.Size(59, 12);
            this.lbVipPhone.TabIndex = 6;
            this.lbVipPhone.Text = "联系电话:";
            // 
            // lbVipCard
            // 
            this.lbVipCard.AutoSize = true;
            this.lbVipCard.Location = new System.Drawing.Point(215, 295);
            this.lbVipCard.Name = "lbVipCard";
            this.lbVipCard.Size = new System.Drawing.Size(59, 12);
            this.lbVipCard.TabIndex = 7;
            this.lbVipCard.Text = "身份证号:";
            // 
            // lbVipAddress
            // 
            this.lbVipAddress.AutoSize = true;
            this.lbVipAddress.Location = new System.Drawing.Point(215, 325);
            this.lbVipAddress.Name = "lbVipAddress";
            this.lbVipAddress.Size = new System.Drawing.Size(59, 12);
            this.lbVipAddress.TabIndex = 9;
            this.lbVipAddress.Text = "地    址:";
            // 
            // txtNumber
            // 
            this.txtNumber.Location = new System.Drawing.Point(287, 84);
            this.txtNumber.Name = "txtNumber";
            this.txtNumber.Size = new System.Drawing.Size(144, 21);
            this.txtNumber.TabIndex = 10;
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(287, 322);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(144, 21);
            this.txtAddress.TabIndex = 11;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(287, 141);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(144, 21);
            this.txtName.TabIndex = 12;
            // 
            // txtPWD
            // 
            this.txtPWD.Location = new System.Drawing.Point(287, 201);
            this.txtPWD.Name = "txtPWD";
            this.txtPWD.PasswordChar = '*';
            this.txtPWD.Size = new System.Drawing.Size(144, 21);
            this.txtPWD.TabIndex = 13;
            // 
            // txtPWDConfirm
            // 
            this.txtPWDConfirm.Location = new System.Drawing.Point(287, 232);
            this.txtPWDConfirm.Name = "txtPWDConfirm";
            this.txtPWDConfirm.PasswordChar = '*';
            this.txtPWDConfirm.Size = new System.Drawing.Size(144, 21);
            this.txtPWDConfirm.TabIndex = 14;
            // 
            // txtPhone
            // 
            this.txtPhone.Location = new System.Drawing.Point(287, 263);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(144, 21);
            this.txtPhone.TabIndex = 15;
            // 
            // txtCard
            // 
            this.txtCard.Location = new System.Drawing.Point(287, 292);
            this.txtCard.Name = "txtCard";
            this.txtCard.Size = new System.Drawing.Size(144, 21);
            this.txtCard.TabIndex = 16;
            // 
            // cmbSex
            // 
            this.cmbSex.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSex.FormattingEnabled = true;
            this.cmbSex.Items.AddRange(new object[] {
            "男",
            "女"});
            this.cmbSex.Location = new System.Drawing.Point(287, 171);
            this.cmbSex.Name = "cmbSex";
            this.cmbSex.Size = new System.Drawing.Size(144, 20);
            this.cmbSex.TabIndex = 17;
            // 
            // picboxPhoto
            // 
            this.picboxPhoto.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.picboxPhoto.Location = new System.Drawing.Point(3, 17);
            this.picboxPhoto.Name = "picboxPhoto";
            this.picboxPhoto.Size = new System.Drawing.Size(126, 152);
            this.picboxPhoto.TabIndex = 25;
            this.picboxPhoto.TabStop = false;
            // 
            // btnEnter
            // 
            this.btnEnter.Location = new System.Drawing.Point(275, 425);
            this.btnEnter.Name = "btnEnter";
            this.btnEnter.Size = new System.Drawing.Size(75, 23);
            this.btnEnter.TabIndex = 26;
            this.btnEnter.Text = "确  认";
            this.btnEnter.UseVisualStyleBackColor = true;
            this.btnEnter.Click += new System.EventHandler(this.btnEnter_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(440, 424);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 27;
            this.btnCancel.Text = "取  消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnUploadPic
            // 
            this.btnUploadPic.Location = new System.Drawing.Point(482, 261);
            this.btnUploadPic.Name = "btnUploadPic";
            this.btnUploadPic.Size = new System.Drawing.Size(54, 23);
            this.btnUploadPic.TabIndex = 28;
            this.btnUploadPic.Text = "上传";
            this.btnUploadPic.UseVisualStyleBackColor = true;
            this.btnUploadPic.Click += new System.EventHandler(this.button3_Click);
            // 
            // cmbLevel
            // 
            this.cmbLevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLevel.FormattingEnabled = true;
            this.cmbLevel.Location = new System.Drawing.Point(287, 112);
            this.cmbLevel.Name = "cmbLevel";
            this.cmbLevel.Size = new System.Drawing.Size(144, 20);
            this.cmbLevel.TabIndex = 30;
            // 
            // epName
            // 
            this.epName.ContainerControl = this;
            // 
            // epPWD
            // 
            this.epPWD.ContainerControl = this;
            // 
            // epPWD2
            // 
            this.epPWD2.ContainerControl = this;
            // 
            // epPhone
            // 
            this.epPhone.ContainerControl = this;
            // 
            // epCard
            // 
            this.epCard.ContainerControl = this;
            // 
            // epAddress
            // 
            this.epAddress.ContainerControl = this;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(95, 440);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(580, 95);
            this.pictureBox1.TabIndex = 36;
            this.pictureBox1.TabStop = false;
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
            this.panel2.TabIndex = 35;
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
            this.panel1.Size = new System.Drawing.Size(784, 25);
            this.panel1.TabIndex = 34;
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
            // gbPic
            // 
            this.gbPic.Controls.Add(this.picboxPhoto);
            this.gbPic.Location = new System.Drawing.Point(479, 77);
            this.gbPic.Name = "gbPic";
            this.gbPic.Size = new System.Drawing.Size(132, 172);
            this.gbPic.TabIndex = 31;
            this.gbPic.TabStop = false;
            this.gbPic.Text = "会员照片";
            // 
            // cameraButton
            // 
            this.cameraButton.Location = new System.Drawing.Point(557, 261);
            this.cameraButton.Name = "cameraButton";
            this.cameraButton.Size = new System.Drawing.Size(54, 23);
            this.cameraButton.TabIndex = 37;
            this.cameraButton.Text = "拍照";
            this.cameraButton.UseVisualStyleBackColor = true;
            this.cameraButton.Click += new System.EventHandler(this.cameraButton_Click);
            // 
            // epLevel
            // 
            this.epLevel.ContainerControl = this;
            // 
            // epNumber
            // 
            this.epNumber.ContainerControl = this;
            // 
            // epSex
            // 
            this.epSex.ContainerControl = this;
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
            this.progressBar1.Location = new System.Drawing.Point(326, 255);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(134, 23);
            this.progressBar1.TabIndex = 42;
            this.progressBar1.Visible = false;
            // 
            // txtMoney
            // 
            this.txtMoney.Location = new System.Drawing.Point(287, 350);
            this.txtMoney.Name = "txtMoney";
            this.txtMoney.Size = new System.Drawing.Size(116, 21);
            this.txtMoney.TabIndex = 43;
            // 
            // txtMark
            // 
            this.txtMark.Location = new System.Drawing.Point(287, 377);
            this.txtMark.Name = "txtMark";
            this.txtMark.Size = new System.Drawing.Size(324, 21);
            this.txtMark.TabIndex = 44;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(215, 354);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(59, 12);
            this.label9.TabIndex = 45;
            this.label9.Text = "充    值:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(215, 381);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(59, 12);
            this.label10.TabIndex = 46;
            this.label10.Text = "备    注:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(409, 355);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(17, 12);
            this.label11.TabIndex = 47;
            this.label11.Text = "元";
            // 
            // AddVipWindow
            // 
            this.AcceptButton = this.btnEnter;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtMark);
            this.Controls.Add(this.txtMoney);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.cameraButton);
            this.Controls.Add(this.gbPic);
            this.Controls.Add(this.lbVipNumber);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.cmbLevel);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnEnter);
            this.Controls.Add(this.lbVipLevel);
            this.Controls.Add(this.txtPWD);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lbVipAddress);
            this.Controls.Add(this.txtPWDConfirm);
            this.Controls.Add(this.lbVipName);
            this.Controls.Add(this.txtNumber);
            this.Controls.Add(this.btnUploadPic);
            this.Controls.Add(this.txtPhone);
            this.Controls.Add(this.lbVipSex);
            this.Controls.Add(this.txtCard);
            this.Controls.Add(this.lbVipPWD);
            this.Controls.Add(this.lbVipCard);
            this.Controls.Add(this.lbVipPWD2);
            this.Controls.Add(this.cmbSex);
            this.Controls.Add(this.lbVipPhone);
            this.Controls.Add(this.pictureBox1);
            this.MaximizeBox = false;
            this.Name = "AddVipWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "添加会员";
            this.Load += new System.EventHandler(this.AddVip_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picboxPhoto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epPWD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epPWD2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epPhone)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epCard)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epAddress)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.gbPic.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.epLevel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epSex)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbVipNumber;
        private System.Windows.Forms.Label lbVipLevel;
        private System.Windows.Forms.Label lbVipName;
        private System.Windows.Forms.Label lbVipSex;
        private System.Windows.Forms.Label lbVipPWD;
        private System.Windows.Forms.Label lbVipPWD2;
        private System.Windows.Forms.Label lbVipPhone;
        private System.Windows.Forms.Label lbVipCard;
        private System.Windows.Forms.Label lbVipAddress;
        private System.Windows.Forms.TextBox txtNumber;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtPWD;
        private System.Windows.Forms.TextBox txtPWDConfirm;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.TextBox txtCard;
        private System.Windows.Forms.ComboBox cmbSex;
        private System.Windows.Forms.PictureBox picboxPhoto;
        private System.Windows.Forms.Button btnEnter;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnUploadPic;
        private System.Windows.Forms.ComboBox cmbLevel;
        private System.Windows.Forms.ErrorProvider epName;
        private System.Windows.Forms.ErrorProvider epPWD;
        private System.Windows.Forms.ErrorProvider epPWD2;
        private System.Windows.Forms.ErrorProvider epPhone;
        private System.Windows.Forms.ErrorProvider epCard;
        private System.Windows.Forms.ErrorProvider epAddress;
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
        private System.Windows.Forms.GroupBox gbPic;
        private System.Windows.Forms.Button cameraButton;
        private System.Windows.Forms.ErrorProvider epLevel;
        private System.Windows.Forms.ErrorProvider epNumber;
        private System.Windows.Forms.ErrorProvider epSex;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtMark;
        private System.Windows.Forms.TextBox txtMoney;
    }
}