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
    public partial class AddVipLevelWindow : Form
    {
        public AddVipLevelWindow()
        {
            InitializeComponent();
        }

        #region 确认按钮点击事件
        private void btnOKClick()
        {
            this.Invoke(new Action(() =>
            {
                VipLevelInfo vipLevel = new VipLevelInfo();
                if (rbVip.Checked)
                {
                    vipLevel.IsVip = true;
                }
                else if (rbNoVip.Checked)
                {
                    vipLevel.IsVip = false;
                }
                else
                {
                    vipLevel.IsVip = true;
                }
                vipLevel.LvName = txtLvName.Text.Trim();
                if (new VipLevelBLL().VipLevelInsert(vipLevel))
                {
                    MessageBox.Show("添加成功");
                    LogInfo logInfo = new LogInfo();
                    logInfo.UserId = StaticData.userLocal.UserId;
                    logInfo.Content = "添加了会员等级，名称为‘" + txtLvName.Text + "'";
                    logInfo.LogTime = DateTime.Now;
                    logInfo.DpId = StaticData.departLocal.DpId;
                    bool b = new LogBLL().LogInsert(logInfo);
                    btnOK.Enabled = false;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("添加失败");
                }
            }));
        }
        private void btnOK_Click(object sender, EventArgs e)
        {
            if (txtLvName.Text.Trim() == "")
            {
                epInfo.SetError(txtLvName, "请输入等级名称");
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

        private void AddVipLevelWindow_Load(object sender, EventArgs e)
        {
            rbVip.Checked = true;
        }

    }
}
