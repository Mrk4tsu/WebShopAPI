using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KatsuShopSolution.Utilities
{
    public class KatsuShopException : Exception
    {
        public KatsuShopException()
        {
        }
        public KatsuShopException(string message) : base(message)
        {
        }
        public KatsuShopException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}
