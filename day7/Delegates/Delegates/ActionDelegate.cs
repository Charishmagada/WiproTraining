using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates
{
    internal class ActionDelegate
    {
        public static void Greeting(string s)
        {
            Console.WriteLine("Hello "+s);
        }
        public static void Greeting2(string s)
        {
            Console.WriteLine("How are you? "+s);
        }
        static void Main()
        {
            string s;
            Console.WriteLine("Enter name");
            s=Console.ReadLine();
            Action<string> action = Greeting;
            action += Greeting2;
            action(s);
        }

            
    }
}
