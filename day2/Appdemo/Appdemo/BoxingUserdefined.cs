using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appdemo
{
    internal class BoxingUserdefined
    {
        public void Show(object obj)
        {
            string type=obj.GetType().Name;
            if(type.Equals("Employee"))
            {
                 Employee employee=(Employee)obj;
                Console.WriteLine("Employee No  " + employee.empno + " Name " + employee.name + " Basic " + employee.basic);
            }
        }
        static void Main()
        {
            Employee employee = new Employee();
            employee.empno = 1;
            employee.name = "siri";
            employee.basic = 998834;

            BoxingUserdefined boxingUserdefined = new BoxingUserdefined();
            boxingUserdefined.Show(employee);
        }
    }
}
