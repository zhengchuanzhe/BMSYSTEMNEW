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
    public partial class VipNoManageWindow : Form
    {
        VipNoInfo vipNoInfo;
        VipNoBLL vipNoBLL;
        bool IsAdmin = false;
        DepartBLL departBLL;
        VipLevelInfo levelInfo;
        VipLevelBLL levelBLL;
        BackgroundWorker bg = new BackgroundWorker();
        string vipNoNM;
        bool IsNameSelect = false;
        public VipNoManageWindow(bool isAdmin)
        {
            InitializeComponent();
            bg.DoWork += new DoWorkEventHandler(bg_DoWork);//异步操作时要做的操作，一般去查列表，这个列表在本页面内先声明，然后在这个dowork方法里去取数填充他
            bg.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bg_RunWorkerCompleted);//这个是取数完成后进行的操作，去到数后，这里取用去到的列表绑定到控件
            vipNoInfo = new VipNoInfo();
            vipNoBLL = new VipNoBLL();
            departBLL = new DepartBLL();
            IsAdmin = isAdmin;
        }

        #region 修改非会员
        private void 修改非会员信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lvVipNo.SelectedItems.Count != 1)
            {
                MessageBox.Show("请选择一行!");
            }
            else
            {
                int id = Convert.ToInt32(lvVipNo.SelectedItems[0].Tag);
                ChangeVipNoWindow changeVipNoWindow = new ChangeVipNoWindow(id);
                changeVipNoWindow.ShowDialog();
                if (IsNameSelect)
                {
                    progressBar1.Visible = true;
                    btnOK.Enabled = false;
                    backgroundWorker2.RunWorkerAsync();
                }
                else
                {
                    progressBar1.Visible = true;
                    btnOK.Enabled = false;
                    backgroundWorker1.RunWorkerAsync();
                }
            }
        }
        #endregion

        #region 删除非会员
        private void BtnDeleteClick(object vipNoInfo)
        {
            this.Invoke(new Action(() =>
            {
                if (vipNoBLL.VipNoDelete(vipNoInfo as VipNoInfo))
                {
                    MessageBox.Show("删除成功！");
                    LogInfo logInfo = new LogInfo();
                    logInfo.UserId = StaticData.userLocal.UserId;
                    logInfo.Content = "删除了非会员‘" + (vipNoInfo as VipNoInfo).VipName + "'的信息";
                    logInfo.LogTime = DateTime.Now;
                    logInfo.DpId = StaticData.departLocal.DpId;
                    bool b = new LogBLL().LogInsert(logInfo);
                    if (IsNameSelect )
                    {
                        progressBar1.Visible = true;
                        btnOK.Enabled = false;
                        backgroundWorker2.RunWorkerAsync();
                    }
                    else
                    {
                        progressBar1.Visible = true;
                        btnOK.Enabled = false;
                        backgroundWorker1.RunWorkerAsync();
                    }
                }
                else
                {
                    MessageBox.Show("删除失败！");
                }
                progressBar1.Visible = true;
            }));
        }
        private void 删除非会员ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lvVipNo.SelectedItems.Count != 1)
            {
                MessageBox.Show("请选择一行!");
            }
            else
            {
                DialogResult result = MessageBox.Show("该操作不可逆，请问您确认删除该会员吗？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.No)
                    return;

                int id = Convert.ToInt32(lvVipNo.SelectedItems[0].Tag);
                string vipNoName = lvVipNo.SelectedItems[0].SubItems[2].Text;
                vipNoInfo = new VipNoInfo();
                vipNoInfo.VipId = id;
                vipNoInfo.VipName = vipNoName;
                Thread th = new Thread(new ParameterizedThreadStart(BtnDeleteClick));
                th.IsBackground = true;
                th.Start(vipNoInfo);
            }
        }
        #endregion

        private void VipNoManageWindow_Load(object sender, EventArgs e)
        {
            bg.RunWorkerAsync();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (txtName .Text .Trim ().Length <=0)
            {
                IsNameSelect = false;
                btnOK.Enabled = false;
                progressBar1.Visible = true;
                selectDpId = (int)cmbDepart.SelectedValue;
                backgroundWorker1.RunWorkerAsync();
            }
            else
            {
                IsNameSelect = true;
                btnOK.Enabled = false;
                progressBar1.Visible = true;
                vipNoNM = txtName.Text.Trim();
                txtName.Text="";
                backgroundWorker2.RunWorkerAsync();
            }
        }
        int selectDpId = 0;
        List<VipNoInfo> vipNoList = new List<VipNoInfo>();
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

            backgroundWorker1.ReportProgress(10);//这里让进度条显示进度
            vipNoInfo.DpId = selectDpId;
            vipNoList = vipNoBLL.VipNoSelectByDPId(vipNoInfo);
            backgroundWorker1.ReportProgress(70);//这里让进度条显示进度
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
           
            levelInfo = new VipLevelInfo();
            levelBLL = new VipLevelBLL();
            if (vipNoList == null) return;
            lvVipNo.BeginUpdate();
            lvVipNo.Items.Clear();
            if (vipNoList .Count <=0)
            {
                lvVipNo.EndUpdate();
                btnOK.Enabled = true;
                progressBar1.Visible = false;
                MessageBox.Show("无非会员信息");
                return;
            }
            VipNoInfo vipNoTemp;
            for (int i = 0; i < vipNoList.Count; i++)
            {
                vipNoTemp = vipNoList[i];
                levelInfo.LvId = vipNoTemp.LvId;
                levelInfo = levelBLL.VipLevelSelectById(levelInfo);
                lvVipNo.Items.Add("");
                lvVipNo.Items[i].SubItems.Add("");
                lvVipNo.Items[i].SubItems.Add("");
                lvVipNo.Items[i].SubItems.Add("");
                lvVipNo.Items[i].SubItems.Add("");
                lvVipNo.Items[i].SubItems.Add("");
                lvVipNo.Items[i].SubItems.Add("");
                lvVipNo.Items[i].SubItems.Add("");
                lvVipNo.Items[i].Tag = vipNoTemp.VipId;
                lvVipNo.Items[i].SubItems[0].Text = vipNoTemp.VipId.ToString();
                lvVipNo.Items[i].SubItems[1].Text = vipNoTemp.VipNumber;
                lvVipNo.Items[i].SubItems[2].Text = vipNoTemp.VipName;
                lvVipNo.Items[i].SubItems[3].Text = vipNoTemp.VipPhone;
                lvVipNo.Items[i].SubItems[4].Text = vipNoTemp.VipCard;
                lvVipNo.Items[i].SubItems[5].Text = levelInfo.LvName;
                lvVipNo.Items[i].SubItems[6].Text = vipNoTemp.AddDate.ToString();
                lvVipNo.Items[i].SubItems[7].Text = vipNoTemp.Mark;
            }
            lvVipNo.EndUpdate();
            btnOK.Enabled = true;
            progressBar1.Visible = false;
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

        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {
            backgroundWorker2.ReportProgress(10);//这里让进度条显示进度
            vipNoList = vipNoBLL.VipNoSelectByVipNoName(vipNoNM );
            backgroundWorker2.ReportProgress(70);//这里让进度条显示进度
        }

        private void backgroundWorker2_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }

        private void backgroundWorker2_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

            levelInfo = new VipLevelInfo();
            levelBLL = new VipLevelBLL();
            if (vipNoList == null) return;
            lvVipNo.BeginUpdate();
            lvVipNo.Items.Clear();
            if (vipNoList.Count <= 0)
            {
                lvVipNo.EndUpdate();
                btnOK.Enabled = true;
                progressBar1.Visible = false;
                MessageBox.Show("无非会员信息");
                return;
            }
            VipNoInfo vipNoTemp;
            for (int i = 0; i < vipNoList.Count; i++)
            {
                vipNoTemp = vipNoList[i];
                levelInfo.LvId = vipNoTemp.LvId;
                levelInfo = levelBLL.VipLevelSelectById(levelInfo);
                lvVipNo.Items.Add("");
                lvVipNo.Items[i].SubItems.Add("");
                lvVipNo.Items[i].SubItems.Add("");
                lvVipNo.Items[i].SubItems.Add("");
                lvVipNo.Items[i].SubItems.Add("");
                lvVipNo.Items[i].SubItems.Add("");
                lvVipNo.Items[i].SubItems.Add("");
                lvVipNo.Items[i].SubItems.Add("");
                lvVipNo.Items[i].Tag = vipNoTemp.VipId;
                lvVipNo.Items[i].SubItems[0].Text = vipNoTemp.VipId.ToString();
                lvVipNo.Items[i].SubItems[1].Text = vipNoTemp.VipNumber;
                lvVipNo.Items[i].SubItems[2].Text = vipNoTemp.VipName;
                lvVipNo.Items[i].SubItems[3].Text = vipNoTemp.VipPhone;
                lvVipNo.Items[i].SubItems[4].Text = vipNoTemp.VipCard;
                lvVipNo.Items[i].SubItems[5].Text = levelInfo.LvName;
                lvVipNo.Items[i].SubItems[6].Text = vipNoTemp.AddDate.ToString();
                lvVipNo.Items[i].SubItems[7].Text = vipNoTemp.Mark; 
            }
            lvVipNo.EndUpdate();
            btnOK.Enabled = true;
            progressBar1.Visible = false;
        }
    }
}
