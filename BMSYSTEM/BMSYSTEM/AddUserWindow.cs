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
using System.IO;
using System.Threading;

namespace BMSYSTEM
{
    public partial class AddUserWindow : Form
    {
        UserBLL userBLL;
        DepartBLL departBLL;
        List<DepartInfo> departList;
        BackgroundWorker bg;
        byte[] image;
        public AddUserWindow()
        {
            bg = new BackgroundWorker();
            bg.DoWork += new DoWorkEventHandler(bg_DoWork);//异步操作时要做的操作，一般去查列表，这个列表在本页面内先声明，然后在这个dowork方法里去取数填充他
            bg.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bg_RunWorkerCompleted);//这个是取数完成后进行的操作，去到数后，这里取用去到的列表绑定到控件
            userBLL = new UserBLL();
            departBLL = new DepartBLL();
            departList = new List<DepartInfo>();
            InitializeComponent();

        }

        void bg_DoWork(object sender, DoWorkEventArgs e)
        {
            departList = departBLL.DepartSelect();
        }
        void bg_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            FillDp();
        }
        private void FillDp()
        {
            cmbDPID.DataSource = departList;
            cmbDPID.DisplayMember = "DPNAME";
            cmbDPID.ValueMember = "DPID";
        }


        #region 确认按钮点击事件
        private void btnOKClick()
        {



        }
        private void btnOK_Click(object sender, EventArgs e)
        {
            if (txtName.Text == "")
            {
                epName.SetError(txtName, "请输入用户名称");
                return;
            }
            if (userBLL.IsExistUser(txtName.Text.Trim()))
            {
                epName.SetError(txtName, "此用户名已存在");
                return;
            }
            else
            {
                epName.SetError(txtName, "");
            }

            if (txtPWD.Text == "")
            {
                epLoginPWD.SetError(txtPWD, "请输入登录密码");
                return;
            }
            if (txtPWD.Text.Length < 6)
            {
                epLoginPWD.SetError(txtPWD, "登录密码长度不得低于六位数");
                return;
            }
            else
            {
                epLoginPWD.SetError(txtPWD, "");
            }
            if (txtPWDConfirm.Text == "")
            {
                epLoginPWD2.SetError(txtPWDConfirm, "请再次输入登录密码");
                return;
            }
            if (txtPWD.Text != txtPWDConfirm.Text)
            {
                epLoginPWD2.SetError(txtPWDConfirm, "两次输入的登录密码不一致");
                return;
            }
            else
            {
                epLoginPWD2.SetError(txtPWDConfirm, "");
            }
            if (txtPWDControl.Text == "")
            {
                epControlPWD.SetError(txtPWDControl, "请输入控制密码");
                return;
            }
            if (txtPWDControl.Text.Length < 6)
            {
                epControlPWD.SetError(txtPWDControl, "控制密码长度不得低于六位数。");
                return;
            }
            else
            {
                epControlPWD.SetError(txtPWDControl, "");
            }
            if (txtPWDControlConfirm.Text == "")
            {
                epControlPWD2.SetError(txtPWDControlConfirm, "请再次输入控制密码");
                return;
            }
            if (txtPWDControl.Text != txtPWDControlConfirm.Text)
            {
                epControlPWD2.SetError(txtPWDControlConfirm, "两次输入的控制密码不一致");
                return;
            }
            else
            {
                epControlPWD2.SetError(txtPWDControlConfirm, "");
            }
            if (txtPhone.Text == "")
            {
                epPhone.SetError(txtPhone, "请输入用户电话");
                return;
            }
            if (!CheckPhone(txtPhone.Text))
            {
                //电话输入错误
                epPhone.SetError(txtPhone, "用户电话输入错误");
                return;
            }
            else
            {
                epPhone.SetError(txtPhone, "");
            }
            if (txtCard.Text == "")
            {
                epCard.SetError(txtCard, "请输入身份证号");
                return;
            }
            if (!CheckCidInfo(txtCard.Text))
            {
                //身份证输入错误
                epCard.SetError(txtCard, "身份证输入错误");
                return;
            }
            else
            {
                epCard.SetError(txtCard, "");
            }
            btnOK.Enabled = false;
            progressBar1.Visible = true;
            user.UserName = txtName.Text;
            user.UserPwd = txtPWD.Text;
            user.UserControlPwd = txtPWDControl.Text;
            user.UserPhone = txtPhone.Text;
            user.UserCard = txtCard.Text;
            user.DpId = Convert.ToInt32(cmbDPID.SelectedValue);
            user.UserPhoto = image;

            logInfo.UserId = StaticData.userLocal.UserId;
            logInfo.Content = "添加了用户，名称为‘" + txtName.Text + "'";
            logInfo.LogTime = DateTime.Now;
            logInfo.DpId = StaticData.departLocal.DpId;

            backgroundWorker1.RunWorkerAsync();
        }
        #endregion

        #region 窗体加载
        private void AddUser_Load(object sender, EventArgs e)
        {
            bg.RunWorkerAsync();
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

        #region 上传照片按钮点击事件
        private void btnSelectPic_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog ofd = new OpenFileDialog();                //new一个方法    
                ofd.ShowDialog();          //显示打开文件的窗口
                string fileName = ofd.FileName;                //获得选择的文件路径
                addPhoto.ImageLocation = fileName;
                FileStream fs = File.OpenRead(fileName);
                image = new byte[fs.Length];
                fs.Read(image, 0, image.Length);
                fs.Close();
                addPhoto.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            catch (Exception ex)
            {
                MessageBox.Show("上传照片失败");
            }
        }
        #endregion

        #region 取消按钮点击事件
        private void btnConcel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region 拍照按钮事件
        private void cameraUser_Click(object sender, EventArgs e)
        {
            try
            {

                Camera camera = new Camera();
                camera.ShowDialog();
                image = camera.CaptureData;
                MemoryStream stream = new MemoryStream(image, true);
                addPhoto.Image = new Bitmap(stream);
                addPhoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            }
            catch (Exception)
            {

            }
        }
        #endregion


        UserInfo user = new UserInfo();
        bool b1;
        LogInfo logInfo = new LogInfo();
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            backgroundWorker1.ReportProgress(10);//这里让进度条显示进度
            b1 = userBLL.InsertUser(user);
            backgroundWorker1.ReportProgress(60);//这里让进度条显示进度
            bool b = new LogBLL().LogInsert(logInfo);
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
            if (b1)
            {
                MessageBox.Show("添加用户成功");

                this.Close();
            }
            else
            {
                MessageBox.Show("添加用户失败");
            }

        }
    }
}
