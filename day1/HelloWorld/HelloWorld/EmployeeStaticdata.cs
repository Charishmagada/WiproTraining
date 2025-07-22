using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorld
{
    internal class EmployeeStaticdata
    {
        static void Main()
        {
            Employee employee1 = new Employee();
            employee1.empno = 1;
            employee1.name = "Geeta";
            employee1.basic = 88323;

            Employee employee2 = new Employee();
            employee2.empno = 2;
            employee2.name = "Sreeja";
            employee2.basic = 88234;

            Console.WriteLine("First Employee Data  ");
            Console.WriteLine("Employ No  " + employee1.empno);
            Console.WriteLine("Employ Name  " + employee1.name);
            Console.WriteLine("Employ Basic  " + employee1.basic);

            Console.WriteLine("Second Employee Data  ");
            Console.WriteLine("Employ No  " + employee2.empno);
            Console.WriteLine("Employ Name  " + employee2.name);
            Console.WriteLine("Employ Basic  " + employee2.basic);
        }
    }
}

