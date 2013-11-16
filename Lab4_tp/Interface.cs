using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4_tp
{
    class Interface
    {
        private Base_account my_account = null;

        public void Fill_accounts_random(List<Base_account> accounts, int n)
        {
            Random rand = new Random();
            int type = 0, number = 1, code = 0;
            double balance = 0;
            DateTime date = DateTime.Now;
            for (int i = 0; i < n; i++)
            {
                type = rand.Next(1, 4);
                while (accounts.Any(t => t.Acc_no == number) == true)
                    number = rand.Next(2, 100500);
                code = rand.Next(1, 9999);
                balance = rand.NextDouble() * 10000;
                switch (type)
                {
                    case 1:
                        accounts.Add(new Checking_account(number, code, balance, date));
                        break;
                    case 2:
                        accounts.Add(new Savings_account(number, code, balance, date));
                        break;
                    case 3:
                        accounts.Add(new Overdraft_account(number, code, balance, date));
                        break;
                    case 4:
                        accounts.Add(new Timed_maturity_account(number, code, balance, date));
                        break;
                }
            }
        }
        public void Fill_accounts_predefined(List<Base_account> accounts)
        {
            accounts.Add(new Checking_account(1, 1234, 10000, DateTime.Now, 5, 0.5));
            accounts.Add(new Savings_account(2, 2345, 20000, DateTime.Now));
            accounts.Add(new Overdraft_account(3, 3456, 30000, DateTime.Now));
            accounts.Add(new Timed_maturity_account(4, 4567, 40000, DateTime.Now, 0.03));
        }
        public bool Log_in(List<Base_account> accounts)
        {
            int pin_attempts = 0, acc_no = 0, pin = -1;
            System.Console.WriteLine("Enter account number:");
            acc_no = Convert.ToInt32(System.Console.ReadLine());
            if (!accounts.Any(t => t.Acc_no == acc_no))
            {
                System.Console.Clear();
                System.Console.WriteLine("There is no such account in the list. Press any key to return to main menu:");
                System.Console.ReadKey();
                return false;
            }
            else
                my_account = accounts.Where(t => t.Acc_no == acc_no).First();

            System.Console.WriteLine("Enter pin-code:");
            while (pin_attempts != 3)
            {
                pin = Convert.ToInt32(System.Console.ReadLine());
                if (pin != my_account.Pin)
                {
                    pin_attempts++;
                    if (pin_attempts != 3)
                        System.Console.WriteLine("Wrong pin-code! Please, try again:");
                }
                else
                    return true;
            }
            System.Console.WriteLine("Wrong pin-code again!. You have no more attempts.\nPress any key to return to main menu:");
            System.Console.ReadKey();
            return false;
        }
        public void Account_management_menu()
        {
            int choise = 0;
            while (choise > 4 || choise < 1)
            {
                System.Console.Clear();
                System.Console.WriteLine("1. Check balance");
                System.Console.WriteLine("2. Deposit money");
                System.Console.WriteLine("3. Withdraw money");
                System.Console.WriteLine("4. Log out");
                int.TryParse(System.Console.ReadLine(), out choise);
            }
            switch (choise)
            {
                case 1:
                    System.Console.WriteLine("Your current balance is {0}", my_account.CheckBalance());
                    break;
                case 2:
                    Deposit();
                    break;
                case 3:
                    Withdraw();
                    break;
                default:
                    return;
            }
            choise = 0;
            System.Console.WriteLine("Do you want to make another operation?\n1. Yes\n2. No");
            int.TryParse(System.Console.ReadLine(), out choise);
            if (choise == 1)
                Account_management_menu();
            else
                return;

        }
        public void Deposit()
        {
            double amount = 0;
            bool success = false;
            while (!success || amount <= 0)
            {
                System.Console.WriteLine("Enter the amount:");
                success = double.TryParse(System.Console.ReadLine(), out amount);
                if (!success)
                    System.Console.WriteLine("Wrong amount. Please, try again");
            }
            my_account.Deposit(amount);
            System.Console.WriteLine("You have deposited {0} to your account", amount);
        }
        public void Withdraw()
        {
            double amount = 0;
            bool success = false;
            while (!success || amount <= 0)
            {
                System.Console.WriteLine("Enter the amount:");
                success = double.TryParse(System.Console.ReadLine(), out amount);
                if (!success)
                    System.Console.WriteLine("Wrong amount. Please, try again");
            }
            amount = my_account.Withdraw(System.DateTime.Now, amount);
            if (amount > 0)
                System.Console.WriteLine("You have withdrawn {0} from your account", amount);
            else
                System.Console.WriteLine("You can't withdraw this amount of money");
        }
        public void Show_account_list(List<Base_account> accounts)
        {
            System.Console.Clear();
            System.Console.WriteLine("------ Accounts list -------");
            foreach (Base_account acc in accounts)
            {
                System.Console.WriteLine("{0}. {1}", acc.Acc_no, acc.GetType().Name);
            }
            System.Console.WriteLine("Press any key to continue");
            System.Console.ReadKey();
        }
        public void Main_menu(List<Base_account> accounts)
        {
            int choise;
            while (true)
            {
                System.Console.Clear();
                choise = -1;
                System.Console.WriteLine("ATM welcomes you, young man. What do you want to do?");
                while (choise < 1 || choise > 3)
                {
                    if (choise != 1 && choise != 2 && choise != 3 && choise != -1)
                        System.Console.WriteLine("ATM don't understand you, young man. Try again, and this time be more careful:");
                    System.Console.WriteLine("1. Show account list");
                    System.Console.WriteLine("2. Log in");
                    System.Console.WriteLine("3. Exit");
                    int.TryParse(System.Console.ReadLine(), out choise);
                    System.Console.Clear();
                }
                switch (choise)
                {
                    case 1:
                        Show_account_list(accounts);
                        break;
                    case 2:
                        if (Log_in(accounts))
                            Account_management_menu();
                        break;
                    case 3:
                        System.Console.WriteLine("Good bye, old man");
                        return;
                }
            }
        }
    }
}
