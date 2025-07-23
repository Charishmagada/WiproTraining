using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Appdemo
{
    internal class Loop
    {
        public void Show()
        {
            int i = 0;
            while (i < 10)
            {
                Console.WriteLine(i);
                i++;
            }
        }
        static void Main()
            {
                Loop l=new Loop();
                l.Show();

            }

    }
}
