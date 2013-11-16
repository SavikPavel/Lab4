using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4_tp
{
    public class Timed_maturity_account : Savings_account
    {
        private double penalty_rate;

        public Timed_maturity_account(int n, int c, double b, DateTime d):base(n, c, b, d)
        {
            penalty_rate = 0.02;
        }
        public Timed_maturity_account(int n, int c, double b, DateTime d, double penalty):base(n, c, b, d)
        {
            penalty_rate = penalty;
        }
        public override double Withdraw(DateTime current_date, double value)
        {
            double amount_given_to_depositor = 0;
            if (value <= balance)
            {
                if (current_date.Day != this.start_date.Day)
                    amount_given_to_depositor = value - (value * penalty_rate);
                else
                    amount_given_to_depositor = 0;
                balance -= value;
                return value - amount_given_to_depositor;
            }
            return 0;
        }
    }
}
