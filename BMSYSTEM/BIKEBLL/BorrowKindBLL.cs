using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MODEL;
using BIKEDAL;

namespace BIKEBLL
{
    public class BorrowKindBLL
    {
        BorrowKindDal borrowKindDal;
        public BorrowKindBLL()
        {
            borrowKindDal = new BorrowKindDal();
        }

        #region 租车类型添加
        /// <summary>
        /// 租车类型添加
        /// </summary>
        /// <param name="borrowKind"></param>
        /// <returns></returns>
        public bool BorrowKindInsert(BorrowKind borrowKind)
        {
            return borrowKindDal.BorrowKindInsert(borrowKind);
        }
        #endregion

        #region 租车类型更新
        /// <summary>
        /// 租车类型更新
        /// </summary>
        /// <param name="borrowKind"></param>
        /// <returns></returns>
        public bool BorrowKindUpdate(BorrowKind borrowKind)
        {
            return borrowKindDal.BorrowKindUpdate(borrowKind);
        }
        #endregion

        #region 删除租车类型
        /// <summary>
        /// 删除租车类型
        /// </summary>
        /// <param name="borrowKind"></param>
        /// <returns></returns>
        public bool BorrowKindDelete(BorrowKind borrowKind)
        {
            return borrowKindDal.BorrowKindDelete(borrowKind);
        }
        #endregion

        #region 根据BKID获得租车类型
        /// <summary>
        /// 根据BKID获得租车类型
        /// </summary>
        /// <returns></returns>
        public BorrowKind BorrowKindSelectById(BorrowKind borrowKind)
        {
            return borrowKindDal.BorrowKindSelectById(borrowKind);
        }
        #endregion

        #region 获取所有租车类型
        /// <summary>
        /// 获取所有租车类型
        /// </summary>
        /// <returns></returns>
        public List<BorrowKind> BorrowKindSelect()
        {
            return borrowKindDal.BorrowKindSelect();
        }
        #endregion
    }
}
