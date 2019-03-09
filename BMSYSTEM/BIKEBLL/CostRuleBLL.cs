using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MODEL;
using BIKEDAL;

namespace BIKEBLL
{
    public class CostRuleBLL
    {
        CostRuleDal costRuleDal;
        public CostRuleBLL()
        {
            costRuleDal = new CostRuleDal();
        }

        #region 日租扣费规则添加
        /// <summary>
        /// 日租扣费规则添加
        /// </summary>
        /// <param name="costRule"></param>
        /// <returns></returns>
        public bool CostRuleInsert(CostRule costRule)
        {
            return costRuleDal.CostRuleInsert(costRule);

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
            return costRuleDal.CostRuleUpdate(costRule);
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
            return costRuleDal.CostRuleDelete(costRule);
        }
        #endregion

        #region 根据CRID获得日租扣费规则
        /// <summary>
        /// 根据CRID获得日租扣费规则
        /// </summary>
        /// <returns></returns>
        public CostRule CostRuleSelectById(CostRule costRule)
        {
            return costRuleDal.CostRuleSelectById(costRule);
        }
        #endregion

        #region 获取所有日租扣费规则
        /// <summary>
        /// 获取所有日租扣费规则
        /// </summary>
        /// <returns></returns>
        public List<CostRule> CostRuleSelect()
        {
            return costRuleDal.CostRuleSelect();
        }
        #endregion

        #region 根据会员等级和租车类型获得扣费规则
        /// <summary>
        /// 根据会员等级和租车类型获得扣费规则
        /// </summary>
        /// <returns></returns>
        public CostRule CostRuleSelectByLevelAndKind(CostRule costRule)
        {
            return costRuleDal.CostRuleSelectByLevelAndKind(costRule);
        }
        #endregion
    }
}
