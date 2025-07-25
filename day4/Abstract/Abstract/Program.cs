using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstract
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Training t1 = new Lara();
            //Training t2= new Arya();
            //Training t3 = new Eesha();

            // to make program extension more easier we can make use of arrays
            Training[] arrtraining = new Training[]
            {
                new Lara(),
                new Arya(),
                new Eesha(),
            };
            foreach (Training t in arrtraining)
            {
                t.Company();
                t.Name();
                t.Email();
                Console.WriteLine("-------------");
            }

        }
    }
}
