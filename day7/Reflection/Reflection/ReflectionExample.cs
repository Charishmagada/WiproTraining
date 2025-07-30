using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace Reflection
{
    internal class ReflectionExample
    {
        static void Main()
        {
            Type typeObj = typeof(Test);
            Console.WriteLine("Methods available in test class are:");
            foreach(MethodInfo mi in typeObj.GetMethods())
            {
                Console.WriteLine(mi.Name);
            }
            Console.WriteLine("Variables available in the class are:");
            foreach(FieldInfo fi in typeObj.GetFields())
            {
                Console.WriteLine(fi.Name);
            }
            
        }
    }
}
