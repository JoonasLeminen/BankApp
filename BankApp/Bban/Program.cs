using System;
using System.Collections.Generic;
using System.Linq;

namespace BankApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("BankApp v1.0");
            Bank bank = new Bank("Ankkalinnan pankki");

            List<Customer> customers = new List<Customer>();
            customers.Add(new Customer("Aku", "Ankka", bank.CreateAccount()));
            customers.Add(new Customer("Roope", "Ankka", bank.CreateAccount()));
            customers.Add(new Customer("Hannu", "Hanhi", bank.CreateAccount()));

            bank.AddTransactionForCustomer(customers[0].AccountNumber, new Transaction(1234, new DateTime(2018, 03, 23)));
            PrintBalance(bank, customers[0]);
            Console.WriteLine("<Enter> lopettaa!");
            Console.ReadLine();
        }

        public static void PrintBalance(Bank bank, Customer customer)
        {
            var balance = bank.GetBalanceForCustomer(customer.AccountNumber);
            Console.WriteLine("{0} - balance: {1}{2:0.00}", customer.ToString(), balance >= 0 ? "+" : "", balance);
        }
    }
}
//Oman pankkinumeron tarkistus
//FI23 5482 3720 0153 38
//     2121 2121 2121 2
//    1+0+4+1+6+2+6+7+4+0+0+1+1+0+3+6=50-42=8
//string machineFormat = BankUtil.CorrectNumber("227720-35988");
//Console.WriteLine(BankUtil.isValidAccount(machineFormat));
  //          Console.ReadKey();