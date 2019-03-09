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
using System.Management;
using System.Threading;

namespace BMSYSTEM
{
    public partial class VipManageWindow : Form
    {
        public VIPInfo vipModel;
        public VipBLL vipBLL;
        public DepartBLL departBLL;
        private DepartInfo departInfo;
        public VipLevelBLL levelBLL;
        private VipLevelInfo levelInfo;
        private VipMoney moneyTemp;
        private VipMoneyBLL moneyBLL;
        bool IsAdmin = false;
        bool IsNameSelect = false;
        string vipNM;
        BackgroundWorker bg = new BackgroundWorker();
        #region 类初始化
        public VipManageWindow(bool isAdmin)
        {
            InitializeComponent();
            bg.DoWork += new DoWorkEventHandler(bg_DoWork);//异步操作时要做的操作，一般去查列表，这个列表在本页面内先声明，然后在这个dowork方法里去取数填充他
            bg.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bg_RunWorkerCompleted);//这个是取数完成后进行的操作，去到数后，这里取用去到的列表绑定到控件
            vipModel = new VIPInfo();
            vipBLL = new VipBLL();
            departBLL = new DepartBLL();
            departInfo = new DepartInfo();
            levelBLL = new VipLevelBLL();
            levelInfo = new VipLevelInfo();
            moneyTemp = new VipMoney();
            moneyBLL = new VipMoneyBLL();
            IsAdmin = isAdmin;

        }
        #endregion

        //this.Invoke(new Action(() =>
        //   {

        //   }));




        #region 窗体加载
        private void VipManageWindow_Load(object sender, EventArgs e)
        {

            bg.RunWorkerAsync();

        }
        #endregion

        #region 修改会员信息
        private void 修改会员信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lvVip.SelectedItems.Count != 1)
            {
                MessageBox.Show("请选择一行!");
            }
            else
            {
                checkPassword2 chPWD = new checkPassword2((lvVip.SelectedItems[0].Tag as VIPInfo ).VipPWD );
                chPWD.ShowDialog();
                if (!chPWD .isTrue )
                {
                    MessageBox.Show("验证密码错误，无法进行修改操作！");
                    return;
                }

                int id = Convert.ToInt32((lvVip.SelectedItems[0].Tag as VIPInfo ).VipId );
                ChangeVipWindow changeVipWindow = new ChangeVipWindow(id);
                changeVipWindow.ShowDialog();
                if (IsNameSelect)
                {
                    btnOK.Enabled = false;
                    progressBar1.Visible = true;
                    backgroundWorker2.RunWorkerAsync();
                }
                else
                {
                    btnOK.Enabled = false;
                    progressBar1.Visible = true;
                    backgroundWorker1.RunWorkerAsync();
                }
            }
        }
        #endregion

        #region 删除会员
        private void BtnDeleteClick(object vipInfo)
        {
            this.Invoke(new Action(() =>
             {
                 VIPInfo v = new VIPInfo();
                 v = vipInfo as VIPInfo;
                 if (vipBLL.VipDelete(v))
                 {
                     MessageBox.Show("删除成功！");
                     LogInfo logInfo = new LogInfo();
                     logInfo.UserId = StaticData.userLocal.UserId;
                     logInfo.Content = "删除了会员‘" + (vipInfo as VIPInfo).VipName + "'";
                     logInfo.LogTime = DateTime.Now;
                     logInfo.DpId = StaticData.departLocal.DpId;
                     bool b = new LogBLL().LogInsert(logInfo);
                     if (IsNameSelect)
                     {
                         btnOK.Enabled = false;
                         progressBar1.Visible = true;
                         backgroundWorker2.RunWorkerAsync();
                     }
                     else
                     {
                         btnOK.Enabled = false;
                         progressBar1.Visible = true;
                         backgroundWorker1.RunWorkerAsync();
                     }
                 }
                 else
                 {
                     MessageBox.Show("删除失败！");
                 }
             }));

        }
        private void 删除会员ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lvVip.SelectedItems.Count != 1)
            {
                MessageBox.Show("请选择一行!");
            }
            else
            {
                if (!IsAdmin)
                {
                    MessageBox.Show("您无此权限");
                    return;
                }
                DialogResult result = MessageBox.Show("该操作不可逆，请问您确认删除该会员吗？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.No)
                    return;
                int id =(lvVip.SelectedItems[0].Tag as VIPInfo).VipId ;
                string vipName = lvVip.SelectedItems[0].SubItems[3].Text;
                VIPInfo vipInfo = new VIPInfo();
                vipInfo.VipId = id;
                vipInfo.VipName = vipName;
                Thread th = new Thread(new ParameterizedThreadStart(BtnDeleteClick));
                th.IsBackground = true;
                th.Start(vipInfo);
            }
        }
        #endregion

        int selectDpId = 0;
        List<VIPInfo> vipList = new List<VIPInfo>();
        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtVipName.Text.Trim().Length <= 0)
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
                    vipNM = txtVipName.Text.Trim();
                    backgroundWorker2.RunWorkerAsync();
                    txtVipName.Text = "";
                }
            }
            catch (Exception)
            {
                MessageBox.Show("网络太差，无法取出信息！");
            }        
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            backgroundWorker1.ReportProgress(10);//这里让进度条显示进度
            vipList = vipBLL.VipSelectByDpId(selectDpId);
            backgroundWorker1.ReportProgress(70);//这里让进度条显示进度
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

            lvVip.BeginUpdate();
            lvVip.Items.Clear();
            VIPInfo vipTemp;
            labCount.Text = vipList.Count.ToString();
            if (vipList.Count <= 0)
            {
                lvVip.EndUpdate();
                MessageBox.Show("无会员信息");
                progressBar1.Visible = false;
                btnOK.Enabled = true;
                return;
            }
            for (int i = 0; i < vipList.Count; i++)
            {
                vipTemp = vipList[i];
                levelInfo.LvId = vipTemp.VipLevelId;
                levelInfo = levelBLL.VipLevelSelectById(levelInfo);
                moneyTemp.VipId = vipTemp.VipId;
                moneyTemp.IsVip = true;
                moneyTemp = moneyBLL.VipMoneySelectByVipId(moneyTemp);
                lvVip.Items.Add("");
                lvVip.Items[i].SubItems.Add("");
                lvVip.Items[i].SubItems.Add("");
                lvVip.Items[i].SubItems.Add("");
                lvVip.Items[i].SubItems.Add("");
                lvVip.Items[i].SubItems.Add("");
                lvVip.Items[i].SubItems.Add("");
                lvVip.Items[i].SubItems.Add("");
                lvVip.Items[i].SubItems.Add("");
                lvVip.Items[i].SubItems.Add("");
                lvVip.Items[i].SubItems.Add("");
                lvVip.Items[i].SubItems.Add("");
                lvVip.Items[i].SubItems.Add("");
                lvVip.Items[i].SubItems.Add("");
                lvVip.Items[i].Tag = vipTemp;
                lvVip.Items[i].SubItems[0].Text = vipTemp.VipId.ToString();
                lvVip.Items[i].SubItems[1].Text = vipTemp.VipNumber;
                lvVip.Items[i].SubItems[2].Text = vipTemp.VipName;
                lvVip.Items[i].SubItems[3].Text = moneyTemp.VmBalance.ToString();
                lvVip.Items[i].SubItems[4].Text = moneyTemp.Integral.ToString();
                lvVip.Items[i].SubItems[5].Text = levelInfo.LvName;
                lvVip.Items[i].SubItems[6].Text = vipTemp.VipSex == true ? "男" : "女";
                lvVip.Items[i].SubItems[7].Text = vipTemp.VipPhone;
                lvVip.Items[i].SubItems[8].Text = vipTemp.VipCard;
                lvVip.Items[i].SubItems[9].Text = vipTemp.VipBirthDay.ToShortDateString();
                lvVip.Items[i].SubItems[10].Text = vipTemp.VipAddress;
                lvVip.Items[i].SubItems[11].Text = vipTemp.AddDate.ToString();
                lvVip.Items[i].SubItems[12].Text = vipTemp.Mark;
                lvVip.Items[i].SubItems.Add(vipTemp .VipPWD );
            }
            lvVip.EndUpdate();
            progressBar1.Visible = false;
            btnOK.Enabled = true;
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
            cmbDepart.SelectedValue = StaticData.departLocal.DpId;
        }

        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {
            backgroundWorker2.ReportProgress(10);//这里让进度条显示进度
            vipList = vipBLL.VipSelectByName(vipNM);
            backgroundWorker2.ReportProgress(70);//这里让进度条显示进度
        }

        private void backgroundWorker2_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }

        private void backgroundWorker2_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

            lvVip.BeginUpdate();
            lvVip.Items.Clear();
            VIPInfo vipTemp;
            if (vipList.Count <= 0)
            {
                lvVip.EndUpdate();
                MessageBox.Show("无会员信息");
                progressBar1.Visible = false;
                btnOK.Enabled = true;
                return;
            }
            for (int i = 0; i < vipList.Count; i++)
            {
                vipTemp = vipList[i];
                levelInfo.LvId = vipTemp.VipLevelId;
                levelInfo = levelBLL.VipLevelSelectById(levelInfo);
                moneyTemp.VipId = vipTemp.VipId;
                moneyTemp.IsVip = true;
                moneyTemp = moneyBLL.VipMoneySelectByVipId(moneyTemp);
                lvVip.Items.Add("");
                lvVip.Items[i].SubItems.Add("");
                lvVip.Items[i].SubItems.Add("");
                lvVip.Items[i].SubItems.Add("");
                lvVip.Items[i].SubItems.Add("");
                lvVip.Items[i].SubItems.Add("");
                lvVip.Items[i].SubItems.Add("");
                lvVip.Items[i].SubItems.Add("");
                lvVip.Items[i].SubItems.Add("");
                lvVip.Items[i].SubItems.Add("");
                lvVip.Items[i].SubItems.Add("");
                lvVip.Items[i].SubItems.Add("");
                lvVip.Items[i].SubItems.Add("");
                lvVip.Items[i].SubItems.Add("");
                lvVip.Items[i].Tag = vipTemp;
                lvVip.Items[i].SubItems[0].Text = vipTemp.VipId.ToString();
                lvVip.Items[i].SubItems[1].Text = vipTemp.VipNumber;
                lvVip.Items[i].SubItems[2].Text = vipTemp.VipName;
                lvVip.Items[i].SubItems[3].Text = moneyTemp.VmBalance.ToString();
                lvVip.Items[i].SubItems[4].Text = moneyTemp.Integral.ToString();
                lvVip.Items[i].SubItems[5].Text = levelInfo.LvName;
                lvVip.Items[i].SubItems[6].Text = vipTemp.VipSex == true ? "男" : "女";
                lvVip.Items[i].SubItems[7].Text = vipTemp.VipPhone;
                lvVip.Items[i].SubItems[8].Text = vipTemp.VipCard;
                lvVip.Items[i].SubItems[9].Text = vipTemp.VipBirthDay.ToShortDateString();
                lvVip.Items[i].SubItems[10].Text = vipTemp.VipAddress;
                lvVip.Items[i].SubItems[11].Text = vipTemp.AddDate.ToString();
                lvVip.Items[i].SubItems[12].Text = vipTemp.Mark;
            }
            lvVip.EndUpdate();
            progressBar1.Visible = false;
            btnOK.Enabled = true;
        }
    }
}
