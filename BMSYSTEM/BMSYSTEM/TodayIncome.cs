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
using System.Threading;


namespace BMSYSTEM
{
    public partial class TodayIncome : Form
    {
        bool IsAdmin = false;
        DepartBLL departBLL;
        VipBLL vipBLL;
        UserBLL userBLL;
        VipMoneyBLL vipMoneyBLL;
        BackgroundWorker bg = new BackgroundWorker();
        BikeReturnBLL brBLL;
        DateTime beginTime;
        DateTime endTime;
        int departId;
        public TodayIncome(bool isAdmin)
        {
            bg.DoWork += new DoWorkEventHandler(bg_DoWork);//异步操作时要做的操作，一般去查列表，这个列表在本页面内先声明，然后在这个dowork方法里去取数填充他
            bg.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bg_RunWorkerCompleted);//这个是取数完成后进行的操作，去到数后，这里取用去到的列表绑定到控件
            departBLL = new DepartBLL();
            InitializeComponent();
            IsAdmin = isAdmin;
            vipBLL = new VipBLL();
            userBLL = new UserBLL();
            vipMoneyBLL = new VipMoneyBLL();
            brBLL = new BikeReturnBLL();
        }


        public static List<DepartInfo> departList;
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

            cmbDepart.DataSource = departBLL.DepartSelect();
            cmbDepart.DisplayMember = "DpName";
            cmbDepart.ValueMember = "DPID";
            cmbDepart.SelectedValue = StaticData.departLocal.DpId;
            if (!IsAdmin)
            {
                cmbDepart.SelectedValue = StaticData.departLocal.DpId;
                cmbDepart.Enabled = false;
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            departId = Int32.Parse(cmbDepart.SelectedValue.ToString());
            btnOk.Enabled = false;
            progressBar1.Visible = true;
            beginTime = dtpBegin.Value.Date;
            endTime = dtpEndTime.Value.Date.AddDays(1);
            backgroundWorker1.RunWorkerAsync();
        }

        public static List<VIPInfo> vipList;
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            backgroundWorker1.ReportProgress(10);//这里让进度条显示进度
            vipList = vipBLL.GetNewVipList(departId,beginTime ,endTime );
            backgroundWorker1.ReportProgress(70);//这里让进度条显示进度
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

            lvMsg.BeginUpdate();
            lvMsg.Groups.Clear();
            lvMsg.Items.Clear();

            #region 新办会员收入
            ListViewItem addVipSum = new ListViewItem();
            ListViewGroup newGroup = new ListViewGroup();
            newGroup.Header = "新办会员收入";
            newGroup.HeaderAlignment = HorizontalAlignment.Center;
            lvMsg.Groups.Add(newGroup);
            if (vipList != null)
            {
                for (int i = 0; i < vipList.Count; i++)
                {
                    UserInfo user = new UserInfo();
                    user.UserId = vipList[i].UserId;
                    user = userBLL.SelectUserById(user);
                    ListViewItem vi = new ListViewItem();
                    vi.SubItems[0].Text = vipList[i].VipName;
                    vi.SubItems.Add("10");
                    vi.SubItems.Add("新会员");
                    vi.SubItems.Add(vipList[i].AddDate.ToString());
                    vi.SubItems.Add(user.UserName);
                    newGroup.Items.Add(vi);
                    lvMsg.Items.Add(vi);
                }
                addVipSum.SubItems[0].Text = "新办会员总计:";
                addVipSum.SubItems.Add((vipList.Count * 10).ToString());
                addVipSum.ForeColor = Color.Red;
            }
            else
            {
                addVipSum.SubItems[0].Text = "新办会员总计:";
                addVipSum.SubItems.Add("0");
                addVipSum.ForeColor = Color.Red;
            }

            #endregion


            #region 充值收入

            ListViewItem vipChargeSum = new ListViewItem();
            ListViewGroup chargeGroup = new ListViewGroup();
            chargeGroup.Header = "充值收入";
            chargeGroup.HeaderAlignment = HorizontalAlignment.Center;
            RechargeInfo rechargeInfo = new RechargeInfo();
            rechargeInfo.DepartId = departId;
            List<RechargeInfo> rechargeList = vipMoneyBLL.RechargeInfoSelect(beginTime , endTime , rechargeInfo);
            if (rechargeList != null)
            {
                double money = 0;
                for (int i = 0; i < rechargeList.Count; i++)
                {
                    UserInfo user = new UserInfo();
                    user.UserId = rechargeList[i].UserId;
                    user = userBLL.SelectUserById(user);
                    ListViewItem vi = new ListViewItem();
                    if (rechargeList[i].IsVip)
                    {
                        VIPInfo vip = new VIPInfo();
                        vip.VipId = rechargeList[i].VipId;
                        vip = vipBLL.VipSelectById(vip);
                        vi.SubItems[0].Text = vip.VipName;
                    }
                    else
                    {
                        VipNoInfo vipNo = new VipNoInfo();
                        vipNo.VipId = rechargeList[i].VipId;
                        vipNo = new VipNoBLL().VipNoSelectByVIPNoId(vipNo);
                        vi.SubItems[0].Text = vipNo.VipName;
                    }
                    money += rechargeList[i].ChargeMoney;
                    vi.SubItems.Add(rechargeList[i].ChargeMoney.ToString());
                    if (rechargeList[i].ChargeMoney < 0)
                    {
                        vi.SubItems.Add("扣费");
                    }
                    else
                    {
                        vi.SubItems.Add("充值");
                    }
                    vi.SubItems.Add(rechargeList[i].RechargeTime.ToString());
                    vi.SubItems.Add(user.UserName);
                    chargeGroup.Items.Add(vi);
                    lvMsg.Items.Add(vi);
                }
                vipChargeSum.SubItems[0].Text = "充值总计:";
                vipChargeSum.SubItems.Add(money.ToString());
                vipChargeSum.ForeColor = Color.Red;

                // lvMsg.Items[rechargeList.Count].ForeColor = Color.Red;
            }
            else
            {
                vipChargeSum.SubItems[0].Text = "充值总计:";
                vipChargeSum.SubItems.Add("0");
                vipChargeSum.ForeColor = Color.Red;

            }
            lvMsg.Groups.Add(chargeGroup);

            #endregion

            #region 会员租车收入
            /////会员租车收入
            ListViewItem vipBorrowSum = new ListViewItem();
            ListViewGroup vipGroup = new ListViewGroup();
            vipGroup.Header = "会员租车收入";
            vipGroup.HeaderAlignment = HorizontalAlignment.Center;
            BikeReturn brTemp = new BikeReturn();
            brTemp.DpId = departId;
            brTemp.IsVip = true;
            List<BikeReturn> bikeReturnList = brBLL.BikeReturnSelectByDpIdAndTime(brTemp,beginTime ,endTime );
            if (bikeReturnList != null)
            {
                double money = 0;
                for (int i = 0; i < bikeReturnList.Count; i++)
                {
                    ListViewItem vi = new ListViewItem();
                    VIPInfo vip = new VIPInfo();
                    UserInfo user = new UserInfo();
                    user.UserId = bikeReturnList[i].BBUserId;
                    user = userBLL.SelectUserById(user);
                    vip.VipId = bikeReturnList[i].VipId;
                    vip = vipBLL.VipSelectById(vip);
                    vi.SubItems[0].Text = vip.VipName;
                    vi.SubItems.Add(bikeReturnList[i].BuCost.ToString());
                    vi.SubItems.Add("会员租车");
                    vi.SubItems.Add(bikeReturnList[i].BBTime.ToString());
                    vi.SubItems.Add(user.UserName);
                    money += bikeReturnList[i].BuCost;
                    vipGroup.Items.Add(vi);
                    lvMsg.Items.Add(vi);
                }
                vipBorrowSum.SubItems[0].Text = "会员租车总计:";
                vipBorrowSum.SubItems.Add(money.ToString());
                vipBorrowSum.ForeColor = Color.Red;

            }
            else
            {
                vipBorrowSum.SubItems[0].Text = "会员租车总计:";
                vipBorrowSum.SubItems.Add("0");
                vipBorrowSum.ForeColor = Color.Red;

            }
            lvMsg.Groups.Add(vipGroup);
            lvMsg.ShowGroups = true;
            #endregion



            #region 非会员租车
            ListViewItem vipNoBorrowSum = new ListViewItem();
            ListViewGroup vipNoGroup = new ListViewGroup();
            vipNoGroup.Header = "非会员租车收入";
            vipNoGroup.HeaderAlignment = HorizontalAlignment.Center;
            brTemp.IsVip = false;
            bikeReturnList = brBLL.BikeReturnSelectByDpIdAndTime(brTemp, beginTime ,endTime );
            if (bikeReturnList != null)
            {
                double money = 0;
                for (int i = 0; i < bikeReturnList.Count; i++)
                {
                    ListViewItem vi = new ListViewItem();
                    VipNoInfo vipNo = new VipNoInfo();
                    UserInfo user = new UserInfo();
                    user.UserId = bikeReturnList[i].BBUserId;
                    user = userBLL.SelectUserById(user);
                    vipNo.VipId = bikeReturnList[i].VipId;
                    vipNo = new VipNoBLL().VipNoSelectByVIPNoId(vipNo);
                    vi.SubItems[0].Text = vipNo.VipName;
                    vi.SubItems.Add(bikeReturnList[i].BuCost.ToString());
                    vi.SubItems.Add("非会员租车");
                    vi.SubItems.Add(bikeReturnList[i].BBTime.ToString());
                    try
                    {
                        vi.SubItems.Add(user.UserName);
                    }
                    catch (Exception)
                    {

                    }
                    money += bikeReturnList[i].BuCost;
                    vipNoGroup.Items.Add(vi);
                    lvMsg.Items.Add(vi);
                }
                vipNoBorrowSum.SubItems[0].Text = "非会员租车总计:";
                vipNoBorrowSum.SubItems.Add(money.ToString());
                vipNoBorrowSum.ForeColor = Color.Red;
            }
            else
            {
                vipNoBorrowSum.SubItems[0].Text = "非会员租车总计:";
                vipNoBorrowSum.SubItems.Add("0");
                vipNoBorrowSum.ForeColor = Color.Red;
            }
            lvMsg.Groups.Add(vipNoGroup);
            lvMsg.ShowGroups = true;
            #endregion

            #region 会员租车余额
            /////会员租车余额
            ListViewItem vipp = new ListViewItem();
            vipp.SubItems[0].Text = "会员余额";
            string DpId = cmbDepart.SelectedValue.ToString();
            string s = vipMoneyBLL.vipSumMoneyBalanceByDpId(DpId).ToString();
            vipp.SubItems.Add(s);
            vipp.ForeColor = Color.Red;

            #endregion

            #region 非会员租车余额
            /////非会员租车余额
            ListViewItem vippNot = new ListViewItem();
            vippNot.SubItems[0].Text = "非会员余额";
            vippNot.SubItems.Add(vipMoneyBLL.vipNoSumMoneyBalanceByDpId(DpId).ToString());
            vippNot.ForeColor = Color.Red;
            #endregion

            #region 总计
            ListViewGroup AllMoney = new ListViewGroup();
            AllMoney.Header = "各项总计";
            AllMoney.HeaderAlignment = HorizontalAlignment.Center;
            AllMoney.Items.Add(addVipSum);
            lvMsg.Items.Add(addVipSum);
            AllMoney.Items.Add(vipChargeSum);
            lvMsg.Items.Add(vipChargeSum);
            AllMoney.Items.Add(vipBorrowSum);
            lvMsg.Items.Add(vipBorrowSum);
            AllMoney.Items.Add(vipNoBorrowSum);
            lvMsg.Items.Add(vipNoBorrowSum);
            AllMoney.Items.Add(vipp);
            lvMsg.Items.Add(vipp);
            AllMoney.Items.Add(vippNot);
            lvMsg.Items.Add(vippNot);

            lvMsg.Groups.Add(AllMoney);
            lvMsg.ShowGroups = true;
            #endregion


            lvMsg.EndUpdate();
            btnOk.Enabled = true;
            progressBar1.Visible = false;
        }

        private void TodayIncome_Load(object sender, EventArgs e)
        {
            bg.RunWorkerAsync();
        }
    }
}
