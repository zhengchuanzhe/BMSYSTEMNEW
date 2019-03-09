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
    public partial class VipLevelManageWindow : Form
    {
        public VipLevelInfo levelModel;
        public VipLevelBLL levelBLL;
        BackgroundWorker bg = new BackgroundWorker();
        public VipLevelManageWindow()
        {
            InitializeComponent();
            levelModel = new VipLevelInfo();
            levelBLL = new VipLevelBLL();
            bg.DoWork += new DoWorkEventHandler(bg_DoWork);//异步操作时要做的操作，一般去查列表，这个列表在本页面内先声明，然后在这个dowork方法里去取数填充他
            bg.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bg_RunWorkerCompleted);//这个是取数完成后进行的操作，去到数后，这里取用去到的列表绑定到控件

        }
        List<VipLevelInfo> levelList = new List<VipLevelInfo>();
        void bg_DoWork(object sender, DoWorkEventArgs e)
        {
            levelList = levelBLL.VipLevelSelect();
        }
        void bg_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            FillDp();
        }
        private void FillDp()
        {
               lvVipLevel.Items.Clear();
               VipLevelInfo levelTemp;
               for (int i = 0; i < levelList.Count; i++)
               {
                   levelTemp = levelList[i];
                   lvVipLevel.Items.Add("");
                   lvVipLevel.Items[i].SubItems.Add("");
                   lvVipLevel.Items[i].SubItems.Add("");
                   lvVipLevel.Items[i].SubItems.Add("");
                   lvVipLevel.Items[i].Tag = levelTemp.LvId;
                   lvVipLevel.Items[i].SubItems[0].Text = levelTemp.LvId.ToString();
                   lvVipLevel.Items[i].SubItems[1].Text = levelTemp.LvName;
                   lvVipLevel.Items[i].SubItems[2].Text = levelTemp.IsVip == true ? "会员" : "非会员";
               }
        }

        #region 修改会员等级
        private void 修改会员等级ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lvVipLevel.SelectedItems.Count != 1)
            {
                MessageBox.Show("请选择一行!");
            }
            else
            {
                int id = Convert.ToInt32(lvVipLevel.SelectedItems[0].Tag);
                ChangeVipLevelWindow changeLevelWindow = new ChangeVipLevelWindow(id);
                changeLevelWindow.ShowDialog();
               bg.RunWorkerAsync ();
            }
        }
        #endregion

        #region  删除会员等级
        private void 删除会员等级ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lvVipLevel.SelectedItems.Count != 1)
            {
                MessageBox.Show("请选择一行!");
            }
            else
            {
                DialogResult result = MessageBox.Show("该操作不可逆，请问您确认删除该会员等级吗？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.No)
                    return;
                int id = Convert.ToInt32(lvVipLevel.SelectedItems[0].Tag);
                string lvName = lvVipLevel.SelectedItems[0].SubItems[1].Text;
                VipLevelInfo levelInfo = new VipLevelInfo();
                levelInfo.LvId = id;
                levelInfo.LvName = lvName;
                if (levelBLL.VipLevelDelete(levelInfo as VipLevelInfo))
                {
                    MessageBox.Show("删除成功！");
                    LogInfo logInfo = new LogInfo();
                    logInfo.UserId = StaticData.userLocal.UserId;
                    logInfo.Content = "删除了名称为‘" + (levelInfo as VipLevelInfo).LvName + "'的会员等级";
                    logInfo.LogTime = DateTime.Now;
                    logInfo.DpId = StaticData.departLocal.DpId;
                    bool b = new LogBLL().LogInsert(logInfo);
                }
                else
                {
                    MessageBox.Show("删除失败！");
                }
                bg.RunWorkerAsync();
            }
        }
        #endregion

        #region 窗体加载
        private void VipLevelManageWindow_Load(object sender, EventArgs e)
        {
            bg.RunWorkerAsync ();
        }
        #endregion

    }
}
