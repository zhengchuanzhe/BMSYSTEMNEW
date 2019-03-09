using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using MODEL;
using BIKEBLL;

namespace BMSYSTEM
{
    public partial class DepartManageWindow : Form
    {
        DepartInfo departModel;
        BackgroundWorker bg = new BackgroundWorker();
        List<DepartInfo> departList = new List<DepartInfo>();
        DepartBLL departBLL;

        #region 窗体实例化
        public DepartManageWindow()
        {
            bg.DoWork += new DoWorkEventHandler(bg_DoWork);//异步操作时要做的操作，一般去查列表，这个列表在本页面内先声明，然后在这个dowork方法里去取数填充他
            bg.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bg_RunWorkerCompleted);//这个是取数完成后进行的操作，去到数后，这里取用去到的列表绑定到控件
            
            InitializeComponent();
            departModel = new DepartInfo();
            departBLL = new DepartBLL();

        }
        #endregion


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

            lvDepart.Items.Clear();
            DepartInfo departTemp;
            for (int i = 0; i < departList.Count; i++)
            {
                departTemp = departList[i];
                lvDepart.Items.Add("");
                lvDepart.Items[i].SubItems.Add("");
                lvDepart.Items[i].SubItems.Add("");
                lvDepart.Items[i].SubItems.Add("");
                lvDepart.Items[i].SubItems.Add("");
                lvDepart.Items[i].Tag = departTemp.DpId;
                lvDepart.Items[i].SubItems[0].Text = departTemp.DpId.ToString();
                lvDepart.Items[i].SubItems[1].Text = departTemp.DpName;
                lvDepart.Items[i].SubItems[2].Text = departTemp.DpPlace;
                lvDepart.Items[i].SubItems[3].Text = departTemp.DpPCMAC;
            }
        }


        #region 窗体加载
        private void DepartManageWindow_Load(object sender, EventArgs e)
        {
            bg.RunWorkerAsync();
        }
        #endregion

        #region 修改分店信息点击事件
        private void 修改分店信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lvDepart.SelectedItems.Count != 1)
            {
                MessageBox.Show("请选择一行!");
            }
            else
            {
                int id = Convert.ToInt32(lvDepart.SelectedItems[0].Tag);
                ChangeDepartWindow changeDepartWindow = new ChangeDepartWindow(id);
                changeDepartWindow.ShowDialog();
                bg.RunWorkerAsync();
            }
        }
        #endregion

        #region 删除分店点击事件
        private void 删除分店ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lvDepart.SelectedItems.Count != 1)
            {
                MessageBox.Show("请选择一行!");
            }
            else
            {
                DialogResult result = MessageBox.Show("该操作不可逆，请问您确认删除该分店吗？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.No)
                    return;
                int id = Convert.ToInt32(lvDepart.SelectedItems[0].Tag);
                string dpName = lvDepart.SelectedItems[0].SubItems[1].Text;
                DepartInfo departInfo = new DepartInfo();
                departInfo.DpId = id;
                departInfo.DpName = dpName;
                if (departBLL.DepartDelete((DepartInfo)departInfo))
                {
                    MessageBox.Show("删除成功！");
                    LogInfo logInfo = new LogInfo();
                    logInfo.UserId = StaticData.userLocal.UserId;
                    logInfo.Content = "删除了分店，名称为‘" + (departInfo as DepartInfo).DpName + "'";
                    logInfo.LogTime = DateTime.Now;
                    logInfo.DpId = StaticData.departLocal.DpId;
                    bool b = new LogBLL().LogInsert(logInfo);
                }
                else
                {
                    MessageBox.Show("删除失败！");
                    return;
                }
                bg.RunWorkerAsync();
            }
        }
        #endregion
    }
}
