using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appdemo
{
    internal class Factorial
    {
        public void Show(int n)
        {
            int i = 1;
            int fact = 1;
            while(i<=n)
            {
                fact = fact * i;
                i++;
            }
            Console.WriteLine(fact);

        }
        static void Main()
        {
            int n;
            Console.WriteLine("Enter number:");
            n=Convert.ToInt32(Console.ReadLine());
            Factorial factorial = new Factorial();
            factorial.Show(n);
        }
    }
}
