using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appdemo
{
    internal class Query2
    {
        static void Main()
        {
            string str = "Welcome to dotnet programming by prasanna";
            string[] names = str.Split(' ');
            foreach (string name in names)
            {
                Console.WriteLine(name);
            }
                
        }
    }
}
