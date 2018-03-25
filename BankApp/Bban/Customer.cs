using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace BankApp
{
    class Customer
    {
        
        private string _firstName;
        private string _lastName;
        private string _accountNumber;

        
        public Customer(string firstName, string lastName, string accountNumber)
        {
            _firstName = firstName;
            _lastName = lastName;
            _accountNumber = accountNumber;
        }

        public string AccountNumber { get => _accountNumber; set => _accountNumber = value; }

        public override string ToString()
        {
            return $"{_firstName}{_lastName}\t{_accountNumber}";
        }
    }
}
