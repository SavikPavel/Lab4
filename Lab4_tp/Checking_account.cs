using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4_tp
{
    public class Checking_account : Base_account
    {
        private int mountly_quota;
        private int total_transactions;
        private double per_transaction_fee;

        public Checking_account(int n, int c, double b, DateTime d):base(n, c, b, d)
        {
            mountly_quota = 10;
            total_transactions = 0;
            per_transaction_fee = 10;
        }
        public Checking_account(int n, int c, double b, DateTime d, int quota, double fee):base(n, c, b, d)
        {
            mountly_quota = quota;
            total_transactions = 0;
            per_transaction_fee = fee;
        }
        public override double Withdraw(DateTime current_date, double value)
        {
                total_transactions++;
                double fee = 0;
                if (total_transactions > mountly_quota)
                    fee = (total_transactions - mountly_quota) * per_transaction_fee;
                if (value + fee <= this.balance)
                {
                    balance -= value + fee;
                    return value;
                }
                else
                    total_transactions--;
            return 0;
        }
        public void AccruePercent(DateTime current_date)
        {
            if (current_date.Day == this.start_date.Day)
                this.total_transactions = 0;
        }
    }
}
