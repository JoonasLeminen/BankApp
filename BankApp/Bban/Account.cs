using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace BankApp
{
    class Account
    {
        
        private string _accountNumber;
        private double _balance;
        private List<Transaction> _transactions;

        
        public Account(string accountNumber)
        {
            _accountNumber = accountNumber;
        }

        public Account(string accountNumber, double balance, List<Transaction> transactions)
        {
            _accountNumber = accountNumber;
            _balance = balance;
            _transactions = transactions;
        }

        public string AccountNumber { get => _accountNumber; set => _accountNumber = value; }

        public double Balance { get => _balance; set => _balance = value; }

        public bool AddTransaction(Transaction transaction)
        {
            bool res = false;

            _transactions.Add(transaction);
            double balanceBeforeTransaction = _balance;
            if (_transactions.Last().Equals(transaction))
            {
                _balance += transaction.Sum;
            }
            if (_balance - transaction.Sum == balanceBeforeTransaction)
            {
                res = true;
            }
            return res;
        }
    }
}
