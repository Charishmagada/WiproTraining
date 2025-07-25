using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstract
{
    internal class Lara:Training
    {
        public override void Name()
        {
            Console.WriteLine("I am lara");
        }
        public override void Email()
        {
            Console.WriteLine("My email is lara@gmail.com");
        }
    }
}
