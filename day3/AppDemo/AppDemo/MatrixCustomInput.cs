using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDemo
{
    internal class MatrixCustomInput
    {
        static void Main()
        {
            int[,] x = new int[2, 3];
            Console.WriteLine("Enter Array Elements:");
            for (int i = 0; i < x.GetLength(0); i++)
            {
                for (int j = 0; j < x.GetLength(1); j++) //size of rows-1
                {
                    x[i,j]=Convert.ToInt32(Console.ReadLine());
                }
            }
            Console.WriteLine("Display Elements in Matrix Format");
            for(int i = 0;i < x.GetLength(0); i++)
            {
                for(int j=0; j < x.GetLength(1);j++)
                {
                    Console.Write(x[i, j]+" ");
                }
                Console.WriteLine();
            }
            
        }
    }
}
