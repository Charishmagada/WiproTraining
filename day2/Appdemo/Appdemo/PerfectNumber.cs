using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appdemo
{
    internal class PerfectNumber
    {
        public void Show(int n)
        {
            int sum = 0;
            for (int i = 1; i < n; i++)
            {
                if(n%i==0)
                {
                    sum += i;
                }
            }
            if(sum==n)
            {
                Console.WriteLine("Perfect Number");
            }
            else
            {
                Console.WriteLine("Not a Perfect Number");
            }
        }
        static void Main()
        {
            int n;
            n=Convert.ToInt32(Console.ReadLine());
            PerfectNumber perfectNumber = new PerfectNumber();
            perfectNumber.Show(n);
        }
    }
}
