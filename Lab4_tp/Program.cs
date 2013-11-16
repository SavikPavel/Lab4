using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4_tp
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Base_account> accountList = new List<Base_account>();
            Interface interface_class = new Interface();
            interface_class.Fill_accounts_predefined(accountList);
            interface_class.Main_menu(accountList);
        }
    }
}
