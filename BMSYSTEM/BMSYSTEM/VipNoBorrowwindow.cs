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
using System.Management;
using System.Text.RegularExpressions;
using System.Threading;

namespace BMSYSTEM
{
    public partial class VipNoBorrowWindow : Form
    {

        VipNoInfo vipNoInfo;
        VipNoBLL vipNoBLL;
        VipLevelBLL vipLevelBLL;
        DepartBLL dpBLL;
        BorrowKindBLL borrowKindBLL;
        VipNoBorrowBLL vipNoBorrowBLL;
        string BorrowBikeMark;
        public VipNoBorrowWindow(int id)
        {
            InitializeComponent();
            vipNoInfo = new VipNoInfo();
            vipNoBLL = new VipNoBLL();
            vipLevelBLL = new VipLevelBLL();
            dpBLL = new DepartBLL();
            borrowKindBLL = new BorrowKindBLL();
            vipNoInfo.VipId = id;
            vipNoBorrowBLL = new VipNoBorrowBLL();
        }

        private void VipNoBorrowwindow_Load(object sender, EventArgs e)
        {
            Thread th = new Thread(new ThreadStart(Bingding));
            th.IsBackground = true;
            th.Start();
        }
        private void Bingding()
        {
            this.Invoke(new Action(() =>
                {
                    FillVipNoMessage();
                    FillBorrowKind();
                }));
        }

        #region 确认按钮点击事件
        private void btnOKClick(object vipNoBorrow)
        {
            this.Invoke(new Action(() =>
            {
                VipNoBorrow vipNoBorrowModel = vipNoBorrow as VipNoBorrow;
                if (vipNoBorrowBLL.VipNoBorrowInsert(vipNoBorrowModel, vipNoBorrowModel.RkrId) == 1)
                {
                    MessageBox.Show("租车成功");
                    LogInfo logInfo = new LogInfo();
                    logInfo.UserId = StaticData.userLocal.UserId;
                    logInfo.Content = "为非会员‘" + txtVipNoName.Text + "'租车" + txtVNNumber.Text.ToString() + "辆";
                    logInfo.LogTime = DateTime.Now;
                    logInfo.DpId = StaticData.departLocal.DpId;
                    bool b = new LogBLL().LogInsert(logInfo);
                    this.Close();
                    txtVNCard.Text = "";
                    txtVNName.Text = "";
                    txtVNNumber.Text = "";
                    txtVNPhone.Text = "";
                }
                else if (vipNoBorrowBLL.VipNoBorrowInsert(vipNoBorrowModel, vipNoBorrowModel.RkrId) == -1)
                {
                    MessageBox.Show("租车失败");
                }
                else if (vipNoBorrowBLL.VipNoBorrowInsert(vipNoBorrowModel, vipNoBorrowModel.RkrId) == -2)
                {
                    MessageBox.Show("余额不足，请先充值");
                }
            }));
        }
        private void btnOK_Click(object sender, EventArgs e)
        {
            if (txtVNName.Text == "")
            {
                epInfo.SetError(txtVNName, "请输入租车人姓名");
                return;
            }
            try
            {
                if (int.Parse(txtVNNumber.Text.ToString()) <= 0)
                {
                    epInfo.SetError(txtVNNumber, "租车数目必须大于零");
                    return;
                }
                //if (int.Parse(txtVNNumber.Text.ToString()) > 3)
                //{
                //    epInfo.SetError(txtVNNumber, "对不起一次租车数量过多，请尝试多次租车!");
                //    return;
                //}
            }
            catch (Exception)
            {
                epInfo.SetError(txtVNNumber, "租车数目必须为整数");
                return;
            }
            if (!CheckPhone(txtVNPhone.Text))
            {
                epInfo.SetError(txtVNPhone, "租车人电话输入错误");
                return;
            }
            if (txtVNCard != null&&txtVNCard .Text .Trim ()!="")
            {
                if (!CheckCidInfo(txtVNCard.Text))
                {
                    epInfo.SetError(txtVNCard, "租车人身份证号输入错误");
                    return;
                }
            }
            VipNoBorrow vipNoBorrowModel = new VipNoBorrow();
            vipNoBorrowModel.VipId = int.Parse(txtVipNoId.Text);
            vipNoBorrowModel.DpId = StaticData.departLocal.DpId;
            vipNoBorrowModel.VnName = txtVNName.Text;
            vipNoBorrowModel.VnPhone = txtVNPhone.Text;
            if (txtVNCard != null && txtVNCard.Text.Trim() != "")
            {
                vipNoBorrowModel.VnCard = txtVNCard.Text;
            }
            else
            {
                vipNoBorrowModel.VnCard = "空";
            }
            vipNoBorrowModel.VnNumber = int.Parse(txtVNNumber.Text);
            vipNoBorrowModel.BbkTime = DateTime.Now;
            vipNoBorrowModel.RkrId = (int)cmbBorrowKind.SelectedValue;
            vipNoBorrowModel.UserId = StaticData.userLocal.UserId;
            if (txtCashPledge.TextLength <= 0)
            {
                BorrowBikeMark = "押金:0元";
            }
            else
            {
                BorrowBikeMark = "押金:" + txtCashPledge.Text.Trim() + "元";
            }
            if (rbStudent.Checked)
            {
                BorrowBikeMark += "，所押证件;学生证";
            }
            if (rbOneCard.Checked)
            {
                BorrowBikeMark += "，所押证件:一卡通";
            }
            if (rbCard.Checked)
            {
                BorrowBikeMark += "，所押证件:身份证";
            }
            if (txtMark.TextLength > 0)
            {
                BorrowBikeMark += "," + txtMark.Text.Trim();
            }
            vipNoBorrowModel.Mark = BorrowBikeMark;
            Thread th = new Thread(new ParameterizedThreadStart(btnOKClick));
            th.IsBackground = true;
            th.Start(vipNoBorrowModel);
        }
        #endregion

        #region 取消按钮点击事件
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region 获取本机物理地址
        public static string getMacAddr_Local()
        {
            string macAddr = null;
            ManagementClass mc = new ManagementClass("Win32_NetworkAdapterConfiguration");
            ManagementObjectCollection moc2 = mc.GetInstances();
            foreach (ManagementObject mo in moc2)
            {
                if (Convert.ToBoolean(mo["IPEnabled"]) == true)
                {
                    macAddr = mo["MacAddress"].ToString();
                    macAddr = macAddr.Replace(':', '-');
                }
                mo.Dispose();
            }
            return macAddr;
        }
        #endregion

        #region 验证身份证号
        private bool CheckCidInfo(string cid)
        {
            string[] aCity = new string[] { null, null, null, null, null, null, null, null, null, null, null, "北京", "天津", "河北", "山西", "内蒙古", null, null, null, null, null, "辽宁", "吉林", "黑龙江", null, null, null, null, null, null, null, "上海", "江苏", "浙江", "安微", "福建", "江西", "山东", null, null, null, "河南", "湖北", "湖南", "广东", "广西", "海南", null, null, null, "重庆", "四川", "贵州", "云南", "西藏", null, null, null, null, null, null, "陕西", "甘肃", "青海", "宁夏", "新疆", null, null, null, null, null, "台湾", null, null, null, null, null, null, null, null, null, "香港", "澳门", null, null, null, null, null, null, null, null, "国外" };
            double iSum = 0;
            System.Text.RegularExpressions.Regex rg = new System.Text.RegularExpressions.Regex(@"^\d{17}(\d|X)$");
            System.Text.RegularExpressions.Match mc = rg.Match(cid);
            if (!mc.Success)
            {
                return false;
                //return "";
            }
            cid = cid.ToLower();
            cid = cid.Replace("x", "a");
            if (aCity[int.Parse(cid.Substring(0, 2))] == null)
            {
                return false;
                //return "非法地区";
            }
            try
            {
                DateTime.Parse(cid.Substring(6, 4) + "-" + cid.Substring(10, 2) + "-" + cid.Substring(12, 2));
            }
            catch
            {
                return false;
                //return "非法生日";
            }
            for (int i = 17; i >= 0; i--)
            {
                iSum += (System.Math.Pow(2, i) % 11) * int.Parse(cid[17 - i].ToString(), System.Globalization.NumberStyles.HexNumber);

            }
            if (iSum % 11 != 1)
                return false;
            //return ("非法证号");

            return true;
            //return (aCity[int.Parse(cid.Substring(0, 2))] + "," + cid.Substring(6, 4) + "-" + cid.Substring(10, 2) + "-" + cid.Substring(12, 2) + "," + (int.Parse(cid.Substring(16, 1)) % 2 == 1 ? "男" : "女"));

        }
        #endregion

        #region 验证手机号码
        public static bool CheckPhone(string phone)
        {
            if (string.IsNullOrEmpty(phone))
                return false;
            return Regex.IsMatch(phone, @"^(13|14|15|16|18|19)\d{9}$");
        }
        #endregion

        #region 为租车类别下拉框绑定数据
        private void FillBorrowKind()
        {
            List<BorrowKind> borrowKindList = borrowKindBLL.BorrowKindSelect();
            cmbBorrowKind.DataSource = borrowKindList;
            cmbBorrowKind.DisplayMember = "BBKNAME";
            cmbBorrowKind.ValueMember = "BKID";
        }
        #endregion

        #region 填写非会员信息
        private void FillVipNoMessage()
        {
            VipNoInfo vipNoTemp = new VipNoInfo();
            vipNoTemp = vipNoBLL.VipNoSelectByVIPNoId(vipNoInfo);
            txtVipNoNumber.Text = vipNoTemp.VipNumber;
            txtVipNoId.Text = vipNoTemp.VipId.ToString();
            txtVipNoName.Text = vipNoTemp.VipName;
            txtVipNoPhone.Text = vipNoTemp.VipPhone;
            txtVipNoCard.Text = vipNoTemp.VipCard;
            txtVipNoMark.Text = vipNoTemp.Mark;
            int vipLV = vipNoTemp.LvId;
            VipLevelInfo levelInfo = new VipLevelInfo();
            levelInfo.LvId = vipLV;
            levelInfo = vipLevelBLL.VipLevelSelectById(levelInfo);
            txtVipNoLevel.Text = levelInfo.LvName;
            int dpid = vipNoTemp.DpId;
            DepartInfo dpInfo = new DepartInfo();
            dpInfo.DpId = dpid;
            dpInfo = dpBLL.DepartSelectById(dpInfo);
            txtDpId.Text = dpInfo.DpName;
            VipMoney vipMoney = new VipMoney();
            VipMoneyBLL vipMoneyBll = new VipMoneyBLL();
            vipMoney.VipId = vipNoTemp.VipId;
            vipMoney.IsVip = false;
            vipMoney = vipMoneyBll.VipMoneySelectByVipId(vipMoney);
            try
            {
                txtMoneyLeft.Text = vipMoney.VmBalance.ToString();
            }
            catch (Exception)
            {
            }

        }
        #endregion

        private void gbVipNoBorrow_Enter(object sender, EventArgs e)
        {

        }



    }
}
