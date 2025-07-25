using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OopsConcepts
{
    class Data
    {
        public void Show()
        {
            Console.WriteLine("non static method");
        }
        public static void Display()
        {
            Console.WriteLine("static method");
        }
    }
    internal class StaticMethod
    {
        static void Main()
        {
           //Data data = new Data();
           //data.Show();
           new Data().Show(); //anonymous obj creation 
        //whenever obj is required only for once we can use anonymous objects(obj name is not required except for show method later)
           Data.Display();
        }
    }
}
