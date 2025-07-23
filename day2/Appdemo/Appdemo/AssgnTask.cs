using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appdemo
{
    internal class AssgnTask
    {
        public void Show(string str)
        {
            string[] names = str.Split(' ');
            
                for(int i = 0;i<names.Length;i++)
                    { 
                    if(i%2==1)
                        {
                        char[] chars = names[i].ToCharArray();
                        System.Array.Reverse(chars);
                        names[i] = new string(chars);
                        }
                     }
            String result = string.Join(" ",names);
            Console.WriteLine(result);
            
        }
        static void Main() {
            string str;
            Console.WriteLine("Enter string:");
            str = Console.ReadLine();
            AssgnTask task = new AssgnTask();
            task.Show(str);
        }
    }
}
