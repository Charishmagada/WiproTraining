using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace OopsConcepts
{
    internal class Inheritance
    {
        class First
        {
            public void Show()
            {
                Console.WriteLine("Base class");
            }
        }
        class Second : First
        { 
            public void Display()
            {
                Console.WriteLine("Derived class");
            }
        }
        static void Main()
        {
            Second s=new Second();
            s.Show();
            s.Display();
        }

    }
}
