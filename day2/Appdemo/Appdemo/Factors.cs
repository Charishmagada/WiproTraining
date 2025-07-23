using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appdemo
{
    internal class Factors
    {
        public void Show(int n)
        {
            for(int i = 1; i <=n; i++)
            {
                if(n%i==0)
                {
                    Console.WriteLine("Factors are "+i);
              
                }
            }
        }
        static void Main(string[] args) 
            {
                int n;
                Console.WriteLine("Enter number:");
                n=Convert.ToInt32(Console.ReadLine());
                Factors factors = new Factors();
                factors.Show(n);
            }

    }
}
