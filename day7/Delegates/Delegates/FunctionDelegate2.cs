using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates
{
    internal class FunctionDelegate2
    {
        public static string Display(int n)
        {
            return "Hello " + n;
        }
        public static int Compare(string s1, string s2)
        {
            return s1.CompareTo(s2);
        }
        public static string Show(int n)
        {
            if(n==1)
            {
                return "Tripura";
            }
            else if(n==2)
            {
                return "Padma";
            }
            return "Unknown";
        }
        public static bool Status(int mtsat)
        {
            if (mtsat == 0)
            {
                return true;
            }
            return false;
        }
        static void Main()
        {
            Func<string, string, int> obj = Compare;
            Console.WriteLine(obj("Padma","Tripura"));
            Func<int, string> obj2 = Show;
            obj2 += Display;
            Console.WriteLine(obj2(2));
            Func<int,bool>obj3= Status;
            Console.WriteLine(obj3(1));

        }
    }
}
