using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MODEL;
using BIKEBLL;
using System.IO;
using System.Threading;


namespace BMSYSTEM
{
    public partial class VipNoCharge : Form
    {
        VipLevelBLL vipLVBLL;
        DepartBLL dpBLL;
        VipMoneyBLL moneyBLL;
        VipNoInfo vipNoInfo;
        VipNoBLL vipNoBLL;
        RechargeInfo rechargeInfo;
        bool dpVipNoIsFirst = true;
        bool IsAdmin = false;
        bool IsCardSelect = false;
        int vipNoId;
        BackgroundWorker bgWord = new BackgroundWorker();
        BackgroundWorker vipNoChangeBg = new BackgroundWorker();
        public VipNoCharge(bool isAdmin)
        {
            InitializeComponent();
            vipLVBLL = new VipLevelBLL();
            dpBLL = new DepartBLL();
            moneyBLL = new VipMoneyBLL();
            vipNoInfo = new VipNoInfo();
            vipNoBLL = new VipNoBLL();
            bgWord.DoWork += new DoWorkEventHandler(bgWord_DoWork);
            bgWord.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bgWord_RunWorkerCompleted);
            bgWord.ProgressChanged += new ProgressChangedEventHandler(bgWord_ProgressChanged);
            bgWord.WorkerReportsProgress = true;
            vipNoChangeBg.DoWork += new DoWorkEventHandler(vipNoChangeBg_DoWork);
            vipNoChangeBg.RunWorkerCompleted += new RunWorkerCompletedEventHandler(vipNoChangeBg_RunWorkerCompleted);
            vipNoChangeBg.ProgressChanged += new ProgressChangedEventHandler(vipNoChangeBg_ProgressChanged);
            vipNoChangeBg.WorkerReportsProgress = true;
            IsAdmin = isAdmin;
        }
        List<DepartInfo> dpList;
        List<VipNoInfo> vipNoList;
        int vipNoDpId = StaticData.departLocal.DpId;
        void bgWord_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar2.Value = e.ProgressPercentage;
        }
        void bgWord_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            #region 绑定分店下拉表
            cmbDpVipNo.DataSource = dpList;
            cmbDpVipNo.DisplayMember = "DPNAME";
            cmbDpVipNo.ValueMember = "DPID";
            cmbDpVipNo.SelectedValue = StaticData.departLocal.DpId;
            dpVipNoIsFirst = false;

            if (!IsAdmin)
            {
                cmbDpVipNo.SelectedValue = StaticData.departLocal.DpId;
                cmbDpVipNo.Enabled = false;
            }
            #endregion

            if (vipNoList != null)
            {
                cmbVipNoId.DataSource = vipNoList;
                cmbVipNoId.DisplayMember = "VipName";
                cmbVipNoId.ValueMember = "VipId";
            }
            progressBar2.Visible = false;
        }
        void bgWord_DoWork(object sender, DoWorkEventArgs e)
        {
            bgWord.ReportProgress(10);
            //得到分店列表
            dpList = dpBLL.DepartSelect();

            bgWord.ReportProgress(30);
            //得到非VIP列表
            vipNoInfo.DpId = vipNoDpId;
            vipNoList = vipNoBLL.VipNoSelectByDPId(vipNoInfo);
            bgWord.ReportProgress(80);

        }
        VipNoInfo vipNoTemp = new VipNoInfo();

        #region 填充余额信息
        private void SelectMoneyLeft(int id, bool isVip)
        {
            VipMoney vipMoneyTemp = new VipMoney();
            vipMoneyTemp.VipId = id;
            vipMoneyTemp.IsVip = isVip;
            try
            {
                vipMoneyTemp = moneyBLL.VipMoneySelectByVipId(vipMoneyTemp);
                txtVipNoMoneyLeft.Text = vipMoneyTemp.VmBalance.ToString();
            }
            catch (Exception ex)
            {
                txtVipNoMoneyLeft.Text = "";
            }
        }
        #endregion

        #region 非会员充值确认按钮点击事件
        private void btnVNOKClick(object vipMoney)
        {
            this.BeginInvoke(new Action(() =>
              {
                  RechargeInfo vipMoneyTemp = vipMoney as RechargeInfo;
                  double Integral = -1;
                  bool result = moneyBLL.Recharge(rechargeInfo,Integral );
                  if (result)
                  {
                      SelectMoneyLeft(vipMoneyTemp.VipId, false);
                      LogInfo logInfo = new LogInfo();
                      logInfo.UserId = StaticData.userLocal.UserId;
                      logInfo.Content = "为非会员'" +cmbVipNoId .SelectedText  + "'充值" + txtVipNoMoney.Text + "元";
                      logInfo.LogTime = DateTime.Now;
                      logInfo.DpId = StaticData.departLocal.DpId;
                      bool b = new LogBLL().LogInsert(logInfo);
                      txtVipNoMoney.Text = "";
                      MessageBox.Show("充值成功!");
                      this.Close();
                  }
                  else
                  {
                      MessageBox.Show("系统故障，充值失败!");
                  }
                  btnVNOK.Enabled = true;
              }));
        }
        private void btnVNOK_Click(object sender, EventArgs e)
        {
            try
            {
                if(txtVipNoCard.Text =="")
                {
                    MessageBox .Show ("请选择非会员");
                    return;
                }
                DialogResult result = MessageBox.Show("充值" + txtVipNoMoney.Text + "元？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.No)
                    return;
                int vipId = Int32.Parse(cmbVipNoId.SelectedValue.ToString());
                rechargeInfo = new RechargeInfo();
                rechargeInfo.VipId = vipId;
                rechargeInfo.DepartId = StaticData.departLocal.DpId;
                rechargeInfo.UserId = StaticData.userLocal.UserId;
                if (txtVipNoMoney.Text.Trim() == "" || txtVipNoMoney.Text.Trim() == null)
                {
                    epMessage.SetError(txtVipNoMoney, "请输入充值金额");
                    btnVNOK.Enabled = false;
                    return;
                }
                double money = double.Parse(txtVipNoMoney.Text.Trim());
                if (money > 5000)
                {
                    MessageBox.Show("充值金额不得超过5000元");
                    btnVNOK.Enabled = false;
                    return;
                }

                btnVNOK.Enabled = false;
                rechargeInfo.ChargeMoney = money;
                rechargeInfo.IsVip = false;

                Thread th = new Thread(new ParameterizedThreadStart(btnVNOKClick));
                th.IsBackground = true;
                th.Start(rechargeInfo);
            }
            catch (Exception)
            {
                MessageBox.Show("充值失败");
            }

        }
        #endregion

        #region 关闭事件
        private void btnVNCancle_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region VIPNo分店下拉列表改变
        private void cmbDpVipNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!dpVipNoIsFirst)
            {
                vipNoDpId = (int)cmbDpVipNo.SelectedValue;
                cmbDpVipNo.Enabled = false;
                progressBar2.Visible = true;
                vipNoChangeBg.RunWorkerAsync();
            }
        }
        void vipNoChangeBg_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar2.Value = e.ProgressPercentage;
        }
        void vipNoChangeBg_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (vipNoList != null)
            {
                cmbVipNoId.DataSource = vipNoList;
                cmbVipNoId.DisplayMember = "VipName";
                cmbVipNoId.ValueMember = "VipId";
                if (vipNoList.Count > 0)
                {
                    cmbVipNoId.SelectedIndex = 0;
                }
                if (IsCardSelect)
                {
                    cmbVipNoId.SelectedValue = vipNoTemp.VipId;
                    IsCardSelect = false;
                } 
                if (cmbVipNoId.SelectedValue != null)
                {
                    vipNoId = (int)cmbVipNoId.SelectedValue;
                }
            }
            cmbDpVipNo.Enabled = true;
            progressBar2.Visible = false;
            if (vipNoList != null && vipNoList.Count != 0)
            {
                btnvipNoSearch.Enabled = true;
            }
        }
        void vipNoChangeBg_DoWork(object sender, DoWorkEventArgs e)
        {
            vipNoChangeBg.ReportProgress(20);
            vipNoInfo.DpId = vipNoDpId;
            vipNoList = vipNoBLL.VipNoSelectByDPId(vipNoInfo);
            vipNoChangeBg.ReportProgress(70);
        }

        #endregion

        private void VipNoCharge_Load(object sender, EventArgs e)
        {
            progressBar2.Visible = true;
            bgWord.RunWorkerAsync();
        }
        private void btnvipNoSearch_Click(object sender, EventArgs e)
        {
            vipNoTemp = null;
            if (!IsCardSelect)
            {
                try
                {
                    vipNoId = (int)cmbVipNoId.SelectedValue;
                }
                catch (Exception)
                {
                    MessageBox.Show("请选择非会员");
                    return;
                }
                IsCardSelect = false;
                vipNoTemp = vipNoList.Find(item => item.VipId == vipNoId);
            }
            else
            {

                string vipNoNumber = txtVipNoNumber.Text.Trim();
                vipNoTemp = vipNoList.Find(item => item.VipNumber == vipNoNumber);
                if (vipNoTemp == null)
                {
                    progressBar2.Visible = true;
                    btnvipNoSearch.Enabled = false;
                    backgroundWorker1.RunWorkerAsync();
                    return;
                }
                cmbVipNoId.SelectedValue = vipNoTemp.VipId;
                IsCardSelect = false;
            }

            if (vipNoTemp == null)
            {
                MessageBox.Show("无该会员信息!");
                return;
            }
            txtVipNoNumber.Text = vipNoTemp.VipNumber;
            txtMark.Text = vipNoTemp.Mark;
            txtVipNoPhone.Text = vipNoTemp.VipPhone;
            txtVipNoCard.Text = vipNoTemp.VipCard;
            txtMark.Text = vipNoTemp.Mark;
            int vipLV = vipNoTemp.LvId;
            VipLevelInfo levelInfo = new VipLevelInfo();
            levelInfo.LvId = vipLV;
            levelInfo = vipLVBLL.VipLevelSelectById(levelInfo);
            txtVipNoLevel.Text = levelInfo.LvName;
            vipNoId = vipNoTemp.VipId;
            SelectMoneyLeft(vipNoId, false);
        }

        private void txtVipNoNumber_Validated(object sender, EventArgs e)
        {
            btnvipNoSearch.Enabled = true;
            IsCardSelect = true;
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            backgroundWorker1.ReportProgress(20);
            vipNoTemp = vipNoBLL.VipNoSelectByVIPNoNumber(txtVipNoNumber.Text.Trim());
            backgroundWorker1.ReportProgress(70);
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar2.Value = e.ProgressPercentage;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (vipNoTemp != null)
            {
                cmbDpVipNo.SelectedValue = vipNoTemp.DpId;
                txtVipNoNumber.Text = vipNoTemp.VipNumber;
                txtVipNoPhone.Text = vipNoTemp.VipPhone;
                txtVipNoCard.Text = vipNoTemp.VipCard;
                txtMark.Text = vipNoTemp.Mark;
                int vipLV = vipNoTemp.LvId;
                VipLevelInfo levelInfo = new VipLevelInfo();
                levelInfo.LvId = vipLV;
                levelInfo = vipLVBLL.VipLevelSelectById(levelInfo);
                txtVipNoLevel.Text = levelInfo.LvName;
                vipNoId = vipNoTemp.VipId;
                SelectMoneyLeft(vipNoId, false);
            }
            else
            {
                MessageBox.Show("无此非会员！");
                IsCardSelect = false;
            }
            progressBar2.Visible = false;
            btnvipNoSearch.Enabled = true;
      
        }

        private void txtVipNoNumber_TextChanged(object sender, EventArgs e)
        {
            btnvipNoSearch.Enabled = true;
        }
    }
}