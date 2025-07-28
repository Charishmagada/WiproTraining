using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates
{
    internal class PredicateDeligate
    {
        public static bool Check(string gender)
        {
            if(gender.Equals("MALE")||gender.Equals("FEMALE"))
            {
                return true;
            }
                return false;
        }
        public static bool MaritalStatus(int status)
        {
            if(status == 0 || status==1)
            {
                return true;
            }
            return false;
        }
        static void Main()
        {
            Console.WriteLine("Enter gender:");
            string gender=Console.ReadLine();
            Console.WriteLine("Enter marital status:");
            int status=Convert.ToInt32(Console.ReadLine());
            Predicate<string> obj1 = Check;
            Console.WriteLine(obj1(gender));
            Predicate<int> obj2 = MaritalStatus;
            Console.WriteLine(obj2(status));

        }
    }
}
