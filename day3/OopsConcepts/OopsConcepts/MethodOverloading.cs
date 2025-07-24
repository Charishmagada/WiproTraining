using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OopsConcepts
{
    internal class MethodOverloading
    {
        public void Show(int x)
        {
            Console.WriteLine("Integer");
        }
        public void Show(string x)
        { 
            Console.WriteLine("String"); 
        }
        public void Show(double x)
        {
            Console.WriteLine("Double");
        }
        static void Main()
        {
            int x = 12;
            string s = "Hello";
            double d = 988.773;
            MethodOverloading m=new MethodOverloading();
            m.Show(x);
            m.Show(s);
            m.Show(d);
        }
    }
}
