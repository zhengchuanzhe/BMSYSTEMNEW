using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MODEL;
using BIKEDAL;

namespace BIKEBLL
{
    public class BikeReturnBLL
    {
        BikeReturnDal bikeReturnDal;
        public BikeReturnBLL()
        {
            bikeReturnDal = new BikeReturnDal();
        }

        #region 还车记录添加
        /// <summary>
        /// 还车记录添加
        /// </summary>
        /// <param name="bikeReturn">还车记录</param>
        /// <returns>若还车数目大于租车数目则返回-2，若还车成功则返回1，若还车不成功则返回-1</returns>
        public int BikeReturnInsert(BikeReturn bikeReturn)
        {
            return bikeReturnDal.BikeReturnInsert(bikeReturn);

        }
        #endregion

        #region 还车记录更新
        /// <summary>
        /// 还车记录更新
        /// </summary>
        /// <param name="bikeReturn"></param>
        /// <returns></returns>
        public bool BikeReturnUpdate(BikeReturn bikeReturn)
        {
            return bikeReturnDal.BikeReturnUpdate(bikeReturn);
        }
        #endregion

        #region 删除还车记录
        /// <summary>
        /// 删除还车记录
        /// </summary>
        /// <param name="bikeReturn"></param>
        /// <returns></returns>
        public bool BikeReturnDelete(BikeReturn bikeReturn)
        {
            return bikeReturnDal.BikeReturnDelete(bikeReturn);
        }
        #endregion

        #region 根据RBKID获得还车记录
        /// <summary>
        /// 根据RBKID获得还车记录
        /// </summary>
        /// <returns></returns>
        public BikeReturn BikeReturnSelectById(BikeReturn bikeReturn)
        {
            BikeReturn bikeReturnTemp = new BikeReturn();
            try
            {
                bikeReturnTemp = bikeReturnDal.BikeReturnSelectById(bikeReturn);
                TimeSpan timeSpan = bikeReturnTemp.BuTime - new DateTime(1900, 1, 1, 0, 0, 0);
                bikeReturnTemp.BuTimeString = timeSpan.Days.ToString() + "天";
                bikeReturnTemp.BuTimeString += timeSpan.Hours.ToString() + "小时";
                bikeReturnTemp.BuTimeString += timeSpan.Minutes.ToString() + "分钟";
                return bikeReturnTemp;
            }
            catch (Exception ex)
            {
                return null;
            }

        }
        #endregion

        #region 根据租车地获得还车信息
        public List<BikeReturn> BikeReturnSelectByDpId(BikeReturn bikeReturn)
        {
            List<BikeReturn> bikeList = new List<BikeReturn>();
            try
            {
                bikeList = bikeReturnDal.BikeReturnSelectByDpId(bikeReturn);
                DateTime timeStart = new DateTime(1900, 1, 1, 0, 0, 0);
                for (int i = 0; i < bikeList.Count; i++)
                {
                    TimeSpan timeSpan = bikeList[i].BuTime - timeStart;
                    bikeList[i].BuTimeString = timeSpan.Days.ToString() + "天" + timeSpan.Hours.ToString() + "小时" + timeSpan.Minutes.ToString() + "分钟";
                }
                return bikeList;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion
        #region 根据会员ID获得还车信息
        public List<BikeReturn> BikeReturnSelectByVipId(BikeReturn bikeReturn)
        {
            List<BikeReturn> bikeList = new List<BikeReturn>();
            try
            {
                bikeList = bikeReturnDal.BikeReturnSelectByVipId(bikeReturn);
                DateTime timeStart = new DateTime(1900, 1, 1, 0, 0, 0);
                for (int i = 0; i < bikeList.Count; i++)
                {
                    TimeSpan timeSpan = bikeList[i].BuTime - timeStart;
                    bikeList[i].BuTimeString = timeSpan.Days.ToString() + "天" + timeSpan.Hours.ToString() + "小时" + timeSpan.Minutes.ToString() + "分钟";
                }
                return bikeList;
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        #endregion


        #region 获取所有还车记录
        /// <summary>
        /// 获取所有还车记录
        /// </summary>
        /// <returns></returns>
        public List<BikeReturn> BikeReturnSelect(DateTime beginTime, DateTime endTime)
        {
            return bikeReturnDal.BikeReturnSelect(beginTime, endTime);
        }
        #endregion

        #region 根据分店和时间段查询该分店租出车辆还车信息
        public List<BikeReturn> BikeReturnSelectByDpIdAndTime(BikeReturn bikeReturn, DateTime startTime, DateTime endTime)
        {
            List<BikeReturn> bikeList = new List<BikeReturn>();
            try
            {
                bikeList = bikeReturnDal.BikeReturnSelectByDpIdAndTime(bikeReturn, startTime, endTime);
                DateTime timeStart = new DateTime(1900, 1, 1, 0, 0, 0);
                for (int i = 0; i < bikeList.Count; i++)
                {
                    TimeSpan timeSpan = bikeList[i].BuTime - timeStart;
                    bikeList[i].BuTimeString = timeSpan.Days.ToString() + "天" + timeSpan.Hours.ToString() + "小时" + timeSpan.Minutes.ToString() + "分钟";
                }
                return bikeList;
            }
            catch (Exception ex)
            {
                return null;
            }

        }



        #endregion
    }
}
