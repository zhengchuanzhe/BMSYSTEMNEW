using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using MODEL;
using BIKEBLL;
using System.IO;
using System.Threading;

namespace BMSYSTEM
{
    public partial class ReChargeWindow : Form
    {
        VipBLL vipBLL;
        VIPInfo vipInfo;
        VipLevelBLL vipLVBLL;
        DepartBLL dpBLL;
        VipMoneyBLL moneyBLL;
        VipNoInfo vipNoInfo;
        RechargeInfo rechargeInfo;
        bool dpVipIsFirst = true;
        bool IsAdmin = false;
        int vipId;
        public  double  chargeMoney  { get; set; }

        BackgroundWorker bgWord = new BackgroundWorker();
        BackgroundWorker vipChangeBg = new BackgroundWorker();
        public ReChargeWindow(bool isAdmin)
        {
            InitializeComponent();
            chargeMoney = 0;
            vipBLL = new VipBLL();
            vipInfo = new VIPInfo();
            vipLVBLL = new VipLevelBLL();
            dpBLL = new DepartBLL();
            moneyBLL = new VipMoneyBLL();
            vipNoInfo = new VipNoInfo();
            bgWord.DoWork += new DoWorkEventHandler(bgWord_DoWork);
            bgWord.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bgWord_RunWorkerCompleted);
            bgWord.ProgressChanged += new ProgressChangedEventHandler(bgWord_ProgressChanged);
            bgWord.WorkerReportsProgress = true;
            IsAdmin = isAdmin;
        }
        List<DepartInfo> dpList;
        ////List<VIPInfo> vipList;
        int dpSelectedId = StaticData.departLocal.DpId;
        void bgWord_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }
        #region 绑定分店下拉表
        void bgWord_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            cmbDpVip.DataSource = dpList;
            cmbDpVip.DisplayMember = "DPNAME";
            cmbDpVip.ValueMember = "DPID";
            cmbDpVip.SelectedValue = StaticData.departLocal.DpId;
            dpVipIsFirst = false;
            cmbDpVip.Enabled = false;
            progressBar1.Visible = false;
        }
        #endregion
        void bgWord_DoWork(object sender, DoWorkEventArgs e)
        {
            bgWord.ReportProgress(10);
            //得到分店列表
            dpList = dpBLL.DepartSelect();

            bgWord.ReportProgress(80);

        }
        VIPInfo vipTemp = new VIPInfo();

        #region 填充余额信息
        private void SelectMoneyLeft(int id, bool isVip)
        {
            VipMoney vipMoneyTemp = new VipMoney();
            vipMoneyTemp.VipId = id;
            vipMoneyTemp.IsVip = isVip;
            try
            {
                vipMoneyTemp = moneyBLL.VipMoneySelectByVipId(vipMoneyTemp);
                txtLeft.Text = vipMoneyTemp.VmBalance.ToString();
                txtIntegralLeft.Text = vipMoneyTemp.Integral.ToString();
            }
            catch (Exception ex)
            {
                txtLeft.Text = "";
            }
        }
        #endregion

        #region 按钮事件
        private void btnOKClick(object vipMoney)
        {
            this.BeginInvoke(new Action(() =>
                {
                    RechargeInfo vipMoneyTemp = vipMoney as RechargeInfo;
                    //if (vipMoneyTemp .ID <1)
                    //{
                    //    MessageBox.Show("请查出用户信息");
                    //    return;
                    //}
                    double Integarl = -1;
                    if (txtIntegral.TextLength > 0)
                    {
                        Integarl = double.Parse(txtIntegral.Text.Trim());
                    }
                    bool result = moneyBLL.Recharge(vipMoneyTemp, Integarl);
                    if (result)
                    {
                        LogInfo logInfo = new LogInfo();
                        logInfo.UserId = StaticData.userLocal.UserId;
                        if (Integarl >= 0)
                        {
                            logInfo.Content = "为会员‘" + txtVipName.Text + "'充值" + vipMoneyTemp.ChargeMoney + "元,积分由" + txtIntegralLeft.Text + "更改为" + Integarl.ToString();
                        }
                        logInfo.Content = "为会员‘" + txtVipName.Text + "'充值" + vipMoneyTemp.ChargeMoney + "元";
                        logInfo.LogTime = DateTime.Now;
                        logInfo.DpId = StaticData.departLocal.DpId;
                        bool b = new LogBLL().LogInsert(logInfo);
                        SelectMoneyLeft(vipMoneyTemp.VipId, true);
                        if (int.Parse(txtMoney.Text.Trim()) < 0)
                        {
                            MessageBox.Show("扣费成功!");
                        }
                        else
                        {
                            MessageBox.Show("充值成功!");
                            chargeMoney = vipMoneyTemp.ChargeMoney;
                        }
                        txtMoney.Text = "";
                        txtIntegral.Text = "";
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("系统故障，充值失败!");
                    }
                }));
        }
        private void btnOK_Click(object sender, EventArgs e)
        {
            if (txtVipName.Text == "")
            {
                MessageBox.Show ("请选择会员！");
                return;
            }
            rechargeInfo = new RechargeInfo();
            rechargeInfo.VipId = vipId;
            rechargeInfo.DepartId = StaticData.departLocal.DpId;
            rechargeInfo.UserId = StaticData.userLocal.UserId;
            if (txtMoney.Text.Trim() == "")
            {
                epMessage.SetError(txtMoney, "请输入存入金额");
                return;
            }
            else
            {
                double a = 0;
                if (!double.TryParse(txtMoney.Text.Trim(), out a))
                {
                    epMessage.SetError(txtMoney, "请输入正确金额");
                    return;
                }
                epMessage.SetError(txtMoney, "");
            }
            double money = double.Parse(txtMoney.Text.Trim());
            if (money > 500)
            {
                MessageBox.Show("充值金额不得操作500元");
                return;
            }
            if (txtIntegral.Text.Trim().Length > 0)
            {
                double a = 0;
                if (!double.TryParse(txtIntegral.Text.Trim(), out a))
                {
                    epMessage.SetError(txtIntegral, "请输入正确积分");
                    return;
                }
                if (double.Parse(txtIntegral.Text) < 0)
                {
                    epMessage.SetError(txtIntegral, "请输入正确积分");
                    return;
                }
                epMessage.SetError(txtIntegral, "");
                DialogResult result1 = MessageBox.Show("要修改积分为" + txtIntegral.Text + "?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result1 == DialogResult.No)
                    return;
            }
            if (money < 0)
            {
                CheckPassWord checkPW = new CheckPassWord(vipTemp.VipName, txtMoney.Text, vipTemp.VipPWD);
                checkPW.ShowDialog();
                if (!checkPW.IsTrue)
                {
                    MessageBox.Show("密码错误，无法扣除费用");
                    return;
                }
            }
            else
            {
                DialogResult result = MessageBox.Show("充值" + txtMoney.Text + "元？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.No)
                    return;
            }

            rechargeInfo.ChargeMoney = money;
            rechargeInfo.IsVip = true;
            Thread th = new Thread(new ParameterizedThreadStart(btnOKClick));
            th.IsBackground = true;
            th.Start(rechargeInfo);
        }
        #endregion

        #region 关闭事件
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnVNCancle_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion



        private void ReChargeWindow_Load(object sender, EventArgs e)
        {
            progressBar1.Visible = true;
            bgWord.RunWorkerAsync();
        }
        private void btnVipSearch_Click(object sender, EventArgs e)
        {
            int a = 0;
            if (!int.TryParse (txtCard .Text,out a) )
            {
                MessageBox.Show("请输入正确卡号！");
                return;
            }
            progressBar1.Visible = true;
            btnVipSearch.Enabled = false;
            btnOK.Enabled = false;
            backgroundWorker1.RunWorkerAsync();
            return;

        }


        #region 根据卡号提取会员信息
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            backgroundWorker1.ReportProgress(20);
            vipTemp = vipBLL.VipSelectByCardNumber(txtCard.Text.Trim());
            backgroundWorker1.ReportProgress(70);
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (vipTemp == null)
            {
                MessageBox.Show("无该会员信息！");
            }
            else
            {

                cmbDpVip.SelectedValue = vipTemp.DpId;
                txtAddress.Text = vipTemp.VipAddress;
                txtBirthday.Text = vipTemp.VipBirthDay.ToShortDateString();
                txtCard.Text = vipTemp.VipNumber;
                txtPhone.Text = vipTemp.VipPhone;
                txtVipName.Text = vipTemp.VipName;
                txtVipCard.Text = vipTemp.VipCard;
                txtMark.Text = vipTemp.Mark;
                vipId = vipTemp.VipId;
                int vipLV = vipTemp.VipLevelId;
                VipLevelInfo levelInfo = new VipLevelInfo();
                levelInfo.LvId = vipLV;
                levelInfo = vipLVBLL.VipLevelSelectById(levelInfo);
                txtVipLv.Text = levelInfo.LvName;
                //int dpid = vipTemp.DpId;
                try
                {
                    if (vipTemp.VipPhoto != new Byte[0])
                    {
                        MemoryStream stream = new MemoryStream(vipTemp.VipPhoto, true);
                        stream.Write(vipTemp.VipPhoto, 0, vipTemp.VipPhoto.Length);
                        pbVip.Image = new Bitmap(stream);
                        pbVip.SizeMode = PictureBoxSizeMode.StretchImage;
                    }
                    else
                    {
                        pbVip.Image = null;
                    }

                }
                catch (Exception ex)
                {
                    pbVip.Image = null;
                }
                SelectMoneyLeft(vipId, true);

            }
            progressBar1.Visible = false;
            btnVipSearch.Enabled = true;
            if (!IsAdmin && vipTemp.DpId != StaticData.departLocal.DpId)
            {
                MessageBox.Show("不是该店会员无权充值！");
                btnOK.Enabled = false;
            }
            else
            {
                btnOK.Enabled = true;

            }

        }
        #endregion

        #region 加载照片
        private void btnAddPhoto_Click(object sender, EventArgs e)
        {
            btnAddPhoto.Enabled = false;
            progressBar1.Visible = true;
            backgroundWorker2.RunWorkerAsync();
        }

        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {
            backgroundWorker2.WorkerReportsProgress = true;
            backgroundWorker2.ReportProgress(20);//这里让进度条显示进度
            vipTemp.VipPhoto = vipBLL.VipPhotoSelectById(vipTemp);
            backgroundWorker2.ReportProgress(70);//这里让进度条显示进度
        }

        private void backgroundWorker2_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }

        private void backgroundWorker2_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                MemoryStream stream = new MemoryStream(vipTemp.VipPhoto, true);
                stream.Write(vipTemp.VipPhoto, 0, vipTemp.VipPhoto.Length);
                pbVip.Image = new Bitmap(stream);
                pbVip.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            catch (Exception ex)
            {
                pbVip.Image = null;
            }
            btnAddPhoto.Enabled = true;
            progressBar1.Visible = false;
        }
        
        #endregion

    }
}
