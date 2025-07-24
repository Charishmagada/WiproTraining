using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDemo
{
    internal class Program
    {
        //manual way of printing matrix elements
        static void Main(string[] args)
        {
            int[,] x = new int[2, 3]
            {
                {1,2,3},
                {4,5,6}
            };
            Console.WriteLine(x[0,0]);
            Console.WriteLine(x[0,1]);
            Console.WriteLine(x[0,2]);
            Console.WriteLine("------------");
            Console.WriteLine(x[1,0]);
            Console.WriteLine(x[1,1]);
            Console.WriteLine(x[1,2]);

        }
    }
}
