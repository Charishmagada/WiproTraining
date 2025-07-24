using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDemo
{
    internal class Matrix
    {
        static void Main()
        {
            int[,] a = new int[2, 3]
            {
                { 1,2,3},
                { 4,5,6}
            };
            for (int i = 0;i<a.GetLength(0);i++)
            {
                for (int j = 0;j<a.GetLength(1);j++)
                {
                    // Console.WriteLine(a[i,j]);
                    //Console.WriteLine("a{0}{1} {2}",i,j,a[i,j]) curly braces are used as place holders just like %d in c or format specifiers.
                    Console.Write(a[i,j]+" ");
                }
                Console.WriteLine();
               
            }

        }
    }
}
