using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BIKEBLL;
using MODEL;
using System.Threading;

namespace BMSYSTEM
{
    public partial class LogWindow : Form
    {
        LogInfo logInfo;
        LogBLL logBLL;
        List<LogInfo> logList;
        BackgroundWorker bg = new BackgroundWorker();
        DateTime start;
        DateTime end;
        int dpid;
        UserBLL userBLL;
        public LogWindow(bool isAdmin)
        {
            InitializeComponent();
            logInfo = new LogInfo();
            logBLL = new LogBLL();
            logList = new List<LogInfo>();
            userBLL = new UserBLL();
            FillDp();
            bg.DoWork += new DoWorkEventHandler(bg_DoWork);//异步操作时要做的操作，一般去查列表，这个列表在本页面内先声明，然后在这个dowork方法里去取数填充他
            bg.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bg_RunWorkerCompleted);//这个是取数完成后进行的操作，去到数后，这里取用去到的列表绑定到控件
            if (!isAdmin)
            {
                cmbDepart.Enabled = false;
            }
        }
        private void FillTime()
        {

        }


        public static List<DepartInfo> departList;
        void bg_DoWork(object sender, DoWorkEventArgs e)
        {
            DepartBLL departBLL = new DepartBLL();
            departList = departBLL.DepartSelect();
        }
        void bg_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            FillDp();
        }
        private void FillDp()
        {
            cmbDepart.DataSource = departList;
            cmbDepart.ValueMember = "DPID";
            cmbDepart.DisplayMember = "DPNAME";
            cmbDepart.SelectedValue = StaticData.departLocal.DpId;
        }
        private void btnOK_Click(object sender, EventArgs e)
        {

            start = dtpStartTime.Value.Date;
            end = dtpEndTime.Value.Date .AddDays (1);
            if (start > end)
            {
                MessageBox.Show("开始时间大于结束时间!");
                return;
            }
            progressBar1.Visible = true;
            btnOK.Enabled = false;
            dpid = Int32.Parse(cmbDepart.SelectedValue.ToString());
            backgroundWorker1.RunWorkerAsync();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            backgroundWorker1.ReportProgress(10);//这里让进度条显示进度
            logList = logBLL.SelectLogByDpId(dpid, start, end);
            backgroundWorker1.ReportProgress(70);//这里让进度条显示进度
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

            if (logList == null || logList.Count == 0)
            {
                MessageBox.Show("没有查找到相应信息!");
                progressBar1.Visible = false;
                btnOK.Enabled = true;
                return;
            }
            lvMessage.BeginUpdate();
            lvMessage.Items.Clear();
            UserInfo userTemp = new UserInfo();
            for (int i = 0; i < logList.Count; i++)
            {
                lvMessage.Items.Add("");
                lvMessage.Items[i].SubItems.Add("");
                lvMessage.Items[i].SubItems.Add("");
                lvMessage.Items[i].SubItems.Add("");
                lvMessage.Items[i].SubItems.Add("");
                lvMessage.Items[i].SubItems[0].Text = logList[i].LogId.ToString();
                userTemp.UserId = logList[i].UserId;
                userTemp = userBLL.SelectUserById(userTemp);
                lvMessage.Items[i].SubItems[1].Text = userTemp.UserName;
                lvMessage.Items[i].SubItems[2].Text = logList[i].LogTime.ToString();
                lvMessage.Items[i].SubItems[3].Text = logList[i].Content;
            }
            lvMessage.EndUpdate();
            progressBar1.Visible = false;
            btnOK.Enabled = true;
        }

        private void LogWindow_Load(object sender, EventArgs e)
        {
            bg.RunWorkerAsync();
        }
    }
}
