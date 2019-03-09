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
    public partial class RuleManageWindow : Form
    {
        CostRule ruleModel;
        CostRuleBLL ruleBLL;
        VipLevelBLL vipLvBLL;
        BackgroundWorker bg = new BackgroundWorker();
        List<CostRule> ruleList = new List<CostRule>();
        VipLevelInfo vipLvInfo;
        VipLevelInfo levelModel;
        VipLevelBLL levelBLL;
        string[] borrowKind = { "", "日租", "月租", "年租" };///租车类型根据相关枚举赋值
        string[] danwei = { "分钟", "小时", "天", "月" };//单位
        #region 窗体实例化
        public RuleManageWindow()
        {
            InitializeComponent();
            ruleModel = new CostRule();
            ruleBLL = new CostRuleBLL();
            vipLvBLL = new VipLevelBLL();
            levelModel = new VipLevelInfo();
            levelBLL = new VipLevelBLL();
            bg.DoWork += new DoWorkEventHandler(bg_DoWork);//异步操作时要做的操作，一般去查列表，这个列表在本页面内先声明，然后在这个dowork方法里去取数填充他
            bg.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bg_RunWorkerCompleted);//这个是取数完成后进行的操作，去到数后，这里取用去到的列表绑定到控件
           
        }
        #endregion

        void bg_DoWork(object sender, DoWorkEventArgs e)
        {
            ruleList = ruleBLL.CostRuleSelect();
        }
        void bg_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            FillDp();
        }
        private void FillDp()
        {

            lvRule.Items.Clear();
            CostRule ruleTemp;
            for (int i = 0; i < ruleList.Count; i++)
            {

                ruleTemp = ruleList[i];
                vipLvInfo = new VipLevelInfo();
                vipLvInfo.LvId = ruleTemp.LvId;
                lvRule.Items.Add("");
                lvRule.Items[i].SubItems.Add("");
                lvRule.Items[i].SubItems.Add("");
                lvRule.Items[i].SubItems.Add("");
                lvRule.Items[i].SubItems.Add("");
                lvRule.Items[i].SubItems.Add("");
                lvRule.Items[i].SubItems.Add("");
                lvRule.Items[i].SubItems.Add("");
                lvRule.Items[i].SubItems.Add("");
                lvRule.Items[i].Tag = ruleTemp.CrId;
                lvRule.Items[i].SubItems[0].Text = ruleTemp.CrId.ToString();
                lvRule.Items[i].SubItems[1].Text = ruleTemp.CrName;
                lvRule.Items[i].SubItems[2].Text = ruleTemp.CostPh.ToString() + "元";
                lvRule.Items[i].SubItems[3].Text = borrowKind[ruleTemp.crKind];
                lvRule.Items[i].SubItems[4].Text = ruleTemp.CostTime.ToString() + danwei[ruleTemp.crKind - 1];//扣费时间的单位比包含时间的单位小一度，日租是每小时的几分扣费当一个小时，月租每天的几个小时扣费当一天，年租每月的几天扣费当一月
                lvRule.Items[i].SubItems[5].Text = ruleTemp.costBegin.ToString() + "元";
                lvRule.Items[i].SubItems[6].Text = ruleTemp.conTime.ToString() + danwei[ruleTemp.crKind];//时间单位，日租的时间单位是小时，月租时间单位是天，年租时间单位是月
                lvRule.Items[i].SubItems[7].Text = vipLvBLL.VipLevelSelectById(vipLvInfo).LvName;
                levelModel.LvId = ruleTemp.LvId;
                levelModel = levelBLL.VipLevelSelectById(levelModel);
                lvRule.Items[i].SubItems[7].Text = levelModel.LvName;
            }
        }

       

        #region 窗体加载
        private void RuleManageWindow_Load(object sender, EventArgs e)
        {
            bg.RunWorkerAsync();
        }
        #endregion

        #region 修改扣费规则
        private void 修改扣费规则ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lvRule.SelectedItems.Count != 1)
            {
                MessageBox.Show("请选择一行!");
            }
            else
            {
                int id = Convert.ToInt32(lvRule.SelectedItems[0].Tag);
                ChangeRuleWindow changeRuleWindow = new ChangeRuleWindow(id);
                changeRuleWindow.ShowDialog();
                bg.RunWorkerAsync();
            }
        }
        #endregion

        #region 删除扣费规则
     
        private void 删除扣费规则ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lvRule.SelectedItems.Count != 1)
            {
                MessageBox.Show("请选择一行!");
            }
            else
            {
                DialogResult result = MessageBox.Show("该操作不可逆，请问您确认删除该用户吗？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.No)
                    return;
                int id = Convert.ToInt32(lvRule.SelectedItems[0].Tag);
                string ruleName = lvRule.SelectedItems[0].SubItems[1].Text;
                CostRule ruleInfo = new CostRule();
                ruleInfo.CrId = id;
                ruleInfo.CrName = ruleName;
                if (ruleBLL.CostRuleDelete(ruleInfo as CostRule))
                {

                    LogInfo logInfo = new LogInfo();
                    logInfo.UserId = StaticData.userLocal.UserId;
                    logInfo.Content = "删除了名称为‘" + (ruleInfo as CostRule).CrName + "'的扣费规则";
                    logInfo.LogTime = DateTime.Now;
                    logInfo.DpId = StaticData.departLocal.DpId;
                    bool b = new LogBLL().LogInsert(logInfo);
                    MessageBox.Show("删除成功！");
                }
                else
                {
                    MessageBox.Show("删除失败！");
                }
                bg.RunWorkerAsync();
            }
        }
        #endregion

    }
}
