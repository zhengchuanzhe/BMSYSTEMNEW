using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BIKEBLL;
using MODEL;
using System.Management;
using System.Text.RegularExpressions;
using System.IO;
using System.Threading;

namespace BMSYSTEM
{
    public partial class ChangeUserWindow : Form
    {
        static int userId = 0;
        UserInfo userInfo;
        UserBLL userBLL;
        DepartBLL departBLL;
        int departValue = 0;
        byte[] image;
        #region 实例化窗体
        public ChangeUserWindow(int id)
        {
            InitializeComponent();
            userId = id;
            userInfo = new UserInfo();
            departBLL = new DepartBLL();
            userInfo.UserId = userId;
            userBLL = new UserBLL();
            Thread th = new Thread(new ParameterizedThreadStart(GetUserInfoById));
            th.Start(userInfo);
            // GetUserInfoById(userInfo);
            //GetDepartInfo();
            cmbDepart.SelectedValue = departValue;

        }
        #endregion

        private void BindCmb()
        {
            this.Invoke(new Action(() =>
                {
                    cmbDepart.DataSource = departBLL.DepartSelect();
                    cmbDepart.DisplayMember = "DPNAME";
                    cmbDepart.ValueMember = "DPID";
                    DataTable dt = departBLL.DepartSelectTable();
                    cmbDepart.DataSource = dt;
                    cmbDepart.DisplayMember = "DPNAME";
                    cmbDepart.ValueMember = "DPID";
                }));
        }

        #region 确认按钮点击事件
        private void btnOKClick()
        {
            this.Invoke(new Action(() =>
            {


                UserInfo user = new UserInfo();
                user.UserName = txtName.Text;
                user.UserPwd = txtLoginPwd.Text;
                user.UserControlPwd = txtContorlPwd.Text;
                user.UserPhone = txtPhone.Text;
                user.UserCard = txtCard.Text;
                user.DpId = Convert.ToInt32(cmbDepart.SelectedValue);
                user.UserPhoto = image;
                user.UserId = userId;
                if (userBLL.UpdateUser(user))
                {
                    MessageBox.Show("恭喜您，修改用户成功");
                    LogInfo logInfo = new LogInfo();
                    logInfo.UserId = StaticData.userLocal.UserId;
                    logInfo.Content = "修改了名称为‘" + txtName.Text + "'的用户信息";
                    logInfo.LogTime = DateTime.Now;
                    logInfo.DpId = StaticData.departLocal.DpId;
                    bool b = new LogBLL().LogInsert(logInfo);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("很抱歉，添修改用户失败");
                }
            }));
        }
        private void btnOK_Click(object sender, EventArgs e)
        {
            if (txtName.Text.Trim() == "")
            {
                epName.SetError(txtName, "请输入姓名!");
                return;
            }
            else
            {
                epName.SetError(txtName ,"");
            }

            if (txtLoginPwd.Text.Trim() == "")
            {
                epLogPwd.SetError(txtLoginPwd, "请输入登陆密码!");
                return;
            }
            else
            {
                epLogPwd.SetError(txtLoginPwd ,"");
            }
            if (txtLoginPwd.Text.Trim().Length < 6)
            {
                epLogPwd.SetError(txtLoginPwd, "登陆密码长度不得低于六位数!");
                return;
            }
            else
            {
                epLogPwd.SetError(txtLoginPwd ,"");
            }
            if (txtLoginPwd.Text.Trim() != txtLoginPwd2.Text.Trim())
            {
                epLogPwd.SetError(txtLoginPwd2, "两次输入登陆密码不一致!");
                return;
            }
            else
            {
                epLogPwd.SetError(txtLoginPwd ,"");
            }
            if (txtContorlPwd.Text.Trim() == "")
            {
                epCtlPwd.SetError(txtContorlPwd, "请输入控制密码!");
                return;
            }
            else
            {
                epCtlPwd.SetError(txtContorlPwd ,"");
            }
            if (txtContorlPwd.Text.Length < 6)
            {
                epCtlPwd.SetError(txtContorlPwd, "控制密码长度不得低于六位数!");
                return;
            }
            else
            {
                epCtlPwd.SetError(txtContorlPwd,"");
            }
            if (txtControlPwd2.Text.Trim() != txtContorlPwd.Text.Trim())
            {
                epCtlPwd.SetError(txtControlPwd2, "两次输入控制密码不一致!");
                return;
            }
            else
            {
                epCtlPwd.SetError(txtControlPwd2 ,"");
            }
            if (txtCard.Text.Trim() == "")
            {
                epPhone.SetError(txtCard, "请输入身份证号!");
                return;
            }
            else
            {
                epPhone.SetError(txtCard ,"");
            }
            if (!CheckCidInfo(txtCard.Text))
            {
                //身份证输入错误
                epCard.SetError(txtCard, "身份证输入错误");
                return;
            }
            else
            {
                epCard.SetError(txtCard ,"");
            }
            if (!CheckPhone(txtPhone.Text))
            {
                //电话输入错误
                epPhone.SetError(txtPhone, "电话输入错误");
                return;
            }
            else
            {
                epPhone.SetError(txtPhone ,"");
            }
            Thread th = new Thread(new ThreadStart(btnOKClick));
            th.IsBackground = true;
            th.Start();
        }
        #endregion

        #region 根据用户Id获取用户信息
        private void GetUserInfoById(object user)
        {
            UserInfo userTemp = userBLL.SelectUserById((UserInfo)user);
            this.Invoke(new Action(() =>
                {
                    txtUserId.Text = userTemp.DpId.ToString();
                    txtName.Text = userTemp.UserName;
                    txtCard.Text = userTemp.UserCard;
                    txtContorlPwd.Text = userTemp.UserControlPwd;
                    txtControlPwd2.Text = userTemp.UserControlPwd;
                    txtLoginPwd.Text = userTemp.UserPwd;
                    txtLoginPwd2.Text = userTemp.UserPwd;
                    cmbDepart.SelectedValue = userTemp.DpId;
                    txtPhone.Text = userTemp.UserPhone;
                    image = userTemp.UserPhoto;
                    try
                    {
                        if (userTemp .UserPhoto ==new  Byte [0])
                        {
                            return;
                        }
                        MemoryStream stream = new MemoryStream(userTemp.UserPhoto, true);
                        stream.Write(userTemp.UserPhoto, 0, userTemp.UserPhoto.Length);
                        picUser.Image = new Bitmap(stream);
                        picUser.SizeMode = PictureBoxSizeMode.StretchImage;
                    }
                    catch (Exception ex)
                    {
                        picUser.Image = null;
                    }
                    departValue = userTemp.DpId;

                }));

        }
        #endregion

        #region 窗体加载
        private void ChangeUserWindow_Load(object sender, EventArgs e)
        {
            Thread thCmb = new Thread(new ThreadStart(BindCmb));
            thCmb.IsBackground = true;
            thCmb.Start();

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

        #region 取消按钮点击事件
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region 上传照片按钮点击事件
        private void btnUploadPic_Click(object sender, EventArgs e)
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

        private void cameraUser_Click(object sender, EventArgs e)
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



    }
}
