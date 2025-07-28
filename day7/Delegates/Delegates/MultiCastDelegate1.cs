using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates
{
    internal class MultiCastDelegate1
    {
        public delegate void MyDelegate();
        public static void Milestone1()
        {
            Console.WriteLine("Milestone1 is on .net core concepts");
        }
        public static void Milestone2()
        {
            Console.WriteLine("Milestone2 is on react concepts");
        }
        public static void Milestone3()
        {
            Console.WriteLine("Milestone3 is on .ASP");
        }
        public static void Milestone4()
        {
            Console.WriteLine("Milestone4 is on azure");
        }
        public static void Project()
        {
            Console.WriteLine("Capstone Project");
        }
        static void Main()
        {
            MyDelegate obj = new MyDelegate(Milestone1);
            obj += Milestone2;
            obj+= Milestone3;
            obj+= Milestone4;
            obj += Project;
            obj();

        }
    }
}
