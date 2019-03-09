using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Threading;
using MODEL;
using BIKEBLL;

namespace BMSYSTEM
{
    public partial class ChangeRuleWindow : Form
    {
        public int crId;
        CostRule ruleModel;
        CostRuleBLL ruleBLL;
        VipLevelBLL vipLvBLL;
        List<VipLevelInfo> listlV;
        int lvId;
        VipLevelInfo levelModel;
        VipLevelBLL levelBLL = new VipLevelBLL();
        string[] danwei = { "分钟", "小时", "天", "月" };//单位
        #region 窗体实例化
        public ChangeRuleWindow(int crid)
        {
            InitializeComponent();
            crId = crid;
            ruleModel = new CostRule();
            ruleBLL = new CostRuleBLL();
            vipLvBLL = new VipLevelBLL();
            levelModel = new VipLevelInfo();
            levelBLL = new VipLevelBLL();
            listlV = new List<VipLevelInfo>();
            ruleModel.CrId = crid;
            bg.DoWork += new DoWorkEventHandler(bg_DoWork);
            bg.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bg_RunWorkerCompleted);
        }
        BackgroundWorker bg = new BackgroundWorker();
        void bg_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            cmbLvId.DataSource = listlV;
            cmbLvId.DisplayMember = "LVNAME";
            cmbLvId.ValueMember = "LVID";
            cmbLvId.SelectedValue = lvId;

            txtRuleName.Text = ruleTemp.CrName;
            txtCostPh.Text = ruleTemp.CostPh.ToString();
            lbDanwei.Text = danwei[ruleTemp.crKind - 1];
            lbDanwei2.Text = danwei[ruleTemp.crKind];
            txtCostTime.Text = ruleTemp.CostTime.ToString();
            txtCostBegin.Text = ruleTemp.costBegin.ToString();
            txtConTime.Text = ruleTemp.conTime.ToString();
            cmbLvId.SelectedValue = ruleTemp.LvId;
        }
        CostRule ruleTemp;
        void bg_DoWork(object sender, DoWorkEventArgs e)
        {
            listlV = vipLvBLL.VipLevelSelect();
            ruleTemp = ruleBLL.CostRuleSelectById(ruleModel);
            ruleModel.crKind = ruleTemp.crKind;
            lvId = ruleTemp.LvId;
        }
        #endregion
        #region 绑定下拉框
        private delegate void FillCmbLVDelegate();
        private void FillCmbLVMethod()
        {

        }
        private void FillCmbLV()
        {

            //  cmbLvId.Invoke(new FillCmbLVDelegate(FillCmbLVMethod));
        }
        #endregion

        private void ChangeRuleWindow_Load(object sender, EventArgs e)
        {
            bg.RunWorkerAsync();
        }

        #region 根据Id获取规则信息
        private void GetRuleById(object rule)
        {



            this.Invoke(new Action(() =>
                {

                }
                ));
        }
        #endregion

        #region 确认按钮点击事件
        private void btnOKClick()
        {
            this.Invoke(new Action(() =>
            {
                ruleModel.CrName = txtRuleName.Text.Trim();
                ruleModel.conTime = Convert.ToInt32(txtConTime.Text.Trim());
                ruleModel.costBegin = Convert.ToDouble(txtCostBegin.Text.Trim());
                ruleModel.CostPh = Convert.ToDouble(txtCostPh.Text.Trim());
                ruleModel.CostTime = Convert.ToInt32(txtCostTime.Text.Trim());
                ruleModel.LvId = (int)cmbLvId.SelectedValue;
                if (ruleBLL.CostRuleUpdate(ruleModel))
                {
                    MessageBox.Show("修改成功");
                    LogInfo logInfo = new LogInfo();
                    logInfo.UserId = StaticData.userLocal.UserId;
                    logInfo.Content = "添加了名称为‘" + txtRuleName.Text + "'的扣费规则信息";
                    logInfo.LogTime = DateTime.Now;
                    logInfo.DpId = StaticData.departLocal.DpId;
                    bool b = new LogBLL().LogInsert(logInfo);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("修改失败");
                }
            }));
        }
        private void btnOK_Click(object sender, EventArgs e)
        {
            if (txtRuleName.Text.Trim() == "" || txtRuleName.Text.Trim() == null)
            {
                epName.SetError(txtRuleName, "请填写扣费规则名称!");
                return;
            }
            else
            {
                epName.SetError(txtRuleName, "");
            }
            if (txtCostPh.Text.Trim() == "" || txtCostPh.Text.Trim() == null)
            {
                epCostPh.SetError(txtCostPh, "请填写单位时间扣费金额!");
                return;
            }
            else if (!Regex.IsMatch(txtCostPh.Text.Trim(), @"^[0-9]*[1-9][0-9]*$"))
            {
                epCostPh.SetError(txtCostPh, "请输入正确的金额!");
                return;
            }
            else
            {
                epName.SetError(txtCostPh, "");
            }
            if (txtCostBegin.Text.Trim() == "" || txtCostBegin.Text.Trim() == null)
            {
                epCostBegin.SetError(txtCostBegin, "请填写初始金额!");
                return;
            }
            else if (!Regex.IsMatch(txtCostBegin.Text.Trim(), @"^[0-9]*[1-9][0-9]*$"))
            {
                epCostPh.SetError(txtCostBegin, "请填写正确的金额!");
                return;
            }
            else
            {
                epName.SetError(txtCostBegin, "");
            }
            if (txtCostTime.Text.Trim() == "" || txtCostTime.Text.Trim() == null)
            {
                epCostBegin.SetError(txtCostTime, "请填写扣费时间!");
                return;
            }
            else if (!Regex.IsMatch(txtCostTime.Text.Trim(), @"^[0-9]*[1-9][0-9]*$"))
            {
                epCostBegin.SetError(txtCostTime, "请填写正确的时间!");
                return;
            }
            else
            {
                epName.SetError(txtCostTime, "");
            }
            if (txtConTime.Text.Trim() == "" || txtConTime.Text.Trim() == null)
            {
                epCostBegin.SetError(txtConTime, "请输入包含时间!");
                return;
            }
            else if (!Regex.IsMatch(txtConTime.Text.Trim(), @"^[0-9]*[1-9][0-9]*$"))
            {
                epCostBegin.SetError(txtConTime, "请输入正确的时间!");
                return;
            }
            else
            {
                epName.SetError(txtConTime, "");
            }
            Thread th = new Thread(new ThreadStart(btnOKClick));
            th.IsBackground = true;
            th.Start();
        }
        #endregion

        #region 取消按钮点击事件
        private void tnCancle_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion


    }
}
