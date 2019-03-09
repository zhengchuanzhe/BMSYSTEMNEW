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
    public partial class AddVipNoWindow : Form
    {
        VipLevelBLL levelBLL;
        VipNoInfo vipNoInfo;
        VipNoBLL vipNoBLL;
        DepartBLL departBLL;
        List<VipLevelInfo> vipLevelList;
        BackgroundWorker bg = new BackgroundWorker();
        public AddVipNoWindow()
        {
            InitializeComponent();
            levelBLL = new VipLevelBLL();
            bg.DoWork += new DoWorkEventHandler(bg_DoWork);//异步操作时要做的操作，一般去查列表，这个列表在本页面内先声明，然后在这个dowork方法里去取数填充他
            bg.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bg_RunWorkerCompleted);//这个是取数完成后进行的操作，去到数后，这里取用去到的列表绑定到控件
            departBLL = new DepartBLL();
            vipNoInfo = new VipNoInfo();
            vipNoBLL = new VipNoBLL();
            vipLevelList = new List<VipLevelInfo>();
        }

        public static List<DepartInfo> departList;
        void bg_DoWork(object sender, DoWorkEventArgs e)
        {
            vipLevelList = levelBLL.VipLevelSelectByIsVip(false);
            departList = departBLL.DepartSelect();
        }
        void bg_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            FillDp();
        }
        private void FillDp()
        {
            cmbLevel.DataSource = vipLevelList;
            cmbLevel.DisplayMember = "LVNAME";
            cmbLevel.ValueMember = "LVID";
            cmbDepart.DataSource = departList;
            cmbDepart.DisplayMember = "DpName";
            cmbDepart.ValueMember = "DPID";
        }


        #region 确认按钮点击事件

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (txtVipNoNumber.Text == "")
            {
                epMessage.SetError(txtVipNoNumber, "请先刷卡");
                return;
            }
            else
            {
                if (vipNoBLL.IsExistByNumber(txtVipNoNumber.Text.Trim()))
                {
                    epMessage.SetError(txtVipNoNumber, "改卡号已注册");
                    return;
                }
                else
                {
                    epMessage.SetError(txtVipNoNumber, "");
                }
            }
            if (txtVipNoName.Text == "")
            {
                epMessage.SetError(txtVipNoName, "请输入名称");
                return;
            }
            else
            {
                epMessage.SetError(txtVipNoName, "");
            }
            if (txtVipNoPWD.Text == "")
            {
                epMessage.SetError(txtVipNoPWD, "请输入密码");
                return;
            }
            else
            {
                epMessage.SetError(txtVipNoPWD, "");
            }
            if (txtVipNoPWD.Text.Length < 6)
            {
                epMessage.SetError(txtVipNoPWD, "密码长度不得低于六位数");
                return;
            }
            else
            {
                epMessage.SetError(txtVipNoPWD, "");
            }
            if (txtVipNoPWD.Text != txtVipNoPWD2.Text)
            {
                epMessage.SetError(txtVipNoPWD2, "两次输入的密码不一致");
                return;
            }
            else
            {
                epMessage.SetError(txtVipNoPWD2, "");
            }
            if (!CheckPhone(txtVipNoPhone.Text))
            {
                epMessage.SetError(txtVipNoPhone, "电话输入错误");
                return;
            }
            else
            {
                epMessage.SetError(txtVipNoPhone, "");
            }
            if (!CheckCidInfo(txtVipNoCard.Text))
            {
                epMessage.SetError(txtVipNoCard, "身份证输入错误");
                return;
            }
            epMessage.SetError(txtVipNoCard, "");
            btnOK.Enabled = false;
            progressBar1.Visible = true;
            vipNoInfo.VipNumber = txtVipNoNumber.Text;
            vipNoInfo.VipName = txtVipNoName.Text;
            vipNoInfo.VipPwd = txtVipNoPWD.Text;
            vipNoInfo.VipPhone = txtVipNoPhone.Text;
            vipNoInfo.VipCard = txtVipNoCard.Text;
            vipNoInfo.DpId = int.Parse(cmbDepart.SelectedValue.ToString());
            vipNoInfo.LvId = (int)cmbLevel.SelectedValue;
            if (txtVipNoMark.TextLength > 0)
            {
                vipNoInfo.Mark = txtVipNoMark.Text.Trim();
            }
            else
            {
                vipNoInfo.Mark = "";
            }

            logInfo.UserId = StaticData.userLocal.UserId;
            logInfo.Content = "添加了非会员，名称为‘" + txtVipNoName.Text + "'";
            logInfo.LogTime = DateTime.Now;
            logInfo.DpId = StaticData.departLocal.DpId;
            backgroundWorker1.RunWorkerAsync();
        }
        #endregion

        #region 取消按钮点击事件
        private void btnCancle_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void AddVipNoWindow_Load(object sender, EventArgs e)
        {
            bg.RunWorkerAsync();
        }

        bool b;
        LogInfo logInfo = new LogInfo();
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            backgroundWorker1.ReportProgress(10);//这里让进度条显示进度
            b = vipNoBLL.VipNoInsert(vipNoInfo);
            backgroundWorker1.ReportProgress(60);//这里让进度条显示进度
            bool b1 = new LogBLL().LogInsert(logInfo);
            backgroundWorker1.ReportProgress(90);//这里让进度条显示进度
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            btnOK.Enabled = true;
            progressBar1.Visible = false;
            if (b)
            {
                MessageBox.Show("添加成功");
                this.Close();
            }
            else
            {
                MessageBox.Show("添加失败");
            }
        }
    }
}
