using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace UnitTestProject
{
    using Lab4_tp;
    [TestClass]
    public class TimedMaturityAccUnitTests
    {
        [TestMethod]
        public void TimedMaturityAccCreatingTest()
        {
            Timed_maturity_account acc = new Timed_maturity_account(1111, 1111, 0, DateTime.Now, 0.09);
            Assert.AreNotEqual(null, acc);
        }
        [TestMethod]
        public void TimedMaturityAccCheckBalanceTest()
        {
            double balance = 1000;
            Timed_maturity_account acc = new Timed_maturity_account(1111, 1111, balance, DateTime.Now, 0.09);
            Assert.AreEqual(balance, acc.CheckBalance());
        }
        [TestMethod]
        public void TimedMaturityAccDepositTest()
        {
            double balance = 1000;
            Timed_maturity_account acc = new Timed_maturity_account(1111, 1111, balance, DateTime.Now);
            acc.Deposit(1000);
            Assert.AreEqual(balance + 1000, acc.CheckBalance());
        }

        [TestMethod]
        public void TimedMaturityAccWithdrawTest()
        {
            double balance = 1000;
            Timed_maturity_account acc = new Timed_maturity_account(1111, 1111, balance, DateTime.Now);
            balance -= acc.Withdraw(DateTime.Now, 200);
            Assert.AreEqual(balance, acc.CheckBalance());
        }

        [TestMethod]
        public void TimedMaturityAccAccrueTest()
        {
            double balance = 1000;
            Timed_maturity_account acc = new Timed_maturity_account(1111, 1111, balance, DateTime.Now);
            balance -= acc.AccruePercent(new DateTime(2013, 12, 12));
            Assert.AreEqual(balance, acc.CheckBalance());
        }
    }
    [TestClass]
    public class CheckingAccUnitTests
    {
        [TestMethod]
        public void CheckingAccCreatingTest()
        {
            Checking_account acc = new Checking_account(1111, 1111, 0, DateTime.Now, 10, 1000);
            Assert.AreNotEqual(null, acc);
        }
        [TestMethod]
        public void CheckingAccCheckBalanceTest()
        {
            double balance = 1000;
            Checking_account acc = new Checking_account(1111, 1111, balance, DateTime.Now);
            Assert.AreEqual(balance, acc.CheckBalance());

        }
        [TestMethod]
        public void CheckingAccDepositTest()
        {
            double balance = 1000;
            Checking_account acc = new Checking_account(1111, 1111, balance, DateTime.Now);
            acc.Deposit(1000);
            Assert.AreEqual(balance + 1000, acc.CheckBalance());
        }

        [TestMethod]
        public void CheckingAccWithdrawTest()
        {
            double balance = 1000;
            Checking_account acc = new Checking_account(1111, 1111, balance, DateTime.Now);
            balance -= acc.Withdraw(DateTime.Now, 200);
            Assert.AreEqual(balance, acc.CheckBalance());
        }

        [TestMethod]
        public void CheckingAccAccrueTest()
        {
            double balance = 1000;
            Checking_account acc = new Checking_account(1111, 1111, balance, DateTime.Now);
            balance -= acc.AccruePercent(new DateTime(2013, 12, 12));
            Assert.AreEqual(balance, acc.CheckBalance());
        }
    }
    [TestClass]
    public class OverdraftAccUnitTests
    {
        [TestMethod]
        public void OverdraftAccCreatingTest()
        {
            Overdraft_account acc = new Overdraft_account(1111, 1111, 0, DateTime.Now);
            Assert.AreNotEqual(null, acc);
        }
        [TestMethod]
        public void OverdraftAccCheckBalanceTest()
        {
            Overdraft_account acc = new Overdraft_account(1111, 1111, 1000, DateTime.Now);
            double balance = acc.CheckBalance();
            Assert.AreEqual(1000, balance);
        }
        [TestMethod]
        public void OverdraftAccDepositTest()
        {
            double balance = 1000;
            Overdraft_account acc = new Overdraft_account(1111, 1111, balance, DateTime.Now);
            acc.Deposit(1000);
            Assert.AreEqual(balance + 1000, acc.CheckBalance());
        }

        [TestMethod]
        public void OverdraftAccWithdrawTest()
        {
            double balance = 1000;
            Overdraft_account acc = new Overdraft_account(1111, 1111, balance, DateTime.Now);
            balance -= acc.Withdraw(DateTime.Now, 200);
            Assert.AreEqual(balance, acc.CheckBalance());
        }

        [TestMethod]
        public void OverdraftAccAccrueTest()
        {
            double balance = 1000;
            Overdraft_account acc = new Overdraft_account(1111, 1111, balance, DateTime.Now);
            balance -= acc.AccruePercent(new DateTime(2013, 12, 12));
            Assert.AreEqual(balance, acc.CheckBalance());
        }
    }
    [TestClass]
    public class SavingsAccUnitTests
    {
        [TestMethod]
        public void SavingsAccCreatingTest()
        {
            Savings_account acc = new Savings_account(1111, 1111, 0, DateTime.Now);
            Assert.AreNotEqual(acc, null);
        }
        [TestMethod]
        public void SavingsAccCheckBalanceTest()
        {
            Savings_account acc = new Savings_account(1111, 1111, 100, DateTime.Now);
            double balance = acc.CheckBalance();
            Assert.AreEqual(100, balance);
        }
        [TestMethod]
        public void SavingsAccDepositTest()
        {
            double balance = 1111;
            Savings_account acc = new Savings_account(1111, 1111, balance, DateTime.Now);
            acc.Deposit(1000);
            Assert.AreEqual(2111, acc.CheckBalance());
        }

        [TestMethod]
        public void SavingsAccWithdrawTest()
        {
            double balance = 1111;
            Savings_account acc = new Savings_account(1111, 1111, balance, DateTime.Now);
            balance -= acc.Withdraw(DateTime.Now, 200);
            Assert.AreEqual(balance, acc.CheckBalance());
        }

        [TestMethod]
        public void SavingsAccAccrueTest()
        {
            double balance = 1111;
            Savings_account acc = new Savings_account(1111, 1111, balance, DateTime.Now);
            balance -= acc.AccruePercent(new DateTime(2013, 12, 12));
            Assert.AreEqual(balance, acc.CheckBalance());
        }
    }
    [TestClass]
    public class InterfaceUnitTests
    {
        [TestMethod]
        public void AccListCreatingTest()
        {
            List<Base_account> accountList = new List<Base_account>();
            Assert.AreNotEqual(accountList, null);
        }
        [TestMethod]
        public void InterfaceCreatingTest()
        {
            Interface interface_class = new Interface();
            Assert.AreNotEqual(interface_class, null);
        }
        [TestMethod]
        public void AccListFillingPredefinedTest()
        {
            List<Base_account> accountList = new List<Base_account>();
            Interface interface_class = new Interface();
            interface_class.Fill_accounts_predefined(accountList);
            Assert.AreNotEqual(accountList, null);
        }
        [TestMethod]
        public void AccListFillingRandomTest()
        {
            List<Base_account> accountList = new List<Base_account>();
            Interface interface_class = new Interface();
            interface_class.Fill_accounts_random(accountList, 10);
            Assert.AreNotEqual(accountList, null);
        }
    }
}
