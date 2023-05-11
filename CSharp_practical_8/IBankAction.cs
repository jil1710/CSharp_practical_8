using CSharp_practical_8.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_practical_8
{
    internal interface IBankAction
    {
        public bool CreateAccount(BankAccount bankAccount);
        public bool UpdateAccountDetails(long bankAccount);
        public bool DeleteAccount(long bankAccount);
        public BankAccount GetAccountDetails(long bankAccount);
        public bool Login(long accnum, string accesskey);
        public bool RequestATMCard(long accnum);

    }
}
