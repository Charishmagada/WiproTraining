using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OopsConcepts
{
    internal class Constructor
    {
        Constructor()
        {
           
        }
        public void Show()
        {
            Console.WriteLine("Instance constructor gets invoked only when object is created");
        }

        static void Main()
        {
            Constructor c = new Constructor();
            c.Show();
        }
    }
}
