using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtensionMethods
{
    internal static class Extension
    {
        public static int Mul(this Calculation calc, int x, int y)
        {
            return x*y;
        }
    }
}
