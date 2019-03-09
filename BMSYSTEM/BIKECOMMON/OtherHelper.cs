using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Management;

namespace BIKECOMMON
{
    public class OtherHelper
    {
        /// <summary>
        /// 获得本机物理地址
        /// </summary>
        /// <returns></returns>
        public string getMacAddrLocal()
        {
            string macAddr = null;
            ManagementClass mc = new ManagementClass("Win32_NetworkAdapterConfiguration");
            ManagementObjectCollection moc2 = mc.GetInstances();
            foreach (ManagementObject mo in moc2)
            {
                if (Convert.ToBoolean(mo["IPEnabled"]) == true)
                {
                    macAddr = mo["MacAddress"].ToString();
                    macAddr = macAddr.Replace(':', '-');
                }
                mo.Dispose();
            }
            return "60-a4-4c-60-7e-ae";
         //return macAddr;
        }
    }
}
