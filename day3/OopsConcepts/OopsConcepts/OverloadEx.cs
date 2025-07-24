using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OopsConcepts
{
    internal class OverloadEx
    {
        public int Sum()
        {
            return 5;
        }
        public int Sum(int x)
        {
            return x + 5;
        }
        public int Sum(int x,int y)
        {
            return x + y+5;
        }
        static void Main()
        {
            int x=2, y=3;
            OverloadEx s = new OverloadEx();
       
            Console.WriteLine("Wrt no arguments "+ s.Sum());
            Console.WriteLine("wrt one argument "+s.Sum(x));
            Console.WriteLine("wrt two arguments " + s.Sum(x,y));
            
        }
    }
}
