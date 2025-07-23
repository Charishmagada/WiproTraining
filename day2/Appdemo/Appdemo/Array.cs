using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appdemo
{
    internal class Array
    {
        public void Show()
        {
            int[] a = new int[] { 10, 20, 30 };
            int[] b = a; // simply we assign for copy
            for (int i = 0; i < a.Length; i++)
            {
                Console.WriteLine(a[i]);
            }
            Console.WriteLine("Copied array");
            for(int i=0; i < b.Length; i++)
            { 
                Console.WriteLine(b[i]); 
            }
            //we can also use foreach loop
            Console.WriteLine("Using foreach loop");
            foreach(int i in a)
                { Console.WriteLine(i); }
        }
        static void Main() {
            Array a = new Array();
            a.Show();

        }
    }
}
