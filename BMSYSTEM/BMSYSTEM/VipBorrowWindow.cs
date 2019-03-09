using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using MODEL;
using BIKEBLL;
using System.IO;
using System.Threading;

namespace BMSYSTEM
{
    public partial class VipBorrowWindow : Form
    {
        VIPInfo vipInfo;
        VipBLL vipBLL;
        VipLevelBLL vipLVBLL;
        DepartBLL dpBLL;
        BorrowKindBLL borrowKindBLL;
        VipBorrowBLL vipBorrowBLL;
        VipMoneyBLL vipMoneyBLL;

        public VipBorrowWindow(int id)
        {
            InitializeComponent();
            vipInfo = new VIPInfo();
            borrowKindBLL = new BorrowKindBLL();
            vipBorrowBLL = new VipBorrowBLL();
            vipBLL = new VipBLL();
            dpBLL = new DepartBLL();
            vipInfo.VipId = id;
            vipLVBLL = new VipLevelBLL();
            vipMoneyBLL = new VipMoneyBLL();

        }
        #region 绑定
        private void Bingding()
        {
            this.Invoke(new Action(() =>
            {
                FillVipMessage();
                FillBorrowKind();
            }));
        }
        private void FillBorrowKind()
        {
            List<BorrowKind> borrowKindList = borrowKindBLL.BorrowKindSelect();
            cmbKind.DataSource = borrowKindList;
            cmbKind.DisplayMember = "BBKNAME";
            cmbKind.ValueMember = "BKID";
        }
        private void FillVipMessage()
        {

            VIPInfo vipTemp = new VIPInfo();
            VipMoney moneyTemp = new VipMoney();
            moneyTemp.VipId = vipInfo.VipId;
            moneyTemp.IsVip = true;
            try
            {
                moneyTemp = vipMoneyBLL.VipMoneySelectByVipId(moneyTemp);
                if (moneyTemp != null)
                {
                    txtInte.Text = moneyTemp.Integral.ToString();
                    txtBalance.Text = moneyTemp.VmBalance.ToString();
                }
                vipTemp = vipBLL.VipSelectById(vipInfo);
                txtAddress.Text = vipTemp.VipAddress;
                txtBirthday.Text = vipTemp.VipBirthDay.ToShortDateString();
                txtCard.Text = vipTemp.VipNumber;
                txtVIPNum.Text = vipTemp.VipId.ToString();
                txtPhone.Text = vipTemp.VipPhone;
                txtVipName.Text = vipTemp.VipName;
                txtVipCard.Text = vipTemp.VipCard;
                int vipLV = vipTemp.VipLevelId;
                VipLevelInfo levelInfo = new VipLevelInfo();
                levelInfo.LvId = vipLV;
                levelInfo = vipLVBLL.VipLevelSelectById(levelInfo);
                txtVipLv.Text = levelInfo.LvName;
                int dpid = vipTemp.DpId;
                DepartInfo dpInfo = new DepartInfo();
                dpInfo.DpId = dpid;
                dpInfo = dpBLL.DepartSelectById(dpInfo);
                txtDp.Text = dpInfo.DpName;
            }
            catch (Exception)
            {
                MessageBox.Show("网络不稳定，请刷新！");
            }
           
        }
        #endregion
        private void btnOKClick()
        {
            this.Invoke(new Action(() =>
            {


                int result = 0;
                VipBorrowInfo borrowInfo = new VipBorrowInfo();
                borrowInfo.BbkNumber = int.Parse(txtNum.Text.Trim());
                borrowInfo.BbkTime = DateTime.Now;
                borrowInfo.DpId = StaticData.departLocal.DpId;
                borrowInfo.VipId = int.Parse(txtVIPNum.Text.Trim());
                borrowInfo.UserId = StaticData.userLocal.UserId;
                borrowInfo.Mark = txtMark.Text.Trim();
                if ((int)cmbKind.SelectedValue == 1)
                {
                    borrowInfo.RkrId = 1;
                    result = vipBorrowBLL.VipBorrowInsert(borrowInfo, 1);
                }
                else if ((int)cmbKind.SelectedValue == 2)
                {
                    borrowInfo.RkrId = 2;
                    result = vipBorrowBLL.VipBorrowInsert(borrowInfo, 2);
                }
                else if ((int)cmbKind.SelectedValue == 3)
                {
                    borrowInfo.RkrId = 3;
                    result = vipBorrowBLL.VipBorrowInsert(borrowInfo, 3);
                }
                if (result == -2)
                {
                    MessageBox.Show("该用户余额不足以支付起始扣费金额，请充值!");
                    CheckMiGo miGo = new CheckMiGo();
                    miGo.ShowDialog();
                    if (miGo.isTrue)
                    {
                        ReChargeWindow rechargeWinodw = new ReChargeWindow(true);
                        rechargeWinodw.ShowDialog();
                        txtBalance.Text = (double.Parse(txtBalance.Text) + rechargeWinodw.chargeMoney).ToString();
                    }
                }
                else if (result == -1)
                {
                    MessageBox.Show("系统出错，请联系管理员!");
                }
                else if (result == 1)
                {
                    MessageBox.Show("租车成功!");
                    btnOK.Enabled = false;
                    LogInfo logInfo = new LogInfo();
                    logInfo.UserId = StaticData.userLocal.UserId;
                    logInfo.Content = "为会员‘" + txtVipName.Text + "'租车" + txtNum.Text.ToString() + "辆";
                    logInfo.LogTime = DateTime.Now;
                    logInfo.DpId = StaticData.departLocal.DpId;
                    bool b = new LogBLL().LogInsert(logInfo);
                    this.Close();
                }
            }));
        }
        private void btnOK_Click(object sender, EventArgs e)
        {
            if (txtNum.Text.Trim() == "")
            {
                epMessage.SetError(txtNum, "请输入租车数量!");
                return;
            }
            else if (!Regex.IsMatch(txtNum.Text.Trim(), @"^[0-9]*[1-9][0-9]*$"))
            {
                epMessage.SetError(txtNum, "请输入正确的数量!");
                return;
            }
            //else if (Int32.Parse(txtNum.Text.Trim()) > 3)
            //{
            //    epMessage.SetError(txtNum, "对不起一次租车数量过多，请尝试多次租车!");
            //    return;
            //}
            Thread th = new Thread(new ThreadStart(btnOKClick));
            th.IsBackground = true;
            th.Start();

        }

        private void VipBorrowWindow_Load(object sender, EventArgs e)
        {
            Thread th = new Thread(new ThreadStart(Bingding));
            th.IsBackground = true;
            th.Start();
        }

        #region 取消按键触发事件
        private void btnCencel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region 加载照片触发事件
        private void btnAddPhoto_Click(object sender, EventArgs e)
        {
            btnAddPhoto.Enabled = false;
            progressBar1.Visible = true;
            backgroundWorker1.RunWorkerAsync();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            backgroundWorker1.WorkerReportsProgress = true;
            backgroundWorker1.ReportProgress(20);//这里让进度条显示进度
            vipInfo.VipPhoto = vipBLL.VipPhotoSelectById(vipInfo);
            backgroundWorker1.ReportProgress(70);//这里让进度条显示进度
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                MemoryStream stream = new MemoryStream(vipInfo.VipPhoto, true);
                stream.Write(vipInfo.VipPhoto, 0, vipInfo.VipPhoto.Length);
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

        #region 刷新
        private void btfreshen_Click(object sender, EventArgs e)
        {
            Bingding();
        }
        #endregion
        
    }
}
