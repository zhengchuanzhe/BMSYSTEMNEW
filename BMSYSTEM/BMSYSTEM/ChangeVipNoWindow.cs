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
using System.Text.RegularExpressions;


namespace BMSYSTEM
{
    public partial class ChangeVipNoWindow : Form
    {
        public int VipId = 0;
        VipNoInfo vipNoInfo;
        VipNoBLL vipNoBLL;
        DepartInfo departInfo;
        DepartBLL departBLL;
        VipLevelBLL levelBLL = new VipLevelBLL();
        public ChangeVipNoWindow(int id)
        {
            InitializeComponent();
            VipId = id;
            vipNoInfo = new VipNoInfo();
            vipNoBLL = new VipNoBLL();
            levelBLL = new VipLevelBLL();
            vipNoInfo.VipId = id;

        }

        private void BingdingCmb()
        {
            this.Invoke(new Action(() =>
            {
                cmbLevel.DataSource = levelBLL.VipLevelSelectByIsVip(false);
                cmbLevel.DisplayMember = "LVNAME";
                cmbLevel.ValueMember = "LVID";
            }));
        }
        private void ChangeVipNoWindow_Load(object sender, EventArgs e)
        {
            Thread thCmb = new Thread(new ThreadStart(BingdingCmb));
            thCmb.IsBackground = true;
            thCmb.Start();
            Thread th = new Thread(new ParameterizedThreadStart(GetVipNoInfoById));
            th.IsBackground = true;
            th.Start(vipNoInfo);
        }
        int vipNoDpId = 0;
        #region 根据会员Id获取用户信息
        private void GetVipNoInfoById(object vipNo)
        {
            VipNoInfo vipNoTemp = vipNoBLL.VipNoSelectByVIPNoId((VipNoInfo)vipNo);
            this.Invoke(new Action(() =>
            {
                txtVipNoNumber.Text = vipNoTemp.VipNumber;
                txtVipNoName.Text = vipNoTemp.VipName;
                txtVipNoPWD.Text = vipNoTemp.VipPwd;
                txtVipNoPhone.Text = vipNoTemp.VipPhone;
                txtVipNoCard.Text = vipNoTemp.VipCard;
                txtMark.Text = vipNoTemp.Mark;
                cmbLevel.SelectedValue = vipNoTemp.LvId;
                vipNoDpId = vipNoTemp.DpId;
                departInfo = new DepartInfo();
                departBLL = new DepartBLL();
                departInfo.DpId = vipNoTemp.DpId;
                departInfo = departBLL.DepartSelectById(departInfo);
                txtDPID.Text = departInfo.DpName;
            }));
        }
        #endregion

        #region 确认按钮点击事件
        private void btnOKClick()
        {
            this.Invoke(new Action(() =>
            {
                vipNoInfo.VipId = VipId;
                vipNoInfo.VipNumber = txtVipNoNumber.Text;
                vipNoInfo.VipName = txtVipNoName.Text;
                vipNoInfo.VipPwd = txtVipNoPWD.Text;
                vipNoInfo.VipPhone = txtVipNoPhone.Text;
                vipNoInfo.VipCard = txtVipNoCard.Text;
                vipNoInfo.DpId = vipNoDpId;
                if (txtMark .TextLength >0)
                {
                    vipNoInfo.Mark = txtMark.Text.Trim();
                }
                else
                {
                    vipNoInfo.Mark = "";
                }
                vipNoInfo.LvId = (int)cmbLevel.SelectedValue;
                if (vipNoBLL.VipNoUpdate(vipNoInfo))
                {
                    MessageBox.Show("修改成功");
                    LogInfo logInfo = new LogInfo();
                    logInfo.UserId = StaticData.userLocal.UserId;
                    logInfo.Content = "修改了非会员‘" + txtVipNoName.Text + "'的信息";
                    logInfo.LogTime = DateTime.Now;
                    logInfo.DpId = StaticData.departLocal.DpId;
                    bool b = new LogBLL().LogInsert(logInfo);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("修改失败");
                }
            }));
        }
        private void btnOK_Click(object sender, EventArgs e)
        {
            if (txtVipNoName.Text == "")
            {
                epMessage.SetError(txtVipNoName, "请输入名称");
                return;
            }
            if (txtVipNoPWD.Text == "")
            {
                epMessage.SetError(txtVipNoPWD, "请输入密码");
                return;
            }
            if (txtVipNoPWD.Text.Length < 6)
            {
                epMessage.SetError(txtVipNoPWD, "密码不得低于六位数");
                return;
            }
            if (!CheckPhone(txtVipNoPhone.Text))
            {
                epMessage.SetError(txtVipNoPhone, "电话输入错误");
                return;
            }
            if (!CheckCidInfo(txtVipNoCard.Text))
            {
                epMessage.SetError(txtVipNoCard, "身份证输入错误");
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


        #region 验证手机号码
        public static bool CheckPhone(string phone)
        {
            if (string.IsNullOrEmpty(phone))
                return false;
            return Regex.IsMatch(phone, @"^(13|14|15|16|18|19)\d{9}$");
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
    }
}
