namespace BMSYSTEM
{
    partial class Camera
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
            this.Buttonphotograpt = new System.Windows.Forms.Button();
            this.combCamera = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.videoSourcePlayer = new AForge.Controls.VideoSourcePlayer();
            this.SuspendLayout();
            // 
            // Buttonphotograpt
            // 
            this.Buttonphotograpt.Location = new System.Drawing.Point(216, 386);
            this.Buttonphotograpt.Name = "Buttonphotograpt";
            this.Buttonphotograpt.Size = new System.Drawing.Size(75, 23);
            this.Buttonphotograpt.TabIndex = 16;
            this.Buttonphotograpt.Text = "拍照";
            this.Buttonphotograpt.UseVisualStyleBackColor = true;
            this.Buttonphotograpt.Click += new System.EventHandler(this.Buttonphotograpt_Click);
            // 
            // combCamera
            // 
            this.combCamera.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combCamera.FormattingEnabled = true;
            this.combCamera.Location = new System.Drawing.Point(236, 27);
            this.combCamera.Name = "combCamera";
            this.combCamera.Size = new System.Drawing.Size(146, 20);
            this.combCamera.TabIndex = 15;
            this.combCamera.SelectedIndexChanged += new System.EventHandler(this.combCamera_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10F);
            this.label1.Location = new System.Drawing.Point(136, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 14);
            this.label1.TabIndex = 14;
            this.label1.Text = "选择摄像头：";
            // 
            // videoSourcePlayer
            // 
            this.videoSourcePlayer.BackColor = System.Drawing.SystemColors.Control;
            this.videoSourcePlayer.Enabled = false;
            this.videoSourcePlayer.Location = new System.Drawing.Point(93, 89);
            this.videoSourcePlayer.Name = "videoSourcePlayer";
            this.videoSourcePlayer.Size = new System.Drawing.Size(370, 254);
            this.videoSourcePlayer.TabIndex = 13;
            this.videoSourcePlayer.Text = "videoSourcePlayer1";
            this.videoSourcePlayer.VideoSource = null;
            // 
            // Camera
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(524, 463);
            this.Controls.Add(this.Buttonphotograpt);
            this.Controls.Add(this.combCamera);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.videoSourcePlayer);
            this.Name = "Camera";
            this.Text = "Camera";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Camera_FormClosing);
            this.Load += new System.EventHandler(this.Camera_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Buttonphotograpt;
        private System.Windows.Forms.ComboBox combCamera;
        private System.Windows.Forms.Label label1;
        private AForge.Controls.VideoSourcePlayer videoSourcePlayer;
    }
}