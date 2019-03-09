using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BIKECOMMON;
using MODEL;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace BIKEDAL
{
    public class MonthCostRuleDal
    {
        DataTable dt;
        ExceptionHelper except;
        public MonthCostRuleDal()
        {
            except = new ExceptionHelper();
        }
        #region 月租扣费规则添加
        /// <summary>
        /// 月租扣费规则添加
        /// </summary>
        /// <param name="monthCostRule"></param>
        /// <returns></returns>
        public bool MonthCostRuleInsert(MonthCostRule monthCostRule)
        {
            int result;
            try
            {
                string sql = "MONTH_COST_RULE_INSERT";
                SqlParameter[] para = new SqlParameter[]
               {
                   new SqlParameter("@CRNAME",SqlDbType.VarChar,50),
                   new SqlParameter("@COSTPH",SqlDbType.Money),
                   new SqlParameter("@COSTTIME",SqlDbType.Time),
                   new SqlParameter("@COSTBEGIN",SqlDbType.Money)

               };
                para[0].Value = monthCostRule.CrName;
                para[1].Value = monthCostRule.CostPh;
                para[2].Value = monthCostRule.CostTime;
                para[3].Value = monthCostRule.CostBegin;
                result = SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringShop, CommandType.StoredProcedure, sql, para);
                return result > 0 ? true : false;
            }
            catch (Exception ex)
            {
                except.ExceptionInsert("添加月租扣费规则出错：" + ex.Message, "MonthCostRuleInsert", DateTime.Now);
                return false;
            }

        }
        #endregion

        #region 月租扣费规则更新
        /// <summary>
        /// 月租扣费规则更新
        /// </summary>
        /// <param name="monthCostRule"></param>
        /// <returns></returns>
        public bool MonthCostRuleUpdate(MonthCostRule monthCostRule)
        {
            int result;
            try
            {
                string sql = "MONTH_COST_RULE_UPDATE";
                SqlParameter[] para = new SqlParameter[]
                {
                    new SqlParameter("@CRID",SqlDbType.Int),
                    new SqlParameter("@CRNAME",SqlDbType.VarChar,50),
                    new SqlParameter("@COSTPH",SqlDbType.Money),
                    new SqlParameter("@COSTTIME",SqlDbType.Time),
                    new SqlParameter("@COSTBEGIN",SqlDbType.Money)
                };
                para[0].Value = monthCostRule.CrId;
                para[1].Value = monthCostRule.CrName;
                para[2].Value = monthCostRule.CostPh;
                para[3].Value = monthCostRule.CostTime;
                para[4].Value = monthCostRule.CostBegin;
                result = SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringShop, CommandType.StoredProcedure, sql, para);
                return result > 0 ? true : false;
            }
            catch (Exception ex)
            {
                except.ExceptionInsert("修改月租扣费规则出错：" + ex.Message, "MonthCostRuleUpdate", DateTime.Now);
                return false;
            }
        }
        #endregion

        #region 删除月租扣费规则
        /// <summary>
        /// 删除月租扣费规则
        /// </summary>
        /// <param name="monthCostRule"></param>
        /// <returns></returns>
        public bool MonthCostRuleDelete(MonthCostRule monthCostRule)
        {
            string sql = "MONTH_COST_RULE_DELETE";
            try
            {
                SqlParameter[] para = new SqlParameter[]
                {
                    new SqlParameter("@CRID",SqlDbType.Int)
                };
                para[0].Value = monthCostRule.CrId;
                int result = SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringShop, CommandType.StoredProcedure, sql, para);
                return result > 0 ? true : false;
            }
            catch (Exception ex)
            {
                except.ExceptionInsert("删除月租扣费规则出错：" + ex.Message, "MonthCostRuleDelete", DateTime.Now);
                return false;
            }
        }
        #endregion

        #region 根据CRID获得月租扣费规则
        /// <summary>
        /// 根据CRID获得月租扣费规则
        /// </summary>
        /// <returns></returns>
        public MonthCostRule MonthCostRuleSelectById(MonthCostRule monthCostRule)
        {
            string sql = "MONTH_COST_RULE_SELECT_BY_CRID";
            dt = new DataTable();
            try
            {
                SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@CRID",SqlDbType.Int)
            };
                para[0].Value = monthCostRule.CrId;
                using (SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringShop, CommandType.StoredProcedure, sql, para))
                {
                    dt.Load(dr);
                }
                MonthCostRule monthCostRuleInfo = new MonthCostRule();
                monthCostRuleInfo.CrId = Convert.ToInt32(dt.Rows[0]["CRID"]);
                monthCostRuleInfo.CrName = Convert.ToString(dt.Rows[0]["CRNAME"]);
                monthCostRuleInfo.CostPh = Convert.ToDouble(dt.Rows[0]["COSTPH"]);
                monthCostRuleInfo.CostTime = Convert.ToDateTime(dt.Rows[0]["COSTTIME"]);
                monthCostRuleInfo.CostBegin = Convert.ToDouble(dt.Rows[0]["COSTBEGIN"]);
                return monthCostRuleInfo;
            }
            catch (Exception ex)
            {
                except.ExceptionInsert("查询月租扣费规则出错：" + ex.Message, "MonthCostRuleSelectById", DateTime.Now);
                return null;
            }
        }
        #endregion

        #region 获取所有月租扣费规则
        /// <summary>
        /// 获取所有月租扣费规则
        /// </summary>
        /// <returns></returns>
        public List<MonthCostRule> MonthCostRuleSelect()
        {
            string sql = "MONTH_COST_RULE_SELECT";
            List<MonthCostRule> listMonthCostRule = new List<MonthCostRule>();
            dt = new DataTable();
            try
            {
                using (SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringShop, CommandType.StoredProcedure, sql, null))
                {
                    dt.Load(dr);
                }
                MonthCostRule monthCostRuleTemp;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    monthCostRuleTemp = new MonthCostRule();
                    monthCostRuleTemp.CrId = Convert.ToInt32(dt.Rows[i]["CRID"]);
                    monthCostRuleTemp.CrName = Convert.ToString(dt.Rows[i]["CRNAME"]);
                    monthCostRuleTemp.CostPh = Convert.ToDouble(dt.Rows[i]["COSTPH"]);
                    monthCostRuleTemp.CostTime = Convert.ToDateTime(dt.Rows[i]["COSTTIME"]);
                    monthCostRuleTemp.CostBegin = Convert.ToDouble(dt.Rows[i]["COSTbEGIN"]);
                    listMonthCostRule.Add(monthCostRuleTemp);
                }
                return listMonthCostRule;
            }
            catch (Exception ex)
            {
                except.ExceptionInsert("查询月租扣费规则出错：" + ex.Message, "MonthCostRuleSelect", DateTime.Now);
                return null;
            }
        }
        #endregion
    }
}
