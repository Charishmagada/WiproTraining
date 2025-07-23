using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appdemo
{
    internal class Circle
    {
        public void Cal(double r)
        {
            double area = Math.PI * r * r;
            double circumference=2*Math.PI*r;
            Console.WriteLine("Area of circle is"+area );
            Console.WriteLine("Circumference of circle is" + circumference);
            
        }
        static void Main()
        {
            double r;
            Console.WriteLine("enter radius");
             r = Convert.ToDouble(Console.ReadLine());
            Circle c=new Circle();
            c.Cal(r);
         
        }
    }
}
