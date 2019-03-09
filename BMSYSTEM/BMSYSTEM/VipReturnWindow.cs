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
using System.Text.RegularExpressions;
using System.Threading;

namespace BMSYSTEM
{
    public partial class VipReturnWindow : Form
    {
        public bool isDispose = false;
        bool first = true;
        VIPInfo vipInfo;
        VipBLL vipBLL;
        VipLevelBLL vipLVBLL;
        DepartBLL dpBLL;
        VipBorrowBLL borrowBLL;
        VipBorrowInfo borrowInfo;
        BorrowKindBLL borrowKindBLL;
        BikeReturnBLL bRetBLL;
        VIPInfo vipTemp = new VIPInfo();
        VipMoneyBLL moneyBLL;
        VipMoney vipMoneyTemp;
        List<VipBorrowInfo> borrowList = new List<VipBorrowInfo>();
        public VipReturnWindow(int id)
        {
            InitializeComponent();
            vipMoneyTemp = new VipMoney();
            vipMoneyTemp.VipId = id;
            vipMoneyTemp.IsVip = true;
            moneyBLL = new VipMoneyBLL();
            vipInfo = new VIPInfo();
            vipBLL = new VipBLL();
            vipLVBLL = new VipLevelBLL();
            dpBLL = new DepartBLL();
            borrowBLL = new VipBorrowBLL();
            borrowInfo = new VipBorrowInfo();
            borrowKindBLL = new BorrowKindBLL();
            bRetBLL = new BikeReturnBLL();
            borrowInfo.VipId = id;
            vipInfo.VipId = id;
            first = true;
            returnBg.DoWork += new DoWorkEventHandler(returnBg_DoWork);
            returnBg.RunWorkerCompleted += new RunWorkerCompletedEventHandler(returnBg_RunWorkerCompleted);
        }

        void returnBg_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (resultBg > 0)
            {

                try
                {
                    txtUseCost.Text = bikeReturnTemp.BuCost.ToString() + "元";
                    txtUseTime.Text = bikeReturnTemp.BuTimeString;
                    MessageBox.Show("还车成功!租车花费:" + bikeReturnTemp.BuCost.ToString() + "元");
                    if (vipMoneyTemp .VmBalance <bikeReturnTemp .BuCost )
                    {
                        MessageBox.Show("会员卡已透支，请充值！");
                        CheckMiGo miGo = new CheckMiGo();
                        miGo.ShowDialog();
                        if (miGo.isTrue)
                        {

                            ReChargeWindow rechargeWinodw = new ReChargeWindow(true);
                            rechargeWinodw.ShowDialog();
                        }
                    }
                    btnOK.Enabled = true;
                    this.Close();
                    //gbCost.Visible = true;                 
                }
                catch (Exception ex)
                {
                }
            }
            else
            {
                MessageBox.Show("还车失败!");
                btnOK.Enabled = true;
            }
        }

        BikeReturn bikeReturnTemp = new BikeReturn();
        int resultBg = 0;
        void returnBg_DoWork(object sender, DoWorkEventArgs e)
        {
            resultBg = bRetBLL.BikeReturnInsert(bikeReturn);
            if (resultBg > 0)
            {
                bikeReturnTemp.RbkId = resultBg;
                bikeReturnTemp = bRetBLL.BikeReturnSelectById(bikeReturnTemp);
                LogInfo logInfo = new LogInfo();
                logInfo.UserId = StaticData.userLocal.UserId;
                logInfo.Content = "为会员‘" + txtVipName.Text + "'还车" + NMReturnNum.Text.ToString() + "辆";
                logInfo.LogTime = DateTime.Now;
                logInfo.DpId = StaticData.departLocal.DpId;
                bool b = new LogBLL().LogInsert(logInfo);
            }
        }

        #region 填充会员信息
        /// <summary>
        /// 填充会员信息
        /// </summary>
        private void FillVipMessage()
        {
            try
            {
                txtAddress.Text = vipTemp.VipAddress;
                txtBirthday.Text = vipTemp.VipBirthDay.ToShortDateString();
                txtCard.Text = vipTemp.VipNumber;
                txtVIPNum.Text = vipTemp.VipId.ToString();
                txtPhone.Text = vipTemp.VipPhone;
                txtVipName.Text = vipTemp.VipName;
                txtVipCard.Text = vipTemp.VipCard;
                txtVipMark.Text = vipTemp.Mark;
                txtMoneyLeft.Text = vipMoneyTemp.VmBalance.ToString();
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
                MessageBox.Show("网络不稳定,请重新加载！");
            }
        }
        #endregion

        #region 填充租车信息
        /// <summary>
        /// 填充租车信息
        /// </summary>
        private void FillVipBorrowMessage()
        {
            try
            {
                if (borrowList == null || borrowList.Count == 0)
                {
                    DialogResult result = MessageBox.Show("该用户没有需要还的车辆!", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.No || result == DialogResult.Yes)
                        isDispose = true;
                    this.Close();
                    return;
                }
                cmbBorrowTime.DataSource = borrowList;
                cmbBorrowTime.DisplayMember = "BBKTIME";
                cmbBorrowTime.ValueMember = "BBKID";
                first = false;
                int id = (int)cmbBorrowTime.SelectedValue;
                VipBorrowInfo borrowTemp = new VipBorrowInfo();
                borrowTemp.BbkId = id;
                borrowTemp = borrowBLL.VipBorrowSelectById(borrowTemp);
                BorrowKind borrowKind = new BorrowKind();
                borrowKind.BkId = borrowTemp.RkrId;
                txtKind.Text = borrowKindBLL.BorrowKindSelectById(borrowKind).BbkName;
                txtBorrowNum.Text = borrowTemp.BbkNumber.ToString();
                txtUnReturn.Text = borrowTemp.LeftNum.ToString();
                txtBorrowT.Text = borrowList[0].Times.ToString();
                txtBorrowMark.Text = borrowTemp.Mark;
                if (borrowTemp.IsNight)
                {
                    labNightCost.ForeColor = Color.Red;
                    labNightCost.Text = "包夜租车";
                }
                else
                {
                    labNightCost.Text = "";
                }

            }
            catch (Exception)
            {
                MessageBox.Show("网络不稳定，请重新加载！");
            }
        }
        #endregion

        #region btnOkClick
        //private void btnOkClick(object bike)
        //{
        //    this.Invoke(new Action(() =>
        //    {
        //        BikeReturn bikeReturn = bike as BikeReturn;
        //        int result = bRetBLL.BikeReturnInsert(bikeReturn);
        //        if (result > 0)
        //        {
        //            MessageBox.Show("还车成功!");
        //            try
        //            {
        //                BikeReturn bikeReturnTemp = new BikeReturn();
        //                bikeReturnTemp.RbkId = result;
        //                bikeReturnTemp = bRetBLL.BikeReturnSelectById(bikeReturnTemp);
        //                txtUseCost.Text = bikeReturnTemp.BuCost.ToString() + "元";
        //                txtUseTime.Text = bikeReturnTemp.BuTimeString;
        //                //gbCost.Visible = true;
        //                LogInfo logInfo = new LogInfo();
        //                logInfo.UserId = StaticData.userLocal.UserId;
        //                logInfo.Content = "为会员‘" + txtVipName.Text + "'还车" + NMReturnNum.Text.ToString() + "辆";
        //                logInfo.LogTime = DateTime.Now;
        //                logInfo.DpId = StaticData.departLocal.DpId;
        //                bool b = new LogBLL().LogInsert(logInfo);
        //            }
        //            catch (Exception ex)
        //            {
        //            }

        //        }
        //        else
        //        {
        //            MessageBox.Show("还车失败!");
        //        }
        //    }));
        //}
        BikeReturn bikeReturn = new BikeReturn();
        BackgroundWorker returnBg = new BackgroundWorker();

        private void btnOk_Click(object sender, EventArgs e)
        {
            if  (NMReturnNum.Text.Trim() == "")
            {
                epMessage.SetError(NMReturnNum, "请输入还车数量!");
                return;
            }
            else if (!Regex.IsMatch(NMReturnNum.Text.Trim(), @"^[0-9]*[1-9][0-9]*$"))
            {
                epMessage.SetError(NMReturnNum, "请输入正确的数量!");
                return;
            }
            else if (Int32.Parse(NMReturnNum.Text.Trim()) > Int32.Parse(txtBorrowNum.Text) || Int32.Parse(txtUnReturn.Text) < Int32.Parse(NMReturnNum.Text.Trim()))
            {
                epMessage.SetError(NMReturnNum, "还车辆数不应该大于已租车辆数!");
                return;
            }

            btnOK.Enabled = false ;
            bikeReturn.IsVip = true;
            bikeReturn.RbkTime = DateTime.Now;
            bikeReturn.VipId = Convert.ToInt32(txtVIPNum.Text.ToString());
            bikeReturn.DpId = StaticData.departLocal.DpId;
            bikeReturn.BrNumber = Convert.ToInt32(NMReturnNum.Text.Trim());
            bikeReturn.BbkId = (int)cmbBorrowTime.SelectedValue;
            bikeReturn.UserId = StaticData.userLocal.UserId;
            returnBg.RunWorkerAsync();
        }
        #endregion

        #region cmbBorrowTimeSelectedIndexChanged
        private void cmbBorrowTimeSelectedIndexChanged(object id)
        {
            this.Invoke(new Action(() =>
            {
                VipBorrowInfo borrowTemp = new VipBorrowInfo();
                borrowTemp.BbkId = (int)id;
                //borrowTemp = borrowBLL.VipBorrowSelectById(borrowTemp);//NZZ2014-08-03修改为下面一句话
                borrowTemp = borrowList.Find(item => item.BbkId == (int)id);
                BorrowKind borrowKind = new BorrowKind();
                borrowKind.BkId = borrowTemp.RkrId;
                txtKind.Text = borrowKindBLL.BorrowKindSelectById(borrowKind).BbkName;
                txtBorrowNum.Text = borrowTemp.BbkNumber.ToString();
                txtUnReturn.Text = borrowTemp.LeftNum.ToString();
                txtBorrowMark.Text = borrowTemp.Mark;
                if (borrowTemp .IsNight )
                {
                    labNightCost.ForeColor = Color.Red;
                    labNightCost.Text = "包夜租车";
                }
                else
                {
                    labNightCost.Text = "";
                }
            }));
        }
        private void cmbBorrowTime_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!first)
            {
                int id = (int)cmbBorrowTime.SelectedValue;
                Thread th = new Thread(new ParameterizedThreadStart(cmbBorrowTimeSelectedIndexChanged));
                th.IsBackground = true;
                th.Start(id);
            }
        }
        #endregion


        private void btnCancle_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void VipReturnWindow_Load(object sender, EventArgs e)
        {
            backgroundWorker1.RunWorkerAsync();
        }
        //private void Bingding()
        //{
        //    this.Invoke(new Action(() =>
        //    {
        //        FillVipMessage();
        //        FillVipBorrowMessage();
        //    }));

        //}
        
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            vipTemp = vipBLL.VipSelectById(vipInfo);
            borrowList = borrowBLL.VipBorrowUnReturnByVipId(vipInfo.VipId);
            vipMoneyTemp = moneyBLL.VipMoneySelectByVipId(vipMoneyTemp);
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            FillVipBorrowMessage();
            FillVipMessage();
        }

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
            vipInfo.VipPhoto = vipBLL.VipPhotoSelectById(vipInfo);
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

        
    }
}
