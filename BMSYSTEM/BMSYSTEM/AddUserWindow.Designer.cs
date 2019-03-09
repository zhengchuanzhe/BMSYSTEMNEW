namespace BMSYSTEM
{
    partial class AddUserWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddUserWindow));
            this.lbName = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lbpwd = new System.Windows.Forms.Label();
            this.txtPWD = new System.Windows.Forms.TextBox();
            this.lbpwd2 = new System.Windows.Forms.Label();
            this.txtPWDConfirm = new System.Windows.Forms.TextBox();
            this.lbContpwd = new System.Windows.Forms.Label();
            this.txtPWDControl = new System.Windows.Forms.TextBox();
            this.lbContpwd2 = new System.Windows.Forms.Label();
            this.txtPWDControlConfirm = new System.Windows.Forms.TextBox();
            this.lbphone = new System.Windows.Forms.Label();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.lbCard = new System.Windows.Forms.Label();
            this.txtCard = new System.Windows.Forms.TextBox();
            this.lbdp = new System.Windows.Forms.Label();
            this.cmbDPID = new System.Windows.Forms.ComboBox();
            this.gbPic = new System.Windows.Forms.GroupBox();
            this.addPhoto = new System.Windows.Forms.PictureBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnConcel = new System.Windows.Forms.Button();
            this.btnSelectPic = new System.Windows.Forms.Button();
            this.epName = new System.Windows.Forms.ErrorProvider(this.components);
            this.epLoginPWD = new System.Windows.Forms.ErrorProvider(this.components);
            this.epLoginPWD2 = new System.Windows.Forms.ErrorProvider(this.components);
            this.epControlPWD = new System.Windows.Forms.ErrorProvider(this.components);
            this.epControlPWD2 = new System.Windows.Forms.ErrorProvider(this.components);
            this.epPhone = new System.Windows.Forms.ErrorProvider(this.components);
            this.epCard = new System.Windows.Forms.ErrorProvider(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.cameraUser = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.gbPic.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.addPhoto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epLoginPWD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epLoginPWD2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epControlPWD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epControlPWD2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epPhone)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epCard)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbName
            // 
            this.lbName.AutoSize = true;
            this.lbName.Location = new System.Drawing.Point(214, 113);
            this.lbName.Name = "lbName";
            this.lbName.Size = new System.Drawing.Size(59, 12);
            this.lbName.TabIndex = 0;
            this.lbName.Text = "用户名称:";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(283, 104);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(154, 21);
            this.txtName.TabIndex = 1;
            // 
            // lbpwd
            // 
            this.lbpwd.AutoSize = true;
            this.lbpwd.Location = new System.Drawing.Point(190, 140);
            this.lbpwd.Name = "lbpwd";
            this.lbpwd.Size = new System.Drawing.Size(83, 12);
            this.lbpwd.TabIndex = 2;
            this.lbpwd.Text = "用户登陆密码:";
            // 
            // txtPWD
            // 
            this.txtPWD.Location = new System.Drawing.Point(283, 132);
            this.txtPWD.Name = "txtPWD";
            this.txtPWD.PasswordChar = '*';
            this.txtPWD.Size = new System.Drawing.Size(154, 21);
            this.txtPWD.TabIndex = 3;
            // 
            // lbpwd2
            // 
            this.lbpwd2.AutoSize = true;
            this.lbpwd2.Location = new System.Drawing.Point(190, 170);
            this.lbpwd2.Name = "lbpwd2";
            this.lbpwd2.Size = new System.Drawing.Size(83, 12);
            this.lbpwd2.TabIndex = 4;
            this.lbpwd2.Text = "确认登陆密码:";
            // 
            // txtPWDConfirm
            // 
            this.txtPWDConfirm.Location = new System.Drawing.Point(283, 164);
            this.txtPWDConfirm.Name = "txtPWDConfirm";
            this.txtPWDConfirm.PasswordChar = '*';
            this.txtPWDConfirm.Size = new System.Drawing.Size(154, 21);
            this.txtPWDConfirm.TabIndex = 5;
            // 
            // lbContpwd
            // 
            this.lbContpwd.AutoSize = true;
            this.lbContpwd.Location = new System.Drawing.Point(190, 199);
            this.lbContpwd.Name = "lbContpwd";
            this.lbContpwd.Size = new System.Drawing.Size(83, 12);
            this.lbContpwd.TabIndex = 6;
            this.lbContpwd.Text = "用户控制密码:";
            // 
            // txtPWDControl
            // 
            this.txtPWDControl.Location = new System.Drawing.Point(283, 194);
            this.txtPWDControl.Name = "txtPWDControl";
            this.txtPWDControl.PasswordChar = '*';
            this.txtPWDControl.Size = new System.Drawing.Size(154, 21);
            this.txtPWDControl.TabIndex = 7;
            // 
            // lbContpwd2
            // 
            this.lbContpwd2.AutoSize = true;
            this.lbContpwd2.Location = new System.Drawing.Point(190, 227);
            this.lbContpwd2.Name = "lbContpwd2";
            this.lbContpwd2.Size = new System.Drawing.Size(83, 12);
            this.lbContpwd2.TabIndex = 8;
            this.lbContpwd2.Text = "确认控制密码:";
            // 
            // txtPWDControlConfirm
            // 
            this.txtPWDControlConfirm.Location = new System.Drawing.Point(284, 223);
            this.txtPWDControlConfirm.Name = "txtPWDControlConfirm";
            this.txtPWDControlConfirm.PasswordChar = '*';
            this.txtPWDControlConfirm.Size = new System.Drawing.Size(153, 21);
            this.txtPWDControlConfirm.TabIndex = 9;
            // 
            // lbphone
            // 
            this.lbphone.AutoSize = true;
            this.lbphone.Location = new System.Drawing.Point(214, 255);
            this.lbphone.Name = "lbphone";
            this.lbphone.Size = new System.Drawing.Size(59, 12);
            this.lbphone.TabIndex = 10;
            this.lbphone.Text = "用户电话:";
            // 
            // txtPhone
            // 
            this.txtPhone.Location = new System.Drawing.Point(283, 250);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(154, 21);
            this.txtPhone.TabIndex = 11;
            // 
            // lbCard
            // 
            this.lbCard.AutoSize = true;
            this.lbCard.Location = new System.Drawing.Point(190, 282);
            this.lbCard.Name = "lbCard";
            this.lbCard.Size = new System.Drawing.Size(83, 12);
            this.lbCard.TabIndex = 12;
            this.lbCard.Text = "用户身份证号:";
            // 
            // txtCard
            // 
            this.txtCard.Location = new System.Drawing.Point(284, 279);
            this.txtCard.Name = "txtCard";
            this.txtCard.Size = new System.Drawing.Size(153, 21);
            this.txtCard.TabIndex = 13;
            // 
            // lbdp
            // 
            this.lbdp.AutoSize = true;
            this.lbdp.Location = new System.Drawing.Point(214, 312);
            this.lbdp.Name = "lbdp";
            this.lbdp.Size = new System.Drawing.Size(59, 12);
            this.lbdp.TabIndex = 14;
            this.lbdp.Text = "所属分店:";
            // 
            // cmbDPID
            // 
            this.cmbDPID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDPID.FormattingEnabled = true;
            this.cmbDPID.Location = new System.Drawing.Point(284, 308);
            this.cmbDPID.Name = "cmbDPID";
            this.cmbDPID.Size = new System.Drawing.Size(153, 20);
            this.cmbDPID.TabIndex = 15;
            // 
            // gbPic
            // 
            this.gbPic.Controls.Add(this.addPhoto);
            this.gbPic.Location = new System.Drawing.Point(502, 99);
            this.gbPic.Name = "gbPic";
            this.gbPic.Size = new System.Drawing.Size(132, 172);
            this.gbPic.TabIndex = 16;
            this.gbPic.TabStop = false;
            this.gbPic.Text = "用户照片";
            // 
            // addPhoto
            // 
            this.addPhoto.Dock = System.Windows.Forms.DockStyle.Fill;
            this.addPhoto.Location = new System.Drawing.Point(3, 17);
            this.addPhoto.Name = "addPhoto";
            this.addPhoto.Size = new System.Drawing.Size(126, 152);
            this.addPhoto.TabIndex = 0;
            this.addPhoto.TabStop = false;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(262, 389);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 17;
            this.btnOK.Text = "确  认";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnConcel
            // 
            this.btnConcel.Location = new System.Drawing.Point(440, 389);
            this.btnConcel.Name = "btnConcel";
            this.btnConcel.Size = new System.Drawing.Size(75, 23);
            this.btnConcel.TabIndex = 18;
            this.btnConcel.Text = "取  消";
            this.btnConcel.UseVisualStyleBackColor = true;
            this.btnConcel.Click += new System.EventHandler(this.btnConcel_Click);
            // 
            // btnSelectPic
            // 
            this.btnSelectPic.Location = new System.Drawing.Point(502, 279);
            this.btnSelectPic.Name = "btnSelectPic";
            this.btnSelectPic.Size = new System.Drawing.Size(51, 23);
            this.btnSelectPic.TabIndex = 19;
            this.btnSelectPic.Text = "上传";
            this.btnSelectPic.UseVisualStyleBackColor = true;
            this.btnSelectPic.Click += new System.EventHandler(this.btnSelectPic_Click);
            // 
            // epName
            // 
            this.epName.ContainerControl = this;
            // 
            // epLoginPWD
            // 
            this.epLoginPWD.ContainerControl = this;
            // 
            // epLoginPWD2
            // 
            this.epLoginPWD2.ContainerControl = this;
            // 
            // epControlPWD
            // 
            this.epControlPWD.ContainerControl = this;
            // 
            // epControlPWD2
            // 
            this.epControlPWD2.ContainerControl = this;
            // 
            // epPhone
            // 
            this.epPhone.ContainerControl = this;
            // 
            // epCard
            // 
            this.epCard.ContainerControl = this;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(112, 436);
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
            this.label1.Text = "————用户信息————";
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
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Transparent;
            this.panel3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel3.BackgroundImage")));
            this.panel3.Controls.Add(this.label9);
            this.panel3.Controls.Add(this.label10);
            this.panel3.Controls.Add(this.label11);
            this.panel3.Controls.Add(this.label12);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.ForeColor = System.Drawing.Color.Black;
            this.panel3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.panel3.Location = new System.Drawing.Point(0, 537);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(784, 25);
            this.panel3.TabIndex = 34;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("微软雅黑", 8F);
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(247, 6);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(289, 16);
            this.label9.TabIndex = 7;
            this.label9.Text = "©2014 畅达车行 版权所有     技术支持 Dreamtech工作组";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(591, 10);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(0, 12);
            this.label10.TabIndex = 6;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(84, 72);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(59, 12);
            this.label11.TabIndex = 5;
            this.label11.Text = "123465789";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.ForeColor = System.Drawing.Color.White;
            this.label12.Location = new System.Drawing.Point(18, 72);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(59, 12);
            this.label12.TabIndex = 3;
            this.label12.Text = "店铺电话:";
            // 
            // cameraUser
            // 
            this.cameraUser.Location = new System.Drawing.Point(583, 278);
            this.cameraUser.Name = "cameraUser";
            this.cameraUser.Size = new System.Drawing.Size(51, 23);
            this.cameraUser.TabIndex = 37;
            this.cameraUser.Text = "拍照";
            this.cameraUser.UseVisualStyleBackColor = true;
            this.cameraUser.Click += new System.EventHandler(this.cameraUser_Click);
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
            this.progressBar1.Location = new System.Drawing.Point(345, 250);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(154, 23);
            this.progressBar1.TabIndex = 42;
            this.progressBar1.Visible = false;
            // 
            // AddUserWindow
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.cameraUser);
            this.Controls.Add(this.lbName);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnSelectPic);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.btnConcel);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.lbpwd);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.txtPWD);
            this.Controls.Add(this.lbphone);
            this.Controls.Add(this.gbPic);
            this.Controls.Add(this.txtPWDControlConfirm);
            this.Controls.Add(this.lbpwd2);
            this.Controls.Add(this.txtPhone);
            this.Controls.Add(this.cmbDPID);
            this.Controls.Add(this.lbContpwd2);
            this.Controls.Add(this.txtPWDConfirm);
            this.Controls.Add(this.lbCard);
            this.Controls.Add(this.lbdp);
            this.Controls.Add(this.txtPWDControl);
            this.Controls.Add(this.lbContpwd);
            this.Controls.Add(this.txtCard);
            this.MinimizeBox = false;
            this.Name = "AddUserWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "添加用户";
            this.Load += new System.EventHandler(this.AddUser_Load);
            this.gbPic.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.addPhoto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epLoginPWD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epLoginPWD2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epControlPWD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epControlPWD2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epPhone)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epCard)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lbpwd;
        private System.Windows.Forms.TextBox txtPWD;
        private System.Windows.Forms.Label lbpwd2;
        private System.Windows.Forms.TextBox txtPWDConfirm;
        private System.Windows.Forms.Label lbContpwd;
        private System.Windows.Forms.TextBox txtPWDControl;
        private System.Windows.Forms.Label lbContpwd2;
        private System.Windows.Forms.TextBox txtPWDControlConfirm;
        private System.Windows.Forms.Label lbphone;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.Label lbCard;
        private System.Windows.Forms.TextBox txtCard;
        private System.Windows.Forms.Label lbdp;
        private System.Windows.Forms.ComboBox cmbDPID;
        private System.Windows.Forms.GroupBox gbPic;
        private System.Windows.Forms.PictureBox addPhoto;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnConcel;
        private System.Windows.Forms.Button btnSelectPic;
        private System.Windows.Forms.ErrorProvider epName;
        private System.Windows.Forms.ErrorProvider epLoginPWD;
        private System.Windows.Forms.ErrorProvider epLoginPWD2;
        private System.Windows.Forms.ErrorProvider epControlPWD;
        private System.Windows.Forms.ErrorProvider epControlPWD2;
        private System.Windows.Forms.ErrorProvider epPhone;
        private System.Windows.Forms.ErrorProvider epCard;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button cameraUser;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.ProgressBar progressBar1;
    }
}