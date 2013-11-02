using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4_tp
{
    class Savings_account : Base_account
    {
        private double percent;
        public void AccruePercent(date current_date)
        {
            double curr_balance = CheckBalance();
            if (current_date.day == this.GetStartDate().day)
                this.SetBalance(curr_balance + curr_balance * percent); 
        }
    }
}
