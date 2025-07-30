using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection
{
    internal class DeprecatedMethod
    {
        [Obsolete("Deprecated Method", false)]
        public static void TestMethod()
        {
            Console.WriteLine("Demo Method...");
        }
        static void Main()
        {

        }
    }
}
