using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace AppDemo
{
    internal class JaggedArrayCustom
    {
        static void Main()
        {
            int n, m;
            Console.WriteLine("Enter Number of Arrays and sixe of array");
            n = Convert.ToInt32(Console.ReadLine());
            m = Convert.ToInt32(Console.ReadLine());
            int[][] jaggedArray = new int[n][];
            int[] x = new int[m];
            int[] y = new int[m];
            Console.WriteLine("Enter Array X:");
            for (int i = 0; i < m; i++)
            {
                x[i] = Convert.ToInt32(Console.ReadLine());
            }
            Console.WriteLine("Enter Array Y:");
            for(int i = 0; i < m; i++)
            {
                y[i]=Convert.ToInt32(Console.ReadLine());
            }
            jaggedArray[0] = x;
            jaggedArray[1]= y;
            for(int i = 0;i<jaggedArray.Length;i++)
            {
                for(int j = 0;j < jaggedArray[i].Length;j++)
                {
                    Console.Write(jaggedArray[i][j]+" ");
                }
                Console.WriteLine();
            }

        }
    }
}
