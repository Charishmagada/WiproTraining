using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appdemo
{
    internal class ConversionCtoF
    {
        public double Conversion(double celsius)
        {
            double faranheit = ((9 * celsius) / 5) + 32;
            return faranheit;
        }
        static void Main()
        {
            double celsius;
            Console.WriteLine( "Enter celsius value to be converted:");
            celsius = Convert.ToDouble(Console.ReadLine());
            ConversionCtoF obj = new ConversionCtoF();
            Console.WriteLine("Faraheit value for given celsius is:" + obj.Conversion(celsius));
        }
    }
}
