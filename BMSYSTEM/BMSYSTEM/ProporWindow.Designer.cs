namespace BMSYSTEM
{
    partial class ProporWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProporWindow));
            this.label1 = new System.Windows.Forms.Label();
            this.txtMoney = new System.Windows.Forms.TextBox();
            this.lbMoney = new System.Windows.Forms.Label();
            this.txtInte = new System.Windows.Forms.TextBox();
            this.lbInte = new System.Windows.Forms.Label();
            this.lbTagMoney = new System.Windows.Forms.Label();
            this.lbTagInte = new System.Windows.Forms.Label();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.epMessage = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.epMessage)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(12, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(265, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "————请输入积分产生比例————";
            // 
            // txtMoney
            // 
            this.txtMoney.Location = new System.Drawing.Point(101, 88);
            this.txtMoney.Name = "txtMoney";
            this.txtMoney.Size = new System.Drawing.Size(100, 21);
            this.txtMoney.TabIndex = 7;
            // 
            // lbMoney
            // 
            this.lbMoney.AutoSize = true;
            this.lbMoney.BackColor = System.Drawing.Color.Transparent;
            this.lbMoney.ForeColor = System.Drawing.Color.White;
            this.lbMoney.Location = new System.Drawing.Point(60, 93);
            this.lbMoney.Name = "lbMoney";
            this.lbMoney.Size = new System.Drawing.Size(35, 12);
            this.lbMoney.TabIndex = 6;
            this.lbMoney.Text = "消费:";
            // 
            // txtInte
            // 
            this.txtInte.Location = new System.Drawing.Point(101, 115);
            this.txtInte.Name = "txtInte";
            this.txtInte.ReadOnly = true;
            this.txtInte.Size = new System.Drawing.Size(100, 21);
            this.txtInte.TabIndex = 9;
            this.txtInte.Text = "1";
            // 
            // lbInte
            // 
            this.lbInte.AutoSize = true;
            this.lbInte.BackColor = System.Drawing.Color.Transparent;
            this.lbInte.ForeColor = System.Drawing.Color.White;
            this.lbInte.Location = new System.Drawing.Point(60, 120);
            this.lbInte.Name = "lbInte";
            this.lbInte.Size = new System.Drawing.Size(35, 12);
            this.lbInte.TabIndex = 8;
            this.lbInte.Text = "积分:";
            // 
            // lbTagMoney
            // 
            this.lbTagMoney.AutoSize = true;
            this.lbTagMoney.BackColor = System.Drawing.Color.Transparent;
            this.lbTagMoney.ForeColor = System.Drawing.Color.White;
            this.lbTagMoney.Location = new System.Drawing.Point(207, 93);
            this.lbTagMoney.Name = "lbTagMoney";
            this.lbTagMoney.Size = new System.Drawing.Size(17, 12);
            this.lbTagMoney.TabIndex = 10;
            this.lbTagMoney.Text = "元";
            // 
            // lbTagInte
            // 
            this.lbTagInte.AutoSize = true;
            this.lbTagInte.BackColor = System.Drawing.Color.Transparent;
            this.lbTagInte.ForeColor = System.Drawing.Color.White;
            this.lbTagInte.Location = new System.Drawing.Point(207, 120);
            this.lbTagInte.Name = "lbTagInte";
            this.lbTagInte.Size = new System.Drawing.Size(17, 12);
            this.lbTagInte.TabIndex = 11;
            this.lbTagInte.Text = "个";
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(62, 163);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 12;
            this.btnOk.Text = "确  认";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(149, 163);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 13;
            this.btnCancel.Text = "取  消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // epMessage
            // 
            this.epMessage.ContainerControl = this;
            // 
            // ProporWindow
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.lbTagInte);
            this.Controls.Add(this.lbTagMoney);
            this.Controls.Add(this.txtInte);
            this.Controls.Add(this.lbInte);
            this.Controls.Add(this.txtMoney);
            this.Controls.Add(this.lbMoney);
            this.Controls.Add(this.label1);
            this.Name = "ProporWindow";
            this.Text = "积分管理窗体";
            this.Load += new System.EventHandler(this.ProporWindow_Load);
            ((System.ComponentModel.ISupportInitialize)(this.epMessage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtMoney;
        private System.Windows.Forms.Label lbMoney;
        private System.Windows.Forms.TextBox txtInte;
        private System.Windows.Forms.Label lbInte;
        private System.Windows.Forms.Label lbTagMoney;
        private System.Windows.Forms.Label lbTagInte;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ErrorProvider epMessage;
    }
}