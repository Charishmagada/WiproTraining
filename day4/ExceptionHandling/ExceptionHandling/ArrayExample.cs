using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionHandling
{
    internal class ArrayExample
    {
        static void Main()
        {
            int[] a = new int[] { 1, 2, 3, };

            try
            {
                a[10] = 10;
                
            }
            catch(IndexOutOfRangeException)
            {
                Console.WriteLine("Array index is too large");
            }
            catch (Exception e) 
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
