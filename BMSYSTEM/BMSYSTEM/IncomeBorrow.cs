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
    public partial class IncomeBorrow : Form
    {
        DepartBLL departBLL;
        bool IsAdmin = false;
        VipMoneyBLL vipMoneyBLL;
        UserBLL userBLL;
        VipBLL vipBLL;
        VipNoBLL vipNoBLL;
        BackgroundWorker bg = new BackgroundWorker();
        DateTime startTime;
        DateTime endTime;
        int dpid;
        RechargeInfo rechargeInfo;

        public IncomeBorrow(bool isAdmin)
        {
            InitializeComponent();

            bg.DoWork += new DoWorkEventHandler(bg_DoWork);//异步操作时要做的操作，一般去查列表，这个列表在本页面内先声明，然后在这个dowork方法里去取数填充他
            bg.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bg_RunWorkerCompleted);//这个是取数完成后进行的操作，去到数后，这里取用去到的列表绑定到控件

            departBLL = new DepartBLL();
            vipMoneyBLL = new VipMoneyBLL();
            userBLL = new UserBLL();
            vipBLL = new VipBLL();
            vipNoBLL = new VipNoBLL();
            IsAdmin = isAdmin;
            rechargeInfo = new RechargeInfo();
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





        private void IncomeBorrow_Load(object sender, EventArgs e)
        {
            bg.RunWorkerAsync();
        }

        List<RechargeInfo> rechargeList = new List<RechargeInfo>();
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

            backgroundWorker1.ReportProgress(10);//这里让进度条显示进度
            rechargeList = vipMoneyBLL.RechargeInfoSelect(startTime, endTime, rechargeInfo);
            backgroundWorker1.ReportProgress(70);//这里让进度条显示进度

        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            lvMsg.BeginUpdate();
            lvMsg.Items.Clear();
            if (rechargeList.Count == 0)
            {
                MessageBox.Show("无充值记录");
                lvMsg.EndUpdate();
                progressBar1.Visible = false;
                btnOk.Enabled = true;
                return;
            }
            if (rechargeList.Count != 0)
            {

                for (int i = 0; i < rechargeList.Count; i++)
                {
                    UserInfo user = new UserInfo();
                    user.UserId = rechargeList[i].UserId;
                    user = userBLL.SelectUserById(user);
                    DepartInfo depart = new DepartInfo();
                    depart.DpId = rechargeList[i].DepartId;
                    depart = departBLL.DepartSelectById(depart);
                    lvMsg.Items.Add("");
                    if (rechargeList[i].IsVip)
                    {
                        VIPInfo vip = new VIPInfo();
                        vip.VipId = rechargeList[i].VipId;
                        lvMsg.Items[i].SubItems[0].Text = vipBLL.VipSelectById(vip).VipName;
                    }
                    else
                    {
                        VipNoInfo vip = new VipNoInfo();
                        vip.VipId = rechargeList[i].VipId;
                        lvMsg.Items[i].SubItems[0].Text = vipNoBLL.VipNoSelectByVIPNoId(vip).VipName;
                    }
                    lvMsg.Items[i].SubItems.Add(rechargeList[i].ChargeMoney.ToString());
                    lvMsg.Items[i].SubItems.Add(user.UserName);
                    lvMsg.Items[i].SubItems.Add(rechargeList[i].RechargeTime.ToString());
                    lvMsg.Items[i].SubItems.Add(depart.DpName);
                }
            }
            lvMsg.EndUpdate();
            progressBar1.Visible = false;
            btnOk.Enabled = true;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            progressBar1.Visible = true;
            btnOk.Enabled = false;
            UserInfo user = new UserInfo();
            dpid = int.Parse(cmbDepart.SelectedValue.ToString());
            int departId = Int32.Parse(cmbDepart.SelectedValue.ToString());
            startTime = dtpBegin.Value.Date ;
            endTime = dtpEnd.Value.Date .AddDays (1);
            rechargeInfo = new RechargeInfo();
            rechargeInfo.DepartId = departId;
            backgroundWorker1.RunWorkerAsync();
        }
    }
}
