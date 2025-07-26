using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeProjects.Models;


namespace EmployeeProject.Dao
{
    public interface IEmployeeDao
    {
        string AddEmployeeDao(Employee employee);
        List<Employee> ShowEmployeeDao();
        Employee SearchEmployeeDao(int Empno);
        string UpdateEmployeeDao(Employee employeeUpdated);
        string DeleteEmployeeDao(int empno);
        string WriteToFileDao();
        string ReadFromFileDao();
    }
}
