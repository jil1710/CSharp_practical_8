using CSharp_practical_8.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_practical_8
{
    internal class ATM : ATMAction
    {
        public override bool ChangePin(long acc)
        {
            Console.Write(" Enter New Pin : ");
            int newpin = Convert.ToInt32(Console.ReadLine());
            var holdername = DBContext.db.FirstOrDefault(e=> e.AccountNumber == acc);
            if (holdername != null)
            {
                holdername.CardDetails!.Pin = newpin;
                return true;
            }
            return false;
        }

        public override BankAccount GetAccountDetails(long bankAccount)
        {
            return DBContext.db.FirstOrDefault(e => e.AccountNumber == bankAccount)!;
        }
    }
}
