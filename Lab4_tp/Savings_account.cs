using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4_tp
{
    public class Savings_account : Base_account
    {
        protected double percent;

        public Savings_account(int n, int c, double b, DateTime d):base(n, c, b, d)
        {
            percent = 0.02;
        }
        public void AccruePercent(DateTime current_date)
        {
            if (current_date.Day == this.start_date.Day)
                this.balance += balance * percent; 
        }
    }
}
