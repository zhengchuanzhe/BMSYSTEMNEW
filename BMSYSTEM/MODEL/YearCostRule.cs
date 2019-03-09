using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MODEL
{
    public class YearCostRule
    {
        //编号
        private int crId;
        public int CrId
        {
            get { return crId; }
            set { crId = value; }
        }
        //规则名称
        private string crName;
        public string CrName
        {
            get { return crName; }
            set { crName = value; }
        }
        //每月扣费金额
        private double costPh;
        public double CostPh
        {
            get { return costPh; }
            set { costPh = value; }
        }
        //扣费活动时间
        private DateTime costTime;
        public DateTime CostTime
        {
            get { return costTime; }
            set { costTime = value; }
        }

        //起始扣费金额
        private double costBegin;
        public double CostBegin
        {
            get { return costBegin; }
            set { costBegin = value; }
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
