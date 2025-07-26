using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeProjects.Models;
using EmployeeProject.Exceptions;
using EmployeeProject.Dao;


namespace EmployeeProject.Bal
{
    public class EmployeeBal
    {
        public StringBuilder sb=new StringBuilder();
        public static EmployeeDaoImpl daoImpl;
        static EmployeeBal()
        {
            daoImpl = new EmployeeDaoImpl();
        }
        public List<Employee>ShowEmployeeBal()
        {
            return daoImpl.ShowEmployeeDao();
        }
        public Employee SearchEmployeeBal(int empno)
        {
            return daoImpl.SearchEmployeeDao(empno);
        }
       public string AddEmployeeBal(Employee employee)
        {
            if(ValidateEmployee(employee)==true)
            {
                return daoImpl.AddEmployeeDao(employee); //if validateemployee is correct then we add data to data layer.
            }
            throw new EmployeeExceptions(sb.ToString());
        }
        public string UpdateEmployeeBal(Employee employUpdated)
        {
            if (ValidateEmployee(employUpdated) == true)
            {
                return daoImpl.UpdateEmployeeDao(employUpdated);
            }
            throw new EmployeeExceptions(sb.ToString());
        }
        public string DeleteEmployeeBal(int empno)
        {
            return daoImpl.DeleteEmployeeDao(empno);
        }
        public string WriteToFileBal()
        {
            return daoImpl.WriteToFileDao();
        }

        public string ReadFromFileBal()
        {
            return daoImpl.ReadFromFileDao();
        }

        // in validation we write business logic
        public bool ValidateEmployee(Employee employee)
        {
            bool flag=true;
            if(employee.Empno<=0)
            {
                sb.Append("Employee number cannot be zero or negative\n");
                flag = false;
            }
            if(employee.Name.Length<5)
            {
                sb.Append("Name should contain min 5 characters\n");
                flag = false;
            }
            if(employee.Basic <10000 ||  employee.Basic >80000)
            {
                sb.Append("Employe basic should range between 10000 and 80000");
                flag = false;
            }
            return flag;
        }
    }
}
