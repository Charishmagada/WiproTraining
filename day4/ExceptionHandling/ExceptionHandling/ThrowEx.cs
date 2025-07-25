using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionHandling
{
    internal class ThrowEx
    {
        public void Show(int n)
        {
            if(n<0)
            {
                throw new ArgumentException("Negative numbers not allowed");
            }
            else if(n==0)
            {
                throw new ArgumentException("Zero is invalid value");
            }
            else
            {
                Console.WriteLine("value is: "+n);
            }
        }
        static void Main()
        {
            int n;
            Console.WriteLine("Enter number:");
            n=Convert.ToInt32(Console.ReadLine());
            ThrowEx throwEx = new ThrowEx();

            try
            {
                throwEx.Show(n);
            }
            catch(ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }
    }
}
