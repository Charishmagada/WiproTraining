using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LambdaExpression
{
    internal class BasicComparer:Comparer<Employee>
    {
        public override int Compare(Employee x, Employee y)
        {
            if(x.Basic>=y.Basic)
            {
                return 1;
            }
            return -1;
        }
    }
}
