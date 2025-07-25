using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractConstructor
{
    internal class River:Employee
    {
        public River(int empno,string name,double basic):base(empno,name,basic) 
        { 
        }
    }
}
