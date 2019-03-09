using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MODEL
{
    public class UInfo
    {
        //编号
        private int uId;
        public int UId
        {
            get { return uId; }
            set { uId = value; }
        }

        //U盾信息
        private string uInfo;
        public string U_Info
        {
            get { return uInfo; }
            set { uInfo = value; }
        }

        //是否删除
        private bool isDelete;
        public bool IsDelete
        {
            get { return isDelete; }
            set { isDelete = value; }
        }
        //是否超级管理员
        private bool isAdmin;
        public bool IsAdmin
        {
            get { return isAdmin; }
            set { isAdmin = value; }
        }
        //添加时间
        private DateTime addDate;
        public DateTime AddDate
        {
            get { return addDate; }
            set { addDate = value; }
        }
        /// <summary>
        /// 对应分店
        /// </summary>
        private int departId;
        public int DepartId
        {
            get { return departId; }
            set { departId = value; }
        }
        /// <summary>
        /// 加密狗序列号
        /// </summary>
        private string identify;
        public string Identify
        {
            get { return identify; }
            set { identify = value; }
        }
    }
}
