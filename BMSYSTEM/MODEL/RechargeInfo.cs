using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MODEL
{
    public class RechargeInfo
    {
        /// <summary>
        /// 编号
        /// </summary>
        private int id;
        public int ID
        {
            get { return id; }
            set { id = value; }
        }
        /// <summary>
        /// 会员或非会员ID
        /// </summary>
        private int vipid;
        public int VipId
        {
            get { return vipid; }
            set { vipid = value; }
        }

        /// <summary>
        /// 是否会员
        /// </summary>
        private bool isvip;
        public bool IsVip
        {
            get { return isvip; }
            set { isvip = value; }
        }
        /// <summary>
        /// 充值时间
        /// </summary>
        private DateTime rechargetime;
        public DateTime RechargeTime
        {
            get { return rechargetime; }
            set { rechargetime = value; }
        }
        /// <summary>
        /// 充值前余额
        /// </summary>
        private double balance;
        public double Balance
        {
            get { return balance; }
            set { balance = value; }
        }
        /// <summary>
        /// 充值金额
        /// </summary>
        private double chargemoney;
        public double ChargeMoney
        {
            get { return chargemoney; }
            set { chargemoney = value; }
        }
        /// <summary>
        /// 充值分店
        /// </summary>
        private int departid;
        public int DepartId
        {
            get { return departid; }
            set { departid = value; }
        }
        /// <summary>
        /// 充值用户
        /// </summary>
        private int userid;
        public int UserId
        {
            get { return userid; }
            set { userid = value; }
        }
        /// <summary>
        /// 是否删除
        /// </summary>
        private bool isdelete;
        public bool IsDelete
        {
            get { return isdelete; }
            set { isdelete = value; }
        }


    }
}
