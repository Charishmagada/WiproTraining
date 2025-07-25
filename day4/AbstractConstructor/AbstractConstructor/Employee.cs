using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractConstructor
{
    internal abstract class Employee
    {
        private int empno;
        private string name;
        private double basic;
       
        public Employee(int empno, string name, double basic)
        {
            this.empno = empno;
            this.name = name;
            this.basic = basic;
        }
        public override string ToString()
        {
            return "empno " + empno + " name " + name + " basic " + basic;
        }
    }
}
