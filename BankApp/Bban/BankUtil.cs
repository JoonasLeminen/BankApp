using System;
using System.Collections.Generic;
using System.Text;

namespace BankApp
{
    class BankUtil
    {
        public static string CorrectNumber(string accountNumber)
        {
            accountNumber = accountNumber.Replace("-", "").Replace(" ", "");

            int positionOfZeros = 0;
            if (accountNumber[0] == '1' || accountNumber[0] == '2' || accountNumber[0] == '6' || accountNumber[0] == '8')
                positionOfZeros = 6;
            else if (accountNumber[0] == '3')
            {
                if (accountNumber[1] == '0' || accountNumber[1] == '2' || accountNumber[1] == '5')
                    return "Account incorrect format!";
                positionOfZeros = 6;
            }
            else if (accountNumber[0] == '4' || accountNumber[0] == '5')
                positionOfZeros = 7;
            else
            {
                return "Account unknown format!";
            }

            for(int i = accountNumber.Length; i < 14; i++)
            {
                accountNumber = accountNumber.Insert(positionOfZeros, "0");
            }
            return accountNumber;
        }

        public static bool isValidAccount(string machineFormatAccount)
        {
            int checkNumber = int.Parse(machineFormatAccount[machineFormatAccount.Length-1].ToString());
            machineFormatAccount = machineFormatAccount.Remove(machineFormatAccount.Length -1,1);
            int[] multiplex = new int[2] { 2, 1 };
            int m = 0;
            for(int i =0; i < machineFormatAccount.Length; i++)
            {
                int n = int.Parse(machineFormatAccount[i].ToString()) * multiplex[i%2];
                if(n>=10)
                    m += n / 10 + (n - 10);
                else
                {
                    m += n;
                }
            }
            int calculatedCheckNumber = ((m / 10 + 1) * 10)-m;
            return checkNumber == calculatedCheckNumber;
        }
    }
}
