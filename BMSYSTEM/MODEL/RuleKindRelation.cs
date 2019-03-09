using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MODEL
{
    //租车类型与扣费规则关系
    public class RuleKindRelation
    {
        //编号
        private int rkrId;
        public int RkrId
        {
            get { return rkrId; }
            set { rkrId = value; }
        }

        //等级ID
        private int lvId;
        public int LvId
        {
            get { return lvId; }
            set { lvId = value; }
        }

        //租车类别ID
        private int brkId;
        public int BrkId
        {
            get { return brkId; }
            set { brkId = value; }
        }

        //扣费规则ID
        private int ruId;
        public int RuId
        {
            get { return ruId; }
            set { ruId = value; }
        }

        //是否删除
        private bool isDelete;
        public bool IsDelete
        {
            get { return isDelete; }
            set { isDelete = value; }
        }
          
    }
}
