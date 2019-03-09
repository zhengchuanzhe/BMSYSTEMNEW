using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MODEL;
using BIKEDAL;

namespace BIKEBLL
{
    public class VipMoneyBLL
    {
        VipMoneyDal vipMoneyDal;
        public VipMoneyBLL()
        {
            vipMoneyDal = new VipMoneyDal();
        }

        #region 会员余额添加
        /// <summary>
        /// 会员余额添加
        /// </summary>
        /// <param name="vipMoney"></param>
        /// <returns></returns>
        public bool VipMoneyInsert(VipMoney vipMoney)
        {
            return vipMoneyDal.VipMoneyInsert(vipMoney);

        }
        #endregion

        #region 会员余额更新
        /// <summary>
        /// 会员余额更新
        /// </summary>
        /// <param name="vipMoney"></param>
        /// <returns></returns>
        public bool VipMoneyUpdate(VipMoney vipMoney)
        {
            return vipMoneyDal.VipMoneyUpdate(vipMoney);
        }
        #endregion

        #region 删除会员余额
        /// <summary>
        /// 删除会员余额
        /// </summary>
        /// <param name="vipMoney"></param>
        /// <returns></returns>
        public bool VipMoneyDelete(VipMoney vipMoney)
        {
            return vipMoneyDal.VipMoneyDelete(vipMoney);
        }
        #endregion

        #region 根据LVID获得会员余额
        /// <summary>
        /// 根据LVID获得会员余额
        /// </summary>
        /// <returns></returns>
        public VipMoney VipMoneySelectById(VipMoney vipMoney)
        {
            return vipMoneyDal.VipMoneySelectById(vipMoney);
        }
        #endregion

        #region 获取所有会员余额
        /// <summary>
        /// 获取所有会员余额
        /// </summary>
        /// <returns></returns>
        public List<VipMoney> VipMoneySelect()
        {
            return vipMoneyDal.VipMoneySelect(true);
        }
        #endregion

        #region 查询会员总余额
        /// <summary>
        /// 查询会员总余额
        /// </summary>
        /// <returns></returns>
        public double vipSumMoneyBalance()
        {
            return vipMoneyDal.vipSumMoneyBalance();
        }
        #endregion

        #region 查询非会员总余额
        /// <summary>
        /// 查询非会员总余额
        /// </summary>
        /// <returns></returns>
        public double vipNotSumMoneyBalance()
        {
            return vipMoneyDal.vipNotSumMoneyBalance();
        }
        #endregion

        #region 根据DPId查询会员余额
        /// <summary>
        /// 根据DPId查询会员余额
        /// </summary>
        /// <returns></returns>
        public double vipSumMoneyBalanceByDpId(string DpId)
        {
            return vipMoneyDal.vipSumMoneyBalanceByDpId(DpId);
        }
        #endregion

        #region 根据DPId查询非会员余额
        /// <summary>
        /// 根据DPId查询会员余额
        /// </summary>
        /// <returns></returns>
        public double vipNoSumMoneyBalanceByDpId(string DpId)
        {
            return vipMoneyDal.vipNoSumMoneyBalanceByDpId(DpId);
        }
        #endregion

        #region 获取所有非会员余额
        /// <summary>
        /// 获取所有非会员余额
        /// </summary>
        /// <returns></returns>
        public List<VipMoney> VipNoMoneySelect()
        {
            return vipMoneyDal.VipMoneySelect(false);
        }
        #endregion


        #region 根据会员Id获取余额
        public VipMoney VipMoneySelectByVipId(VipMoney vipMoney)
        {
            return vipMoneyDal.VipMoneySelectByVipId(vipMoney);
        }
        #endregion

        #region 会员充值
        /// <summary>
        /// 会员与非会员充值
        /// </summary>
        /// <param name="vipMoney"></param>
        /// <returns></returns>
        public bool Recharge(RechargeInfo vipMoney, double Integral)
        {
            VipMoney money = new VipMoney();
            money.IsVip = vipMoney.IsVip;
            money.VipId = vipMoney.VipId;
            money.VmBalance = vipMoney.ChargeMoney;
            money.Integral = Integral;
            ///先去记录充值信息
            vipMoneyDal.RechargeInfoAdd(vipMoney);
            //这里去充值
            return vipMoneyDal.Recharge(money);
        }
        #endregion

        #region 会员充值记录查询

        public List<RechargeInfo> RechargeInfoSelect(DateTime begin, DateTime end, RechargeInfo rechargeInfo)
        {
            return vipMoneyDal.RechargeInfoSelect(begin, end, rechargeInfo);
        }
        #endregion

    }
}
