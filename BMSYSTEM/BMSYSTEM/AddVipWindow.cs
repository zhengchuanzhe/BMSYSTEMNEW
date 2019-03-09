using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.IO;
using MODEL;
using BIKEBLL;
using System.Management;
using System.Threading;

namespace BMSYSTEM
{
    public partial class AddVipWindow : Form
    {
        VipBLL vipBLL;
        VIPInfo vipModel;
        List<VipLevelInfo> vipLVList;
        byte[] image;
        double money = 0;

        VipLevelBLL vipLVBLL = new VipLevelBLL();
        BackgroundWorker bg = new BackgroundWorker();
        public AddVipWindow()
        {
            InitializeComponent();
            vipModel = new VIPInfo();
            vipBLL = new VipBLL();
            vipLVList = new List<VipLevelInfo>();
            bg.DoWork += new DoWorkEventHandler(bg_DoWork);//异步操作时要做的操作，一般去查列表，这个列表在本页面内先声明，然后在这个dowork方法里去取数填充他
            bg.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bg_RunWorkerCompleted);//这个是取数完成后进行的操作，去到数后，这里取用去到的列表绑定到控件

        }

        void bg_DoWork(object sender, DoWorkEventArgs e)
        {
            vipLVList = vipLVBLL.VipLevelSelectByIsVip(true);
        }
        void bg_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            FillDp();
        }
        private void FillDp()
        {
            cmbLevel.DataSource = vipLVList;
            cmbLevel.DisplayMember = "LVNAME";
            cmbLevel.ValueMember = "LVID";
            if (vipLVList.Count >0)
            {
                cmbLevel.SelectedIndex = vipLVList.Count - 1;
            }
        }

        #region 绑定下拉列表
        /// <summary>
        /// 绑定下拉列表
        /// </summary>

        private void BingdingcmbDp()
        {

        }
        #endregion

        #region 上传照片按钮点击事件
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog ofd = new OpenFileDialog();                //new一个方法    
                ofd.ShowDialog();          //显示打开文件的窗口
                string fileName = ofd.FileName;                //获得选择的文件路径
                picboxPhoto.ImageLocation = fileName;
                FileStream fs = File.OpenRead(fileName);
                image = new byte[fs.Length];
                fs.Read(image, 0, image.Length);
                fs.Close();
                picboxPhoto.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            catch (Exception ex)
            {
                MessageBox.Show("上传照片失败");
            }
        }
        #endregion

        #region 窗体加载
        private void AddVip_Load(object sender, EventArgs e)
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

        #region 确认按钮点击事件

        private void btnEnter_Click(object sender, EventArgs e)
        {
            if (txtNumber.Text.Trim() == "")
            {
                epNumber.SetError(txtNumber, "请输入会员卡号");
                return;
            }
            else
            {
                if (vipBLL.IsExistVip(txtNumber.Text.Trim()))
                {
                    epNumber.SetError(txtNumber, "该卡号已注册");
                    return;
                }
                else
                {
                    epNumber.SetError(txtNumber, "");
                }
            }
            if (cmbLevel.SelectedValue == null)
            {
                epLevel.SetError(cmbLevel, "请选择会员等级");
                return;
            }
            else
            {
                epLevel.SetError(cmbLevel, "");
            }
            if (txtName.Text.Trim() == "")
            {
                epName.SetError(txtName, "请输入会员名称");
                return;
            }
            else
            {
                epName.SetError(txtName, "");
            }
            if (cmbSex.SelectedItem == null)
            {
                epSex.SetError(cmbSex, "请选择会员性别");
                return;
            }
            else
            {
                epSex.SetError(cmbSex, "");
            }
            if (txtPWD.Text.Trim() == "")
            {
                epPWD.SetError(txtPWD, "请输入会员密码");
                return;
            }
            else
            {
                if (txtPWD.Text.Length < 6)
                {
                    epPWD.SetError(txtPWD, "密码长度不得低于六位数");
                    return;
                }
                else
                {
                    epPWD.SetError(txtPWD, "");
                }
            }

            if (txtPWDConfirm.Text.Trim() == "")
            {
                epPWD2.SetError(txtPWDConfirm, "请再次输入会员密码");
                return;
            }
            else
            {
                if (txtPWD.Text.Trim() != txtPWDConfirm.Text.Trim())
                {
                    epPWD2.SetError(txtPWDConfirm, "两次输入的密码不一致");
                    return;
                }
                else
                {
                    epPWD2.SetError(txtPWDConfirm, "");
                }
            }

            if (txtPhone.Text.Trim() == "")
            {
                epPhone.SetError(txtPhone, "请输入会员电话");
                return;
            }
            else
            {
                if (!CheckPhone(txtPhone.Text.Trim()))
                {
                    epPhone.SetError(txtPhone, "联系电话输入错误");
                    return;
                }
                else
                {
                    epPhone.SetError(txtPhone, "");
                }
            }

            if (txtCard.Text.Trim() == "")
            {
                epCard.SetError(txtCard, "请输入会员身份证号");
                return;
            }
            else
            {
                if (!CheckCidInfo(txtCard.Text.Trim()))
                {
                    epCard.SetError(txtCard, "身份证输入错误");
                    return;
                }
                else
                {
                    epCard.SetError(txtCard, "");
                }
            }

            if (txtAddress.Text.Trim() == "")
            {
                epAddress.SetError(txtAddress, "请输入会员地址");
                return;
            }
            else
            {
                epAddress.SetError(txtAddress, "");
            }
            double a=0;
            if (double.TryParse (txtMoney.Text ,out a ))
            {
                money = double.Parse(txtMoney .Text .Trim ());
                if (money <0)
                {
                    epAddress.SetError(txtMoney, "请输入正确的金额");
                    return;
                }
                if (money >500)
                {
                    MessageBox.Show("充值金额不得操作500元");
                    return;
                }
                epAddress.SetError(txtMoney ,"");
            }
            else
            {
                epAddress.SetError(txtMoney, "请输入正确的金额");
                return;
            }
            if (txtMark .Text .Length <=0)
            {
                vipModel.Mark = "";
            }
            else
            {
                vipModel.Mark = txtMark.Text.ToString ().Trim();
            }
            DialogResult result = MessageBox.Show("充值" + txtMoney.Text + "元？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No)
                return;
            vipModel.VipNumber = txtNumber.Text.Trim();
            vipModel.VipName = txtName.Text.Trim();
            vipModel.VipLevelId = Convert.ToInt32(cmbLevel.SelectedValue);
            vipModel.VipSex = cmbSex.SelectedItem.ToString() == "男" ? true : false;
            vipModel.VipPWD = txtPWD.Text.Trim();
            vipModel.VipPhone = txtPhone.Text.Trim();
            vipModel.VipCard = txtCard.Text.Trim();
            string cid = txtCard.Text.Trim();
            DateTime birthDay = DateTime.Parse(cid.Substring(6, 4) + "-" + cid.Substring(10, 2) + "-" + cid.Substring(12, 2));
            vipModel.VipBirthDay = birthDay;
            vipModel.VipAddress = txtAddress.Text.Trim();
            vipModel.VipPhoto = image;
            vipModel.DpId = StaticData.departLocal.DpId;
            vipModel.UserId = StaticData.userLocal.UserId;
            logInfo.UserId = StaticData.userLocal.UserId;
            logInfo.Content = "添加会员，名称为‘" + txtName.Text;
            logInfo.LogTime = DateTime.Now;
            logInfo.DpId = StaticData.departLocal.DpId;
            btnEnter.Enabled = false;
            progressBar1.Visible = true;
            backgroundWorker1.RunWorkerAsync();
        }
        #endregion

        #region 取消按钮点击事件
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
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
                picboxPhoto.Image = new Bitmap(stream);
                picboxPhoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            }
            catch (Exception)
            {

            }
        }
        #endregion

        bool b1;
        LogInfo logInfo = new LogInfo();
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

            backgroundWorker1.ReportProgress(10);//这里让进度条显示进度
            b1 = new VipBLL().VipInsert(vipModel,money );
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
            btnEnter.Enabled = true;
            progressBar1.Visible = false;
            if (b1)
            {
                MessageBox.Show("恭喜您，添加会员成功", "系统提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk);
                this.Close();
            }
            else
            {
                MessageBox.Show("很抱歉，添加会员失败", "系统提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                return;
            }
        }


    }
}
