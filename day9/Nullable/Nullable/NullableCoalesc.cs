using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nullable
{
    internal class NullableCoalesc
    {
        static void Main()
        {
            string s1 = null;
            string s2 = "Welcome";
            string s3 = "Bye";

            string s4 = s1 ?? s2;
            Console.WriteLine(s4);// if null executes right hand operand
            s4= s3??s2;
            Console.WriteLine(s4);// if not null executes left hand operand.
        }
    }
}
