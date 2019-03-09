using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MODEL
{
    public class ChangeUser
    {
        private double newVip;
        public double NewVip
        {
            get { return newVip; }
            set { newVip = value; }
        }

        private double vipIncome;

        public double VipIncome
        {
            get { return vipIncome; }
            set { vipIncome = value; }
        }

        private double vipNoIncome;
        public double VipNoIncome
        {
            get { return vipNoIncome; }
            set { vipNoIncome = value; }
        }
    }
}
