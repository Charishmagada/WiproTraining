using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static CustomAttributes.AttributeExample2;

namespace CustomAttributes
{
    public class Demo2
    {
        public static void PrintClassInfor(Type t)
        {
            MemberInfo memberInfo = t;
            object[] arr = memberInfo.GetCustomAttributes(typeof(VendorAttribute), false);
            foreach (object ob in arr)
            {
                VendorAttribute v = (VendorAttribute)ob;
                Console.WriteLine(v.vendorName);
                Console.WriteLine(v.premiumAmount);
            }
        }
        static void Main()
            {
            Demo2.PrintClassInfor(typeof(Anubhav));
            Demo2.PrintClassInfor(typeof(Aarifa));
            }
    }
}
