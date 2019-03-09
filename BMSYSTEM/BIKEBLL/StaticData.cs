using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BIKECOMMON;
using MODEL;

namespace BIKEBLL
{
    public static class StaticData
    {
        #region 帮助工具
        private static OtherHelper otherHelper = new OtherHelper();
        private static DepartBLL departBLL = new DepartBLL();
        #endregion
        static StaticData()
        {
            GetDpId();          
        }
        /// <summary>
        /// 获得分店信息
        /// </summary>
        public static void GetDpId()
        {
            string mac = otherHelper.getMacAddrLocal();
            DepartInfo departInfo = new DepartInfo();
            departInfo.DpPCMAC = mac;
            departInfo = departBLL.DepartSelectByMac(departInfo);
            departLocal = departInfo;
        }
        /// <summary>
        /// 当前登陆分店
        /// </summary>
        public static DepartInfo departLocal=new DepartInfo();
        /// <summary>
        /// 当前登陆用户
        /// </summary>
        public static UserInfo userLocal=new UserInfo();

    }
}
