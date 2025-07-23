using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appdemo
{
    internal class Query1
    {
        public void Show(String data)
        {
            data = data.ToLower();
            int count = 0;
            char[] chars=data.ToCharArray();
            foreach(char c in chars)
            {
                if (c == 'a' || c == 'e'|| c=='i' ||c=='o'||c=='u')
                {
                    count += 1;
                }
            }
            Console.WriteLine("total number of vowels in a given string:"+count);
        }
        static void Main()
        {
            string data;
            Console.WriteLine("Enter string:");
            data = Console.ReadLine();
            Query1 query1 = new Query1();
            query1.Show(data);
        }
    }
}
