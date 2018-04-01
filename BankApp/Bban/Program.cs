using System;
using System.Collections.Generic;
using System.Linq;

namespace BankApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();

            Console.WriteLine("BankApp v1.0");
            Bank bank = new Bank("Ankkalinnan pankki");

            List<Customer> customers = new List<Customer>();
            customers.Add(new Customer("Aku", "Ankka", bank.CreateAccount()));
            customers.Add(new Customer("Roope", "Ankka", bank.CreateAccount()));
            customers.Add(new Customer("Hannu", "Hanhi", bank.CreateAccount()));

            var endTime = DateTime.Today;
            var time = new TimeSpan(24 * 30 * 6, 0, 0);
            var startTime = endTime.Date - time;

            bank.AddTransactionForCustomer(customers[0].AccountNumber, new Transaction(1234, new DateTime(2018, 03, 23)));
            bank.AddTransactionForCustomer(customers[1].AccountNumber, new Transaction(1000000, new DateTime(2018, 04, 01)));
            bank.AddTransactionForCustomer(customers[2].AccountNumber, new Transaction(500, new DateTime(2018, 04, 01)));
            PrintBalance(bank, customers[0]);
            PrintBalance(bank, customers[1]);
            PrintBalance(bank, customers[2]);
            Console.WriteLine();

            for (int i = 0; i < 20; i++)
            {
                bank.AddTransactionForCustomer(customers[rnd.Next(0, 3)].AccountNumber,
                    new Transaction(rnd.Next(-3000, 3000),
                    new DateTime(2018, rnd.Next(1, 3), rnd.Next(1, 28))));
            }

            Console.WriteLine($"{bank.ToString()}\n");

            for (int i = 0; i < customers.Count; i++)
            {
                PrintBalance(bank, customers[i]);
                Console.WriteLine($"Transactions from last 6 months: {startTime.ToShortDateString()} - {endTime.ToShortDateString()}");
                PrintTransactions(bank.GetTransactions(customers[i].AccountNumber, startTime, endTime), customers[i]);
            }

            Console.WriteLine("<Enter> lopettaa!");
            Console.ReadKey();
        }

        public static void PrintBalance(Bank bank, Customer customer)
        {
            var balance = bank.GetBalanceForCustomer(customer.AccountNumber);
            Console.WriteLine("{0} - balance: {1}{2:0.00}", customer.ToString(), balance >= 0 ? "+" : "", balance);
        }

        public static void PrintTransactions(List<Transaction> transactions, Customer customer)
        {
            Console.WriteLine($"{customer.FirstName} {customer.LastName}:");

            for (int i = 0; i < transactions.Count(); i++)
            {
                Console.WriteLine("{0}\t{1}{2:0.00}",
                    transactions[i].Timestamp.ToShortDateString(),
                    transactions[i].Sum >= 0 ? "+" : "",
                    transactions[i].Sum);
            }
            Console.WriteLine();
        }
    }
}