using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MODEL
{
    public class VIPInfo
    {
        //vip自动生成标号
        private int vipId;
        public int VipId
        {
            get { return vipId; }
            set { vipId = value; }
        }
        //vip卡号
        private string vipNumber;
        public string VipNumber
        {
            get { return vipNumber; }
            set { vipNumber = value; }
        }
        //vip姓名
        private string vipName;
        public string VipName
        {
            get { return vipName; }
            set { vipName = value; }
        }
        //vip性别，ture表示男，false表示女
        private bool vipSex;
        public bool VipSex
        {
            get { return vipSex; }
            set { vipSex = value; }
        }
        //vip相片地址
        private byte[] vipPhoto;
        public byte[] VipPhoto
        {
            get { return vipPhoto; }
            set { vipPhoto = value; }
        }
        //vip 用户等级
        private int vipLevelId;
        public int VipLevelId
        {
            get { return vipLevelId; }
            set { vipLevelId = value; }
        }
        //vip密码
        private string vipPWD;
        public string VipPWD
        {
            get { return vipPWD; }
            set { vipPWD = value; }
        }
        //vip电话
        private string vipPhone;
        public string VipPhone
        {
            get { return vipPhone; }
            set { vipPhone = value; }
        }
        //vip生日
        private DateTime vipBirthDay;
        public DateTime VipBirthDay
        {
            get { return vipBirthDay; }
            set { vipBirthDay = value; }
        }
        //vip身份证号
        private string vipCard;
        public string VipCard
        {
            get { return vipCard; }
            set { vipCard = value; }
        }
        //vip地址
        private string vipAddress;
        public string VipAddress
        {
            get { return vipAddress; }
            set { vipAddress = value; }
        }
        //是否删除
        private bool isDelete;
        public bool IsDelete
        {
            get { return isDelete; }
            set { isDelete = value; }
        }
        //所属分店
        private int dpId;
        public int DpId
        {
            get { return dpId; }
            set { dpId = value; }
        }
        //添加时间
        private DateTime addDate;
        public DateTime AddDate
        {
            get { return addDate; }
            set { addDate = value; }
        }
        //添加人
        private int userId;
        public int UserId
        {
            get { return userId; }
            set { userId = value; }
        }
        /// <summary>
        /// 备注
        /// </summary>
        private string mark;
        public string  Mark
        {
            get { return mark; }
            set { mark = value; }
        }
    }
}
