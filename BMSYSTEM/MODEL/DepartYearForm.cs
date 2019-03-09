using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MODEL
{
    //分店年报表
    public class DepartYearForm
    {
        //编号
        private int dyId;
        public int DyId
        {
            get { return dyId; }
            set { dyId = value; }
        }
        //分店编号
        private int dpId;
        public int DpId
        {
            get { return dpId; }
            set { dpId = value; }
        }
        //会员消费收入
        private double vipCost;
        public double VipCost
        {
            get { return vipCost; }
            set { vipCost = value; }
        }
        //非会员消费收入
        private double vipNoCost;
        public double VipNoCost
        {
            get { return vipNoCost; }
            set { vipNoCost = value; }
        }
        //新办会员收入
        private double newVipIncome;
        public double NewVipIncome
        {
            set { newVipIncome = value; }
            get { return newVipIncome; }
        }
        //会员充值
        private double vipCharge;
        public double VipCharge
        {
            set { vipCharge = value; }
            get { return vipCharge; }
        }
        //非会员充值
        private double vipNoCharge;
        public double VipNoCharge
        {
            get { return vipNoCharge; }
            set { vipNoCharge = value; }
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
        //总收入
        private double total;
        public double Total
        {
            get { return total; }
            set { total = value; }
        }

    }
}
