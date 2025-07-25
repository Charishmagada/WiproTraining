using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstract
{
    internal class Arya:Training
    {
        public override void Name()
        {
            Console.WriteLine("I am Arya");
        }
        public override void Email()
        {
            Console.WriteLine("My email is arya@gmail.com");
        }
    }
}
