using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MODEL
{
    //分店月收入情况
    public class DepartMonthForm
    {
        //编号
        private int dmId;
        public int DmId
        {
            get { return dmId; }
            set { dmId = value; }
        }
        //分店编号
        private int dpId;
        public int DpId
        {
            get { return dpId; }
            set { dpId = value; }
        }
        //会员消费收入总额
        private double vipCost;
        public double VipCost
        {
            get { return vipCost; }
            set { vipCost = value; }
        }

        //非会员消费收入总额
        private double vipNoCost;
        public double VipNoCost
        {
            get { return vipNoCost; }
            set { vipNoCost = value; }
        }

        //记录生成时间
        private DateTime time;
        public DateTime Time
        {
            get { return time; }
            set { time = value; }
        }

        //是否删除
        private bool isDelete;
        public bool IsDelete
        {
            get { return isDelete; }
            set { isDelete = value; }
        }
        //新办会员收入
        private double  newVipIncome;
        public double NewVipIncom
        {
            get { return newVipIncome; }
            set { newVipIncome = value; }
        }
        //会员充值收入
        private double vipCharge;
        public double VipCharge
        {
            get { return vipCharge; }
            set { vipCharge = value; }
        }
        //非会员充值
        private double vipNoCharge;
        public double VipNoCharge
        {
            get { return vipNoCharge; }
            set { vipNoCharge = value; }
        }
        //会员余额
        private double vipBalance;
        public double VipBalance
        {
            get { return vipBalance; }
            set { vipBalance = value; }
        }
        //非会员余额
        private double vipNoBalance;
        public double VipNoBalancel
        {
            set { vipNoBalance = value; }
            get { return vipNoBalance; }
        }
        //总收入
        private double total;
        public double Total
        {
            get { return total; }
            set { total = value; }
        }
    }
}
