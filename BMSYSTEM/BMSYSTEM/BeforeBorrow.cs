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
    public partial class BeforeBorrow : Form
    {
        public bool isTrue = false;//返回值，用于判断是否验证通过，验证通过为true不通过为false
        public int vipId = 0;//返回验证成功的VIP的ID;
        public bool isVip;//是否是会员验证
        VipBLL vipBLL;
        VIPInfo vipInfo;
        VipNoBLL vipNoBLL;
        VipNoInfo vipNoInfo;
        bool IsBorrow;
        public BeforeBorrow(bool isvip,bool isBorrow)
        {
            InitializeComponent();
            isVip = isvip;
            vipBLL = new VipBLL();
            vipInfo = new VIPInfo();
            vipNoBLL = new VipNoBLL();
            vipNoInfo = new VipNoInfo();
            IsBorrow = isBorrow;
        }

        public BeforeBorrow(string num, bool isvip, bool isBorrow)
        {
            InitializeComponent();
            txtCard.Text = num;
            isVip = isvip;
            vipBLL = new VipBLL();
            vipInfo = new VIPInfo();
            vipNoBLL = new VipNoBLL();
            vipNoInfo = new VipNoInfo();
            IsBorrow = isBorrow;
        }
        private void btnOK_Click(object sender, EventArgs e)
        {
            if (txtCard.Text.Trim() == "")
            {
                epMessage.SetError(txtCard, "请刷入卡号或姓名!");
                return;
            }
            if (txtPwd.Text.Trim() == "")
            {
                epMessage.SetError(txtPwd, "请输入密码!");
                return;
            }
            if (isVip)
            {
                vipInfo.VipNumber = txtCard.Text.Trim();
                vipInfo.VipPWD = txtPwd.Text.Trim();
                vipInfo = vipBLL.VipCheck(vipInfo);
                if (vipInfo.VipId == 0)
                {
                    MessageBox.Show("租车密码与卡号不相符!");
                }
                else
                {
                    isTrue = true;
                    vipId = vipInfo.VipId;
                    this.Close();
                }
            }
            else
            {
                vipNoInfo.VipNumber = txtCard.Text.Trim();
                vipNoInfo.VipPwd = txtPwd.Text.Trim();
                vipNoInfo = vipNoBLL.VipNoCheck(vipNoInfo);
                if (vipNoInfo.VipId == 0)
                {
                    MessageBox.Show("租车密码与卡号不相符!");
                }
                else
                {
                    isTrue = true;
                    vipId = vipNoInfo.VipId;
                    this.Close();
                }
            }

        }
        #region 取消按钮点击事件
        private void btnCencel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        private void BeforeBorrow_Load(object sender, EventArgs e)
        {
            if (isVip )
            {
                lbTs.Text = "————请刷入会员卡————";
                if (IsBorrow)
                {
                    LabBorrowOrReturn.Text = "会员租车";
                }
                else
                {
                    LabBorrowOrReturn.Text = "会员还车";
                }
            }
            else
            {
                lbTs.Text = "————请刷入非会员卡————";
                if (IsBorrow)
                {
                    LabBorrowOrReturn.Text = "非会员租车";
                }
                else
                {
                    LabBorrowOrReturn.Text = "非会员还车";
                }
            }
        }
    }
}
