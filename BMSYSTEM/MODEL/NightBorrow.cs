using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MODEL
{
    /// <summary>
    /// 包夜租车类实体类
    /// </summary>
    public   class NightBorrow
    {
        /// <summary>
        /// 包夜租车Id
        /// </summary>
        private string  id;
        public string Id
        {
            set { id = value; }
            get { return id; }
        }

        /// <summary>
        /// 包夜花费
        /// </summary>
        private string cost;
        public string Cost
        {
            set { cost = value; }
            get { return cost; }
        }

        /// <summary>
        /// 开始时间
        /// </summary>
        private string beginTime;
        public string BeginTime
        {
            set { beginTime = value; }
            get { return beginTime; }
        }

        /// <summary>
        /// 结束时间
        /// </summary>
        private string endTime;
        public string EndTime
        {
            set { endTime = value; }
            get { return endTime; }
        }

        /// <summary>
        /// 备注
        /// </summary>
        private string mark;
        public string Mark
        {
            set { mark = value; }
            get { return mark; }
        }

        /// <summary>
        ///是否删除
        /// </summary>
        private bool isDelete;
        public bool IsDelete
        {
            set { isDelete = value;}
            get { return isDelete; }
        }
    }
}
