using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractConstructor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Employee[] arrEmployee = new Employee[]
            {
                new Ayan(1,"ayan",1234),
                new Rustyn(2,"rustyn",5678),
                new River(3,"river",9123)

            };
            foreach (Employee emp in arrEmployee)
            {
                Console.WriteLine(emp);
            }

        }
    }
}
