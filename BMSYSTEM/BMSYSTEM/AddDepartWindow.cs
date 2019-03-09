using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using MODEL;
using BIKEBLL;

namespace BMSYSTEM
{
    public partial class AddDepartWindow : Form
    {
        DepartBLL departBLL;
        DepartInfo depart;
        public AddDepartWindow()
        {
            InitializeComponent();
            depart = new DepartInfo();
        }

        #region 确认按钮点击事件

        private void btnEnter_Click(object sender, EventArgs e)
        {

            if (txtDPName.Text.Trim() == "")
            {
                epName.SetError(txtDPName, "请输入分店名称!");
                return;
            }
            if (txtDPPlace.Text.Trim() == "")
            {
                epPlace.SetError(txtDPPlace, "请输入分店地址!");
                return;
            }
            if (txtDPPCMAC.Text.Trim() == "")
            {
                epMAC.SetError(txtDPPCMAC, "请输入分店电脑物理地址!");
                return;
            }
            progressBar1.Visible = true;
            depart.DpName = txtDPName.Text;
            depart.DpPlace = txtDPPlace.Text;
            depart.DpPCMAC = txtDPPCMAC.Text;
            backgroundWorker1.RunWorkerAsync();

        }
        #endregion

        #region 取消按钮点击事件
        private void btnCancle_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region 窗体加载事件
        private void AddDepartWindow_Load(object sender, EventArgs e)
        {
            departBLL = new DepartBLL();
        }
        #endregion

        bool b1;
        LogInfo logInfo = new LogInfo();
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            backgroundWorker1.ReportProgress(10);//这里让进度条显示进度
            b1 = new DepartBLL().DepartInsert(depart);
            backgroundWorker1.ReportProgress(70);//这里让进度条显示进度
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

            if (b1)
            {
                MessageBox.Show("添加分店成功", "系统提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk);
                logInfo.UserId = StaticData.userLocal.UserId;
                logInfo.Content = "添加了分店，名称为‘" + txtDPName.Text + "'";
                logInfo.LogTime = DateTime.Now;
                logInfo.DpId = StaticData.departLocal.DpId;
                bool b = new LogBLL().LogInsert(logInfo);
                this.Close();
            }
            else
            {
                MessageBox.Show("添加分店失败", "系统提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
            btnOKDay.Enabled = true;
            progressBar1.Visible = false;
        }
    }
}
