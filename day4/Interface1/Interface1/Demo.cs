using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface1
{
    internal class Demo:IOne,ITwo
    {
        public void Name()
        {
            Console.WriteLine("I am Lara");
        }
        public void Email()
        {
            Console.WriteLine("Lara@gmail.com");
        }
        static void Main(string[] args)
        {
            Demo d = new Demo();
            d.Name();
            d.Email();
        }
    }
}
