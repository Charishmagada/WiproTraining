using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace NunitDemos
{
    public class Employee
    {
        public int Empno {  get; set; }
        public string Name { get; set; }
        public double Basic {  get; set; }
        public Employee() { }
        public Employee(int empno, string name,double basic)
        {
            Empno = empno;
            Name = name;
            Basic = basic;
        }
        public override string ToString()
        {
            return "Empno " + Empno + " Name " + Name + " Basic " + Basic;
        }

    }
}
