using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MODEL;
using BIKEDAL;

namespace BIKEBLL
{
    public class DepartBLL
    {
        DepartDal departDal;
        public DepartBLL()
        {
            departDal = new DepartDal();
        }

        #region 分店添加
        /// <summary>
        /// 分店添加
        /// </summary>
        /// <param name="depart"></param>
        /// <returns></returns>
        public bool DepartInsert(DepartInfo depart)
        {
            return departDal.DepartInsert(depart);

        }
        #endregion

        #region 分店更新
        /// <summary>
        /// 分店更新
        /// </summary>
        /// <param name="depart"></param>
        /// <returns></returns>
        public bool DepartUpdate(DepartInfo depart)
        {
            return departDal.DepartUpdate(depart);
        }
        #endregion

        #region 删除分店
        /// <summary>
        /// 删除分店
        /// </summary>
        /// <param name="depart"></param>
        /// <returns></returns>
        public bool DepartDelete(DepartInfo depart)
        {
            return departDal.DepartDelete(depart);
        }
        #endregion

        #region 根据CRID获得分店
        /// <summary>
        /// 根据CRID获得分店
        /// </summary>
        /// <returns></returns>
        public DepartInfo DepartSelectById(DepartInfo depart)
        {
            return departDal.DepartSelectById(depart);
        }
        #endregion

        #region 获取所有分店
        /// <summary>
        /// 获取所有分店
        /// </summary>
        /// <returns></returns>
        public List<DepartInfo> DepartSelect()
        {
            return departDal.DepartSelect();
        }

        public DataTable DepartSelectTable()
        {
            return departDal.DepartSelectTable();
        }
        #endregion

        #region 根据物理地址获得分店
        /// <summary>
        /// 根据CRID获得分店
        /// </summary>
        /// <returns></returns>
        public DepartInfo DepartSelectByMac(DepartInfo depart)
        {
            return departDal.DepartSelectByMac(depart);
        }
        #endregion
    }
}
