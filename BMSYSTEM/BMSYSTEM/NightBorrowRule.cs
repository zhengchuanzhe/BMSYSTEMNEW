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
    public partial class NightBorrowRule : Form
    {
        NightBorrow nightBorrow;
        NightBorrowBLL nightBorrowBLL;
        public NightBorrowRule(bool isAdmin)
        {
            InitializeComponent();
            nightBorrow = new NightBorrow();
            nightBorrowBLL = new NightBorrowBLL();
        }

        //页面加载
        private void NightBorrowRule_Load(object sender, EventArgs e)
        {
            rdVip.Checked = true;
        }

        //包夜租车填充信息
        private void fillMessage(string id)
        {
            nightBorrow = nightBorrowBLL.nightBorrowSelect(id);
            txtNightCost.Text = nightBorrow.Cost.ToString();
            txtStartTime.Text = nightBorrow.BeginTime.ToString();
            txtEndTime.Text = nightBorrow.EndTime;
        }

        //会员与非会员按钮互换
        private void rbtnBorrow_CheckedChanged(object sender, EventArgs e)
        {
            if (rdVip.Checked)
            {
                fillMessage("1");
            }
            else
            {
                fillMessage("2");
            }
        }

        //确定按钮
        private void btOk_Click(object sender, EventArgs e)
        {
            int a=0;
            if (!int.TryParse (txtNightCost.Text,out a))
            {
                errorProvider1.SetError(txtNightCost, "请输入正确扣费金额");
                return;
            }
            if (int .Parse (txtNightCost .Text)<=0)
            {
                 errorProvider1.SetError(txtNightCost, "请输入正确扣费金额");
                return;
            }
            else
            {
                errorProvider1.SetError(txtNightCost, "");
            }
            if (!int.TryParse (txtStartTime.Text ,out a))
            {
                errorProvider1.SetError(txtStartTime, "请输入正确时间");
                return;
            }
            if (int.Parse(txtStartTime.Text) <= 0)
            {
                errorProvider1.SetError(txtStartTime, "请输入正确时间");
                return;
            }
            else
            {
                errorProvider1.SetError(txtStartTime ,"");
            }
            if (!int.TryParse(txtEndTime.Text, out a))
            {
                errorProvider1.SetError(txtEndTime, "请输入正确时间");
                return;
            }
            if (int.Parse(txtEndTime.Text) <= 0)
            {
                errorProvider1.SetError(txtEndTime, "请输入正确时间");
                return;
            }
            else
            {
                errorProvider1.SetError(txtEndTime, "");
            }
            if (int.Parse (txtStartTime .Text )<=int .Parse (txtEndTime .Text ))
            {
                errorProvider1.SetError(txtStartTime, "请输入正确时间");
                errorProvider1.SetError(txtEndTime, "请输入正确时间");
                return;
            }
            else
            {
                errorProvider1.SetError(txtEndTime, "");
                errorProvider1.SetError(txtStartTime, "");
            }
            nightBorrow.Cost = txtNightCost.Text;
            nightBorrow.BeginTime = txtStartTime.Text;
            nightBorrow.EndTime = txtEndTime.Text;
            if (rdVip.Checked)
            {
                nightBorrow.Id = "1";
                if (!nightBorrowBLL.RuleUpdate(nightBorrow))
                {
                    MessageBox.Show("网络问题，修改失败！");
                }
                else
                {
                    MessageBox.Show("修改成功！");
                    this.Close();
                }
            }
            else
            {
                nightBorrow.Id = "2";
                if (!nightBorrowBLL.RuleUpdate(nightBorrow))
                {
                    MessageBox.Show("网络问题，修改失败！");
                }
                else
                {
                    MessageBox.Show("修改成功！");
                    this.Close();
                }
            }
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
