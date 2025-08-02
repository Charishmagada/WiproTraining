using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidPrinciples
{
    public class WithSRP
    {
        public class InvoiceCalculator
        {
            public void CalculateTotal()
            { /* calculation */ }
        }

        public class InvoicePrinter
        {
            public void PrintInvoice()
            { Console.WriteLine("Printing Invoice"); }
        }

        public class InvoiceRepository
        {
            public void SaveToDatabase()
            { Console.WriteLine("Saving to DB"); }
        }
     

        static void Main(string[]  args)
        {
            InvoicePrinter printer = new InvoicePrinter();
            printer.PrintInvoice();
            InvoiceRepository repository = new InvoiceRepository();
            repository.SaveToDatabase();
            InvoiceCalculator invoiceCalculator = new InvoiceCalculator();
            invoiceCalculator.CalculateTotal();
        }
    }
}
