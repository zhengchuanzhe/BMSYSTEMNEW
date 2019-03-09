namespace BMSYSTEM
{
    partial class AddDepartWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddDepartWindow));
            this.lbDPName = new System.Windows.Forms.Label();
            this.lbDPPlace = new System.Windows.Forms.Label();
            this.lbDPPCMAC = new System.Windows.Forms.Label();
            this.txtDPName = new System.Windows.Forms.TextBox();
            this.txtDPPlace = new System.Windows.Forms.TextBox();
            this.txtDPPCMAC = new System.Windows.Forms.TextBox();
            this.epName = new System.Windows.Forms.ErrorProvider(this.components);
            this.epPlace = new System.Windows.Forms.ErrorProvider(this.components);
            this.epMAC = new System.Windows.Forms.ErrorProvider(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnCencelDay = new System.Windows.Forms.Button();
            this.btnOKDay = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.epName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epPlace)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epMAC)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lbDPName
            // 
            this.lbDPName.AutoSize = true;
            this.lbDPName.Location = new System.Drawing.Point(298, 122);
            this.lbDPName.Name = "lbDPName";
            this.lbDPName.Size = new System.Drawing.Size(59, 12);
            this.lbDPName.TabIndex = 0;
            this.lbDPName.Text = "分店名称:";
            // 
            // lbDPPlace
            // 
            this.lbDPPlace.AutoSize = true;
            this.lbDPPlace.Location = new System.Drawing.Point(298, 165);
            this.lbDPPlace.Name = "lbDPPlace";
            this.lbDPPlace.Size = new System.Drawing.Size(59, 12);
            this.lbDPPlace.TabIndex = 1;
            this.lbDPPlace.Text = "分店地址:";
            // 
            // lbDPPCMAC
            // 
            this.lbDPPCMAC.AutoSize = true;
            this.lbDPPCMAC.Location = new System.Drawing.Point(257, 203);
            this.lbDPPCMAC.Name = "lbDPPCMAC";
            this.lbDPPCMAC.Size = new System.Drawing.Size(101, 12);
            this.lbDPPCMAC.TabIndex = 2;
            this.lbDPPCMAC.Text = "分店电脑MAC地址:";
            // 
            // txtDPName
            // 
            this.txtDPName.Location = new System.Drawing.Point(363, 116);
            this.txtDPName.Name = "txtDPName";
            this.txtDPName.Size = new System.Drawing.Size(145, 21);
            this.txtDPName.TabIndex = 3;
            // 
            // txtDPPlace
            // 
            this.txtDPPlace.Location = new System.Drawing.Point(363, 156);
            this.txtDPPlace.Name = "txtDPPlace";
            this.txtDPPlace.Size = new System.Drawing.Size(145, 21);
            this.txtDPPlace.TabIndex = 4;
            // 
            // txtDPPCMAC
            // 
            this.txtDPPCMAC.Location = new System.Drawing.Point(364, 194);
            this.txtDPPCMAC.Name = "txtDPPCMAC";
            this.txtDPPCMAC.Size = new System.Drawing.Size(145, 21);
            this.txtDPPCMAC.TabIndex = 5;
            // 
            // epName
            // 
            this.epName.ContainerControl = this;
            // 
            // epPlace
            // 
            this.epPlace.ContainerControl = this;
            // 
            // epMAC
            // 
            this.epMAC.ContainerControl = this;
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
            this.panel1.TabIndex = 22;
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
            // btnCencelDay
            // 
            this.btnCencelDay.Location = new System.Drawing.Point(435, 287);
            this.btnCencelDay.Name = "btnCencelDay";
            this.btnCencelDay.Size = new System.Drawing.Size(75, 23);
            this.btnCencelDay.TabIndex = 31;
            this.btnCencelDay.Text = "取  消";
            this.btnCencelDay.UseVisualStyleBackColor = true;
            this.btnCencelDay.Click += new System.EventHandler(this.btnCancle_Click);
            // 
            // btnOKDay
            // 
            this.btnOKDay.Location = new System.Drawing.Point(265, 287);
            this.btnOKDay.Name = "btnOKDay";
            this.btnOKDay.Size = new System.Drawing.Size(75, 23);
            this.btnOKDay.TabIndex = 30;
            this.btnOKDay.Text = "确  认";
            this.btnOKDay.UseVisualStyleBackColor = true;
            this.btnOKDay.Click += new System.EventHandler(this.btnEnter_Click);
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
            this.panel2.TabIndex = 32;
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
            this.label1.Text = "————分店信息————";
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
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(108, 440);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(580, 95);
            this.pictureBox1.TabIndex = 33;
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
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(334, 349);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(127, 23);
            this.progressBar1.TabIndex = 42;
            this.progressBar1.Visible = false;
            // 
            // AddDepartWindow
            // 
            this.AcceptButton = this.btnOKDay;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.btnCencelDay);
            this.Controls.Add(this.btnOKDay);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.txtDPName);
            this.Controls.Add(this.lbDPName);
            this.Controls.Add(this.lbDPPlace);
            this.Controls.Add(this.txtDPPCMAC);
            this.Controls.Add(this.txtDPPlace);
            this.Controls.Add(this.lbDPPCMAC);
            this.MaximizeBox = false;
            this.Name = "AddDepartWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "添加分店";
            this.Load += new System.EventHandler(this.AddDepartWindow_Load);
            ((System.ComponentModel.ISupportInitialize)(this.epName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epPlace)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epMAC)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbDPName;
        private System.Windows.Forms.Label lbDPPlace;
        private System.Windows.Forms.Label lbDPPCMAC;
        private System.Windows.Forms.TextBox txtDPName;
        private System.Windows.Forms.TextBox txtDPPlace;
        private System.Windows.Forms.TextBox txtDPPCMAC;
        private System.Windows.Forms.ErrorProvider epName;
        private System.Windows.Forms.ErrorProvider epPlace;
        private System.Windows.Forms.ErrorProvider epMAC;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnCencelDay;
        private System.Windows.Forms.Button btnOKDay;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.ProgressBar progressBar1;
    }
}