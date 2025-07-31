using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nullable
{
    public class Emp
    {
        public int Empno { get; set; }
        public string Name {  get; set; }
        public double Basic {  get; set; }
        public override string ToString()
        {
            return "Employee No " + Empno + " Name " + Name + " Basic "+Basic;
        }
    }
}
