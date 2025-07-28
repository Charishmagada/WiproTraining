using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates
{
    internal class SingleCastDelegate
    {
        public delegate void MyDelegate(string s);
        public static void Show(string s)
        {
            Console.WriteLine("Delgates demo by "+s);
        }
        static void Main()
        {
            MyDelegate obj = new MyDelegate(Show);
            MyDelegate obj1 = Show;//both syntaxes are fine 
            obj("Prasanna Sir");
            obj1("Prasanna Sir");

        }
    }
}
