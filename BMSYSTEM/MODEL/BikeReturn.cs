using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MODEL
{
    //还车基本信息
    public class BikeReturn
    {
        //标示ID
        private int rbkId;
        public int RbkId
        {
            get { return rbkId; }
            set { rbkId = value; }
        }
        //租车信息ID
        private int bbkId;
        public int BbkId
        {
            get { return bbkId; }
            set { bbkId = value; }
        }
        //还车时间
        private DateTime rbkTime;
        public DateTime RbkTime
        {
            get { return rbkTime; }
            set { rbkTime = value; }
        }
        //会员ID
        private int vipId;
        public int VipId
        {
            get { return vipId; }
            set { vipId = value; }
        }

        //是否是会员还车
        private bool isVip;
        public bool IsVip
        {
            get { return isVip; }
            set { isVip = value; }
        }
        //还车地编号
        private int dpId;
        public int DpId
        {
            get { return dpId; }
            set { dpId = value; }
        }
        //使用金额
        private double buCost;
        public double BuCost
        {
            get { return buCost; }
            set { buCost = value; }
        }
        //使用时长
        private DateTime buTime;
        public DateTime BuTime
        {
            get { return buTime; }
            set { buTime = value; }
        }
        //还车数量
        private int brNumber;
        public int BrNumber
        {
            get { return brNumber; }
            set { brNumber = value; }
        }
        //是否删除
        private int isDelete;
        public int IsDelete
        {
            get { return isDelete; }
            set { isDelete = value; }
        }
        private string buTimeString;
        public string BuTimeString
        {
            get { return buTimeString; }
            set { buTimeString = value; }
        }
        /// <summary>
        /// 租车时间，适当的修改model因为有的地方需要用到
        /// </summary>
        private DateTime bbTime;
        public DateTime BBTime
        {
            set { bbTime = value; }
            get { return bbTime; }
        }
        /// <summary>
        /// 租车时负责人
        /// </summary>
        private int bbUserId;
        public int BBUserId
        {
            get { return bbUserId; }
            set { bbUserId = value; }
        }
        /// <summary>
        /// 用户Id
        /// </summary>
        private int userId;
        public int UserId
        {
            set { userId = value; }
            get { return userId; }
        }
        /// <summary>
        /// 备注信息
        /// </summary>
        private string mark;
        public string Mark
        {
            set { mark = value; }
            get { return mark; }
        }
    }
}
