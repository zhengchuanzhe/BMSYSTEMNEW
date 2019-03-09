using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BIKECOMMON;
using MODEL;
using BIKEBLL;
using System.Threading;

namespace BMSYSTEM
{
    public partial class UInfoChange : Form
    {
        UInfo uInfo;
        UInfoBLL uBLL;
        DepartInfo departInfo;
        DepartBLL departBLL;
        int Id;
        public UInfoChange(int id)
        {
            InitializeComponent();
            uInfo = new UInfo();
            departInfo = new DepartInfo();
            departBLL = new DepartBLL();
            uBLL = new UInfoBLL();
            Id = id;

        }
        #region 绑定
        private void Bingding()
        {
            this.Invoke(new Action(() =>
            {
                FillDepart();
                FillUMessage(Id);
                cmbDepart.SelectedValue = Id;
            }));
        }
        private void FillDepart()
        {
            List<DepartInfo> departList = departBLL.DepartSelect();
            cmbDepart.DataSource = departList;
            cmbDepart.DisplayMember = "DPNAME";
            cmbDepart.ValueMember = "DPID";
        }

        private void FillUMessage(int id)
        {
            uInfo.UId = id;
            uInfo = uBLL.UInfoSelectById(uInfo);
            txtGo.Text = uInfo.U_Info;
            cmbDepart.SelectedValue = uInfo.DepartId;
            if (uInfo.IsAdmin)
            {
                rbAdmin.Checked = true;
            }
            else
            {
                rbNoAdmin.Checked = true;
            }
        }
        #endregion
        private void btnFindClick(object uInfo)
        {
            this.Invoke(new Action(() =>
            {


                if (uBLL.UInfoUpdate(uInfo as UInfo))
                {
                    MessageBox.Show("添加成功!");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("添加失败!");
                }
            }));
        }
        private void btnFind_Click(object sender, EventArgs e)
        {
            String code = txtGo.Text.Trim();
            if (code == "")
            {
                epMessage.SetError(txtGo, "请输入加密狗秘钥!");
                return;
            }
            uInfo.DepartId = (int)cmbDepart.SelectedValue;
            uInfo.U_Info = code;
            if (rbAdmin.Checked)
            {
                uInfo.IsAdmin = true;
            }
            else
            {
                uInfo.IsAdmin = false;
            }
            Thread th = new Thread(new ParameterizedThreadStart(btnFindClick));
            th.IsBackground = true;
            th.Start(uInfo);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void UInfoChange_Load(object sender, EventArgs e)
        {
            Thread th = new Thread(new ThreadStart(Bingding));
            th.IsBackground = true;
            th.Start();
        }
    }
}
