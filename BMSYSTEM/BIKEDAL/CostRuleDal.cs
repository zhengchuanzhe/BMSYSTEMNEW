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
    public class CostRuleDal
    {
        DataTable dt;
        ExceptionHelper except;
        public CostRuleDal()
        {
            except = new ExceptionHelper();
        }


        #region 日租扣费规则添加
        /// <summary>
        /// 日租扣费规则添加
        /// </summary>
        /// <param name="costRule"></param>
        /// <returns></returns>
        public bool CostRuleInsert(CostRule costRule)
        {
            int result;
            try
            {
                string sql = "COST_RULE_INSERT";
                SqlParameter[] para = new SqlParameter[]
               {
                   new SqlParameter("@CRNAME",SqlDbType.VarChar,50),
                   new SqlParameter("@COSTPH",SqlDbType.Money),
                   new SqlParameter("@COSTTIME",SqlDbType.Int),
                   new SqlParameter("@COSTBEGIN",SqlDbType.Money),
                   new SqlParameter("@CRKID",SqlDbType.Int),
                   new SqlParameter("@CONTIME",SqlDbType.Int),
                   new SqlParameter("@LVID",SqlDbType.Int)
               };
                para[0].Value = costRule.CrName;
                para[1].Value = costRule.CostPh;
                para[2].Value = costRule.CostTime;
                para[3].Value = costRule.costBegin;
                para[4].Value = costRule.crKind;
                para[5].Value = costRule.conTime;
                para[6].Value = costRule.LvId;
                result = SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringShop, CommandType.StoredProcedure, sql, para);
                return result > 0 ? true : false;
            }
            catch (Exception ex)
            {
                except.ExceptionInsert("添加日租扣费规则出错：" + ex.Message, "CostRuleInsert", DateTime.Now);
                return false;
            }

        }
        #endregion

        #region 日租扣费规则更新
        /// <summary>
        /// 日租扣费规则更新
        /// </summary>
        /// <param name="costRule"></param>
        /// <returns></returns>
        public bool CostRuleUpdate(CostRule costRule)
        {
            int result;
            try
            {
                string sql = "COST_RULE_UPDATE";
                SqlParameter[] para = new SqlParameter[]
                {
                    new SqlParameter("@CRID",SqlDbType.Int),
                    new SqlParameter("@CRNAME",SqlDbType.VarChar,50),
                    new SqlParameter("@COSTPH",SqlDbType.Money),
                    new SqlParameter("@COSTTIME",SqlDbType.Int),
                    new SqlParameter("@COSTBEGIN",SqlDbType.Money),
                    new SqlParameter("@CRKID",SqlDbType.Int),
                    new SqlParameter("@CONTIME",SqlDbType.Int),
                    new SqlParameter("@LVID",SqlDbType.Int)
                };
                para[0].Value = costRule.CrId;
                para[1].Value = costRule.CrName;
                para[2].Value = costRule.CostPh;
                para[3].Value = costRule.CostTime;
                para[4].Value = costRule.costBegin;
                para[5].Value = costRule.crKind;
                para[6].Value = costRule.conTime;
                para[7].Value = costRule.LvId;
                result = SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringShop, CommandType.StoredProcedure, sql, para);
                return result > 0 ? true : false;
            }
            catch (Exception ex)
            {
                except.ExceptionInsert("修改日租扣费规则出错：" + ex.Message, "CostRuleUpdate", DateTime.Now);
                return false;
            }
        }
        #endregion

        #region 删除日租扣费规则
        /// <summary>
        /// 删除日租扣费规则
        /// </summary>
        /// <param name="costRule"></param>
        /// <returns></returns>
        public bool CostRuleDelete(CostRule costRule)
        {
            string sql = "COST_RULE_DELETE";
            try
            {
                SqlParameter[] para = new SqlParameter[]
                {
                    new SqlParameter("@CRID",SqlDbType.Int)
                };
                para[0].Value = costRule.CrId;
                int result = SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringShop, CommandType.StoredProcedure, sql, para);
                return result > 0 ? true : false;
            }
            catch (Exception ex)
            {
                except.ExceptionInsert("删除日租扣费规则出错：" + ex.Message, "CostRuleDelete", DateTime.Now);
                return false;
            }
        }
        #endregion

        #region 根据CRID获得日租扣费规则
        /// <summary>
        /// 根据CRID获得日租扣费规则
        /// </summary>
        /// <returns></returns>
        public CostRule CostRuleSelectById(CostRule costRule)
        {
            string sql = "COST_RULE_SELECT_BY_CRID";
            dt = new DataTable();
            try
            {
                SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@CRID",SqlDbType.Int)
            };
                para[0].Value = costRule.CrId;
                using (SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringShop, CommandType.StoredProcedure, sql, para))
                {
                    dt.Load(dr);
                }
                CostRule costRuleInfo = new CostRule();
                costRuleInfo.CrId = Convert.ToInt32(dt.Rows[0]["CRID"]);
                costRuleInfo.CrName = Convert.ToString(dt.Rows[0]["CRNAME"]);
                costRuleInfo.CostPh = Convert.ToDouble(dt.Rows[0]["COSTPH"]);
                costRuleInfo.CostTime = Convert.ToInt32(dt.Rows[0]["COSTTIME"]);
                costRuleInfo.costBegin = Convert.ToDouble(dt.Rows[0]["COSTBEGIN"]);
                costRuleInfo.crKind = Convert.ToInt32(dt.Rows[0]["CRKID"]);
                costRuleInfo.conTime = Convert.ToInt32(dt.Rows[0]["CONTIME"]);
                costRuleInfo.LvId = Convert.ToInt32(dt.Rows[0]["LVID"]);
                return costRuleInfo;
            }
            catch (Exception ex)
            {
                except.ExceptionInsert("查询日租扣费规则出错：" + ex.Message, "CostRuleSelectById", DateTime.Now);
                return null;
            }
        }
        #endregion

        #region 根据会员等级和租车类型获得扣费规则
        /// <summary>
        /// 根据会员等级和租车类型获得扣费规则
        /// </summary>
        /// <returns></returns>
        public CostRule CostRuleSelectByLevelAndKind(CostRule costRule)
        {
            string sql = "COST_RULE_SELECT_BY_LEVELANDKIND";
            dt = new DataTable();
            try
            {
                SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@LVID",SqlDbType.Int),
                new SqlParameter("@KIND",SqlDbType.Int),
            };
                para[0].Value = costRule.LvId;
                para[1].Value = costRule.crKind;
                using (SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringShop, CommandType.StoredProcedure, sql, para))
                {
                    dt.Load(dr);
                }
                CostRule costRuleInfo = new CostRule();
                costRuleInfo.CrId = Convert.ToInt32(dt.Rows[0]["CRID"]);
                costRuleInfo.CrName = Convert.ToString(dt.Rows[0]["CRNAME"]);
                costRuleInfo.CostPh = Convert.ToDouble(dt.Rows[0]["COSTPH"]);
                costRuleInfo.CostTime = Convert.ToInt32(dt.Rows[0]["COSTTIME"]);
                costRuleInfo.costBegin = Convert.ToDouble(dt.Rows[0]["COSTBEGIN"]);
                costRuleInfo.crKind = Convert.ToInt32(dt.Rows[0]["CRKID"]);
                costRuleInfo.conTime = Convert.ToInt32(dt.Rows[0]["CONTIME"]);
                costRule.LvId = Convert.ToInt32(dt.Rows[0]["LVID"]);
                return costRuleInfo;
            }
            catch (Exception ex)
            {
                except.ExceptionInsert("查询日租扣费规则出错：" + ex.Message, "CostRuleSelectById", DateTime.Now);
                return null;
            }
        }
        #endregion

        #region 获取所有扣费规则
        /// <summary>
        /// 获取所有日租扣费规则
        /// </summary>
        /// <returns></returns>
        public List<CostRule> CostRuleSelect()
        {
            string sql = "COST_RULE_SELECT";
            List<CostRule> listCostRule = new List<CostRule>();
            dt = new DataTable();
            try
            {
                using (SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringShop, CommandType.StoredProcedure, sql, null))
                {
                    dt.Load(dr);
                }
                CostRule costRuleTemp;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    costRuleTemp = new CostRule();
                    costRuleTemp.CrId = Convert.ToInt32(dt.Rows[i]["CRID"]);
                    costRuleTemp.CrName = Convert.ToString(dt.Rows[i]["CRNAME"]);
                    costRuleTemp.CostPh = Convert.ToDouble(dt.Rows[i]["COSTPH"]);
                    costRuleTemp.CostTime = Convert.ToInt32(dt.Rows[i]["COSTTIME"]);
                    costRuleTemp.costBegin = Convert.ToDouble(dt.Rows[i]["COSTBEGIN"]);
                    costRuleTemp.crKind = Convert.ToInt32(dt.Rows[i]["CRKID"]);
                    costRuleTemp.conTime = Convert.ToInt32(dt.Rows[i]["CONTIME"]);
                    costRuleTemp.LvId = Convert.ToInt32(dt.Rows[i]["LVID"]);
                    listCostRule.Add(costRuleTemp);
                }
                return listCostRule;
            }
            catch (Exception ex)
            {
                except.ExceptionInsert("查询日租扣费规则出错：" + ex.Message, "CostRuleSelect", DateTime.Now);
                return null;
            }
        }
        #endregion


    }
}
