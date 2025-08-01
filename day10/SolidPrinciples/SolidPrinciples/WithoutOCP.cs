using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidPrinciples
{
    public class WithoutOCP
    {
        public double GetDiscount(string type, double amount)
        {
            if (type == "Diwali")
                return amount * 0.9;
            else if (type == "NewYear")
                return amount * 0.8;
            else
                return amount;
        }
        static void Main()
        {
            WithoutOCP withoutOCP = new WithoutOCP();
            Console.WriteLine(withoutOCP.GetDiscount("Diwali",10000));
            Console.WriteLine(withoutOCP.GetDiscount("NewYear",10000));

        }

    }
}
