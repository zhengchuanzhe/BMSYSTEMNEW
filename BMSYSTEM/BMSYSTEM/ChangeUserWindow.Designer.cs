namespace BMSYSTEM
{
    partial class ChangeUserWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChangeUserWindow));
            this.btnUploadPic = new System.Windows.Forms.Button();
            this.gbPic = new System.Windows.Forms.GroupBox();
            this.picUser = new System.Windows.Forms.PictureBox();
            this.cmbDepart = new System.Windows.Forms.ComboBox();
            this.txtCard = new System.Windows.Forms.TextBox();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.txtControlPwd2 = new System.Windows.Forms.TextBox();
            this.txtContorlPwd = new System.Windows.Forms.TextBox();
            this.txtLoginPwd2 = new System.Windows.Forms.TextBox();
            this.txtLoginPwd = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtUserId = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.lbDepart = new System.Windows.Forms.Label();
            this.lbCard = new System.Windows.Forms.Label();
            this.lbPhone = new System.Windows.Forms.Label();
            this.lbControlPwd2 = new System.Windows.Forms.Label();
            this.lbControlPwd = new System.Windows.Forms.Label();
            this.lbLoginPwd2 = new System.Windows.Forms.Label();
            this.lbLoginPwd = new System.Windows.Forms.Label();
            this.lbName = new System.Windows.Forms.Label();
            this.lbId = new System.Windows.Forms.Label();
            this.epName = new System.Windows.Forms.ErrorProvider(this.components);
            this.epLogPwd = new System.Windows.Forms.ErrorProvider(this.components);
            this.epCtlPwd = new System.Windows.Forms.ErrorProvider(this.components);
            this.epPhone = new System.Windows.Forms.ErrorProvider(this.components);
            this.epCard = new System.Windows.Forms.ErrorProvider(this.components);
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
            this.cameraUser = new System.Windows.Forms.Button();
            this.gbPic.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picUser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epLogPwd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epCtlPwd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epPhone)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epCard)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnUploadPic
            // 
            this.btnUploadPic.Location = new System.Drawing.Point(494, 255);
            this.btnUploadPic.Name = "btnUploadPic";
            this.btnUploadPic.Size = new System.Drawing.Size(50, 23);
            this.btnUploadPic.TabIndex = 21;
            this.btnUploadPic.Text = "上传";
            this.btnUploadPic.UseVisualStyleBackColor = true;
            this.btnUploadPic.Click += new System.EventHandler(this.btnUploadPic_Click);
            // 
            // gbPic
            // 
            this.gbPic.Controls.Add(this.picUser);
            this.gbPic.Location = new System.Drawing.Point(494, 81);
            this.gbPic.Name = "gbPic";
            this.gbPic.Size = new System.Drawing.Size(132, 172);
            this.gbPic.TabIndex = 20;
            this.gbPic.TabStop = false;
            this.gbPic.Text = "用户照片";
            // 
            // picUser
            // 
            this.picUser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picUser.Location = new System.Drawing.Point(3, 17);
            this.picUser.Name = "picUser";
            this.picUser.Size = new System.Drawing.Size(126, 152);
            this.picUser.TabIndex = 0;
            this.picUser.TabStop = false;
            // 
            // cmbDepart
            // 
            this.cmbDepart.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDepart.FormattingEnabled = true;
            this.cmbDepart.Location = new System.Drawing.Point(263, 369);
            this.cmbDepart.Name = "cmbDepart";
            this.cmbDepart.Size = new System.Drawing.Size(200, 20);
            this.cmbDepart.TabIndex = 19;
            // 
            // txtCard
            // 
            this.txtCard.Location = new System.Drawing.Point(263, 332);
            this.txtCard.Name = "txtCard";
            this.txtCard.Size = new System.Drawing.Size(200, 21);
            this.txtCard.TabIndex = 18;
            // 
            // txtPhone
            // 
            this.txtPhone.Location = new System.Drawing.Point(263, 293);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(200, 21);
            this.txtPhone.TabIndex = 17;
            // 
            // txtControlPwd2
            // 
            this.txtControlPwd2.Location = new System.Drawing.Point(263, 261);
            this.txtControlPwd2.Name = "txtControlPwd2";
            this.txtControlPwd2.PasswordChar = '*';
            this.txtControlPwd2.Size = new System.Drawing.Size(200, 21);
            this.txtControlPwd2.TabIndex = 16;
            // 
            // txtContorlPwd
            // 
            this.txtContorlPwd.Location = new System.Drawing.Point(263, 226);
            this.txtContorlPwd.Name = "txtContorlPwd";
            this.txtContorlPwd.PasswordChar = '*';
            this.txtContorlPwd.Size = new System.Drawing.Size(200, 21);
            this.txtContorlPwd.TabIndex = 15;
            // 
            // txtLoginPwd2
            // 
            this.txtLoginPwd2.Location = new System.Drawing.Point(263, 191);
            this.txtLoginPwd2.Name = "txtLoginPwd2";
            this.txtLoginPwd2.PasswordChar = '*';
            this.txtLoginPwd2.Size = new System.Drawing.Size(200, 21);
            this.txtLoginPwd2.TabIndex = 14;
            // 
            // txtLoginPwd
            // 
            this.txtLoginPwd.Location = new System.Drawing.Point(263, 154);
            this.txtLoginPwd.Name = "txtLoginPwd";
            this.txtLoginPwd.PasswordChar = '*';
            this.txtLoginPwd.Size = new System.Drawing.Size(200, 21);
            this.txtLoginPwd.TabIndex = 13;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(263, 119);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(200, 21);
            this.txtName.TabIndex = 12;
            // 
            // txtUserId
            // 
            this.txtUserId.Location = new System.Drawing.Point(263, 81);
            this.txtUserId.Name = "txtUserId";
            this.txtUserId.ReadOnly = true;
            this.txtUserId.Size = new System.Drawing.Size(200, 21);
            this.txtUserId.TabIndex = 11;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(454, 429);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 10;
            this.btnCancel.Text = "取  消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(258, 429);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 9;
            this.btnOK.Text = "确  认";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // lbDepart
            // 
            this.lbDepart.AutoSize = true;
            this.lbDepart.Location = new System.Drawing.Point(190, 373);
            this.lbDepart.Name = "lbDepart";
            this.lbDepart.Size = new System.Drawing.Size(59, 12);
            this.lbDepart.TabIndex = 8;
            this.lbDepart.Text = "所属分店:";
            // 
            // lbCard
            // 
            this.lbCard.AutoSize = true;
            this.lbCard.Location = new System.Drawing.Point(188, 337);
            this.lbCard.Name = "lbCard";
            this.lbCard.Size = new System.Drawing.Size(59, 12);
            this.lbCard.TabIndex = 7;
            this.lbCard.Text = "身份证号:";
            // 
            // lbPhone
            // 
            this.lbPhone.AutoSize = true;
            this.lbPhone.Location = new System.Drawing.Point(190, 298);
            this.lbPhone.Name = "lbPhone";
            this.lbPhone.Size = new System.Drawing.Size(59, 12);
            this.lbPhone.TabIndex = 6;
            this.lbPhone.Text = "联系电话:";
            // 
            // lbControlPwd2
            // 
            this.lbControlPwd2.AutoSize = true;
            this.lbControlPwd2.Location = new System.Drawing.Point(164, 266);
            this.lbControlPwd2.Name = "lbControlPwd2";
            this.lbControlPwd2.Size = new System.Drawing.Size(83, 12);
            this.lbControlPwd2.TabIndex = 5;
            this.lbControlPwd2.Text = "确认控制密码:";
            // 
            // lbControlPwd
            // 
            this.lbControlPwd.AutoSize = true;
            this.lbControlPwd.Location = new System.Drawing.Point(188, 231);
            this.lbControlPwd.Name = "lbControlPwd";
            this.lbControlPwd.Size = new System.Drawing.Size(59, 12);
            this.lbControlPwd.TabIndex = 4;
            this.lbControlPwd.Text = "控制密码:";
            // 
            // lbLoginPwd2
            // 
            this.lbLoginPwd2.AutoSize = true;
            this.lbLoginPwd2.Location = new System.Drawing.Point(164, 196);
            this.lbLoginPwd2.Name = "lbLoginPwd2";
            this.lbLoginPwd2.Size = new System.Drawing.Size(83, 12);
            this.lbLoginPwd2.TabIndex = 3;
            this.lbLoginPwd2.Text = "确认登陆密码:";
            // 
            // lbLoginPwd
            // 
            this.lbLoginPwd.AutoSize = true;
            this.lbLoginPwd.Location = new System.Drawing.Point(190, 159);
            this.lbLoginPwd.Name = "lbLoginPwd";
            this.lbLoginPwd.Size = new System.Drawing.Size(59, 12);
            this.lbLoginPwd.TabIndex = 2;
            this.lbLoginPwd.Text = "登陆密码:";
            // 
            // lbName
            // 
            this.lbName.AutoSize = true;
            this.lbName.Location = new System.Drawing.Point(190, 125);
            this.lbName.Name = "lbName";
            this.lbName.Size = new System.Drawing.Size(59, 12);
            this.lbName.TabIndex = 1;
            this.lbName.Text = "用户姓名:";
            // 
            // lbId
            // 
            this.lbId.AutoSize = true;
            this.lbId.Location = new System.Drawing.Point(188, 90);
            this.lbId.Name = "lbId";
            this.lbId.Size = new System.Drawing.Size(59, 12);
            this.lbId.TabIndex = 0;
            this.lbId.Text = "用户编号:";
            // 
            // epName
            // 
            this.epName.ContainerControl = this;
            // 
            // epLogPwd
            // 
            this.epLogPwd.ContainerControl = this;
            // 
            // epCtlPwd
            // 
            this.epCtlPwd.ContainerControl = this;
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
            this.pictureBox1.Location = new System.Drawing.Point(111, 440);
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
            // cameraUser
            // 
            this.cameraUser.Location = new System.Drawing.Point(570, 255);
            this.cameraUser.Name = "cameraUser";
            this.cameraUser.Size = new System.Drawing.Size(50, 23);
            this.cameraUser.TabIndex = 37;
            this.cameraUser.Text = "拍照";
            this.cameraUser.UseVisualStyleBackColor = true;
            this.cameraUser.Click += new System.EventHandler(this.cameraUser_Click);
            // 
            // ChangeUserWindow
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.cameraUser);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnUploadPic);
            this.Controls.Add(this.gbPic);
            this.Controls.Add(this.cmbDepart);
            this.Controls.Add(this.txtCard);
            this.Controls.Add(this.txtPhone);
            this.Controls.Add(this.txtUserId);
            this.Controls.Add(this.txtControlPwd2);
            this.Controls.Add(this.lbId);
            this.Controls.Add(this.txtContorlPwd);
            this.Controls.Add(this.lbName);
            this.Controls.Add(this.txtLoginPwd2);
            this.Controls.Add(this.lbLoginPwd);
            this.Controls.Add(this.txtLoginPwd);
            this.Controls.Add(this.lbLoginPwd2);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lbControlPwd);
            this.Controls.Add(this.lbControlPwd2);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.lbPhone);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.lbCard);
            this.Controls.Add(this.lbDepart);
            this.Controls.Add(this.pictureBox1);
            this.MinimizeBox = false;
            this.Name = "ChangeUserWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "修改用户信息";
            this.Load += new System.EventHandler(this.ChangeUserWindow_Load);
            this.gbPic.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picUser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epLogPwd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epCtlPwd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epPhone)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epCard)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Label lbDepart;
        private System.Windows.Forms.Label lbCard;
        private System.Windows.Forms.Label lbPhone;
        private System.Windows.Forms.Label lbControlPwd2;
        private System.Windows.Forms.Label lbControlPwd;
        private System.Windows.Forms.Label lbLoginPwd2;
        private System.Windows.Forms.Label lbLoginPwd;
        private System.Windows.Forms.Label lbName;
        private System.Windows.Forms.Label lbId;
        private System.Windows.Forms.TextBox txtCard;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.TextBox txtControlPwd2;
        private System.Windows.Forms.TextBox txtContorlPwd;
        private System.Windows.Forms.TextBox txtLoginPwd2;
        private System.Windows.Forms.TextBox txtLoginPwd;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtUserId;
        private System.Windows.Forms.ComboBox cmbDepart;
        private System.Windows.Forms.GroupBox gbPic;
        private System.Windows.Forms.PictureBox picUser;
        private System.Windows.Forms.Button btnUploadPic;
        private System.Windows.Forms.ErrorProvider epName;
        private System.Windows.Forms.ErrorProvider epLogPwd;
        private System.Windows.Forms.ErrorProvider epCtlPwd;
        private System.Windows.Forms.ErrorProvider epPhone;
        private System.Windows.Forms.ErrorProvider epCard;
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
        private System.Windows.Forms.Button cameraUser;
    }
}