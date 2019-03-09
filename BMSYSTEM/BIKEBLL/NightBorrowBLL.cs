using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MODEL;
using BIKEDAL;

namespace BIKEBLL
{
    /// <summary>
    /// 包夜扣费规则管理实体类
    /// </summary>
    public  class NightBorrowBLL
    {
        NightBorrowDal nightBorrowDal;
        public NightBorrowBLL()
        {
            nightBorrowDal = new NightBorrowDal();
        }


        #region 包夜扣费规则修改
        /// <summary>
        /// 包夜扣费规则修改
        /// </summary>
        /// <param name="NB"></param>
        /// <returns></returns>
        public bool RuleUpdate(NightBorrow NB)
        {
            return nightBorrowDal.RuleUpdate(NB);
        }
        #endregion

        #region 取出包夜扣费规则
        /// <summary>
        /// 取出包夜扣费规则
        /// </summary>
        /// <param name="id">扣费规则ID</param>
        /// <returns></returns>
        public NightBorrow nightBorrowSelect(string id)
        {
            return nightBorrowDal.nightBorrowSelect(id);
        }
        #endregion

    }
}
