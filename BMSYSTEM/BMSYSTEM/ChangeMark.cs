using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BIKEBLL;

namespace BMSYSTEM
{
    public partial class ChangeMark : Form
    {
        VipBorrowBLL vipBorrowBLL;
        VipNoBorrowBLL vipNoBorrowBLL;
        string BBID;
        bool IsVip;
        public ChangeMark(string BBID,string Mark,bool isVip)
        {
            InitializeComponent();
            txtMark.Text = Mark;
            this.BBID = BBID;
            IsVip = isVip;
            vipBorrowBLL = new VipBorrowBLL();
            vipNoBorrowBLL = new VipNoBorrowBLL();
        }

        //确定按钮
        private void btnOK_Click(object sender, EventArgs e)
        {
            DialogResult result1 = MessageBox.Show("修改备注?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result1 == DialogResult.No)
                return;
            if (IsVip)
            {
                try
                {
                    if (vipBorrowBLL.vipMarkUpdate(BBID ,txtMark .Text .Trim ()))
                    {
                         MessageBox.Show("操作成功");
                         this.Close();
                    }
                    else
                    {
                        MessageBox.Show("操作失败");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("操作失败");
                }
            }
            else
            {

                try
                {
                    if (vipNoBorrowBLL.vipNoMarkUpdate(BBID, txtMark.Text.Trim()))
                    {
                        MessageBox.Show("操作成功");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("操作失败");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("操作失败");
                }
            }
        }

        //取消按钮
        private void btnCencel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
