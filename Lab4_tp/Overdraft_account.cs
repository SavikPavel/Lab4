using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4_tp
{
    public class Overdraft_account : Base_account
    {
        protected double percent;
        public Overdraft_account(int n, int c, double b, DateTime d):base(n, c, b, d)
        {
            percent = 0.02;
        }
        public override double Withdraw(DateTime current_date, double value)
        {
            this.balance -= value;
            return value;
        }
        public void AccruePercent(DateTime current_date)
        {
            if (current_date.Day == this.start_date.Day && balance < 0)
               this.balance += balance * percent;
        }
    }
}
