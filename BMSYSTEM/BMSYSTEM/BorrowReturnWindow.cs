using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using BIKEBLL;
using MODEL;

namespace BMSYSTEM
{
    public partial class BorrowReturnWindow : Form
    {
        #region 逻辑对象

        VipBorrowBLL vipBorrowBLL;
        VipNoBLL vipNoBLL;
        DepartBLL departBLL;
        VipBLL vipBLL;
        VipLevelBLL vipLvBLL;
        VipNoBorrowBLL vipNoBorrowBLL;
        BikeReturnBLL bikeReturnBLL;
        int id;
        bool isFirst;
        DateTime startTime;
        DateTime endTime;
        BackgroundWorker bg = new BackgroundWorker();
        List<BikeReturn> bikeList = new List<BikeReturn>();
        List<BikeReturn> bikeNoList = new List<BikeReturn>();
        #endregion

        #region 模型对象
        DepartInfo depart;
        List<DepartInfo> departList;
        VipBorrowInfo vipBorrow;
        List<VipBorrowInfo> vipBorrowList;
        VipNoBorrow vipNoBorrow;
        List<VipNoBorrow> vipNoBorrowList;
        string[] kind = new string[] { "", "日租", "月租", "年租" };
        bool IsAdmin = false;
        #endregion

        #region 类实例化
        public BorrowReturnWindow(bool isAdmin)
        {
            InitializeComponent();
            bg.DoWork += new DoWorkEventHandler(bg_DoWork);//异步操作时要做的操作，一般去查列表，这个列表在本页面内先声明，然后在这个dowork方法里去取数填充他
            bg.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bg_RunWorkerCompleted);//这个是取数完成后进行的操作，去到数后，这里取用去到的列表绑定到控件
            vipBorrowBLL = new VipBorrowBLL();
            vipNoBLL = new VipNoBLL();
            departBLL = new DepartBLL();
            depart = new DepartInfo();
            departList = new List<DepartInfo>();
            vipBorrow = new VipBorrowInfo();
            vipBorrowList = new List<VipBorrowInfo>();
            vipNoBorrow = new VipNoBorrow();
            vipNoBorrowList = new List<VipNoBorrow>();
            vipBLL = new VipBLL();
            vipLvBLL = new VipLevelBLL();
            vipNoBorrowBLL = new VipNoBorrowBLL();
            bikeReturnBLL = new BikeReturnBLL();
            IsAdmin = isAdmin;
        }
        #endregion

        #region 绑定下拉框
        void bg_DoWork(object sender, DoWorkEventArgs e)
        {
            departList = departBLL.DepartSelect();
        }
        void bg_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            FillDp();
        }
        private void FillDp()
        {
            cmbDepart.DataSource = departList;
            cmbDepart.DisplayMember = "DPNAME";
            cmbDepart.ValueMember = "DPID";
            cmbDepart.SelectedValue = StaticData.departLocal.DpId;
            isFirst = false;
            if (!IsAdmin)
            {
                cmbDepart.SelectedValue = StaticData.departLocal.DpId;
                cmbDepart.Enabled = false;
            }
        }
        #endregion



        #region 绑定租车查询
        /// <summary>
        /// 绑定租车查询
        /// </summary>
        /// 
        private void FillBorrowLV()
        {
            id = (int)cmbDepart.SelectedValue;
            startTime = dtpStartTime.Value.Date;
            endTime = dtpEndTime.Value.Date .AddDays (1);
            backgroundWorker1.RunWorkerAsync();
        }
        #endregion

        #region 绑定还车查询
        /// <summary>
        /// 绑定还车查询
        /// </summary>
        ///  

        private void FillReturnLV()
        {
            id = (int)cmbDepart.SelectedValue;
            startTime = dtpStartTime.Value.Date;
            endTime = dtpEndTime.Value.Date .AddDays (1);
            bikeTemp.IsVip = true;
            bikeTemp.DpId = id;
            backgroundWorker2.RunWorkerAsync();
        }
        #endregion



        #region 切换tab事件
        private void tbMessage_Selected(object sender, TabControlEventArgs e)
        {
            btnOK.Enabled = false;
            progressBar1.Visible = true;
            if (tbMessage.SelectedIndex == 0)
            {
                FillBorrowLV();
            }
            if (tbMessage.SelectedIndex == 1)
            {
                FillReturnLV();
            }
        }
        #endregion

        #region 确定按钮点击事件
        private void btnOK_Click(object sender, EventArgs e)
        {
            progressBar1.Visible = true;
            btnOK.Enabled = false;
            if (tbMessage.SelectedIndex == 0)
            {
                FillBorrowLV();
            }
            if (tbMessage.SelectedIndex == 1)
            {
                FillReturnLV();
            }
            /* 这种方法也可以用暂时保留，因为上面已经写了委托不用重新再改了，两种方法都可以用
            if (tbMessage.SelectedIndex == 0)
            {
                this.BeginInvoke(new Action(() =>
                { FillBorrowLVMethod(); }));
            }
            if (tbMessage.SelectedIndex == 1)
            {
                this.BeginInvoke(new Action(() =>
                { FillReturnLVMethod(); }));
            }
             * */
        }
        #endregion

        #region 窗体加载
        private void BorrowReturnWindow_Load(object sender, EventArgs e)
        {
            bg.RunWorkerAsync();

        }
        #endregion

        #region 租车查询

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            backgroundWorker1.ReportProgress(10);//这里让进度条显示进度
            vipBorrowList = vipBorrowBLL.VipBorrowSelectAllByDpIdAndTime(id, startTime, endTime);
            backgroundWorker1.ReportProgress(60);//这里让进度条显示进度
            vipNoBorrowList = vipNoBorrowBLL.VipNoBorrowSelectAllByDpIdAndTime(id, startTime, endTime);
            backgroundWorker1.ReportProgress(90);//这里让进度条显示进度
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

            VipNoInfo vipNoTemp = new VipNoInfo();
            VIPInfo vipTemp = new VIPInfo();
            VipLevelInfo vipLvInfo = new VipLevelInfo();
            if (vipBorrowList == null || vipBorrowList.Count == 0)
            {
                MessageBox.Show("未查询到相应租车信息!");
                lvBorrowMessage.Items.Clear();
                btnOK.Enabled = true;
                progressBar1.Visible = false;
                return;
            }
            int length = vipBorrowList.Count;
            lvBorrowMessage.BeginUpdate();
            lvBorrowMessage.Items.Clear();
            for (int i = 0; i < vipBorrowList.Count; i++)
            {
                lvBorrowMessage.Items.Add("");
                lvBorrowMessage.Items[i].SubItems.Add("");
                lvBorrowMessage.Items[i].SubItems.Add("");
                lvBorrowMessage.Items[i].SubItems.Add("");
                lvBorrowMessage.Items[i].SubItems.Add("");
                lvBorrowMessage.Items[i].SubItems.Add("");
                lvBorrowMessage.Items[i].SubItems.Add("");
                lvBorrowMessage.Items[i].SubItems.Add("");
                lvBorrowMessage.Items[i].SubItems.Add("");
                lvBorrowMessage.Items[i].SubItems.Add("");
                vipTemp.VipId = vipBorrowList[i].VipId;
                vipTemp = vipBLL.VipSelectById(vipTemp);
                vipLvInfo.LvId = vipTemp.VipLevelId;
                vipLvInfo = vipLvBLL.VipLevelSelectById(vipLvInfo);
                lvBorrowMessage.Items[i].SubItems[0].Text = vipTemp.VipNumber;
                lvBorrowMessage.Items[i].SubItems[1].Text = vipTemp.VipName;
                lvBorrowMessage.Items[i].SubItems[2].Text = vipTemp.VipPhone;
                lvBorrowMessage.Items[i].SubItems[3].Text = vipLvInfo.LvName;
                lvBorrowMessage.Items[i].SubItems[4].Text = vipBorrowList[i].BbkTime.ToString();
                lvBorrowMessage.Items[i].SubItems[5].Text = vipBorrowList[i].BbkNumber.ToString();
                lvBorrowMessage.Items[i].SubItems[6].Text = kind[vipBorrowList[i].RkrId];
                lvBorrowMessage.Items[i].SubItems[7].Text = vipBorrowList[i].IsReturn == true ? "已还" : "未还";
                lvBorrowMessage.Items[i].SubItems[8].Text = vipBorrowList[i].LeftNum.ToString();
            }
            if (vipNoBorrowList == null)
            {
                return;
            }
            for (int i = 0; i < vipNoBorrowList.Count; i++)
            {
                lvBorrowMessage.Items.Add("");
                lvBorrowMessage.Items[i + length].SubItems.Add("");
                lvBorrowMessage.Items[i + length].SubItems.Add("");
                lvBorrowMessage.Items[i + length].SubItems.Add("");
                lvBorrowMessage.Items[i + length].SubItems.Add("");
                lvBorrowMessage.Items[i + length].SubItems.Add("");
                lvBorrowMessage.Items[i + length].SubItems.Add("");
                lvBorrowMessage.Items[i + length].SubItems.Add("");
                lvBorrowMessage.Items[i + length].SubItems.Add("");
                vipNoTemp.VipId = vipNoBorrowList[i].VipId;
                vipNoTemp = vipNoBLL.VipNoSelectByVIPNoId(vipNoTemp);
                vipLvInfo.LvId = vipNoTemp.LvId;
                vipLvInfo = vipLvBLL.VipLevelSelectById(vipLvInfo);
                lvBorrowMessage.Items[i + length].SubItems[0].Text = vipNoTemp.VipNumber;
                lvBorrowMessage.Items[i + length].SubItems[1].Text = vipNoBorrowList[i].VnName;
                lvBorrowMessage.Items[i + length].SubItems[2].Text = vipNoBorrowList[i].VnPhone;
                lvBorrowMessage.Items[i + length].SubItems[3].Text = vipLvInfo.LvName;
                lvBorrowMessage.Items[i + length].SubItems[4].Text = vipNoBorrowList[i].BbkTime.ToString();
                lvBorrowMessage.Items[i + length].SubItems[5].Text = vipNoBorrowList[i].VnNumber.ToString();
                lvBorrowMessage.Items[i + length].SubItems[6].Text = kind[vipNoBorrowList[i].RkrId];
                lvBorrowMessage.Items[i + length].SubItems[7].Text = vipNoBorrowList[i].IsReturn == true ? "已还" : "未还";
                lvBorrowMessage.Items[i + length].SubItems[8].Text = vipNoBorrowList[i].LeftNum.ToString();
            }
            lvBorrowMessage.EndUpdate();
            btnOK.Enabled = true;
            progressBar1.Visible = false;
        }

        #endregion

        #region 还车查询

        BikeReturn bikeTemp = new BikeReturn();
        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {
            backgroundWorker2.ReportProgress(10);//这里让进度条显示进度
            bikeList = bikeReturnBLL.BikeReturnSelectByDpIdAndTime(bikeTemp, startTime, endTime);
            backgroundWorker2.ReportProgress(60);//这里让进度条显示进度 
            bikeTemp.IsVip = false;
            bikeNoList = bikeReturnBLL.BikeReturnSelectByDpIdAndTime(bikeTemp, startTime, endTime);
            backgroundWorker2.ReportProgress(90);//这里让进度条显示进度

        }

        private void backgroundWorker2_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

            progressBar1.Value = e.ProgressPercentage;
        }
        VIPInfo vipTemp = new VIPInfo();
        VipNoInfo vipNoTemp = new VipNoInfo();
        DepartInfo departTemp = new DepartInfo();
        VipNoBorrow vipNoBorrowTemp = new VipNoBorrow();
        VipLevelInfo vipLvInfo = new VipLevelInfo();
        private void backgroundWorker2_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (bikeNoList != null)
            {
                bikeList.AddRange(bikeNoList);
            }
            if (bikeList == null || bikeList.Count == 0)
            {
                MessageBox.Show("未查询到相应还车信息!");
                lvReturnMessage.Items.Clear();
                progressBar1.Visible = false;
                btnOK.Enabled = true;
                return;
            }
            lvReturnMessage.BeginUpdate();
            lvReturnMessage.Items.Clear();
            for (int i = 0; i < bikeList.Count; i++)
            {
                lvReturnMessage.Items.Add("");
                lvReturnMessage.Items[i].SubItems.Add("");
                lvReturnMessage.Items[i].SubItems.Add("");
                lvReturnMessage.Items[i].SubItems.Add("");
                lvReturnMessage.Items[i].SubItems.Add("");
                lvReturnMessage.Items[i].SubItems.Add("");
                lvReturnMessage.Items[i].SubItems.Add("");
                lvReturnMessage.Items[i].SubItems.Add("");
                lvReturnMessage.Items[i].SubItems.Add("");
                lvReturnMessage.Items[i].SubItems.Add("");
                lvReturnMessage.Items[i].SubItems.Add("");
                if (bikeList[i].IsVip)
                {
                    vipTemp.VipId = bikeList[i].VipId;
                    vipTemp = vipBLL.VipSelectById(vipTemp);
                    departTemp.DpId = bikeList[i].DpId;
                    departTemp = departBLL.DepartSelectById(departTemp);
                    vipLvInfo.LvId = vipTemp.VipLevelId;
                    vipLvInfo = vipLvBLL.VipLevelSelectById(vipLvInfo);
                    vipBorrow.BbkId = bikeList[i].BbkId;
                    vipBorrow = vipBorrowBLL.VipBorrowSelectById(vipBorrow);
                    lvReturnMessage.Items[i].SubItems[0].Text = vipTemp.VipNumber;
                    lvReturnMessage.Items[i].SubItems[1].Text = vipTemp.VipName;
                    lvReturnMessage.Items[i].SubItems[2].Text = vipLvInfo.LvName;
                    lvReturnMessage.Items[i].SubItems[3].Text = vipBorrow.BbkTime.ToString();
                    lvReturnMessage.Items[i].SubItems[4].Text = bikeList[i].BrNumber.ToString();
                    lvReturnMessage.Items[i].SubItems[5].Text = kind[vipBorrow.RkrId];
                    lvReturnMessage.Items[i].SubItems[6].Text = bikeList[i].RbkTime.ToString();
                    lvReturnMessage.Items[i].SubItems[7].Text = bikeList[i].BuTimeString;
                    lvReturnMessage.Items[i].SubItems[8].Text = bikeList[i].BuCost.ToString();
                    lvReturnMessage.Items[i].SubItems[9].Text = departTemp.DpName;
                }
                else
                {
                    vipNoTemp.VipId = bikeList[i].VipId;
                    vipNoTemp = vipNoBLL.VipNoSelectByVIPNoId(vipNoTemp);
                    departTemp.DpId = bikeList[i].DpId;
                    departTemp = departBLL.DepartSelectById(departTemp);
                    vipLvInfo.LvId = vipNoTemp.LvId;
                    vipLvInfo = vipLvBLL.VipLevelSelectById(vipLvInfo);
                    vipNoBorrowTemp.BbkId = bikeList[i].BbkId;
                    vipNoBorrowTemp = vipNoBorrowBLL.VipNoBorrowSelectByBBKId(vipNoBorrowTemp);
                    lvReturnMessage.Items[i].SubItems[0].Text = vipNoTemp.VipNumber;
                    lvReturnMessage.Items[i].SubItems[1].Text = vipNoBorrowTemp.VnName;
                    lvReturnMessage.Items[i].SubItems[2].Text = vipLvInfo.LvName;
                    lvReturnMessage.Items[i].SubItems[3].Text = vipNoBorrowTemp.BbkTime.ToString();
                    lvReturnMessage.Items[i].SubItems[4].Text = bikeList[i].BrNumber.ToString();
                    lvReturnMessage.Items[i].SubItems[5].Text = kind[vipNoBorrowTemp.RkrId];
                    lvReturnMessage.Items[i].SubItems[6].Text = bikeList[i].RbkTime.ToString();
                    lvReturnMessage.Items[i].SubItems[7].Text = bikeList[i].BuTimeString;
                    lvReturnMessage.Items[i].SubItems[8].Text = bikeList[i].BuCost.ToString();
                    lvReturnMessage.Items[i].SubItems[9].Text = departTemp.DpName;
                }
            }
            lvReturnMessage.EndUpdate();
            progressBar1.Visible = false;
            btnOK.Enabled = true;
        }
        #endregion
    }
}
