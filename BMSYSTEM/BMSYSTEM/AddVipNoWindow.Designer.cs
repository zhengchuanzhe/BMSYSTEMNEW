namespace BMSYSTEM
{
    partial class AddVipNoWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddVipNoWindow));
            this.lbVipNumber = new System.Windows.Forms.Label();
            this.btnCancle = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.cmbLevel = new System.Windows.Forms.ComboBox();
            this.txtVipNoCard = new System.Windows.Forms.TextBox();
            this.txtVipNoPhone = new System.Windows.Forms.TextBox();
            this.txtVipNoPWD = new System.Windows.Forms.TextBox();
            this.txtVipNoPWD2 = new System.Windows.Forms.TextBox();
            this.txtVipNoName = new System.Windows.Forms.TextBox();
            this.txtVipNoNumber = new System.Windows.Forms.TextBox();
            this.lbVipNoLevel = new System.Windows.Forms.Label();
            this.lbVipNoCard = new System.Windows.Forms.Label();
            this.lbVipNoPhone = new System.Windows.Forms.Label();
            this.lbVipNoPWD2 = new System.Windows.Forms.Label();
            this.lbVipNoPWD = new System.Windows.Forms.Label();
            this.lbVipNoName = new System.Windows.Forms.Label();
            this.epMessage = new System.Windows.Forms.ErrorProvider(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.txtMark = new System.Windows.Forms.Panel();
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
            this.cmbDepart = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtVipNoMark = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.epMessage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.txtMark.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbVipNumber
            // 
            this.lbVipNumber.AutoSize = true;
            this.lbVipNumber.Location = new System.Drawing.Point(289, 83);
            this.lbVipNumber.Name = "lbVipNumber";
            this.lbVipNumber.Size = new System.Drawing.Size(59, 12);
            this.lbVipNumber.TabIndex = 0;
            this.lbVipNumber.Text = "卡    号:";
            // 
            // btnCancle
            // 
            this.btnCancle.Location = new System.Drawing.Point(421, 370);
            this.btnCancle.Name = "btnCancle";
            this.btnCancle.Size = new System.Drawing.Size(75, 23);
            this.btnCancle.TabIndex = 15;
            this.btnCancle.Text = "取  消";
            this.btnCancle.UseVisualStyleBackColor = true;
            this.btnCancle.Click += new System.EventHandler(this.btnCancle_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(277, 370);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 14;
            this.btnOK.Text = "确  认";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // cmbLevel
            // 
            this.cmbLevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLevel.FormattingEnabled = true;
            this.cmbLevel.Location = new System.Drawing.Point(360, 261);
            this.cmbLevel.Name = "cmbLevel";
            this.cmbLevel.Size = new System.Drawing.Size(131, 20);
            this.cmbLevel.TabIndex = 13;
            // 
            // txtVipNoCard
            // 
            this.txtVipNoCard.Location = new System.Drawing.Point(360, 229);
            this.txtVipNoCard.Name = "txtVipNoCard";
            this.txtVipNoCard.Size = new System.Drawing.Size(131, 21);
            this.txtVipNoCard.TabIndex = 12;
            // 
            // txtVipNoPhone
            // 
            this.txtVipNoPhone.Location = new System.Drawing.Point(360, 198);
            this.txtVipNoPhone.Name = "txtVipNoPhone";
            this.txtVipNoPhone.Size = new System.Drawing.Size(131, 21);
            this.txtVipNoPhone.TabIndex = 11;
            // 
            // txtVipNoPWD
            // 
            this.txtVipNoPWD.Location = new System.Drawing.Point(360, 139);
            this.txtVipNoPWD.Name = "txtVipNoPWD";
            this.txtVipNoPWD.PasswordChar = '*';
            this.txtVipNoPWD.Size = new System.Drawing.Size(131, 21);
            this.txtVipNoPWD.TabIndex = 10;
            // 
            // txtVipNoPWD2
            // 
            this.txtVipNoPWD2.Location = new System.Drawing.Point(360, 171);
            this.txtVipNoPWD2.Name = "txtVipNoPWD2";
            this.txtVipNoPWD2.PasswordChar = '*';
            this.txtVipNoPWD2.Size = new System.Drawing.Size(131, 21);
            this.txtVipNoPWD2.TabIndex = 9;
            // 
            // txtVipNoName
            // 
            this.txtVipNoName.Location = new System.Drawing.Point(360, 102);
            this.txtVipNoName.Name = "txtVipNoName";
            this.txtVipNoName.Size = new System.Drawing.Size(131, 21);
            this.txtVipNoName.TabIndex = 8;
            // 
            // txtVipNoNumber
            // 
            this.txtVipNoNumber.Location = new System.Drawing.Point(360, 74);
            this.txtVipNoNumber.Name = "txtVipNoNumber";
            this.txtVipNoNumber.Size = new System.Drawing.Size(131, 21);
            this.txtVipNoNumber.TabIndex = 7;
            // 
            // lbVipNoLevel
            // 
            this.lbVipNoLevel.AutoSize = true;
            this.lbVipNoLevel.Location = new System.Drawing.Point(289, 269);
            this.lbVipNoLevel.Name = "lbVipNoLevel";
            this.lbVipNoLevel.Size = new System.Drawing.Size(59, 12);
            this.lbVipNoLevel.TabIndex = 6;
            this.lbVipNoLevel.Text = "等    级:";
            // 
            // lbVipNoCard
            // 
            this.lbVipNoCard.AutoSize = true;
            this.lbVipNoCard.Location = new System.Drawing.Point(289, 238);
            this.lbVipNoCard.Name = "lbVipNoCard";
            this.lbVipNoCard.Size = new System.Drawing.Size(59, 12);
            this.lbVipNoCard.TabIndex = 5;
            this.lbVipNoCard.Text = "身份证号:";
            // 
            // lbVipNoPhone
            // 
            this.lbVipNoPhone.AutoSize = true;
            this.lbVipNoPhone.Location = new System.Drawing.Point(289, 207);
            this.lbVipNoPhone.Name = "lbVipNoPhone";
            this.lbVipNoPhone.Size = new System.Drawing.Size(59, 12);
            this.lbVipNoPhone.TabIndex = 4;
            this.lbVipNoPhone.Text = "电    话:";
            // 
            // lbVipNoPWD2
            // 
            this.lbVipNoPWD2.AutoSize = true;
            this.lbVipNoPWD2.Location = new System.Drawing.Point(289, 180);
            this.lbVipNoPWD2.Name = "lbVipNoPWD2";
            this.lbVipNoPWD2.Size = new System.Drawing.Size(59, 12);
            this.lbVipNoPWD2.TabIndex = 3;
            this.lbVipNoPWD2.Text = "再次输入:";
            // 
            // lbVipNoPWD
            // 
            this.lbVipNoPWD.AutoSize = true;
            this.lbVipNoPWD.Location = new System.Drawing.Point(289, 148);
            this.lbVipNoPWD.Name = "lbVipNoPWD";
            this.lbVipNoPWD.Size = new System.Drawing.Size(59, 12);
            this.lbVipNoPWD.TabIndex = 2;
            this.lbVipNoPWD.Text = "密    码:";
            // 
            // lbVipNoName
            // 
            this.lbVipNoName.AutoSize = true;
            this.lbVipNoName.Location = new System.Drawing.Point(289, 111);
            this.lbVipNoName.Name = "lbVipNoName";
            this.lbVipNoName.Size = new System.Drawing.Size(59, 12);
            this.lbVipNoName.TabIndex = 1;
            this.lbVipNoName.Text = "姓    名:";
            // 
            // epMessage
            // 
            this.epMessage.ContainerControl = this;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(107, 440);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(580, 95);
            this.pictureBox1.TabIndex = 36;
            this.pictureBox1.TabStop = false;
            // 
            // txtMark
            // 
            this.txtMark.BackColor = System.Drawing.Color.Transparent;
            this.txtMark.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("txtMark.BackgroundImage")));
            this.txtMark.Controls.Add(this.label1);
            this.txtMark.Controls.Add(this.label6);
            this.txtMark.Controls.Add(this.label7);
            this.txtMark.Controls.Add(this.label8);
            this.txtMark.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtMark.ForeColor = System.Drawing.Color.Black;
            this.txtMark.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.txtMark.Location = new System.Drawing.Point(0, 0);
            this.txtMark.Name = "txtMark";
            this.txtMark.Size = new System.Drawing.Size(784, 41);
            this.txtMark.TabIndex = 35;
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
            this.label1.Text = "————非会员信息————";
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
            this.progressBar1.Location = new System.Drawing.Point(342, 212);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(149, 23);
            this.progressBar1.TabIndex = 42;
            this.progressBar1.Visible = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(291, 299);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(59, 12);
            this.label9.TabIndex = 43;
            this.label9.Text = "所属分店:";
            // 
            // cmbDepart
            // 
            this.cmbDepart.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDepart.FormattingEnabled = true;
            this.cmbDepart.Location = new System.Drawing.Point(360, 296);
            this.cmbDepart.Name = "cmbDepart";
            this.cmbDepart.Size = new System.Drawing.Size(131, 20);
            this.cmbDepart.TabIndex = 44;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(200, 333);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(59, 12);
            this.label10.TabIndex = 45;
            this.label10.Text = "备    注:";
            // 
            // txtVipNoMark
            // 
            this.txtVipNoMark.Location = new System.Drawing.Point(262, 329);
            this.txtVipNoMark.Name = "txtVipNoMark";
            this.txtVipNoMark.Size = new System.Drawing.Size(343, 21);
            this.txtVipNoMark.TabIndex = 46;
            // 
            // AddVipNoWindow
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.txtVipNoMark);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.cmbDepart);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.btnCancle);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.txtMark);
            this.Controls.Add(this.cmbLevel);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.txtVipNoCard);
            this.Controls.Add(this.txtVipNoPhone);
            this.Controls.Add(this.txtVipNoNumber);
            this.Controls.Add(this.txtVipNoPWD);
            this.Controls.Add(this.lbVipNumber);
            this.Controls.Add(this.txtVipNoPWD2);
            this.Controls.Add(this.lbVipNoName);
            this.Controls.Add(this.txtVipNoName);
            this.Controls.Add(this.lbVipNoPWD);
            this.Controls.Add(this.lbVipNoPWD2);
            this.Controls.Add(this.lbVipNoLevel);
            this.Controls.Add(this.lbVipNoPhone);
            this.Controls.Add(this.lbVipNoCard);
            this.MaximizeBox = false;
            this.Name = "AddVipNoWindow";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "添加非会员";
            this.Load += new System.EventHandler(this.AddVipNoWindow_Load);
            ((System.ComponentModel.ISupportInitialize)(this.epMessage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.txtMark.ResumeLayout(false);
            this.txtMark.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbVipNumber;
        private System.Windows.Forms.Label lbVipNoLevel;
        private System.Windows.Forms.Label lbVipNoCard;
        private System.Windows.Forms.Label lbVipNoPhone;
        private System.Windows.Forms.Label lbVipNoPWD2;
        private System.Windows.Forms.Label lbVipNoPWD;
        private System.Windows.Forms.Label lbVipNoName;
        private System.Windows.Forms.Button btnCancle;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.ComboBox cmbLevel;
        private System.Windows.Forms.TextBox txtVipNoCard;
        private System.Windows.Forms.TextBox txtVipNoPhone;
        private System.Windows.Forms.TextBox txtVipNoPWD;
        private System.Windows.Forms.TextBox txtVipNoPWD2;
        private System.Windows.Forms.TextBox txtVipNoName;
        private System.Windows.Forms.TextBox txtVipNoNumber;
        private System.Windows.Forms.ErrorProvider epMessage;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel txtMark;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.TextBox txtVipNoMark;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cmbDepart;
        private System.Windows.Forms.Label label9;
    }
}