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
using System.IO;
using System.Threading;

namespace BMSYSTEM
{
    public partial class ChangeVipWindow : Form
    {
        static int vipId = 0;
        VipBLL vipBLL;
        VipLevelBLL levelBLL;
        VIPInfo vipInfo;
        DepartBLL departBLL;
        byte[] image;
        public ChangeVipWindow(int vipid)
        {
            InitializeComponent();
            vipId = vipid;
            vipBLL = new VipBLL();
            levelBLL = new VipLevelBLL();
            vipInfo = new VIPInfo();
            departBLL = new DepartBLL();
            vipInfo.VipId = vipId;

        }
        private void Bingding()
        {
            this.Invoke(new Action(() =>
            {
                BingdingCmb();
            }));
        }
        private void BingdingCmb()
        {
            cmbVipLevel.DataSource = levelBLL.VipLevelSelectByIsVip(true);
            cmbVipLevel.DisplayMember = "LVNAME";
            cmbVipLevel.ValueMember = "LVID";
            cmbDPID.DataSource = departBLL.DepartSelect();
            cmbDPID.DisplayMember = "DPNAME";
            cmbDPID.ValueMember = "DPID";

        }
        #region 窗体加载
        private void ChangeVipWindow_Load(object sender, EventArgs e)
        {
            Thread thCmb = new Thread(new ThreadStart(Bingding));
            thCmb.IsBackground = true;
            thCmb.Start();
            Thread th = new Thread(new ParameterizedThreadStart(GetVipInfoById));
            th.IsBackground = true;
            th.Start(vipInfo);
        }
        #endregion

        #region 根据会员Id获取用户信息
        private void GetVipInfoById(object vip)
        {
            VIPInfo vipTemp = vipBLL.VipSelectById((VIPInfo)vip);
            this.Invoke(new Action(() =>
                {
                    txtVipNumber.Text = vipTemp.VipNumber;
                    cmbVipLevel.SelectedValue = vipTemp.VipLevelId;
                    txtVipName.Text = vipTemp.VipName;
                    cmbDPID.SelectedValue = vipTemp.DpId;
                    if (vipTemp.VipSex)
                    {
                        rbtnSex1.Checked = true;
                    }
                    else
                    {
                        rbtnSex2.Checked = true;
                    }
                    txtVipPWD.Text = vipTemp.VipPWD;
                    txtVipPWD2.Text = vipTemp.VipPWD;
                    txtVipPhone.Text = vipTemp.VipPhone;
                    txtVipCard.Text = vipTemp.VipCard;
                    txtVipAddress.Text = vipTemp.VipAddress;
                    image = vipTemp.VipPhoto;
                    txtMark.Text = vipTemp.Mark;
                    try
                    {
                        if (vipTemp.VipPhoto == new Byte[0])
                        {
                            picUser.Image = null;
                            return;
                        }
                        MemoryStream stream = new MemoryStream(vipTemp.VipPhoto, true);
                        stream.Write(vipTemp.VipPhoto, 0, vipTemp.VipPhoto.Length);
                        picUser.Image = new Bitmap(stream);
                        picUser.SizeMode = PictureBoxSizeMode.StretchImage;
                    }
                    catch (Exception ex)
                    {
                        picUser.Image = null;
                    }
                    cmbDPID.SelectedValue = vipTemp.DpId;
                }));
        }
        #endregion

        #region 上传图片点击按钮
        private void btnUpLoadPic_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog ofd = new OpenFileDialog();                //new一个方法    
                ofd.ShowDialog();          //显示打开文件的窗口
                string fileName = ofd.FileName;                //获得选择的文件路径
                picUser.ImageLocation = fileName;
                FileStream fs = File.OpenRead(fileName);
                image = new byte[fs.Length];
                fs.Read(image, 0, image.Length);
                fs.Close();
                picUser.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            catch (Exception ex)
            {
            }
        }
        #endregion

        #region 确认按钮点击事件
        private void btnOKClick()
        {
            this.Invoke(new Action(() =>
            {


                vipInfo = new VIPInfo();
                vipInfo.VipId = vipId;
                vipInfo.VipNumber = txtVipNumber.Text;
                vipInfo.VipLevelId = Convert.ToInt32(cmbVipLevel.SelectedValue);
                vipInfo.VipName = txtVipName.Text;
                vipInfo.VipPWD = txtVipPWD.Text;
                vipInfo.VipSex = rbtnSex1.Checked;
                vipInfo.VipPhone = txtVipPhone.Text;
                vipInfo.VipCard = txtVipCard.Text;
                string cid = txtVipCard.Text.Trim();
                DateTime birthDay = DateTime.Parse(cid.Substring(6, 4) + "-" + cid.Substring(10, 2) + "-" + cid.Substring(12, 2));
                vipInfo.VipBirthDay = birthDay;
                vipInfo.VipAddress = txtVipAddress.Text;
                vipInfo.VipPhoto = image;
                if (txtMark.TextLength > 0)
                {
                    vipInfo.Mark = txtMark.Text.Trim();
                }
                else
                {
                    vipInfo.Mark = "";
                }
                vipInfo.DpId = Convert.ToInt32(cmbDPID.SelectedValue);
                if (vipBLL.VipUpdate(vipInfo))
                {
                    MessageBox.Show("修改会员成功", "系统提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk);
                    LogInfo logInfo = new LogInfo();
                    logInfo.UserId = StaticData.userLocal.UserId;
                    logInfo.Content = "修改会员‘" + txtVipName.Text + "'的信息";
                    logInfo.LogTime = DateTime.Now;
                    logInfo.DpId = StaticData.departLocal.DpId;
                    bool b = new LogBLL().LogInsert(logInfo);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("添修改会员失败", "系统提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                }
            }));
        }
        private void btnOK_Click(object sender, EventArgs e)
        {

            if (txtVipPWD.Text.Trim() == "")
            {
                epPWD.SetError(txtVipPWD, "请输入密码");
                return;
            }
            else
            {
                if (txtVipPWD.Text.Length < 6)
                {
                    epPWD.SetError(txtVipPWD, "密码长度不得低于六位数");
                    return;
                }
                else
                {
                    epPWD.SetError(txtVipPWD, "");
                }
            }
            if (txtVipPWD.Text.Trim() != txtVipPWD2.Text.Trim())
            {
                epPWD2.SetError(txtVipPWD2, "两次密码不一致");
                return;
            }
            else
            {
                epPWD2.SetError(txtVipPWD2, "");
            }
            if (txtVipName.Text.Trim() == "")
            {
                epName.SetError(txtVipName, "请输入会员姓名");
                return;
            }
            else
            {
                epName.SetError(txtVipName, "");
            }
            if (!CheckPhone(txtVipPhone.Text.Trim()))
            {
                epPhone.SetError(txtVipPhone, "请输入正确会员电话");
                return;
            }
            else
            {
                epPhone.SetError(txtVipPhone, "");
            }
            if (txtVipCard.Text.Trim() == "")
            {
                epCard.SetError(txtVipCard, "请输入会员身份证");
                return;
            }
            else
            {
                if (!CheckCidInfo(txtVipCard.Text.Trim()))
                {
                    epCard.SetError(txtVipCard, "请输入正确身份证号");
                    return;
                }
                epCard.SetError(txtVipCard, "");
            }
            if (txtVipAddress.Text.Trim() == "")
            {
                epAddress.SetError(txtVipAddress, "请输入会员地址");
                return;
            }
            else
            {
                epAddress.SetError(txtVipAddress, "");
            }
            //bool check = true;
            //if (!CheckCidInfo(txtVipCard.Text.Trim()))
            //{
            //    epCard.SetError(txtVipCard, "请输入正确的身份证号码!");
            //    check = false;
            //}
            //else if (!CheckPhone(txtVipPhone.Text.Trim()))
            //{
            //    //电话输入错误
            //    epPhone.SetError(txtVipPhone, "会员电话输入错误!");
            //    return;
            //}
            //else if (txtVipPWD.Text.Trim() != txtVipPWD2.Text.Trim())
            //{
            //    epPWD2.SetError(txtVipPWD2, "两次输入的密码不一致!");
            //    return;
            //}
            //else if (txtVipName.Text.Trim() == "")
            //{
            //    epName.SetError(txtVipName, "请输入会员名称!");
            //    return;
            //}
            //else if (txtVipPWD.Text.Trim() == "")
            //{
            //    epPWD.SetError(txtVipPWD, "请输入会员密码!");
            //    return;
            //}
            //else if (txtVipPWD.Text.Length < 6)
            //{
            //    epPWD.SetError(txtVipPWD, "密码长度不得低于六位数!");
            //    return;
            //}
            //else if (txtVipPWD2.Text.Trim() == "")
            //{
            //    epPWD2.SetError(txtVipPWD2, "请再次输入会员密码!");
            //    return;
            //}
            //else if (txtVipPhone.Text.Trim() == "")
            //{
            //    epPhone.SetError(txtVipPhone, "请输入会员电话!");
            //    return;
            //}
            //else if (txtVipCard.Text.Trim() == "")
            //{
            //    epCard.SetError(txtVipCard, "请输入会员身份证号");
            //    return;
            //}
            //else if (txtVipAddress.Text.Trim() == "")
            //{
            //    epAddress.SetError(txtVipAddress, "请输入会员地址!");
            //    return;
            //}
            Thread th = new Thread(new ThreadStart(btnOKClick));
            th.IsBackground = true;
            th.Start();
        }
        #endregion

        #region 取消按钮点击事件
        private void btnCancel_Click(object sender, EventArgs e)
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

        #region 点击拍照按钮事件
        private void cameraButton_Click(object sender, EventArgs e)
        {
            try
            {
                Camera camera = new Camera();
                camera.ShowDialog();
                image = camera.CaptureData;
                MemoryStream stream = new MemoryStream(image, true);
                picUser.Image = new Bitmap(stream);
                picUser.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            }
            catch (Exception)
            {

            }
        }
        #endregion

    }
}
