using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MODEL;
using BIKEDAL;

namespace BIKEBLL
{
    public class VipNoBorrowBLL
    {
        VipNoBorrowDal vipNoBorrowDal;
        public VipNoBorrowBLL()
        {
            vipNoBorrowDal = new VipNoBorrowDal();
        }

        #region 非会员租车添加
        /// <summary>
        /// 非会员租车添加
        /// </summary>
        /// <param name="vipNoBorrow">非会员租车记录</param>
        /// <param name="bkid">租车类别ID</param>
        /// <returns>若余额不足则返回-2，若添加成功则返回1，若不成功返回-1</returns>
        public int VipNoBorrowInsert(VipNoBorrow vipNoBorrow, int bkid)
        {
            return vipNoBorrowDal.VipNoBorrowInsert(vipNoBorrow, bkid);
        }
        #endregion

        #region 根据非会员ID删除非会员租车
        /// <summary>
        /// 根据非会员ID删除非会员租车
        /// </summary>
        /// <param name="vipNoBorrow"></param>
        /// <returns></returns>
        public bool VipNoBorrowDeleteByVipId(VipNoBorrow vipNoBorrow)
        {
            return vipNoBorrowDal.VipNoBorrowDeleteByVipId(vipNoBorrow);
        }
        #endregion

        #region 根据BBKID删除非会员借车记录
        public bool VipNoBorrowDeleteByBBKId(VipNoBorrow vipNoBorrow)
        {
            return vipNoBorrowDal.VipNoBorrowDeleteByBBKId(vipNoBorrow);
        }
        #endregion

        #region 根据BBKID获得非会员租车信息
        /// <summary>
        /// 根据BBKID获得非会员租车信息
        /// </summary>
        /// <returns></returns>
        public VipNoBorrow VipNoBorrowSelectByBBKId(VipNoBorrow vipNoBorrow)
        {
            return vipNoBorrowDal.VipNoBorrowSelectByBBKId(vipNoBorrow);
        }
        #endregion

        #region 获取所有非会员租车
        /// <summary>
        /// 获取所有非会员租车
        /// </summary>
        /// <returns></returns>
        public List<VipNoBorrow> VipNoBorrowSelect()
        {
            return vipNoBorrowDal.VipNoBorrowSelect();
        }
        #endregion

        #region 根据非会员ID获取租车信息
        public List<VipNoBorrow> VipNoBorrowSelectByVipNoId(int vipId)
        {
            return vipNoBorrowDal.VipNoBorrowSelectByVipNoId(vipId);
        }
        #endregion

        #region 根据非会员ID和时间段获取租车信息
        public List<VipNoBorrow> VipNoBorrowSelectByVipNoIdAndTime(int vipId, DateTime startTime, DateTime endTime)
        {
            return vipNoBorrowDal.VipNoBorrowSelectByVipNoIdAndTime(vipId,startTime,endTime);
        }
        #endregion

        #region 根据分店ID获取租车信息
        public List<VipNoBorrow> VipNoBorrowSelectByDpId(int dpId)
        {
            return vipNoBorrowDal.VipNoBorrowSelectByDpId(dpId);
        }
        #endregion

        #region 根据分店ID获得租车信息已还未还都有
        public List<VipNoBorrow> VipNoBorrowSelectAllByDpId(int dpId)
        {
            return vipNoBorrowDal.VipNoBorrowSelectAllByDpId(dpId);
        }
        #endregion

        #region 根据分店ID和时间段获取租车信息
        /// <summary>
        /// 值查未还的
        /// </summary>
        /// <param name="dpId"></param>
        /// <returns></returns>
        public List<VipNoBorrow> VipNoBorrowSelectByDpIdAndTime(int dpId, DateTime startTime, DateTime endTime)
        {
            return vipNoBorrowDal.VipNoBorrowSelectByDpIdAndTime(dpId,startTime,endTime);
        }
        #endregion
        
        #region 根据分店ID和时间段获得该分店下租车信息，已还未还都查出来
        /// <summary>
        /// 已还未还都查出来
        /// </summary>
        /// <param name="dpId"></param>
        /// <returns></returns>
        public List<VipNoBorrow> VipNoBorrowSelectAllByDpIdAndTime(int dpId, DateTime startTime, DateTime endTime)
        {
            return vipNoBorrowDal.VipNoBorrowSelectAllByDpIdAndTime(dpId,startTime,endTime);
        }


        #endregion

        #region 非会员更改租车备注
        public bool vipNoMarkUpdate(string BBID, string MARK)
        {
            return vipNoBorrowDal.vipNoMarkUpdate(BBID, MARK);
        }
        #endregion
    }
}
