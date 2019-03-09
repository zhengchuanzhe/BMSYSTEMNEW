namespace BMSYSTEM
{
    partial class UserLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserLogin));
            this.lbUserName = new System.Windows.Forms.Label();
            this.lbUserPWD = new System.Windows.Forms.Label();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.txtUserPWD = new System.Windows.Forms.TextBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.epMessage1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.epMessage1)).BeginInit();
            this.SuspendLayout();
            // 
            // lbUserName
            // 
            this.lbUserName.AutoSize = true;
            this.lbUserName.BackColor = System.Drawing.Color.Transparent;
            this.lbUserName.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbUserName.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lbUserName.Location = new System.Drawing.Point(257, 214);
            this.lbUserName.Name = "lbUserName";
            this.lbUserName.Size = new System.Drawing.Size(74, 21);
            this.lbUserName.TabIndex = 0;
            this.lbUserName.Text = "用户名：";
            // 
            // lbUserPWD
            // 
            this.lbUserPWD.AutoSize = true;
            this.lbUserPWD.BackColor = System.Drawing.Color.Transparent;
            this.lbUserPWD.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbUserPWD.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lbUserPWD.Location = new System.Drawing.Point(257, 257);
            this.lbUserPWD.Name = "lbUserPWD";
            this.lbUserPWD.Size = new System.Drawing.Size(73, 21);
            this.lbUserPWD.TabIndex = 1;
            this.lbUserPWD.Text = "密   码：";
            // 
            // txtUserName
            // 
            this.txtUserName.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.txtUserName.Location = new System.Drawing.Point(342, 212);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(196, 25);
            this.txtUserName.TabIndex = 2;
            // 
            // txtUserPWD
            // 
            this.txtUserPWD.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.txtUserPWD.Location = new System.Drawing.Point(342, 254);
            this.txtUserPWD.Name = "txtUserPWD";
            this.txtUserPWD.PasswordChar = '*';
            this.txtUserPWD.Size = new System.Drawing.Size(196, 25);
            this.txtUserPWD.TabIndex = 3;
            // 
            // btnOK
            // 
            this.btnOK.Font = new System.Drawing.Font("宋体", 9.5F);
            this.btnOK.Location = new System.Drawing.Point(299, 305);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 25);
            this.btnOK.TabIndex = 4;
            this.btnOK.Text = "登  录";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            this.btnOK.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.btnOK_KeyPress);
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("宋体", 9.5F);
            this.btnCancel.Location = new System.Drawing.Point(419, 305);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 25);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "取  消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Cursor = System.Windows.Forms.Cursors.Default;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 8F);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.label1.Location = new System.Drawing.Point(247, 542);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(289, 16);
            this.label1.TabIndex = 6;
            this.label1.Text = "©2014 畅达车行 版权所有     技术支持 Dreamtech工作组";
            // 
            // epMessage1
            // 
            this.epMessage1.ContainerControl = this;
            // 
            // UserLogin
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.txtUserPWD);
            this.Controls.Add(this.txtUserName);
            this.Controls.Add(this.lbUserPWD);
            this.Controls.Add(this.lbUserName);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "UserLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "用户登录";
            this.Load += new System.EventHandler(this.UserLogin_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.UserLogin_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.epMessage1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbUserName;
        private System.Windows.Forms.Label lbUserPWD;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.TextBox txtUserPWD;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ErrorProvider epMessage;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ErrorProvider epMessage1;
    }
}