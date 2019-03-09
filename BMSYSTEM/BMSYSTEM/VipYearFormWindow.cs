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
    public partial class VipYearFormWindow : Form
    {
        DepartBLL departBLL;
        VipYearFormBLL vipYearFormBLL;
        private bool IsAdmin = false;
        BackgroundWorker bg = new BackgroundWorker();
        DateTime startTime;
        DateTime endTime;
        int dpid;
        public VipYearFormWindow(bool isAdmin)
        {
            InitializeComponent();
            bg.DoWork += new DoWorkEventHandler(bg_DoWork);//异步操作时要做的操作，一般去查列表，这个列表在本页面内先声明，然后在这个dowork方法里去取数填充他
            bg.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bg_RunWorkerCompleted);//这个是取数完成后进行的操作，去到数后，这里取用去到的列表绑定到控件
            departBLL = new DepartBLL();
            vipYearFormBLL = new VipYearFormBLL();
            IsAdmin = isAdmin;
        }
        #region 确认按钮点击事件
        private void btnOK_Click(object sender, EventArgs e)
        {
            btnOK.Enabled = false;
            progressBar1.Visible = true;
            startTime = dtpStartTime.Value.Date ;
            endTime = dtpEndTime.Value.Date.AddDays (1) ;
            dpid = int.Parse(cmbDepart.SelectedValue.ToString());
            backgroundWorker1.RunWorkerAsync();
        }
        #endregion
        private void VipYearFormWindow_Load(object sender, EventArgs e)
        {
            bg.RunWorkerAsync();
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

        List<VipYearForm> vipYearFormList = new List<VipYearForm>();
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            backgroundWorker1.ReportProgress(10);//这里让进度条显示进度
            vipYearFormList = vipYearFormBLL.VipYearFormSelectByTime(startTime, endTime, dpid);
            backgroundWorker1.ReportProgress(70);//这里让进度条显示进度
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (vipYearFormList == null) 
            { 
                MessageBox.Show("未查询到相应报表信息");
                progressBar1.Visible = false;
                btnOK.Enabled = true;
                return;
            }
            if (vipYearFormList.Count == 0)
            {
                MessageBox.Show("未查询到相应报表信息");
                progressBar1.Visible = false;
                btnOK.Enabled = true ;
                return;
            }
            double VipCost = 0;
            int VipTimes = 0;

            lvVipYearForm.BeginUpdate();
            lvVipYearForm.Items.Clear();
            VipYearForm vipYearFormTemp;
            for (int i = 0; i < vipYearFormList.Count; i++)
            {
                vipYearFormTemp = vipYearFormList[i];
                lvVipYearForm.Items.Add(vipYearFormTemp.VipId.ToString());
                lvVipYearForm.Items[i].SubItems.Add(vipYearFormTemp.VyCost.ToString());
                lvVipYearForm.Items[i].SubItems.Add(vipYearFormTemp.VyTimes.ToString());
                lvVipYearForm.Items[i].SubItems.Add(vipYearFormTemp.Time.ToString());
                lvVipYearForm.Items[i].SubItems.Add("");
                lvVipYearForm.Items[i].Tag = vipYearFormTemp.VyId;
                VipCost += vipYearFormTemp.VyCost;
                VipTimes += vipYearFormTemp.VyTimes;
            }
            ListViewItem vipFormSum = new ListViewItem();
            vipFormSum.SubItems[0].Text = "总计";
            vipFormSum.SubItems.Add(VipCost .ToString ());
            vipFormSum.SubItems.Add(VipTimes.ToString());
            vipFormSum.SubItems.Add("");
            vipFormSum.ForeColor = Color.Red;
            lvVipYearForm.Items.Add(vipFormSum );

            lvVipYearForm.EndUpdate();
            progressBar1.Visible = false;
            btnOK.Enabled = true ;
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
