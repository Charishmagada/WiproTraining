using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shadowing
{
    internal class Second:First
    {
        public new void Show()
        {
            Console.WriteLine("Show method from class second");
        }
    }
}
