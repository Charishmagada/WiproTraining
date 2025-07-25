using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace OopsConcepts
{
    internal class StaticExample
    {
        static int count; //variable scope within the class
        public void Increment()
        {
            count++;
        }
        public void Show()
        {
            Console.WriteLine("count value is:"+count);
        }
        static void Main(string[] args) //main fun defines as static because here we are not creating any obj so static methods get invoked without obj right
        {
            StaticExample example = new StaticExample();
            StaticExample example2 = new StaticExample();
            StaticExample example3 = new StaticExample();
            example.Increment();
            example.Show();
            example2.Increment();
            example2.Show();
            example3.Increment();
            example3.Show(); //if static not used all 3 will be 1 as op.

        }
    }
}
