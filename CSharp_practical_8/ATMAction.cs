using CSharp_practical_8.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_practical_8
{
    internal abstract class ATMAction
    { 
        public abstract bool ChangePin(long acc);
        public abstract BankAccount GetAccountDetails(long bankAccount);

    }
}
