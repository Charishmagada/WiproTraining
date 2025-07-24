using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InheritanceExamples
{
    internal class Second:First
    {
        public void Show()
        {
            base.Show();
            Console.WriteLine("show method from class second");
            /// <summary>
            /// derived class over writes the base class.
            /// To avoid this and method needs to be printed from both classes we make use of keyword called base
            /// </summary>
        }

    }
}
