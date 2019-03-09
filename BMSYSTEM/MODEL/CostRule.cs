using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MODEL
{
    //扣费规则
    public class CostRule
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
        //每小时扣费金额
        private double costPh;
        public double CostPh
        {
            get { return costPh; }
            set { costPh = value; }
        }
        //扣费活动时间
        private int costTime;
        public int CostTime
        {
            get { return costTime; }
            set { costTime = value; }
        }
        //起始扣费金额
        private double costbegin;
        public double costBegin
        {
            get { return costbegin; }
            set { costbegin = value; }
        }

        //起始扣费金额包含的时间
        private int contime;
        public int conTime
        {
            get { return contime; }
            set { contime = value; }
        }

        //扣费种类：日租、月租、年租
        private int crkind;
        public int crKind
        {
            get { return crkind; }
            set { crkind = value; }
        }

        //是否删除
        private bool isDelete;
        public bool IsDelete
        {
            get { return isDelete; }
            set { isDelete = value; }
        }
        //会员等级
        private int lvId;
        public int LvId
        {
            get { return lvId; }
            set { lvId = value; }
        }
    }
}
