using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LambdaExpression
{
    internal class NameComparer:Comparer<Employee>
    {
        public override int Compare(Employee x, Employee y)
        {
            return x.Name.CompareTo(y.Name);
        }
    }
}
