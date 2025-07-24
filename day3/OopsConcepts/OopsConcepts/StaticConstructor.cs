using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OopsConcepts
{
    internal class StaticConstructor
    {
        static StaticConstructor()
        {
            Console.WriteLine("Without intantiation in Main Static constructors will get invoked");
        }
        StaticConstructor()
        {
            Console.WriteLine("Testing Instance constructor");
        }
        static void Main()
        {

        }

    }
}
