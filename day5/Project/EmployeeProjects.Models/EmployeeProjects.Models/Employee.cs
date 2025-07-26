using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeProjects.Models
{
    [Serializable]
    public class Employee
    {
       
            public int Empno { get; set; }
            public string Name { get; set; }
            public string Gender { get; set; }
            public string Designation { get; set; }
            public double Basic { get; set; }
        public Employee() { }
        public Employee(int empno, string name, string gender, string designation, double basic)
        {
            Empno = empno;
            Name = name;
            Gender = gender;
            Designation = designation;
            Basic = basic;
        }
        public override string ToString()
        { 
            return " Employee num " + Empno +
                " Employee name " + Name +
                " Employee gender " + Gender +
                " Employee designation " + Designation +
                " Employee basic" + Basic;
        }
    }

}
