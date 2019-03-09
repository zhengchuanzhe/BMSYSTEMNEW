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
    public partial class DepartMonthFormWindow : Form
    {
        DepartBLL departBLL;
        DepartMonthFormBLL departMonthFormBLL;
        bool IsAdmin = false;
        BackgroundWorker bg = new BackgroundWorker();

        public static List<DepartInfo> departList;
        public DepartMonthFormWindow(bool isAdmin)
        {
            InitializeComponent();
            bg.DoWork += new DoWorkEventHandler(bg_DoWork);//异步操作时要做的操作，一般去查列表，这个列表在本页面内先声明，然后在这个dowork方法里去取数填充他
            bg.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bg_RunWorkerCompleted);//这个是取数完成后进行的操作，去到数后，这里取用去到的列表绑定到控件
            departBLL = new DepartBLL();
            departMonthFormBLL = new DepartMonthFormBLL();
            IsAdmin = isAdmin;
        }

        void bg_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            FillDp();
        }
        private void FillDp()
        {
            //this.Invoke(new Action(() =>
            //{
            //    cmbDepart.DataSource = departBLL.DepartSelect();
            //    cmbDepart.DisplayMember = "DpName";
            //    cmbDepart.ValueMember = "DPID";
            //    if (!IsAdmin)
            //    {
            //        cmbDepart.SelectedValue = StaticData.departLocal.DpId;
            //        cmbDepart.Enabled = false;
            //    }
            //}));
            cmbDepart.DataSource = departList;
            cmbDepart.DisplayMember = "DpName";
            cmbDepart.ValueMember = "DPID";
            if (!IsAdmin)
            {
                cmbDepart.SelectedValue = StaticData.departLocal.DpId;
                cmbDepart.Enabled = false;
            }
        }

        #region 确认按钮点击事件
        private void btnOKClick()
        {
            BingDingLV();
        }
        DateTime startTime;
        DateTime endTime;
        int dpid;
        private void btnOK_Click(object sender, EventArgs e)
        {
            btnOK.Enabled = false;
            progressBar1.Visible = true;
            startTime = dtpStartTime.Value.Date;
            endTime = dtpEndTime.Value;
            endTime = endTime.Date.AddDays(1);
            dpid = int.Parse(cmbDepart.SelectedValue.ToString());
            backgroundWorker1.RunWorkerAsync();
            //Thread th = new Thread(new ThreadStart(btnOKClick));
            //th.IsBackground = true;
            //th.Start();
        }

        void bg_DoWork(object sender, DoWorkEventArgs e)
        {
            departList = departBLL.DepartSelect();
        }
        #endregion

        #region 绑定ListView
        /// <summary>
        /// 绑定列表控件
        /// </summary>
        public void BingDingLV()
        {
            this.Invoke(new Action(() =>
            {


            }));
        }
        #endregion

        private void DepartMonthFormWindow_Load(object sender, EventArgs e)
        {
            bg.RunWorkerAsync();
            //Thread th = new Thread(new ThreadStart(FillDp));
            //th.IsBackground = true;
            //th.Start();
        }
        List<DepartMonthForm> departMonthFormList = new List<DepartMonthForm>();
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            backgroundWorker1.ReportProgress(10);//这里让进度条显示进度
            departMonthFormList = departMonthFormBLL.DepartMonthFormSelectByTime(startTime, endTime, dpid);
            backgroundWorker1.ReportProgress(70);//这里让进度条显示进度
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            progressBar1.Visible = false;
            if (departMonthFormList == null) return;
            if (departMonthFormList.Count == 0)
            {
                MessageBox.Show("未查询到相应报表信息");
                btnOK.Enabled = true;
                return;
            }
            this.lvDepartMonthForm.BeginUpdate();
            lvDepartMonthForm.Items.Clear();
            DepartMonthForm departMonthFormTemp;
            double newVipIncome = 0;
            double vipCharge = 0;
            double vipNoCharge = 0;
            double vipCost = 0;
            double vipNoCost = 0;
            double vipBalance = 0;
            double vipNoBalance = 0;
            double total = 0;
            for (int i = 0; i < departMonthFormList.Count; i++)
            {
                departMonthFormTemp = departMonthFormList[i];
                lvDepartMonthForm.Items.Add(departMonthFormTemp.DpId.ToString());
                lvDepartMonthForm.Items[i].SubItems.Add(departMonthFormTemp.NewVipIncom.ToString());
                lvDepartMonthForm.Items[i].SubItems.Add(departMonthFormTemp.VipCharge.ToString());
                lvDepartMonthForm.Items[i].SubItems.Add(departMonthFormTemp.VipNoCharge.ToString());
                lvDepartMonthForm.Items[i].SubItems.Add(departMonthFormTemp.VipCost.ToString());
                lvDepartMonthForm.Items[i].SubItems.Add(departMonthFormTemp.VipNoCost.ToString());
                lvDepartMonthForm.Items[i].SubItems.Add(departMonthFormTemp.VipBalance.ToString());
                lvDepartMonthForm.Items[i].SubItems.Add(departMonthFormTemp.VipNoBalancel.ToString());
                lvDepartMonthForm.Items[i].SubItems.Add(departMonthFormTemp.Time.ToString());
                lvDepartMonthForm.Items[i].SubItems.Add(departMonthFormTemp.Total.ToString());
                lvDepartMonthForm.Items[i].Tag = departMonthFormTemp.DmId;
                newVipIncome += departMonthFormTemp.NewVipIncom;
                vipCharge += departMonthFormTemp.VipCharge;
                vipNoCharge += departMonthFormTemp.VipNoCharge;
                vipCost += departMonthFormTemp.VipCost;
                vipNoCost += departMonthFormTemp.VipNoCost;
                vipBalance = departMonthFormTemp.VipBalance;
                vipNoBalance = departMonthFormTemp.VipNoBalancel;
                total += departMonthFormTemp.Total;
                //lvDepartMonthForm.Items[i].SubItems[0].Text = departMonthFormTemp.DpId.ToString();
                //lvDepartMonthForm.Items[i].SubItems[1].Text = departMonthFormTemp.VipCost.ToString();
                //lvDepartMonthForm.Items[i].SubItems[2].Text = departMonthFormTemp.VipNoCost.ToString();
                //lvDepartMonthForm.Items[i].SubItems[3].Text = (departMonthFormTemp.VipCost + departMonthFormTemp.VipNoCost).ToString();
                //lvDepartMonthForm.Items[i].SubItems[4].Text = departMonthFormTemp.Time.ToString();
            }
            ListViewItem vipFormSum = new ListViewItem();
            vipFormSum.SubItems[0].Text = "总计";
            vipFormSum.SubItems.Add(newVipIncome.ToString());
            vipFormSum.SubItems.Add(vipCharge.ToString());
            vipFormSum.SubItems.Add(vipNoCharge.ToString());
            vipFormSum.SubItems.Add(vipCost.ToString());
            vipFormSum.SubItems.Add(vipNoCost.ToString());
            vipFormSum.SubItems.Add(vipBalance.ToString());
            vipFormSum.SubItems.Add(vipNoBalance.ToString());
            vipFormSum.SubItems.Add("");
            vipFormSum.SubItems.Add(total.ToString());
            vipFormSum.ForeColor = Color.Red;
            lvDepartMonthForm.Items.Add(vipFormSum);

            this.lvDepartMonthForm.EndUpdate();
            btnOK.Enabled = true;
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }
    }
}
