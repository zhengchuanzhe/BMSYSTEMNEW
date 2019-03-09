using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MODEL;
using BIKEDAL;

namespace BIKEBLL
{
    public class VipYearFormBLL
    {
        VipYearFormDal vipYearFormDal;
        public VipYearFormBLL()
        {
            vipYearFormDal = new VipYearFormDal();
        }

        #region 根据时间段选出会员消费年报表
        public List<VipYearForm> VipYearFormSelectByTime(DateTime begintime, DateTime endtime,int dpid)
        {
            return vipYearFormDal.VipYearFormSelectByTime(begintime,endtime,dpid);
        }
        #endregion
    }
}
