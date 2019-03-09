using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using MODEL;
using BIKEBLL;

namespace BMSYSTEM
{
    public partial class ChangeDepartWindow : Form
    {
        public int departId;
        DepartInfo departModel;
        DepartBLL departBLL;

        #region 窗体实例化
        public ChangeDepartWindow(int id)
        {
            InitializeComponent();
            departId = id;
            departModel = new DepartInfo();
            departBLL = new DepartBLL();
        }
        #endregion

        #region 根据分店Id获取分店信息

        private void GetDepartInfoById(DepartInfo depart)
        {
            DepartInfo departTemp = departBLL.DepartSelectById(depart);
            txtDPName.Text = departTemp.DpName;
            txtDPPlace.Text = departTemp.DpPlace;
            txtDPPCMAC.Text = departTemp.DpPCMAC;
        }
        #endregion

        #region 窗体加载
        private void ChangeDepartWindow_Load(object sender, EventArgs e)
        {
            Thread th = new Thread(new ThreadStart(Bingding));
            th.IsBackground = true;
            th.Start();
        }
        private void Bingding()
        {
            departModel.DpId = departId;
            this.Invoke(new Action(() =>
            {
                GetDepartInfoById(departModel);
            }));
        }
        #endregion

        #region 确认按钮点击事件
        private void btnOKClick()
        {
            this.Invoke(new Action(() =>
            {


                departModel = new DepartInfo();
                departModel.DpId = departId;
                departModel.DpName = txtDPName.Text;
                departModel.DpPlace = txtDPPlace.Text;
                departModel.DpPCMAC = txtDPPCMAC.Text;
                if (departBLL.DepartUpdate(departModel))
                {
                    MessageBox.Show("恭喜您，修改分店信息成功");
                    LogInfo logInfo = new LogInfo();
                    logInfo.UserId = StaticData.userLocal.UserId;
                    logInfo.Content = "添加了名称为‘" + txtDPName.Text + "'的分店信息";
                    logInfo.LogTime = DateTime.Now;
                    logInfo.DpId = StaticData.departLocal.DpId;
                    bool b = new LogBLL().LogInsert(logInfo);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("很抱歉，添修改分店信息失败");
                }
            }));
        }
        private void btnOK_Click(object sender, EventArgs e)
        {
            if (txtDPName.Text.Trim() == "")
            {
                epName.SetError(txtDPName, "请输入分店名称!");
                return;
            }
            if (txtDPPlace.Text.Trim() == "")
            {
                epPlace.SetError(txtDPPlace, "请输入分店地址!");
                return;
            }
            if (txtDPPCMAC.Text.Trim() == "")
            {
                epMAC.SetError(txtDPPCMAC, "请输入分店电脑物理地址!");
                return;
            }
            Thread th = new Thread(new ThreadStart(btnOKClick));
            th.IsBackground = true;
            th.Start();
        }
        #endregion

        #region 取消按钮点击事件
        private void btnCancle_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion
    }
}
