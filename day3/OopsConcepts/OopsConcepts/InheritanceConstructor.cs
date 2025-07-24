using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OopsConcepts
{
    internal class InheritanceConstructor
    {
        class A
        {
            public A()
            {
                Console.WriteLine("Base Class");
            }
        }
        class B :A
        {
            public B()
            {
                Console.WriteLine("Derived Class");
            }
        }
        static void Main()
        {
            B b=new B();

        }
    }
}
