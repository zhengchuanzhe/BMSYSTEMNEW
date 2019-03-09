using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MODEL
{
    //非会员租车信息表
    public class VipNoBorrow
    {
        //编号
        private int bbkId;
        public int BbkId
        {
            get { return bbkId; }
            set { bbkId = value; }
        }
        //对应非会员卡卡号
        private int vipId;
        public int VipId
        {
            get { return vipId; }
            set { vipId = value; }
        }
        //租车分店ID
        private int dpId;
        public int DpId
        {
            get { return dpId; }
            set { dpId = value; }
        }
        //租车类型
        private int rkrId;
        public int RkrId
        {
            get { return rkrId; }
            set { rkrId = value; }
        }
        //租车人名称
        private string vnName;
        public string VnName
        {
            get { return vnName; }
            set { vnName = value; }
        }
        //租车人电话
        private string vnPhone;
        public string VnPhone
        {
            get { return vnPhone; }
            set { vnPhone = value; }
        }
        //非会员身份证号
        private string vnCard;
        public string VnCard
        {
            get { return vnCard; }
            set { vnCard = value; }
        }
        //租车辆数
        private int vnNumber;
        public int VnNumber
        {
            get { return vnNumber; }
            set { vnNumber = value; }
        }

        //租车开始时间
        private DateTime bbkTime;
        public DateTime BbkTime
        {
            get { return bbkTime; }
            set { bbkTime = value; }
        }
        //是否删除
        private bool isDelete;
        public bool IsDelete
        {
            get { return isDelete; }
            set { isDelete = value; }
        }
        /// <summary>
        /// 是否归还
        /// </summary>
        private bool isReturn;
        public bool IsReturn
        {
            get { return isReturn; }
            set { isReturn = value; }
        }
        /// <summary>
        /// 未还车辆
        /// </summary>
        private int leftNum;
        public int LeftNum
        {
            set { leftNum = value; }
            get { return leftNum; }
        }
        /// <summary>
        /// 用户Id
        /// </summary>
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
        public string Mark
        {
            set { mark=value ; }
            get { return mark; }
        }
        /// <summary>
        /// 是否为包夜租车
        /// </summary>
        private bool isNight;
        public bool IsNight
        {
            set { isNight = value; }
            get { return isNight; }
        }

    }
}
