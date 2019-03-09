using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MODEL;
using BIKEDAL;

namespace BIKEBLL
{
    public class VipNoBLL
    {
        VipNoDal vipNoDal;
        public VipNoBLL()
        {
            vipNoDal = new VipNoDal();
        }

        #region 非会员添加
        /// <summary>
        /// 非会员添加
        /// </summary>
        /// <param name="vipNo"></param>
        /// <returns></returns>
        public bool VipNoInsert(VipNoInfo vipNo)
        {
            return vipNoDal.VipNoInsert(vipNo);

        }
        #endregion

        #region 非会员更新
        /// <summary>
        /// 非会员更新
        /// </summary>
        /// <param name="vipNo"></param>
        /// <returns></returns>
        public bool VipNoUpdate(VipNoInfo vipNo)
        {
            return vipNoDal.VipNoUpdate(vipNo);
        }
        #endregion

        #region 删除非会员
        /// <summary>
        /// 删除非会员
        /// </summary>
        /// <param name="vipNo"></param>
        /// <returns></returns>
        public bool VipNoDelete(VipNoInfo vipNo)
        {
            return vipNoDal.VipNoDelete(vipNo);
        }
        #endregion

        #region 根据VIPID获得非会员
        /// <summary>
        /// 根据VIPID获得非会员
        /// </summary>
        /// <returns></returns>
        public VipNoInfo VipNoSelectByVIPNoId(VipNoInfo vipNo)
        {
            return vipNoDal.VipNoSelectByVIPNoId(vipNo);
        }
        #endregion

        #region 根据分店Id获取非会员
        public List<VipNoInfo> VipNoSelectByDPId(VipNoInfo vipNo)
        {
            return vipNoDal.VipNoSelectByDPId(vipNo);
        }
        #endregion

        #region 根据根据非会员名称获取非会员列表
        /// <summary>
        /// 根据根据非会员名称获取非会员列表
        /// </summary>
        /// <param name="VipNoName">非会员名称</param>
        /// <returns></returns>
        public List<VipNoInfo> VipNoSelectByVipNoName(string VipNoName)
        {
            return vipNoDal.VipNoSelectByVipNoName(VipNoName );
        }
        #endregion

        #region 获取所有非会员
        /// <summary>
        /// 获取所有非会员
        /// </summary>
        /// <returns></returns>
        public List<VipNoInfo> VipNoSelect()
        {
            return vipNoDal.VipNoSelect();
        }
        #endregion

        #region 根据卡号判断非会员是否存在
        /// <summary>
        /// 根据卡号判断非会员是否存在
        /// </summary>
        /// <param name="vipNo">非会员卡号</param>
        /// <returns>存在为true，不存在未false</returns>
        public bool IsExistByNumber(string vipNumber)
        {
            return vipNoDal.IsExistByNumber(vipNumber);
        }
        #endregion

        #region 根据卡号获得非会员
        /// <summary>
        /// 根据卡号获得非会员
        /// </summary>
        /// <returns></returns>
        public VipNoInfo VipNoSelectByVIPNoNumber(string vipNoNumber)
        {
            return vipNoDal.VipNoSelectByVIPNoNumber(vipNoNumber);
        }
        #endregion

        #region 验证非会员密码是否正确
        public VipNoInfo VipNoCheck(VipNoInfo vipNo)
        {
            return vipNoDal.VipNoCheck(vipNo);
        }
        #endregion
    }
}
