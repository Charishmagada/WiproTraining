using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace AppDemo
{
    internal class CallByReference
    {
        public void Calc(int n,ref int f)
        {
           for (int i = 1;i<=n;i++)
            {
                f=f*i;
            }
        }
        static void Main()
        {
            int n, f = 1;
            Console.WriteLine("Enter number");
            n=Convert.ToInt32(Console.ReadLine());
            CallByReference c = new CallByReference();
            c.Calc(n,ref f);
            Console.WriteLine(f);
        }
    }
}
