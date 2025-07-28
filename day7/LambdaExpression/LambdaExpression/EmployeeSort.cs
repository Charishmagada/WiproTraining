using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LambdaExpression
{
    internal class EmployeeSort
    {
        static void Main()
        {
            List<Employee> employeeList = new List<Employee>
            {
                new Employee { Empno = 11, Name = "Padma", Basic = 99887 },
                new Employee { Empno = 2, Name = "Tripura", Basic = 98833 },
                new Employee { Empno = 33, Name = "Nireesha", Basic = 97543 },
                new Employee { Empno = 4, Name = "Vijju", Basic = 98765 },
                new Employee { Empno = 55, Name = "Praneetha", Basic = 98776 },
            };
            employeeList.Sort();
            Console.WriteLine("Sorted data:");// (by default it gets sorted with empno)
            var result1 = employeeList.Select(x => x);
            foreach (var v in result1)
            {
                Console.WriteLine(v);
            }
            Console.WriteLine("Sort by name wise");
            employeeList.Sort(new NameComparer());
            var result2= employeeList.Select(x => x);
            foreach(var v in result2)
            {
                Console.WriteLine(v);
            }
            Console.WriteLine("Sort by basic wise");
            employeeList.Sort(new BasicComparer());
            var result3= employeeList.Select(x => x);
            foreach(var v in result3)
            {
                Console.WriteLine(v);
            }
        }
    }
}
