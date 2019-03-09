using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MODEL
{
    public class BorrowKind
    {
        //编号
        private int bkId;
        public int BkId
        {
            get { return bkId; }
            set { bkId = value; }
        }

        //租车种类名称
        private string bbkName;
        public string BbkName
        {
            get { return bbkName; }
            set { bbkName = value; }
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
