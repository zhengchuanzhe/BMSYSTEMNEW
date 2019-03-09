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

namespace BMSYSTEM
{
    public partial class UserLogin : Form
    {
        UserBLL userBLL;
        UserInfo userInfo;
        public UserLogin()
        {
            InitializeComponent();
            userBLL = new UserBLL();
            userInfo = new UserInfo();
        }
        #region 登陆按钮点击事件
        private void btnOK_Click(object sender, EventArgs e)
        {
            if (txtUserName.Text.Trim() == "")
            {
                epMessage1.SetError(txtUserName, "请输入用户名!");
                return;
            }
            else if (txtUserPWD.Text.Trim() == "")
            {
                epMessage1.SetError(txtUserPWD, "请输入密码!");
                return;
            }
            userInfo = new UserInfo();
            userInfo.UserName = txtUserName.Text;
            userInfo.UserPwd = txtUserPWD.Text;
            userInfo = userBLL.SelectUserByNameAndPWD(userInfo);
            if (userInfo != null)
            {
                this.Hide();
                LogInfo logInfo = new LogInfo();
                logInfo.UserId = userInfo.UserId;
                logInfo.LogTime = DateTime.Now;
                logInfo.Content = "用户" + userInfo.UserName + "登录了该系统";
                logInfo.DpId = StaticData.departLocal.DpId;
                bool b = new LogBLL().LogInsert(logInfo);
                StaticData.userLocal = userInfo;
                MainForm mainForm = new MainForm();
                mainForm.Show();
            }
            else
            {
                MessageBox.Show("用户名或密码错误");
            }
        }
        #endregion

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void UserLogin_Load(object sender, EventArgs e)
        {

        }

        private void btnOK_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void UserLogin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnOK_Click(sender, e);
            }
        }
    }
}
