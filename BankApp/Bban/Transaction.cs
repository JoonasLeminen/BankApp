using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace BankApp
{
    class Transaction
    {

        public double Sum; 
        private DateTime _timestamp;

        
        public Transaction(double sum, DateTime timestamp)
        {
            Sum = sum;
            _timestamp = timestamp;
        }

        public double sum { get => Sum; set => Sum = value; }
    }
}
