using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MODEL
{
    /// <summary>
    /// 非会员基本信息
    /// </summary>
    public class VipNoInfo
    {
        //非会员编号
        private int vipId;
        public int VipId
        {
            get { return vipId; }
            set { vipId = value; }
        }
        //非会员卡号
        private string vipNumber;
        public string VipNumber
        {
            get { return vipNumber; }
            set { vipNumber = value; }
        }
        //非会员名称
        private string vipName;
        public string VipName
        {
            get { return vipName; }
            set { vipName = value; }
        }
        //非会员控制密码
        private string vipPwd;
        public string VipPwd
        {
            get { return vipPwd; }
            set { vipPwd = value; }
        }

        //非会员电话
        private string vipPhone;
        public string VipPhone
        {
            get { return vipPhone; }
            set { vipPhone = value; }
        }

        //非会员身份证号
        private string vipCard;
        public string VipCard
        {
            get { return vipCard; }
            set { vipCard = value; }
        }

        //等级
        private int lvId;
        public int LvId
        {
            get
            {
                return lvId;
            }
            set
            {
                lvId = value;
            }
        }
        //是否删除
        private bool isDelete;
        public bool IsDelete
        {
            get { return isDelete; }
            set { isDelete = value; }
        }
        //所属分店ID
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
        /// <summary>
        /// 备注
        /// </summary>
        private string mark;
        public string Mark
        {
            set { mark = value; }
            get { return mark; }
        }
    }
}
