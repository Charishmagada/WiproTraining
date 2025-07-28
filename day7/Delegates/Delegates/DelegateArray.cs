using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates
{
    internal class DelegateArray
    {
        public delegate void MyDelegate(int n);
        public static void PosNeg(int n)
        {
            if (n <= 0)
            {
                Console.WriteLine("Negative number");
            }
            else
            {
                Console.WriteLine("Positive Number");
            }
        }
        public static void EvenOdd(int n)
        {
            if (n % 2 == 0)
            {
                Console.WriteLine("Even number");
            }
            else
            {
                Console.WriteLine("Odd number");
            }
        }
        public static void Fact(int n)
        {
            int f = 1;
            for (int i = 1; i <= n; i++)
            {
                f = f * i;

            }
            Console.WriteLine(f);
        }
        static void Main()
        {
            int n;
            Console.WriteLine("Enter number:");
            n=Convert.ToInt32(Console.ReadLine());
            MyDelegate[] arr =
                {
                new MyDelegate(PosNeg),
                new MyDelegate(EvenOdd),
                new MyDelegate(Fact)
                };
            foreach(MyDelegate m in arr)
            {
                m(n);
            }
        }
    }
}
