using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MODEL
{
    //会员年报表
   public class VipYearForm
    {
       //编号
       private int vyId;
       public int VyId
       {
           get { return vyId; }
           set { vyId = value; }
       }
       //会员编号
       private int vipId;
       public int VipId
       {
           get { return vipId; }
           set { vipId = value; }
       }
       //会员花费
       private double vyCost;
       public double VyCost
       {
           get { return vyCost; }
           set { vyCost = value; }
       }
       //会员租车次数
       private int vyTimes;
       public int VyTimes
       {
           get { return vyTimes; }
           set { vyTimes = value; }
       }

       //记录生成时间
       private DateTime time;
       public DateTime Time
       {
           get { return time; }
           set { time = value; }
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
