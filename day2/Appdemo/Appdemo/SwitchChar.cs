using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appdemo
{
    internal class SwitchChar
    {
        public void Check(char choice)
        {
            switch (choice)
            {
                case 'a':
                case 'A':
                case '1':
                    Console.WriteLine("1st case");
                    break;
                case 'b':
                case 'B':
                case '2':
                    Console.WriteLine("2nd case");
                    break;
                case 'c':
                case 'C':
                case '3':
                    Console.WriteLine("3rd case");
                    break;


            }
        }
        static void Main(string[] args)
        {
            char choice;
            choice = Convert.ToChar(Console.ReadLine());
            SwitchChar obj = new SwitchChar();
            obj.Check(choice);


        }
    }
}
