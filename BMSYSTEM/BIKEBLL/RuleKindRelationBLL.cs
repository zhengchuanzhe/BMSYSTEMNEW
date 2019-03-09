using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MODEL;
using BIKEDAL;

namespace BIKEBLL
{
    public class RuleKindRelationBLL
    {
        RuleKindRelationDal ruleKindRelationDal;
        public RuleKindRelationBLL()
        {
            ruleKindRelationDal = new RuleKindRelationDal();
        }

        #region 租车类型与扣费规则之间的关系添加
        /// <summary>
        /// 租车类型与扣费规则之间的关系添加
        /// </summary>
        /// <param name="ruleKindRelation"></param>
        /// <returns></returns>
        public bool RuleKindRelationInsert(RuleKindRelation ruleKindRelation)
        {
            return ruleKindRelationDal.RuleKindRelationInsert(ruleKindRelation);

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
            return ruleKindRelationDal.RuleKindRelationUpdate(ruleKindRelation);
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
            return ruleKindRelationDal.RuleKindRelationDelete(ruleKindRelation);
        }
        #endregion

        #region 根据CRID获得租车类型与扣费规则之间的关系
        /// <summary>
        /// 根据CRID获得租车类型与扣费规则之间的关系
        /// </summary>
        /// <returns></returns>
        public RuleKindRelation RuleKindRelationSelectById(RuleKindRelation ruleKindRelation)
        {
            return ruleKindRelationDal.RuleKindRelationSelectById(ruleKindRelation);
        }
        #endregion

        #region 获取所有租车类型与扣费规则之间的关系
        /// <summary>
        /// 获取所有租车类型与扣费规则之间的关系
        /// </summary>
        /// <returns></returns>
        public List<RuleKindRelation> RuleKindRelationSelect()
        {
            return ruleKindRelationDal.RuleKindRelationSelect();
        }
        #endregion
    }
}
