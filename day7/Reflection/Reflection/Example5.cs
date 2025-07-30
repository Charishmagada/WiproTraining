using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection
{
    [CLSCompliant(true)]
        internal class Example5
        { 
            public void display() { }
            public void Hello() { }

            public void method1() { }

            public void testEmploy() { }
            public void HowMany() { }

            static void Main()
            {
                new Example5().Hello();
            }
        }
    }

