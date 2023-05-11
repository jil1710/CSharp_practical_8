using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_practical_8.models
{
    public sealed class CardDetail
    {
        public long CardNumber { get; init; }
        public int CVV { get; init; }
        public int Pin { get; set; } 
        public bool isActivate { get; set; } = false;
    }
}
