using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BMSYSTEM
{
    public partial class CheckPassWord : Form
    {
        string vipName, money, passWord;
        public bool IsTrue=false ;
        public CheckPassWord(string VipName,string Money,string PassWord)
        {
            InitializeComponent();
            vipName = VipName;
            money = Money;
            passWord = PassWord;
        }

        private void CheckPassWord_Load(object sender, EventArgs e)
        {
            labName.Text = vipName;
            labMoney.Text = money+"元";
        }

        private void btOk_Click(object sender, EventArgs e)
        {
            if (passWord !=txtPassWord .Text .Trim ())
            {
                MessageBox.Show("密码错误！");
                return;
            }
            else
            {
                IsTrue = true;
                this.Close();
            }
        }

        private void btnCencel_Click(object sender, EventArgs e)
        {
            IsTrue = true;
            this.Close();
        }



    }
}
