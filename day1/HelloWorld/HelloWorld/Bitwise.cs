﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorld
{
    internal class Bitwise
    {
        static void Main()
        {
            int a=5, b=3;
            Console.WriteLine( a&b);
            Console.WriteLine( a|b );
            Console.WriteLine(a ^ b);
            Console.WriteLine(~a);
        }
    }
}
