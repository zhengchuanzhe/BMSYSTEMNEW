using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MODEL
{
    /// <summary>
    /// 分店信息
    /// </summary>
    public class DepartInfo
    {
        //分店编号
        private int dpId;
        public int DpId
        {
            get { return dpId; }
            set { dpId = value; }
        }
        //分店名称
        private string dpName;
        public string DpName
        {
            get { return dpName; }
            set { dpName = value; }
        }
        //分店地址
        private string dpPlace;
        public string DpPlace
        {
            get { return dpPlace; }
            set { dpPlace = value; }
        }

        //分店电脑MAC地址
        private string dpPCMAC;
        public string DpPCMAC
        {
            get { return dpPCMAC; }
            set { dpPCMAC = value; }
        }

        //是否删除
        private bool isDelete;
        public bool IsDelete
        {
            get { return isDelete; }
            set { isDelete = value; }
        }
        //添加时间
        private DateTime addDate;
        public DateTime AddDate
        {
            get { return addDate; }
            set { addDate = value; }
        }
    }
}
