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
    public partial class ChangeVipLevelWindow : Form
    {
        VipLevelInfo levelModel;
        VipLevelBLL levelBLL;
        int levelId;

        #region 实例化窗体
        public ChangeVipLevelWindow(int levelid)
        {
            InitializeComponent();
            levelModel = new VipLevelInfo();
            levelBLL = new VipLevelBLL();
            levelModel.LvId = levelid;
            levelId = levelid;

        }
        #endregion

        private void BindingCmb()
        {
            this.Invoke(new Action(() =>
            {
                levelModel = levelBLL.VipLevelSelectById(levelModel);
                txtLvName.Text = levelModel.LvName;
                if (levelModel.IsVip)
                {
                    rbVip.Checked = true;
                }
                else
                {
                    rbNoVip.Checked = true;
                }

            }));


        }

        #region 确认按钮点击事件
        private void btnOKClick()
        {
            this.Invoke(new Action(() =>
            {


                levelModel.LvId = levelId;
                levelModel.LvName = txtLvName.Text.Trim();
                levelModel.IsDelete = false;
                if (rbVip.Checked)
                {
                    levelModel.IsVip = true;
                }
                else
                {
                    levelModel.IsVip = false;
                }
                if (levelBLL.VipLevelUpdate(levelModel))
                {
                    MessageBox.Show("修改成功");
                    LogInfo logInfo = new LogInfo();
                    logInfo.UserId = StaticData.userLocal.UserId;
                    logInfo.Content = "修改了名称为‘" + txtLvName.Text + "'的会员等级信息";
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
            if (txtLvName.Text.Trim() == "")
            {
                epInfo.SetError(txtLvName, "请输入会员等级名称");
                return;
            }
            else
            {
                epInfo.SetError(txtLvName ,"");
            }
            Thread th = new Thread(new ThreadStart(btnOKClick));
            th.IsBackground = true;
            th.Start();
        }
        #endregion

        #region 取消按钮点击事件
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        private void ChangeVipLevelWindow_Load(object sender, EventArgs e)
        {
            Thread th = new Thread(new ThreadStart(BindingCmb));
            th.IsBackground = true;
            th.Start();
        }


    }
}
