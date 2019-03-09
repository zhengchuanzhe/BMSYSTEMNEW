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
using System.Text.RegularExpressions;
using System.Threading;

namespace BMSYSTEM
{
    public partial class VipNoReturnWindow : Form
    {
        public bool isDispose = false;
        bool first = true;
        VipNoInfo vipNoInfo;
        VipNoBLL vipNoBLL;
        //VipLevelBLL vipLVBLL;
        //DepartBLL dpBLL;
        VipNoBorrowBLL vnBorrowBLL;
        VipNoBorrow vnBorrow;
        BorrowKindBLL borrowKindBLL;
        BikeReturnBLL bRetBLL;
        public VipNoReturnWindow(int id)
        {
            InitializeComponent();
            vipNoInfo = new VipNoInfo();
            vipNoBLL = new VipNoBLL();
            //vipLVBLL = new VipLevelBLL();
            //dpBLL = new DepartBLL();
            vnBorrowBLL = new VipNoBorrowBLL();
            vnBorrow = new VipNoBorrow();
            borrowKindBLL = new BorrowKindBLL();
            bRetBLL = new BikeReturnBLL();
            vnBorrow.VipId = id;
            vipNoInfo.VipId = id;
            first = true;
        }

        #region 确认按钮
        BikeReturn bikeReturn = new BikeReturn();
        private void btnOK_Click(object sender, EventArgs e)
        {
            if (txtReturnNum.Text.Trim() == "")
            {
                epMessage.SetError(txtReturnNum, "请输入还车数量!");
                return;
            }
            else if (!Regex.IsMatch(txtReturnNum.Text.Trim(), @"^[0-9]*[1-9][0-9]*$"))
            {
                epMessage.SetError(txtReturnNum, "请输入正确的数量!");
                return;
            }
            else if (Int32.Parse(txtReturnNum.Text.Trim()) > Int32.Parse(txtVNNum.Text))
            {
                epMessage.SetError(txtReturnNum, "还车辆数不应该大于已租车辆数!");
                return;
            }
            btnOK.Enabled = false;
            bikeReturn.IsVip = false;
            bikeReturn.RbkTime = DateTime.Now;
            bikeReturn.VipId = Convert.ToInt32(txtVipNoId.Text);
            bikeReturn.DpId = StaticData.departLocal.DpId;
            bikeReturn.BrNumber = Convert.ToInt32(txtReturnNum.Text.Trim());
            bikeReturn.BbkId = (int)cmbVNName.SelectedValue;
            bikeReturn.UserId = StaticData.userLocal.UserId;
            backgroundWorker1.RunWorkerAsync();
        }
        #endregion



        #region  选择租车人
        private void SelectIndexThread(object id)
        {
            this.Invoke(new Action(() =>
            {
                VipNoBorrow vnBorrowTemp = new VipNoBorrow();
                vnBorrowTemp.BbkId = (int)id;
                vnBorrowTemp = vnBorrowBLL.VipNoBorrowSelectByBBKId(vnBorrowTemp);
                BorrowKind borrowKind = new BorrowKind();
                borrowKind.BkId = vnBorrowTemp.RkrId;
                txtBorrowKind.Text = borrowKindBLL.BorrowKindSelectById(borrowKind).BbkName;
                if (vnBorrowTemp.IsNight)
                {
                    labNightCost.Text = "包夜租车";
                }
                else
                {
                    labNightCost.Text = "";
                }
                txtVNPhone.Text = vnBorrowTemp.VnPhone;
                txtVNCard.Text = vnBorrowTemp.VnCard;
                txtBorrowTime.Text = vnBorrowTemp.BbkTime.ToString();
                //txtBBKTime.Text = (DateTime.Now - vnBorrowTemp.BbkTime).ToString().Substring (0,8);
                txtVNNum.Text = vnBorrowTemp.LeftNum.ToString();
                txtMark.Text = vnBorrowTemp.Mark;
            }));
        }
        private void cmbVNName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!first)
            {
                int id = (int)cmbVNName.SelectedValue;
                Thread th = new Thread(new ParameterizedThreadStart(SelectIndexThread));
                th.IsBackground = true;
                th.Start(id);
            }
        }
        #endregion

        private void lbMark_Click(object sender, EventArgs e)
        {

        }

        private void txtCost_TextChanged(object sender, EventArgs e)
        {

        }

        #region 取消按钮
        private void btnCancle_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region 初始化赋值列表值
        BackgroundWorker bg = new BackgroundWorker();

        private void VipNoReturnWindow_Load(object sender, EventArgs e)
        {
            bg.DoWork += new DoWorkEventHandler(bg_DoWork);
            bg.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bg_RunWorkerCompleted);
            bg.RunWorkerAsync();
        }

        void bg_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            txtVipNoId.Text = vipNoTemp.VipId.ToString();
            txtVipNoNumber.Text = vipNoTemp.VipNumber.ToString();
            if (borrowList == null || borrowList.Count == 0)
            {
                DialogResult result = MessageBox.Show("该用户没有需要还的车辆!", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.No || result == DialogResult.Yes)
                    this.Close();
                isDispose = true;
                return;
            }
            cmbVNName.DataSource = borrowList;
            cmbVNName.DisplayMember = "VNNAME";
            cmbVNName.ValueMember = "BBKID";
            first = false;
            cmbVNName_SelectedIndexChanged("", new EventArgs());

        }
        VipNoInfo vipNoTemp = new VipNoInfo();
        List<VipNoBorrow> borrowList;
        void bg_DoWork(object sender, DoWorkEventArgs e)
        {
            vipNoTemp = vipNoBLL.VipNoSelectByVIPNoId(vipNoInfo);
            borrowList = vnBorrowBLL.VipNoBorrowSelectByVipNoId(vipNoInfo.VipId);
        }
        #endregion
        int result = 0;
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            result = bRetBLL.BikeReturnInsert(bikeReturn);
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (result > 0)
            {
                try
                {
                    BikeReturn bikeReturnTemp = new BikeReturn();
                    bikeReturnTemp.RbkId = result;
                    bikeReturnTemp = bRetBLL.BikeReturnSelectById(bikeReturnTemp);
                    txtCost.Text = bikeReturnTemp.BuCost.ToString() + "元";
                    txtBBKTime.Text = bikeReturnTemp.BuTimeString;
                }
                catch (Exception ex)
                {
                }
                MessageBox.Show("还车成功!租车消费:" + txtCost.Text);
                btnOK.Enabled = true;
                this.Close();
            }
            else
            {
                MessageBox.Show("还车失败!");
                btnOK.Enabled = true;
            }
        }
    }
}
