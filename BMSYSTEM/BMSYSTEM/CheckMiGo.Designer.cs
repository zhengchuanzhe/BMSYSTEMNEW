namespace BMSYSTEM
{
    partial class CheckMiGo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CheckMiGo));
            this.lbMiGo = new System.Windows.Forms.Label();
            this.btnOk = new System.Windows.Forms.Button();
            this.txtMiGo = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.epMessage = new System.Windows.Forms.ErrorProvider(this.components);
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.epMessage)).BeginInit();
            this.SuspendLayout();
            // 
            // lbMiGo
            // 
            this.lbMiGo.AutoSize = true;
            this.lbMiGo.BackColor = System.Drawing.Color.Transparent;
            this.lbMiGo.ForeColor = System.Drawing.Color.White;
            this.lbMiGo.Location = new System.Drawing.Point(115, 102);
            this.lbMiGo.Name = "lbMiGo";
            this.lbMiGo.Size = new System.Drawing.Size(41, 12);
            this.lbMiGo.TabIndex = 0;
            this.lbMiGo.Text = "秘钥：";
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(96, 163);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 1;
            this.btnOk.Text = "确  认";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // txtMiGo
            // 
            this.txtMiGo.Location = new System.Drawing.Point(162, 97);
            this.txtMiGo.Name = "txtMiGo";
            this.txtMiGo.PasswordChar = '*';
            this.txtMiGo.Size = new System.Drawing.Size(118, 21);
            this.txtMiGo.TabIndex = 2;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(221, 163);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "取  消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // epMessage
            // 
            this.epMessage.ContainerControl = this;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(61, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(249, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "————请输入加密狗秘钥————";
            // 
            // CheckMiGo
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(384, 262);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.txtMiGo);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.lbMiGo);
            this.MaximizeBox = false;
            this.Name = "CheckMiGo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "加密狗验证";
            ((System.ComponentModel.ISupportInitialize)(this.epMessage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbMiGo;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.TextBox txtMiGo;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ErrorProvider epMessage;
        private System.Windows.Forms.Label label1;
    }
}