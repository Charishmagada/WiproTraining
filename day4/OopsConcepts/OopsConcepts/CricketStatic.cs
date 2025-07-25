using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace OopsConcepts
{
    internal class CricketStatic
    {
        static int score;
        public void Increment(int x)
        {
            score += x;

        }
        public void Show()
        {
            Console.WriteLine("overall score:" + score);
        }

        static void Main()
        {
            CricketStatic c1 = new CricketStatic();
            CricketStatic c2= new CricketStatic();
            CricketStatic c3 = new CricketStatic();
            c1.Increment(20);
            c2.Increment(30);
            c3.Increment(50);
            c3.Show();
        }
    }
}
