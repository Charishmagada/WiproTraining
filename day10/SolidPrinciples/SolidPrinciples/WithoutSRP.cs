using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidPrinciples
{
    public class WithoutSRP
    {
            public void CalculateTotal() { /* ... */ }

            public void PrintInvoice() { Console.WriteLine("Printing Invoice"); }

            public void SaveToDatabase() { Console.WriteLine("Saving to DB"); }
        static void Main()
        {
            WithoutSRP withoutSRP = new WithoutSRP();
            withoutSRP.CalculateTotal();
            withoutSRP.PrintInvoice();
            withoutSRP.SaveToDatabase();

        }

    }
}
