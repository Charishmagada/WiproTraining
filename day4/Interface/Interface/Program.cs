using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IntTraining[] arr = new IntTraining[]
            {
                new Padma(),new Siri()
            };
            foreach (IntTraining item in arr)
            {
                item.Name();
                item.Email();
                Console.WriteLine("-----------");
            }

        }
    }
}
