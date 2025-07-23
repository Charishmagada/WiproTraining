using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appdemo
{
    internal class Palindrome
    {
        public void Show(string str)
        {
            string rev = new string(str.Reverse().ToArray());
            if (rev.Equals(str))
            {
                Console.WriteLine("it is a Palindrome"); ;
            }
            else
            {
                Console.WriteLine("it is Not a Palindrome");
            }
        }
        static void Main()
        {
            string str;
            Console.WriteLine("Enter String");
            str = Console.ReadLine();
            Palindrome palindrome = new Palindrome();
            palindrome.Show(str);
        }
    }
}
