using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4_tp
{
    class Checking_account : Base_account
    {
        private int mountly_quota;
        private int total_transactions;
        private double per_transaction_fee;
        public override bool Withdraw(double value)
        {
                total_transactions++;
                double fee = 0;
                if (total_transactions > mountly_quota)
                    fee = (total_transactions - mountly_quota) * per_transaction_fee;
                if (value + fee <= CheckBalance())
                {
                    SetBalance(CheckBalance() + value + fee);
                    return true;
                }
            return false;
            }

        }
    }
}
