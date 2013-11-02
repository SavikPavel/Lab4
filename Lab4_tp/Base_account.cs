using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4_tp
{
    struct date
    {
        public int year;
        public int month;
        public int day;
        date(int _year, int _month, int _day)
        {
            year = _year;
            month = _month;
            day = _day;
        }
    }
    abstract class Base_account
    {
        private double balance;
        public void SetBalance(double _balance)
        {
            this.balance = _balance;
        }
        private  date start_date;
        public date GetStartDate()
        {
            return this.start_date;
        }
        public void SetStartDate(date new_date)
        {
            this.start_date = new_date;
        }

        public void Deposit(double value)
        {
            balance += value;
        }
        public virtual bool Withdraw(double value)
        {
            if (value <= balance)
            {
                balance -= value;
                return true;
            }
            return false;
        }
        public double CheckBalance()
        {
            return balance;
        }
    }
}
