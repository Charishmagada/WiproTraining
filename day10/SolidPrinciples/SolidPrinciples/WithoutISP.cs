using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidPrinciples
{
    internal class WithoutISP
    {
        public interface IMachine
        {
            void Print();
            void Scan();
            void Fax();
        }

        public class OldPrinter : IMachine
        {
            public void Print() => Console.WriteLine("Printed");

            public void Scan() => throw new NotImplementedException();

            public void Fax() => throw new NotImplementedException();
        }
        static void Main()
        {

            IMachine printer = new OldPrinter();
            printer.Print(); // Works fine

            try
            {
                printer.Scan(); // Will throw NotImplementedException
            }
            catch (NotImplementedException)
            {
                Console.WriteLine("Scan not supported by this printer.");
            }

            try
            {
                printer.Fax(); // Will throw NotImplementedException
            }
            catch (NotImplementedException)
            {
                Console.WriteLine("Fax not supported by this printer.");
            }

        }
    }
}
