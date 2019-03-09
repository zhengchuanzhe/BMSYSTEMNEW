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
    public partial class checkPassword2 : Form
    {
        string vipPwd;
        public bool isTrue = false;
        public checkPassword2(string VipPWD)
        {
            InitializeComponent();
            vipPwd = VipPWD;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (txtPassWord .Text .Trim ()==vipPwd )
            {
                isTrue = true;
                this.Close();
            }
            else
            {
                MessageBox.Show("密码错误!");
            }
        }

        private void btnCencel_Click(object sender, EventArgs e)
        {
            isTrue = true;
            this.Close();
        }
    }
}
