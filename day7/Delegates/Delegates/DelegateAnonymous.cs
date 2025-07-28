using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates
{
    internal class DelegateAnonymous
    {
        public delegate void MyDelegate(string str);
        static void Main()
        {
            MyDelegate obj = delegate (string str)
            {
                Console.WriteLine("Anonymous Delegate "+str);
            };
            obj("dot net");
        }
    }
}
