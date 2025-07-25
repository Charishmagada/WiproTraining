using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionHandling
{
    internal class StrExample
    {
        static void Main()
        {
            string s = "Hello World";
            try
            {
                Console.WriteLine(s.Substring(2,100));
            }
            catch(ArgumentOutOfRangeException)
            {
                Console.WriteLine("Range is out of index");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            
        }
    }
}
