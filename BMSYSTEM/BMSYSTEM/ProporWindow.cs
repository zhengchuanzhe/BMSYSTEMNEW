using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Text.RegularExpressions;
using BIKEBLL;
using MODEL;

namespace BMSYSTEM
{
    public partial class ProporWindow : Form
    {
        Integral inteModel;
        IntegralBLL inteBLL;
        public ProporWindow()
        {
            InitializeComponent();
            inteModel = new Integral();
            inteBLL = new IntegralBLL();

        }
        private delegate void UpdateProPor();
        private void FillPropor()
        {
            inteModel = inteBLL.GetIntegralMessage();
            txtMoney.BeginInvoke(new UpdateProPor(updateMoney));
        }
        private void updateMoney()
        {
            txtMoney.Text = inteModel.Value.ToString();
        }
        private void btnOk_Click(object sender, EventArgs e)
        {
            if (txtMoney.Text.Trim() == "")
            {
                epMessage.SetError(txtMoney, "请输入金额");
                return;
            }
            if (!Regex.IsMatch(txtMoney.Text.Trim(), @"^[0-9]*[1-9][0-9]*$"))
            {
                epMessage.SetError(txtMoney, "请输入正确的金额");
                return;
            }
            int money = Convert.ToInt32(txtMoney.Text.Trim());
            inteModel.Value = money;
            inteModel.Meaning = "积分兑换比例";

            if (inteBLL.UpdateIntegralMessage(inteModel))
            {
                MessageBox.Show("修改成功!");
                this.Close();
            }
            else
            {
                MessageBox.Show("修改出错!");
            }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ProporWindow_Load(object sender, EventArgs e)
        {
            Thread myThread = new Thread(new ThreadStart(FillPropor));
            myThread.IsBackground = true;
            myThread.Start();
        }
    }
}
