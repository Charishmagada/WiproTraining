using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace Appdemo
{
    internal class Query3
    {
        public bool IsPalindrome(string str)
        {
            string rev=new string(str.Reverse().ToArray());
            if(rev.Equals(str))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void Show1(string str)
        {
            string[] names = str.Split(' ');
            foreach (string name in names)
            {
                if (IsPalindrome(name) == true)
                {
                    Console.WriteLine(name);
                }
            }
        }
        public static void Main()
        {
            Console.WriteLine("Enter String:");
            string str=Console.ReadLine();
            Query3 query = new Query3();
            query.Show1(str);
        }
        

    }
}
