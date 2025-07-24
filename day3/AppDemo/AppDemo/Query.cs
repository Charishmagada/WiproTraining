using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDemo
{
    internal class Query
    {
        public void Increment(int x)
        {
            ++x;
        }
        static void Main()
        {
            int x=12;
            Query q = new Query();
            q.Increment(x);
            Console.WriteLine(x);//call by value since Increment method doest not return any so irrespective of operator the value of x remain same as 12
            q.Increment1(ref x);
            Console.WriteLine(x); 
        }

        //to overcome this we have call by reference
        public void Increment1(ref int x)
        {
            x++;
        }
    }
}
