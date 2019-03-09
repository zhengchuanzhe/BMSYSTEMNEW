using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MODEL
{
    /// <summary>
    /// 会员等级
    /// </summary>
    public class VipLevelInfo
    {
        //等级编号
        private int lvId;
        public int LvId
        {
            get { return lvId; }
            set { lvId = value; }
        }
        //等级名称
        private string lvName;
        public string LvName
        {
            get { return lvName; }
            set { lvName = value; }
        }
        //是否删除
        private bool isDelete;
        public bool IsDelete
        {
            get { return isDelete; }
            set { isDelete = value; }
        }
        private bool isVip;
        public bool IsVip
        {
            get { return isVip; }
            set { isVip = value; }
        }
    }
}
