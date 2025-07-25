using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractConstructor
{
    internal class Rustyn:Employee
    {
        public Rustyn(int empno,string name,double basic):base(empno,name,basic) 
        {
        }
    }
}
