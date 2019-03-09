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
    public partial class UInfoAdd : Form
    {
        UInfo uInfo;
        UInfoBLL uBLL;
        DepartInfo departInfo;
        DepartBLL departBLL;
        public UInfoAdd()
        {
            InitializeComponent();
            rbNoAdmin.Checked = true;
            uInfo = new UInfo();
            departInfo = new DepartInfo();
            departBLL = new DepartBLL();
            uBLL = new UInfoBLL();

        }
        #region 绑定
        private void Bingding()
        {
            this.Invoke(new Action(() =>
            {
                FillDepart();
            }));
        }

        private void FillDepart()
        {
            List<DepartInfo> departList = departBLL.DepartSelect();
            cmbDepart.DataSource = departList;
            cmbDepart.DisplayMember = "DPNAME";
            cmbDepart.ValueMember = "DPID";
        }
        #endregion

        private void btnFindClick(object uInfo)
        {
            this.Invoke(new Action(() =>
            {
                if (uBLL.UInfoInsert(uInfo as UInfo))
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
            else if (rbAdmin.Checked)
            {
                uInfo.IsAdmin = true;
            }
            else
            {
                uInfo.IsAdmin = false;
            }
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
                    StringBuilder sb = new StringBuilder(32);
                    API.NTGetHardwareID(sb);
                    uInfo.Identify = sb.ToString();
                    uInfo.DepartId = (int)cmbDepart.SelectedValue;
                    uInfo.U_Info = code;
                    Thread th = new Thread(new ParameterizedThreadStart(btnFindClick));
                    th.IsBackground = true;
                    th.Start(uInfo);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("加载DLL出现问题!");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void UInfoAdd_Load(object sender, EventArgs e)
        {
            Thread th = new Thread(new ThreadStart(Bingding));
            th.IsBackground = true;
            th.Start();
        }
    }
}
