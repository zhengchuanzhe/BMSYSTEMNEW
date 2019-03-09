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
    public partial class DepartYearFromWindow : Form
    {
        DepartBLL departBLL;
        DepartYearFormBLL departYearFormBLL;
        bool IsAdmin = false;
        BackgroundWorker bg = new BackgroundWorker();
        DateTime startTime;
        DateTime endTime;
        int dpid;
        public DepartYearFromWindow(bool isAdmin)
        {
            InitializeComponent();
            departBLL = new DepartBLL();
            departYearFormBLL = new DepartYearFormBLL();
            IsAdmin = isAdmin;
            bg.DoWork += new DoWorkEventHandler(bg_DoWork);//异步操作时要做的操作，一般去查列表，这个列表在本页面内先声明，然后在这个dowork方法里去取数填充他
            bg.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bg_RunWorkerCompleted);//这个是取数完成后进行的操作，去到数后，这里取用去到的列表绑定到控件
            
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
            cmbDepart.DataSource = departList;
            cmbDepart.DisplayMember = "DpName";
            cmbDepart.ValueMember = "DPID";
            if (!IsAdmin)
            {
                cmbDepart.SelectedValue = StaticData.departLocal.DpId;
                cmbDepart.Enabled = false;
            }
        }


        //private void btnOKClick()
        //{
        //    this.BeginInvoke(new Action(() =>
        //    {
        //        BingDingLV();
        //    }));

        //}
        private void btnOK_Click(object sender, EventArgs e)
        {

            btnOK.Enabled = false ;
            progressBar1.Visible = true;
            startTime = dtpStartTime.Value.Date ;
            endTime = dtpEndTime.Value.Date.AddDays (1) ;
            dpid = int.Parse(cmbDepart.SelectedValue.ToString());
            backgroundWorker1.RunWorkerAsync();
            //Thread th = new Thread(new ThreadStart(btnOKClick));
            //th.IsBackground = true;
            //th.Start();
        }
        List<DepartYearForm> departYearFormList = new List<DepartYearForm>();
        //#region 绑定ListView
        ///// <summary>
        ///// 绑定列表控件
        ///// </summary>
        //public void BingDingLV()
        //{

          
          
        //}
        //#endregion

        private void DepartYearFromWindow_Load(object sender, EventArgs e)
        {
            bg.RunWorkerAsync();
            //Thread th = new Thread(new ThreadStart(FillDp));
            //th.IsBackground = true;
            //th.Start();
        }

        
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            backgroundWorker1.ReportProgress(10);//这里让进度条显示进度
            departYearFormList = departYearFormBLL.DepartYearFormSelectByTime(startTime, endTime, dpid);
            backgroundWorker1.ReportProgress(70);//这里让进度条显示进度
        }
        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
      
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            
            if (departYearFormList == null) return;
            if (departYearFormList.Count == 0)
            {
                MessageBox.Show("未查询到相应报表信息");
                progressBar1.Visible = false;
                btnOK.Enabled = true;
                return;
            }
            lvDepartYearForm.Items.Clear();
            DepartYearForm departYearFormTemp;
            double newVipIncome = 0;
            double vipCharge = 0;
            double vipNoCharge = 0;
            double vipCost = 0;
            double vipNoCost = 0;
            double total = 0;
            for (int i = 0; i < departYearFormList.Count; i++)
            {
                departYearFormTemp = departYearFormList[i];
                lvDepartYearForm.Items.Add("");
                lvDepartYearForm.Items[i].SubItems.Add("");
                lvDepartYearForm.Items[i].SubItems.Add("");
                lvDepartYearForm.Items[i].SubItems.Add("");
                lvDepartYearForm.Items[i].SubItems.Add("");
                lvDepartYearForm.Items[i].SubItems.Add("");
                lvDepartYearForm.Items[i].SubItems.Add("");
                lvDepartYearForm.Items[i].SubItems.Add("");
                lvDepartYearForm.Items[i].SubItems.Add("");
                lvDepartYearForm.Items[i].SubItems.Add("");
                lvDepartYearForm.Items[i].Tag = departYearFormTemp.DyId;
                lvDepartYearForm.Items[i].SubItems[0].Text = departYearFormTemp.DpId.ToString();
                lvDepartYearForm.Items[i].SubItems[1].Text = departYearFormTemp.VipCost.ToString();
                lvDepartYearForm.Items[i].SubItems[2].Text = departYearFormTemp.VipNoCost.ToString();
                lvDepartYearForm.Items[i].SubItems[3].Text = departYearFormTemp.NewVipIncome.ToString();
                lvDepartYearForm.Items[i].SubItems[4].Text = departYearFormTemp.VipCharge.ToString();
                lvDepartYearForm.Items[i].SubItems[5].Text = departYearFormTemp.VipNoCharge.ToString();
                lvDepartYearForm.Items[i].SubItems[6].Text = departYearFormTemp.Time.ToString();
                lvDepartYearForm.Items[i].SubItems[7].Text = departYearFormTemp.Total.ToString();
                newVipIncome += departYearFormTemp.NewVipIncome;
                vipCharge += departYearFormTemp.VipCharge;
                vipNoCharge += departYearFormTemp.VipNoCharge;
                vipCost += departYearFormTemp.VipCost;
                vipNoCost += departYearFormTemp.VipNoCost;
                total += departYearFormTemp.Total;
            }

            ListViewItem vipFormSum = new ListViewItem();
            vipFormSum.SubItems[0].Text = "总计";
            vipFormSum.SubItems.Add(vipCost.ToString());
            vipFormSum.SubItems.Add(vipNoCost.ToString());
            vipFormSum.SubItems.Add(newVipIncome.ToString());
            vipFormSum.SubItems.Add(vipCharge.ToString());
            vipFormSum.SubItems.Add(vipNoCharge.ToString());
            vipFormSum.SubItems.Add("");
            vipFormSum.SubItems.Add(total.ToString());
            vipFormSum.ForeColor = Color.Red;
            lvDepartYearForm.Items.Add(vipFormSum);

            progressBar1.Visible = false;
            btnOK.Enabled = true ;
        }


    }
}
