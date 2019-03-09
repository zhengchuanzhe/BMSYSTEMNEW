using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MODEL
{
    //会员余额信息
    public class VipMoney
    {
        //编号
        private int vmId;
        public int VmId
        {
            get { return vmId; }
            set { vmId = value; }
        }
        //会员编号
        private int vipId;
        public int VipId
        {
            get { return vipId; }
            set { vipId = value; }
        }
        //会员余额
        private double vmBalance;
        public double VmBalance
        {
            get { return vmBalance; }
            set { vmBalance = value; }
        }
        //是否删除
        private bool isDelete;
        public bool IsDelete
        {
            get { return isDelete; }
            set { isDelete = value; }
        }
        /// <summary>
        /// 是否VIP
        /// </summary>
        private bool isVip;
        public bool IsVip
        {
            get { return isVip; }
            set { isVip = value; }
        }
        /// <summary>
        /// 会员积分
        /// </summary>
        private double integral;
        public double Integral
        {
            get { return integral; }
            set { integral = value; }
        }


    }
}
