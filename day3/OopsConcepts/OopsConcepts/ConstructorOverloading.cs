using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OopsConcepts
{
    internal class ConstructorOverloading
    {
        int a, b;
        public ConstructorOverloading()
        {
            a = 5;
            b = 7;

        }
        public ConstructorOverloading(int a, int b)
        {
            this.a = a;
            this.b = b;
        }
        public void Show()
        {
            Console.WriteLine("A value is "+a+"B value is "+b);
        }


        static void Main()
        {
            ConstructorOverloading c=new ConstructorOverloading();
            c.Show();
            ConstructorOverloading c1 = new ConstructorOverloading(11,12);
            c1.Show();

        }

    }
}
