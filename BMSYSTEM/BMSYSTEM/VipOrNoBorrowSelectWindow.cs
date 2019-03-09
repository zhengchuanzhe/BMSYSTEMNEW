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
    public partial class VipOrNoBorrowSelectWindow : Form
    {
        VipBLL vipBLL;
        VipNoBLL vipNoBLL;
        VIPInfo vipInfo;
        VipLevelBLL vipLVBLL;
        DepartBLL dpBLL;
        VipBorrowBLL vipBorrowBLL;
        BikeReturnBLL bikeReturnBLL;
        VipNoBorrowBLL vipNoBorrowBLL;
        DateTime startTime;
        DateTime endTime;
        int id;
        int vipId;
        int vipNoId;

        string[] kind = new string[] { "", "日租", "月租", "年租" };
        bool IsFirst = true;
        bool DFirst = true;
        bool VFirst = true;
        bool DNFirst = true;
        bool VNFirst = true;
        bool IsAdmin = false;
        bool IsCardChang = false;
        List<DepartInfo> departList;
        public VipOrNoBorrowSelectWindow(bool isAdmin)
        {
            InitializeComponent();
            vipBLL = new VipBLL();
            vipNoBLL = new VipNoBLL();
            vipInfo = new VIPInfo();
            vipLVBLL = new VipLevelBLL();
            dpBLL = new DepartBLL();
            vipBorrowBLL = new VipBorrowBLL();
            bikeReturnBLL = new BikeReturnBLL();
            vipNoBorrowBLL = new VipNoBorrowBLL();
            IsAdmin = isAdmin;
            IsFirst = true;
            departList = new List<DepartInfo>();

        }

        #region 填充所属分店下拉框
        private void FillDepart()
        {
            List<DepartInfo> departList = new List<DepartInfo>();
            try
            {
                departList = dpBLL.DepartSelect();
                cmbVipDepart.DataSource = departList;
                cmbVipDepart.DisplayMember = "DpName";
                cmbVipDepart.ValueMember = "DpId";
                cmbVipDepart.SelectedValue = StaticData.departLocal.DpId;
                DFirst = false;
            }
            catch (Exception ex)
            {
            }
        }
        private void FillNoDepart()
        {
            List<DepartInfo> departList = new List<DepartInfo>();
            departList = dpBLL.DepartSelect();
            cmbDeaprtNo.DataSource = departList;
            cmbDeaprtNo.DisplayMember = "DpName";
            cmbDeaprtNo.ValueMember = "DpId";
            DNFirst = false;
        }

        #endregion

        #region 为会员Id下拉框绑定数据
        private void FillVipId()
        {
            try
            {
                List<VIPInfo> vipList = new List<VIPInfo>();
                vipList = vipBLL.VipSelectByDpId(Int32.Parse(cmbVipDepart.SelectedValue.ToString()));
                cmbVipId.DataSource = vipList;
                cmbVipId.DisplayMember = "VIPID";
                cmbVipId.ValueMember = "VIPID";
                VFirst = false;
                IsFirst = false;

                if (IsCardChang)
                {
                    cmbVipId.SelectedValue = vipId;
                    FillLVMessage();
                    IsCardChang = false;
                }
            }
            catch (Exception ex)
            {
            }
        }
        #endregion

        #region 为非会员ID下拉框绑定数据
        private void FillVipNoId()
        {
            try
            {
                List<VipNoInfo> vipNoList = new List<VipNoInfo>();
                VipNoInfo vipNoTemp = new VipNoInfo();
                vipNoTemp.DpId = Int32.Parse(cmbDeaprtNo.SelectedValue.ToString());
                vipNoList = vipNoBLL.VipNoSelectByDPId(vipNoTemp);
                cmbVipNo.DataSource = vipNoList;
                cmbVipNo.DisplayMember = "VIPNAME";
                cmbVipNo.ValueMember = "VIPID";
                VNFirst = false;
                if (IsCardChang)
                {
                    IsCardChang = false;
                    cmbVipNo.SelectedValue = vipNoId;
                }
            }
            catch (Exception ex)
            {
            }
        }

        #endregion

        #region 填充会员信息
        private void FillVipMessage()
        {
            int id = Int32.Parse(cmbVipId.SelectedValue.ToString());
            VIPInfo vipTemp = new VIPInfo();
            vipInfo.VipId = id;
            vipTemp = vipBLL.VipSelectById(vipInfo);
            txtAddress.Text = vipTemp.VipAddress;
            txtBirthday.Text = vipTemp.VipBirthDay.ToShortDateString();
            txtCard.Text = vipTemp.VipNumber;
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

        }

        private void FillVipMessage(string vipCardNumber)
        {

            VIPInfo vipTemp = new VIPInfo();
            vipTemp = vipBLL.VipSelectByCardNumber(vipCardNumber);
            if (vipTemp == null)
            {
                epMessge.SetError(txtCard, "此卡号不存在");
                return;
            }
            epMessge.SetError(txtCard, "");
            if (cmbVipDepart.SelectedValue.ToString() == vipTemp.DpId.ToString())
            {
                cmbVipId.SelectedValue = vipTemp.VipId;
            }
            else
            {
                IsCardChang = true;
                cmbVipDepart.SelectedValue = vipTemp.DpId;
                vipId = vipTemp.VipId;
            }

            txtAddress.Text = vipTemp.VipAddress;
            txtBirthday.Text = vipTemp.VipBirthDay.ToShortDateString();
            txtCard.Text = vipTemp.VipNumber;
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

        }
        #endregion

        #region 填充非会员信息
        //根据非会员ID
        private void FillVipNoMessage()
        {
            try
            {
                int id = Int32.Parse(cmbVipNo.SelectedValue.ToString());
                VipNoInfo vipNoTemp = new VipNoInfo();
                vipNoTemp.VipId = id;
                vipNoTemp = vipNoBLL.VipNoSelectByVIPNoId(vipNoTemp);
                txtVipNoNumber.Text = vipNoTemp.VipNumber;
                txtVipNoPhone.Text = vipNoTemp.VipPhone;
                txtVipNoCard.Text = vipNoTemp.VipCard;
                int vipLV = vipNoTemp.LvId;
                VipLevelInfo levelInfo = new VipLevelInfo();
                levelInfo.LvId = vipLV;
                levelInfo = vipLVBLL.VipLevelSelectById(levelInfo);
                txtVipNoLevel.Text = levelInfo.LvName;
            }
            catch (Exception ex)
            {
            }
        }
        //根据非会员卡号
        private void FillVipNoMessage(string VipNoCard)
        {
            try
            {
                VipNoInfo vipNoTemp = new VipNoInfo();
                vipNoTemp = vipNoBLL.VipNoSelectByVIPNoNumber(VipNoCard);
                if (vipNoTemp == null)
                {
                    epMessge.SetError(txtVipNoNumber, "该卡号不存在");
                    return;
                }
                epMessge.SetError(txtVipNoNumber, "");
                if (int.Parse(cmbDeaprtNo.SelectedValue.ToString()) == vipNoTemp.DpId)
                {
                    cmbVipNo.SelectedValue = vipNoTemp.VipId;
                }
                else
                {
                    IsCardChang = true;
                    cmbDeaprtNo.SelectedValue = vipNoTemp.DpId;
                    vipNoId = vipNoTemp.VipId;
                }
            }
            catch (Exception ex)
            {
            }
        }
        #endregion

        #region 填充会员记录查询的ListView
        private void FillLVMessage()
        {
            startTime = dtpStartTimeVip.Value.Date;
            endTime = dtpEndTimeVip.Value.Date.AddDays(1);
            if (cmbVipId.SelectedValue == null)
            {
                return;
            }
            id = Int32.Parse(cmbVipId.SelectedValue.ToString());
            bikeReturnTemp.IsVip = true;
            bikeReturnTemp.VipId = id;
            progressBar1.Visible = true;
            backgroundWorker1.RunWorkerAsync();
        }
        #endregion

        #region 填充非会员记录
        private void FillNoVipMessage()
        {
            startTime = dtpStartTimeVipNo.Value.Date;
            endTime = dtpEndTimeVipNo.Value.Date.AddDays(1);
            if (cmbVipNo.SelectedValue == null)
            {
                return;
            }
            id = Int32.Parse(cmbVipNo.SelectedValue.ToString());
            bikeReturnTemp.IsVip = false;
            bikeReturnTemp.VipId = id;
            progressBar1.Visible = true;
            backgroundWorker2.RunWorkerAsync();
        }
        #endregion


        #region 选取会员
        private void cmbVipId_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!VFirst && !IsCardChang)
            {
                if (cmbVipId.SelectedValue == null)
                {
                    return;
                }
                FillVipMessage();
                FillLVMessage();
            }

        }
        #endregion

        private void VipOrNoBorrowSelectWindow_Load(object sender, EventArgs e)
        {

        }

        #region TbSelectIndexChanged
        private void tbMessage_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (tbMessage.SelectedTab == tpVip)
            {
                FillVipId();
            }
            if (tbMessage.SelectedTab == tpNoVip)
            {

                FillVipNoId();

            }
        }
        #endregion

        #region cmbDepartNoSelectIndexChanged
        private void cmbDepartNoSelectIndexChanged()
        {
            this.Invoke(new Action(() =>
            {
                FillVipNoId();
            }));

        }
        private void cmbDeaprtNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!DNFirst)
            {
                Thread th = new Thread(new ThreadStart(cmbDepartNoSelectIndexChanged));
                th.IsBackground = true;
                th.Start();
            }
        }
        #endregion

        #region cmbVipNoSelectedIndexChanged
        private void cmbVipNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!VNFirst && !IsCardChang)
            {
                if (!IsFirst)
                {
                    FillVipNoMessage();
                    FillNoVipMessage();
                }
            }
        }
        #endregion

        #region cmbVipDepartSelectedIndexChanged
        private void cmbVipDepartSelectedIndexChanged()
        {
            this.Invoke(new Action(() =>
            {
                FillVipId();
            }));

        }
        private void cmbVipDepart_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!DFirst)
            {
                Thread th = new Thread(new ThreadStart(cmbVipDepartSelectedIndexChanged));
                th.IsBackground = true;
                th.Start();
            }
        }
        #endregion

        private void VipOrNoBorrowSelectWindow_Load_1(object sender, EventArgs e)
        {
            try
            {
                Thread th = new Thread(new ThreadStart(Bingding));
                th.IsBackground = true;
                th.Start();
            }
            catch (Exception)
            {
                MessageBox.Show("网络信号太差，无法取出信息");
            }
        }
        private void Bingding()
        {
            this.Invoke(new Action(() =>
            {
                FillDepart();
                FillNoDepart();
                FillVipId();
                FillVipNoId();
                if (!IsAdmin)
                {
                    cmbDeaprtNo.SelectedValue = StaticData.departLocal.DpId;
                    cmbVipDepart.SelectedValue = StaticData.departLocal.DpId;
                    cmbDeaprtNo.Enabled = false;
                    cmbVipDepart.Enabled = false;
                }
            }));
        }

        //会员卡号改变
        private void txtCard_Validated(object sender, EventArgs e)
        {
            string vipCard = txtCard.Text.Trim();
            if (vipCard.Length <= 0)
            {
                return;
            }
            FillVipMessage(vipCard);

        }

        //会员开始时间改变事件
        private void dtpStartTimeVip_ValueChanged(object sender, EventArgs e)
        {
            FillLVMessage();
        }

        //会员结束时间改变事件
        private void dtpEndTimeVip_ValueChanged(object sender, EventArgs e)
        {
            FillLVMessage();
        }

        //非会员卡号改变事件
        private void txtVipNoNumber_Validated(object sender, EventArgs e)
        {
            string vipNoCrad = txtVipNoNumber.Text.Trim();
            if (vipNoCrad.Length <= 0)
            {
                return;
            }
            FillVipNoMessage(vipNoCrad);
        }

        //非会员开始时间改变事件
        private void dtpStartTimeVipNo_ValueChanged(object sender, EventArgs e)
        {
            FillNoVipMessage();
        }

        //非会员结束时间改变事件
        private void dtpEndTimeVipNo_ValueChanged(object sender, EventArgs e)
        {
            FillNoVipMessage();
        }



        #region 绑定会员记录信息
        List<VipBorrowInfo> vipBorrowList = new List<VipBorrowInfo>();
        List<BikeReturn> vipReturnList = new List<BikeReturn>();
        BikeReturn bikeReturnTemp = new BikeReturn();
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            backgroundWorker1.ReportProgress(10);//这里让进度条显示进度
            vipBorrowList = vipBorrowBLL.VipBorrowSelectByVipIdAndTime(id, startTime, endTime);
            backgroundWorker1.ReportProgress(40);//这里让进度条显示进度
            vipReturnList = bikeReturnBLL.BikeReturnSelectByVipId(bikeReturnTemp);
            backgroundWorker1.ReportProgress(80);//这里让进度条显示进度
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            progressBar1.Visible = false;
            try
            {
                if ((vipBorrowList == null && vipReturnList == null))
                {
                    MessageBox.Show("没有查询到相应租车记录信息!");
                    lvVipMessage.Items.Clear();
                    return;
                }
                if (vipBorrowList.Count == 0)
                {
                    MessageBox.Show("没有查询到相应租车记录信息!");
                    lvVipMessage.Items.Clear();
                    return;
                }
                lvVipMessage.Items.Clear();
                DepartInfo dpTemp = new DepartInfo();
                for (int i = 0; i < vipBorrowList.Count; i++)
                {
                    lvVipMessage.Items.Add("");
                    lvVipMessage.Items[i].SubItems.Add("");
                    lvVipMessage.Items[i].SubItems.Add("");
                    lvVipMessage.Items[i].SubItems.Add("");
                    lvVipMessage.Items[i].SubItems.Add("");
                    lvVipMessage.Items[i].SubItems.Add("");
                    lvVipMessage.Items[i].SubItems.Add("");
                    lvVipMessage.Items[i].SubItems.Add("");
                    lvVipMessage.Items[i].SubItems.Add("");
                    lvVipMessage.Items[i].SubItems[0].Text = kind[vipBorrowList[i].RkrId];
                    lvVipMessage.Items[i].SubItems[1].Text = vipBorrowList[i].BbkTime.ToString();
                    dpTemp.DpId = vipBorrowList[i].DpId;
                    dpTemp = dpBLL.DepartSelectById(dpTemp);
                    lvVipMessage.Items[i].SubItems[2].Text = dpTemp.DpName;
                    lvVipMessage.Items[i].SubItems[3].Text = vipBorrowList[i].IsReturn == true ? "已还" : "未还";
                    if (vipBorrowList[i].IsReturn)//如果是已经还过
                    {
                        if (vipReturnList == null || vipReturnList.Count == 0)
                        {
                            return;
                        }
                        bikeReturnTemp = vipReturnList.Find(item => item.BbkId == vipBorrowList[i].BbkId);
                        if (bikeReturnTemp == null)
                        { return; }
                        dpTemp.DpId = bikeReturnTemp.DpId;
                        dpTemp = dpBLL.DepartSelectById(dpTemp);
                        lvVipMessage.Items[i].SubItems[4].Text = dpTemp.DpName;
                        lvVipMessage.Items[i].SubItems[5].Text = bikeReturnTemp.RbkTime.ToString();
                        lvVipMessage.Items[i].SubItems[6].Text = bikeReturnTemp.BuTimeString;
                        lvVipMessage.Items[i].SubItems[7].Text = bikeReturnTemp.BuCost.ToString();
                    }
                }
            }
            catch (Exception)
            {

            }
        }
        #endregion


        #region 绑定非会员信息
        List<VipNoBorrow> vipNoList = new List<VipNoBorrow>();
        List<BikeReturn> vipNoReturnList = new List<BikeReturn>();
        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {
            backgroundWorker2.ReportProgress(10);//这里让进度条显示进度  
            vipNoList = vipNoBorrowBLL.VipNoBorrowSelectByVipNoIdAndTime(id, startTime, endTime);
            backgroundWorker2.ReportProgress(40);//这里让进度条显示进度 
            vipNoReturnList = bikeReturnBLL.BikeReturnSelectByVipId(bikeReturnTemp);
            backgroundWorker2.ReportProgress(80);//这里让进度条显示进度  
        }

        private void backgroundWorker2_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }

        private void backgroundWorker2_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            progressBar1.Visible = false;
            try
            {
                if ((vipNoList == null && vipNoReturnList == null))
                {
                    MessageBox.Show("没有查询到相应租车记录信息!");
                    lvNoMessage.Items.Clear();
                    return;
                }
                if (vipNoList.Count == 0)
                {
                    MessageBox.Show("没有查询到相应租车记录信息!");
                    lvNoMessage.Items.Clear();
                    return;
                }
                lvNoMessage.Items.Clear();
                DepartInfo dpTemp = new DepartInfo();
                for (int i = 0; i < vipNoList.Count; i++)
                {
                    lvNoMessage.Items.Add("");
                    lvNoMessage.Items[i].SubItems.Add("");
                    lvNoMessage.Items[i].SubItems.Add("");
                    lvNoMessage.Items[i].SubItems.Add("");
                    lvNoMessage.Items[i].SubItems.Add("");
                    lvNoMessage.Items[i].SubItems.Add("");
                    lvNoMessage.Items[i].SubItems.Add("");
                    lvNoMessage.Items[i].SubItems.Add("");
                    lvNoMessage.Items[i].SubItems.Add("");
                    lvNoMessage.Items[i].SubItems.Add("");
                    dpTemp.DpId = vipNoList[i].DpId;
                    dpTemp = dpBLL.DepartSelectById(dpTemp);
                    lvNoMessage.Items[i].SubItems[0].Text = vipNoList[i].VnName;
                    lvNoMessage.Items[i].SubItems[1].Text = kind[vipNoList[i].RkrId];
                    lvNoMessage.Items[i].SubItems[2].Text = vipNoList[i].BbkTime.ToString();
                    lvNoMessage.Items[i].SubItems[3].Text = dpTemp.DpName;
                    lvNoMessage.Items[i].SubItems[4].Text = vipNoList[i].IsReturn ? "已还" : "未还";
                    if (vipNoList[i].IsReturn)//如果是已经还过
                    {
                        if (vipNoReturnList == null || vipNoReturnList.Count == 0)
                        {
                            return;
                        }
                        bikeReturnTemp = vipNoReturnList.Find(item => item.BbkId == vipNoList[i].BbkId);
                        if (bikeReturnTemp == null)
                        { return; }
                        dpTemp.DpId = bikeReturnTemp.DpId;
                        dpTemp = dpBLL.DepartSelectById(dpTemp);
                        lvNoMessage.Items[i].SubItems[5].Text = dpTemp.DpName;
                        lvNoMessage.Items[i].SubItems[6].Text = bikeReturnTemp.RbkTime.ToString();
                        lvNoMessage.Items[i].SubItems[7].Text = bikeReturnTemp.BuTimeString;
                        lvNoMessage.Items[i].SubItems[8].Text = bikeReturnTemp.BuCost.ToString();
                    }
                }
            }
            catch (Exception)
            {

            }
        }
        #endregion




    }
}
