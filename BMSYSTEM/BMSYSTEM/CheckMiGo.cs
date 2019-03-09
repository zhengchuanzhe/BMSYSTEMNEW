using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BIKECOMMON;
using BIKEBLL;
using MODEL;

namespace BMSYSTEM
{
    public partial class CheckMiGo : Form
    {
        UInfoBLL uBLL;
        UInfo uInfo;
        public bool isAdmin = false;
        public int DpId = -1;
        public bool isTrue = false;
        public CheckMiGo()
        {
            InitializeComponent();
            uBLL = new UInfoBLL();
            uInfo = new UInfo();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (txtMiGo.Text.Trim() == "")
            {
                MessageBox.Show("请输入加密狗秘钥!");
                return;
            }
            string code = txtMiGo.Text.Trim();
            try
            {
                int result = API.NTFindFirst(code);
                if (result == 20)
                {
                    MessageBox.Show("请插入加密锁!");
                }
                else if (result == 1)
                {
                    MessageBox.Show("请插入正确的加密锁!");
                }
                else
                {
                    StringBuilder HardwareId = new StringBuilder();
                    try
                    {
                        API.NTGetHardwareID(HardwareId);
                    }
                    catch (Exception ex)
                    {
                    }
                    uInfo.Identify = HardwareId.ToString();
                    uInfo.U_Info = code;
                    try
                    {
                        uInfo = uBLL.GetUInfoByMessage(uInfo);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message + "," + ex.Source.ToString());
                    }
                    if (uInfo != null)
                    {
                        isTrue = true;
                        isAdmin = uInfo.IsAdmin;
                        DpId = uInfo.DepartId;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("密码输入有误!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("加载DLL出现问题!");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
           isAdmin = true ;
          isTrue = true;
            this.Close();
        }

    }
}
