using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionFilters
{
    internal class FilterExample1
    {
        static void FilterData(string name)
        {
            string filter = " ";
            if (name.Length >= 0 && name.Length <= 3)
            {
                filter = "small";
            }
            else if (name.Length >= 3 && name.Length <= 10)
            {
                filter = "medium";
            }
            else if (name.Length > 10)
            {
                filter = "good";
            }
            if (filter == "small")
            {
                throw new FilterExceptionUserDefined("small name expception occured");
            }
            else if (filter == "medium")
            {
                throw new FilterExceptionUserDefined("medium name exception occured");
            }
            else if (filter == "good")
            {
                throw new FilterExceptionUserDefined("no error");
            }
            else
            {
                throw new FilterExceptionUserDefined("this case not defined");
            }
        }
        static void Main()
        {
            string name;
            Console.WriteLine("Enter name:");
            name = Console.ReadLine();
            try
            {
                FilterData(name);
            }
            catch (FilterExceptionUserDefined e)when(e.Message.Contains("small"))
            {
                Console.WriteLine(e.Message);
            }
            catch(FilterExceptionUserDefined e)when(e.Message.Contains("medium"))
            {
                Console.WriteLine(e.Message);
            }
            catch(FilterExceptionUserDefined e)
            {
                Console.WriteLine(e.Message);
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
            }

        }

    }
}
