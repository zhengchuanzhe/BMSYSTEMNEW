namespace BMSYSTEM
{
    partial class BeforeBorrow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BeforeBorrow));
            this.label1 = new System.Windows.Forms.Label();
            this.txtCard = new System.Windows.Forms.TextBox();
            this.lbPwd = new System.Windows.Forms.Label();
            this.txtPwd = new System.Windows.Forms.TextBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCencel = new System.Windows.Forms.Button();
            this.lbTs = new System.Windows.Forms.Label();
            this.epMessage = new System.Windows.Forms.ErrorProvider(this.components);
            this.LabBorrowOrReturn = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.epMessage)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("宋体", 9F);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(95, 94);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "卡号/姓名：";
            // 
            // txtCard
            // 
            this.txtCard.Location = new System.Drawing.Point(171, 90);
            this.txtCard.Name = "txtCard";
            this.txtCard.Size = new System.Drawing.Size(100, 21);
            this.txtCard.TabIndex = 1;
            // 
            // lbPwd
            // 
            this.lbPwd.AutoSize = true;
            this.lbPwd.BackColor = System.Drawing.Color.Transparent;
            this.lbPwd.Font = new System.Drawing.Font("宋体", 9F);
            this.lbPwd.ForeColor = System.Drawing.Color.White;
            this.lbPwd.Location = new System.Drawing.Point(100, 133);
            this.lbPwd.Name = "lbPwd";
            this.lbPwd.Size = new System.Drawing.Size(65, 12);
            this.lbPwd.TabIndex = 2;
            this.lbPwd.Text = "租车密码：";
            // 
            // txtPwd
            // 
            this.txtPwd.Location = new System.Drawing.Point(171, 128);
            this.txtPwd.Name = "txtPwd";
            this.txtPwd.PasswordChar = '*';
            this.txtPwd.Size = new System.Drawing.Size(100, 21);
            this.txtPwd.TabIndex = 3;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(96, 183);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 4;
            this.btnOK.Text = "确  认";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCencel
            // 
            this.btnCencel.Location = new System.Drawing.Point(220, 183);
            this.btnCencel.Name = "btnCencel";
            this.btnCencel.Size = new System.Drawing.Size(75, 23);
            this.btnCencel.TabIndex = 5;
            this.btnCencel.Text = "取  消";
            this.btnCencel.UseVisualStyleBackColor = true;
            this.btnCencel.Click += new System.EventHandler(this.btnCencel_Click);
            // 
            // lbTs
            // 
            this.lbTs.AutoSize = true;
            this.lbTs.BackColor = System.Drawing.Color.Transparent;
            this.lbTs.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lbTs.ForeColor = System.Drawing.Color.White;
            this.lbTs.Location = new System.Drawing.Point(76, 45);
            this.lbTs.Name = "lbTs";
            this.lbTs.Size = new System.Drawing.Size(217, 20);
            this.lbTs.TabIndex = 6;
            this.lbTs.Text = "————请刷入会员卡————";
            // 
            // epMessage
            // 
            this.epMessage.ContainerControl = this;
            // 
            // LabBorrowOrReturn
            // 
            this.LabBorrowOrReturn.AutoSize = true;
            this.LabBorrowOrReturn.BackColor = System.Drawing.Color.Transparent;
            this.LabBorrowOrReturn.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabBorrowOrReturn.ForeColor = System.Drawing.Color.Red;
            this.LabBorrowOrReturn.Location = new System.Drawing.Point(141, 16);
            this.LabBorrowOrReturn.Name = "LabBorrowOrReturn";
            this.LabBorrowOrReturn.Size = new System.Drawing.Size(54, 25);
            this.LabBorrowOrReturn.TabIndex = 7;
            this.LabBorrowOrReturn.Text = "租车";
            // 
            // BeforeBorrow
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(384, 262);
            this.Controls.Add(this.LabBorrowOrReturn);
            this.Controls.Add(this.lbTs);
            this.Controls.Add(this.btnCencel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.txtPwd);
            this.Controls.Add(this.lbPwd);
            this.Controls.Add(this.txtCard);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.Name = "BeforeBorrow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "刷卡提示";
            this.Load += new System.EventHandler(this.BeforeBorrow_Load);
            ((System.ComponentModel.ISupportInitialize)(this.epMessage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCard;
        private System.Windows.Forms.Label lbPwd;
        private System.Windows.Forms.TextBox txtPwd;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCencel;
        private System.Windows.Forms.Label lbTs;
        private System.Windows.Forms.ErrorProvider epMessage;
        private System.Windows.Forms.Label LabBorrowOrReturn;
    }
}