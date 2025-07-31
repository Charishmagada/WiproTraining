using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomAttributes
{
    [AttributeExample(InformationString = "Class")]
    public class Student
    {
        private int sno;
        private string name;

        [AttributeExample(InformationString = "Constructor")]
        public Student(int sno, string name)
        {
            this.sno = sno;
            this.name = name;
        }

        [AttributeExample(InformationString = "Method")]
        public void Display()
        {
            Console.WriteLine("Sno " + sno + " Name  " + name);
        }
    }
}
