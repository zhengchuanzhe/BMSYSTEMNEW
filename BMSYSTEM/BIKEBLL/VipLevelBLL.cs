using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MODEL;
using BIKEDAL;

namespace BIKEBLL
{
    public class VipLevelBLL
    {
        VipLevelDal vipLevelDal;
        public VipLevelBLL()
        {
            vipLevelDal = new VipLevelDal();
        }

        #region 会员等级添加
        /// <summary>
        /// 会员等级添加
        /// </summary>
        /// <param name="vipLevel"></param>
        /// <returns></returns>
        public bool VipLevelInsert(VipLevelInfo vipLevel)
        {
            return vipLevelDal.VipLevelInsert(vipLevel);

        }
        #endregion

        #region 会员等级更新
        /// <summary>
        /// 会员等级更新
        /// </summary>
        /// <param name="vipLevel"></param>
        /// <returns></returns>
        public bool VipLevelUpdate(VipLevelInfo vipLevel)
        {
            return vipLevelDal.VipLevelUpdate(vipLevel);
        }
        #endregion

        #region 删除会员等级
        /// <summary>
        /// 删除会员等级
        /// </summary>
        /// <param name="vipLevel"></param>
        /// <returns></returns>
        public bool VipLevelDelete(VipLevelInfo vipLevel)
        {
            return vipLevelDal.VipLevelDelete(vipLevel);
        }
        #endregion

        #region 根据LVID获得会员等级
        /// <summary>
        /// 根据LVID获得会员等级
        /// </summary>
        /// <returns></returns>
        public VipLevelInfo VipLevelSelectById(VipLevelInfo vipLevel)
        {
            return vipLevelDal.VipLevelSelectById(vipLevel);
        }
        #endregion

        #region 获取所有会员等级
        /// <summary>
        /// 获取所有会员等级
        /// </summary>
        /// <returns></returns>
        public List<VipLevelInfo> VipLevelSelect()
        {
            return vipLevelDal.VipLevelSelect();
        }
        #endregion

        #region 根据LVNAME获得会员等级
        /// <summary>
        /// 根据LVNAME获得会员等级
        /// </summary>
        /// <returns></returns>
        public VipLevelInfo VipLevelSelectByLVName(VipLevelInfo vipLevel)
        {
            return vipLevelDal.VipLevelSelectByLVName(vipLevel);
        }
        #endregion
        /// <summary>
        /// 根据ISVIP获得会员等级列表
        /// </summary>
        /// <param name="isVip"></param>
        /// <returns></returns>
        public List<VipLevelInfo> VipLevelSelectByIsVip(bool isVip)
        {
            return vipLevelDal.VipLevelSelectByIsVip(isVip);
        }
    }
}
