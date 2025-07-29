using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NunitDemos
{
    public class EmployeeDao
    {
        static List<Employee> employeeList;
        static EmployeeDao()
        {
            employeeList = new List<Employee>()
            {
                new Employee { Empno = 1, Name = "Tripura", Basic = 99887 },
                new Employee { Empno = 2, Name = "Padma", Basic = 98987 },
                new Employee { Empno = 3, Name = "Nireesha", Basic = 99778 },
                new Employee { Empno = 4, Name = "Vijju", Basic = 98978 }
            };
        }
        public List<Employee>ShowEmployee()
        {
            return employeeList;
        }
        public Employee SearchEmployee(int empno)
        {
            Employee employeeFound = null;
            foreach (Employee emp in employeeList)
            {
                if(emp.Empno==empno)
                {
                    employeeFound= emp;
                }
            }
            return employeeFound;
        }
    }
}
