using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MODEL;
using BIKEDAL;

namespace BIKEBLL
{
    public class DepartMonthFormBLL
    {
        DepartMonthFormDal departMonthFormDal;
        public DepartMonthFormBLL()
        {
            departMonthFormDal = new DepartMonthFormDal();
        }

        #region 根据时间段选出分店月收入信息
        public List<DepartMonthForm> DepartMonthFormSelectByTime(DateTime begintime, DateTime endtime,int dpid)
        {
            return departMonthFormDal.DepartMonthFormSelectByTime(begintime,endtime,dpid);
        }
        #endregion
    }
}
