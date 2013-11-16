using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4_tp
{
    public abstract class Base_account
    {
        private int acc_no;
        private int pin;
        protected double balance;
        protected DateTime start_date;

        public int Pin
        {
            get { return pin; }
            set { pin = value; }
        }
        public int Acc_no
        {
            get { return acc_no; }
            set { acc_no = value; }
        }
        public Base_account(int number, int code, double start_balance, DateTime start_date)
        {
            acc_no = number;
            pin = code;
            balance = start_balance;
            this.start_date = start_date;
        }

        public void Deposit(double value)
        {
            balance += value;
        }
        public virtual double Withdraw(DateTime current_date, double value)
        {
            if (value <= balance)
            {
                balance -= value;
                return value;
            }
            return 0;
        }
        public double CheckBalance()
        {
            return balance;
        }
    }
}
