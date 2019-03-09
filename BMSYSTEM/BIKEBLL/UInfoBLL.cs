using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MODEL;
using BIKEDAL;

namespace BIKEBLL
{
    public class UInfoBLL
    {
        UInfoDal uInfoDal;
        public UInfoBLL()
        {
            uInfoDal = new UInfoDal();
        }

        #region U盾添加
        /// <summary>
        /// U盾添加
        /// </summary>
        /// <param name="depart"></param>
        /// <returns></returns>
        public bool UInfoInsert(UInfo uInfo)
        {
            return uInfoDal.UInfoInsert(uInfo);

        }
        #endregion

        #region U盾更新
        /// <summary>
        /// U盾更新
        /// </summary>
        /// <param name="uInfo"></param>
        /// <returns></returns>
        public bool UInfoUpdate(UInfo uInfo)
        {
            return uInfoDal.UInfoUpdate(uInfo);
        }
        #endregion

        #region 删除U盾
        /// <summary>
        /// 删除U盾
        /// </summary>
        /// <param name="uInfo"></param>
        /// <returns></returns>
        public bool UInfoDelete(UInfo uInfo)
        {
            return uInfoDal.UInfoDelete(uInfo);
        }
        #endregion

        #region 根据UID获得U盾
        /// <summary>
        /// 根据CRID获得U盾
        /// </summary>
        /// <returns></returns>
        public UInfo UInfoSelectById(UInfo uInfo)
        {
            return uInfoDal.UInfoSelectById(uInfo);
        }
        #endregion

        #region 获取所有U盾
        /// <summary>
        /// 获取所有U盾
        /// </summary>
        /// <returns></returns>
        public List<UInfo> UInfoSelect()
        {
            return uInfoDal.UInfoSelect();
        }
        #endregion

        #region 根据U顿信息获得它的表示
        public UInfo GetUInfoByMessage(UInfo uInfo)
        {
            return uInfoDal.GetUInfoByUMessage(uInfo);
        }

        #endregion
    }
}
