using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OopsConcepts
{
   static class Demo
        {
        public static void Show()
        {
            Console.WriteLine("Show method");
        }
        public  static string Trainer()
        {
           return "trainer is prasanna";
        }
        }
    internal class StaticClass
    {
        static void Main()
        {
            Demo.Show();
            Console.WriteLine(Demo.Trainer());
        }
    }
}
