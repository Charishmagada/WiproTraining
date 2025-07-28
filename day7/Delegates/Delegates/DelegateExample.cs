using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates
{
    internal class DelegateExample
    {
        public delegate void MyDelegate();
        public static void Show()
        { 
            Console.WriteLine("Delegates Demo");
        }
        static void Main(string[] args)
        {
            MyDelegate obj=new MyDelegate(Show);
            obj();

        }
    }
}
