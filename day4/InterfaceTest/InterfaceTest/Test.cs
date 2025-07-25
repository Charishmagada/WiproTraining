using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceTest
{
    internal class Test : Interface1, Interface2
    {
        // when you have same methods names in both interfaces,then you should implement using interface name
        void Interface1.Show()
        {
            Console.WriteLine("Show method from Interface1");
        }

        void Interface2.Show()
        {
            Console.WriteLine("Show method from Interface2");
        }
        static void Main()
        {
            Interface1 obj1=new Test();
            Interface2 obj2=new Test();
            obj1.Show();
            obj2.Show();    
        }
    }
}
