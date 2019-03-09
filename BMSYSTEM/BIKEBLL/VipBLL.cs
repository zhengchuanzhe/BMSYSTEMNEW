using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MODEL;
using BIKEDAL;

namespace BIKEBLL
{
    public class VipBLL
    {
        VipDal vipDal;
        public VipBLL()
        {
            vipDal = new VipDal();
        }


        #region 根据VIP的卡号判断是否已存在
        /// <summary>
        /// 根据VIP的卡号判断是否已存在
        /// </summary>
        /// <param name="VipNumber">会员卡号</param>
        /// <returns></returns>
        public bool IsExistVip(string VipNumber)
        {
           return  vipDal.IsExistVip(VipNumber );
        }
        #endregion

        #region VIP添加
        /// <summary>
        /// VIP添加
        /// </summary>
        /// <param name="vip"></param>
        /// <returns></returns>
        public bool VipInsert(VIPInfo vip,double money)
        {
            return vipDal.VipInsert(vip,money );

        }
        #endregion

        #region VIP更新
        /// <summary>
        /// VIP更新
        /// </summary>
        /// <param name="vip"></param>
        /// <returns></returns>
        public bool VipUpdate(VIPInfo vip)
        {
            return vipDal.VipUpdate(vip);
        }
        #endregion

        #region 删除VIP信息
        /// <summary>
        /// 删除VIP信息
        /// </summary>
        /// <param name="vip"></param>
        /// <returns></returns>
        public bool VipDelete(VIPInfo vip)
        {
            return vipDal.VipDelete(vip);
        }
        #endregion

        #region 根据VIPID获得VIP基本信息
        /// <summary>
        /// 根据VIPID获得VIP基本信息
        /// </summary>
        /// <returns></returns>
        public VIPInfo VipSelectById(VIPInfo vip)
        {
            return vipDal.VipSelectById(vip);
        }
        #endregion

        #region 根据VIPID获得VIP照片
        /// <summary>
        /// 根据VIPID获得VIP照片
        /// </summary>
        /// <returns></returns>
        public byte[] VipPhotoSelectById(VIPInfo vip)
        {
            return vipDal.VipPhotoSelectById(vip); 
        }
        #endregion

        #region 主页根据VIPID获得VIP基本信息
        /// <summary>
        /// 根据VIPID获得VIP基本信息
        /// </summary>
        /// <returns></returns>
        public VIPInfo VipSelectById_MainPage(VIPInfo vip)
        {
            return vipDal.VipSelectById_MainPage(vip);
        }
        #endregion

        #region 获取所有VIP信息
        /// <summary>
        /// 获取所有VIP信息
        /// </summary>
        /// <returns></returns>
        public List<VIPInfo> VipSelect()
        {
            return vipDal.VipSelect();
        }
        #endregion

        #region 根据分店ID获得该分店下的VIP列表
        /// <summary>
        /// 根据分店ID获得该分店下的VIP列表
        /// </summary>
        /// <param name="dpId"></param>
        /// <returns></returns>
        public List<VIPInfo> VipSelectByDpId(int dpId)
        {
            return vipDal.VipSelectByDpId(dpId);
        }
        #endregion

        #region 根据VIP名称搜索用户列表
        /// <summary>
        ///根据VIP名称搜索用户列表
        /// </summary>
        /// <param name="vipName">Vip名称</param>
        /// <returns></returns>
        public List<VIPInfo> VipSelectByName(string vipName)
        {
            return vipDal.VipSelectByName(vipName);
        }
        #endregion

        #region 根据会员卡号获得VIP基本信息
        /// <summary>
        /// 根据会员卡号获得VIP基本信息
        /// </summary>
        /// <param name="vip">会员卡号</param>
        /// <returns></returns>
        public VIPInfo VipSelectByCardNumber(string  vipCard)
        {
            return vipDal.VipSelectByCardNumber(vipCard);
        }
        #endregion

        #region 验证用户信息
        /// <summary>
        /// 验证用户信息
        /// </summary>
        /// <param name="vip"></param>
        /// <returns></returns>
        public VIPInfo VipCheck(VIPInfo vip)
        {
            return vipDal.VipCheck(vip);
        }
        #endregion

        #region 查询新建VIP列表
        /// <summary>
        /// 查询新建VIP列表
        /// </summary>
        /// <param name="dpId"></param>
        /// <returns></returns>
        public List<VIPInfo> GetNewVipList(int dpId, DateTime beginTime, DateTime endTime)
        {
            return vipDal.GetNewVipList(dpId,beginTime ,endTime );
        }
        #endregion
     
    }
}
