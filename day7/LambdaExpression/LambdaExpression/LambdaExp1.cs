using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LambdaExpression
{
    internal class LambdaExp1
    {
        static void Main()
        {
            List<Employee> employeeList = new List<Employee>
            {
                new Employee{Empno=1,Name="Padma",Basic=99887},
                new Employee{Empno=2,Name="Tripura",Basic=98833 },
                new Employee{Empno=3,Name="Nireesha",Basic=97543 },
                new Employee{Empno=4,Name="Vijju",Basic=98765 },
                new Employee{Empno=5,Name="Praneetha",Basic=98776 },
            };
            Console.WriteLine("Employee List:");
            var result1 = employeeList.Select(x => x);
            foreach(var v in result1)
            {
                Console.WriteLine(v);
            }
            var result2 = employeeList.Select(x => new { x.Name, x.Basic });
            Console.WriteLine("Projected Fields are");
            foreach (var v in result2)
            {
                Console.WriteLine(v);
            }
            var result3 = employeeList.Where(x => x.Basic >= 90000);
            Console.WriteLine("Salary > 90000 records are");
            foreach (var v in result3)
            {
                Console.WriteLine(v);
            }
            var result4 = employeeList.Where(x => x.Name.StartsWith("P"));
            Console.WriteLine("Employee names starting with P:");
            foreach (var v in result4)
            {
                Console.WriteLine(v);
            }
        }
    }
}
