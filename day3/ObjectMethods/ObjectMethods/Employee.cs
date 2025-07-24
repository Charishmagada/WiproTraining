using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectMethods
{
    internal class Employee
    {
        int empno;
        string name;
        double basic;
        public Employee()
        {

        }
        public Employee(int empno, string name,double basic)
        {
            this.empno = empno;
            this.name = name;
            this.basic = basic;
        }
        public override string ToString()
        {
            return "empno "+ empno+" name "+name+ " basic "+basic;
        }
    }
}
