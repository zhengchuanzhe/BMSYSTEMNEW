using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using BIKECOMMON;
using MODEL;

namespace BIKEDAL
{
    public class RuleKindRelationDal
    {
        ExceptionHelper except;
        DataTable dt;

        public RuleKindRelationDal()
        {
            except = new ExceptionHelper();
        }

        #region 租车类型与扣费规则之间的关系添加
        /// <summary>
        /// 租车类型与扣费规则之间的关系添加
        /// </summary>
        /// <param name="ruleKindRelation"></param>
        /// <returns></returns>
        public bool RuleKindRelationInsert(RuleKindRelation ruleKindRelation)
        {
            int result;
            try
            {
                string sql = "RULE_KIND_RELATION_INSERT";
                SqlParameter[] para = new SqlParameter[]
               {
                   new SqlParameter("@LVID",SqlDbType.Int),
                   new SqlParameter("@BRKID",SqlDbType.Int),
                   new SqlParameter("@RUID",SqlDbType.Int)
               };
                para[0].Value = ruleKindRelation.LvId;
                para[1].Value = ruleKindRelation.BrkId;
                para[2].Value = ruleKindRelation.RuId;
                result = SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringShop, CommandType.StoredProcedure, sql, para);
                return result > 0 ? true : false;
            }
            catch (Exception ex)
            {
                except.ExceptionInsert("添加租车类型与扣费规则之间的关系出错：" + ex.Message, "RuleKindRelationInsert", DateTime.Now);
                return false;
            }

        }
        #endregion

        #region 租车类型与扣费规则之间的关系更新
        /// <summary>
        /// 租车类型与扣费规则之间的关系更新
        /// </summary>
        /// <param name="ruleKindRelation"></param>
        /// <returns></returns>
        public bool RuleKindRelationUpdate(RuleKindRelation ruleKindRelation)
        {
            int result;
            try
            {
                string sql = "RULE_KIND_RELATION_UPDATE";
                SqlParameter[] para = new SqlParameter[]
                {
                    new SqlParameter("@RKRID",SqlDbType.Int),
                    new SqlParameter("@LVID",SqlDbType.VarChar,50),
                    new SqlParameter("@BRKID",SqlDbType.VarChar,200),
                    new SqlParameter("@RUID",SqlDbType.VarChar,50)
                };
                para[0].Value = ruleKindRelation.RkrId;
                para[1].Value = ruleKindRelation.LvId;
                para[2].Value = ruleKindRelation.BrkId;
                para[3].Value = ruleKindRelation.RuId;
                result = SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringShop, CommandType.StoredProcedure, sql, para);
                return result > 0 ? true : false;
            }
            catch (Exception ex)
            {
                except.ExceptionInsert("修改租车类型与扣费规则之间的关系出错：" + ex.Message, "RuleKindRelationUpdate", DateTime.Now);
                return false;
            }
        }
        #endregion

        #region 删除租车类型与扣费规则之间的关系
        /// <summary>
        /// 删除租车类型与扣费规则之间的关系
        /// </summary>
        /// <param name="ruleKindRelation"></param>
        /// <returns></returns>
        public bool RuleKindRelationDelete(RuleKindRelation ruleKindRelation)
        {
            string sql = "RULE_KIND_RELATION_DELETE";
            try
            {
                SqlParameter[] para = new SqlParameter[]
                {
                    new SqlParameter("@RKRID",SqlDbType.Int)
                };
                para[0].Value = ruleKindRelation.RkrId;
                int result = SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringShop, CommandType.StoredProcedure, sql, para);
                return result > 0 ? true : false;
            }
            catch (Exception ex)
            {
                except.ExceptionInsert("删除租车类型与扣费规则之间的关系出错：" + ex.Message, "RuleKindRelationDelete", DateTime.Now);
                return false;
            }
        }
        #endregion

        #region 根据CRID获得租车类型与扣费规则之间的关系
        /// <summary>
        /// 根据CRID获得租车类型与扣费规则之间的关系
        /// </summary>
        /// <returns></returns>
        public RuleKindRelation RuleKindRelationSelectById(RuleKindRelation ruleKindRelation)
        {
            string sql = "RULE_KIND_RELATION_SELECT_BY_DPID";
            dt = new DataTable();
            try
            {
                SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@RKRID",SqlDbType.Int)
            };
                para[0].Value = ruleKindRelation.RkrId;
                using (SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringShop, CommandType.StoredProcedure, sql, para))
                {
                    dt.Load(dr);
                }
                RuleKindRelation ruleKindRelationInfo = new RuleKindRelation();
                ruleKindRelationInfo.RkrId = Convert.ToInt32(dt.Rows[0]["RKRID"]);
                ruleKindRelationInfo.LvId = Convert.ToInt32(dt.Rows[0]["LVID"]);
                ruleKindRelationInfo.BrkId = Convert.ToInt32(dt.Rows[0]["BRKID"]);
                ruleKindRelationInfo.RuId = Convert.ToInt32(dt.Rows[0]["RUID"]);
                return ruleKindRelationInfo;
            }
            catch (Exception ex)
            {
                except.ExceptionInsert("查询租车类型与扣费规则之间的关系出错：" + ex.Message, "RuleKindRelationSelectById", DateTime.Now);
                return null;
            }
        }
        #endregion

        #region 获取所有租车类型与扣费规则之间的关系
        /// <summary>
        /// 获取所有租车类型与扣费规则之间的关系
        /// </summary>
        /// <returns></returns>
        public List<RuleKindRelation> RuleKindRelationSelect()
        {
            string sql = "RULE_KIND_RELATION_SELECT";
            List<RuleKindRelation> listRuleKindRelation = new List<RuleKindRelation>();
            dt = new DataTable();
            try
            {
                using (SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringShop, CommandType.StoredProcedure, sql, null))
                {
                    dt.Load(dr);
                }
                RuleKindRelation ruleKindRelationTemp;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    ruleKindRelationTemp = new RuleKindRelation();
                    ruleKindRelationTemp.RkrId = Convert.ToInt32(dt.Rows[i]["RKRID"]);
                    ruleKindRelationTemp.LvId = Convert.ToInt32(dt.Rows[i]["LVID"]);
                    ruleKindRelationTemp.BrkId = Convert.ToInt32(dt.Rows[i]["BRKID"]);
                    ruleKindRelationTemp.RuId = Convert.ToInt32(dt.Rows[i]["RUID"]);
                    listRuleKindRelation.Add(ruleKindRelationTemp);
                }
                return listRuleKindRelation;
            }
            catch (Exception ex)
            {
                except.ExceptionInsert("查询租车类型与扣费规则之间的关系出错：" + ex.Message, "RuleKindRelationSelect", DateTime.Now);
                return null;
            }
        }
        #endregion
    }
}
