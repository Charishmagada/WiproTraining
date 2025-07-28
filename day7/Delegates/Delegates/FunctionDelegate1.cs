using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Delegates
{
    internal class FunctionDelegate1
    {
        public static int Sum(int x, int y)
        {
            return x + y;
        }
        public static int Sub(int x, int y)
        {
            return x - y;
        }
        public static int Mul(int x, int y)
        {
            return x * y;
        }
        static void Main()
        {
            Func<int, int, int> obj = Sum;
            Console.WriteLine("Sum is " + obj(12, 5));
            obj += Sub;
            Console.WriteLine("Sub is " + obj(12, 5));
            obj += Mul;
            Console.WriteLine("Mul is "+obj(12, 5));
        }
    }
}