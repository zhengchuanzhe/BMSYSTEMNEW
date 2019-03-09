using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using MODEL;
using BIKEBLL;
using System.Threading;

namespace BMSYSTEM
{
    public partial class AddRuleWindow : Form
    {
        CostRuleBLL ruleBLL;
        CostRule costRule;
        VipLevelBLL vipLvBLL;
        VipLevelInfo levelModel;
        VipLevelBLL levelBLL;

        BackgroundWorker bg;
        List<VipLevelInfo> listlV;
        private delegate void fillCmbLvDelegate();
        public AddRuleWindow()
        {
            InitializeComponent();
            costRule = new CostRule();
            ruleBLL = new CostRuleBLL();
            vipLvBLL = new VipLevelBLL();
            levelModel = new VipLevelInfo();
            levelBLL = new VipLevelBLL();
            listlV = new List<VipLevelInfo>();
            bg = new BackgroundWorker();
            bg.DoWork += new DoWorkEventHandler(bg_DoWork);//异步操作时要做的操作，一般去查列表，这个列表在本页面内先声明，然后在这个dowork方法里去取数填充他
            bg.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bg_RunWorkerCompleted);//这个是取数完成后进行的操作，去到数后，这里取用去到的列表绑定到控件
        }


        void bg_DoWork(object sender, DoWorkEventArgs e)
        {
            listlV = vipLvBLL.VipLevelSelect(); ;
        }
        void bg_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            FillDp();
        }
        private void FillDp()
        {
            cmbVipLvDay.DataSource = listlV;
            cmbVipLvDay.DisplayMember = "LVNAME";
            cmbVipLvDay.ValueMember = "LVID";

            cmbVipLvMonth.DataSource = listlV;
            cmbVipLvMonth.DisplayMember = "LVNAME";
            cmbVipLvMonth.ValueMember = "LVID";

            cmbVipLVYear.DataSource = listlV;
            cmbVipLVYear.DisplayMember = "LVNAME";
            cmbVipLVYear.ValueMember = "LVID";
        }





        #region 窗体加载
        private void AddRuleWindow_Load(object sender, EventArgs e)
        {
            bg.RunWorkerAsync();
        }
        #endregion

        #region DayOkClick事件
        private void btnOKDay_Click(object sender, EventArgs e)
        {
            if (txtNameDay.Text.Trim() == "" || txtNameDay.Text.Trim() == null)
            {
                epName.SetError(txtNameDay, "请输入规则名称!");
                return;
            }
            else
            {
                epName.SetError(txtNameDay, "");
            }
            if (txtMoneyPerHour.Text.Trim() == "" || txtMoneyPerHour.Text.Trim() == null)
            {
                epName.SetError(txtMoneyPerHour, "请输入单位时间扣费金额!");
                return;
            }
            else
            {
                epName.SetError(txtMoneyPerHour, "");
            }
            if (!Regex.IsMatch(txtMoneyPerHour.Text.Trim(), @"^[0-9]*[1-9][0-9]*$"))
            {
                epName.SetError(txtMoneyPerHour, "请输入正确的金额!");
                return;
            }
            else
            {
                epName.SetError(txtMoneyPerHour, "");
            }
            if (txtContentTimeDay.Text.Trim() == "" || txtContentTimeDay.Text.Trim() == null)
            {
                epName.SetError(txtContentTimeDay, "请输入扣费活动时间!");
                return;
            }
            else if (!Regex.IsMatch(txtContentTimeDay.Text.Trim(), @"^[0-9]*[1-9][0-9]*$"))
            {
                epName.SetError(txtContentTimeDay, "请输入正确的时间!");
                return;
            }
            else
            {
                epName.SetError(txtContentTimeDay, "");
            }
            if (txtContTimeDay.Text.Trim() == "" || txtContTimeDay.Text.Trim() == null)
            {
                epName.SetError(txtContTimeDay, "请输入初始扣费包含时间!");
                return;
            }
            else if (!Regex.IsMatch(txtContTimeDay.Text.Trim(), @"^[0-9]*[1-9][0-9]*$"))
            {
                epName.SetError(txtContTimeDay, "请输入正确的时间!");
                return;
            }
            else
            {
                epName.SetError(txtContTimeDay, "");
            }
            if (txtInitMoneyDay.Text.Trim() == "" || txtInitMoneyDay.Text.Trim() == null)
            {
                epName.SetError(txtInitMoneyDay, "请输入初始扣费金额!");
                return;
            }
            else if (!Regex.IsMatch(txtInitMoneyDay.Text.Trim(), @"^[0-9]*[1-9][0-9]*$"))
            {
                epName.SetError(txtInitMoneyDay, "请输入正确的金额!");
                return;
            }
            else
            {
                epName.SetError(txtInitMoneyDay, "");
            }

            progressBar1.Visible = true;
            btnOKDay.Enabled = false;
            costRule = new CostRule();
            costRule.CrName = txtNameDay.Text.Trim();
            costRule.CostPh = double.Parse(txtMoneyPerHour.Text.Trim());
            costRule.CostTime = int.Parse(txtContentTimeDay.Text.Trim());//扣费活动时间
            costRule.costBegin = double.Parse(txtInitMoneyDay.Text.Trim());
            costRule.conTime = int.Parse(txtContTimeDay.Text.Trim());//起始金额包含时间
            costRule.crKind = (int)BorrowKindEnum.Day;
            costRule.LvId = (int)cmbVipLvDay.SelectedValue;
            LogInfo logInfo = new LogInfo();
            logInfo.UserId = StaticData.userLocal.UserId;
            logInfo.Content = "添加了日租扣费规则，名称为‘" + txtNameDay.Text + "'";
            logInfo.LogTime = DateTime.Now;
            logInfo.DpId = StaticData.departLocal.DpId;

            backgroundWorker2.RunWorkerAsync();
        }
        #endregion
        #region MonthOKClick事件
        private void btnOKMonth_Click(object sender, EventArgs e)
        {
            if (txtNameMonth.Text.Trim() == "" || txtNameMonth.Text.Trim() == null)
            {
                epName.SetError(txtNameMonth, "请输入规则名称!");
                return;
            }
            else
            {
                epName.SetError(txtNameMonth, "");
            }
            if (txtCostPerMonth.Text.Trim() == "" || txtCostPerMonth.Text.Trim() == null)
            {
                epName.SetError(txtCostPerMonth, "请输入单位时间扣费金额!");
                return;
            }
            else if (!Regex.IsMatch(txtCostPerMonth.Text.Trim(), @"^[0-9]*[1-9][0-9]*$"))
            {
                epName.SetError(txtCostPerMonth, "请输入正确的金额!");
                return;
            }
            else
            {
                epName.SetError(txtCostPerMonth, "");
            }
            if (txtCostTimeMonth.Text.Trim() == "" || txtCostTimeMonth.Text.Trim() == null)
            {
                epName.SetError(txtCostTimeMonth, "请输入扣费活动时间!");
                return;
            }
            else if (!Regex.IsMatch(txtCostTimeMonth.Text.Trim(), @"^[0-9]*[1-9][0-9]*$"))
            {
                epName.SetError(txtCostTimeMonth, "请输入正确的时间!");
                return;
            }
            else
            {
                epName.SetError(txtCostTimeMonth, "");
            }
            if (txtContTimeMonth.Text.Trim() == "" || txtContTimeMonth.Text.Trim() == null)
            {
                epName.SetError(txtContTimeMonth, "请输入初始扣费包含时间!");
                return;
            }
            else if (!Regex.IsMatch(txtContTimeMonth.Text.Trim(), @"^[0-9]*[1-9][0-9]*$"))
            {
                epName.SetError(txtContTimeMonth, "请输入正确的时间!");
                return;
            }

            else
            {
                epName.SetError(txtContTimeMonth, "");
            }
            if (txtInitMoneyMonth.Text.Trim() == "" || txtInitMoneyMonth.Text.Trim() == null)
            {
                epName.SetError(txtInitMoneyMonth, "请输入初始扣费金额!");
                return;
            }
            else if (!Regex.IsMatch(txtInitMoneyMonth.Text.Trim(), @"^[0-9]*[1-9][0-9]*$"))
            {
                epName.SetError(txtInitMoneyMonth, "请输入正确的金额!");
                return;
            }
            else
            {
                epName.SetError(txtInitMoneyMonth, "");
            }
            btnOKMonth.Enabled = false;
            progressBar1.Visible = true;
            costRule = new CostRule();
            costRule.CrName = txtNameMonth.Text.Trim();
            costRule.CostPh = double.Parse(txtCostPerMonth.Text.Trim());
            costRule.CostTime = int.Parse(txtCostTimeMonth.Text.Trim());//扣费活动时间
            costRule.costBegin = double.Parse(txtInitMoneyMonth.Text.Trim());//初始扣费金额
            costRule.conTime = int.Parse(txtContTimeMonth.Text.Trim());//起始金额包含时间
            costRule.LvId = int.Parse(cmbVipLvMonth.SelectedValue.ToString());
            costRule.crKind = (int)BorrowKindEnum.Month;
            costRule.LvId = (int)cmbVipLvMonth.SelectedValue;

            logInfo.UserId = StaticData.userLocal.UserId;
            logInfo.Content = "添加了月租扣费规则，名称为‘" + txtNameMonth.Text + "'";
            logInfo.LogTime = DateTime.Now;
            logInfo.DpId = StaticData.departLocal.DpId;


            backgroundWorker2.RunWorkerAsync();
        }
        #endregion
        #region YearOKClick事件
        private void btnOKYear_Click(object sender, EventArgs e)
        {
            if (txtNameYear.Text.Trim() == "" || txtNameYear.Text.Trim() == null)
            {
                epName.SetError(txtNameYear, "请输入规则名称!");
                return;
            }

            else
            {
                epName.SetError(txtNameYear, "");
            }
            if (txtCostPerYear.Text.Trim() == "" || txtCostPerYear.Text.Trim() == null)
            {
                epName.SetError(txtCostPerYear, "请输入单位时间扣费金额!");
                return;
            }
            else if (!Regex.IsMatch(txtCostPerYear.Text.Trim(), @"^[0-9]*[1-9][0-9]*$"))
            {
                epName.SetError(txtCostPerYear, "请输入正确的金额!");
                return;
            }


            else
            {
                epName.SetError(txtCostPerYear, "");
            }
            if (txtCostTimeYear.Text.Trim() == "" || txtCostTimeYear.Text.Trim() == null)
            {
                epName.SetError(txtCostTimeYear, "请输入扣费活动时间!");
                return;
            }
            else if (!Regex.IsMatch(txtCostTimeYear.Text.Trim(), @"^[0-9]*[1-9][0-9]*$"))
            {
                epName.SetError(txtCostTimeYear, "请输入正确的时间!");
                return;
            }


            else
            {
                epName.SetError(txtCostTimeYear, "");
            }
            if (txtContentTimeYear.Text.Trim() == "" || txtContentTimeYear.Text.Trim() == null)
            {
                epName.SetError(txtContentTimeYear, "请输入初始扣费包含时间!");
                return;
            }
            else if (!Regex.IsMatch(txtContentTimeYear.Text.Trim(), @"^[0-9]*[1-9][0-9]*$"))
            {
                epName.SetError(txtContentTimeYear, "请输入正确的时间!");
                return;
            }

            else
            {
                epName.SetError(txtContentTimeYear, "");
            }
            if (txtInitCostYear.Text.Trim() == "" || txtInitCostYear.Text.Trim() == null)
            {
                epName.SetError(txtInitCostYear, "请输入初始扣费金额!");
                return;
            }
            else if (!Regex.IsMatch(txtInitCostYear.Text.Trim(), @"^[0-9]*[1-9][0-9]*$"))
            {
                epName.SetError(txtInitCostYear, "请输入正确的金额!");
                return;
            }
            else
            {
                epName.SetError(txtInitCostYear, "");
            }
            btnOKYear.Enabled = false;
            progressBar1.Visible = true;
            costRule.CrName = txtNameYear.Text.Trim();
            costRule.CostPh = double.Parse(txtCostPerYear.Text.Trim());
            costRule.CostTime = int.Parse(txtCostTimeYear.Text.Trim());//扣费活动时间
            costRule.costBegin = double.Parse(txtInitCostYear.Text.Trim());//初始扣费金额
            costRule.conTime = int.Parse(txtContentTimeYear.Text.Trim());//起始金额包含时间
            costRule.crKind = (int)BorrowKindEnum.Year;
            costRule.LvId = (int)cmbVipLVYear.SelectedValue;

            logInfo.UserId = StaticData.userLocal.UserId;
            logInfo.Content = "添加了年租扣费规则，名称为‘" + txtNameYear.Text + "'";
            logInfo.LogTime = DateTime.Now;
            logInfo.DpId = StaticData.departLocal.DpId;

            backgroundWorker1.RunWorkerAsync();
        }
        #endregion
        private void btnCencelDay_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnConcelMonth_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCencelYear_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        bool b1;
        bool b2;
        LogInfo logInfo = new LogInfo();
        //年租
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            backgroundWorker1.ReportProgress(10);//这里让进度条显示进度
            b1 = ruleBLL.CostRuleInsert(costRule);
            backgroundWorker1.ReportProgress(60);//这里让进度条显示进度
            b2 = new LogBLL().LogInsert(logInfo);
            backgroundWorker1.ReportProgress(90);
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            progressBar1.Visible = false;
            btnOKYear.Enabled = true;
            if (b1)
            {
                MessageBox.Show("添加扣费规则成功!");
                this.Close();
            }
            else
            {
                MessageBox.Show("添加扣费规则失败!");
            }
        }


        //月租
        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {
            backgroundWorker2.ReportProgress(10);//这里让进度条显示进度
            b1 = ruleBLL.CostRuleInsert(costRule);
            backgroundWorker2.ReportProgress(60);//这里让进度条显示进度
            b2 = new LogBLL().LogInsert(logInfo);
            backgroundWorker2.ReportProgress(90);

        }

        private void backgroundWorker2_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }

        private void backgroundWorker2_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            btnOKMonth.Enabled = true;
            progressBar1.Visible = false;
            if (b1)
            {
                MessageBox.Show("添加扣费规则成功!");
                this.Close();
            }
            else
            {
                MessageBox.Show("添加扣费规则失败!");
            }
        }

        //日租
        private void backgroundWorker3_DoWork(object sender, DoWorkEventArgs e)
        {
            backgroundWorker3.ReportProgress(10);//这里让进度条显示进度
            b1 = ruleBLL.CostRuleInsert(costRule);
            backgroundWorker3.ReportProgress(60);//这里让进度条显示进度
            b2 = new LogBLL().LogInsert(logInfo);
            backgroundWorker3.ReportProgress(90);
        }

        private void backgroundWorker3_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }

        private void backgroundWorker3_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            progressBar1.Visible = false;
            btnOKDay.Enabled = true;
            if (b1)
            {

                MessageBox.Show("添加扣费规则成功!");

                this.Close();
            }
            else
            {
                MessageBox.Show("添加扣费规则失败!");
            }
        }
    }
}
