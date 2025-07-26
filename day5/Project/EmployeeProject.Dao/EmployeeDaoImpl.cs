using EmployeeProjects.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeProject.Dao
{
    public class EmployeeDaoImpl : IEmployeeDao

    {
        static List<Employee> employeeList;
        static EmployeeDaoImpl()
        {
            employeeList = new List<Employee>();
        }
        public string AddEmployeeDao(Employee employee)
        {
              employeeList.Add(employee);
              return "employee record inserted";
            
        }
        public Employee SearchEmployeeDao(int empno)
        {
            Employee employeeFound = null;
            foreach(Employee employee in employeeList)
            {
                if(employee.Empno==empno)
                {
                    employeeFound = employee;
                    break;
                }
            }
            return employeeFound;
        }
        public List<Employee>ShowEmployeeDao()
        {
            return employeeList;
        }
        public string DeleteEmployeeDao(int empno)
        {
            Employee employeeFound = SearchEmployeeDao(empno);
            if (employeeFound != null)
            {
                employeeList.Remove(employeeFound);
                return "Employee Record Deleted Successfully";
            }
            return "Employee Record Not Found";
        }
        public string UpdateEmployeeDao(Employee employeeUpdated)
            {
            Employee employeeFound = SearchEmployeeDao(employeeUpdated.Empno);
            if (employeeFound != null)
            {
                employeeFound.Name = employeeUpdated.Name;
                employeeFound.Gender = employeeUpdated.Gender;
                employeeFound.Designation = employeeUpdated.Designation;
                employeeFound.Basic = employeeUpdated.Basic;
                return "Employ Record Updated";
            }
            return "Employ Record Not Found";
            }
        public string WriteToFileDao()
        {
            FileStream fs = new FileStream(@"C:\Users\Charishma Gada\Wipro\day5\Employee.txt", FileMode.Create, FileAccess.Write);
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(fs, employeeList);
            fs.Close();
            return "Data Stored in Files Successfully";
        }
        public string ReadFromFileDao()
        {
            FileStream fs = new FileStream(@"C:\Users\Charishma Gada\Wipro\day5\Employee.txt" ,FileMode.Open, FileAccess.Read);
            BinaryFormatter formatter = new BinaryFormatter();
            employeeList = (List<Employee>)formatter.Deserialize(fs);
            return "Data Retrieved from the File Successfully";
        }

    }

}

