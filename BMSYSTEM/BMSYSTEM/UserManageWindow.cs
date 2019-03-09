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
using System.Management;
using System.Threading;

namespace BMSYSTEM
{
    public partial class UserManageWindow : Form
    {
        public UserInfo userModel;
        public UserBLL userBLL;
        public DepartBLL departBLL;
        private DepartInfo departInfo;
        BackgroundWorker bg = new BackgroundWorker();
        public UserManageWindow()
        {
            InitializeComponent();
            userModel = new UserInfo();
            userBLL = new UserBLL();
            departBLL = new DepartBLL();
            departInfo = new DepartInfo();
            bg.DoWork += new DoWorkEventHandler(bg_DoWork);//异步操作时要做的操作，一般去查列表，这个列表在本页面内先声明，然后在这个dowork方法里去取数填充他
            bg.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bg_RunWorkerCompleted);//这个是取数完成后进行的操作，去到数后，这里取用去到的列表绑定到控件
        }

        List<UserInfo> userList = new List<UserInfo>();
        void bg_DoWork(object sender, DoWorkEventArgs e)
        {
            userList = userBLL.SelectUser();
        }
        void bg_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            FillDp();
        }
        private void FillDp()
        {
            lvUser.Items.Clear();
            UserInfo userTemp;
            for (int i = 0; i < userList.Count; i++)
            {
                userTemp = userList[i];
                departInfo.DpId = userTemp.DpId;
                departInfo = departBLL.DepartSelectById(departInfo);
                lvUser.Items.Add("");
                lvUser.Items[i].SubItems.Add("");
                lvUser.Items[i].SubItems.Add("");
                lvUser.Items[i].SubItems.Add("");
                lvUser.Items[i].SubItems.Add("");
                lvUser.Items[i].SubItems.Add("");
                lvUser.Items[i].Tag = userTemp.UserId;
                lvUser.Items[i].SubItems[0].Text = userTemp.UserId.ToString();
                lvUser.Items[i].SubItems[1].Text = userTemp.UserName;
                lvUser.Items[i].SubItems[2].Text = userTemp.UserPhone;
                lvUser.Items[i].SubItems[3].Text = userTemp.UserCard;
                lvUser.Items[i].SubItems[4].Text = departInfo.DpName;
            }
        }


      

        #region 修改用户信息
        private void 修改用户信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lvUser.SelectedItems.Count != 1)
            {
                MessageBox.Show("请选择一行!");
            }
            else
            {
                int id = Convert.ToInt32(lvUser.SelectedItems[0].Tag);
                ChangeUserWindow changeUserWindow = new ChangeUserWindow(id);
                changeUserWindow.ShowDialog();
                bg.RunWorkerAsync();
            }
        }
        #endregion

        #region 删除用户
        private void 删除用户ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lvUser.SelectedItems.Count != 1)
            {
                MessageBox.Show("请选择一行!");
            }
            else
            {
                DialogResult result = MessageBox.Show("该操作不可逆，请问您确认删除该用户吗？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.No)
                    return;
                int id = Convert.ToInt32(lvUser.SelectedItems[0].Tag);
                string userName = lvUser.SelectedItems[0].SubItems[1].Text;
                UserInfo userInfo = new UserInfo();
                userInfo.UserId = id;
                userInfo.UserName = userName;
                if (userBLL.DeleteUser(userInfo as UserInfo))
                {
                    MessageBox.Show("删除成功！");
                    LogInfo logInfo = new LogInfo();
                    logInfo.UserId = StaticData.userLocal.UserId;
                    logInfo.Content = "删除了用户，名称为‘" + (userInfo as UserInfo).UserName + "'";
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

        private void UserManageWindow_Load(object sender, EventArgs e)
        {
            bg.RunWorkerAsync();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

        }
    }
}
