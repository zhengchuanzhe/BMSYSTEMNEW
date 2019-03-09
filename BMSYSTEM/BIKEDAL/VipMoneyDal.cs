using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MODEL;
using BIKECOMMON;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace BIKEDAL
{
    public class VipMoneyDal
    {
        DataTable dt;
        ExceptionHelper except;
        public VipMoneyDal()
        {
            except = new ExceptionHelper();
        }

        #region 会员余额添加
        /// <summary>
        /// 会员余额添加
        /// </summary>
        /// <param name="vipMoney"></param>
        /// <returns></returns>
        public bool VipMoneyInsert(VipMoney vipMoney)
        {
            int result;
            try
            {
                string sql = "VIP_MONEY_INSERT";
                SqlParameter[] para = new SqlParameter[]
               {
                   new SqlParameter("@VIPID",SqlDbType.Int),
                   new SqlParameter("@VMBALANCE",SqlDbType.Money),
                   new SqlParameter("@ISVIP",SqlDbType.Bit)
               };
                para[0].Value = vipMoney.VipId;
                para[1].Value = vipMoney.VmBalance;
                para[2].Value = vipMoney.IsVip;
                result = SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringShop, CommandType.StoredProcedure, sql, para);
                return result > 0 ? true : false;
            }
            catch (Exception ex)
            {
                except.ExceptionInsert("添加会员余额出错：" + ex.Message, "VipMoneyInsert", DateTime.Now);
                return false;
            }

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
            int result;
            try
            {
                string sql = "VIP_MONEY_UPDATE";
                SqlParameter[] para = new SqlParameter[]
                {
                    new SqlParameter("@VIPID",SqlDbType.Int),
                    new SqlParameter("@VMBALANCE",SqlDbType.Money),
                    new SqlParameter("@ISVIP",SqlDbType.Bit)
                };
                para[0].Value = vipMoney.VipId;
                para[1].Value = vipMoney.VmBalance;

                para[2].Value = vipMoney.IsVip;
                result = SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringShop, CommandType.StoredProcedure, sql, para);
                return result > 0 ? true : false;
            }
            catch (Exception ex)
            {
                except.ExceptionInsert("修改会员余额出错：" + ex.Message, "VipMoneyUpdate", DateTime.Now);
                return false;
            }
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
            string sql = "VIP_MONEY_DELETE";
            try
            {
                SqlParameter[] para = new SqlParameter[]
                {
                    new SqlParameter("@VMID",SqlDbType.Int)
                };
                para[0].Value = vipMoney.VmId;
                int result = SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringShop, CommandType.StoredProcedure, sql, para);
                return result > 0 ? true : false;
            }
            catch (Exception ex)
            {
                except.ExceptionInsert("删除会员余额出错：" + ex.Message, "VipMoneyDelete", DateTime.Now);
                return false;
            }
        }
        #endregion

        #region 根据LVID获得会员余额
        /// <summary>
        /// 根据LVID获得会员余额
        /// </summary>
        /// <returns></returns>
        public VipMoney VipMoneySelectById(VipMoney vipMoney)
        {
            string sql = "VIP_MONEY_SELECT_BY_VMID";
            dt = new DataTable();
            try
            {
                SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@VMID",SqlDbType.Int)             
            };
                para[0].Value = vipMoney.VmId;
                using (SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringShop, CommandType.StoredProcedure, sql, para))
                {
                    dt.Load(dr);
                }
                VipMoney vipMoneyInfo = new VipMoney();
                vipMoneyInfo.VmId = Convert.ToInt32(dt.Rows[0]["VMID"]);
                vipMoneyInfo.VipId = Convert.ToInt32(dt.Rows[0]["VIPID"]);
                vipMoneyInfo.VmBalance = Convert.ToDouble(dt.Rows[0]["VMBALANCE"]);
                vipMoneyInfo.Integral = Convert.ToDouble(dt.Rows[0]["INTEGRAL"]);
                return vipMoneyInfo;
            }
            catch (Exception ex)
            {
                except.ExceptionInsert("查询会员余额出错：" + ex.Message, "VipMoneySelectById", DateTime.Now);
                return null;
            }
        }
        #endregion

        #region 获取所有会员余额
        /// <summary>
        /// 获取所有会员余额
        /// </summary>
        /// <returns></returns>
        public List<VipMoney> VipMoneySelect(bool isVip)
        {
            string sql = "VIP_MONEY_SELECT";
            List<VipMoney> listVipMoney = new List<VipMoney>();
            dt = new DataTable();
            try
            {
                SqlParameter[] para = new SqlParameter[]
                {
                    new SqlParameter("@ISVIP",SqlDbType.Bit)
                };
                para[0].Value = isVip;
                using (SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringShop, CommandType.StoredProcedure, sql, para))
                {
                    dt.Load(dr);
                }
                VipMoney vipMoneyTemp;
                //VMID,VIPID,VMBALANCE
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    vipMoneyTemp = new VipMoney();
                    vipMoneyTemp.VmId = Convert.ToInt32(dt.Rows[i]["VMID"]);
                    vipMoneyTemp.VipId = Convert.ToInt32(dt.Rows[i]["VIPID"]);
                    vipMoneyTemp.VmBalance = Convert.ToDouble(dt.Rows[i]["VMBALANCE"]);
                    vipMoneyTemp.Integral = Convert.ToDouble(dt.Rows[i]["INTEGRAL"]);
                    listVipMoney.Add(vipMoneyTemp);
                }
                return listVipMoney;
            }
            catch (Exception ex)
            {
                except.ExceptionInsert("查询会员余额出错：" + ex.Message, "VipMoneySelect", DateTime.Now);
                return null;
            }
        }
        #endregion


        #region 查询会员总余额
        /// <summary>
        /// 查询会员总余额
        /// </summary>
        /// <returns></returns>
        public double vipSumMoneyBalance()
        {
            double sumMoneyBalance = 0;
            string sql = "VIP_SUM_MONEY_BALANCE";
            try
            {
                SqlParameter[] param = new SqlParameter[] { };
                object o = SqlHelper.ExecuteScalar(SqlHelper.ConnectionStringShop, CommandType.StoredProcedure, sql, param);
                sumMoneyBalance = Convert.ToDouble(o.ToString()); ;
                return sumMoneyBalance;
            }
            catch (Exception ex)
            {
                return sumMoneyBalance;
            }

        }
        #endregion

        #region 查询非会员总余额
        /// <summary>
        /// 查询非会员总余额
        /// </summary>
        /// <returns></returns>
        public double vipNotSumMoneyBalance()
        {
            double sumNotMoneyBalance = 0;
            string sql = "VIP_NOT_SUM_MONEY_BALANCE";
            try
            {
                SqlParameter[] param = new SqlParameter[] { };
                object o = SqlHelper.ExecuteScalar(SqlHelper.ConnectionStringShop, CommandType.StoredProcedure, sql, param);
                sumNotMoneyBalance = Convert.ToDouble(o.ToString()); ;
                return sumNotMoneyBalance;
            }
            catch (Exception ex)
            {
                return sumNotMoneyBalance;
            }

        }
        #endregion

        #region 根据DPId查询会员余额
        /// <summary>
        /// 根据DPId查询会员余额
        /// </summary>
        /// <returns></returns>
        public double vipSumMoneyBalanceByDpId(string DpId)
        {
            double sumMoneyBalanceByDpId = 0;
            string sql = "VIP_SUM_MONEY_BALANCE_BY_DPID";
            try
            {
                SqlParameter[] param = new SqlParameter[] { 
                    new SqlParameter ("@DPID",DpId )
                };
                object o = SqlHelper.ExecuteScalar(SqlHelper.ConnectionStringShop, CommandType.StoredProcedure, sql, param);
                sumMoneyBalanceByDpId = Convert.ToDouble(o.ToString()); ;
                return sumMoneyBalanceByDpId;
            }
            catch (Exception ex)
            {
                return sumMoneyBalanceByDpId;
            }

        }
        #endregion

        #region 根据DPId查询非会员余额
        /// <summary>
        /// 根据DPId查询会员余额
        /// </summary>
        /// <returns></returns>
        public double vipNoSumMoneyBalanceByDpId(string DpId)
        {
            double sumNoMoneyBalanceByDpId = 0;
            string sql = "VIP_NO_SUM_MONEY_BALANCE_BY_DPID";
            try
            {
                SqlParameter[] param = new SqlParameter[] { 
                    new SqlParameter ("@DPID",DpId )
                };
                object o = SqlHelper.ExecuteScalar(SqlHelper.ConnectionStringShop, CommandType.StoredProcedure, sql, param);
                sumNoMoneyBalanceByDpId = Convert.ToDouble(o.ToString()); ;
                return sumNoMoneyBalanceByDpId;
            }
            catch (Exception ex)
            {
                return sumNoMoneyBalanceByDpId;
            }

        }
        #endregion

        #region 根据会员Id获取余额
        public VipMoney VipMoneySelectByVipId(VipMoney vipMoney)
        {
            string sql = "VIP_MONEY_SELECT_BY_VIPID";
            dt = new DataTable();
            try
            {
                SqlParameter[] para = new SqlParameter[]
                {
                new SqlParameter("@VIPID",SqlDbType.Int),
                new SqlParameter("@ISVIP",SqlDbType.Bit)
                };
                para[0].Value = vipMoney.VipId;
                para[1].Value = vipMoney.IsVip;
                using (SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringShop, CommandType.StoredProcedure, sql, para))
                {
                    dt.Load(dr);
                }
                VipMoney vipMoneyInfo = new VipMoney();
                vipMoneyInfo.VmId = Convert.ToInt32(dt.Rows[0]["VMID"]);
                vipMoneyInfo.VipId = Convert.ToInt32(dt.Rows[0]["VIPID"]);
                vipMoneyInfo.VmBalance = Convert.ToDouble(dt.Rows[0]["VMBALANCE"]);
                vipMoneyInfo.Integral = Convert.ToDouble(dt.Rows[0]["INTEGRAL"]);
                return vipMoneyInfo;
            }
            catch (Exception ex)
            {
                except.ExceptionInsert("查询会员余额出错：" + ex.Message, "VipMoneySelectByVipId", DateTime.Now);
                return null;
            }
        }
        #endregion

        #region 会员非会员充值
        public bool Recharge(VipMoney vipMoney)
        {
            string sql = "VIP_MONEY_RECHARGE";
            try
            {
                SqlParameter[] para = new SqlParameter[]
                {
                    new SqlParameter("@VIPID",SqlDbType.Int),
                    new SqlParameter("@VMBALANCE",SqlDbType.Money),
                    new SqlParameter("@ISVIP",SqlDbType.Bit),
                    new SqlParameter ("@INTEGRAL",SqlDbType .Money )
                };
                para[0].Value = vipMoney.VipId;
                para[1].Value = vipMoney.VmBalance;
                para[2].Value = vipMoney.IsVip;
                para[3].Value = vipMoney.Integral;
                int result = SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringShop, CommandType.StoredProcedure, sql, para);
                return true;
            }
            catch (Exception ex)
            {
                except.ExceptionInsert("会员充值出错：" + ex.Message, "Recharge", DateTime.Now);
                return false;
            }
        }

        #endregion

        #region 会员或非会员充值记录

        public List<RechargeInfo> RechargeInfoSelect(DateTime begin, DateTime end, RechargeInfo rechargeInfo)
        {
            string sql = "RECHARGE_SELECT_BY_DEPART";
            List<RechargeInfo> rechargeList = new List<RechargeInfo>();
            dt = new DataTable();
            try
            {
                SqlParameter[] para = new SqlParameter[]
                {
                    new SqlParameter("@beginTime",SqlDbType.DateTime),
                    new SqlParameter("@endTime",SqlDbType.DateTime),
                    new SqlParameter("@DepartId",SqlDbType.Int)
                };
                para[0].Value = begin;
                para[1].Value = end;
                para[2].Value = rechargeInfo.DepartId;
                RechargeInfo rechargeTemp;
                using (SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringShop, CommandType.StoredProcedure, sql, para))
                {
                    dt.Load(dr);
                }
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    rechargeTemp = new RechargeInfo();
                    rechargeTemp.DepartId = Convert.ToInt32(dt.Rows[i]["DEPARTMENTID"]);
                    rechargeTemp.ChargeMoney = Convert.ToDouble(dt.Rows[i]["CHARGEMONEY"]);
                    rechargeTemp.Balance = Convert.ToDouble(dt.Rows[i]["BALANCE"]);
                    rechargeTemp.ID = Convert.ToInt32(dt.Rows[i]["ID"]);
                    rechargeTemp.IsVip = Convert.ToBoolean(dt.Rows[i]["ISVIP"]);
                    rechargeTemp.VipId = Convert.ToInt32(dt.Rows[i]["VIPID"]);
                    rechargeTemp.UserId = Convert.ToInt32(dt.Rows[i]["USERID"]);
                    rechargeTemp.RechargeTime = Convert.ToDateTime(dt.Rows[i]["CHARGETIME"]);
                    rechargeList.Add(rechargeTemp);
                }
                return rechargeList;
            }
            catch (Exception ex)
            {
                except.ExceptionInsert("查询会员或非会员充值记录出错：" + ex.Message, "RechargeInfoSelect", DateTime.Now);
                return null;
            }

        }

        #endregion


        #region 添加会员或非会员充值记录

        public bool RechargeInfoAdd(RechargeInfo recharge)
        {
            string sql = "RECHARGE_ADD";
            try
            {
                SqlParameter[] para = new SqlParameter[]
                {
                    new SqlParameter("@VIPID",SqlDbType.Int),
                    new SqlParameter("@ISVIP",SqlDbType.Bit),
                    new SqlParameter("@CHARGEMONEY",SqlDbType.Money),
                    new SqlParameter("@DEPARTMENTID",SqlDbType.Int),
                    new SqlParameter("@USERID",SqlDbType.Int)
                };
                para[0].Value = recharge.VipId;
                para[1].Value = recharge.IsVip;
                para[2].Value = recharge.ChargeMoney;
                para[3].Value = recharge.DepartId;
                para[4].Value = recharge.UserId;
                int result = SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringShop, CommandType.StoredProcedure, sql, para);
                return result > 0 ? true : false;
            }
            catch (Exception ex)
            {
                except.ExceptionInsert("添加会员充值记录出错：" + ex.Message, "RechargeInfoAdd", DateTime.Now);
                return false;
            }
        }
        #endregion

    }
}
