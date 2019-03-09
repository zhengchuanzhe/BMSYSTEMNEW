using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MODEL;
using BIKEDAL;

namespace BIKEBLL
{
    public class DepartYearFormBLL
    {
        DepartYearFormDal departYearFormDal;
        public DepartYearFormBLL()
        {
            departYearFormDal = new DepartYearFormDal();
        }

        #region 根据时间段和分店ID选出分店年收入信息
        public List<DepartYearForm> DepartYearFormSelectByTime(DateTime begintime, DateTime endtime,int dpid)
        {
            return departYearFormDal.DepartYearFormSelectByTime(begintime,endtime,dpid);
        }
        #endregion
    }
}
