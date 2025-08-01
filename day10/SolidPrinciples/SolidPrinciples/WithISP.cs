using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidPrinciples
{
   
        public class WithISP
        {
            // Separated interfaces
            public interface IPrinter
            {
                void Print();
            }

            public interface IScanner
            {
                void Scan();
            }

            public interface IFax
            {
                void Fax();
            }

            // Old printer: only prints
            public class OldPrinter : IPrinter
            {
                public void Print() => Console.WriteLine("Printed using OldPrinter");
            }

            // Modern multi-function printer: does all
            public class ModernPrinter : IPrinter, IScanner, IFax
            {
                public void Print() => Console.WriteLine("Printed using ModernPrinter");
                public void Scan() => Console.WriteLine("Scanned using ModernPrinter");
                public void Fax() => Console.WriteLine("Faxed using ModernPrinter");
            }

            // Scanner-only device
            public class ScannerMachine : IScanner
            {
                public void Scan() => Console.WriteLine("Scanned using ScannerMachine");
            }

            static void Main()
            {
                IPrinter oldPrinter = new OldPrinter();
                oldPrinter.Print();

                Console.WriteLine();

                ModernPrinter modern = new ModernPrinter();
                modern.Print();
                modern.Scan();
                modern.Fax();

                Console.WriteLine();

                IScanner scanner = new ScannerMachine();
                scanner.Scan();
            }
        }
    }

