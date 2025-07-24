using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appdemo
{
    internal class Boxing
    {
        static void Main()
        {
            int x = 12;
            string str = "wipro";
            double y = 12.37;

            //implement boxing
            object ob1 = x;
            object ob2 = str;
            object ob3 = y;

            //implement unboxing
            int x1=(Int32)ob1;
            string str1=(string)ob2;
            double y1=(double)ob3;

            Console.WriteLine(x1);
            Console.WriteLine(str1);
            Console.WriteLine(y1); 

            // This is not the correct way of usage because dynamically it should take type of varaible.

                
        }
    }
}
