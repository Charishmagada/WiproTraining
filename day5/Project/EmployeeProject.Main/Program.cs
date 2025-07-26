using System;
using System.Collections.Generic;
using EmployeeProjects.Models;
using EmployeeProject.Exceptions;
using EmployeeProject.Bal;
using System.Collections.Concurrent;
using System.Net.Http.Headers;


namespace EmployeeProject.Main
{
    internal class Program
    {
        static EmployeeBal employeeBal;
        static Program()
        {
            employeeBal = new EmployeeBal();
        }
        public static void SearchEmployeeMain()
        {
            int empno;
            Console.WriteLine("Enter Employee Number to search:");
            empno=Convert.ToInt32(Console.ReadLine());
            Employee employee=employeeBal.SearchEmployeeBal(empno);
            if(employee != null )
            {
                Console.WriteLine(employee);
            }
            else
            {
                Console.WriteLine("Record not found.");
            }
        }
        public static void ShowEmployeeMain()
        {
            List<Employee> employeeList = employeeBal.ShowEmployeeBal();
            Console.WriteLine("Employee Record:");
            foreach (Employee employee in employeeList)
            {
                Console.WriteLine(employee);
            }
        }
        public static void AddEmployeeMain()
        {
            Employee employee = new Employee();
            Console.WriteLine("Enter Employee Number:");
            employee.Empno=Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Employee Name:");
            employee.Name=Console.ReadLine();
            Console.WriteLine("Enter Gender:");
            employee.Gender=Console.ReadLine();
            Console.WriteLine("Employee Designation:");
            employee.Designation=Console.ReadLine();
            Console.WriteLine("Enter Basic:");
            employee.Basic=Convert.ToDouble(Console.ReadLine());
            Console.WriteLine(employeeBal.AddEmployeeBal(employee));

        }
        public static void WriteToFileMain()
        {
            Console.WriteLine(employeeBal.WriteToFileBal());
        }

        public static void ReadFromFileMain()
        {
            Console.WriteLine(employeeBal.ReadFromFileBal());
        }
        public static void DeleteEmployeeMain()
        {
            int empno;
            Console.WriteLine("Enter Employee Number   ");
            empno = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(employeeBal.DeleteEmployeeBal(empno));
        }

        public static void UpdateEmployMain()
        {
            Employee employee = new Employee();
            Console.WriteLine("Enter Employee Number  ");
            employee.Empno = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Employee Name  ");
            employee.Name = Console.ReadLine();
            Console.WriteLine("Enter Gender (MALE/FEMALE)   ");
            employee.Gender = Console.ReadLine();
            Console.WriteLine("Enter Designation  ");
            employee.Designation = Console.ReadLine();
            Console.WriteLine("Enter Basic  ");
            employee.Basic = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine(employeeBal.UpdateEmployeeBal(employee));
        }
        static void Main()
        {
            int choice;
            do
            {
                Console.WriteLine("O P T I O N S");
                Console.WriteLine("----------");
                Console.WriteLine("1.Add Employee");
                Console.WriteLine("2.Show Employee");
                Console.WriteLine("3.Search Employee");
                Console.WriteLine("4.Update Employee");
                Console.WriteLine("5.Delete Employee");
                Console.WriteLine("6.Write to file");
                Console.WriteLine("7.Read from file");
                Console.WriteLine("Enter Choice:");
                choice = Convert.ToInt32(Console.ReadLine());
                switch(choice)
                {
                    case 1:
                        try
                        {
                            AddEmployeeMain();
                        }
                        catch(EmployeeExceptions e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e);
                        }
                        break;
                     case 2:
                        ShowEmployeeMain();
                        break;
                     case 3:
                        SearchEmployeeMain();
                        break;
                    case 4:
                        try
                        {
                            UpdateEmployMain();
                        }
                        catch (EmployeeExceptions e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e);
                        }
                        break;
                    case 5:
                        DeleteEmployeeMain();
                        break;
                    case 6:
                        WriteToFileMain();
                        break;
                    case 7:
                        ReadFromFileMain();
                        break;
                    case 8:
                        return;

                }
            } while (choice != 8);
        }
    }
}
