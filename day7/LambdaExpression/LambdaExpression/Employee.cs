using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LambdaExpression
{
    internal class Employee:IComparable<Employee>
    {
        public int Empno {  get; set; }
        public string Name { get; set; }
        public double Basic {  get; set; }
        public int CompareTo(Employee employee)
        {
            if(Empno>=employee.Empno)
            {
                return 1;
            }
            return -1;
        }
        public override string ToString()
        {
            return "Employee no " + Empno + " Employee Name " + Name + " Basic " + Basic;
        }

    }
}
