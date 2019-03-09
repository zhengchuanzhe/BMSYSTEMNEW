using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BIKECOMMON;
using MODEL;
using BIKEBLL;
using System.Threading;

namespace BMSYSTEM
{
    public partial class UManageWindow : Form
    {
        UInfoBLL uBLL;
        UInfo uInfo;
        DepartInfo departInfo;
        DepartBLL departBLL;
        
        BackgroundWorker bg = new BackgroundWorker();
        public UManageWindow()
        {
            InitializeComponent();
            uInfo = new UInfo();
            uBLL = new UInfoBLL();
            departInfo = new DepartInfo();
            departBLL = new DepartBLL();
            bg.DoWork += new DoWorkEventHandler(bg_DoWork);//异步操作时要做的操作，一般去查列表，这个列表在本页面内先声明，然后在这个dowork方法里去取数填充他
            bg.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bg_RunWorkerCompleted);//这个是取数完成后进行的操作，去到数后，这里取用去到的列表绑定到控件
           

        }

        List<UInfo> uList = new List<UInfo>();
        void bg_DoWork(object sender, DoWorkEventArgs e)
        {
            uList = uBLL.UInfoSelect();
        }
        void bg_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            FillDp();
        }
        private void FillDp()
        {
            if (uList == null || uList.Count == 0)
            {
                MessageBox.Show("没有查找到相关数据!");
                return;
            }
            lvMessage.Items.Clear();
            for (int i = 0; i < uList.Count; i++)
            {
                lvMessage.Items.Add("");
                lvMessage.Items[i].SubItems.Add("");
                lvMessage.Items[i].SubItems.Add("");
                lvMessage.Items[i].SubItems.Add("");
                lvMessage.Items[i].SubItems.Add("");
                departInfo.DpId = uList[i].DepartId;
                departInfo = departBLL.DepartSelectById(departInfo);
                lvMessage.Items[i].Tag = uList[i].UId;
                lvMessage.Items[i].SubItems[0].Text = uList[i].U_Info;
                lvMessage.Items[i].SubItems[1].Text = departInfo.DpName;
                lvMessage.Items[i].SubItems[2].Text = uList[i].IsAdmin ? "是" : "否";
                lvMessage.Items[i].SubItems[3].Text = uList[i].AddDate.ToString();
            }
        }


        
        private void 修改加密狗信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(lvMessage.SelectedItems[0].Tag);
            UInfoChange uChage = new UInfoChange(id);
            uChage.ShowDialog();
            bg.RunWorkerAsync();
        }

        private void BtnDeleteClick(object uInfo)
        {
            

        }
        private void 删除加密狗ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lvMessage.SelectedItems.Count != 1)
            {
                MessageBox.Show("请选择一行!");
            }
            else
            {
                DialogResult result = MessageBox.Show("该操作不可逆，请问您确认删除该用户吗？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.No)
                    return;
                int id = Convert.ToInt32(lvMessage.SelectedItems[0].Tag);
                uInfo.UId = id;
                if (uBLL.UInfoDelete(uInfo as UInfo))
                {
                    MessageBox.Show("删除成功!");
                }
                else
                {
                    MessageBox.Show("删除失败!");
                }
                bg.RunWorkerAsync();
            }
        }

        private void UManageWindow_Load(object sender, EventArgs e)
        {
            bg.RunWorkerAsync();
        }
    }
}
