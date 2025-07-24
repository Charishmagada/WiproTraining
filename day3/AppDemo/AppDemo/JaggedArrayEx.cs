using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDemo
{
    internal class JaggedArrayEx
    {
        static void Main()
        {
            int n, m;
            Console.WriteLine("Enter number of Arrays you want to store(rows):");
            n=Convert.ToInt32(Console.ReadLine());
            int[][] jaggedArray = new int[n][];
            for (int i = 0;i<n;i++)
            {
                Console.WriteLine("Number of elements in each Array:");
                m= Convert.ToInt32(Console.ReadLine());
                jaggedArray[i]= new int[m];
                Console.WriteLine("Enter elements for array(row)");
                for (int j = 0; j < m; j++)
                {
                    jaggedArray[i][j] = Convert.ToInt32(Console.ReadLine());
                }

            }
            Console.WriteLine("Jagged Array Elements:");
            for (int i = 0; i < jaggedArray.Length; i++)
            {
                for (int j = 0; j < jaggedArray[i].Length; j++)
                {
                    Console.Write(jaggedArray[i][j] + " ");
                }
                Console.WriteLine();
            }

        }
    }
}
