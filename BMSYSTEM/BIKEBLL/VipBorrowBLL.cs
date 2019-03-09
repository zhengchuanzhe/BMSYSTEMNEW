using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MODEL;
using BIKEDAL;

namespace BIKEBLL
{
    public class VipBorrowBLL
    {
        VipBorrowDal vipBorrowDal;
        public VipBorrowBLL()
        {
            vipBorrowDal = new VipBorrowDal();
        }

        #region 会员租车添加
        /// <summary>
        /// 会员租车添加
        /// </summary>
        /// <param name="vipBorrow">租车记录</param>
        /// <param name="bkid">租车类型ID</param>
        /// <returns>若余额不足返回-2，若租车成功返回1，若租车不成功返回-1</returns>
        public int VipBorrowInsert(VipBorrowInfo vipBorrow, int bkid)
        {
            return vipBorrowDal.VipBorrowInsert(vipBorrow, bkid);
        }
        #endregion

        #region 删除会员租车
        /// <summary>
        /// 删除会员租车
        /// </summary>
        /// <param name="vipBorrow"></param>
        /// <returns></returns>
        public bool VipBorrowDelete(VipBorrowInfo vipBorrow)
        {
            return vipBorrowDal.VipBorrowDelete(vipBorrow);
        }
        #endregion

        #region 根据BBKID获得会员租车信息
        /// <summary>
        /// 根据BBKID获得会员租车信息
        /// </summary>
        /// <returns></returns>
        public VipBorrowInfo VipBorrowSelectById(VipBorrowInfo vipBorrow)
        {
            return vipBorrowDal.VipBorrowSelectById(vipBorrow);
        }
        #endregion

        #region 获取所有会员租车
        /// <summary>
        /// 获取所有会员租车
        /// </summary>
        /// <returns></returns>
        public List<VipBorrowInfo> VipBorrowSelect()
        {
            return vipBorrowDal.VipBorrowSelect();
        }
        #endregion

        #region 根据会员ID获取租车信息
        public List<VipBorrowInfo> VipBorrowSelectByVipId(int vipId)
        {
            return vipBorrowDal.VipBorrowSelectByVipId(vipId);
        }
        #endregion

        #region 根据会员ID和时间段获取租车信息
        public List<VipBorrowInfo> VipBorrowSelectByVipIdAndTime(int vipId, DateTime startTime, DateTime endTime)
        {
            return vipBorrowDal.VipBorrowSelectByVipIAndTime(vipId,startTime,endTime);
        }
        #endregion

        #region 根据会员ID获得该会员未还租车信息

        public List<VipBorrowInfo> VipBorrowUnReturnByVipId(int vipId)
        {
            return vipBorrowDal.VipBorrowUnreturnByVipId(vipId);
        }

        #endregion

        #region 根据分店ID获取租车信息
        public List<VipBorrowInfo> VipBorrowSelectByDpId(int dpId)
        {
            return vipBorrowDal.VipBorrowSelectByDpId(dpId);
        }
        #endregion

        #region 根据分店ID获得该分店下租出去的车辆信息
        public List<VipBorrowInfo> VipBorrowSelectAllByDpId(int dpid)
        {
            return vipBorrowDal.VipBorrowSelectAllByDpId(dpid);
        }

        #endregion

        #region 根据分店ID和时间段获得租车信息(已还，未还)都有
        public List<VipBorrowInfo> VipBorrowSelectAllByDpIdAndTime(int dpId, DateTime startTime, DateTime endTime)
        {
            return vipBorrowDal.VipBorrowSelectAllByDpIdAndTime(dpId,startTime,endTime);
        }
        #endregion

        #region 根据分店ID和时间段获取租车信息(未还)
        public List<VipBorrowInfo> VipBorrowSelectByDpIdAndTime(int dpId, DateTime startTime, DateTime endTime)
        {
            return vipBorrowDal.VipBorrowSelectByDpIdAndTime(dpId,startTime,endTime);
        }
        #endregion

        #region 会员更改租车备注
        /// <summary>
        /// 会员更改租车备注
        /// </summary>
        /// <param name="BBID">租车ID</param>
        /// <param name="MARK">备注</param>
        /// <returns></returns>
        public bool vipMarkUpdate(string BBID, string MARK)
        {
            return vipBorrowDal.vipMarkUpdate(BBID, MARK);
        }
        #endregion

        #region 转为包夜功能
        /// <summary>
        /// 转为包夜功能
        /// </summary>
        /// <param name="BBID">租车id</param>
        /// <param name="isVip">是否为会员</param>
        /// <returns></returns>
        public bool nightBorrow(VipBorrowInfo vipBorrowTemp)
        {
            return vipBorrowDal.nightBorrow(vipBorrowTemp .BbkId.ToString () ,true );
        }

        /// <summary>
        /// 转为包夜功能
        /// </summary>
        /// <param name="BBID">租车id</param>
        /// <param name="isVip">是否为会员</param>
        /// <returns></returns>
        public bool nightBorrow(VipNoBorrow vipNoBorrow)
        {
            return vipBorrowDal.nightBorrow(vipNoBorrow.BbkId.ToString(), false );
        }
        #endregion

        #region 取消包夜功能
        /// <summary>
        /// 取消包夜功能
        /// </summary>
        /// <param name="BBID">租车ID</param>
        /// <param name="isVip">是否为会员</param>
        /// <returns></returns>
        public bool notNightBorrow(VipBorrowInfo vipBorrowTemp)
        {
            return vipBorrowDal.notNightBorrow(vipBorrowTemp.BbkId.ToString(), true);
        }

        /// <summary>
        /// 取消包夜功能
        /// </summary>
        /// <param name="BBID">租车ID</param>
        /// <param name="isVip">是否为会员</param>
        /// <returns></returns>
        public bool notNightBorrow(VipNoBorrow vipNoBorrow)
        {
            return vipBorrowDal.notNightBorrow(vipNoBorrow.BbkId.ToString(), false );
        }
        #endregion

    }
}
