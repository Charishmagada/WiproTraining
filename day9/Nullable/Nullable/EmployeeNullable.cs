using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nullable
{
    internal class EmployeeNullable
    {
        static void Main()
        {
            Employee employee1= new Employee();
            employee1.Empno = 1;
            employee1.Name = "Padma";
            employee1.Basic = 99887;

            Employee employee2= new Employee();
            employee2.Empno = 2;
            employee2.Name = "Tripura";
            employee2.Basic = 99897;

            if(employee1.LeaveDays.HasValue)
            {
                Console.WriteLine("{0} taken leave ",employee1.Name);
                employee1.Status = 0;
            }
            else
            {
                Console.WriteLine("{0} not taken leave ",employee1.Name); 
                employee1.Status = 1;
            }
            if(employee2.LeaveDays.HasValue)
            {
                Console.WriteLine("{0} taken leave ", employee2.Name);
                employee2.Status = 0;
            }
            else
            {
                Console.WriteLine("{0} not taken leave ", employee2.Name);
                employee2.Status = 1;
            }


        }
    }
}
