using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BIKECOMMON;
using MODEL;
using BIKEDAL;

namespace BIKEBLL
{
    public class IntegralBLL
    {
        public IntegralDal dal;
        public IntegralBLL()
        {
            dal = new IntegralDal();
        }
        /// <summary>
        /// 获取比例信息
        /// </summary>
        /// <returns></returns>
        public Integral GetIntegralMessage()
        {
            return dal.GetIntegralMessage();
        }
        /// <summary>
        /// 更新比例信息
        /// </summary>
        /// <param name="inte"></param>
        /// <returns></returns>
        public bool UpdateIntegralMessage(Integral inte)
        {
            return dal.UpdateIntegralMessage(inte);
        }
    }
}
