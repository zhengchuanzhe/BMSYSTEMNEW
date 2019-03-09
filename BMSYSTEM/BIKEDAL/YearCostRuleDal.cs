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
    public class YearCostRuleDal
    {
        DataTable dt;
        ExceptionHelper except;
        public YearCostRuleDal()
        {
            except = new ExceptionHelper();
        }

        #region 年租扣费规则添加
        /// <summary>
        /// 年租扣费规则添加
        /// </summary>
        /// <param name="yearCostRule"></param>
        /// <returns></returns>
        public bool YearCostRuleInsert(YearCostRule yearCostRule)
        {
            int result;
            try
            {
                string sql = "YEAR_COST_RULE_INSERT";
                SqlParameter[] para = new SqlParameter[]
               {
                   new SqlParameter("@CRNAME",SqlDbType.VarChar,50),
                   new SqlParameter("@COSTPH",SqlDbType.Money),
                   new SqlParameter("@COSTTIME",SqlDbType.Time),
                   new SqlParameter("@COSTBEGIN",SqlDbType.Money)

               };
                para[0].Value = yearCostRule.CrName;
                para[1].Value = yearCostRule.CostPh;
                para[2].Value = yearCostRule.CostTime;
                para[3].Value = yearCostRule.CostBegin;
                result = SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringShop, CommandType.StoredProcedure, sql, para);
                return result > 0 ? true : false;
            }
            catch (Exception ex)
            {
                except.ExceptionInsert("添加年租扣费规则出错：" + ex.Message, "YearCostRuleInsert", DateTime.Now);
                return false;
            }

        }
        #endregion

        #region 年租扣费规则更新
        /// <summary>
        /// 年租扣费规则更新
        /// </summary>
        /// <param name="yearCostRule"></param>
        /// <returns></returns>
        public bool YearCostRuleUpdate(YearCostRule yearCostRule)
        {
            int result;
            try
            {
                string sql = "YEAR_COST_RULE_UPDATE";
                SqlParameter[] para = new SqlParameter[]
                {
                    new SqlParameter("@CRID",SqlDbType.Int),
                    new SqlParameter("@CRNAME",SqlDbType.VarChar,50),
                    new SqlParameter("@COSTPH",SqlDbType.Money),
                    new SqlParameter("@COSTTIME",SqlDbType.Time),
                    new SqlParameter("@COSTBEGIN",SqlDbType.Money)
                };
                para[0].Value = yearCostRule.CrId;
                para[1].Value = yearCostRule.CrName;
                para[2].Value = yearCostRule.CostPh;
                para[3].Value = yearCostRule.CostTime;
                para[4].Value = yearCostRule.CostBegin;
                result = SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringShop, CommandType.StoredProcedure, sql, para);
                return result > 0 ? true : false;
            }
            catch (Exception ex)
            {
                except.ExceptionInsert("修改年租扣费规则出错：" + ex.Message, "YearCostRuleUpdate", DateTime.Now);
                return false;
            }
        }
        #endregion

        #region 删除年租扣费规则
        /// <summary>
        /// 删除年租扣费规则
        /// </summary>
        /// <param name="yearCostRule"></param>
        /// <returns></returns>
        public bool YearCostRuleDelete(YearCostRule yearCostRule)
        {
            string sql = "YEAR_COST_RULE_DELETE";
            try
            {
                SqlParameter[] para = new SqlParameter[]
                {
                    new SqlParameter("@CRID",SqlDbType.Int)
                };
                para[0].Value = yearCostRule.CrId;
                int result = SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringShop, CommandType.StoredProcedure, sql, para);
                return result > 0 ? true : false;
            }
            catch (Exception ex)
            {
                except.ExceptionInsert("删除年租扣费规则出错：" + ex.Message, "YearCostRuleDelete", DateTime.Now);
                return false;
            }
        }
        #endregion

        #region 根据CRID获得年租扣费规则
        /// <summary>
        /// 根据CRID获得年租扣费规则
        /// </summary>
        /// <returns></returns>
        public YearCostRule YearCostRuleSelectById(YearCostRule yearCostRule)
        {
            string sql = "YEAR_COST_RULE_SELECT_BY_CRID";
            dt = new DataTable();
            try
            {
                SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@CRID",SqlDbType.Int)
            };
                para[0].Value = yearCostRule.CrId;
                using (SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringShop, CommandType.StoredProcedure, sql, para))
                {
                    dt.Load(dr);
                }
                YearCostRule yearCostRuleInfo = new YearCostRule();
                yearCostRuleInfo.CrId = Convert.ToInt32(dt.Rows[0]["CRID"]);
                yearCostRuleInfo.CrName = Convert.ToString(dt.Rows[0]["CRNAME"]);
                yearCostRuleInfo.CostPh = Convert.ToDouble(dt.Rows[0]["COSTPH"]);
                yearCostRuleInfo.CostTime = Convert.ToDateTime(dt.Rows[0]["COSTTIME"]);
                yearCostRuleInfo.CostBegin = Convert.ToDouble(dt.Rows[0]["COSTBEGIN"]);
                return yearCostRuleInfo;
            }
            catch (Exception ex)
            {
                except.ExceptionInsert("查询年租扣费规则出错：" + ex.Message, "YearCostRuleSelectById", DateTime.Now);
                return null;
            }
        }
        #endregion

        #region 获取所有年租扣费规则
        /// <summary>
        /// 获取所有年租扣费规则
        /// </summary>
        /// <returns></returns>
        public List<YearCostRule> YearCostRuleSelect()
        {
            string sql = "YEAR_COST_RULE_SELECT";
            List<YearCostRule> listYearCostRule = new List<YearCostRule>();
            dt = new DataTable();
            try
            {
                using (SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringShop, CommandType.StoredProcedure, sql, null))
                {
                    dt.Load(dr);
                }
                YearCostRule yearCostRuleTemp;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    yearCostRuleTemp = new YearCostRule();
                    yearCostRuleTemp.CrId = Convert.ToInt32(dt.Rows[i]["CRID"]);
                    yearCostRuleTemp.CrName = Convert.ToString(dt.Rows[i]["CRNAME"]);
                    yearCostRuleTemp.CostPh = Convert.ToDouble(dt.Rows[i]["COSTPH"]);
                    yearCostRuleTemp.CostTime = Convert.ToDateTime(dt.Rows[i]["COSTTIME"]);
                    yearCostRuleTemp.CostBegin = Convert.ToDouble(dt.Rows[i]["COSTbEGIN"]);
                    listYearCostRule.Add(yearCostRuleTemp);
                }
                return listYearCostRule;
            }
            catch (Exception ex)
            {
                except.ExceptionInsert("查询年租扣费规则出错：" + ex.Message, "YearCostRuleSelect", DateTime.Now);
                return null;
            }
        }
        #endregion
    }
}
