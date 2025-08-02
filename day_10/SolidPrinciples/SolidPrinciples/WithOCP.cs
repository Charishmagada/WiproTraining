using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidPrinciples
{
    public class WithOCP
    {
        public interface IDiscount
        {
            double ApplyDiscount(double amount);
        }

        public class DiwaliDiscount : IDiscount
        {
            public double ApplyDiscount(double amount) => amount * 0.9;
        }

        public class NewYearDiscount : IDiscount
        {
            public double ApplyDiscount(double amount) => amount * 0.8;
        }
        
        static void Main()
        {
            
            IDiscount diwaliDiscount = new DiwaliDiscount();
            double finalAmount1 = diwaliDiscount.ApplyDiscount(1000);
            Console.WriteLine("Diwali Discounted Amount: " + finalAmount1);

            IDiscount newYearDiscount = new NewYearDiscount();
            double finalAmount2 = newYearDiscount.ApplyDiscount(1000);
            Console.WriteLine("New Year Discounted Amount: " + finalAmount2);
        }


    }
}
