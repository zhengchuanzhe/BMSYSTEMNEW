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
    public partial class ChangeUser : Form
    {
        UserBLL userBLL;
        public ChangeUser()
        {
            InitializeComponent();
            userBLL = new UserBLL();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ChangeUser_Load(object sender, EventArgs e)
        {
            MODEL.ChangeUser changeInfo = userBLL.ChangeLoginUser(StaticData.userLocal.UserId);
            lbVip.Text = changeInfo.VipIncome.ToString();
            lbvipNo.Text = changeInfo.VipNoIncome.ToString();
            lbNewIncome.Text = changeInfo.NewVip.ToString();
            lbTotal.Text = (changeInfo.VipIncome + changeInfo.VipNoIncome + changeInfo.NewVip).ToString ();
        }
    }
}
