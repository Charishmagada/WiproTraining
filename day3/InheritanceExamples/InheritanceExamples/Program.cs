using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InheritanceExamples
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Second second = new Second();
            second.Show();// only derived class method gets executed
        }
    }
}
