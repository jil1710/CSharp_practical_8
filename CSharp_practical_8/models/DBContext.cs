using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_practical_8.models
{
    public class DBContext
    {
        public static List<BankAccount> db { get; set; } = new();
    }
}
