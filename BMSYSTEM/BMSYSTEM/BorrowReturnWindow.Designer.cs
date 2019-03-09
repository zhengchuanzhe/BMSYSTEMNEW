namespace BMSYSTEM
{
    partial class BorrowReturnWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BorrowReturnWindow));
            this.tbMessage = new System.Windows.Forms.TabControl();
            this.tbBorrow = new System.Windows.Forms.TabPage();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.lvBorrowMessage = new System.Windows.Forms.ListView();
            this.colCard = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colPhone = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colVipLv = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colStartTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colNumber = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colKind = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colIsReturn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colLeftNum = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tpReturn = new System.Windows.Forms.TabPage();
            this.lvReturnMessage = new System.Windows.Forms.ListView();
            this.colRCard = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colRName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colRLv = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colRStartTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colRNumber = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colRKind = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colRReturnTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colRUTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colUCost = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colRDepart = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.dtpEndTime = new System.Windows.Forms.DateTimePicker();
            this.dtpStartTime = new System.Windows.Forms.DateTimePicker();
            this.lbEndTime = new System.Windows.Forms.Label();
            this.lbStartTime = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.cmbDepart = new System.Windows.Forms.ComboBox();
            this.lbDepart = new System.Windows.Forms.Label();
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
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
            this.tbMessage.SuspendLayout();
            this.tbBorrow.SuspendLayout();
            this.tpReturn.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbMessage
            // 
            this.tbMessage.Controls.Add(this.tbBorrow);
            this.tbMessage.Controls.Add(this.tpReturn);
            this.tbMessage.Location = new System.Drawing.Point(0, 79);
            this.tbMessage.Name = "tbMessage";
            this.tbMessage.SelectedIndex = 0;
            this.tbMessage.Size = new System.Drawing.Size(784, 461);
            this.tbMessage.TabIndex = 0;
            this.tbMessage.Selected += new System.Windows.Forms.TabControlEventHandler(this.tbMessage_Selected);
            // 
            // tbBorrow
            // 
            this.tbBorrow.Controls.Add(this.progressBar1);
            this.tbBorrow.Controls.Add(this.lvBorrowMessage);
            this.tbBorrow.Location = new System.Drawing.Point(4, 22);
            this.tbBorrow.Name = "tbBorrow";
            this.tbBorrow.Padding = new System.Windows.Forms.Padding(3);
            this.tbBorrow.Size = new System.Drawing.Size(776, 435);
            this.tbBorrow.TabIndex = 0;
            this.tbBorrow.Text = "已租情况查询";
            this.tbBorrow.UseVisualStyleBackColor = true;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(323, 178);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(157, 23);
            this.progressBar1.TabIndex = 42;
            this.progressBar1.Visible = false;
            // 
            // lvBorrowMessage
            // 
            this.lvBorrowMessage.AllowDrop = true;
            this.lvBorrowMessage.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colCard,
            this.colName,
            this.colPhone,
            this.colVipLv,
            this.colStartTime,
            this.colNumber,
            this.colKind,
            this.colIsReturn,
            this.colLeftNum});
            this.lvBorrowMessage.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.lvBorrowMessage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvBorrowMessage.GridLines = true;
            this.lvBorrowMessage.Location = new System.Drawing.Point(3, 3);
            this.lvBorrowMessage.Name = "lvBorrowMessage";
            this.lvBorrowMessage.Size = new System.Drawing.Size(770, 429);
            this.lvBorrowMessage.TabIndex = 0;
            this.lvBorrowMessage.UseCompatibleStateImageBehavior = false;
            this.lvBorrowMessage.View = System.Windows.Forms.View.Details;
            // 
            // colCard
            // 
            this.colCard.Text = "会员卡号";
            this.colCard.Width = 87;
            // 
            // colName
            // 
            this.colName.Text = "租车人";
            this.colName.Width = 81;
            // 
            // colPhone
            // 
            this.colPhone.Text = "租车人电话";
            this.colPhone.Width = 101;
            // 
            // colVipLv
            // 
            this.colVipLv.Text = "会员等级";
            this.colVipLv.Width = 75;
            // 
            // colStartTime
            // 
            this.colStartTime.Text = "开始时间";
            this.colStartTime.Width = 141;
            // 
            // colNumber
            // 
            this.colNumber.Text = "租车辆数";
            this.colNumber.Width = 67;
            // 
            // colKind
            // 
            this.colKind.Text = "租车类型";
            this.colKind.Width = 76;
            // 
            // colIsReturn
            // 
            this.colIsReturn.Text = "是否已还";
            // 
            // colLeftNum
            // 
            this.colLeftNum.Text = "未还辆数";
            this.colLeftNum.Width = 74;
            // 
            // tpReturn
            // 
            this.tpReturn.Controls.Add(this.lvReturnMessage);
            this.tpReturn.Location = new System.Drawing.Point(4, 22);
            this.tpReturn.Name = "tpReturn";
            this.tpReturn.Padding = new System.Windows.Forms.Padding(3);
            this.tpReturn.Size = new System.Drawing.Size(776, 435);
            this.tpReturn.TabIndex = 1;
            this.tpReturn.Text = "已还情况查询";
            this.tpReturn.UseVisualStyleBackColor = true;
            // 
            // lvReturnMessage
            // 
            this.lvReturnMessage.AllowDrop = true;
            this.lvReturnMessage.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colRCard,
            this.colRName,
            this.colRLv,
            this.colRStartTime,
            this.colRNumber,
            this.colRKind,
            this.colRReturnTime,
            this.colRUTime,
            this.colUCost,
            this.colRDepart});
            this.lvReturnMessage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvReturnMessage.GridLines = true;
            this.lvReturnMessage.Location = new System.Drawing.Point(3, 3);
            this.lvReturnMessage.Name = "lvReturnMessage";
            this.lvReturnMessage.Size = new System.Drawing.Size(770, 429);
            this.lvReturnMessage.TabIndex = 0;
            this.lvReturnMessage.UseCompatibleStateImageBehavior = false;
            this.lvReturnMessage.View = System.Windows.Forms.View.Details;
            // 
            // colRCard
            // 
            this.colRCard.Text = "卡号";
            this.colRCard.Width = 120;
            // 
            // colRName
            // 
            this.colRName.Text = "租车人";
            this.colRName.Width = 120;
            // 
            // colRLv
            // 
            this.colRLv.Text = "会员等级";
            this.colRLv.Width = 120;
            // 
            // colRStartTime
            // 
            this.colRStartTime.Text = "开始时间";
            this.colRStartTime.Width = 120;
            // 
            // colRNumber
            // 
            this.colRNumber.Text = "还车辆数";
            this.colRNumber.Width = 120;
            // 
            // colRKind
            // 
            this.colRKind.Text = "租车类型";
            this.colRKind.Width = 120;
            // 
            // colRReturnTime
            // 
            this.colRReturnTime.Text = "还车时间";
            this.colRReturnTime.Width = 120;
            // 
            // colRUTime
            // 
            this.colRUTime.Text = "租车时间";
            this.colRUTime.Width = 120;
            // 
            // colUCost
            // 
            this.colUCost.Text = "租车花费(元)";
            this.colUCost.Width = 120;
            // 
            // colRDepart
            // 
            this.colRDepart.Text = "还车地";
            this.colRDepart.Width = 120;
            // 
            // dtpEndTime
            // 
            this.dtpEndTime.Location = new System.Drawing.Point(272, 51);
            this.dtpEndTime.Name = "dtpEndTime";
            this.dtpEndTime.Size = new System.Drawing.Size(110, 21);
            this.dtpEndTime.TabIndex = 10;
            // 
            // dtpStartTime
            // 
            this.dtpStartTime.Location = new System.Drawing.Point(77, 51);
            this.dtpStartTime.Name = "dtpStartTime";
            this.dtpStartTime.Size = new System.Drawing.Size(110, 21);
            this.dtpStartTime.TabIndex = 9;
            // 
            // lbEndTime
            // 
            this.lbEndTime.AutoSize = true;
            this.lbEndTime.Location = new System.Drawing.Point(198, 55);
            this.lbEndTime.Name = "lbEndTime";
            this.lbEndTime.Size = new System.Drawing.Size(65, 12);
            this.lbEndTime.TabIndex = 8;
            this.lbEndTime.Text = "结束时间：";
            // 
            // lbStartTime
            // 
            this.lbStartTime.AutoSize = true;
            this.lbStartTime.Location = new System.Drawing.Point(12, 55);
            this.lbStartTime.Name = "lbStartTime";
            this.lbStartTime.Size = new System.Drawing.Size(65, 12);
            this.lbStartTime.TabIndex = 7;
            this.lbStartTime.Text = "起始时间：";
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(609, 51);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "确  认";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // cmbDepart
            // 
            this.cmbDepart.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDepart.FormattingEnabled = true;
            this.cmbDepart.Location = new System.Drawing.Point(460, 51);
            this.cmbDepart.Name = "cmbDepart";
            this.cmbDepart.Size = new System.Drawing.Size(121, 20);
            this.cmbDepart.TabIndex = 0;
            // 
            // lbDepart
            // 
            this.lbDepart.AutoSize = true;
            this.lbDepart.Location = new System.Drawing.Point(395, 55);
            this.lbDepart.Name = "lbDepart";
            this.lbDepart.Size = new System.Drawing.Size(59, 12);
            this.lbDepart.TabIndex = 0;
            this.lbDepart.Text = "选择分店:";
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
            this.label1.Text = "————租还情况————";
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
            // backgroundWorker2
            // 
            this.backgroundWorker2.WorkerReportsProgress = true;
            this.backgroundWorker2.WorkerSupportsCancellation = true;
            this.backgroundWorker2.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker2_DoWork);
            this.backgroundWorker2.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker2_ProgressChanged);
            this.backgroundWorker2.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker2_RunWorkerCompleted);
            // 
            // BorrowReturnWindow
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.dtpEndTime);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.dtpStartTime);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tbMessage);
            this.Controls.Add(this.lbEndTime);
            this.Controls.Add(this.lbStartTime);
            this.Controls.Add(this.lbDepart);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.cmbDepart);
            this.MaximizeBox = false;
            this.Name = "BorrowReturnWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "租还情况查询";
            this.Load += new System.EventHandler(this.BorrowReturnWindow_Load);
            this.tbMessage.ResumeLayout(false);
            this.tbBorrow.ResumeLayout(false);
            this.tpReturn.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tbMessage;
        private System.Windows.Forms.TabPage tbBorrow;
        private System.Windows.Forms.TabPage tpReturn;
        private System.Windows.Forms.ComboBox cmbDepart;
        private System.Windows.Forms.Label lbDepart;
        private System.Windows.Forms.ListView lvReturnMessage;
        private System.Windows.Forms.ListView lvBorrowMessage;
        private System.Windows.Forms.ColumnHeader colCard;
        private System.Windows.Forms.ColumnHeader colName;
        private System.Windows.Forms.ColumnHeader colVipLv;
        private System.Windows.Forms.ColumnHeader colStartTime;
        private System.Windows.Forms.ColumnHeader colNumber;
        private System.Windows.Forms.ColumnHeader colKind;
        private System.Windows.Forms.ColumnHeader colIsReturn;
        private System.Windows.Forms.ColumnHeader colRCard;
        private System.Windows.Forms.ColumnHeader colRName;
        private System.Windows.Forms.ColumnHeader colRLv;
        private System.Windows.Forms.ColumnHeader colRStartTime;
        private System.Windows.Forms.ColumnHeader colRNumber;
        private System.Windows.Forms.ColumnHeader colRKind;
        private System.Windows.Forms.ColumnHeader colRReturnTime;
        private System.Windows.Forms.ColumnHeader colRUTime;
        private System.Windows.Forms.ColumnHeader colUCost;
        private System.Windows.Forms.ColumnHeader colRDepart;
        private System.Windows.Forms.ColumnHeader colPhone;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.ColumnHeader colLeftNum;
        private System.Windows.Forms.DateTimePicker dtpEndTime;
        private System.Windows.Forms.DateTimePicker dtpStartTime;
        private System.Windows.Forms.Label lbEndTime;
        private System.Windows.Forms.Label lbStartTime;
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
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.ComponentModel.BackgroundWorker backgroundWorker2;
    }
}