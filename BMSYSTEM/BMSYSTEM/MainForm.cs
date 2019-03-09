using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Management;
using MODEL;
using BIKEBLL;
using System.IO;
using System.Threading;

namespace BMSYSTEM
{
    public partial class MainForm : Form
    {
        int DPId;
        DepartInfo depart;
        DepartBLL departBLL;
        VipBorrowBLL vipBorrowBLL;
        VipNoBorrowBLL vipNoBorrowBLL;
        BikeReturnBLL bikeReturnBLL;
        VipBLL vipBLL;
        VipNoBLL vipNoBLL;
        List<VipBorrowInfo> vipBorrowList = new List<VipBorrowInfo>();
        List<VipNoBorrow> vipNoBorrowList = new List<VipNoBorrow>();
        DateTime startTime = DateTime.Now.Date;
        DateTime endTime = DateTime.Now;
        BackgroundWorker bg = new BackgroundWorker();
        string[] borrowKind = new string[] { "未知", "日租", "月租", "年租" };
        List<VIPInfo> vipBirthList = new List<VIPInfo>();
        private delegate void CompeleteDelete();
        public MainForm()
        {
            InitializeComponent();
            //bg.DoWork += new DoWorkEventHandler(bg_DoWork);//异步操作时要做的操作，一般去查列表，这个列表在本页面内先声明，然后在这个dowork方法里去取数填充他
            //bg.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bg_RunWorkerCompleted);//这个是取数完成后进行的操作，去到数后，这里取用去到的列表绑定到控件
            this.FormClosing += new FormClosingEventHandler(MainForm_FormClosing);
            vipNoBLL = new VipNoBLL();
            vipBLL = new VipBLL();
            bikeReturnBLL = new BikeReturnBLL();
        }
        private void getVipList()
        {
            vipBirthList = vipBLL.VipSelectByDpId(StaticData.departLocal.DpId);
            if (vipBirthList == null) return;
            txtBirth.BeginInvoke(new CompeleteDelete(Compelete));
        }
        private void Compelete()
        {
            DateTime now = DateTime.Now;
            for (int i = 0; i < vipBirthList.Count; i++)
            {
                DateTime birthDay = vipBirthList[i].VipBirthDay;
                if (birthDay.Month == now.Month && birthDay.Day == now.Day)
                {
                    txtBirth.Text += "卡号:[" + vipBirthList[i].VipNumber + " " + vipBirthList[i].VipName + "]";
                }
            }
        }
        void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
        private void 充值系统ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }



        public static List<DepartInfo> departList;
       
        #region 窗体加载
        private void MainForm_Load(object sender, EventArgs e)
        { 
            depart = new DepartInfo();
            departBLL = new DepartBLL();
            lbDpName.Text = StaticData.departLocal.DpName;
            lbDpAddress.Text = StaticData.departLocal.DpPlace;
            DPId = StaticData.departLocal.DpId;
            vipBorrowBLL = new VipBorrowBLL();
            vipBLL = new VipBLL();
            vipNoBorrowBLL = new VipNoBorrowBLL();
            rbtnBorrow.Checked = true;
            ////绑定分店
            //departList = departBLL.DepartSelect();
            //cmbDepart.DataSource = departList;
            //cmbDepart.DisplayMember = "DpName";
            //cmbDepart.ValueMember = "DPID";
            //cmbDepart.SelectedValue = StaticData.departLocal.DpId;
            // BingDingLV();
            lbUserName.Text = "登录用户：" + StaticData.userLocal.UserName;
            lbUserPhone.Text = "用户电话：" + StaticData.userLocal.UserPhone;
            DepartInfo departInfo = new DepartInfo();
            departInfo.DpId = StaticData.userLocal.DpId;
            departInfo = new DepartBLL().DepartSelectById(departInfo);
            lbDPID.Text = "所属分店：" + departInfo.DpName;
            try
            {
                MemoryStream stream = new MemoryStream(StaticData.userLocal.UserPhoto, true);
                stream.Write(StaticData.userLocal.UserPhoto, 0, StaticData.userLocal.UserPhoto.Length);
                picUser.Image = new Bitmap(stream);
                picUser.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            catch (Exception ex)
            {
            }
            Thread th = new Thread(new ThreadStart(getVipList));
            th.IsBackground = true;
            th.Start();
        }
        #endregion



        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        #region 搜索按钮点击事件
        private delegate void BinDing();
        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                DPId = StaticData.departLocal.DpId;
                btnSearch.Enabled = false;
                startTime = DateTime.Now.Date;
                endTime = DateTime.Now;
                if (rbtnBorrow.Checked == true)
                {
                    progressBar1.Visible = true;
                    backgroundWorker1.RunWorkerAsync();
                }
                else if (rbtnReturn.Checked == true)
                {
                    progressBar2.Visible = true;
                    backgroundWorker2.RunWorkerAsync();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("网络差无法取出");
            }
        }

        #endregion

        #region 管理系统菜单

        #region 添加会员
        private void 添加会员ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CheckMiGo miGo = new CheckMiGo();
            miGo.ShowDialog();
            if (miGo.isTrue)
            {
                if (miGo.DpId == StaticData.departLocal.DpId || miGo.isAdmin)
                {
                    AddVipWindow addVip = new AddVipWindow();
                    addVip.Show();
                }
                else
                {
                    MessageBox.Show("加密狗验证正确，但该加密狗不能管理该分店!");
                }
            }
        }
        #endregion

        #region 添加分店
        private void 添加分店ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CheckMiGo miGo = new CheckMiGo();
            miGo.ShowDialog();
            if (miGo.isTrue)
            {
                if (miGo.isAdmin)
                {
                    AddDepartWindow addDepart = new AddDepartWindow();
                    addDepart.Show();
                }
                else
                {
                    MessageBox.Show("加密狗验证正确，但该加密狗没有此权限!");
                }
            }
        }
        #endregion

        #region 添加用户
        private void 添加用户ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CheckMiGo miGo = new CheckMiGo();
            miGo.ShowDialog();
            if (miGo.isTrue)
            {
                if (miGo.isAdmin)
                {
                    AddUserWindow addUser = new AddUserWindow();
                    addUser.Show();
                }
                else
                {
                    MessageBox.Show("加密狗验证正确，但该加密狗没有此权限!");
                }
            }
        }
        #endregion

        #region 添加规则
        private void 添加规则ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CheckMiGo miGo = new CheckMiGo();
            miGo.ShowDialog();
            if (miGo.isTrue)
            {
                if (miGo.isAdmin)
                {
                    AddRuleWindow addRule = new AddRuleWindow();
                    addRule.Show();
                }
                else
                {
                    MessageBox.Show("加密狗验证正确，但该加密狗没有此权限!");
                }
            }
        }
        #endregion

        #region 会员管理
        private void 管理会员ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CheckMiGo miGo = new CheckMiGo();
            miGo.ShowDialog();
            if (miGo.isTrue)
            {
                if (miGo.DpId == StaticData.departLocal.DpId || miGo.isAdmin)
                {
                    VipManageWindow vipManage = new VipManageWindow(miGo.isAdmin);
                    vipManage.Show();
                }
                else
                {
                    MessageBox.Show("加密狗验证正确，但该加密狗不能管理该分店!");
                }
            }
        }
        #endregion

        #region 管理用户
        private void 管理用户ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CheckMiGo miGo = new CheckMiGo();
            miGo.ShowDialog();
            if (miGo.isTrue)
            {
                if (miGo.isAdmin)
                {
                    UserManageWindow userManage = new UserManageWindow();
                    userManage.Show();
                }
                else
                {
                    MessageBox.Show("加密狗验证正确，但该加密狗没有此权限!");
                }
            }
        }
        #endregion

        #region 管理分店
        private void 管理分店ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CheckMiGo miGo = new CheckMiGo();
            miGo.ShowDialog();
            if (miGo.isTrue)
            {
                if (miGo.isAdmin)
                {
                    DepartManageWindow departManage = new DepartManageWindow();
                    departManage.Show();
                }
                else
                {
                    MessageBox.Show("加密狗验证正确，但该加密狗没有此权限!");
                }
            }
        }
        #endregion

        #region 管理规则
        private void 管理规则ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CheckMiGo miGo = new CheckMiGo();
            miGo.ShowDialog();
            if (miGo.isTrue)
            {
                if (miGo.isAdmin)
                {
                    RuleManageWindow ruleManage = new RuleManageWindow();
                    ruleManage.Show();
                }
                else
                {
                    MessageBox.Show("加密狗验证正确，但该加密狗没有此权限!");
                }
            }
        }
        #endregion


        #endregion

        #region 切换查询类型
        private void rbtnBorrow_CheckedChanged(object sender, EventArgs e)
        {
            lvBorrow.Columns.Clear();
            lvBorrow.Items.Clear();
            if (rbtnBorrow.Checked == true)
            {
                lvBorrow.FullRowSelect = true;
                labCount.Text = "未还车辆:";
                label1.Text = "0辆";
                lvBorrow.Columns.Add("colNumber", "卡号", 80);
                lvBorrow.Columns.Add("colName", "租车人", 80);
                lvBorrow.Columns.Add("colBorrowKind", "租车类型", 80);
                lvBorrow.Columns.Add("colStartTime", "租车开始时间", 180);
                lvBorrow.Columns.Add("colBorrowNum", "租车辆数(辆)", 100);
                lvBorrow.Columns.Add("colLeftNum", "未还辆数(辆)", 100);
                lvBorrow.Columns.Add("colPhone", "租车人电话", 120);
                lvBorrow.Columns.Add("colAddress", "租车人地址", 170);
                lvBorrow.Columns.Add("colMark", "备注", 250);
                lvBorrow.Columns.Add("col", "包夜租车", 80);
            }
            if (rbtnReturn.Checked == true)
            {
                lvBorrow.FullRowSelect = false;
                labCount.Text = "租车次数:";
                label1.Text = "0次";
                lvBorrow.Columns.Add("colNumber", "卡号", 80);
                lvBorrow.Columns.Add("colName", "租车人", 80);
                lvBorrow.Columns.Add("colDPID", "还车地点", 120);
                lvBorrow.Columns.Add("colReturnNum", "还车数量(辆)", 120);
                lvBorrow.Columns.Add("colReturnTime", "还车时间", 200);
                lvBorrow.Columns.Add("colCostTime", "使用时间", 200);
                lvBorrow.Columns.Add("colMoney", "使用金额(元)", 120);
                lvBorrow.Columns.Add("colMark", "备注", 250);
            }
        }
        #endregion

        #region 添加会员等级
        private void 添加会员等级ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CheckMiGo miGo = new CheckMiGo();
            miGo.ShowDialog();
            if (miGo.isTrue)
            {
                if (miGo.isAdmin)
                {
                    AddVipLevelWindow addLevel = new AddVipLevelWindow();
                    addLevel.ShowDialog();
                }
                else
                {
                    MessageBox.Show("加密狗验证正确，但该加密狗没有此权限!");
                }
            }
        }
        #endregion

        #region 管理会员等级
        private void 管理会员等级ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CheckMiGo miGo = new CheckMiGo();
            miGo.ShowDialog();
            if (miGo.isTrue)
            {
                if (miGo.isAdmin)
                {
                    VipLevelManageWindow levelManage = new VipLevelManageWindow();
                    levelManage.ShowDialog();
                }
                else
                {
                    MessageBox.Show("加密狗验证正确，但该加密狗没有此权限!");
                }
            }
        }
        #endregion

        #region 非会员租车
        private void 非会员租车ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BeforeBorrow beforeBorrw = new BeforeBorrow(false, true);
            beforeBorrw.ShowDialog();
            if (beforeBorrw.isTrue)
            {
                VipNoBorrowWindow vipNoBorrow = new VipNoBorrowWindow(beforeBorrw.vipId);
                vipNoBorrow.ShowDialog();
            }
        }
        #endregion

        #region 会员租车
        private void 会员租车ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BeforeBorrow beforeBorrw = new BeforeBorrow(true, true);
            beforeBorrw.ShowDialog();
            if (beforeBorrw.isTrue)
            {
                VipBorrowWindow borrowWindow = new VipBorrowWindow(beforeBorrw.vipId);
                borrowWindow.ShowDialog();
            }

        }
        #endregion

        #region 会员还车
        private void 会员还车ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BeforeBorrow beforeBorrw = new BeforeBorrow(true, false);
            beforeBorrw.ShowDialog();
            if (beforeBorrw.isTrue)
            {
                VipReturnWindow vipReturnWindow = new VipReturnWindow(beforeBorrw.vipId);
                if (vipReturnWindow.isDispose)
                {
                    vipReturnWindow.Dispose();
                }
                else
                {
                    vipReturnWindow.ShowDialog();
                }
            }

        }
        #endregion

        #region 非会员还车
        private void 非会员还车ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BeforeBorrow beforeBorrw = new BeforeBorrow(false, false);
            beforeBorrw.ShowDialog();
            if (beforeBorrw.isTrue)
            {
                VipNoReturnWindow vipNoReturnWindow = new VipNoReturnWindow(beforeBorrw.vipId);
                if (vipNoReturnWindow.isDispose)
                {
                    vipNoReturnWindow.Dispose();
                }
                else
                {
                    vipNoReturnWindow.ShowDialog();
                }
            }
        }
        #endregion

        #region 添加非会员
        private void 添加非会员ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CheckMiGo miGo = new CheckMiGo();
            miGo.ShowDialog();
            if (miGo.isTrue)
            {
                if (miGo.DpId == StaticData.departLocal.DpId || miGo.isAdmin)
                {
                    AddVipNoWindow addVipNo = new AddVipNoWindow();
                    addVipNo.ShowDialog();
                }
                else
                {
                    MessageBox.Show("加密狗验证正确，但该加密狗不能管理该分店!");
                }
            }
        }
        #endregion

        #region 管理非会员
        private void 管理非会员ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CheckMiGo miGo = new CheckMiGo();
            miGo.ShowDialog();
            if (miGo.isTrue)
            {
                if (miGo.DpId == StaticData.departLocal.DpId || miGo.isAdmin)
                {
                    VipNoManageWindow vipNoManage = new VipNoManageWindow(miGo.isAdmin);
                    vipNoManage.ShowDialog();
                }
                else
                {
                    MessageBox.Show("加密狗验证正确，但该加密狗不能管理该分店!");
                }
            }
        }
        #endregion

        private void 租还车查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CheckMiGo miGo = new CheckMiGo();
            miGo.ShowDialog();
            if (miGo.isTrue)
            {
                if (miGo.DpId == StaticData.departLocal.DpId || miGo.isAdmin)
                {
                    BorrowReturnWindow borrowReturnWindow = new BorrowReturnWindow(miGo.isAdmin);
                    borrowReturnWindow.ShowDialog();
                }
                else
                {
                    MessageBox.Show("加密狗验证正确，但该加密狗不能管理该分店!");
                }
            }
        }

        private void 日志查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CheckMiGo miGo = new CheckMiGo();
            miGo.ShowDialog();
            if (miGo.isTrue)
            {
                if (miGo.DpId == StaticData.departLocal.DpId || miGo.isAdmin)
                {
                    LogWindow logWindow = new LogWindow(miGo.isAdmin);
                    logWindow.ShowDialog();
                }
                else
                {
                    MessageBox.Show("加密狗验证正确，但该加密狗不能管理该分店!");
                }
            }
        }

        private void 会员租车查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CheckMiGo miGo = new CheckMiGo();
            miGo.ShowDialog();
            if (miGo.isTrue)
            {
                if (miGo.DpId == StaticData.departLocal.DpId || miGo.isAdmin)
                {
                    VipOrNoBorrowSelectWindow vipSelect = new VipOrNoBorrowSelectWindow(true);
                    vipSelect.ShowDialog();
                }
                else
                {
                    MessageBox.Show("加密狗验证正确，但该加密狗不能管理该分店!");
                }
            }
        }

        #region 会员报表
        private void 会员报表ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CheckMiGo miGo = new CheckMiGo();
            miGo.ShowDialog();
            if (miGo.isTrue)
            {
                if (miGo.DpId == StaticData.departLocal.DpId || miGo.isAdmin)
                {
                    VipYearFormWindow vipYear = new VipYearFormWindow(miGo.isAdmin);
                    vipYear.ShowDialog();
                }
                else
                {
                    MessageBox.Show("加密狗验证正确，但该加密狗不能管理该分店!");
                }
            }
        }
        #endregion

        #region 月收入报表
        private void 月收入报表ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CheckMiGo miGo = new CheckMiGo();
            miGo.ShowDialog();
            if (miGo.isTrue)
            {
                if (miGo.DpId == StaticData.departLocal.DpId || miGo.isAdmin)
                {
                    DepartMonthFormWindow departMonthForm = new DepartMonthFormWindow(miGo.isAdmin);
                    departMonthForm.ShowDialog();
                }
                else
                {
                    MessageBox.Show("加密狗验证正确，但该加密狗不能管理该分店!");
                }
            }
        }
        #endregion

        #region 年收入报表
        private void 年收入报表ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CheckMiGo miGo = new CheckMiGo();
            miGo.ShowDialog();
            if (miGo.isTrue)
            {
                if (miGo.DpId == StaticData.departLocal.DpId || miGo.isAdmin)
                {
                    DepartYearFromWindow departYearForm = new DepartYearFromWindow(miGo.isAdmin);
                    departYearForm.ShowDialog();
                }
                else
                {
                    MessageBox.Show("加密狗验证正确，但该加密狗不能管理该分店!");
                }
            }
        }
        #endregion

        private void 加密狗管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 租车还车系统ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 添加加密狗ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CheckMiGo miGo = new CheckMiGo();
            miGo.ShowDialog();
            if (miGo.isTrue)
            {
                if (miGo.isAdmin)
                {
                    UInfoAdd uAdd = new UInfoAdd();
                    uAdd.ShowDialog();
                }
                else
                {
                    MessageBox.Show("加密狗验证正确，您没有此权限!");
                }
            }
        }

        private void 管理加密狗ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CheckMiGo miGo = new CheckMiGo();
            miGo.ShowDialog();
            if (miGo.isTrue)
            {
                if (miGo.isAdmin)
                {
                    UManageWindow uManage = new UManageWindow();
                    uManage.ShowDialog();
                }
                else
                {
                    MessageBox.Show("加密狗验证正确，您没有此权限!");
                }
            }
        }



        private void 积分比例管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CheckMiGo miGo = new CheckMiGo();
            miGo.ShowDialog();
            if (miGo.isTrue)
            {
                if (miGo.isAdmin)
                {
                    ProporWindow por = new ProporWindow();
                    por.ShowDialog();
                }
                else
                {
                    MessageBox.Show("加密狗验证正确，您没有此权限!");
                }
            }


        }

        private void 充值查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CheckMiGo miGo = new CheckMiGo();
            miGo.ShowDialog();
            if (miGo.isTrue)
            {
                if (miGo.DpId == StaticData.departLocal.DpId || miGo.isAdmin)
                {
                    IncomeBorrow income = new IncomeBorrow(miGo.isAdmin);
                    income.ShowDialog();
                }
                else
                {
                    MessageBox.Show("加密狗验证正确，但该加密狗不能管理该分店!");
                }
            }

        }

        private void 今日收入查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CheckMiGo miGo = new CheckMiGo();
            miGo.ShowDialog();
            if (miGo.isTrue)
            {
                if (miGo.DpId == StaticData.departLocal.DpId || miGo.isAdmin)
                {
                    TodayIncome today = new TodayIncome(miGo.isAdmin);
                    today.ShowDialog();
                }
                else
                {
                    MessageBox.Show("加密狗验证正确，但该加密狗不能管理该分店!");
                }
            }

        }

        private void 交接班ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangeUser change = new ChangeUser();
            change.ShowDialog();
        }

        //进度条

        List<BikeReturn> bikeList = new List<BikeReturn>();
        List<BikeReturn> bikeNoList = new List<BikeReturn>();
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            backgroundWorker1.ReportProgress(10);//这里让进度条显示进度
            vipBorrowList = vipBorrowBLL.VipBorrowSelectByDpIdAndTime(DPId, startTime, endTime);
            backgroundWorker1.ReportProgress(50);//这里让进度条显示进度
            vipNoBorrowList = vipNoBorrowBLL.VipNoBorrowSelectByDpIdAndTime(DPId, startTime, endTime);
            backgroundWorker1.ReportProgress(70);//这里让进度条显示进度

        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                VIPInfo vipModel = new VIPInfo();
                VipNoInfo vipNoModel = new VipNoInfo();
                if (vipBorrowList.Count == 0 && vipNoBorrowList.Count == 0)
                {
                    btnSearch.Enabled = true;
                    progressBar1.Visible = false;
                    lvBorrow.Items.Clear();
                    label1.Text = "0辆";
                    MessageBox.Show("未查询到相应数据!");
                    return;
                }
                double sum = 0;
                lvBorrow.Items.Clear();
                VipBorrowInfo vipBorrowTemp;
                if (vipModel == null)
                {
                    vipModel = new VIPInfo();
                }
                for (int i = 0; i < vipBorrowList.Count; i++)
                {
                    try
                    {
                        vipBorrowTemp = vipBorrowList[i];
                        lvBorrow.Items.Add("");
                        lvBorrow.Items[i].ForeColor = Color.BlueViolet;
                        lvBorrow.Items[i].SubItems.Add("");
                        lvBorrow.Items[i].SubItems.Add("");
                        lvBorrow.Items[i].SubItems.Add("");
                        lvBorrow.Items[i].SubItems.Add("");
                        lvBorrow.Items[i].SubItems.Add("");
                        lvBorrow.Items[i].SubItems.Add("");
                        lvBorrow.Items[i].SubItems.Add("");
                        lvBorrow.Items[i].SubItems.Add("");
                        lvBorrow.Items[i].SubItems.Add("");
                        lvBorrow.Items[i].Tag = vipBorrowTemp;
                        vipModel.VipId = vipBorrowTemp.VipId;
                        vipModel = vipBLL.VipSelectById_MainPage(vipModel);
                        if (vipModel == null)
                        {
                            vipModel.VipId = vipBorrowTemp.VipId;
                            vipModel = vipBLL.VipSelectById_MainPage(vipModel);
                        }
                        lvBorrow.Items[i].SubItems[0].Text = vipModel.VipNumber;
                        lvBorrow.Items[i].SubItems[1].Text = vipModel.VipName;
                        lvBorrow.Items[i].SubItems[2].Text = borrowKind[vipBorrowTemp.RkrId];
                        lvBorrow.Items[i].SubItems[3].Text = vipBorrowTemp.BbkTime.ToString();
                        lvBorrow.Items[i].SubItems[4].Text = vipBorrowTemp.BbkNumber.ToString();
                        lvBorrow.Items[i].SubItems[5].Text = vipBorrowTemp.LeftNum.ToString();
                        lvBorrow.Items[i].SubItems[6].Text = vipModel.VipPhone.ToString();
                        lvBorrow.Items[i].SubItems[7].Text = vipModel.VipAddress;
                        lvBorrow.Items[i].SubItems[8].Text = vipBorrowTemp.Mark;
                        if (vipBorrowTemp.IsNight)
                        {
                            lvBorrow.Items[i].SubItems[9].Text = "是";
                        }
                        else
                        {
                            lvBorrow.Items[i].SubItems[9].Text = "否";
                        }
                        sum += vipBorrowTemp.LeftNum;

                    }
                    catch (Exception)
                    {
                    }
                }
                VipNoBorrow vipNoBorrowTemp;
                if (vipNoModel == null)
                {
                    vipNoModel = new VipNoInfo();
                }
                for (int i = 0; i < vipNoBorrowList.Count; i++)
                {
                    try
                    {
                        vipNoBorrowTemp = vipNoBorrowList[i];
                        lvBorrow.Items.Add("");
                        lvBorrow.Items[i + vipBorrowList.Count].ForeColor = Color.Red;
                        lvBorrow.Items[i + vipBorrowList.Count].SubItems.Add("");
                        lvBorrow.Items[i + vipBorrowList.Count].SubItems.Add("");
                        lvBorrow.Items[i + vipBorrowList.Count].SubItems.Add("");
                        lvBorrow.Items[i + vipBorrowList.Count].SubItems.Add("");
                        lvBorrow.Items[i + vipBorrowList.Count].SubItems.Add("");
                        lvBorrow.Items[i + vipBorrowList.Count].SubItems.Add("");
                        lvBorrow.Items[i + vipBorrowList.Count].SubItems.Add("");
                        lvBorrow.Items[i + vipBorrowList.Count].SubItems.Add("");
                        lvBorrow.Items[i + vipBorrowList.Count].SubItems.Add("");
                        lvBorrow.Items[i + vipBorrowList.Count].SubItems.Add("");
                        lvBorrow.Items[i + vipBorrowList.Count].Tag = vipNoBorrowTemp;
                        vipNoModel.VipId = vipNoBorrowTemp.VipId;
                        vipNoModel = vipNoBLL.VipNoSelectByVIPNoId(vipNoModel);
                        lvBorrow.Items[i + vipBorrowList.Count].SubItems[0].Text = vipNoModel.VipNumber;
                        lvBorrow.Items[i + vipBorrowList.Count].SubItems[1].Text = vipNoBorrowTemp.VnName;
                        lvBorrow.Items[i + vipBorrowList.Count].SubItems[2].Text = borrowKind[vipNoBorrowTemp.RkrId];
                        lvBorrow.Items[i + vipBorrowList.Count].SubItems[3].Text = vipNoBorrowTemp.BbkTime.ToString();
                        lvBorrow.Items[i + vipBorrowList.Count].SubItems[4].Text = vipNoBorrowTemp.VnNumber.ToString();
                        lvBorrow.Items[i + vipBorrowList.Count].SubItems[5].Text = vipNoBorrowTemp.LeftNum.ToString();
                        lvBorrow.Items[i + vipBorrowList.Count].SubItems[6].Text = vipNoBorrowTemp.VnPhone.ToString();
                        lvBorrow.Items[i + vipBorrowList.Count].SubItems[8].Text = vipNoBorrowTemp.Mark;
                        if (vipNoBorrowTemp.IsNight)
                        {
                            lvBorrow.Items[i + vipBorrowList.Count].SubItems[9].Text = "是";
                        }
                        else
                        {
                            lvBorrow.Items[i + vipBorrowList.Count].SubItems[9].Text = "否";
                        }
                        sum += vipNoBorrowTemp.LeftNum;

                    }
                    catch (Exception)
                    {
                    }
                }
                label1.Text = sum.ToString() + "辆";
            }
            catch (Exception)
            {
            }

            btnSearch.Enabled = true;
            progressBar1.Visible = false;
        }

        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {
            backgroundWorker2.ReportProgress(10);//这里让进度条显示进度
            BikeReturn bikeTemp = new BikeReturn();
            bikeTemp.IsVip = true;
            bikeTemp.DpId = DPId;
            bikeList = bikeReturnBLL.BikeReturnSelectByDpIdAndTime(bikeTemp, startTime, endTime);
            backgroundWorker2.ReportProgress(50);
            bikeTemp.IsVip = false;
            bikeNoList = bikeReturnBLL.BikeReturnSelectByDpIdAndTime(bikeTemp, startTime, endTime);
            backgroundWorker2.ReportProgress(70);
        }

        private void backgroundWorker2_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar2.Value = e.ProgressPercentage;
        }

        private void backgroundWorker2_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                //DateTime startTime = DateTime.Now.Date;
                label1.Text = "0";
                VIPInfo vipTemp = new VIPInfo();
                VipNoInfo vipNoTemp = new VipNoInfo();
                DepartInfo departTemp = new DepartInfo();
                VipNoBorrow vipNoBorrowTemp = new VipNoBorrow();
                if (bikeNoList != null && bikeNoList.Count != 0)
                {
                    bikeList.AddRange(bikeNoList);
                }
                if (bikeList == null || bikeList.Count == 0)
                {
                    btnSearch.Enabled = true;
                    progressBar2.Visible = false;
                    label1.Text = "0次";
                    MessageBox.Show("未查询到相应数据!");
                    return;
                }
                label1.Text = bikeList.Count.ToString() + "次";
                lvBorrow.Items.Clear();
                for (int i = 0; i < bikeList.Count; i++)
                {
                    try
                    {
                        lvBorrow.Items.Add("");
                        lvBorrow.Items[i].SubItems.Add("");
                        lvBorrow.Items[i].SubItems.Add("");
                        lvBorrow.Items[i].SubItems.Add("");
                        lvBorrow.Items[i].SubItems.Add("");
                        lvBorrow.Items[i].SubItems.Add("");
                        lvBorrow.Items[i].SubItems.Add("");
                        lvBorrow.Items[i].SubItems.Add("");
                        lvBorrow.Items[i].SubItems.Add("");
                        if (bikeList[i].IsVip)
                        {
                            vipTemp.VipId = bikeList[i].VipId;
                            vipTemp = vipBLL.VipSelectById_MainPage(vipTemp);
                            departTemp.DpId = bikeList[i].DpId;
                            departTemp = departBLL.DepartSelectById(departTemp);
                            lvBorrow.Items[i].SubItems[0].Text = vipTemp.VipNumber;
                            lvBorrow.Items[i].SubItems[1].Text = vipTemp.VipName;
                            lvBorrow.Items[i].SubItems[2].Text = departTemp.DpName;
                            lvBorrow.Items[i].SubItems[3].Text = bikeList[i].BrNumber.ToString();
                            lvBorrow.Items[i].SubItems[4].Text = bikeList[i].RbkTime.ToString();
                            lvBorrow.Items[i].SubItems[5].Text = bikeList[i].BuTimeString;
                            lvBorrow.Items[i].SubItems[6].Text = bikeList[i].BuCost.ToString();
                            lvBorrow.Items[i].SubItems[7].Text = bikeList[i].Mark;
                            lvBorrow.Items[i].ForeColor = Color.BlueViolet;
                        }
                        else
                        {
                            vipNoTemp.VipId = bikeList[i].VipId;
                            vipNoTemp = vipNoBLL.VipNoSelectByVIPNoId(vipNoTemp);
                            departTemp.DpId = bikeList[i].DpId;
                            departTemp = departBLL.DepartSelectById(departTemp);
                            vipNoBorrowTemp.BbkId = bikeList[i].BbkId;
                            vipNoBorrowTemp = vipNoBorrowBLL.VipNoBorrowSelectByBBKId(vipNoBorrowTemp);
                            lvBorrow.Items[i].SubItems[0].Text = vipNoTemp.VipNumber;
                            lvBorrow.Items[i].SubItems[1].Text = vipNoBorrowTemp.VnName;
                            lvBorrow.Items[i].SubItems[2].Text = departTemp.DpName;
                            lvBorrow.Items[i].SubItems[3].Text = bikeList[i].BrNumber.ToString();
                            lvBorrow.Items[i].SubItems[4].Text = bikeList[i].RbkTime.ToString();
                            lvBorrow.Items[i].SubItems[5].Text = bikeList[i].BuTimeString;
                            lvBorrow.Items[i].SubItems[6].Text = bikeList[i].BuCost.ToString();
                            lvBorrow.Items[i].SubItems[7].Text = bikeList[i].Mark;
                            lvBorrow.Items[i].ForeColor = Color.Red;
                        }


                    }
                    catch (Exception)
                    {
                    }
                }
            }
            catch (Exception)
            {
            }
            btnSearch.Enabled = true;
            progressBar2.Visible = false;
        }

        private void 会员充值ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CheckMiGo miGo = new CheckMiGo();
            miGo.ShowDialog();
            if (miGo.isTrue)
            {

                ReChargeWindow rechargeWinodw = new ReChargeWindow(miGo .isAdmin );
                rechargeWinodw.ShowDialog();

            }
        }

        private void 非会员充值ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CheckMiGo miGo = new CheckMiGo();
            miGo.ShowDialog();
            if (miGo.isTrue)
            {
                if (miGo.DpId == StaticData.departLocal.DpId || miGo.isAdmin)
                {
                    VipNoCharge nocahrge = new VipNoCharge(miGo.isAdmin);
                    nocahrge.ShowDialog();
                }
                else
                {
                    MessageBox.Show("对不起，您没有该权限!");
                }
            }
        }

        private void 转为包夜租车ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lvBorrow.SelectedItems.Count != 1)
            {
                MessageBox.Show("请选择一行!");
                return;
            }
            DialogResult result1 = MessageBox.Show("转为包夜租车?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result1 == DialogResult.No)
                return;
            bool flag = false;
            try
            {
                if (lvBorrow.SelectedItems[0].ForeColor == Color.BlueViolet)
                {
                    flag = vipBorrowBLL.nightBorrow(lvBorrow.SelectedItems[0].Tag as VipBorrowInfo);
                }
                else
                {
                    flag = vipBorrowBLL.nightBorrow(lvBorrow.SelectedItems[0].Tag as VipNoBorrow);
                }
            }
            catch (Exception ex)
            {
                flag = false;
            }
            if (flag)
            {
                lvBorrow.SelectedItems[0].SubItems[9].Text = "是";
                MessageBox.Show("操作成功！");
            }
            else
            {
                MessageBox.Show("操作失败！");
            }

        }

        private void 取消包夜租车ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (lvBorrow.SelectedItems.Count != 1)
            {
                MessageBox.Show("请选择一行!");
                return;
            }
            DialogResult result1 = MessageBox.Show("取消包夜租车?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result1 == DialogResult.No)
                return;
            bool flag = false;
            try
            {
                if (lvBorrow.SelectedItems[0].ForeColor == Color.BlueViolet)
                {
                    flag = vipBorrowBLL.notNightBorrow(lvBorrow.SelectedItems[0].Tag as VipBorrowInfo);
                }
                else
                {
                    flag = vipBorrowBLL.notNightBorrow(lvBorrow.SelectedItems[0].Tag as VipNoBorrow);
                }
            }
            catch (Exception ex)
            {
                flag = false;
            }
            if (flag)
            {
                lvBorrow.SelectedItems[0].SubItems[9].Text = "否";
                MessageBox.Show("操作成功！");
            }
            else
            {
                MessageBox.Show("操作失败！");
            }

        }

        private void 包夜管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CheckMiGo miGo = new CheckMiGo();
            miGo.ShowDialog();
            if (miGo.isTrue)
            {
                if (miGo.DpId == StaticData.departLocal.DpId || miGo.isAdmin)
                {
                    NightBorrowRule nightBorrowRule = new NightBorrowRule(miGo.isAdmin);
                    nightBorrowRule.Show();
                }
                else
                {
                    MessageBox.Show("对不起，您没有该权限!");
                }
            }
        }

        #region 双击事件
        private void lvBorrow_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (lvBorrow.SelectedItems.Count != 1)
            {
                MessageBox.Show("请选择一行!");
                return;
            }
            try
            {
                if (lvBorrow.SelectedItems[0].ForeColor  == Color.BlueViolet)
                {
                    BeforeBorrow beforeBorrw = new BeforeBorrow(lvBorrow.SelectedItems[0].SubItems[0].Text,true, false);
                    beforeBorrw.ShowDialog();
                    if (beforeBorrw.isTrue)
                    {
                        VipReturnWindow vipReturnWindow = new VipReturnWindow(beforeBorrw.vipId);
                        if (vipReturnWindow.isDispose)
                        {
                            vipReturnWindow.Dispose();
                        }
                        else
                        {
                            vipReturnWindow.ShowDialog();
                        }
                    }
                }
                else
                {
                    BeforeBorrow beforeBorrw = new BeforeBorrow(lvBorrow.SelectedItems[0].SubItems[0].Text,false, false);
                    beforeBorrw.ShowDialog();
                    if (beforeBorrw.isTrue)
                    {
                        VipNoReturnWindow vipNoReturnWindow = new VipNoReturnWindow(beforeBorrw.vipId);
                        if (vipNoReturnWindow.isDispose)
                        {
                            vipNoReturnWindow.Dispose();
                        }
                        else
                        {
                            vipNoReturnWindow.ShowDialog();
                        }
                    }
                }
                
            }
            catch (Exception ex)
            {
            }
        }        
        #endregion

        #region 修改备注
        private void 修改备注ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (lvBorrow.SelectedItems.Count != 1)
            {
                MessageBox.Show("请选择一行!");
                return;
            }
            string BbkId;
            try
            {
               
                if (lvBorrow.SelectedItems[0].ForeColor == Color.BlueViolet)
                { 
                    BbkId =(lvBorrow.SelectedItems[0].Tag as VipBorrowInfo).BbkId.ToString () ;
                    ChangeMark CMark = new ChangeMark(BbkId, lvBorrow.SelectedItems[0].SubItems[8].Text, true);
                    CMark.ShowDialog();
                }
                else
                {
                    BbkId = (lvBorrow.SelectedItems[0].Tag as VipNoBorrow).BbkId.ToString();
                    ChangeMark CMark = new ChangeMark(BbkId, lvBorrow.SelectedItems[0].SubItems[8].Text,false );
                    CMark.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("操作失败！");
                return;
            }
        }
        #endregion

      

  

    }
}
